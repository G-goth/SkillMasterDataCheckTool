using System;
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
    }
}