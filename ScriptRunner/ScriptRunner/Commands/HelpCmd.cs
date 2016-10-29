using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptRunner.Commands
{
    public class HelpCmd:ICommand
    {
        public string Argument()
        {
            return "-?";
        }

        public string HelpText()
        {
            return this.Name() + ":\nArgument: " + this.Argument() + "\n Description: shows the list of commands "; 
        }

        public string Name()
        {
            return "help";
        }

        public object Action(string[] args)
        {
            foreach (ICommand cmd in Program.commands)
            {

                Console.WriteLine(cmd.HelpText());
            }
            return null;
           
        }
    }
}
