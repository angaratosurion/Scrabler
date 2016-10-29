using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.Data;
using ICSharpCode.SharpZipLib.Zip;

using WareForms;
using Hydrobase;
using HydrobaseSDK;
//// 

namespace Scrabler
{
    /// <summary>
    /// The class that handles the installation of the scripts
    ///  @authorKiparissis Koutsioukis(Angarato Surion)
    /// </summary>
    public class ScrablerInstaller
    {
        public const string ReferenceTag = "!";

        
        /// <summary>
        /// this method will install the given script to the script folder
        /// and copy the dll neede by the sript to the needed folder
        /// </summary>
        /// <param name="script_Archfilename">the full path of the script </param>
        /// <param name="installfolder_scriptanddll">the path that
        /// script and dll wll be installed</param>
        public void Install(string script_Archfilename,string installfolder_scriptanddll)
        {
            try
            {
                ScriptInfo scrinf=null;
                ScrablerCore core = new ScrablerCore();
                DataSet set = new DataSet();
                hydrobaseADO ad = new hydrobaseADO();
                string tscrfilename = null,str;
                string[] files;
                if ((script_Archfilename != null) && (installfolder_scriptanddll != null) 
                     &&(File.Exists(script_Archfilename)==true ) &&(Directory.Exists(installfolder_scriptanddll) == true) )
                {

                    if (Directory.Exists(installfolder_scriptanddll +"\\"+ ScrablerCore.ScriptsFolderDLL)!=true)
                    {
                        Directory.CreateDirectory(installfolder_scriptanddll +"\\"+ ScrablerCore.ScriptsFolderDLL);

                    }
                    
                    
                    
                    
                    FastZip ziphandler = new FastZip();
                    FileInfo fileinf = new FileInfo(script_Archfilename);

                    ziphandler.ExtractZip(script_Archfilename, SDKBase.UsersTempDirectory + "\\" + fileinf.Name, "scrf");



                   
                       
                        files= Directory.GetFiles(SDKBase.UsersTempDirectory + "\\" + fileinf.Name);       
                           ad.AttachDataBaseinDataSet(set, files[0]);
                          // MessageBox.Show(files[0]);
                                scrinf = core.GetScriptInfo(set);
                                core.SetReferences(set, installfolder_scriptanddll + "\\" + ScrablerCore.ScriptsFolderDLL+"\\"+scrinf.Title, files[0]);
                                File.Copy(files[0], installfolder_scriptanddll + "\\" + ScrablerCore.ScriptsFolder + "\\" + files[0].Substring(files[0].LastIndexOf("\\")+1));
                                str = files[0];            
                    tscrfilename =files[0];

                                File.Delete(files[0]);
                                ziphandler.ExtractZip(script_Archfilename, SDKBase.UsersTempDirectory + "\\" + fileinf.Name, "dll");
                                files = null;           
                    files = Directory.GetFiles(SDKBase.UsersTempDirectory + "\\" + fileinf.Name);
                                foreach (string file in files)
                                {
                                    FileInfo dllinf = new FileInfo(file);
                                    this.CopyDll(file, installfolder_scriptanddll + "\\" + ScrablerCore.ScriptsFolderDLL + "\\" + scrinf.Title + "\\"+dllinf.Name );
                                    //MessageBox.Show("hi6");
                                }
                                core.SetReferences(set, installfolder_scriptanddll + "\\" + ScrablerCore.ScriptsFolderDLL + "\\" + scrinf.Title, tscrfilename);
                                    
                            }

                        
                      FileInfo   fileinf2 = new FileInfo(script_Archfilename);
                      
                        string [] tfile= Directory.GetFiles( SDKBase.UsersTempDirectory + "\\" + fileinf2.Name);
                      foreach (string file in tfile)
                      {

                          File.Delete(file);


                      }
                        
                        Directory.Delete(SDKBase.UsersTempDirectory + "\\" + fileinf2.Name);
                       

                    }
                

                



            
            catch (Exception e)
            {
                Program.Bugtracking(e);

               
            }
}


        
       /// <summary>
       /// This checks if the reference has been tagged as a dll that doesnt belong
       /// to the application and returns the new path
       /// that the dll will have.
       /// </summary>
       /// <param name="ref_dll">the given reference</param>
       /// <param name="dllinstalltionfolder">the folder that all script's dll 
       /// will be</param>
        /// <returns>returns the new path
        /// that the dll will have</returns>
        
        public string CheckIfdllNeedToBeInstalled(string ref_dll,string dllinstalltionfolder)
        {
            try
            {
                string ap = null ;
                if ((ref_dll != null) && (dllinstalltionfolder != null))
                {
                    if (ref_dll.StartsWith(ScrablerInstaller.ReferenceTag) == true)
                    {
                        ap = ref_dll.Replace(ScrablerInstaller.ReferenceTag, dllinstalltionfolder +"\\");

                    }
                    else
                    {

                        ap = ref_dll;
                    }


                }
                return ap;


            }
            catch (Exception e)
            {
                Program.Bugtracking(e);
                return null;


            }


        }
        void CopyDll(string source,string target)
        {
            try
            {
                if ((source != null) && (target != null) &&(File.Exists(source)==true) )
                {
                   
                    if (Directory.Exists(target.Substring(0,target.LastIndexOf("\\")) ) == true)
                    {

                        File.Move(source, target);
                    }
                    else
                    {
                        Directory.CreateDirectory(target.Substring(0, target.LastIndexOf("\\") ));
                        File.Move(source, target);



                    }


                }


            }
            catch (Exception e)
            {
                Program.Bugtracking(e);


            }


        }
        /// <summary>
        /// Copies all process's references to given folder
        /// </summary>
        /// <param name="cp">parameters of the given compiler</param>
        /// <param name="path">path to be copied</param>
        public void CopyProcessReference(CompilerParameters cp,string path )
        {
            try
            {
                if ((cp != null) && (path != null) && (cp.ReferencedAssemblies != null))
                {


                    foreach(string str  in cp.ReferencedAssemblies)
                    {
                        if (File.Exists(Path.Combine(path,Path.GetFileName(str))) == true)
                        {
                            File.Delete(Path.Combine(path,Path.GetFileName(str)));

                        }
                        File.Copy(str, Path.Combine(path,Path.GetFileName(str)));
                        

                    }

                }


            }
                catch(FileNotFoundException)
            {



                }
            catch (Exception e)
            {
                Program.Bugtracking(e);


            }



        }
    }
}
