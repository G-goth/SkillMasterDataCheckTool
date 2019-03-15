using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using SkillMasterDataCheckTool.UtilityClassProviders;
using SkillMasterDataCheckTool.IOFiles.IOExcel;
using SkillMasterDataCheckTool.IOFiles.IOCSV;
using SkillMasterDataCheckTool.IOFileNames;

namespace SkillMasterDataCheckTool
{
    class MainClass
    {
        private static IUtilityClassProvider utilityProvider;
        public static void SetUtilityClassProvider(IUtilityClassProvider utility)
        {
            utilityProvider = utility;
        }
        static void Main(string[] args)
        {
            // 疎結合をやってみるテスト
            utilityProvider = ServiceLocatorProvider.GetInstance.Current.Resolve<IUtilityClassProvider>();
            utilityProvider.ITestMethod();

            // ファイルのフルパスの取得
            IOFileName iof = new IOFileName();
            List<string> fileFullPath = new List<string>();
            fileFullPath.AddRange(iof.GetSpecifiedExtensionFileFullPath("xlsx"));
            // Console.WriteLine(iof.GetSpecifiedExtensionFileNameToList(fileFullPath)[0]);
            
            // Excelファイルの最大シート数を取得
            IOExcelFiles ioe = new IOExcelFiles();
            int maxSheetNumber = ioe.GetExcelSheetNumberMax(fileFullPath[0]);
            // Excelファイルのシート数を連番で取得
            List<int> serialNumber = new List<int>(ioe.GetExcelSheetNumberList(fileFullPath[0]));

            List<XLWorkbook> workBookList = new List<XLWorkbook>();
            List<string[][]> XLDataList = new List<string[][]>();
            for(int xlFileCount = 1; xlFileCount <= fileFullPath.Count; ++xlFileCount)
            {
                XLDataList.Add(ioe.ExtractionExcelData(xlFileCount, ioe.GetExcelObject(fileFullPath[xlFileCount -1])));
            }
        }
    }
}