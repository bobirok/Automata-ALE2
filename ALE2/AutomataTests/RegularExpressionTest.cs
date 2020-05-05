using ALE2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataTests
{
    [TestClass]
    public class RegularExpressionTest
    {
        [TestMethod]
        public void GetNdfaFromRegularExpressionShouldReturnListOfTransitions()
        {
            // arrange
            RegularExpression re1 = new RegularExpression(new Letter('a'));
            RegularExpression re2 = new RegularExpression(new Letter('b'));
            RegularExpression re3 = new RegularExpression(new Letter('.'));
            re3.left = re1;
            re3.right = re2;
            List<Transition> transitions;
            RegularExpressionController regularExpressionController = new RegularExpressionController();

            // act 
            transitions = regularExpressionController.getNdfaFromRegularExpression(re3);

            // assert
            Assert.AreEqual(transitions.Count, 2);
        }
    }
}
