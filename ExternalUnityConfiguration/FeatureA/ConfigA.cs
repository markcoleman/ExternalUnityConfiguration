namespace ExternalUnityConfiguration.FeatureA
{
    public class ConfigA : IConfigA
    {
        public ConfigA()
        {
            Name = "IAmConfigA";
        }

        public string Name { get; private set; }
    }
}