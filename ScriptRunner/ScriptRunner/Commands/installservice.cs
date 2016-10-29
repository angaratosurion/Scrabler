using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ServiceTools;
//using System.ServiceProcess;

namespace ScriptRunner.Commands
{
    public class InstallService: ICommand
    {

        public string Argument()
        {
            return "-is";
        }

        public string HelpText()
        {
            return "installs the windows service  given the with the correct arguments.\n syntax : scriptrunner -is servicename servicedisplayname servicepath";
        }

        public string Name()
        {
            return "InstallService";
        }

        public object Action(string[] args)
        {
            object ap = null;
            if (args != null)
            {
                if ((args[1] != null) && (args[2] != null) && (args[3]) != null)
                {
                    if (!ServiceInstaller.ServiceIsInstalled(args[1]))
                    {
                        if (ServiceInstaller.GetServiceStatus(args[1]) == ServiceState.Starting)
                        {

                            ServiceInstaller.StopService(args[1]);

                        }
                        Console.WriteLine("Installing Service :" + args[1]);
                        ServiceInstaller.InstallAndStart(args[1], args[2], args[3]);
                    }
                }
            }
        
                return ap;
        }
            
        }
    }

