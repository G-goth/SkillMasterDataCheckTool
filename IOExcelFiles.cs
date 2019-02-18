using System;
using System.Linq;
using System.Collections.Generic;
using ClosedXML.Excel;

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

    public int GetExcelSheetNumber(string fileName)
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

    /// <summary>
    /// ClosedXMLでExcelワークブックを取得する
    /// </summary>
    /// <param name="fileName">ファイル名(拡張子まで)</param>
    /// <returns>XLWorkbook型変数</returns>
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

    private string[,] GetExcelUsedTwoDimensionsArray(int sheetNumber, XLWorkbook workBook)
    {
        var workSheet = workBook.Worksheet(sheetNumber);
        (int column, int row) xlCellAddress;
        xlCellAddress.column = workSheet.LastColumnUsed().ColumnNumber();
        xlCellAddress.row = workSheet.LastRowUsed().RowNumber();
        string[,] xlUsedSheetAddress = new string[xlCellAddress.row, xlCellAddress.column];

        return xlUsedSheetAddress;
    }

    /// <summary>
    /// Excelのデータをセルごとに読み込んで2次元配列に代入する
    /// </summary>
    /// <param name="workBook">XLWorkbook変数</param>
    /// <returns>使用しているExcelのセルのデータをstringの2次元配列で返す</returns>
    public string[,] ExtractionExcelData(int sheetNumber, XLWorkbook workBook)
    {
        var workSheet = workBook.Worksheet(sheetNumber);
        string[,] xlRowStrArray = GetExcelUsedTwoDimensionsArray(1, workBook);

        for(int row = 0; row < xlRowStrArray.GetLength(0); ++row)
        {
            for(int column = 0; column < xlRowStrArray.GetLength(1); ++column)
            {
                xlRowStrArray[row,column] = workSheet.Cell(row + 1, column + 1).Value.ToString();
                // Console.WriteLine("dataList[{0}, {1}] : {2}", row, column, xlRowStrArray[row, column]);
            }
            // Console.WriteLine();
        }
        workBook.Dispose();
        return xlRowStrArray;
    }
}