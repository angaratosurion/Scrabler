using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Hydrobase;
using HydrobaseSDK;
using WareForms;

//using pigeon;
using System.Configuration;

//using HydroMultyUser;
using Scrabler;
using ScriptRunner.Commands;
using System.Runtime.InteropServices;
namespace ScriptRunner
{
    public static class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public static string ScriptsFolder;
// static bool hidden;
        public static void FindScriptsFolder()
        {

            try
            {
                string tmppath, driveletter;
                //string[] tmpproffolder;
                tmppath = "C:\\Documents and Settings\\" + Environment.UserName + "\\Application Data\\" + Application.ProductName + "\\" + "Scripts";
               
            //    tmppath += "\\" + tmpproffolder;
                ScriptsFolder = tmppath;


            }
            catch (Exception ex)
            {

                Program.errorreporting(ex);
                //return null;
            }

        }
        public static MesageConsole Console;
        public const string autostartscript = "autostart.scrf";
       internal  static List<Commands.ICommand> commands;
     
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      ///
        [STAThread]
        static void Main(string[] args)
        {
            IntPtr hWnd = FindWindow(null, "scriptrunner"); //put your console window caption here

            if (hWnd != IntPtr.Zero)
            {

                //Hide the window

                ShowWindow(hWnd, 0); // 0 = SW_HIDE

            }





            if (hWnd != IntPtr.Zero)
            {

                //Show window again

                ShowWindow(hWnd, 1); //1 = SW_SHOWNORMA

            }
            Core core = new Core();
            Allias  opt = new Allias();
            List<Commands.ICommand> commands = new List<Commands.ICommand>();
            ICommand [] cms = {new AutoscriptExecution(),new FileScriptExe(),new HiddenWin(),new Noarguments(),new ShownWindow(), new HelpCmd(),
                              new InstallService(),new RemoveService()};
            commands.AddRange(cms);

            Program.commands = commands;
            opt.CreateOptions();
            opt.LoadAlliaces ();
            //opt.LoadAlliaces();
            if (args.Length>1 )
            {
                foreach (ICommand cmd in commands)
                {

                    if ((args[0].Equals(cmd.Argument())) || (args[0].Contains(cmd.Argument())))
                    {
                        cmd.Action(args);
                        break;

                    }
                }
                System.Console.ReadLine();


                Application.Run();
            }
            else
            {
                HelpCmd helpcmd = new HelpCmd();
                helpcmd.Action(null);
                System.Console.ReadLine();
                Application.Exit();
                

            }

         
           
            
        }
        public static void errorreporting(Exception ex)
        {
            NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
            Log.TraceException(ex.Message, ex);


        }
    }
}