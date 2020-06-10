using ALE2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2.Interfaces
{
    public interface IStackController
    {
        bool WordWithStackExists(string word, State currentState, Stack stack);
    }
}
