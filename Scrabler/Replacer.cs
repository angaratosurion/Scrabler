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

using WareForms;
using Hydrobase;
using HydrobaseSDK;
//// 

namespace Scrabler
{
    /// <summary>
    /// Replaces Some specific definisions with given values.
    ///  @authorKiparissis Koutsioukis(Angarato Surion)
    /// </summary>
   public class Replacer:ScrablerInstaller
    {
       /// <summary>
       /// The tag that indicates that this const mst be replaced
       /// </summary>
       public const string replacemanettag = "#";
       /// <summary>
       /// Search and replaces the defined consts with their values
       /// </summary>
       /// <param name="source">the source of the script</param>
       /// <param name="filter"> the array with the consts</param>
       /// <param name="replacewith">the array with values</param>
       /// <returns> the code with the values  of the consts</returns>
       public string  findandreplaceDefinedConsts(string source,string filter, string replacewith)
       {

           try
           {
               string ap = null,tmp;
               //string[] wordsforchange;
               if((source !=null)  &&(replacewith!=null) &&(filter !=null))
               {
                   tmp =source.Replace(replacemanettag + filter ,replacewith);
                   ap = tmp.Replace("$", "&&");



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
       /// Search and replaces the defined symbols with their values that doesnt work in xml files
       /// 
      /// </summary>
       /// <param name="source">the source of the script</param>
       /// <returns>Search and replaces the defined symbols with their values that doesnt work in xml files
       /// and retrunrs the result
       /// </returns>
       public string findandreplaceSymbols(string source)
       {

           try
           {
               string ap = null, tmp;
               //string[] wordsforchange;
               if (source != null) 
               {
                   //tmp = source.Replace(replacemanettag + filter, replacewith);
                   ap = source.Replace("$", "&&");



               }
               return ap;


           }
           catch (Exception e)
           {

               Program.Bugtracking(e);
               return null;
           }


       }
       
    }
}
