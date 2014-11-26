namespace ExternalUnityConfiguration.FeatureB
{
    public class ConfigB : IConfigB
    {
        public ConfigB()
        {
            Name = "IAmConfigB";
        }

        public string Name { get; private set; }
    }
}