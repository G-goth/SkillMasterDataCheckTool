namespace SkillMasterDataCheckTool
{
    public sealed class SingletonClass
    {
        private static SingletonClass _singleInstance = new SingletonClass();
        public static SingletonClass GetInstance()
        {
            return _singleInstance;
        }
        private SingletonClass()
        {
        }
    }
}