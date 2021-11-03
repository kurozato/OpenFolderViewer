using System;
using BlackSugar.Repository;
using BlackSugar.Model;
using System.Collections.Generic;
using Setting = BlackSugar.Repository.GeneralSetting;

namespace BlackSugar.Service
{
    public  interface IFolderService
    {
        List<Folder> GetOpenFolder();

        List<Folder> GetPinsFolder();

        void TogglePin(Folder folder, bool pinned);

        void Select(Folder folder);

        Theme GetTheme();
    }

    public class FolderService : IFolderService
    {
        protected IFileReader _fileReader;
        protected IFileWriter _fileWriter;
        protected IeXternalAppAdpter _exAppAdpter;
        protected IGeneralSetting _setting;

        public FolderService(
            IFileReader fileReader,
            IFileWriter fileWriter,
            IeXternalAppAdpter exAppAdpter,
            IGeneralSetting setting)
        {
            _fileReader = fileReader ?? throw new ArgumentException(nameof(fileReader));
            _fileWriter = fileWriter ?? throw new ArgumentException(nameof(fileWriter));
            _exAppAdpter = exAppAdpter ?? throw new ArgumentException(nameof(exAppAdpter));
            _setting = setting ?? throw new ArgumentException(nameof(setting));
        }

        public Theme GetTheme()
        {
            return _setting.Theme;
        }

        public List<Folder> GetOpenFolder()
        {

            var file = _exAppAdpter.Kick(
                            Setting.Path(Setting.EXTERNAL_APP_NAME),
                             "\"" + Setting.Root + "\" /r");

            file = Setting.Path(file);

            var result = _fileReader.Read<List<Folder>>(file) ?? new List<Folder>();
            
            if(System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            return result;
        }

        public List<Folder> GetPinsFolder()
        {
            var file = Setting.Path(Setting.FILENAME_PINS);
            return _fileReader.Read<List<Folder>>(file) ?? new List<Folder>();
        }

        public void Select(Folder folder)
        {
            _exAppAdpter.KickFileOrUrl(folder.Path);
        }

        public void TogglePin(Folder folder, bool pinned)
        {
            var pins = GetPinsFolder();
            if (pinned)
                pins.Add(folder);
            else
                pins.Remove(folder);

            var file = Setting.Path(Setting.FILENAME_PINS);

            _fileWriter.Write(file, pins);
        }
    }
}
