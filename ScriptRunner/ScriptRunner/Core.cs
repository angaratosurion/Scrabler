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
//using HydroMultyUser;
using Scrabler;
using System.Reflection;

namespace ScriptRunner
{
    public class Core
    {
        ScrablerCore scarabler = new ScrablerCore();
        Scrabler.ScrablerV2 scrablerV2 = new ScrablerV2();

        public const string run = "run";
        public const string stop = "stop";
        public const string script = "script";
        public const string code = "code";
        public const string exit="exit";
        public const string listscripts = "list scripts";
        public const string loadedscripts = "loaded scripts";
        public const string addAllias = "add allias";
        public const string showAllias = "show allias";

        public void createScriptsDirectory()
        {


            try
            {
                Program.FindScriptsFolder();
                string path;
                if (Program.ScriptsFolder != null)
                {
                    if (Directory.Exists(Program.ScriptsFolder ) == false)
                    {
                        // MessageBox.Show(Program.ScriptsFolder + "\\" + ScrablerCore.ScriptsFolder);
                        Directory.CreateDirectory(Program.ScriptsFolder);




                    }



                }
               // webBrowser.ScriptsFolder = Program.ScriptsFolder + "\\" + ScrablerCore.ScriptsFolder;


            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
            }



        }
        //public void Autoexecutescripts()
        //{
        //    try
        //    {

        //        string[] filelist = Directory.GetFiles(Program.ScriptsFolder);
        //                scarabler.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));
          
        //        if (filelist != null)
        //                {

        //                   // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\AxInterop.MOZILLACONTROLLib.dll");
        //                   // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Interop.MOZILLACONTROLLib.dll");
        //                  ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);
        //                    ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Scrabler.dll");
        //                   //ScrablerCore.definedConstants = definedConstants;
        //                 //   ScrablerCore.definedValues = definedValues;
        //                    //Interop.MOZILLACONTROLLib.dll

        //                    foreach (string file in filelist)
        //                    {
        //                        if ((file != null) &&(file.EndsWith("scrf")==true ))
        //                        {int i;
        //                            scarabler.ReadScript(file);
        //                          //  if (Program.hidden == false)
        //                            {
        //                                for (i = 0; i < ScrablerCore.AssemblyCol.Count; i++)
        //                                {
        //                                    Type[] t = ScrablerCore.AssemblyCol.GetItem(i).GetTypes();
        //                                    // foreach (Type d in t)
        //                                    {
        //                                        System.Console.WriteLine("NameSapce: " + t[0].Namespace);
        //                                    }
        //                                }
        //                            }
        //                        }

        //                    }
        //            //autoastart.scrf
        //                    if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\autoastart.scrf") == true)
        //                    {

        //                        this.Executescript(Path.GetDirectoryName(Application.ExecutablePath) + "\\autoastart.scrf");


        //                    }


        //                }
             




        //    }
        //    catch (Exception ex)
        //    {


        //        Program.errorreporting(ex);
        //    }




        //}
        public void Autoexecutescripts(string username, int version)
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
                        string[] filelist = Directory.GetDirectories(Program.ScriptsFolder);
                        //MessageBox.Show("hhh 2" + Program.ScriptsFolder);
                        // if (filelist != null)
                        {

                            // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\AxInterop.MOZILLACONTROLLib.dll");
                            // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Interop.MOZILLACONTROLLib.dll");
                            //  ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                            ScrablerV2.cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Scrabler.dll");
                            
                            foreach (string file in filelist)
                            {
                                if (file != null)
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

    
        public void Autoexecutescripts(bool win)
        {
            try
            {

                string[] filelist = Directory.GetFiles(Program.ScriptsFolder);
                scarabler.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));

                if ((filelist != null ) &&(win =true ))
                {

                    // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\AxInterop.MOZILLACONTROLLib.dll");
                    // ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Interop.MOZILLACONTROLLib.dll");
                    ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                    // ScrablerCore.definedConstants = definedConstants;
                    //   ScrablerCore.definedValues = definedValues;
                    //Interop.MOZILLACONTROLLib.dll
                    ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Scrabler.dll");

                    foreach (string file in filelist)
                    {
                        if (file != null)
                        {
                            int i;
                            scarabler.ReadScript(file);
                           // if (Program.hidden == false)
                            {
                                for (i = 0; i < ScrablerCore.AssemblyCol.Count; i++)
                                {
                                    Type[] t = ScrablerCore.AssemblyCol.GetItem(i).GetTypes();
                                    // foreach (Type d in t)
                                    {

                                        Program.Console.WriteLine("NameSapce: " + t[0].Namespace);
                                    }
                                }
                            }
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

                

                //scarabler.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));
               

                //if (file != null)
                //{

                //   ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                    
                //    ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Scrabler.dll");



                //    int i;
                //    if (File.Exists(file) == true)
                //    {
                //        ap = scarabler.ReadScript(file);
                //    }
                   



                //}
                scrablerV2.GetExeCutingApplicationVersion(Assembly.LoadFile(Application.ExecutablePath));
                ScrablerV2.cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Scrabler.dll");
               ap= scrablerV2.ReadScript2(file);




                return ap;



            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
                return null;
            }




        }
        public   void ExecuteCommand(string Cmd)
        {
            try
            {
                Allias allias = new Allias();
               Cmd= allias.ReplaceAllias(Cmd);
                if (Cmd != null)
                {
                    string[] files = Directory.GetFiles(Program.ScriptsFolder); ;
                    if (Cmd.Contains(run) == true)
                    {
                        if ((Cmd.Contains(run) == true) &&(Cmd.Contains(script)==true ) )
                        {
                            string tscrpt = Cmd.Substring(Cmd.LastIndexOf(script) + script.Length +1);
                            //string[] files;
                           //MessageBox.Show(Program.ScriptsFolder + "\\" + tscrpt);
                            
                            //files = Directory.GetFiles(Program.ScriptsFolder );

                            Executescript(this.SearchList(files,tscrpt));

                           // MessageBox.Show(this.SearchList(files,tscrpt));
                            /*else if ((files!=null)&&(files.Length >0)&&(File.Exists(files[0])==true))
                            {
                                Executescript(files[0]);

                               // MessageBox.Show(tscrpt);
                            }*/

                        }

                    }
                    else if (Cmd.Contains(stop) == true)
                    {
                        if ((Cmd.Contains(stop) == true) && (Cmd.Contains(script) == true))
                        {
                            string tname,tscript2;
                            DataSet set;
                            ScrablerCore tscrabl = new ScrablerCore();
                            string tscrpt = Cmd.Substring(Cmd.LastIndexOf(script) + script.Length +1);
                          //this.SearchList(files,tscrpt)
                           // files = Directory.GetFiles(Program.ScriptsFolder);

                            tscript2 = this.SearchList(files, tscrpt);
                            tname = Path.GetFileName(tscript2);
                                
                               // ScrablerCore.AssemblyCol.Remove(ScrablerCore.AssemblyCol.GetItem(tname));

                                ScrablerCore.AssemblyCol.Remove(ScrablerCore.AssemblyCol.GetItem(tname));

                             
                        }



                    }
                    else if (Cmd.Contains(Core.code) == true)
                    {
                        Program.Console.CommandBox.Multiline = true;
                        Program.Console.CommandBox.ScrollBars = ScrollBars.Both;
                        string tcode;
                        tcode=Cmd.Substring(Cmd.LastIndexOf(code)+code.Length);
                        ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")) + "\\Scrabler.dll");
                        ScrablerCore.cp.ReferencedAssemblies.Add(Application.ExecutablePath);

                        scarabler.Eval(tcode);

                        //
                       
                       


                    }
                    else if (Cmd.Contains(Core.exit ) == true)
                    {
                        Application.Exit();

                    }
                    else if (Cmd.Contains(Core.listscripts) == true)
                    {

                        this.ShowList(files);

                    }
                    else if (Cmd.Contains(Core.loadedscripts ) == true)
                    {
                        int i = 0;
                        Program.Console.WriteLine("Loaded Scripts: \n");
                        for (i = 0; i < ScrablerCore.AssemblyCol.Count; i++)
                        {

                            Type[] t = ScrablerCore.AssemblyCol.GetItem(i).GetTypes();
                            // foreach (Type d in t)
                            {
                                Program.Console.WriteLine("NameSapce: " + t[0].Namespace);
                            }


                        }

                    }
                    else if (Cmd.Contains(Core.addAllias) == true)
                    {
                       
                        //string tmp = Cmd.Substring(Cmd.LastIndexOf(Core.addAllias) + addAllias.Length + 1);
                       // string[] tmpar = tmp.Split(',');
                       // MessageBox.Show(tmp);
                        AddAllias adallias = new AddAllias();
                        adallias.Show();
                        
                       //allias.LoadAlliaces();

                    }
                    else if (Cmd.Contains(Core.showAllias) == true)
                    {
                        allias.ShowAllias();

                    }



                    ///ScrablerCore.AssemblyCol
                        

                }
                
            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
            }


        }
        public string SearchList(string [] list,string val)
        {
            try
            {
                int i;
                string ap = null;
                for(i=0;i<list.Length;i++)
                {
                    string tmp = Path.GetFileName(list[i]);
                    //MessageBox.Show(list[i]);
                    if (tmp != null)
                    {
                       
                        if (list[i].Contains(val)==true  )
                        {

                           

                            ap = list[i];
                            break;
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
        public void ShowList(string[] list)
        {
            try
            {
                int i;
                Program.Console.WriteLine("List of Scripts:\n");
                foreach (string str in list)
                {

                    Program.Console.WriteLine(str);

                }
                


            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
                
            }





        }
    }
}
