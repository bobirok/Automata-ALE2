using ALE2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace AutomataTests
{
    [TestClass]
    public class DeepCopyTest
    {
        [TestMethod]
        public void CopyLetterShouldCreateDeepCopyOfLetter()
        {
            // arrange
            Letter a = new Letter('a');
            Letter b = new Letter('b');

            Letter aCopy, bCopy;

            // act
            aCopy = a.CopyLetter();
            bCopy = b.CopyLetter();

            // assert
            Assert.IsTrue(a.Equals(aCopy));
            Assert.IsTrue(b.Equals(bCopy));
        }

        [TestMethod]
        public void CopyStateShouldCreateDeepCopyOfState()
        {
            // arrange
            State S1 = new State("S1");
            State S2 = new State("S2");

            State S1Copy, S2Copy;

            // act
            S1Copy = S1.CopyState();
            S2Copy = S2.CopyState();

            // assert
            Assert.IsTrue(S1.Equals(S1Copy));
            Assert.IsTrue(S2.Equals(S2Copy));
        }

        [TestMethod]
        public void CopyTransitionShouldCreateDeepCopyOfTransition()
        {
            // arrange
            State S1 = new State("S1");
            State S2 = new State("S2");
            Letter a = new Letter('a');
            Letter b = new Letter('b');

            Transition t1 = new Transition(S1, S2, a);
            Transition t2 = new Transition(S2, S1, b);

            Transition t1Copy, t2Copy;

            // act 
            t1Copy = t1.CopyTransition();
            t2Copy = t2.CopyTransition();

            // assert
            Assert.IsTrue(t1.Equals(t1Copy));
            Assert.IsTrue(t2.Equals(t2Copy));
        }

        [TestMethod]
        public void WordEqualsShouldReturnFalseWhenWordsAreDifferent()
        {
            // arrange
            Word word1 = new Word("aa", true, true);
            Word word2 = new Word("ab", true, true);

            // act
            // nothing to act

            // assert
            Assert.IsFalse(word1.Equals(word2));
        }

        [TestMethod]
        public void WordEqualsShouldReturnFalseWhenExpectedIsDifferent()
        {
            // arrange
            Word word1 = new Word("aa", true, true);
            Word word2 = new Word("aa", false, true);

            // act
            // nothing to act

            // assert
            Assert.IsFalse(word1.Equals(word2));
        }

        [TestMethod]
        public void WordEqualsSholdReturnTrueWhenWordsEqual()
        {
            // arrange
            Word word1 = new Word("aa", true, true);
            Word word2 = new Word("aa", true, true);

            // act
            // nothing to act

            // assert
            Assert.IsTrue(word1.Equals(word2));
        }

        [TestMethod]
        public void CopyStackShouldCopyStack()
        {
            // arrange
            Stack stack = new Stack();
            Stack stackCopy;

            // act
            stack.PushToStack(new Letter('a'));
            stack.PushToStack(new Letter('b'));
            stack.PushToStack(new Letter('c'));

            stackCopy = stack.CopyStack();

            // assert
            Assert.IsTrue(stack.elements.SequenceEqual(stackCopy.elements));
        }

        [TestMethod]
        public void CopyTraceShouldCreateDeepCopyOfTrace()
        {
            // arrange
            State initialState = new State("S1");
            State lastState = new State("S2");

            Transition transition1 = new Transition(initialState, lastState, new Letter('a'));
            Transition transition2 = new Transition(lastState, initialState, new Letter('b'));

            Trace trace = new Trace(new List<Transition>() { transition1, transition2 }, initialState);

            trace.visitedStates.Add(initialState);

            Trace traceCopy;

            // act
            traceCopy = trace.CopyTrace();

            // assert
            Assert.IsTrue(trace.Equals(traceCopy));
        }
    }
}
