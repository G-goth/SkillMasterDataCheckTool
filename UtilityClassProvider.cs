using System;
using System.Collections.Generic;
using SkillMasterDataCheckTool;

namespace UtilityClassProviders
{
    public class UtilityClassProvider : IUtilityClassProvider
    {
        public void ITestMethod()
        {
            Console.WriteLine("Called!!");
        }
        public bool GetArgumentZeroCheck(int num, int dPointPosition)
        {
            return UtilityClass.ArgumentZeroCheck(num, dPointPosition);
        }
        public int GetAdvancedRoundINT(int num, int dPointPosition)
        {
            return UtilityClass.AdvancedRoundINT(num, dPointPosition);
        }
        public List<int> GetGenerateSerialNumber(int startNum, int endNum)
        {
            return UtilityClass.GenerateSerialNumber(startNum, endNum);
        }
    }
}