using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System;
using ClosedXML.Excel;

namespace SkillMasterDataCheckTool
{
    public class ReadExcelFiles
    {
        public void GenerateStageAndWave(XLWorkbook workbook)
        {
            var worksheet1 = workbook.Worksheet(1);
            var worksheet2 = workbook.Worksheet(2);
            int row1 = worksheet1.LastRowUsed().RowNumber();
            List<string> stageIDs = new List<string>();
            List<string> stageWave = new List<string>();
            List<string> totalEnemies = new List<string>();

            // A列とB列のデータを取得
            stageIDs = Enumerable.Range(1, row1).Select(index => worksheet1.Cell(index, 1).Value.ToString()).ToList();
            stageWave = Enumerable.Range(1, row1).Select(index => worksheet1.Cell(index, 2).Value.ToString()).ToList();
            totalEnemies = Enumerable.Range(1, row1).Select(index => worksheet1.Cell(index, 3).Value.ToString()).ToList();

            // ここにロジック
            foreach(var ids in stageIDs)
            {
                Console.WriteLine(ids);
            }
            Console.WriteLine("Done!!");
        }
    }
}