using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace GlareBattleTestSupportTool
{
    class IOExcelFiles
    {
        public XLWorkbook GetExcelObject(string fileName)
        {
            using(var workbook = new XLWorkbook(@"" + fileName + ".xlsx"))
            {
                return workbook;
            }
        }
    }
}