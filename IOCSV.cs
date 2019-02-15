using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class IOCSV
{
    /// <summary>
    /// CSVファイルの読み込み
    /// </summary>
    /// <param name="fileName">CSVファイルの名前</param>
    public void ReadCSV(string fileName)
    {
        List<string[]> values = new List<string[]>();
        try
        {
            using(var sr = new StreamReader(@""+fileName + ".csv", System.Text.Encoding.UTF8))
            {
                ExtractionCSV(sr);
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
        }
    }
    private List<string[]> ExtractionCSV(StreamReader sr)
    {
        string line;
        List<string[]> values = new List<string[]>();
        while(!sr.EndOfStream)
        {
            line = sr.ReadLine();
            values.Add(line.Split(','));
        }
        Console.WriteLine(values[0][0]);
        foreach(var value in values)
        {
            Action<string[]> act1 = (str) =>
            {
                for(int i = 0; i < 2; ++i)
                {
                    Console.Write(str[i] + ",");
                }
                Console.WriteLine();
            };
            act1(value);
        }
        return values;
    }
}