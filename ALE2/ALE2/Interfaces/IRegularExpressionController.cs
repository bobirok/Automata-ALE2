using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Interfaces
{
    public interface IRegularExpressionController
    {
        RegularExpression GetNdfaFromRegularExpression(ref string formula);

        string GetNDfaFromRegularExpressionAsString(List<Transition> transitions);

        List<State> ExtractStatesFromTransitions(List<Transition> transitions);

        List<Letter> ExtractAlphabetFromTransitions(List<Transition> transitions);
    }
}
