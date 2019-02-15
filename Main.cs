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

        for(int sheetCount = 1; sheetCount <= fileFullPath.Count; ++sheetCount)
        {
            ioe.ExtractionExcelData(sheetCount, ioe.GetExcelObject(fileFullPath[sheetCount -1]));
        }
        // foreach(var item in fileFullPath)
        // {
        //     ioe.ExtractionExcelData(1, ioe.GetExcelObject(item));
        // }
    }
}