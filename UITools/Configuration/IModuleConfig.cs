using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace WinFwk.UITools.Configuration
{
    public interface IModuleConfig : ICloneable
    {
        [Browsable(false)]
        [XmlIgnore]
        IConfigurableModule OwnerModule { get; }
    }
}
