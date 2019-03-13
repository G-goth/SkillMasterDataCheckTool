using System.Collections.Generic;

namespace SkillMasterDataCheckTool
{
    interface IUtilityClassProvider
    {
        bool GetArgumentZeroCheck(int num, int dPointPosition);
        // int AdvancedRoundINT(int num, int dPointPosition);
        // List<int> GenerateSerialNumber(int startNum, int endNum);
    }
}