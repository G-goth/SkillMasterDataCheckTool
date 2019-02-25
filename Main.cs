using System;
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
        Console.WriteLine(iof.GetSpecifiedExtensionFileNameToList(fileFullPath)[0]);
        
        // Excelファイルの最大シート数を取得
        int maxSheetNumber = ioe.GetExcelSheetNumberMax(fileFullPath[0]);
        // Excelファイルのシート数を連番で取得
        List<int> serialNumber = new List<int>(ioe.GetExcelSheetNumberList(fileFullPath[0]));

        List<XLWorkbook> workBookList = new List<XLWorkbook>();
        List<string[,]> XLDataList = new List<string[,]>();
        for(int xlFileCount = 1; xlFileCount <= fileFullPath.Count; ++xlFileCount)
        {
            XLDataList.Add(ioe.ExtractionExcelData(xlFileCount, ioe.GetExcelObject(fileFullPath[xlFileCount -1])));
        }
    }
}