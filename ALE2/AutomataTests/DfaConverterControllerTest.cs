using ALE2.Controllers;
using ALE2.Interfaces;
using ALE2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AutomataTests
{
    [TestClass]
    public class DfaConverterControllerTest
    {
        [TestMethod]
        public void produceDfaTableShouldProduceDfaTable()
        {
            // arrange
            Letter a = new Letter('a');
            Letter b = new Letter('b');
            State s1 = new State("S1");
            State s2 = new State("S2");
            s2.isFinalState = true;
            State s3 = new State("S3");
            State s4 = new State("S4");
            s4.isFinalState = true;
            State s5 = new State("S5");
            List<Transition> transitions = new List<Transition>()
            {
                new Transition(s1, s2, new Letter('_')),
                new Transition(s1, s2, a),
                new Transition(s2, s3, b),
                new Transition(s2, s3, a),
                new Transition(s3, s2, a),
                new Transition(s3, s1, new Letter('_')),
                new Transition(s3, s4, b),
                new Transition(s4, s2, new Letter('_')),
                new Transition(s4, s5, b)
            };

            AutomataTable table = new AutomataTable();

            IDfaConverterController dfaConverterController = new DfaConverterController(table, transitions);

            // act
            AutomataTable result = dfaConverterController.ProduceDfaTable(new List<State>() { s1, s2, s3, s4, s5 },
                    new List<Letter>() { a, b });
            result.rows = result.rows.Distinct().ToList();

            // assert
            Assert.AreEqual(12, result.rows.Count);
            Assert.AreEqual("{S1S2}", result.rows[0].cells[0].AsString());
        }
    }
}
