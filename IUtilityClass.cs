using System.Collections.Generic;

namespace SkillMasterDataCheckTool
{
    interface IUtilityClassProvider
    {
        void ITestMethod();
        bool GetArgumentZeroCheck(int num, int dPointPosition);
        int GetAdvancedRoundINT(int num, int dPointPosition);
        // List<int> GenerateSerialNumber(int startNum, int endNum);
    }
}