using System;
using System.Collections.Generic;
using SkillMasterDataCheckTool.UtilityClassProviders;
using SkillMasterDataCheckTool.IIOFilesProviders;

namespace SkillMasterDataCheckTool
{
    class MainClass
    {
        private static IUtilityClassProvider utilityProvider;
        private static IIOFileNamesProvider ioFileNamesProvider;
        private static IIOExcelFilesProvider ioExcelFilesProvider;
        public static void SetUtilityClassProvider(IUtilityClassProvider utility)
        {
            utilityProvider = utility;
        }
        static void Main(string[] args)
        {
            
            // UtilityClassで疎結合をやってみるテスト
            utilityProvider = ServiceLocatorProvider.GetInstance.utilityCurrent.Resolve<IUtilityClassProvider>();
            utilityProvider.ITestMethod();

            // ファイルのフルパスの取得
            List<string> fileFullPath = new List<string>();
            ioFileNamesProvider = ServiceLocatorProvider.GetInstance.ioFileNameCurrent.Resolve<IIOFileNamesProvider>();
            fileFullPath.AddRange(ioFileNamesProvider.GetSpecifiedExtensionFileFullPath("xlsx"));
            // Console.WriteLine(ioFileNamesProvider.GetSpecifiedExtensionFileNameToList(fileFullPath)[0]);
            
            // Excelファイルの最大シート数を取得
            ioExcelFilesProvider = ServiceLocatorProvider.GetInstance.ioExcelFileCurrent.Resolve<IIOExcelFilesProvider>();
            int maxSheetNumber = ioExcelFilesProvider.GetExcelSheetNumberMax(fileFullPath[0]);
            // Excelファイルのシート数を連番で取得
            List<int> serialNumber = new List<int>(ioExcelFilesProvider.GetExcelSheetNumberList(fileFullPath[0]));            

            // List<XLWorkbook> workBookList = new List<XLWorkbook>();
            // List<string[][]> XLDataList = new List<string[][]>();
            // for(int xlFileCount = 1; xlFileCount <= fileFullPath.Count; ++xlFileCount)
            // {
            //     XLDataList.Add(ioe.ExtractionExcelData(xlFileCount, ioe.GetExcelObject(fileFullPath[xlFileCount -1])));
            // }

            // ExcelファイルにステージIDとウェーブ数を書き込む
            ReadExcelFiles readexcel = new ReadExcelFiles();
            var sheet = ioExcelFilesProvider.GetExcelObject("test2.xlsx");
            readexcel.GenerateStageAndWave(sheet);
        }
    }
}