using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("https://127.0.0.1:9293/Countries");
            using (ServiceHost host = new ServiceHost(typeof(CountryService), baseAddress))
            {
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                behavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(behavior);

                host.Open();

                Console.WriteLine("CountryService is running, press Q to quit");
                while(true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Q) break;
                }
                host.Close();
            }
        }
    }
}
