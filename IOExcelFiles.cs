using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace GlareBattleTestSupportTool
{
    class IOExcelFiles
    {
        public int ExcelWorkSheetNumberProp{ set; get; }
        public XLWorkbook ExcelWorkBookProp{ set; get; }

        private int GetUsedCellRowCount(int sheetNumber, XLWorkbook workBook)
        {
            var workSheet = workBook.Worksheet(sheetNumber);
            // var workSheet = ExcelWorkBookProp.Worksheet(ExcelWorkSheetNumberProp);
            return workSheet.LastColumnUsed().ColumnNumber();
        }
        private int GetUsedCellColumnCount(int sheetNumber, XLWorkbook workBook)
        {
            var workSheet = workBook.Worksheet(sheetNumber);
            // var workSheet = ExcelWorkBookProp.Worksheet(ExcelWorkSheetNumberProp);
            return workSheet.LastRowUsed().RowNumber();
        }
        private int GetExcelSheetNumber(string fileName)
        {
            int workSheetNumber;
            using(var workBook = new XLWorkbook(@"" + fileName))
            {
                try
                {
                    workSheetNumber = workBook.Worksheets.Count;
                }
                catch
                {
                    return 0;
                }
            }
            return workSheetNumber;
        }

        public XLWorkbook GetExcelObject(string fileName)
        {
            using(var workBook = new XLWorkbook(@"" + fileName))
            {
                try
                {
                    return workBook;
                }
                catch(System.Exception e)
                {
                    Console.WriteLine(e);
                    return workBook;
                }
            }
        }
        // public (int sheetNumber, XLWorkbook workBook) GetXLWorkBookTupleObject(string fileName)
        // {
        //     using(var workBook = new XLWorkbook(@"" + fileName))
        //     {
        //         try
        //         {
        //             return;
        //         }
        //         catch(System.Exception e)
        //         {
        //             Console.WriteLine(e);
        //             return
        //         }
        //     }
        // }

        public List<string> ExtractionExcelData(int sheetNumber, XLWorkbook workBook)
        {
            (int x, int y) xlCellAddress;
            var workSheet = workBook.Worksheet(sheetNumber);
            xlCellAddress.x = workSheet.LastColumnUsed().ColumnNumber();
            xlCellAddress.y = workSheet.LastRowUsed().RowNumber();

            var columnCount = workSheet.LastColumnUsed().ColumnNumber();
            var rowCount = workSheet.LastRowUsed().RowNumber();
            string[,] excelRowStr = new string[rowCount, columnCount];
            List<string> excelCellData = new List<string>();

            for(int row = 0; row < rowCount; ++row)
            {
                for(int column = 0; column < columnCount; ++column)
                {
                    excelRowStr[row,column] = workSheet.Cell(row + 1, column + 1).Value.ToString();
                    //Console.WriteLine("dataList[{0}, {1}] : {2}", row, column, excelRowStr[row, column]);
                }
                //Console.WriteLine();
            }
            workBook.Dispose();
            return excelCellData;
        }
    }
}