using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScrablerService;
using System.ServiceModel;


namespace ScrablerConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ScrablerService.ScrablerService));
            host.Open();
            Console.WriteLine(host.State.ToString() + "\n" + host.BaseAddresses[0].ToString());
            Console.ReadLine();
            host.Close();
        }
    }
}
