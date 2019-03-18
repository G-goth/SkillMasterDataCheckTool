using SkillMasterDataCheckTool.UtilityClassProviders;
using SkillMasterDataCheckTool.IIOFilesProviders;
using SkillMasterDataCheckTool.IOFiles.IOExcel;
using SkillMasterDataCheckTool.IOFileNames;

namespace SkillMasterDataCheckTool
{
    public sealed class ServiceLocatorProvider
    {
        private static ServiceLocatorProvider _singleton = new ServiceLocatorProvider();
        public ServiceLocator utilityCurrent{ get; private set; }
        public ServiceLocator ioFileNameCurrent{ get; private set; }
        public ServiceLocator ioExcelFileCurrent{ get; private set; }

        public static ServiceLocatorProvider GetInstance
        {
            get{ return _singleton; }
        }
        private ServiceLocatorProvider()
        {
            // UtilityClassの依存関係を登録
            utilityCurrent = new ServiceLocator();
            utilityCurrent.Register<IUtilityClassProvider>(new UtilityClassProvider());

            // IOFileNameの依存関係を登録
            ioFileNameCurrent = new ServiceLocator();
            ioFileNameCurrent.Register<IIOFileNamesProvider>(new IOFileName());

            // IOExcelFilesの依存関係を登録
            ioExcelFileCurrent = new ServiceLocator();
            ioExcelFileCurrent.Register<IIOExcelFilesProvider>(new IOExcelFiles());
        }
    }
}