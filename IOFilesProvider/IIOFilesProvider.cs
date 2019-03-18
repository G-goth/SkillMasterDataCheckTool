using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace SkillMasterDataCheckTool.IIOFilesProviders
{
    public interface IIOFilesProvider
    {
        List<string> GetSpecifiedExtensionFileFullPath(string fileExtentions);
        string GetSpecifiedExtensionFileName(string fileFullPath);
        List<string> GetSpecifiedExtensionFileNameToList(List<string> fileFullPathList);
    }
}