using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;

using System.Collections;
using System.Reflection;



namespace Scrabler
{

    /// <summary>
    /// Class which loads the plugins for scrabler
    /// </summary>

    public class ScrablerPluginsLoader : IConfigurationSectionHandler
    {

        /// <summary>
        /// Class which loads the plugins for scrabler
        /// </summary>
        public ScrablerPluginsLoader()
        {
            //TheDarkOwlLogger.TheDarkOwlLogger hbug = new TheDarkOwlLogger.TheDarkOwlLogger();
        }
        #region IConfigurationSectionHandler Members
       // BaseClass hbclas = new BaseClass();
        //TheDarkOwlLogger.TheDarkOwlLogger hdBugger = new TheDarkOwlLogger.TheDarkOwlLogger();
        //static public ScrablerPluginCollection Loaded_ScrablerPlugins ;
        /// <summary>
        /// Iterate through all the child nodes
        ///	of the XMLNode that was passed in and create instances
        ///	of the specified Types by reading the attribite values of the nodes
        ///	we use a try/Catch here because some of the nodes
        ///	might contain an invalid reference to a ScrablerPlugin type
        ///	</summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section">The XML section we will iterate against</param>
        /// <returns></returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            ScrablerPluginCollection Loaded_ScrablerPlugins = new ScrablerPluginCollection();

            foreach (XmlNode node in section.ChildNodes)
            {
                try
                {
                    //Use the Activator class's 'CreateInstance' method
                    //to try and create an instance of the ScrablerPlugin by
                    //passing in the type name specified in the attribute value
                    object plugObject = Activator.CreateInstance(Type.GetType(node.Attributes["type"].Value));

                    //Cast this to an ScrablerPluginSDK interface and add to the collection
                    ScrablerPluginSDK ScrablerPlugin = (ScrablerPluginSDK)plugObject;
                    Loaded_ScrablerPlugins.Add(ScrablerPlugin);
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.ToString());
                    //hbclas.errorhandling(e);
                    //Catch any exceptions
                    //but continue iterating for more ScrablerPlugins
                    Program.Bugtracking(e);
                }
            }

            return Loaded_ScrablerPlugins;
        }
        public string[] GetHydrobaseScrablerPluginsInfo(ScrablerPluginCollection HyPlugColl)
        {
            try
            {
                string[] ScrablerPluginNamesAndVersions = null;
                int Ply8osScrablerPlugins, i = 0;

                if (HyPlugColl != null)
                {
                    Ply8osScrablerPlugins = HyPlugColl.Count;
                    ScrablerPluginNamesAndVersions = new string[Ply8osScrablerPlugins];
                    foreach (ScrablerPluginSDK ScrablerPlugin in HyPlugColl)
                    {
                        if (i < Ply8osScrablerPlugins)
                        {
                            ScrablerPluginNamesAndVersions[i] = ScrablerPlugin.Name + " - " + ScrablerPlugin.GetScrablerPluginVersion();

                            i++;
                        }



                    }

                }
                return ScrablerPluginNamesAndVersions;


            }
            catch (Exception e)
            {
                Program.Bugtracking(e);

                return null;
            }


        }
        #endregion
        /// <summary>
        /// Gets the SDK's Version
        /// </summary>
        /// <returns></returns>
        public string GetScrablerPluginsLoaderVersion()
        {
            try
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();


            }
            catch (Exception e)
            {
                Program.Bugtracking(e);
                return null;

            }




        }
        /// <summary>
        /// finds a plugin in the loaded plugins collection
        /// </summary>
        /// <param name="plugColl">collections whichs keeps the plugins</param>
        /// <param name="ScrablerPluginName">name of the plugin which you are looking for.</param>
        /// <returns>the plugin you are looking for</returns>
        public ScrablerPluginSDK FindAScrablerPlugin(ScrablerPluginCollection plugColl, string ScrablerPluginName)
        {

            try
            {
                ScrablerPluginSDK plugret = null;
                if ((plugColl != null) && (ScrablerPluginName != null))
                {

                    foreach (ScrablerPluginSDK ScrablerPlugin in plugColl)
                    {
                        if (ScrablerPlugin.Name == ScrablerPluginName)
                        {

                            plugret = ScrablerPlugin;

                        }


                    }



                }
                return plugret;


            }

            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;

            }



        }
        /// <summary>
        /// checks if a plugin exist in the given colelction with name.
        /// </summary>
        /// <param name="plugColl">plugin collection</param>
        /// <param name="ScrablerPluginName">name of the plugin</param>
        /// <returns>true if it exists</returns>
        public bool ExistScrablerPlugin(ScrablerPluginCollection plugColl, string ScrablerPluginName)
        {


            try
            {
                bool res = false;
                int i, Plh8osPlug;
                if ((plugColl != null) && (ScrablerPluginName != null))
                {
                    Plh8osPlug = plugColl.Count;
                    //foreach (ScrablerPluginSDK ScrablerPlugin in plugColl)
                    for (i = 0; i < Plh8osPlug; i++)
                    {
                        if (plugColl[i].Name.Equals(ScrablerPluginName) == true)
                        {


                            res = true;
                            //MessageBox.Show(Convert.ToString(res));
                            break;

                        }


                    }



                }
                return res;


            }

            catch (Exception e)
            {

                Program.Bugtracking(e);
                return false;

            }



        }
        /// <summary>
        /// checks if a plugin exist in the given colelction with which starts with the given  name.
        /// </summary>
        /// <param name="plugColl">plugin collection</param>
        /// <param name="ScrablerPluginName">name of the plugin</param>
        /// <returns>true if it exists</returns>
        public bool ExistScrablerPluginStartsWith(ScrablerPluginCollection plugColl, string ScrablerPluginName)
        {
            try
            {
                bool res = false;
                int i, Plh8osPlug;
                if ((plugColl != null) && (ScrablerPluginName != null))
                {
                    Plh8osPlug = plugColl.Count;
                    //foreach (ScrablerPluginSDK ScrablerPlugin in plugColl)
                    for (i = 0; i < Plh8osPlug; i++)
                    {
                        if (plugColl[i].Name.StartsWith(ScrablerPluginName) == true)
                        {


                            res = true;
                            //MessageBox.Show(Convert.ToString(res));
                            break;

                        }


                    }



                }
                return res;


            }

            catch (Exception e)
            {

                Program.Bugtracking(e);
                return false;

            }


        }
        /// <summary>
        /// Clears the given plugin collection
        /// </summary>
        /// <param name="plugcoll">plugin colelction to be cleared</param>
        public void ClearScrablerPluginsCollection(ScrablerPluginCollection plugcoll)
        {
            try
            {
                if (plugcoll != null)
                {
                    plugcoll.Clear();


                }



            }
            catch (Exception e)
            {
                Program.Bugtracking(e);

            }


        }

        /// <summary>
        /// Deleted the plugin with the given name
        /// </summary>
        /// <param name="plugcoll">plugins colelction</param>
        /// <param name="plugname">name of plugin</param>
        public void DeleteSelectedScrablerPlugin(ScrablerPluginCollection plugcoll, string plugname)
        {

            try
            {
                if ((plugcoll != null) && (plugname != null))
                {
                    this.FindAScrablerPlugin(plugcoll, plugname).Dispose();
                    plugcoll.Remove(this.FindAScrablerPlugin(plugcoll, plugname));


                }



            }
            catch (Exception e)
            {
                Program.Bugtracking(e);

            }
        }
      /*
        public ScrablerPluginSDK FindAScrablerPluginBasedOnKind(ScrablerPluginCollection plugcoll, string ScrablerPluginkind)
        {
            try
            {
                ScrablerPluginSDK plug = null;
                int i;
                if ((plugcoll != null) || (ScrablerPluginkind != null))
                {
                    for (i = 0; i < plugcoll.Count; i++)
                    {
                        
                            plug = plugcoll[i];
                            break;

                        

                    }


                }
                return plug;

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }

        }
        public ScrablerPluginCollection FindAScrablerPluginsBasedOnKind(ScrablerPluginCollection plugcoll, string ScrablerPluginkind)
        {
            try
            {
                ScrablerPluginCollection plug = null;
                int i;
                if ((plugcoll != null) || (ScrablerPluginkind != null))
                {
                    plug = new ScrablerPluginCollection();
                    for (i = 0; i < plugcoll.Count; i++)
                    {
                        
                            plug.Add(plugcoll[i]);


                      

                    }


                }
                return plug;

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;
            }

        }
       */
       
        /// <summary>
        /// Copies the plugin with the given name from on plugin collection to other one
        /// </summary>
        /// <param name="source">source plugin colelction</param>
        /// <param name="target">target plugin collection</param>
        /// <param name="plugname">name of plugin name</param>        
        public void CopyScrablerPlugin(ScrablerPluginCollection source, ScrablerPluginCollection target, string plugname)
        {
            try
            {
                ScrablerPluginSDK plg;
                if ((source != null) || (target != null) || (plugname != null))
                {
                    plg = this.FindAScrablerPlugin(source, plugname);
                    target.Add(plg);
                }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
            }
        }
        /*
         public void CopyScrablerPluginBasedOnKind(ScrablerPluginCollection source, ScrablerPluginCollection target, string plugkind)
        {
            try
            {
                ScrablerPluginSDK plg;
                if ((source != null) || (target != null) || (plugkind != null))
                {
                    plg = this.FindAScrablerPluginBasedOnKind(source, plugkind);
                    if (plg != null)
                    {
                        target.Add(plg);
                    }

                }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
            }








        }*/
    }


}
