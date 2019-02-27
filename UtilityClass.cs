using System;
using System.Linq;
using System.Collections.Generic;

public static class UtilityClass
{
    static readonly int TEN = 10;
    public static List<int> GenerateSerialNumber(int startNum, int endNum)
    {
        return Enumerable.Repeat(++startNum, endNum).ToList();
    }

    public static int AdvancedRoundINT(int num, int dPointPosition)
    {
        // 数値の桁数よりも四捨五入する位置が大きかったら0を返す
        if(((int)Math.Log10(num) + 1) <= dPointPosition) return 0;
        // いずれかの引数に0が入っていれば0を返す
        if(num <= 0 | dPointPosition <= 0)  return 0;
        // そうでなければ整数の指定桁数四捨五入の結果を返す
        else
        {
            var pan = Math.Round(num / Math.Pow(TEN, dPointPosition)) * Math.Pow(TEN, dPointPosition);
            return (int)pan;
        }
    }
}