using BlackSugar.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackSugar.Repository
{
    public interface IGeneralSetting
    {
        Theme Theme { get; set; }
    }


    public class GeneralSetting : IGeneralSetting
    {
        IFileReader _fileReader;

        public GeneralSetting(IFileReader fileReader)
        {
            _fileReader = fileReader ?? throw new ArgumentException(nameof(fileReader));

            var setting = _fileReader.Read<dynamic>(Path(FILENAME_SETTING));
            Theme = setting?.theme ?? Theme.Dark;
        }

        public const string FILENAME_SETTING = "setting.json";
        public const string FILENAME_RECODE = "e_recodes";
        public const string FILENAME_PINS = "pinned.json";
        public const string EXTERNAL_APP_NAME = "OFV.EXE";
  
        public Theme Theme { get; set; }

        public static string Root => AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

        public static string Path(string name) => System.IO.Path.Combine(Root, name);

    }
}
