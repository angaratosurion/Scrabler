using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ScriptRunner.Commands
{
    public class Noarguments:ICommand
    {
        public string Argument()
        {
            return " ";
        }

        public string HelpText()
        {
            return this.Name() + ":\nArgument: " + this.Argument() + "\n Description: excutes the script "; 
        }

        public string Name()
        {
            return "Noarguments";
        }

        public object Action(string[] args)
        {
            Core core = new Core();
            //core.createScriptsDirectory();

            //core.Autoexecutescripts(Environment.UserName, 2);
            Console.WriteLine(args[0]);
           return  core.Executescript(args[0]);
            Application.Run();
            return null;
        }
    }
}
