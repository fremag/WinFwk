using System.Collections.Generic;

namespace WinFwk.UITools.Configuration
{
    public interface IModuleConfigEditor
    {
        IModuleConfig ModuleConfig { get; }
        void Init(IModuleConfig moduleConfig);
        IEnumerable<IEditorAction> EditorActions { get; }
    }
}