using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel; 
using ScrablerService;
namespace ScrablerServiceHost
{
    public partial class ScrablerServiceHost : ServiceBase
    {   ServiceHost host = new ServiceHost(typeof(ScrablerService.ScrablerService));
        public ScrablerServiceHost()
        { 
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                host.Open();
            }
            catch (Exception ex)
            {

              //  host.Open();
                System.Console.WriteLine (ex.ToString());
            }
            
        }

        protected override void OnStop()
        {

            host.Close();
        }
    }
}
