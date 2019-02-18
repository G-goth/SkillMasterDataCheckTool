﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;

class MainClass
{
    static void Main(string[] args)
    {
        IOCSV io = new IOCSV();
        IOFileName iof = new IOFileName();
        IOExcelFiles ioe = new IOExcelFiles();

        // ファイルのフルパスの取得
        List<string> fileFullPath = new List<string>();
        fileFullPath.AddRange(iof.GetSpecifiedExtensionFileFullPath("xlsx"));
        Console.WriteLine(iof.GetSpecifiedExtensionFileName(fileFullPath[0]));
        // LINQ Test
        // ファイル名の取得
        List<string> fileNameList = new List<string>();
        fileNameList.AddRange(iof.GetSpecifiedExtensionFileNameToList(fileFullPath));
        foreach(var item in fileNameList)
        {
            Console.WriteLine(item);
        }
        // foreach(var fileName in fileFullPath)
        // {
        //     fileNameList.Add(iof.GetSpecifiedExtensionFileName(fileName));
        // }

        List<XLWorkbook> workBookList = new List<XLWorkbook>();
        List<string[,]> XLDataList = new List<string[,]>();
        for(int xlFileCount = 1; xlFileCount <= fileFullPath.Count; ++xlFileCount)
        {
            XLDataList.Add(ioe.ExtractionExcelData(xlFileCount, ioe.GetExcelObject(fileFullPath[xlFileCount -1])));
        }
    }
}