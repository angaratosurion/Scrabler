using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptRunner.Commands
{
    interface ICommand
    {
        string Argument();
        string HelpText();
        string Name();
        object Action(string[] args);

    }
}
