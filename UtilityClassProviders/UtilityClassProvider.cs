using System;
using System.Collections.Generic;
using SkillMasterDataCheckTool.UtilityClassProviders;

namespace SkillMasterDataCheckTool.UtilityClassProviders
{
    public class UtilityClassProvider : UtilityClass, IUtilityClassProvider
    {
        public void ITestMethod()
        {
            Console.WriteLine("Called!!");
        }
        public int GetAdvancedRoundINT(int num, int dPointPosition)
        {
            return AdvancedRoundINT(num, dPointPosition);
        }
        public List<int> GetGenerateSerialNumber(int startNum, int endNum)
        {
            return GenerateSerialNumber(startNum, endNum);
        }
    }
}