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
using NLog;

namespace Scrabler
{
    public class ScrablerV2 : ScrablerCore
    {
        Replacer replacer = new Replacer();
        hydrobaseADO ado = new hydrobaseADO();
        /// <summary>
        /// Xml-file which includes the info for the scrabler script
        /// </summary>
        public const string scriptext = ".scf2";
        /// <summary>
        ///  Reads the xmlfile containing the information of the script  executes it
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="scriptname">the full path in which the script's directory is located</param>
        /// <param name="gui">the gui of the application that will
        /// execute the script</param>
        /// <returns>the assembly which is the result of the executed script</returns>
        public object ReadScript(string scriptname, WareForm gui)
        {

            try
            {
                int i = 0;
                object ap = null;
                DataSet set = new DataSet();
                if ((scriptname != null) && (gui != null))
                {
                    string code, clas, func, names, tfilename;
                    tfilename = scriptname + scriptext;
                    string[] refs;
                    ado.AttachDataBaseinDataSet(set, tfilename);
                    refs = this.GetReferences(set);
                    names = this.GetNameSace(set);
                    code = this.GetCode(set);
                    clas = this.GetClass(set);
                    func = this.GetFunction(set);
                    if ((definedConstants != null) && (definedValues != null) && (definedConstants.Length == definedValues.Length))
                    {
                        for (i = 0; i < definedConstants.Length; i++)
                        {
                            code = replacer.findandreplaceDefinedConsts(code, definedConstants[i], definedValues[i]);
                            code = replacer.findandreplaceSymbols(code);

                        }


                    }
                    else if ((definedConstants == null) && (definedValues == null) && (definedConstants.Length == definedValues.Length))
                    {

                        code = replacer.findandreplaceSymbols(code);

                    }




                    ScriptsSet = set;
                    ScriptInfo scrinf = this.GetScriptInfo(set);
                    scrinf.Filename = scriptname;
                    ap = this.EvalWithParams(code.Split('\n'), scriptname, names, clas, func, refs, gui, scrinf);





                }
                return ap;



            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }



        }
        public object EvalWithParams(string[] sCSCode, string scriptname, string NameSapce, string Clas, string func, string[] refs, WareForm winGUI, ScriptInfo scrinf)
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
                        //cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "Scrabler.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");

                        /* sb.Append("using System;\n");
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
                          //sb.Append("return " + sCSCode + "; \n");
                         sb.Append(sCSCode + "; \n"); */
                        /*sb.Append("} \n");
                        sb.Append("} \n");
                        sb.Append("}\n");*/
                        //string stat;
                        //sb.Replace(func + "(WareForm gui", func + "( WareForm " + winGUI);


                        //   CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
                        CompilerResults cr = icc.CompileAssemblyFromFileBatch(cp, sCSCode);

                        if (cr.Errors.Count > 0)
                        {
                            //  string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            ErrorWindow errwin = new ErrorWindow();
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);

                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;

                            // errwin.txtCode.Text = cr.
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
                        // cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "Scrabler.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";
                        cp.GenerateInMemory = true;
                        /* StringBuilder sb = new StringBuilder("");
                         sb.Append("Imports System\n");
                         sb.Append("Imports System.Xml\n");
                         sb.Append("Imports System.Data\n");
                         sb.Append("Imports System.Data.SqlClient\n");

                         sb.Append("Imports System.Drawing\n");
                         sb.Append("Imports Hydrobase\n");
                         sb.Append("Imports HydrobaseSDK\n");

                         sb.Append("Imports WareForms\n");


                         sb.Append(sCSCode + " \n");*/

                        CompilerResults cr = icc.CompileAssemblyFromFileBatch(cp, sCSCode);
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            ErrorWindow errwin = new ErrorWindow();
                            errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;

                            //errwin.txtCode.Text = tmp;
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
        /// <summary>
        /// Reads the xmlfile containing the information of the script  executes it
        /// and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.
        /// </summary>
        /// <param name="scriptname">the full path in which the script's directory is located</param>
        /// <returns>the assembly which is the result of the executed script</returns>
        public object ReadScript2(string scriptname)
        {

            try
            {
                int i = 0;
                object ap = null;
                DataSet set = new DataSet();

                if (scriptname != null)
                {

                    string code, clas, func, names, lang, tfilename;
                    if (Path.GetExtension(scriptname) == null)
                    {
                        tfilename = Path.Combine(scriptname, scriptext);
                    }
                    else
                    {
                        tfilename = scriptname;
                    }

                    string[] refs;
                    //  MessageBox.Show(tfilename);

                    ado.AttachDataBaseinDataSet(set, tfilename);
                    //    MessageBox.Show(set.Tables[0].TableName);
                    refs = this.GetReferences(set);
                    names = this.GetNameSace(set);
                    code = this.GetCode(set);
                    clas = this.GetClass(set);
                    func = this.GetFunction(set);
                    lang = this.GetLanguage(set);

                    /*    if ((definedConstants != null) && (definedValues != null) && (definedConstants.Length == definedValues.Length))
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

                        } */

                    // MessageBox.Show(code);

                    ScriptsSet = set;
                    ScriptInfo scrinfo = this.GetScriptInfo(set);
                    scrinfo.Filename = scriptname;
                    //  MessageBox.Show(scrinfo.Language);
                    ap = Eval2(code.Split('\n'), scriptname, names, clas, func, refs, scrinfo);










                }

                return ap;



            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
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
        /// <param name="refs">the references that </param>
        /// <param name="scrinf">Class that has info about script</param>
        /// <returns>and returns the assembly if the script is being 
        /// excuted or null if no ecript executed or an error occures.</returns>
        public object Eval2(string[] sCSCode, string scriptname, string NameSapce, string Clas, string func, string[] refs, ScriptInfo scrinf)
        {
            try
            {

                //string e = File.ReadAllText(sCSCode[0]);
                //   MessageBox.Show(e);


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
                        //cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "Scrabler.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";

                        cp.GenerateInMemory = true;
                        /* StringBuilder sb = new StringBuilder("");
                         sb.Append("using System;\n");
                         sb.Append("using System.Xml;\n");
                         sb.Append("using System.Data;\n");
                         sb.Append("using System.Data.SqlClient;\n");

                         sb.Append("using System.Drawing;\n");
                         sb.Append("using Hydrobase;\n");
                         sb.Append("using HydrobaseSDK;\n");

                         sb.Append("using WareForms;\n");


                       //  sb.Append(sCSCode + "; \n");*/
                        // MessageBox.Show("hhh" );

                        /*foreach (string st in sCSCode)
                        {
                            MessageBox.Show("hhh1" +st );
                        }*/
                        // MessageBox.Show(sCSCode[0]);
                        CompilerResults cr = icc.CompileAssemblyFromFileBatch(cp, sCSCode);
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // cr.Errors[0].
                            // string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            // // errwin.txtCode.Text = tmp;

                            ErrorWindow errwin = new ErrorWindow();


                            /*errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;
                            //MessageBox.Show(cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText);
                            errwin.Show();*/
                            this.SaveErrorrs(cr.Errors);

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
                        //cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "HydrobaseSDK.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "WareForms.dll");
                        cp.ReferencedAssemblies.Add(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\" + "Scrabler.dll");
                        cp.ReferencedAssemblies.AddRange(refs);


                        cp.CompilerOptions = "/t:library";
                        cp.GenerateInMemory = true;
                        StringBuilder sb = new StringBuilder("");
                        /*  sb.Append("Imports System\n");
                          sb.Append("Imports System.Xml\n");
                          sb.Append("Imports System.Data\n");
                          sb.Append("Imports System.Data.SqlClient\n");

                          sb.Append("Imports System.Drawing\n");
                          sb.Append("Imports Hydrobase\n");
                          sb.Append("Imports HydrobaseSDK\n");

                          sb.Append("Imports WareForms\n");


                          sb.Append(sCSCode + " \n");*/

                        CompilerResults cr = icc.CompileAssemblyFromFileBatch(cp, sCSCode);
                        if (cr.Errors.Count > 0)
                        {
                            // MessageBox.Show("ERROR in " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText + cr.Errors[0].ToString() +"\n" + sb.ToString(), "Error evaluating cs code" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // string tmp = sb.ToString().Replace("\n", Environment.NewLine);
                            //errwin.txtCode.Text = tmp;
                            /* ErrorWindow errwin = new ErrorWindow();
                             errwin.listErrors.Text = "ERROR in line " + cr.Errors[0].Line + ": " + cr.Errors[0].ErrorText;

                             errwin.Show();
                             this.SaveErrorrs(cr.Errors);
                             */
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
        /// Saves all the compilation erros  in a file at application's installation folder
        /// </summary>
        /// <param name="compilererrcol"></param>
        public void SaveErrorrs(CompilerErrorCollection compilererrcol)
        {

            try
            {
                if (compilererrcol != null)
                {

                    StreamWriter wr = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\errrors.txt", true, Encoding.UTF8);
                    foreach (CompilerError err in compilererrcol)
                    {

                        wr.WriteLine();
                        wr.WriteLine(err.ToString());
                    }
                    wr.Flush();
                    wr.Close();

                }

            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
                //return null;
            }

        }


    }
}
