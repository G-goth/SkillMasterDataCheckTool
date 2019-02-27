using System;
using System.Linq;
using System.Collections.Generic;

public static class UtilityClass
{
    public static List<int> GenerateSerialNumber(int startNum, int endNum)
    {
        return Enumerable.Repeat(++startNum, endNum).ToList();
    }

    public static int AdvancedRoundINT(int num, int decimalPointPosition)
    {
        return 0;
    }
}