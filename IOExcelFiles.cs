using System;
using System.Linq;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace GlareBattleTestSupportTool
{
    class IOExcelFiles
    {
        private int GetUsedCellRowCount(int sheetNumber, XLWorkbook workBook)
        {
            var workSheet = workBook.Worksheet(sheetNumber);
            return workSheet.LastColumnUsed().ColumnNumber();
        }
        private int GetUsedCellColumnCount(int sheetNumber, XLWorkbook workBook)
        {
            var workSheet = workBook.Worksheet(sheetNumber);
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

        public string[,] ExtractionExcelData(int sheetNumber, XLWorkbook workBook)
        {
            var workSheet = workBook.Worksheet(sheetNumber);
            (int column, int row) xlCellAddress;
            xlCellAddress.column = workSheet.LastColumnUsed().ColumnNumber();
            xlCellAddress.row = workSheet.LastRowUsed().RowNumber();
            string[,] excelRowStr = new string[xlCellAddress.row, xlCellAddress.column];

            for(int row = 0; row < xlCellAddress.row; ++row)
            {
                for(int column = 0; column < xlCellAddress.column; ++column)
                {
                    excelRowStr[row,column] = workSheet.Cell(row + 1, column + 1).Value.ToString();
                    //Console.WriteLine("dataList[{0}, {1}] : {2}", row, column, excelRowStr[row, column]);
                }
                //Console.WriteLine();
            }
            workBook.Dispose();
            return excelRowStr;
        }
    }
}