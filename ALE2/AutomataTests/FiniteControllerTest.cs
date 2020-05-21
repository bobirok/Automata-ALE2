using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE2;
namespace AutomataTests
{
    /// <summary>
    /// Summary description for FiniteControllerTest
    /// </summary>
    [TestClass]
    public class FiniteControllerTest
    {
        [TestMethod]
        public void InitializeAllTracesShouldCreateAllPossibleTraces()
        {
            // arrange
            State s1 = new State("S1");
            State s2 = new State("S2");
            State s3 = new State("S3");
            s3.isFinalState = true;
            Letter l1 = new Letter('a');
            List<Transition> transitions = new List<Transition>() { new Transition(s1, s2, l1), new Transition(s2, s3, l1) };
            FiniteController finiteController = new FiniteController(new List<Trace>(), transitions);

            // act
            finiteController.InstantiateTraces(s1, s1, new List<Transition>());

            // assert
            Assert.IsTrue(finiteController.traces.Count == 1);
        }

        [TestMethod]
        public void InitializeAllTracesShouldCreateAllPossibleTracesWithCycles()
        {
            // arrange
            State s1 = new State("S1");
            State s2 = new State("S2");
            State s3 = new State("S3");
            s3.isFinalState = true;
            Letter l1 = new Letter('a');
            List<Transition> transitions = new List<Transition>() { new Transition(s1, s2, l1), new Transition(s2, s3, l1), 
                new Transition(s2, s2, l1), new Transition(s2, s1, l1) };
            FiniteController finiteController = new FiniteController(new List<Trace>(), transitions);

            // act
            finiteController.InstantiateTraces(s1, s1, new List<Transition>());

            // assert
            Assert.IsTrue(finiteController.traces.Count == 1);
        }

        [TestMethod]
        public void AutomataIsFiniteShouldReturnTrue()
        {
            // arrange
            State s1 = new State("S1");
            State s2 = new State("S2");
            State s3 = new State("S3");
            s3.isFinalState = true;
            Letter l1 = new Letter('a');
            List<Transition> transitions = new List<Transition>() { new Transition(s1, s2, l1), new Transition(s2, s3, l1) };
            FiniteController finiteController = new FiniteController(new List<Trace>(), transitions);

            // act
            finiteController.InstantiateTraces(s1, s1, new List<Transition>());
            var isFinite = finiteController.AutomataIsFinite();

            // assert
            Assert.IsTrue(isFinite);
        }

        [TestMethod]
        public void AutomataIsFiniteShouldReturnTrueWhenHasNoOutGoingLetters()
        {
            // arrange
            State s1 = new State("S1");
            State s2 = new State("S2");
            State s3 = new State("S3");
            Letter l1 = new Letter('a');
            s3.isFinalState = true;
            List<Transition> transitions = new List<Transition>() { new Transition(s1, s2, l1), new Transition(s2, s3, l1),
                new Transition(s2, s2, l1), new Transition(s2, s1, l1) };
            FiniteController finiteController = new FiniteController(new List<Trace>(), transitions);

            // act
            finiteController.InstantiateTraces(s1, s1, new List<Transition>());
            var isFinite = finiteController.AutomataIsFinite();

            // assert
            Assert.IsFalse(isFinite);
        }

        [TestMethod]
        public void AutomataIsFiniteShouldReturnFalseWhenHasCycle()
        {
            // arrange
            State s1 = new State("S1");
            State s2 = new State("S2");
            State s3 = new State("S3");
            Letter l1 = new Letter('a');
            s3.isFinalState = true;
            s1.outgoingLetters.Add(l1);
            s2.outgoingLetters.Add(l1);
            s3.outgoingLetters.Add(l1);
            List<Transition> transitions = new List<Transition>() { new Transition(s1, s2, l1), new Transition(s2, s3, l1),
                new Transition(s2, s2, l1), new Transition(s2, s1, l1) };
            FiniteController finiteController = new FiniteController(new List<Trace>(), transitions);

            // act
            finiteController.InstantiateTraces(s1, s1, new List<Transition>());
            var isFinite = finiteController.AutomataIsFinite();

            // assert
            Assert.IsFalse(isFinite);
        }

        [TestMethod]
        public void ExtractAllWordsFromAutomataShouldReturnAllWordsFromAutomata()
        {
            // arrange
            State s1 = new State("S1");
            State s2 = new State("S2");
            State s3 = new State("S3");
            s3.isFinalState = true;
            Letter l1 = new Letter('a');
            List<Transition> transitions = new List<Transition>() { new Transition(s1, s2, l1), new Transition(s2, s3, l1) };
            FiniteController finiteController = new FiniteController(new List<Trace>(), transitions);

            // act
            finiteController.InstantiateTraces(s1, s1, new List<Transition>());
            var words = finiteController.ExtractAllWordsFromAutomata();

            // assert
            Assert.AreEqual(words[0].word, "aa");
        }
    }
}
