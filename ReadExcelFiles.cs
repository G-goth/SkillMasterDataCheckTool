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
            for(int i = 2; i <= row1; ++i)
            {
                stageIDs.Add(worksheet1.Cell(i,1).Value.ToString());
            }
            for(int i = 2; i <= row1; ++i)
            {
                stageIDs.Add(worksheet1.Cell(i,2).Value.ToString());
            }
            for(int i = 2; i <= row1; ++i)
            {
                totalEnemies.Add(worksheet1.Cell(i,3).Value.ToString());
            }

            // ここにロジック
            var stageID = Enumerable.Repeat(worksheet1.Cell(2, 1).Value.ToString(), int.Parse(worksheet1.Cell(2, 3).Value.ToString())).ToList();
            // Console.WriteLine(double.Parse(worksheet1.Cell(2, 3).Value.ToString()) / double.Parse(worksheet1.Cell(2, 2).Value.ToString()));
            for(int i = 2; i <= int.Parse(worksheet1.Cell(i, 3).Value.ToString()); ++i)
            {
                if(double.Parse(worksheet1.Cell(i, 3).Value.ToString()) / double.Parse(worksheet1.Cell(i, 2).Value.ToString()) >= i)
                {
                    for(int i_i = 2; i_i < int.Parse(worksheet1.Cell(i, 3).Value.ToString()) / 2; ++i_i)
                    {
                        Console.WriteLine(worksheet1.Cell(i, 1).Value + " : " + 1);
                    }
                }
                else if(int.Parse(worksheet1.Cell(2, 2).Value.ToString()) == 1) return;

                if(double.Parse(worksheet1.Cell(i, 3).Value.ToString()) / double.Parse(worksheet1.Cell(i, 2).Value.ToString()) <= i)
                {
                    for(int i_i = i; i_i <= int.Parse(worksheet1.Cell(i, 3).Value.ToString()); ++i_i)
                    {
                        Console.WriteLine(worksheet1.Cell(i, 1).Value + " : " + 2);
                    }
                }
            }
            Console.WriteLine("Done!!");
        }
    }
}