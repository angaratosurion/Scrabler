using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptRunner;
using System.Windows.Forms;
using System.IO;

namespace ScriptRunner.Commands
{
   public class AutoscriptExecution:ICommand
    { 
      public string Argument()
      {
           return "-as"; 
      }
      public string Name()
      {
           return "AutoscriptExecution"; 
      }

      public string HelpText()
      {
        return this.Name()+ ":\nArgument: "+ this.Argument()+"\n Description: makes the Console window "; 
      }
      public object Action(string[] args)
      {

          Core core = new Core();
          core.Executescript(Program.autostartscript);

          return null;
      }
    
    }
}
