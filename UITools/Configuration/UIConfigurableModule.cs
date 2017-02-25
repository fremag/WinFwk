using System;
using WinFwk.UIModules;

namespace WinFwk.UITools.Configuration
{
    public abstract class UIConfigurableModule<T> : UIModule, IConfigurableModule where T : class, IModuleConfig
    {
        public abstract T Config { get; }
        public abstract void Apply(T config);

        public virtual IModuleConfigEditor CreateEditor()
        {
            return new DefaultModuleConfigEditor();
        }

        public IModuleConfig ModuleConfig => Config;

        public void Apply(IModuleConfig config)
        {
            T moduleConfig = config as T;
            Apply(moduleConfig);
        }
    }
}
