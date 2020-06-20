using ALE2.Controllers;
using ALE2.Interfaces;
using ALE2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AutomataTests
{
    [TestClass]
    public class ParserControllerTest
    {
        [TestMethod]
        public void ParseShouldParseGivenString()
        {
            // arrange
            Mock<Stack> stackMock = new Mock<Stack>();
            List<Letter> alphabet = new List<Letter>();
            List<State> states = new List<State>();
            List<Transition> transitions = new List<Transition>();
            List<Word> words = new List<Word>();
            IParserController parserController = new ParserController(alphabet, states, transitions, stackMock.Object, words);
            string[] lines = new string[] { "alphabet: ab", "states: S0,S1", "final: S1", "transitions:", "S0,a --> S1", "S1,b --> S0", "end.", "words:", "ab, n", "a, y", "end." };

            // act
            parserController.Parse(lines);

            // assert
            Assert.AreEqual(2, states.Count);
            Assert.AreEqual(2, alphabet.Count);
            Assert.AreEqual(2, transitions.Count);
            Assert.IsTrue(states[1].isFinalState);

            Assert.IsFalse(words[0].existsInAutomata);
            Assert.IsFalse(words[0].expectedWordExistance);
            Assert.AreEqual("ab", words[0].word);

            Assert.IsTrue(words[1].expectedWordExistance);
            Assert.IsTrue(words[1].existsInAutomata);
            Assert.AreEqual("a", words[1].word);
        }
    }
}
