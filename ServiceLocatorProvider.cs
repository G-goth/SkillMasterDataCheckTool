using UtilityClassProviders;

namespace SkillMasterDataCheckTool
{
    public sealed class ServiceLocatorProvider
    {
        public ServiceLocator Current { get; private set; }

        private void RegisterDependency()
        {
            Current = new ServiceLocator();
            // 依存関係を登録
            Current.Register<IUtilityClassProvider>(new UtilityClassProvider());
        }
    }
}