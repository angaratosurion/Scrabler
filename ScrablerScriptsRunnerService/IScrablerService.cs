using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Scrabler;

namespace ScrablerService
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
  //  [ServiceContract]
    [ServiceContract(Namespace = "http://ScrablerService")]
    public interface IScrablerService
    {
        [OperationContract]
        string GetServiceVersion();
        [OperationContract]
        void createScriptsDirectory(string username);
        [OperationContract]
        void Autoexecutescripts(string username,int version);
    
        [OperationContract]
          object Executescript(string file);
        [OperationContract]
        ScriptInfo [] GetLoadedScripts();
    }

    
}
