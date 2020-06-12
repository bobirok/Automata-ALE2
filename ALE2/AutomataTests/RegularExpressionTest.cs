using ALE2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using ALE2.Interfaces;

namespace AutomataTests
{
    [TestClass]
    public class RegularExpressionTest
    {
        [TestMethod]
        public void GetNdfaFromRegularExpressionShouldUseLetterRule()
        {
            // arrange
            string formula = "a";
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            // act
            RegularExpression regularExpression = regularExpressionController.GetNdfaFromRegularExpression(ref formula);

            // assert
            Assert.AreEqual(1, regularExpression.transitions.Count);
            Assert.IsTrue(regularExpression.initial.data == "S0");
            Assert.IsTrue(regularExpression.final.data == "S1");
            Assert.IsTrue(regularExpression.final.isFinalState);
        }

        [TestMethod]
        public void GetNdfaFromRegularExpressionShouldUseAndRule()
        {
            // arrange
            string formula = ".(a,b)";
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            // act
            RegularExpression regularExpression = regularExpressionController.GetNdfaFromRegularExpression(ref formula);

            // assert
            Assert.IsTrue(regularExpression.transitions.Count == 2);
            Assert.IsTrue(regularExpression.transitions.Exists(_ => _.connectingLetter.data == 'a'));
            Assert.IsTrue(regularExpression.transitions.Exists(_ => _.connectingLetter.data == 'b'));
            Assert.IsTrue(regularExpression.final.isFinalState);
        }

        [TestMethod]
        public void GetNdfaFromRegularExpressionShouldUseOrRule()
        {
            // arrange
            string formula = "|(a,b)";
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            // act 
            RegularExpression regularExpression = regularExpressionController.GetNdfaFromRegularExpression(ref formula);

            // assert
            Assert.IsTrue(regularExpression.transitions.Count == 6);
            Assert.IsTrue(regularExpression.transitions.Exists(_ => _.connectingLetter.data == 'a'));
            Assert.IsTrue(regularExpression.transitions.Exists(_ => _.connectingLetter.data == 'b'));
            Assert.IsTrue(regularExpression.final.isFinalState);
        }

        [TestMethod]
        public void GetNdfaFromRegularExpressionShouldUseStarRule()
        {
            // arrange
            string formula = "*(a)";
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            // act 
            RegularExpression regularExpression = regularExpressionController.GetNdfaFromRegularExpression(ref formula);

            // assert
            Assert.IsTrue(regularExpression.transitions.Count == 5);
            Assert.IsTrue(regularExpression.transitions.Exists(_ => _.connectingLetter.data == 'a'));
            Assert.IsTrue(regularExpression.final.isFinalState);
            Assert.AreEqual(4, regularExpression.transitions.FindAll(_ => _.connectingLetter.data == '_').Count);
        }

        [TestMethod]
        public void GetNdfaFromRegularExpressionShouldReturnListOfTransitions()
        {
            // arrange
            string formula = "*(|(.(a,b),a))";
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            // act 
            RegularExpression regularExpression = regularExpressionController.GetNdfaFromRegularExpression(ref formula);

            // assert
            Assert.AreEqual(11, regularExpression.transitions.Count);
            Assert.IsTrue(regularExpression.final.isFinalState);
        }

        [TestMethod]
        public void GetNDfaFromRegularExpressionAsStringShouldReturnDNfaAsString()
        {
            // arrange
            State stateOneMock = new State("S0");
            State stateTwoMock = new State("S1");
            Letter letterOneMock = new Letter('a');
            Letter letterTwoMock = new Letter('b');
            List<State> statesMock = new List<State>() { stateOneMock, stateTwoMock };
            List<Letter> alphabetMock = new List<Letter>() { letterOneMock, letterTwoMock };
            List<Transition> transitionsMock = new List<Transition>() { new Transition(stateOneMock, stateTwoMock, letterOneMock),
                                                                        new Transition(stateTwoMock, stateOneMock, letterTwoMock)};

            Mock<RegularExpressionController> regularExpressionController = new Mock<RegularExpressionController>();

            // act
            regularExpressionController.Setup(_ => _.ExtractStatesFromTransitions(It.IsAny<List<Transition>>())).Returns(statesMock);
            regularExpressionController.Setup(_ => _.ExtractAlphabetFromTransitions(It.IsAny<List<Transition>>())).Returns(alphabetMock);

            string result = regularExpressionController.Object.GetNDfaFromRegularExpressionAsString(transitionsMock);

            // assert
            Assert.IsTrue(result.Contains("alphabet: ab"));
            Assert.IsTrue(result.Contains("states: S0,S1"));
            Assert.IsTrue(result.Contains("S0,a --> S1"));
            Assert.IsTrue(result.Contains("S1,b --> S0"));
        }

        [TestMethod]
        public void ExtractStatesFromTransitionsShouldReturnListOfStatesFromTransitions()
        {
            // arrange
            State stateOneMock = new State("S0");
            State stateTwoMock = new State("S1");
            Letter letterOneMock = new Letter('a');
            Letter letterTwoMock = new Letter('b');
            List<Transition> transitionsMock = new List<Transition>() { new Transition(stateOneMock, stateTwoMock, letterOneMock),
                                                                        new Transition(stateTwoMock, stateOneMock, letterTwoMock)};
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            // act
            List<State> statesResult = regularExpressionController.ExtractStatesFromTransitions(transitionsMock);

            // assert
            Assert.AreEqual(2, statesResult.Count);
            Assert.IsTrue(statesResult[0].data == "S0");
            Assert.IsTrue(statesResult[1].data == "S1");
        }

        [TestMethod]
        public void ExtractAlphabetFromTransitionsShouldReturnAlphabetFromTransitions()
        {
            // arrange
            State stateOneMock = new State("S0");
            State stateTwoMock = new State("S1");
            Letter letterOneMock = new Letter('a');
            Letter letterTwoMock = new Letter('b');
            List<Transition> transitionsMock = new List<Transition>() { new Transition(stateOneMock, stateTwoMock, letterOneMock),
                                                                        new Transition(stateTwoMock, stateOneMock, letterTwoMock)};
            IRegularExpressionController regularExpressionController = new RegularExpressionController();

            // act
            List<Letter> statesResult = regularExpressionController.ExtractAlphabetFromTransitions(transitionsMock);

            // assert
            Assert.AreEqual(2, statesResult.Count);
            Assert.IsTrue(statesResult[0].data == 'a');
            Assert.IsTrue(statesResult[1].data == 'b');
        }
    }
}
