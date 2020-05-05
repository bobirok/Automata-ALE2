using System;
using ALE2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomataTests
{
    [TestClass]
    public class StateTest
    {
        [TestMethod]
        public void GetShapeStringShouldReturnCircle()
        {
            // arrange
            State state = new State("S1");

            // act
            state.isFinalState = false;

            // assert
            Assert.IsTrue(state.GetShapeString() == "circle");
        }

        [TestMethod]
        public void GetShapeStringShouldReturnDoubleCircle()
        {
            // arrange
            State state = new State("S2");

            // act
            state.isFinalState = true;

            // assert
            Assert.IsTrue(state.GetShapeString() == "doublecircle");
        }
    }
}
