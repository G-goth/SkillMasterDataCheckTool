using UtilityClassProviders;

namespace SkillMasterDataCheckTool
{
    public sealed class ServiceLocatorProvider
    {
        private static ServiceLocatorProvider _singleton = new ServiceLocatorProvider();
        public ServiceLocator Current { get; private set; }
        public static ServiceLocatorProvider GetInstance
        {
            get{ return _singleton; }
        }
        private ServiceLocatorProvider()
        {
            Current = new ServiceLocator();
            // 依存関係を登録
            Current.Register<IUtilityClassProvider>(new UtilityClassProvider());
        }
    }
}