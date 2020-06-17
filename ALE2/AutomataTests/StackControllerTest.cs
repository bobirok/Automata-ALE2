using ALE2;
using ALE2.Controllers;
using ALE2.Interfaces;
using ALE2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AutomataTests
{
    [TestClass]
    public class StackControllerTest
    {
        [TestMethod]
        public void WordWithStackExistsShouldReturnTrue()
        {
            // arrange
            string[] lines = new string[] {"alphabet: ab",
                                "states: N0,N1,N2",
                                "stack: x",
                                "final: N0,N2",
                                "transitions:",
                                "N0,_[_,x] --> N1",
                                "N1,_[x,_]--> N0",
                                "N1,a-- > N2",
                                "end.",
                                };

            List<Transition> transitions = new List<Transition>();
            List<State> states = new List<State>();
            List<Letter> alphabet = new List<Letter>();
            List<Word> words = new List<Word>();
            Stack stack = new Stack();

            IParserController parserController = new ParserController(alphabet, states, transitions, stack, words);
            IStackController stackController = new StackController(transitions, stack);

            // act
            parserController.Parse(lines);

            // assert
            Assert.IsTrue(stackController.WordWithStackExists("aa", states[0], stack));
        }

        [TestMethod]
        public void WordWithStackExistsShouldReturnFalse()
        {
            // arrange
            string[] lines = new string[] {"alphabet: ab",
                                "states: N0,N1,N2",
                                "stack: x",
                                "final: N2",
                                "transitions:",
                                "N0,_[_,x] --> N1",
                                "N1,_[x,_]--> N0",
                                "N1,a-- > N2",
                                "end.",
                                };

            List<Transition> transitions = new List<Transition>();
            List<State> states = new List<State>();
            List<Letter> alphabet = new List<Letter>();
            List<Word> words = new List<Word>();
            Stack stack = new Stack();

            IParserController parserController = new ParserController(alphabet, states, transitions, stack, words);
            IStackController stackController = new StackController(transitions, stack);

            // act
            parserController.Parse(lines);

            // assert
            Assert.IsFalse(stackController.WordWithStackExists("aa", states[0], stack));
        }

        [TestMethod]
        public void WordWithStackExistsShouldCheckWithMultipleWords()
        {
            // arrange
            string[] lines = new string[] { "alphabet: abc",
                                            "stack: x",
                                            "states: S,B,C",
                                            "final: C",
                                            "transitions:",
                                            "S,a[_,x]-- > S",
                                            "S,_-- > B",
                                            "B,b[_,x]-- > B",
                                            "B,_-- > C",
                                            "C,c[x,_]-- > C",
                                            "end." };

            List<Transition> transitions = new List<Transition>();
            List<State> states = new List<State>();
            List<Letter> alphabet = new List<Letter>();
            List<Word> words = new List<Word>();
            Stack stack = new Stack();

            IParserController parserController = new ParserController(alphabet, states, transitions, stack, words);
            IStackController stackController = new StackController(transitions, stack);

            // act
            parserController.Parse(lines);

            // assert
            Assert.IsTrue(stackController.WordWithStackExists("abcc", states[0], new Stack()));
            Assert.IsTrue(stackController.WordWithStackExists("aacc", states[0], new Stack()));
            Assert.IsTrue(stackController.WordWithStackExists("bbbccc", states[0], new Stack()));
            Assert.IsFalse(stackController.WordWithStackExists("aaabbcccc", states[0], new Stack()));
            Assert.IsFalse(stackController.WordWithStackExists("aabbccccc", states[0], new Stack()));
            Assert.IsFalse(stackController.WordWithStackExists("bbaccc", states[0], new Stack()));

        }
    }
}
