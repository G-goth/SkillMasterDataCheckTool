using System;
using System.Linq;
using System.Collections.Generic;

interface IUtilityClass
{
    int AdvancedRoundINT(int num, int dPointPosition);
    List<int> GenerateSerialNumber(int startNum, int endNum);
}
abstract class UtilityBaseClass : IUtilityClass
{
    protected static readonly int TEN = 10;
    protected bool ArgumentZeroCheck(int num, int dPointPosition)
    {
        // 数値の桁数よりも四捨五入する位置が大きかったらfalseを返す
        if(((int)Math.Log10(num) + 1) <= dPointPosition) return false;
        // いずれかの引数に0が入っていればfalseを返す
        if(num <= 0 | dPointPosition <= 0)  return false;
        // いずれもマッチしなかったらtrue
        return true;
    }
    public virtual List<int> GenerateSerialNumber(int startNum, int endNum)
    {
        return Enumerable.Repeat(++startNum, endNum).ToList();
    }
    public virtual int AdvancedRoundINT(int num, int dPointPosition){ return 0; }
}
class UtilityClass : UtilityBaseClass
{
    public override int AdvancedRoundINT(int num, int dPointPosition)
    {
        if(ArgumentZeroCheck(num, dPointPosition) == false) return 0;
        else
        {
            return (int)(Math.Round(num / Math.Pow(TEN, dPointPosition)) * Math.Pow(TEN, dPointPosition));
        }
    }
}