using ExternalUnityConfiguration.FeatureA;
using ExternalUnityConfiguration.FeatureB;
using ExternalUnityConfiguration.FeatureC;

namespace ExternalUnityConfiguration
{
    public class ServiceService : IServiceService
    {
        private readonly IConfigA _configA;
        private readonly IConfigB _configB;
        private readonly IConfigC _configC;

        public ServiceService(IConfigA configA, IConfigB configB, IConfigC configC)
        {
            _configA = configA;
            _configB = configB;
            _configC = configC;
        }

        public string GetName()
        {
            return "ConfigA: " + _configA.Name + " ConfigB: " + _configB.Name + " ConfigC: " + _configC.Name;
        }
    }
}