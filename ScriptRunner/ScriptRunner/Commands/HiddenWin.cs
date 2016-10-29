using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ScriptRunner.Commands
{
   public class HiddenWin:ICommand 
    {
        public string Argument()
        {
            return "-hidden";
        }

        public string HelpText()
        {
            return this.Name() + ":\nArgument: " + this.Argument() + "\n Description: hides the Console window "; 
        }

        public string Name()
        {
            return "HiddenWin";
        }

        public object Action(string[] args)
        {
            Core core = new Core();
            core.createScriptsDirectory();

            core.Autoexecutescripts(Environment.UserName, 2);
            Application.Run();
            return null;
        }
    }
}
