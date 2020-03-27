using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace GenericService
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive && (args.Count() == 0))
            {
                Console.WriteLine("Это сервис");
                return;
            }

            string name = Assembly.GetEntryAssembly().Location;

            string arg1 = args.Count() > 0 ? args[0] : "";
            arg1.ToLower();

            switch (arg1)
            {
                case "install":
                    ManagedInstallerClass.InstallHelper(new string[] {name});
                    break;
                case "delete":
                    //ManagedInstallerClass.InstallHelper(new string[] {name });
                    break;
                case "remove":
                    break;
                case "uninstall":
                    break;
                default:
                    Service svc = new Service();
                    ServiceBase.Run(svc);
                    break;
            }

            
        }
    }
}
