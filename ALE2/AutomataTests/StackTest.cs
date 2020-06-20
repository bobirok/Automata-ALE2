using ALE2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomataTests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void PushStackShouldPushLetterToStack()
        {
            // arrange
            Stack stack = new Stack();

            // act
            stack.PushToStack(new Letter('a'));
            stack.PushToStack(new Letter('b'));

            // assert
            Assert.AreEqual(2, stack.elements.Count);
        }

        [TestMethod]
        public void StackIsEmptyShouldReturnTrue()
        {
            // arrange
            Stack stack = new Stack();

            // act
            // nothing to act

            // assert
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void StackIsEmotyShouldReturnFalse()
        {
            // arrange
            Stack stack = new Stack();

            // act
            stack.PushToStack(new Letter('a'));
            stack.PushToStack(new Letter('b'));

            // assert
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void GetCurrentTopStackShouldReturnTopElementOfStack()
        {
            // arrange
            Stack stack = new Stack();
            Letter a = new Letter('a');
            Letter b = new Letter('b');

            // act
            stack.PushToStack(a);
            stack.PushToStack(b);

            // assert
            Assert.IsTrue(stack.GetCurrentTopStack().Equals(b));
        }

        [TestMethod]
        public void PopStackShouldRemoveTopElement()
        {
            // arrange
            Stack stack = new Stack();

            // act
            stack.PushToStack(new Letter('a'));
            stack.PushToStack(new Letter('b'));

            stack.PopStack();

            // assert
            Assert.AreEqual(1, stack.elements.Count);
        }
    }
}
