using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ServiceTools;
//using System.ServiceProcess;

namespace ScriptRunner.Commands
{
    public class RemoveService:ICommand
    {

        public string Argument()
        {
            return "-rs";
        }

        public string HelpText()
        {
            return "installs the windows service  given the with the correct arguments.\n the arguments will be sevicename";
        }

        public string Name()
        {
            return "RemoveService";
        }

        public object Action(string[] args)
        {
            object ap = null;
            if( args!=null)
            {
                if( (args [0]!=null ) !=null)
                {

                    if (ServiceInstaller.ServiceIsInstalled(args[1]))
                    { 
                        if( ServiceInstaller.GetServiceStatus(args[1])==ServiceState.Starting)
                   
                        {
                       
                            ServiceInstaller.StopService(args[1]);
                   
                        }
                        Console.WriteLine("Removing Service :" + args[1]);
                        ServiceInstaller.Uninstall(args[1]);
                    }
                }
            }
            return ap;
        }
    }
}
