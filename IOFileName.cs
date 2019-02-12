using System;
using System.Linq;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace GlareBattleTestSupportTool
{
    class IOFileName
    {
        /// <summary>
        /// 指定された拡張子のファイルのフルパスを検索して取得する。
        /// </summary>
        /// <param name="fileExtentions">拡張子名(xlsx、docxなど)</param>
        /// <returns>返り値はstringのList なかった場合は空のListが返り値となる</returns>
        public List<string> GetSpecifiedExtensionFileFullPath(string fileExtentions)
        {
            var dir = System.Environment.CurrentDirectory;
            System.Environment.CurrentDirectory = dir;
            string[] files = System.IO.Directory.GetFiles(@"" + dir, "*", System.IO.SearchOption.TopDirectoryOnly);
            List<string> fileFullPath = new List<string>();

            int fileExtentionsCount;
            string trimStr;
            foreach(var item in files)
            {
                // 3文字拡張子ファイルのフルパスのみを入れる
                fileExtentionsCount = item.Count() - 3;
                trimStr = item.Substring(fileExtentionsCount);
                if(trimStr == fileExtentions)
                {
                    fileFullPath.Add(item);
                }
                // 4文字拡張子ファイルのフルパスのみを入れる
                fileExtentionsCount = item.Count() - 4;
                trimStr = item.Substring(fileExtentionsCount);
                if(trimStr == fileExtentions)
                {
                    fileFullPath.Add(item);
                }
            }
            return fileFullPath;
        }

        /// <summary>
        /// ファイルのフルパスから拡張子付きファイル名を取得
        /// </summary>
        /// <param name="fileFullPath">ファイルのフルパス</param>
        /// <returns>拡張子付きファイル名</returns>
        public string GetSpecifiedExtensionFileName(string fileFullPath)
        {
            var dir = System.Environment.CurrentDirectory;
            Uri u1 = new Uri(dir);
            Uri u2 = new Uri(fileFullPath);
            Uri relativeUri = u1.MakeRelativeUri(u2);
            string relativePath = relativeUri.ToString();
            int separateFilename = relativePath.IndexOf("/") + 1;
            
            return relativePath.Substring(separateFilename);
        }
    }
}