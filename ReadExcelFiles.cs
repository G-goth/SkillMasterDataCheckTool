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
            List<string> stageID = new List<string>();
            List<string> totalEnemies = new List<string>();

            // A列とB列のデータを取得
            for(int i = 2; i <= row1; ++i)
            {
                stageID.Add(worksheet1.Cell(i,1).Value.ToString());
            }
            for(int i = 2; i <= row1; ++i)
            {
                totalEnemies.Add(worksheet1.Cell(i,2).Value.ToString());
            }
            // ここにロジック
            Console.WriteLine("Done!!");
        }
    }
}