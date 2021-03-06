using System.Collections.Generic;

namespace SkillMasterDataCheckTool.UtilityClassProviders
{
    interface IUtilityClassProvider
    {
        void ITestMethod();
        int GetAdvancedRoundINT(int num, int dPointPosition);
        List<int> GetGenerateSerialNumber(int startNum, int endNum);
    }
}