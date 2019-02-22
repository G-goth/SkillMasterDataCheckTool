using System;
using System.Linq;
using System.Collections.Generic;
using ClosedXML.Excel;

interface IIOExcelFiles
{
    List<int> GetExcelSheetNumberList(string fileName);
    int GetExcelSheetNumberMax(string fileName);
    string[,] ExtractionExcelData(int sheetNumber, XLWorkbook workBook);
    // ClosedXML
    XLWorkbook GetExcelObject(string fileName);
}

class IOExcelFiles : IIOExcelFiles
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

    /// <summary>
    /// 取得したExcelファイルの最大シート数
    /// </summary>
    /// <param name="fileName">Excelファイル名</param>
    /// <returns>最大シート数</returns>
    public int GetExcelSheetNumberMax(string fileName)
    {
        try
        {
            using(var workBook = new XLWorkbook(@"" + fileName))
            {
                return workBook.Worksheets.Count;
            }
        }
        catch(System.Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }

    /// <summary>
    /// 取得したExcelファイルのシート数を連番でListに登録して返す
    /// </summary>
    /// <param name="fileName">Excelファイル名</param>
    /// <returns>連番の入ったList</returns>
    public List<int> GetExcelSheetNumberList(string fileName)
    {
        List<int> serialNumber = new List<int>();
        int workSheetNumber;
        using(var workBook = new XLWorkbook(@"" + fileName))
        {
            try
            {
                workSheetNumber = workBook.Worksheets.Count;
                serialNumber.AddRange(Enumerable.Repeat(1, workSheetNumber).ToList());
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e);
                return serialNumber;
            }
        }
        return serialNumber;
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