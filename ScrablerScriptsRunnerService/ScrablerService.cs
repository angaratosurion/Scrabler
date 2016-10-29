using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Scrabler;

namespace ScrablerService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
  
    public class ScrablerService : IScrablerService
    {
        ScriptRepo repo = new ScriptRepo();
        ScrablerCore scarabler = new ScrablerCore();
        Scrabler.ScrablerV2 scrablerV2 = new ScrablerV2();
       // List<ProcessHost> process = new List<ProcessHost>();
        public void createScriptsDirectory(string username)
        {


            try
            {
                if (username != null)
                {
                    Program.FindScriptsFolder(username);
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
        public void Autoexecutescripts(string username ,int version)
        {
            try
            {
                if (username != null)
                {
                    
                   
                    if (version == 1)
                    {
                        scarabler.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));
                        string[] filelist = Directory.GetFiles(Program.ScriptsFolder);
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
                                if ((file != null) && (file.EndsWith(ScrablerCore.scriptextenstion) == true))
                                {

                                    int i;
                                    // ProcessHost prohost = new ProcessHost(); 
                                    scarabler.ReadScript(file);


                                }
                                if ((file != null) && (file.EndsWith("cs") == true))
                                {

                                    int i;
                                    scarabler.ReadScriptInLightMode(file);


                                }

                            }
                            //autoastart.scrf


                        }
                    }
                    else
                    {
                        scrablerV2.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));
                        string[] filelist = Directory.GetFiles(Program.ScriptsFolder);
                     //  MessageBox.Show("hhh 2" + Program.ScriptsFolder);
                      if (filelist != null)
                        {

                            // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\AxInterop.MOZILLACONTROLLib.dll");
                            // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Interop.MOZILLACONTROLLib.dll");
                            //  ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                            ScrablerV2.cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Scrabler.dll");
                            //ScrablerCore.definedConstants = definedConstants;
                            //   ScrablerCore.definedValues = definedValues;
                            //Interop.MOZILLACONTROLLib.dll
                           // MessageBox.Show("hhh 2" + filelist[0]);
                            foreach (string file in filelist)
                            { 
                                if ((file != null)  &&(file.EndsWith(ScrablerV2.scriptext)))
                                {
                                  

                                    int i;
                                    // ProcessHost prohost = new ProcessHost(); 
                                    scrablerV2.ReadScript2(file);


                                }
                             

                            }
                            //autoastart.scrf


                        }

                    }



                }


            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
            }




        }
        
        public object Executescript(string file)
        {
            try
            {

                object ap = null;

                // string[] filelist = Directory.GetFiles(Program.ScriptsFolder);

                //ScrablerCore tscarabler = new ScrablerCore();

                scarabler.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));

                if (file != null)
                {

                    // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\AxInterop.MOZILLACONTROLLib.dll");
                    // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Interop.MOZILLACONTROLLib.dll");
                    ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                    // ScrablerCore.definedConstants = definedConstants;
                    //   ScrablerCore.definedValues = definedValues;
                    //Interop.MOZILLACONTROLLib.dll
                    ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Scrabler.dll");



                    int i;
                    if (File.Exists(file) == true)
                    {
                        ap = scarabler.ReadScript(file);
                    }
                    //Type[] t = ScrablerCore.AssemblyCol.GetItem(i).GetTypes();
                    // foreach (Type d in t)
                    // {
                    // System.Console.WriteLine("NameSapce: " + t[0].Namespace);
                    //}



                }



                return ap;



            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
                return null;
            }




        }
        public ScriptInfo[] GetLoadedScripts()
        {

            try
            {
                ScriptInfo[] ap=null ;

                if(ScrablerCore.AssemblyCol!=null )
                {
                    List<ScriptInfo> scrdt = ScrablerCore.AssemblyCol.ScriptInfoCollection();
                    if (scrdt != null)
                    {
                        ap = new ScriptInfo[scrdt.Count];
                        int i;
                        for(i=0;i<scrdt.Count;i++)
                        {
                            ap[i] =scrdt[i];


                        }
                    }
                   
                }

                return ap;

            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
                return null;
            }
        }
        public string GetServiceVersion()
        {
            try
            {

                string Ekdo = null;



                Ekdo = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                return Ekdo;
                

            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
             return null;
            }

        }
    }
}
