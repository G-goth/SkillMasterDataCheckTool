using System;
using System.Collections.Generic;

class MainClass
{
    static void Main(string[] args)
    {
        IOCSV io = new IOCSV();
        IOFileName iof = new IOFileName();
        IOExcelFiles ioe = new IOExcelFiles();

        List<string> fileFullPath = new List<string>();
        fileFullPath.AddRange(iof.GetSpecifiedExtensionFileFullPath("xlsx"));

        List<string[,]> XLDataList = new List<string[,]>();
        for(int sheetCount = 1; sheetCount <= fileFullPath.Count; ++sheetCount)
        {
            XLDataList.Add(ioe.ExtractionExcelData(sheetCount, ioe.GetExcelObject(fileFullPath[sheetCount -1])));
        }
    }
}