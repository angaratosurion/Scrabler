using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
namespace ScrablerRunnerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new ScrablerRunnerService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
        public static string ScriptsFolder;
        // static bool hidden;
        //static TheDarkOwlLogger.TheDarkOwlLogger bugger = new TheDarkOwlLogger.TheDarkOwlLogger();
        public static void FindScriptsFolder()
        {

            try
            {
                string tmppath, driveletter, tfold;
               // if (username != null)
                {
                    tfold = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    //string[] tmpproffolder;
                    //     tmppath = "C:\\Documents and Settings\\" + Environment.UserName + "\\Application Data\\ScrablerService \\" + "Scripts";

                    //    tmppath += "\\" + tmpproffolder;
                    //ScriptsFolder = tfold + " \\ScrablerService\\" + "Scripts";
                    //ScriptsFolder = "C:\\Documents and Settings\\" + username + "\\Application Data\\ScrablerService\\" + "Scripts";
                    ScriptsFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Scripts");


                    
                }
                ;

            }
            catch (Exception ex)
            {

                Program.errorreporting(ex);
                //return null;
            }

        }
        //public static MesageConsole Console;
        public static void errorreporting(Exception ex)
        {
            //  ;

            //bugger.TakeTheException2XmlLog(ex, Application.ProductName, Application.ProductVersion);
            // TheDarkOwlLogger.TheDarkOwlLogger.TakeTheExceptiontoXmlLog(ex, Application.ProductName, Application.ProductVersion);
            Scrabler.Program.Bugtracking(ex);
            MessageBox.Show(ex.ToString());

        }
    }
}
