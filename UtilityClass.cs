using System;
using System.Linq;
using System.Collections.Generic;

public static class UtilityClass
{
    public static List<int> GenerateSerialNumber(int startNum, int endNum)
    {
        List<int> serialNumber = new List<int>();
        IEnumerable<int> serial = Enumerable.Repeat(++startNum, endNum);
        serialNumber = serial.ToList();
        return serialNumber;
    }
}