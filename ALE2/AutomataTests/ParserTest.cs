using System;
using System.Collections.Generic;
using ALE2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutomataTests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void parseAlphabetShouldParseAlphabet()
        {
            // arrange
            List<Letter> alphabet = new List<Letter>();
            Mock<List<State>> statesMock = new Mock<List<State>>();
            Mock<List<Transition>> transitionsMock = new Mock<List<Transition>>();
            Parser parser = new Parser(alphabet, statesMock.Object, transitionsMock.Object);
            string unparsedAlphabet = "abc";

            // act
            parser.parseAlphabet(unparsedAlphabet);

            // assert
            Assert.AreEqual(alphabet.Count, 3);
        }

        [TestMethod]
        public void parseStatesShouldParseStates()
        {
            // arrange
            List<State> states = new List<State>();
            Mock<List<Letter>> alphabetMock = new Mock<List<Letter>>();
            Mock<List<Transition>> transitionsMock = new Mock<List<Transition>>();
            Parser parser = new Parser(alphabetMock.Object, states, transitionsMock.Object);
            string unparsedStates = "S,A,B,C";

            // act
            parser.parseStates(unparsedStates);

            // assert
            Assert.AreEqual(states.Count, 4);
        }

        [TestMethod]
        public void parseFinalStateShouldMarkExistingStateAsFinal()
        {
            // arrange
            List<State> states = new List<State>() { new State("S"), new State("B") };
            Mock<List<Letter>> alphabetMock = new Mock<List<Letter>>();
            Mock<List<Transition>> transitionsMock = new Mock<List<Transition>>();
            Parser parser = new Parser(alphabetMock.Object, states, transitionsMock.Object);
            string unparsedFinalStates = "B";

            // act
            parser.parseFinalStates(unparsedFinalStates);
            State finalState = states.Find(_ => _.data == unparsedFinalStates);

            // assert
            Assert.IsTrue(finalState.isFinalState);
        }

        [TestMethod]
        public void parseTransitionsShouldParseTransitions()
        {
            // arrange
            List<Letter> alphabet = new List<Letter>() { new Letter('a'), new Letter('b') };
            List<State> states = new List<State>() { new State("S"), new State("B") };
            List<Transition> transitions = new List<Transition>();
            Parser parser = new Parser(alphabet, states, transitions);
            string unparsedTransition = "S,a --> B ";

            // act
            parser.parseTransition(unparsedTransition);
            Transition transition = transitions[0];
            Letter connectingLetter = alphabet.Find(_ => _.data == 'a');

            // assert
            Assert.AreEqual(transitions.Count, 1);
            Assert.AreEqual(transition.connectingLetter, connectingLetter);
        }

        [TestMethod]
        public void wordExistsShouldReturnTrueWhenWordExists()
        {
            // arrange
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>(){ stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>(){ new Transition(stateOne, stateTwo, letter)};
            Parser parser = new Parser(alphabet, states, transitions);
            string word = "a";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.wordExists(word, stateOne);

            // assert
            Assert.IsTrue(wordExistsInAutomata);
        }

        [TestMethod]
        public void wordExistsShouldReturnFalseWhenWordDoesNotExist()
        {
            // arrange
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>() { stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>() { new Transition(stateOne, stateTwo, letter) };
            Parser parser = new Parser(alphabet, states, transitions);
            string word = "b";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.wordExists(word, stateOne);

            // assert
            Assert.IsFalse(wordExistsInAutomata);
        }

        [TestMethod]
        public void wordExistsShouldReturnTrueWhenWordExistsWithMultipleTransitions()
        {
            // arrange
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>() { stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>() { new Transition(stateOne, stateTwo, letter), 
                                                                    new Transition(stateOne, stateOne, letter) };
            Parser parser = new Parser(alphabet, states, transitions);
            string word = "a";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.wordExists(word, stateOne);

            // assert
            Assert.IsTrue(wordExistsInAutomata);
        }

        [TestMethod]
        public void wordExistsShouldReturnFalseWhenWordDoesNotExistWithMultipleTransitions()
        {
            // arrange
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>() { stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>() { new Transition(stateOne, stateTwo, letter),
                                                                    new Transition(stateOne, stateOne, letter) };
            Parser parser = new Parser(alphabet, states, transitions);
            string word = "b";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.wordExists(word, stateOne);

            // assert
            Assert.IsFalse(wordExistsInAutomata);
        }
    }
}
