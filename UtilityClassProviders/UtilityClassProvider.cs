using System;
using System.Collections.Generic;
using SkillMasterDataCheckTool.UtilityClassProviders;

namespace SkillMasterDataCheckTool.UtilityClassProviders
{
    public class UtilityClassProvider : UtilityClass, IUtilityClassProvider
    {
        private UtilityClassProvider utilityProvider = new UtilityClassProvider();
        public void ITestMethod()
        {
            Console.WriteLine("Called!!");
        }
        public int GetAdvancedRoundINT(int num, int dPointPosition)
        {
            return utilityProvider.AdvancedRoundINT(num, dPointPosition);
        }
        public List<int> GetGenerateSerialNumber(int startNum, int endNum)
        {
            return utilityProvider.GenerateSerialNumber(startNum, endNum);
        }
    }
}