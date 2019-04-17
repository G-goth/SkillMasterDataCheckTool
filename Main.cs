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
            // ファイルのフルパスの取得
            List<string> fileFullPath = new List<string>();
            ioFileNamesProvider = ServiceLocatorProvider.GetInstance.ioFileNameCurrent.Resolve<IIOFileNamesProvider>();
            fileFullPath.AddRange(ioFileNamesProvider.GetSpecifiedExtensionFileFullPath("xlsx"));
            // ファイル名のみを取得
            List<string> fileNameList = new List<string>();
            foreach(var name in fileFullPath)
            {
                fileNameList.Add(ioFileNamesProvider.GetSpecifiedExtensionFileName(name));
            }

            // ExcelファイルにステージIDとウェーブ数を書き込む
            ioExcelFilesProvider = ServiceLocatorProvider.GetInstance.ioExcelFileCurrent.Resolve<IIOExcelFilesProvider>();
            var looping = true;
            int keyValue = 0;
            int fileCount = 0;
            List<int> fileCountList = new List<int>();
            while(looping)
            {
                try
                {
                    foreach(var name in fileNameList)
                    {
                        fileCountList.Add(++fileCount);
                        Console.WriteLine(fileCount + " : " + name);
                    }
                    Console.WriteLine("いずれかのファイルを数字で選んでください(数字を選んでエンターキーを押す)");
                    keyValue = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("数字以外が押されました");
                    fileCount = 0;
                    continue;
                }
            }
            Console.WriteLine("現在生成中・・・");
            ReadExcelFiles readexcel = new ReadExcelFiles();
            var sheet = ioExcelFilesProvider.GetExcelObject(fileNameList[keyValue - 1]);
            readexcel.GenerateStageAndWave(sheet, fileNameList[keyValue - 1]);
            Console.WriteLine("なにかキーを押して終了・・・");
            Console.ReadKey();
        }
    }
}