using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace ScrablerService
{
   public  class Program
    {
        public static string ScriptsFolder;
        // static bool hidden;
        
        public static void FindScriptsFolder(string username)
        {

            try
            {
                string tmppath, driveletter,tfold;
                if (username != null)
                {
                    tfold = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    //string[] tmpproffolder;
               //     tmppath = "C:\\Documents and Settings\\" + Environment.UserName + "\\Application Data\\ScrablerService \\" + "Scripts";
                  
                    //    tmppath += "\\" + tmpproffolder;
                    //ScriptsFolder = tfold + " \\ScrablerService\\" + "Scripts";
                    ScriptsFolder = "C:\\Documents and Settings\\" + username + "\\Application Data\\ScrablerService\\" + "Scripts";
                   // MessageBox.Show(ScriptsFolder);
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
            
          Scrabler.Program.Bugtracking(ex);
           // TheDarkOwlLogger.TheDarkOwlLogger.TakeTheExceptiontoXmlLog(ex, Application.ProductName, Application.ProductVersion);

        }
    }
}
