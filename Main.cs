using System;
using System.Collections.Generic;

namespace GlareBattleTestSupportTool
{
    class MainClass
    {
        static void Main(string[] args)
        {
            IOCSV io = new IOCSV();
            IOFileName iof = new IOFileName();
            IOExcelFiles ioe = new IOExcelFiles();

            List<string> fileFullPath = new List<string>();
            fileFullPath.AddRange(iof.GetSpecifiedExtensionFileFullPath("xlsx"));
            foreach(var item in fileFullPath)
            {
                ioe.ExtractionExcelData(1, ioe.GetExcelObject(item));
            }
        }
    }
}