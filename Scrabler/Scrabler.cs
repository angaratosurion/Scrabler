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
using System.Security;
using System.Security.Permissions;

using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using WareForms;
using Hydrobase;
using HydrobaseSDK;
// 

using System.Configuration;
using Scrabler.IDE;


namespace Scrabler
{
    /// <summary>
    /// The core of This library that does the most job..<br/>
    /// TODO: To implement the ability to run vb.net code.
    /// 
    /// @authorKiparissis Koutsioukis(Angarato Surion)
    /// </summary>
    public  class ScrablerCore : Replacer 
    {
        enumScriptRuningMode runmode = enumScriptRuningMode.Normal;
        
        /// <summary>
        /// The core of This library that does the most job..
        /// </summary>
        /// 





        static ScrablerDefSettings defsett;
        static ScriptRepo repo;

        hydrobaseADO ado = new hydrobaseADO();

        /// <summary>
        /// This constractor inititalisizes Scrabler in the given mode
        /// </summary>
        /// <param name="runingmode">this enum changes the execution mode of the scripts </param>
        public ScrablerCore(enumScriptRuningMode runingmode)
        {

            runmode = runingmode;

        }

        /// <summary>
        /// Default Constractor
        /// </summary>

        public ScrablerCore()
        {

            runmode = enumScriptRuningMode.Normal;

        }
        /// <summary>
        /// The Collection of all assemblies created by the executed scripts.
        /// 
        /// </summary>
        public static AssemblyCollection AssemblyCol = new AssemblyCollection();

        

        public const string scriptextenstion = ".scrf";
        /// <summary>
        /// The const that has the tag that refers to the references needed
        /// for the script to run.
        /// </summary>
        public const string references= "references";
        /// <summary>
        /// The const that has the tag that refers to the 
        /// function that is to be executed.
        /// </summary>
        public const string execution_func = "function";
        /// <summary>
        /// The const that has the tag that refers to the 
        /// namespace that the code in the script .
        /// </summary>
        public const string namespacetag = "namespace";
        /// <summary>
        /// The const that has the tag that refers to the 
        /// class that the code in the script .
        /// </summary>
        public const string classtag = "class";
        /// <summary>
        /// The const that has the tag that refers to the 
        /// class that  code exists .
        /// </summary>
        public const string Code = "code";
        /// <summary>
        /// The const that has the tag that refers to the 
        /// author of the script
        /// </summary>
        public const string Author = "author";
        /// <summary>
        ///  The const that has the tag that refers to the 
        /// version of the script
        /// </summary>
        
        public const string VersionTag = "version";
        /// <summary>
        ///  The const that has the tag that refers to the 
        /// description of the script
        /// </summary>
         public const string Description="description";
         /// <summary>
         ///  The const that has the tag that refers to the 
         /// copyright holder of the script
         /// </summary>
        public const string Copyright="copyright";
        /// <summary>
        ///  The const that has the tag that refers to the lowest
        /// version of the application that will run on.
        /// </summary>
        public const string LowerApplicationVersionTag = "lower_application_Version";
        /// <summary>
        /// The maximum version of the application that is written for.
        /// </summary>
        public const string MaxApplicationVersionTag = "max__application_Version";
        /// <summary>
        /// The Versionof the Scrabler version that is able to run the script.
        /// </summary>   
        /// 
        ///
       

        public const string Scrabler_VersionTag = "scrabler_Version";
        /// <summary>
        /// the [rpgraming language that scrabler script is writen on
        /// </summary>
        public const string LangTag = "Program_Lang";
       
        public const string Titletag = "title";
        //public string code;
        public static WareForm tForm;
        public const string ScriptsFolder = "Scripts";
        public const string ScriptsFolderDLL = "Scripts DLL";
        static string applicationVerForUpd;
        public static string[] definedConstants,definedValues;
        ScrablerInstaller installer = new ScrablerInstaller();
        public static DataSet ScriptsSet;
        /// <summary>
        /// This keeps the dataset of that the script's info are saved.
        /// </summary>

        Replacer replacer = new Replacer();

        /// <summary>
        /// Gets the assembly of the executing applicaion and takes the version
        /// </summary>
        /// <param name="app">The assemply of the executing application</param>
        public void GetExeCutingApplicationVersion(Assembly app)
        {
            try
            {
                if (app != null)
                {
                    applicationVerForUpd = app.GetName().Version.ToString();
                    // MessageBox.Show(applicationVerForUpd);



                }
                else
                {

                    applicationVerForUpd = Assembly.LoadFile(Application.ExecutablePath).GetName().Version.ToString();


                }


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);

            }


        }

        public CSharpCodeProvider c = new CSharpCodeProvider();
        public static  CompilerParameters cp = new CompilerParameters();
        public VBCodeProvider vb = new VBCodeProvider();
        //public static CompilerParameters vcp = new CompilerParameters();
        
        
        
     

        /// <summary>
        /// Returns the version of the Library
        /// </summary>
        /// <returns> Returns the version of the Library</returns>
        public static string GetVersion()
        {
            try
            {
                string Ekdo = null;

                

                Ekdo = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                return Ekdo;
            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }


        }
        /// <summary>
        ///  Returns the References of the Script
        /// or null in error or nothing happened
        /// Note:This works only at normal Mode
        /// </summary>
        /// <param name="set">the dataset that 1st datatable 
        /// that has the the info and the code of the script</param>
        /// <returns>Returns the References of the Script 
        /// or null in error or nothing happened</returns>
        public string[] GetReferences(DataSet set)
        {

            try
            { 
                string [] ap = null;
                string tmp;
                char[] ar ={ '|'};
                int i;
                if ((set != null) &&(set.Tables.Count>0))
                {
                    //DataRowCollection col = set.Tables[0].Rows;

                    DataRow row = set.Tables[0].Rows[0];
                        object[] val = row.ItemArray;
                     i=set.Tables[0].Columns.IndexOf(references);
                        tmp = Convert.ToString(val[i]);
                        ap = tmp.Split(ar );



                   // }

                }
                return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                  return null;
            }

        }
        /// <summary>
        /// Returns the Namespace of the Script
        /// or null in error or nothing happened
        /// Note:This works only at normal Mode
        /// </summary>
        /// <param name="set">the dataset that 1st datatable 
        /// that has the the info and the code of the script</param>
        /// <returns>Returns the Namespace of the Script
        /// or null in error or nothing happened</returns>
        public string GetNameSace(DataSet set)
        {
            try
            {
                string ap = null;
                int i;
                if ((set != null) && (set.Tables.Count > 0))
                {
                    //DataRowCollection col = set.Tables[0].Rows;
                    DataRow row = set.Tables[0].Rows[0];
                    object[] val = row.ItemArray;
                    i=set.Tables[0].Columns.IndexOf(namespacetag);
                    ap = Convert.ToString(val[i]);



                    // }

                }
                return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }



        }
    
        
        /// <summary>
        /// Returns the Class of the Script
        /// or null in error or nothing happened
        /// </summary>
        /// <param name="set">the dataset that 1st datatable 
        /// that has the the info and the code of the script</param>
        /// <returns>Returns the Class of the Script
        /// or null in error or nothing happened</returns>
        public string GetClass(DataSet set)
        {
            try
            {
                string ap = null;
                int i;
                if ((set != null) || (set.Tables.Count > 0))
                {
                    //DataRowCollection col = set.Tables[0].Rows;
                    DataRow row = set.Tables[0].Rows[0];
                    object[] val = row.ItemArray;
                     i=set.Tables[0].Columns.IndexOf(classtag);
                    ap = Convert.ToString(val[i]);



                    // }

                }
                return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }




        }
        /// <summary>
        /// Returns the function of the Script that will be executed
        /// or null in error or nothing happened
        /// Note:This works only at normal Mode
        /// </summary>
        /// <param name="set">the dataset that 1st datatable 
        /// that has the the info and the code of the script</param>
        /// <returns>Returns the function of the Script rgar will be executed
        /// or null in error or nothing happened</returns>
        public string GetFunction(DataSet set)
        {
            try
            {
                string ap = null;
                int i;
                if ((set != null) && (set.Tables.Count > 0))
                {
                    //DataRowCollection col = set.Tables[0].Rows;
                    DataRow row = set.Tables[0].Rows[0];
                    object[] val = row.ItemArray;
                     i=set.Tables[0].Columns.IndexOf(execution_func);
                    // MessageBox.Show(Convert.ToString(val[i]));
                    ap = Convert.ToString(val[i]);



                    // }

                }
                return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }



        }

        /// <summary>
        /// /// Returns the language that  the Script is written
        ///  or null in error or nothing happened
        /// Note:This works only at normal Mode
        /// </summary>
        /// <param name="set">the dataset that 1st datatable 
        /// that has the the info and the code of the script</param>
        /// <returns></returns>
        public string GetLanguage(DataSet set)
        {
            try
            {
                string ap = null;
                int i;
                if ((set != null) && (set.Tables.Count > 0))
                {
                    //DataRowCollection col = set.Tables[0].Rows;
                    DataRow row = set.Tables[0].Rows[0];
                    object[] val = row.ItemArray;
                    i = set.Tables[0].Columns.IndexOf(LangTag);
                    // MessageBox.Show(Convert.ToString(val[i]));
                    if (set.Tables[0].Columns.Contains(LangTag) == true)
                    {
                        if (Convert.ToString(val[i]) != null)
                        {
                            ap = Convert.ToString(val[i]);
                        }
                        else
                        {
                            ap = "C#";
                        }
                        
                    }
                    


                    // }

                }
                return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }



        }
        /// <summary>
        /// Returns the code of the Script 
        /// or null in error or nothing happened
        /// Note:This works only at normal Mode
        /// </summary>
        /// <param name="set">the dataset that 1st datatable 
        /// that has the the info and the code of the script</param>
        /// <returns>Returns the code of the Script 
        /// or null in error or nothing happened</returns>
        public string GetCode(DataSet set)
        {

            try
            {
                string ap = null;
                int i;
                
                    if ((set != null) || (set.Tables.Count > 0))
                    {
                        //DataRowCollection col = set.Tables[0].Rows;
                        DataRow row = set.Tables[0].Rows[0];
                        object[] val = row.ItemArray;
                        i = set.Tables[0].Columns.IndexOf(Code);
                        ap = Convert.ToString(val[i]);
                        //MessageBox.Show(Convert.ToString(val[3]));
                        // StreamReader reader= new StreamReader(Convert.ToString(val[3]));

                        //ap = reader.ReadToEnd();
                        //reader.Close();


                        // }
                    
                    

                }
                return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }

        }
        /// <summary>
        /// Returns the information of the script
        /// or null in error or nothing happened
        /// Note:This works only at normal Mode
        /// </summary>
        /// <param name="set">the dataset that 1st datatable 
        /// that has the the info and the code of the script</param>
        /// <returns>Returns the information of the script
        /// or null in error or nothing happened</returns>
        public ScriptInfo GetScriptInfo(DataSet set)
        {
            try
            {
                ScriptInfo  ap = null;
                int i;
                if ((set != null) && (set.Tables.Count > 0))
                {
                    //DataRowCollection col = set.Tables[0].Rows;
                    ap = new ScriptInfo();
                    DataRow row = set.Tables[0].Rows[0];
                    object[] val = row.ItemArray;
                    i = set.Tables[0].Columns.IndexOf(Author);
                    ap.Author = Convert.ToString(val[i]);
                    i = set.Tables[0].Columns.IndexOf(VersionTag);
                    ap.Version= Convert.ToString(val[i]);
                    i = set.Tables[0].Columns.IndexOf(Copyright);
                    ap.Copyright = Convert.ToString(val[i]);
                    i = set.Tables[0].Columns.IndexOf(Description);
                    ap.Description = Convert.ToString(val[i]);
                    i = set.Tables[0].Columns.IndexOf(Titletag);

                    ap.Title = Convert.ToString(val[i]);

                    i = set.Tables[0].Columns.IndexOf(LowerApplicationVersionTag);

                    ap.LowerApplicationVersion = Convert.ToString(val[i]);

                    i = set.Tables[0].Columns.IndexOf(MaxApplicationVersionTag);
                    ap.MaxApplicationVersion = Convert.ToString(val[i]);
                    i = set.Tables[0].Columns.IndexOf(Scrabler_VersionTag);
                    ap.ScrablerVersion = Convert.ToString(val[i]);
                    if (set.Tables[0].Columns.Contains(LangTag) == true)
                    {
                        i = set.Tables[0].Columns.IndexOf(LangTag);
                        if (Convert.ToString(val[i]) != null)
                        {
                            ap.Language= Convert.ToString(val[i]);
                        }
                        else
                        {
                            ap.Language = "C#";
                        }

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
        /// <summary>
        /// Reads the given file and execute the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="filename">the name of the file that has the script</param>
        /// <param name="gui">the gui of the application that will
        /// execute the script
        /// </param>
        /// <returns>Reads the given file and execute the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public  object  ReadScript(string filename,WareForm gui)
        {

            try
            {
                int i = 0;
                object ap=null;
                DataSet set = new DataSet();
                if((filename !=null) &&(gui!=null))
                {
                    string  code, clas, func,names;
                    string [] refs;
                   ado.AttachDataBaseinDataSet(set, filename);
                   refs = this.GetReferences(set);
                   names = this.GetNameSace(set);
                   code = this.GetCode(set);
                   clas = this.GetClass(set);
                   func = this.GetFunction(set);
                    if(( definedConstants !=null ) &&(definedValues !=null)&&(definedConstants.Length ==definedValues.Length )  )
                    {
                        for (i = 0; i < definedConstants.Length; i++)
                        {
                            code =replacer.findandreplaceDefinedConsts (code, definedConstants[i], definedValues[i]);
                            code = replacer.findandreplaceSymbols(code);

                        }


                    }
                    else if ((definedConstants == null) && (definedValues == null) && (definedConstants.Length == definedValues.Length))
                    {

                        code = replacer.findandreplaceSymbols(code);

                    }




                    ScriptsSet = set;
                    ScriptInfo scrinf = this.GetScriptInfo(set);
                    scrinf.Filename = filename;
                    ap = this.EvalWithParams(code, filename, names, clas, func, refs, gui, scrinf);
                    




                }
                return ap;



            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                  return null;
            }



        }


        /// <summary>
        /// Reads the given file and execute the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="filename">the name of the file that has the script</param>
        /// <returns>Reads the given file and execute the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public object ReadScript(string filename)
        {

            try
            {
                int i = 0;
                object ap = null;
                DataSet set = new DataSet();

                if (filename != null)
                {

                    string code, clas, func, names,lang;
                    string[] refs;
                    ado.AttachDataBaseinDataSet(set, filename);
                    refs = this.GetReferences(set);
                    names = this.GetNameSace(set);
                    code = this.GetCode(set);
                    clas = this.GetClass(set);
                    func = this.GetFunction(set);
                    lang = this.GetLanguage(set);

                    if ((definedConstants != null) && (definedValues != null) && (definedConstants.Length == definedValues.Length))
                    {
                        for (i = 0; i < definedConstants.Length; i++)
                        {
                            code = replacer.findandreplaceDefinedConsts(code, definedConstants[i], definedValues[i]);

                            code = replacer.findandreplaceSymbols(code);
                        }


                    }
                    else
                    {

                        code = replacer.findandreplaceSymbols(code);

                    }



                    ScriptsSet = set;
                    ScriptInfo scrinfo = this.GetScriptInfo(set);
                    scrinfo.Filename = filename;
                  //  MessageBox.Show(scrinfo.Language);
                    ap = this.Eval(code, filename, names, clas, func, refs, scrinfo);










                }

                return ap;



            }
            catch (Exception e)
            {

                Program.Bugtracking(e);

                return null;
            }



        }


        /// <summary>
       // Reads the given file andinstall the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="filename">the name of the file that has the script</param>
        /// <returns>Reads the given file and execute the script</param>
        /// <param name="path">the fodler that file will be saved </param>
        /// <returns>Reads the given file and execute the script
        /// and returns the assembly as process  if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public string  ReadScriptAndInstall(string filename,string path)
        {

            try
            {
                int i = 0;
               string   ap = null;
                DataSet set = new DataSet();

                if ((filename != null) &&(path !=null))
                {

                    string code, clas, func, names, lang;
                    string[] refs;
                    ado.AttachDataBaseinDataSet(set, filename);
                    refs = this.GetReferences(set);
                    names = this.GetNameSace(set);
                    code = this.GetCode(set);
                    clas = this.GetClass(set);
                    func = this.GetFunction(set);
                    lang = this.GetLanguage(set);

                    if ((definedConstants != null) && (definedValues != null) && (definedConstants.Length == definedValues.Length))
                    {
                        for (i = 0; i < definedConstants.Length; i++)
                        {
                            code = replacer.findandreplaceDefinedConsts(code, definedConstants[i], definedValues[i]);

                            code = replacer.findandreplaceSymbols(code);
                        }


                    }
                    else
                    {

                        code = replacer.findandreplaceSymbols(code);

                    }



                    ScriptsSet = set;
                    ScriptInfo scrinfo = this.GetScriptInfo(set);
                    scrinfo.Filename = filename;
                    //  MessageBox.Show(scrinfo.Language);
                    ap =this.EvalAndSave(code, filename, names, clas, func, refs, scrinfo,path );
                    
                    if (ap != null)
                    {
                        File.Delete(filename);

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
        /// <summary>
        /// Reads the given file and execute the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="filename">the name of the file that has the script</param>
        /// <param name="dontExecute">Put true to load the script without to execute it</param>
        /// <returns>Reads the given file and execute the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public object ReadScript(string filename,bool dontExecute)
        {

            try
            {
                int i = 0;
                object ap = null;
                DataSet set = new DataSet();
                //MessageBox.Show(filename );

                if (filename != null)
                {
                     
                    string code, clas, func, names, lang;
                    string[] refs;
                    set.Tables.Clear();
                    ado.AttachDataBaseinDataSet(set, filename);
                  //  MessageBox.Show(set.Tables.Count.ToString());
                    refs = this.GetReferences(set);
                    names = this.GetNameSace(set);
                    code = this.GetCode(set);
                    clas = this.GetClass(set);
                    func = this.GetFunction(set);
                    lang = this.GetLanguage(set);

                    if ((definedConstants != null) && (definedValues != null) && (definedConstants.Length == definedValues.Length))
                    {
                        for (i = 0; i < definedConstants.Length; i++)
                        {
                            code = replacer.findandreplaceDefinedConsts(code, definedConstants[i], definedValues[i]);

                            code = replacer.findandreplaceSymbols(code);
                        }


                    }
                    else
                    {

                        code = replacer.findandreplaceSymbols(code);

                    }



                    ScriptsSet = set;
                    ScriptInfo scrinfo = this.GetScriptInfo(set);
                    scrinfo.Filename = filename;
                    //  MessageBox.Show(scrinfo.Language);
                    if (dontExecute == false)
                    {
                        ap = this.Eval(code, filename, names, clas, func, refs, scrinfo);
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
        /// <summary>
        /// reads and executes only Scripts written to be executed in light mode
        /// </summary>
        /// <param name="filename">he name of the file that has the script</param>
        /// <returns>Reads the given file and execute the script
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public object ReadScriptInLightMode(string filename)
        {

            try
            {
                int i = 0;
                object ap = null;
                DataSet set = new DataSet();


                if (filename != null)
                {
                    string code = null, clas, func, names;
                    string[] refs;
                    // ado.AttachDataBaseinDataSet(set, filename);
                    refs = this.GetReferences(set);
                    names = Application.ProductName;

                    if (File.Exists(filename) == true)
                    {
                        StreamReader reader = new StreamReader(filename);
                        code = reader.ReadToEnd();

                    }


                    if ((definedConstants != null) && (definedValues != null) && (definedConstants.Length == definedValues.Length))
                    {
                        for (i = 0; i < definedConstants.Length; i++)
                        {
                            code = replacer.findandreplaceDefinedConsts(code, definedConstants[i], definedValues[i]);

                            code = replacer.findandreplaceSymbols(code);
                        }


                    }
                    else
                    {

                        code = replacer.findandreplaceSymbols(code);

                    }



                    // ScriptsSet = set;
                    ap = this.Eval(code);




                }

                return ap;



            }
            catch (Exception e)
            {

                Program.Bugtracking(e);

                return null;
            }



        }
       

        /// <summary>
        /// checks  the script's  Compatibility and returns true when it is
        /// or flase when it isnt or an error occured
        /// </summary>
        /// <param name="scrinf">the class tht has the info of the script</param>
        /// <returns>returns true when it is
        /// or flase when it isnt or an error occured</returns>
        public bool checkCompatibility(ScriptInfo scrinf)
        {

            try
            {
                bool ap = false;
                Version scrscrver = new Version(scrinf.ScrablerVersion);
                Version LibVer= new Version(ScrablerCore.GetVersion());
                Version appVer = new Version(applicationVerForUpd);
                Version scrloappVer = new Version(scrinf.LowerApplicationVersion);
                Version scrmaxappVer = new Version(scrinf.MaxApplicationVersion);
               // MessageBox.Show(scrloappVer.CompareTo(appVer) + "\n" + scrmaxappVer.CompareTo(appVer) + "\n" + scrscrver.CompareTo(LibVer));
                if((scrinf!=null ) ||(scrloappVer.CompareTo(appVer)>=0) ||(scrmaxappVer.CompareTo(appVer)<=0))
                {
                   

                    ap = true;

                }
                return ap;

            }

            catch (Exception e)
            {

                Program.Bugtracking(e);
                return false;


            }



        }

       

        /// <summary>
        /// Executes the code that is saved in the sCSCode
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="sCSCode">here put the code</param>
        /// <param name="scriptname">name of  the sctipt</param>
        /// <param name="NameSapce">the namespace that class
        /// of the script belongs</param>
        /// <param name="Clas">the class of the script</param>
        /// <param name="func">the func that s to be executed</param>
        /// <param name="refs">the references that </param>
        /// <param name="scrinf">Class that has info about script</param>
        /// <returns>and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public  object Eval(string sCSCode, string scriptname,string NameSapce,string Clas,string func,string [] refs,ScriptInfo scrinf)
        {
            try
            {


                if ((sCSCode != null) && (scriptname != null) && (NameSapce != null) && (Clas != null) && (func != null) 
                    && (refs != null) && (refs.Length > 0)
                    && (scrinf != null) 
                    && (checkCompatibility(scrinf) == true))
                {
                    if ((scrinf.Language == "C#") || (scrinf.Language == "c#"))
                    {
                        ICodeCompiler icc = c.CreateCompiler();
                        //ErrorWindow errwin ;



                        cp.ReferencedAssemblies.Add("system.dll");
                        cp.ReferencedAssemblies.Add("system.xml.dll");
                        cp.ReferencedAssemblies.Add("system.data.dll");
                        // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                        cp.ReferencedAssemblies.Add("system.drawing.dll");
                        cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");
                        sb.Append("using System;\n");
                        sb.Append("using System.Xml;\n");
                        sb.Append("using System.Data;\n");
                        sb.Append("using System.Data.SqlClient;\n");

                        sb.Append("using System.Drawing;\n");
                        sb.Append("using Hydrobase;\n");
                        sb.Append("using HydrobaseSDK;\n");

                        sb.Append("using WareForms;\n");


                        sb.Append(sCSCode + "; \n");
                       
                        CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                           // errwin.txtCode.Text = tmp;
                            ErrorWindow errwin = new ErrorWindow(cr.Errors, tmp);
                           
                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;
                            //MessageBox.Show(cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText);
                            errwin.Show();

                            return null;
                        }

                        System.Reflection.Assembly a = cr.CompiledAssembly;


                        object o = a.CreateInstance(NameSapce + "." + Clas);

                        AssemblyCol.Add(a, scrinf);

                        Type t = o.GetType();

                        MethodInfo mi = t.GetMethod(func);
                        //WareForm[] oParams = new WareForm[1];
                        //  oParams[0] = winGUI;
                        object s = mi.Invoke(o, null);
                        return s;
                    }
                    else if((scrinf.Language=="VB")||(scrinf.Language=="vb"))
                    {
                        //MessageBox.Show("aa");
                        ICodeCompiler icc = vb.CreateCompiler();
                       // ErrorWindow errwin = new ErrorWindow();



                        cp.ReferencedAssemblies.Add("system.dll");
                        cp.ReferencedAssemblies.Add("system.xml.dll");
                        cp.ReferencedAssemblies.Add("system.data.dll");
                        // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                        cp.ReferencedAssemblies.Add("system.drawing.dll");
                        cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");
                        sb.Append("Imports System\n");
                        sb.Append("Imports System.Xml\n");
                        sb.Append("Imports System.Data\n");
                      sb.Append("Imports System.Data.SqlClient\n");

                        sb.Append("Imports System.Drawing\n");
                        sb.Append("Imports Hydrobase\n");
                        sb.Append("Imports HydrobaseSDK\n");

                       sb.Append("Imports WareForms\n");


                        sb.Append(sCSCode + " \n");

                        CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            //errwin.txtCode.Text = tmp;
                            ErrorWindow errwin = new ErrorWindow(cr.Errors,tmp,true );
                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;
                           
                            errwin.Show();
                            
                            return null;
                        }

                        System.Reflection.Assembly a = cr.CompiledAssembly;


                        object o = a.CreateInstance(NameSapce + "." + Clas);

                        AssemblyCol.Add(a, scrinf);

                        Type t = o.GetType();

                        MethodInfo mi = t.GetMethod(func);
                        //WareForm[] oParams = new WareForm[1];
                        //  oParams[0] = winGUI;
                        object s = mi.Invoke(o, null);
                        return s;

                    }
                }
                return null;

            }
            catch (Exception e)
            {
                Program.Bugtracking(e);
               
                return null;
            }

        }
        /// <summary>
        /// Executes the code that is saved in the sCSCode
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="scriptname">name of  the sctipt</param>
        /// <param name="NameSapce">the namespace that class
        /// of the script belongs</param>
        /// <param name="Clas">the class of the script</param>
        /// <param name="func">the func that s to be executed</param>
        /// <param name="refs">the references that </param>
        /// <param name="scrinf">Class that has info about script</param>
        /// <param name="path">path that process wil be saved </param>
        /// <returns>Returns the new path of the compiled executable/process</returns>
        
        public string EvalAndSave(string sCSCode, string scriptname, string NameSapce, string Clas, string func, string[] refs, ScriptInfo scrinf,string path)
        {
            try
            {


                if ((sCSCode != null) && (scriptname != null) && (NameSapce != null) && (Clas != null) && (func != null)
                    && (refs != null) && (refs.Length > 0)
                    && (scrinf != null)
                    && (checkCompatibility(scrinf) == true) &&(path !=null))
                {
                    if ((scrinf.Language == "C#") || (scrinf.Language == "c#"))
                    {
                        ICodeCompiler icc = c.CreateCompiler();
                        //ErrorWindow errwin ;



                        cp.ReferencedAssemblies.Add("system.dll");
                        cp.ReferencedAssemblies.Add("system.xml.dll");
                        cp.ReferencedAssemblies.Add("system.data.dll");
                        // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                        cp.ReferencedAssemblies.Add("system.drawing.dll");
                        cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:exe";
                        cp.GenerateExecutable = true;
                        cp.OutputAssembly = Path.Combine(path, scriptname + ".exe");
                        StringBuilder sb = new StringBuilder("");
                        sb.Append("using System;\n");
                        sb.Append("using System.Xml;\n");
                        sb.Append("using System.Data;\n");
                        sb.Append("using System.Data.SqlClient;\n");

                        sb.Append("using System.Drawing;\n");
                        sb.Append("using Hydrobase;\n");
                        sb.Append("using HydrobaseSDK;\n");

                        sb.Append("using WareForms;\n");


                        sb.Append(sCSCode + "; \n");

                        CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            // errwin.txtCode.Text = tmp;
                            ErrorWindow errwin = new ErrorWindow(cr.Errors, tmp);

                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;
                            //MessageBox.Show(cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText);
                            errwin.Show();

                           // return null;
                        }

                        System.Reflection.Assembly a = cr.CompiledAssembly;


                        object o = a.CreateInstance(NameSapce + "." + Clas);

                        AssemblyCol.Add(a, scrinf);

                        Type t = o.GetType();

                        MethodInfo mi = t.GetMethod(func);
                        //WareForm[] oParams = new WareForm[1];
                        //  oParams[0] = winGUI;
                       // object s = mi.Invoke(o, null);\


                     //   System.Windows.Forms.MessageBox.Show(Path.GetDirectoryName(scrinf.Filename));
                     
                        ScrablerInstaller inst = new ScrablerInstaller();
                        inst.CopyProcessReference(cp, path);
                         if(File.Exists(Path.Combine(path, Path.GetFileNameWithoutExtension(scriptname) + ".exe"))==true )
                        {

                            File.Delete(Path.Combine(path, Path.GetFileNameWithoutExtension(scriptname) + ".exe"));
                        }
                        File.Move(Path.GetDirectoryName(scrinf.Filename)+"\\" + Path.GetFileName(scriptname) + ".exe", Path.Combine(path, Path.GetFileNameWithoutExtension(scriptname) + ".exe"));
                        
                        return cp.OutputAssembly;
                        //return s;
                    }
                    else if ((scrinf.Language == "VB") || (scrinf.Language == "vb"))
                    {
                        //MessageBox.Show("aa");
                        ICodeCompiler icc = vb.CreateCompiler();
                        // ErrorWindow errwin = new ErrorWindow();



                        cp.ReferencedAssemblies.Add("system.dll");
                        cp.ReferencedAssemblies.Add("system.xml.dll");
                        cp.ReferencedAssemblies.Add("system.data.dll");
                        // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                        cp.ReferencedAssemblies.Add("system.drawing.dll");
                        cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:exe";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");
                        sb.Append("Imports System\n");
                        sb.Append("Imports System.Xml\n");
                        sb.Append("Imports System.Data\n");
                        sb.Append("Imports System.Data.SqlClient\n");

                        sb.Append("Imports System.Drawing\n");
                        sb.Append("Imports Hydrobase\n");
                        sb.Append("Imports HydrobaseSDK\n");

                        sb.Append("Imports WareForms\n");


                        sb.Append(sCSCode + " \n");

                        CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            //errwin.txtCode.Text = tmp;
                            ErrorWindow errwin = new ErrorWindow(cr.Errors, tmp, true);
                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;

                            errwin.Show();

                            return null;
                        }

                        System.Reflection.Assembly a = cr.CompiledAssembly;


                        object o = a.CreateInstance(NameSapce + "." + Clas);

                        AssemblyCol.Add(a, scrinf);

                        Type t = o.GetType();

                        MethodInfo mi = t.GetMethod(func);
                        //WareForm[] oParams = new WareForm[1];
                        //  oParams[0] = winGUI;
                    // object s = mi.Invoke(o, null);
                    // Process s;
                      //  return s;
                        ScrablerInstaller inst = new ScrablerInstaller();
                        //System.Windows.Forms.MessageBox.Show(Path.GetDirectoryName(scrinf.Filename) + scriptname);
                        if(File.Exists(Path.Combine(path, Path.GetFileNameWithoutExtension(scriptname) + ".exe"))==true )
                        {

                            File.Delete(Path.Combine(path, Path.GetFileNameWithoutExtension(scriptname) + ".exe"));
                        }
                        File.Move(Path.GetDirectoryName(scrinf.Filename) + "\\" + scriptname + ".exe", Path.Combine(path, Path.GetFileNameWithoutExtension(scriptname) + ".exe"));
                        inst.CopyProcessReference(cp, path);
                        return cp.OutputAssembly;

                    }
                }
            return null;

            }
            catch (Exception e)
            {
                Program.Bugtracking(e);

             return null;
            }

        }
       
        /// <summary>
        /// Put in the argument a c# without  to be in class or namespace and execute it
        /// 
        /// </summary>
        /// <param name="sCSCode"></param>
        /// <returns></returns>
        
        
        public object Eval(string sCSCode)
        {
            try
            {
                string NameSapce, Clas;

                if ((sCSCode != null) )
                {
                   

                   
                    ICodeCompiler icc = c.CreateCompiler();
                    ErrorWindow errwin = new ErrorWindow();
                    
                    cp.ReferencedAssemblies.Add("system.dll");
                    cp.ReferencedAssemblies.Add("system.xml.dll");
                    cp.ReferencedAssemblies.Add("system.data.dll");
                    cp.ReferencedAssemblies.Add("system.windows.forms.dll");
                    cp.ReferencedAssemblies.Add("system.drawing.dll");
                    cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                   cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                    cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                    cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                    cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Scrabler.dll");
                    //cp.ReferencedAssemblies.AddRange(refs);
                 //   MessageBox.Show(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", ""));
                    

                    
                    cp.CompilerOptions = "/t:library";
                    cp.GenerateInMemory = true;
                    StringBuilder sb = new StringBuilder("");

                    sb.Append("using System;\n");
                    sb.Append("using System.Xml;\n");
                    sb.Append("using System.Data;\n");
                    sb.Append("using System.Data.SqlClient;\n");
                  sb.Append("using System.Windows.Forms;\n");
                    sb.Append("using System.Drawing;\n");
                    sb.Append("using Hydrobase;\n");
                    sb.Append("using HydrobaseSDK;\n");
                    sb.Append("using Scrabler;\n");

                    //sb.Append("using Frogy_Base_Hydrobase_Data_Enviroment;\n");
                    sb.Append("using WareForms;\n");

                     sb.Append("namespace CSCodeEvaler{ \n");
                     sb.Append("public class CSCodeEvaler{ \n");
                     sb.Append("public object EvalCode(){\n");
                     sb.Append("return " + sCSCode + "; \n");
                    sb.Append(sCSCode + "; \n");
                    sb.Append("} \n");
                    sb.Append("} \n");
                    sb.Append("}\n");

                   
                  
                    CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                  
                    
                    if (cr.Errors.Count > 0)
                    {

                        errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;
                        string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                        errwin.txtCode.Text = tmp;
                        errwin.Show();
                        
                       // System.Console.WriteLine(tmp);
                        return null;
                    }
                  //  MessageBox.Show(sb.ToString());
                    

                    System.Reflection.Assembly a = cr.CompiledAssembly;
                    


                    object o = a.CreateInstance("CSCodeEvaler" + "." + "CSCodeEvaler");
                    ScriptInfo scritf = new ScriptInfo();
                    scritf.Title = "CSCodeEvaler";
                    scritf.ScrablerVersion = Convert.ToString(ScrablerCore.GetVersion());

                    AssemblyCol.Add(a, scritf);

                    Type t = o.GetType();

                    MethodInfo mi = t.GetMethod("EvalCode");
                    //WareForm[] oParams = new WareForm[1];
                    //  oParams[0] = winGUI;
                    if (o != null)
                    {
                        object s = mi.Invoke(o, null);
                        return s;


                    }
                   
                }
                return null;

            }
            catch (Exception e)
            {
                Program.Bugtracking(e);

                return null;
            }

        }
        

        /// <summary>
        /// Executes the code that is saved in the sCSCode
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="sCSCode">here put the code</param>
        /// <param name="scriptname">name of  the sctipt</param>
        /// <param name="NameSapce">the namespace that class
        /// of the script belongs</param>
        /// <param name="Clas">the class of the script</param>
        /// <param name="func">the func that s to be executed</param>
        /// <param name="winGUI">the gui of the app that executes the scripts</param>
        ///  <param name="scrinf">the class tht has the info of the script</param>
        /// <returns>Executes the code that is saved in the sCSCode
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public object EvalWithParams(string sCSCode, string scriptname, string NameSapce, string Clas, string func, string[] refs, WareForm winGUI,ScriptInfo scrinf)
        {



            try
            {


                if ((sCSCode != null) && (scriptname != null) && (NameSapce != null) && (Clas != null) && (func != null) && (refs != null) && (winGUI != null) &&(scrinf!=null) &&(checkCompatibility(scrinf)==true ))
                {
                    if((scrinf.Language=="C#")||(scrinf.Language=="c#"))
                    {
                    ICodeCompiler icc = c.CreateCompiler();
                    

                    cp.ReferencedAssemblies.Add("system.dll");
                    cp.ReferencedAssemblies.Add("system.xml.dll");
                    cp.ReferencedAssemblies.Add("system.data.dll");
                    // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                    cp.ReferencedAssemblies.Add("system.drawing.dll");
                    cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                    cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                    cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                    cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                    cp.ReferencedAssemblies.AddRange(refs);


                    cp.CompilerOptions = "/t:library";
                    cp.GenerateInMemory = true;
                    StringBuilder sb = new StringBuilder("");

                    sb.Append("using System;\n");
                    sb.Append("using System.Xml;\n");
                    sb.Append("using System.Data;\n");
                    sb.Append("using System.Data.SqlClient;\n");
                    //  sb.Append("using System.Windows.objects;\n");
                    sb.Append("using System.Drawing;\n");
                    sb.Append("using Hydrobase;\n");
                    sb.Append("using HydrobaseSDK;\n");

                    //sb.Append("using Frogy_Base_Hydrobase_Data_Enviroment;\n");
                    sb.Append("using WareForms;\n");

                    /* sb.Append("namespace CSCodeEvaler{ \n");
                     sb.Append("public class CSCodeEvaler{ \n");
                     sb.Append("public object EvalCode(){\n");
                     //sb.Append("return " + sCSCode + "; \n");*/
                    sb.Append(sCSCode + "; \n");
                    /*sb.Append("} \n");
                    sb.Append("} \n");
                    sb.Append("}\n");*/
                    //string stat;
                    //sb.Replace(func + "(WareForm gui", func + "( WareForm " + winGUI);


                    CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                    if (cr.Errors.Count > 0)
                    {
                        string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                        ErrorWindow errwin = new ErrorWindow(cr.Errors,tmp);
                        // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);

                        errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;
                      
                        errwin.txtCode.Text = tmp;
                        errwin.Show();

                        return null;
                    }

                    System.Reflection.Assembly a = cr.CompiledAssembly;
                    object o = a.CreateInstance(NameSapce + "." + Clas);
                    AssemblyCol.Add(a, scrinf);
                    Type t = o.GetType();

                    MethodInfo mi = t.GetMethod(func);
                    WareForm[] oParams = new WareForm[1];
                    oParams[0] = winGUI;
                    object s = mi.Invoke(o, oParams);
                    return s;
                }
                     else if((scrinf.Language=="VB")||(scrinf.Language=="vb"))
                    {

                        ICodeCompiler icc = vb.CreateCompiler();
                       // ErrorWindow errwin = new ErrorWindow();



                        cp.ReferencedAssemblies.Add("system.dll");
                        cp.ReferencedAssemblies.Add("system.xml.dll");
                        cp.ReferencedAssemblies.Add("system.data.dll");
                        // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                        cp.ReferencedAssemblies.Add("system.drawing.dll");
                        cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");
                        sb.Append("Imports System\n");
                        sb.Append("Imports System.Xml\n");
                        sb.Append("Imports System.Data\n");
                        sb.Append("Imports System.Data.SqlClient\n");

                        sb.Append("Imports System.Drawing\n");
                        sb.Append("Imports Hydrobase\n");
                        sb.Append("Imports HydrobaseSDK\n");

                        sb.Append("Imports WareForms\n");


                        sb.Append(sCSCode + " \n");

                        CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            ErrorWindow errwin = new ErrorWindow(cr.Errors, tmp,true);
                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;
                            
                            errwin.txtCode.Text = tmp;
                            errwin.Show();
                            
                            return null;
                        }

                        System.Reflection.Assembly a = cr.CompiledAssembly;


                        object o = a.CreateInstance(NameSapce + "." + Clas);

                        AssemblyCol.Add(a, scrinf);

                        Type t = o.GetType();

                        MethodInfo mi = t.GetMethod(func);
                        WareForm[] oParams = new WareForm[1];
                        oParams[0] = winGUI;
                        object s = mi.Invoke(o, oParams);
                       // object s = mi.Invoke(o, null);
                        return s;

                    }

                }
                return null;

            }
            catch (Exception e)
            {
                Program.Bugtracking(e);

                return null;
            }

        }


       /*
        /// <summary>
        /// Executes the code that is saved in the sCSCode
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="sCSCode">here put the code</param>
        /// <param name="scriptname">name of  the sctipt</param>
        /// <param name="NameSapce">the namespace that class
        /// of the script belongs</param>
        /// <param name="Clas">the class of the script</param>
        /// <param name="func">the func that s to be executed</param>
        /// <param name="winGUI">the gui of the app that executes the scripts</param>
        ///  <param name="scrinf">the class tht has the info of the script</param>
        /// <returns>Executes the code that is saved in the sCSCode
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public Process  EvalWithParams(string sCSCode, string scriptname, string NameSapce, string Clas, string func, string[] refs, WareForm winGUI, ScriptInfo scrinf,ScrablerDefSettings sett)
        {



            try
            {


                if ((sCSCode != null) && (scriptname != null) && (NameSapce != null) && (Clas != null) && (func != null) && (refs != null) && (winGUI != null) && (scrinf != null) && (checkCompatibility(scrinf) == true))
                {
                    if ((scrinf.Language == "C#") || (scrinf.Language == "c#"))
                    {
                        ICodeCompiler icc = c.CreateCompiler();


                        cp.ReferencedAssemblies.Add("system.dll");
                        cp.ReferencedAssemblies.Add("system.xml.dll");
                        cp.ReferencedAssemblies.Add("system.data.dll");
                        // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                        cp.ReferencedAssemblies.Add("system.drawing.dll");
                        cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.AddRange(refs);

                        cp.CompilerOptions = "/t:exe";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");

                        sb.Append("using System;\n");
                        sb.Append("using System.Xml;\n");
                        sb.Append("using System.Data;\n");
                        sb.Append("using System.Data.SqlClient;\n");
                        //  sb.Append("using System.Windows.objects;\n");
                        sb.Append("using System.Drawing;\n");
                        sb.Append("using Hydrobase;\n");
                        sb.Append("using HydrobaseSDK;\n");

                        //sb.Append("using Frogy_Base_Hydrobase_Data_Enviroment;\n");
                        sb.Append("using WareForms;\n");

                     
                        sb.Append(sCSCode + "; \n");
                       
                        //string stat;
                        //sb.Replace(func + "(WareForm gui", func + "( WareForm " + winGUI);


                        CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        if (cr.Errors.Count > 0)
                        {
                            string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            ErrorWindow errwin = new ErrorWindow(cr.Errors, tmp);
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);

                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;

                            errwin.txtCode.Text = tmp;
                            errwin.Show();

                            return null;
                        }

                        System.Reflection.Assembly a = cr.CompiledAssembly;
                        object o = a.CreateInstance(NameSapce + "." + Clas);
                        AssemblyCol.Add(a, scrinf);
                        Type t = o.GetType();

                        MethodInfo mi = t.GetMethod(func);
                        WareForm[] oParams = new WareForm[1];
                        oParams[0] = winGUI;
                        object s = mi.Invoke(o, oParams);
                        return s;
                    }
                    else if ((scrinf.Language == "VB") || (scrinf.Language == "vb"))
                    {

                        ICodeCompiler icc = vb.CreateCompiler();
                        // ErrorWindow errwin = new ErrorWindow();



                        cp.ReferencedAssemblies.Add("system.dll");
                        cp.ReferencedAssemblies.Add("system.xml.dll");
                        cp.ReferencedAssemblies.Add("system.data.dll");
                        // cp.ReferencedAssemblies.Add("system.windows.objects.dll");
                        cp.ReferencedAssemblies.Add("system.drawing.dll");
                        cp.ReferencedAssemblies.Add(Application.ExecutablePath);
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\Hydrobase.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");
                        sb.Append("Imports System\n");
                        sb.Append("Imports System.Xml\n");
                        sb.Append("Imports System.Data\n");
                        sb.Append("Imports System.Data.SqlClient\n");

                        sb.Append("Imports System.Drawing\n");
                        sb.Append("Imports Hydrobase\n");
                        sb.Append("Imports HydrobaseSDK\n");

                        sb.Append("Imports WareForms\n");


                        sb.Append(sCSCode + " \n");

                        CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            ErrorWindow errwin = new ErrorWindow(cr.Errors, tmp, true);
                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;

                            errwin.txtCode.Text = tmp;
                            errwin.Show();

                            return null;
                        }

                        System.Reflection.Assembly a = cr.CompiledAssembly;


                        object o = a.CreateInstance(NameSapce + "." + Clas);
                        
                        AssemblyCol.Add(a, scrinf);

                        Type t = o.GetType();

                        MethodInfo mi = t.GetMethod(func);
                        WareForm[] oParams = new WareForm[1];
                        oParams[0] = winGUI;
                        object s = mi.Invoke(o, oParams);
                        // object s = mi.Invoke(o, null);
                        return (Process)s;

                    }

                }
                return null;

            }
            catch (Exception e)
            {
                Program.Bugtracking(e);

                return null;
            }

        }
        */


        /// <summary>
        /// This method sets the references o the script with the given name
        /// if the references is marked as non of application's or .net2 frameworks
        /// itputs as its path the contents of the scriptsreffolder variable
        /// </summary>
        /// <param name="set">the dataset that the content of the script will be saved.</param>
        /// <param name="scriptsreffolder">the folder that will be putted as path for
        /// the reference thatdoesnt belong to neither application and .net2 </param>
        /// <param name="scriptfilename">the path of the script</param>
        
        
        public void SetReferences(DataSet set,string scriptsreffolder,string scriptfilename)
        {

            try
            {
                string[] ap = null,tap;
                string tmp,tmp2=null;
                char[] ar ={ '|' };
                int i,j;
                if ((set != null) && (set.Tables.Count > 0) && (scriptsreffolder!=null) &&(scriptfilename!=null))
                {
                    //DataRowCollection col = set.Tables[0].Rows;

                    DataRow row = set.Tables[0].Rows[0];
                    object[] val = row.ItemArray;
                    i = set.Tables[0].Columns.IndexOf(references);
                    tmp = Convert.ToString(val[i]);
                    ap = tmp.Split(ar);
                    tap = new string[ap.Length];
                    for(j=0;j<tap.Length;j++)
                    {
                        tap[j] = "|"+installer.CheckIfdllNeedToBeInstalled(ap[j], scriptsreffolder);
                        
                    }

                    for (j = 0; j < tap.Length; j++)
                    {
                        tmp2 += tap[j];

                    }
                    
                    val[i] = tmp2;
                    row.ItemArray = val;
                    ado.SaveTable(set, scriptfilename, 0, "");



                    // }

                }
                //return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }

        }
        /// <summary>
        /// Save the Script with the given file name
        /// </summary>
        /// <param name="filename">path that srcpt will be saved</param>
        /// <param name="code">the code of the scrpt</param>
        /// <param name="refer">the references</param>
        ///  <param name="namespc"> The name space of executed code</param>
        /// <param name="execfunc">function to be executed</param>
        /// <param name="execclass">The name of the class that will be executed</param>
        /// <param name="info">the scripts info</param>
        
        public void SaveScript(string filename, string code, 
            string refer, string namespc,string execfunc,string execclass,
            ScriptInfo info)
        {
           try
            { 
                int i;
                ScriptsSet = new DataSet(BaseClass.tabletag);

               
                if((filename !=null )||(code !=null )||
                   (refer !=null ) ||(info !=null)||(execclass !=null))
                {
                    ScriptsSet.Tables.Add(BaseClass.recordtag);

                    ScriptsSet.Tables[0].Columns.Add(ScrablerCore.namespacetag);
                    ScriptsSet.Tables[0].Columns.Add(ScrablerCore.classtag);
                    ScriptsSet.Tables[0].Columns.Add(ScrablerCore.execution_func);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.Code);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.Titletag);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.VersionTag);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.Author);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.Description);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.Copyright);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.LangTag);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.LowerApplicationVersionTag);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.MaxApplicationVersionTag);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.Scrabler_VersionTag);
                         ScriptsSet.Tables[0].Columns.Add(ScrablerCore.references);
                        // ScriptsSet.Tables[0].Columns.Add(classtag);
                    
                         
                        
                         object[] val = new object[ScriptsSet.Tables[0].Columns.Count];

                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.Titletag);
                         val[i] = info.Title;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.Author);
                         val[i] = info.Author;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.Description);
                         val[i] = info.Description;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.Copyright);
                         val[i] = info.Copyright;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.LangTag);
                         val[i] = info.Language;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.LowerApplicationVersionTag);
                         val[i] = info.LowerApplicationVersion;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.MaxApplicationVersionTag);
                         val[i]=info.MaxApplicationVersion;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.Scrabler_VersionTag);
                         val[i] = info.ScrablerVersion;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.references);
                         val[i] = refer;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.namespacetag);
                         val[i] = namespc;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.execution_func);
                         val[i] = execfunc;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.Code);
                         val[i] = code;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.VersionTag);
                         val[i] = info.Version;
                         i = ScriptsSet.Tables[0].Columns.IndexOf(ScrablerCore.classtag);
                         val[i] = execclass;
                       
                         ScriptsSet.Tables[0].Rows.Add(val);
                         //ScriptsSet.Tables[0].WriteXml(filename);
                   
                         ScriptsSet.Tables[0].TableName = BaseClass.recordtag;
                       //  ScriptsSet.WriteXml(filename);
                    
                        
                        ado.SaveTable(ScriptsSet, filename, 0,"dffff");
                     
                         //MessageBox.Show(o.ToString());
                     
                     
                     
                     

                 }

            }
            catch (Exception e)
            {

              Program.Bugtracking(e);
                //return null;
            }

        }
        }
    }

