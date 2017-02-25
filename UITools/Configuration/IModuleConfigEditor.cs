namespace WinFwk.UITools.Configuration
{
    public interface IModuleConfigEditor
    {
        void Init(IModuleConfig moduleConfig);
        void Apply();
    }
}