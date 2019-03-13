using System.Collections.Generic;
using ClosedXML.Excel;
namespace SkillMasterDataCheckTool
{
    interface IIOExcelFiles
    {
        List<int> GetExcelSheetNumberList(string fileName);
        int GetExcelSheetNumberMax(string fileName);
        string[][] ExtractionExcelData(int sheetNumber, XLWorkbook workBook);
        XLWorkbook GetExcelObject(string fileName);
    }
}