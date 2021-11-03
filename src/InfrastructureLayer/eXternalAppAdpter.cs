using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BlackSugar.Repository
{
    public interface IeXternalAppAdpter
    {
        string Kick(string app, string arguments);
        void KickFileOrUrl(string url);
    }

    public class eXternalAppAdpter : IeXternalAppAdpter
    {
        public string Kick(string app, string arguments)
        {
            string result = null;
            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = app;
                process.StartInfo.Arguments = arguments;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();

                result = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
                process.Close();
            }
            return result;
        }

        public void KickFileOrUrl(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //Windowsのとき  
                //Process.Start("cmd", "start " + fileOrApp);
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linuxのとき  
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //Macのとき  
                Process.Start("open", url);
            }
        }
    }
}
