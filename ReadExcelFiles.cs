using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System;
using ClosedXML.Excel;

namespace SkillMasterDataCheckTool
{
    public class ReadExcelFiles
    {
        public void GenerateStageAndWave(XLWorkbook workbook, string fileName)
        {
            var worksheet1 = workbook.Worksheet(1);
            var worksheet2 = workbook.Worksheet(2);
            int row1 = worksheet1.LastRowUsed().RowNumber() - 1;
            List<int> stageIDs = new List<int>();
            List<int> stageWave = new List<int>();
            List<int> totalEnemies = new List<int>();

            // A列とB列のデータを取得
            stageIDs = Enumerable.Range(2, row1).Select(index => worksheet1.Cell(index, 1).GetValue<int>()).ToList();
            stageWave = Enumerable.Range(2, row1).Select(index => worksheet1.Cell(index, 2).GetValue<int>()).ToList();
            totalEnemies = Enumerable.Range(2, row1).Select(index => worksheet1.Cell(index, 3).GetValue<int>()).ToList();

            // ここにロジック
            List<(int id, int wave)> stageIDsTuple = new List<(int, int)>();
            for(int ids = 0; ids < stageIDs.Count; ++ids)
            {
                var allocationAns = Math.Round((double)stageWave[ids] / (double)totalEnemies[ids] * 10);
                for(int wave = 0; wave < allocationAns; ++wave)
                {
                    for(int allocation = 0; allocation <= allocationAns; ++allocation)
                    {
                        stageIDsTuple.Add((stageIDs[ids], (wave + 1)));
                    }
                }
            }

            // ExcelファイルにステージIDとウェーブ数を書き出す
            for(int i = 0; i < stageIDsTuple.Count; ++i)
            {
                worksheet2.Cell((i+ 1), 1).Value = stageIDsTuple[i].id;
                worksheet2.Cell((i+ 1), 2).Value = stageIDsTuple[i].wave;
            }
            workbook.SaveAs(fileName);
            Console.WriteLine("Done!!");
        }
    }
}