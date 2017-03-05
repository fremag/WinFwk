using System.ComponentModel;
using System.Xml.Serialization;

namespace WinFwk.UITools.Configuration
{
    public class ModuleConfigAdapter : IModuleConfig
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
