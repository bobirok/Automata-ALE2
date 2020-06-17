using ALE2;
using ALE2.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AutomataTests
{
    [TestClass]
    public class DfaControllerTest
    {
        [TestMethod]
        public void IsDfaShouldReturnFalseWhenEpsilonIsPresent()
        {
            // arrange
            State stateOneMock = new State("S0");
            stateOneMock.outgoingLetters.Add(new Letter('_'));
            Mock<List<Letter>> alphabetMock = new Mock<List<Letter>>();

            List<State> states = new List<State>() { stateOneMock };
            IDfaController dfaController = new DfaController();

            // act
            bool isDfa = dfaController.IsDfa(states, alphabetMock.Object);

            // assert
            Assert.IsFalse(isDfa);
        }

        [TestMethod]
        public void IsDfaShouldReturnFalseWhenStateHasTwoSameOutgoingLetters()
        {
            // arrange
            State stateOneMock = new State("S0");
            Letter letterMock = new Letter('a');
            stateOneMock.outgoingLetters.Add(letterMock);
            stateOneMock.outgoingLetters.Add(letterMock);
            Mock<List<Letter>> alphabetMock = new Mock<List<Letter>>();

            List<State> states = new List<State>() { stateOneMock };
            IDfaController dfaController = new DfaController();

            // act
            bool isDfa = dfaController.IsDfa(states, alphabetMock.Object);

            // assert
            Assert.IsFalse(isDfa);
        }

        [TestMethod]
        public void IsDfaShouldReturnFalseWhenStateHasLessOutgoingLettersThanAlphabet()
        {
            // arrange
            State stateOneMock = new State("S0");
            Letter letterMockOne = new Letter('a');
            Letter letterMockTwo = new Letter('b');
            stateOneMock.outgoingLetters.Add(letterMockOne);
            List<Letter> alphabetMock = new List<Letter>() { letterMockOne, letterMockTwo };

            List<State> states = new List<State>() { stateOneMock };
            IDfaController dfaController = new DfaController();

            // act
            bool isDfa = dfaController.IsDfa(states, alphabetMock);

            // assert
            Assert.IsFalse(isDfa);
        }

        [TestMethod]
        public void IsDfaShouldReturnTrueWhenEveryStateHasEachOutgoingLetterFromAlphabet()
        {
            // arrange
            State stateOneMock = new State("S0");
            Letter letterMockOne = new Letter('a');
            Letter letterMockTwo = new Letter('b');
            stateOneMock.outgoingLetters.Add(letterMockOne);
            stateOneMock.outgoingLetters.Add(letterMockTwo);
            List<Letter> alphabetMock = new List<Letter>() { letterMockOne, letterMockTwo };

            List<State> states = new List<State>() { stateOneMock };
            IDfaController dfaController = new DfaController();

            // act
            bool isDfa = dfaController.IsDfa(states, alphabetMock);

            // assert
            Assert.IsTrue(isDfa);
        }
    }
}
