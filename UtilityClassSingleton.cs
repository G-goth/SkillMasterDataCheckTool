namespace SkillMasterDataCheckTool
{
    public sealed class UtilityClassSingleton
    {
        private static UtilityClassSingleton _singleton = new UtilityClassSingleton();
        public static UtilityClassSingleton Instance
        {
            get{ return _singleton; }
        }
        private UtilityClassSingleton()
        {
        }
    }
}