namespace ExternalUnityConfiguration.FeatureC
{
    public class ConfigC : IConfigC
    {
        public ConfigC()
        {
            Name = "IAmConfigC";
        }

        public string Name { get; private set; }
    }
}