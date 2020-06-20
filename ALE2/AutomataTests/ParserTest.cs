using ALE2.Controllers;
using ALE2.Interfaces;
using ALE2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

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
            Mock<Stack> stackMock = new Mock<Stack>();
            Mock<List<State>> statesMock = new Mock<List<State>>();
            Mock<List<Transition>> transitionsMock = new Mock<List<Transition>>();
            IParser parser = new Parser(alphabet, statesMock.Object, transitionsMock.Object, stackMock.Object);
            string unparsedAlphabet = "abc";

            // act
            parser.ParseAlphabet(unparsedAlphabet);

            // assert
            Assert.AreEqual(alphabet.Count, 3);
        }

        [TestMethod]
        public void parseStatesShouldParseStates()
        {
            // arrange
            List<State> states = new List<State>();
            Mock<List<Letter>> alphabetMock = new Mock<List<Letter>>();
            Mock<Stack> stackMock = new Mock<Stack>();
            Mock<List<Transition>> transitionsMock = new Mock<List<Transition>>();
            IParser parser = new Parser(alphabetMock.Object, states, transitionsMock.Object, stackMock.Object);
            string unparsedStates = "S,A,B,C";

            // act
            parser.ParseStates(unparsedStates);

            // assert
            Assert.AreEqual(states.Count, 4);
        }

        [TestMethod]
        public void parseFinalStateShouldMarkExistingStateAsFinal()
        {
            // arrange
            List<State> states = new List<State>() { new State("S"), new State("B") };
            Mock<List<Letter>> alphabetMock = new Mock<List<Letter>>();
            Mock<Stack> stackMock = new Mock<Stack>();
            Mock<List<Transition>> transitionsMock = new Mock<List<Transition>>();
            IParser parser = new Parser(alphabetMock.Object, states, transitionsMock.Object, stackMock.Object);
            string unparsedFinalStates = "B";

            // act
            parser.ParseFinalStates(unparsedFinalStates);
            State finalState = states.Find(_ => _.data == unparsedFinalStates);

            // assert
            Assert.IsTrue(finalState.isFinalState);
        }

        [TestMethod]
        public void parseTransitionsShouldParseTransitions()
        {
            // arrange
            Mock<Stack> stackMock = new Mock<Stack>();
            List<Letter> alphabet = new List<Letter>() { new Letter('a'), new Letter('b') };
            List<State> states = new List<State>() { new State("S"), new State("B") };
            List<Transition> transitions = new List<Transition>();
            IParser parser = new Parser(alphabet, states, transitions, stackMock.Object);
            string unparsedTransition = "S,a --> B ";

            // act
            parser.ParseTransition(unparsedTransition);
            Transition transition = transitions[0];
            Letter connectingLetter = alphabet.Find(_ => _.data == 'a');

            // assert
            Assert.AreEqual(transitions.Count, 1);
            Assert.AreEqual(transition.connectingLetter, connectingLetter);
        }

        [TestMethod]
        public void parseStackShouldParseStack()
        {
            // arrange
            string stackString = "xyz";

            Mock<List<Letter>> alphabetMock = new Mock<List<Letter>>();
            Mock<List<State>> statesMock = new Mock<List<State>>();
            Mock<List<Transition>> transitionsMock = new Mock<List<Transition>>();

            Stack stack = new Stack();

            IParser parser = new Parser(alphabetMock.Object, statesMock.Object, transitionsMock.Object, stack);

            // act
            parser.ParseStack(stackString);
            string result = "";

            foreach (var letter in stack.possibleElements)
            {
                result += letter.data;
            }

            // assert
            Assert.AreEqual(stackString, result);
        }

        [TestMethod]
        public void wordExistsShouldReturnTrueWhenWordExists()
        {
            // arrange
            Mock<Stack> stackMock = new Mock<Stack>();
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>() { stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>() { new Transition(stateOne, stateTwo, letter) };
            IParser parser = new Parser(alphabet, states, transitions, stackMock.Object);
            string word = "a";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.WordExists(word, stateOne);

            // assert
            Assert.IsTrue(wordExistsInAutomata);
        }

        [TestMethod]
        public void wordExistsShouldReturnFalseWhenWordDoesNotExist()
        {
            // arrange
            Mock<Stack> stackMock = new Mock<Stack>();
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>() { stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>() { new Transition(stateOne, stateTwo, letter) };
            Parser parser = new Parser(alphabet, states, transitions, stackMock.Object);
            string word = "b";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.WordExists(word, stateOne);

            // assert
            Assert.IsFalse(wordExistsInAutomata);
        }

        [TestMethod]
        public void wordExistsShouldReturnTrueWhenWordExistsWithMultipleTransitions()
        {
            // arrange
            Mock<Stack> stackMock = new Mock<Stack>();
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>() { stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>() { new Transition(stateOne, stateTwo, letter),
                                                                    new Transition(stateOne, stateOne, letter) };
            IParser parser = new Parser(alphabet, states, transitions, stackMock.Object);
            string word = "a";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.WordExists(word, stateOne);

            // assert
            Assert.IsTrue(wordExistsInAutomata);
        }

        [TestMethod]
        public void wordExistsShouldReturnFalseWhenWordDoesNotExistWithMultipleTransitions()
        {
            // arrange
            Mock<Stack> stackMock = new Mock<Stack>();
            Letter letter = new Letter('a');
            State stateOne = new State("S");
            State stateTwo = new State("B");
            List<Letter> alphabet = new List<Letter>() { letter };
            List<State> states = new List<State>() { stateOne, stateTwo };
            List<Transition> transitions = new List<Transition>() { new Transition(stateOne, stateTwo, letter),
                                                                    new Transition(stateOne, stateOne, letter) };
            Parser parser = new Parser(alphabet, states, transitions, stackMock.Object);
            string word = "b";

            // act
            stateTwo.isFinalState = true;
            stateOne.outgoingLetters.Add(letter);
            bool wordExistsInAutomata = parser.WordExists(word, stateOne);

            // assert
            Assert.IsFalse(wordExistsInAutomata);
        }
    }
}
