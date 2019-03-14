using System;
using System.Collections.Generic;
using SkillMasterDataCheckTool.UtilityClassProviders.UtilityClass;

namespace SkillMasterDataCheckTool.UtilityClassProviders
{
    public class UtilityClassProvider : IUtilityClassProvider
    {
        public void ITestMethod()
        {
            Console.WriteLine("Called!!");
        }
        public int GetAdvancedRoundINT(int num, int dPointPosition)
        {
            return UtilityClass.UtilityClass.AdvancedRoundINT(num, dPointPosition);
        }
        public List<int> GetGenerateSerialNumber(int startNum, int endNum)
        {
            return UtilityClass.UtilityClass.GenerateSerialNumber(startNum, endNum);
        }
    }
}