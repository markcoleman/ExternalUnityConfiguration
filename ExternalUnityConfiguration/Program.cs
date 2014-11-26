using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using ExternalUnityConfiguration.FeatureA;
using ExternalUnityConfiguration.FeatureB;
using ExternalUnityConfiguration.FeatureC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;


namespace ExternalUnityConfiguration
{
    internal class Program
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private static void Main(string[] args)
        {
            string unityAPath = Path.Combine(AssemblyDirectory, "UnitySectionA.config");
            IUnityContainer container = new UnityContainer();


            var unityAFileMap = new ExeConfigurationFileMap {ExeConfigFilename = unityAPath};
            Configuration unityAConfiguration = ConfigurationManager.OpenMappedExeConfiguration(unityAFileMap, ConfigurationUserLevel.None);
            var unityASection = (UnityConfigurationSection) unityAConfiguration.GetSection("unity");

            container.LoadConfiguration(unityASection);
            var configA = container.Resolve<IConfigA>();
            Console.WriteLine(configA.Name);


            string unityBPath = Path.Combine(AssemblyDirectory, "UnitySectionB.config");
            var unityBFileMap = new ExeConfigurationFileMap {ExeConfigFilename = unityBPath};
            Configuration unityBConfiguration = ConfigurationManager.OpenMappedExeConfiguration(unityBFileMap, ConfigurationUserLevel.None);
            var unityBSection = (UnityConfigurationSection) unityBConfiguration.GetSection("unity");

            container.LoadConfiguration(unityBSection);
            var configB = container.Resolve<IConfigB>();
            Console.WriteLine(configB.Name);


            container.LoadConfiguration();
            var configC = container.Resolve<IConfigC>();
            Console.WriteLine(configC.Name);


            container.RegisterType<IServiceService, ServiceService>();

            var service = container.Resolve<IServiceService>();
            Console.WriteLine(service.GetName());

            Console.ReadKey();
        }
    }
}