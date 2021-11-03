using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace BlackSugar.Repository
{
    internal class Encode
    {
        public const int ENCODE_SHIFT_JIS = 0;
    }

    public interface IFileReader
    {
        TResult Read<TResult>(string path);
    }

    public class FileReader : IFileReader
    {
        public TResult Read<TResult>(string path)
        {
            if (File.Exists(path) == false)
                return default(TResult);

            TResult result;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {

                using (var reader = new StreamReader(stream, Encoding.GetEncoding(Encode.ENCODE_SHIFT_JIS)))
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    result = JsonSerializer.Deserialize<TResult>(reader.ReadToEnd(), options);
                    reader.Close();
                }
                stream.Close();
            }
            return result;
        }
    }

    public interface IFileWriter
    {
        void Write(string path, object value);
    }

    public class FileWriter : IFileWriter
    {
        public void Write(string path, object value)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(value, options);
            using (var writer = new StreamWriter(path, false, Encoding.GetEncoding(Encode.ENCODE_SHIFT_JIS)))
            {
                writer.Write(json);
                writer.Close();
            }
        }
    }

}