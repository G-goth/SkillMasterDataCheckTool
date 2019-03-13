using SkillMasterDataCheckTool;

namespace SkillMasterDataCheckTool.UtilityClassProviders
{
    public class UtilityClassProvider : IUtilityClassProvider
    {
        private UtilityClass utility = new UtilityClass();
        public bool GetArgumentZeroCheck(int num, int dPointPosition)
        {
            return utility.ArgumentZeroCheck(num, dPointPosition);
        }
    }
}