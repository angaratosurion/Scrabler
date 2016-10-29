using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScriptRunner.Commands
{
  public   class ShownWindow:ICommand
    {
      public string Argument()
      {
           return "-w"; 
      }
      public string Name()
      {
          return "Show window"; 
      }

      public string HelpText()
      {
         return this.Name()+ ":\nArgument: "+ this.Argument()+"\n Description: makes the Console window "; 
      }
      public object Action(string[] args)
      {
          Core core = new Core();
          Application.EnableVisualStyles();
          //  Application.SetCompatibleTextRenderingDefault(false);
          string[] files = Directory.GetFiles(Program.ScriptsFolder);
          string tmp = core.SearchList(files, Program.autostartscript);
          core.Executescript(tmp);
          Application.Run(new MesageConsole());
          if (args[1] != null)
          {
              //   Core core = new Core();
              core.Executescript(args[1]);

          }
        return null;
      }
    }
}
