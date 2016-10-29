using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using WareForms;
using System.Reflection;

//// 

namespace Scrabler
{
    public class ScrablerPlugin : ScrablerCore
    {
    }
   
    public abstract class ScrablerPluginSDK : ScrablerCore
   {
       public static string AppFolder;
       string tkind;

       public ScrablerPluginSDK()
       {


       }

       /*public abstract string[] GetReferences(DataSet set);
       public abstract string GetNameSace(DataSet set);
       public abstract string GetClass(DataSet set);
       public abstract string GetFunction(DataSet set);
       public abstract string GetCode(DataSet set);
       public abstract ScriptInfo GetScriptInfo(DataSet set);
        public abstract bool checkCompatibility(ScriptInfo scrinf);
       public abstract object Eval(string sCSCode, string scriptname, string NameSapce, string Clas, string func, string[] refs, ScriptInfo scrinf);
       public abstract object EvalWithParams(string sCSCode, string scriptname, string NameSapce, string Clas, string func, string[] refs, WareForm winGUI, ScriptInfo scrinf);
       public abstract void SetReferences(DataSet set, string scriptsreffolder, string scriptfilename);
        public abstract string  GetProgrammLanguage(DataSet set);
        
        */
       public abstract object ReadScript(string filename, WareForm gui);
       public abstract object ReadScript(string filename);
       


       public abstract string MakeAction(ScrablerPlugin plugcontent, object tobj, params  string[] tparam);
       
      
       public abstract string Name
       {
           get;






       }
       abstract public string GetScrablerPluginVersion();
       /*{

           try
           {
               string Ekdo = null;



               Ekdo = Assembly.GetExecutingAssembly().GetName().Version.ToString();
               //Ekdo=Assembly.
               return Ekdo;
           }
           catch (Exception e)
           {
               return null;

           }
       }*/
       public abstract void Dispose();





   }
    public class ScrablerPluginCollection : CollectionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> class.
        /// </summary>
        public ScrablerPluginCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> class containing the elements of the specified source collection.
        /// </summary>
        /// <param name="value">A <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> with which to initialize the collection.</param>
        public ScrablerPluginCollection(ScrablerPluginCollection value)
        {
            this.AddRange(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> class containing the specified array of <see cref="ScrablerPluginSDK">ScrablerPluginSDK</see> objects.
        /// </summary>
        /// <param name="value">An array of <see cref="ScrablerPluginSDK">ScrablerPluginSDK</see> objects with which to initialize the collection. </param>
        public ScrablerPluginCollection(ScrablerPluginSDK[] value)
        {
            this.AddRange(value);
        }

        /// <summary>
        /// Gets the <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> at the specified index in the collection.
        /// <para>
        /// In C#, this property is the indexer for the <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> class.
        /// </para>
        /// </summary>
        public ScrablerPluginSDK this[int index]
        {
            get { return ((ScrablerPluginSDK)(this.List[index])); }
        }

        public int Add(ScrablerPluginSDK value)
        {
            return this.List.Add(value);
        }

        /// <summary>
        /// Copies the elements of the specified <see cref="ScrablerPluginSDK">ScrablerPluginSDK</see> array to the end of the collection.
        /// </summary>
        /// <param name="value">An array of type <see cref="ScrablerPluginSDK">ScrablerPluginSDK</see> containing the objects to add to the collection.</param>
        public void AddRange(ScrablerPluginSDK[] value)
        {
            for (int i = 0; (i < value.Length); i = (i + 1))
            {
                this.Add(value[i]);
            }
        }

        /// <summary>
        /// Adds the contents of another <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> to the end of the collection.
        /// </summary>
        /// <param name="value">A <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> containing the objects to add to the collection. </param>
        public void AddRange(ScrablerPluginCollection value)
        {
            for (int i = 0; (i < value.Count); i = (i + 1))
            {
                this.Add((ScrablerPluginSDK)value.List[i]);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection contains the specified <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see>.
        /// </summary>
        /// <param name="value">The <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> to search for in the collection.</param>
        /// <returns><b>true</b> if the collection contains the specified object; otherwise, <b>false</b>.</returns>
        public bool Contains(ScrablerPluginSDK value)
        {
            return this.List.Contains(value);
        }

        /// <summary>
        /// Copies the collection objects to a one-dimensional <see cref="T:System.Array">Array</see> instance beginning at the specified index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array">Array</see> that is the destination of the values copied from the collection.</param>
        /// <param name="index">The index of the array at which to begin inserting.</param>
        public void CopyTo(ScrablerPluginSDK[] array, int index)
        {
            this.List.CopyTo(array, index);
        }

        /// <summary>
        /// Creates a one-dimensional <see cref="T:System.Array">Array</see> instance containing the collection items.
        /// </summary>
        /// <returns>Array of type ScrablerPluginSDK</returns>
        public ScrablerPluginSDK[] ToArray()
        {
            ScrablerPluginSDK[] array = new ScrablerPluginSDK[this.Count];
            this.CopyTo(array, 0);

            return array;
        }

        /// <summary>
        /// Gets the index in the collection of the specified <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see>, if it exists in the collection.
        /// </summary>
        /// <param name="value">The <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> to locate in the collection.</param>
        /// <returns>The index in the collection of the specified object, if found; otherwise, -1.</returns>
        public int IndexOf(ScrablerPluginSDK value)
        {
            return this.List.IndexOf(value);
        }

        public void Insert(int index, ScrablerPluginSDK value)
        {
            List.Insert(index, value);
        }

        public void Remove(ScrablerPluginSDK value)
        {
            List.Remove(value);
        }

        /// <summary>
        /// Returns an enumerator that can iterate through the <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> instance.
        /// </summary>
        /// <returns>An <see cref="ScrablerPluginCollectionEnumerator">ScrablerPluginCollectionEnumerator</see> for the <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> instance.</returns>
        public new ScrablerPluginCollectionEnumerator GetEnumerator()
        {
            return new ScrablerPluginCollectionEnumerator(this);
        }

        /// <summary>
        /// Supports a simple iteration over a <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see>.
        /// </summary>
        public class ScrablerPluginCollectionEnumerator : IEnumerator
        {
            private IEnumerator _enumerator;
            private IEnumerable _temp;

            /// <summary>
            /// Initializes a new instance of the <see cref="ScrablerPluginCollectionEnumerator">ScrablerPluginCollectionEnumerator</see> class referencing the specified <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> object.
            /// </summary>
            /// <param name="mappings">The <see cref="ScrablerPluginCollection">ScrablerPluginCollection</see> to enumerate.</param>
            public ScrablerPluginCollectionEnumerator(ScrablerPluginCollection mappings)
            {
                _temp = ((IEnumerable)(mappings));
                _enumerator = _temp.GetEnumerator();
            }

            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            public ScrablerPluginSDK Current
            {
                get { return ((ScrablerPluginSDK)(_enumerator.Current)); }
            }

            object IEnumerator.Current
            {
                get { return _enumerator.Current; }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns><b>true</b> if the enumerator was successfully advanced to the next element; <b>false</b> if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            bool IEnumerator.MoveNext()
            {
                return _enumerator.MoveNext();
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                _enumerator.Reset();
            }

            void IEnumerator.Reset()
            {
                _enumerator.Reset();
            }
        }
    }
}
