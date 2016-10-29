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
using System.Collections;

using WareForms;
using Hydrobase;
using HydrobaseSDK;
// 

namespace Scrabler
{
    /// <summary>
    /// This is a colleection of assebly type that the scripts will be save aftet their 
    /// execution.
    ///  @authorKiparissis Koutsioukis(Angarato Surion)
    /// </summary>
    public class AssemblyCollection:CollectionBase
    {
        List<ScriptInfo> scripinfCol = new List<ScriptInfo>();
        /// <summary>
        /// Adds given assembly to the collection
        /// </summary>
        /// <param name="assembly">given assembly</param>
        /// <param name="scrinf"> script's info</param>
        public void Add(Assembly assembly,ScriptInfo scrinf)
        {

            try
            {
                if ((assembly != null) &&(scrinf!=null) )
                {
                    if (List.Contains(assembly) != true)
                    {
                        this.List.Add(assembly);
                        this.scripinfCol.Add(scrinf);
                    }
                    else
                    {
                        this.List.Remove(assembly);
                        this.scripinfCol.Remove(scrinf);
                        this.List.Add(assembly);
                        this.scripinfCol.Add(scrinf);

                    }
                }


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }


        }
        /// <summary>
       /// Adds given array assembly to the collection
        /// </summary>
        /// <param name="assembly">array of assembly</param>
        /// <<param name="scriptinf">the array that includes the information of the scripts</param>
        public void AddRange(Assembly[] assembly, ScriptInfo [] scriptinf)
        {
            try
            {

                if ((assembly != null) &&(scriptinf!=null))
                {
                    int i = 0;
                    for (i = 0; i < assembly.Length; i++)
                    {

                        Add(assembly[i],scriptinf[i]);
                        //scripinfCol.Add(]);

                    }
                    

                }

            }


            catch (Exception e)
            {

                Program.Bugtracking(e);
               // return null;
            }
        }
        /// <summary>
        /// returns the index of the given assembly
        /// or a value lower than 0 when an error occurs or nothing happened
        /// </summary>
        /// <param name="assmbly">the assembly that we saerch for</param>
        /// <returns>returns the index of the given assembly
        /// or a value lower than 0 when an error occurs or nothing happened</returns>
        public int IndexOf(Assembly assmbly)
        {

            try
            {
                int ap = -1;
                if (assmbly != null)
                {

                    ap = List.IndexOf(assmbly);

                }
                return ap;

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return -2;
            }

        }
        /// <summary>
        /// Removes given assembly from colelction
        /// </summary>
        /// <param name="assembly">assembly that is to be removed</param>
        public void Remove(Assembly assembly)
        {

            try
            {
                if (assembly != null)
                {


                    List.Remove(assembly);
                    foreach (ScriptInfo scr in scripinfCol)
                    {
                        Type [] t= assembly.GetTypes();
                        if (scr.Title == t[0].Namespace)
                        {

                            scripinfCol.Remove(scr);

                        }

                    }
                }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }


        }
        /// <summary>
        /// checks if the given assembly exists 
        /// returns true if exists or false if doesnt
        /// </summary>
        /// <param name="assembly">assembly we search for</param>
        /// <returns>returns true if exists or false if doesnt</returns>
        public bool Contains(Assembly assembly)
        {

            try
            {
                bool ap = false;
                if (assembly != null)
                {
                   ap= List.Contains(assembly);


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
        /// checks if exists any assmbly with the given namespace
        /// returns true if exists or false if doesnt
        /// </summary>
        /// <param name="nameSpace">the namespace of the assembly that we search for</param>
        /// <returns>returns true if exists or false if doesnt</returns>
        public bool Contains(string nameSpace)
        {

            try
            {
                bool ap = false;
                int i;
                if (nameSpace != null)
                {
                    for (i = 0; i < List.Count; i++)
                    {

                        Assembly tmp = (Assembly)List[i];
                        Type [] t= tmp.GetTypes();
                        if (t[0].Namespace == nameSpace)
                        {

                             ap = true;
                             break;

                        }

                    }



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
        /// Returns the index of the assembly with the given namespace
        /// or a value lower than zero wehn doesnt exists 
        /// </summary>
        /// <param name="nameSpace">the namespace of the assembly that we search for</param>
        /// <returns>Returns the index of the assembly with the given namespace
        /// or a value lower than zero wehn doesnt exists</returns>
        public int IndexOf(string nameSpace)
        {

            try
            {
               int ap = -1;
                int i;
                if (nameSpace != null)
                {
                    for (i = 0; i < List.Count; i++)
                    {

                        Assembly tmp = (Assembly)List[i];
                        Type[] t = tmp.GetTypes();
                        if (t[0].Namespace  == nameSpace)
                        {

                            ap = List.IndexOf(tmp);
                            break;

                        }

                    }



                }
                return ap;


            }

            catch (Exception e)
            {

                Program.Bugtracking(e);
                return -2;
            }

        }
        /// <summary>
        /// Returns the assembly form the given index
        /// or null if doesnt exist or an error occured
        /// </summary>
        /// <param name="index">index in the collection that the assembly exists</param>
        /// <returns> Returns the assembly form the given index
        /// or null if doesnt exist or an error occured</returns>
        public Assembly GetItem(int index)
        {

            try
            {
                Assembly ap = null;
                if (index >= 0)
                {

                    ap = (Assembly)List[index];
                    
                    

                }
                return ap;


            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null ;
            }



        }
        /// <summary>
        ///  Returns the assembly form the given namespace
        /// or null if doesnt exist or an error occured
        /// </summary>
        /// <param name="Namespace">the namespace of the assembly that we search for</param>
        /// <returns>Returns the assembly form the given namespace
        /// or null if doesnt exist or an error occured</returns>
        public Assembly GetItem(string Namespace)
        {

            try
            {
                Assembly ap = null;
                int i;
                if ((Namespace!=null)&&(Contains(Namespace)==true ) )
                {

                    for (i = 0;i< List.Count; i++)
                    {
                        Assembly tmp = (Assembly)List[i];
                        Type[] t = tmp.GetTypes();
                        if (t[0].Namespace == Namespace)
                        {

                            ap = tmp;
                            break;

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
        /// Returns the information of  loaded scripts
        /// </summary>
        /// <returns>Returns the information of  loaded scripts</returns>
        public List<ScriptInfo> ScriptInfoCollection()
        {
            try
            {
                if (scripinfCol != null)
                {


                    return scripinfCol;
                }
                return null;


            }
             catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }
            }


        
       
        
    }
}
