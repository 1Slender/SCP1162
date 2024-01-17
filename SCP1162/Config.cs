using Exiled.API.Interfaces;

namespace SCP1162
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}
