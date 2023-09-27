using G_Pigmy.App.DataControl.Interfaces;

namespace G_Pigmy.App.DataControl.Implementations
{
    public class Utility : IUtility
    {
        public string CreatePartitionKey(string key, string value)
        {
            return key + ":" + value;
        }
    }
}
