using System.Collections.Generic;

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
