using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScriptRunner.Commands
{
    class FileScriptExe:ICommand
    {
        public string Argument()
        {
           return "-af"; 
        }
        public string Name()
        {
           return "FilescriptExecution"; 
        }

        public string HelpText()
        {
           return this.Name() + ":\nArgument: " + this.Argument() + "\n Description:Executes the script from the given file"; 
        }
        public object Action(string[] args)
        {

            Core core = new Core();
            if (args[1] != null)
            {
                //   Core core = new Core();
                string t= Path.GetDirectoryName(Application.ExecutablePath) + "\\scripts\\" + args[1];
               // MessageBox.Show(t);
                //core.Executescript(t);
                System.Console.WriteLine(args[1]);
                return core.Executescript( args[1]);

            }
            return null;
        }
    }
}
