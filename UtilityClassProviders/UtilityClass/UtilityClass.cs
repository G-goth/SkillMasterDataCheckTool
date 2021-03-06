using System;
using System.Linq;
using System.Collections.Generic;

namespace SkillMasterDataCheckTool.UtilityClassProviders
{
    public class UtilityClass
    {
        private static readonly int TEN = 10;
        private bool ArgumentZeroCheck(int num, int dPointPosition)
        {
            // 数値の桁数よりも四捨五入する位置が大きかったらfalseを返す
            if(((int)Math.Log10(num) + 1) <= dPointPosition) return false;
            // いずれかの引数に0が入っていればfalseを返す
            if(num <= 0 | dPointPosition <= 0)  return false;
            // いずれもマッチしなかったらtrue
            return true;
        }
        protected int AdvancedRoundINT(int num, int dPointPosition)
        {
            if(ArgumentZeroCheck(num, dPointPosition) == false) return 0;
            else
            {
                return (int)(Math.Round(num / Math.Pow(TEN, dPointPosition)) * Math.Pow(TEN, dPointPosition));
            }
        }
        protected List<int> GenerateSerialNumber(int startNum, int endNum)
        {
            return Enumerable.Repeat(++startNum, endNum).ToList();
        }
    }
}