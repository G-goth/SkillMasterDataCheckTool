﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;

class MainClass
{
    static void Main(string[] args)
    {
        // LINQ Test
        List<string> sf3 = new List<string>(){"1st", "2nd", "3rd"};
        string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };
        var query = fruits.Select((fruit, index) => new { index, str = fruit.Substring(0, index) });
        var sfQuery = sf3.Select(title => "sf3 " + title);
        Console.WriteLine(Enumerable.Repeat(sf3, sf3.Count));

        IOCSV io = new IOCSV();
        IOFileName iof = new IOFileName();
        IOExcelFiles ioe = new IOExcelFiles();

        // ファイルのフルパスの取得
        List<string> fileFullPath = new List<string>();
        fileFullPath.AddRange(iof.GetSpecifiedExtensionFileFullPath("xlsx"));
        // ファイル名の取得
        foreach(var fileName in iof.GetSpecifiedExtensionFileNameToList(fileFullPath))
        {
            Console.WriteLine(fileName);
        }

        List<XLWorkbook> workBookList = new List<XLWorkbook>();
        List<string[,]> XLDataList = new List<string[,]>();
        for(int xlFileCount = 1; xlFileCount <= fileFullPath.Count; ++xlFileCount)
        {
            XLDataList.Add(ioe.ExtractionExcelData(xlFileCount, ioe.GetExcelObject(fileFullPath[xlFileCount -1])));
        }
    }
}