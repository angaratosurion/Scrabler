using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Security;
using System.Security.Principal;
using System.Management;
using System.Management.Instrumentation;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;
using System.Reflection;
using Scrabler;
using Hydrobase;
using ScriptRunner;

namespace ScrablerRunnerService
{
    public partial class ScrablerRunnerService : ServiceBase
    {
       // ScrablerService.ScrablerServiceClient clnt=null;
        DataSet set = new DataSet();
        string username, password;
        hydrobaseADO ado = new hydrobaseADO();
        ScrablerCore scarabler = new ScrablerCore();
        Scrabler.ScrablerV2 scr2 = new ScrablerV2();
        List<Process> aproc = new List<Process>();
        public void createScriptsDirectory()
        {


            try
            {
            //    if (username != null)
                {
                    Program.FindScriptsFolder();
                    string path;
                    //  MessageBox.Show(Program.ScriptsFolder);
                    if (Program.ScriptsFolder != null)
                    {
                        if (Directory.Exists(Program.ScriptsFolder) == false)
                        {
                            // MessageBox.Show(Program.ScriptsFolder + "\\" + ScrablerCore.ScriptsFolder);
                            Directory.CreateDirectory(Program.ScriptsFolder);




                        }



                    }
                }
                // webBrowser.ScriptsFolder = Program.ScriptsFolder + "\\" + ScrablerCore.ScriptsFolder;


            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
            }



        }
        public void Autoexecutescripts()
        {
            try
            {
                //if (username != null)
                //{
                    string[] filelist = Directory.GetFiles(Program.ScriptsFolder);
                    scarabler.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));
                    

                    if (filelist != null)
                    {

                        // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\AxInterop.MOZILLACONTROLLib.dll");
                        // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Interop.MOZILLACONTROLLib.dll");
                        //  ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        ScrablerCore.cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Scrabler.dll");
                        //ScrablerCore.definedConstants = definedConstants;
                        //   ScrablerCore.definedValues = definedValues;
                        //Interop.MOZILLACONTROLLib.dll

                        foreach (string file in filelist)
                        {
                            //if ((file != null) && (file.EndsWith("scrf") == true))
                            //{

                            //    int i;
                            //    // ProcessHost prohost = new ProcessHost(); 
                            //    scarabler.ReadScript(file);


                            //}
                            //if ((file != null) && (file.EndsWith("cs") == true))
                            //{

                            //    int i;
                            //    scarabler.ReadScriptInLightMode(file);


                            //}
                            //if ((file != null) && (file.EndsWith(Scrabler.ScrablerV2.scriptext) == true))
                            //{
                            //    scr2.ReadScript2(file);
                            //}
                          //  MessageBox.Show(file);

                            //char[] pass = password.ToCharArray();
                            //fixed (char* pchar= pass)
                            //{

                            //Core core = new Core();
                            



                           
                          //core.Executescript(file);

                          ProcessStartInfo inf = new ProcessStartInfo();
                          inf.CreateNoWindow = true;
                          inf.Arguments ="-af"+ " \"" + file + "\"";



                          inf.FileName = Path.Combine(Application.StartupPath, "ScriptRunner.exe");
                          Process pr = new Process();
                          pr.StartInfo = inf;

                          pr.Start();
                          this.aproc.Add(pr);
                      //  }

                        }
                        //autoastart.scrf


                    }



                //}


            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
            }




        }
        public ScrablerRunnerService()
        {
            InitializeComponent();
            this.AutoLog = true;
           // this.RequestAdditionalTime(5000);
           
        }

        protected override void OnStart(string[] args)
        {
           //clnt = new ScrablerService.ScrablerServiceClient();
          //  Console.WriteLine(Environment.UserName);
          //File.CreateText(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\" + Environment.UserName + ".txt");
            //clnt.Open();
            try
            {
                
                ado.AttachDataBaseinDataSet(set, Path.Combine(Application.StartupPath, "settings.xml"));
                object[] vals = set.Tables[0].Rows[0].ItemArray;
                username = Convert.ToString(vals[0]);
                password = Convert.ToString(vals[1]);
               // MessageBox.Show(password);
                this.createScriptsDirectory();
                this.Autoexecutescripts();
            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
            }

            
           
            
        }

        protected override void OnStop()
        {
            //clnt.Close();
            foreach( Process pr in aproc)
            {
                pr.Kill();
            }
        }
        protected override void OnCustomCommand(int command)
        {
                    }
    }
}
