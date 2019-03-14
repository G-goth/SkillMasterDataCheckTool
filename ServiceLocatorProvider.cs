using UtilityClassProviders;

namespace SkillMasterDataCheckTool
{
    public sealed class ServiceLocatorProvider
    {
        private static ServiceLocatorProvider _singleton = new ServiceLocatorProvider();
        public static ServiceLocatorProvider GetInstance()
        {
            return _singleton;
        }
        private ServiceLocatorProvider()
        {}
        
        public ServiceLocator Current { get; private set; }
        private void RegisterDependency()
        {
            Current = new ServiceLocator();
            // 依存関係を登録
            Current.Register<IUtilityClassProvider>(new UtilityClassProvider());
        }
    }
}