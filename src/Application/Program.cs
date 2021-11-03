using System;
using System.Collections.Generic;
//using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

using BlackSugar.SimpleMvp;
using BlackSugar.Repository;
using BlackSugar.Service;
using BlackSugar.View;
using BlackSugar.Presenter;

namespace WinFormsApp1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var resolver = new DependencyResolver();
            resolver.Set(services => {

                //Repository
                services.AddSingleton<IFileReader, FileReader>();
                services.AddSingleton<IFileWriter, FileWriter>();
                services.AddSingleton<IeXternalAppAdpter, eXternalAppAdpter>();

                services.AddSingleton<IGeneralSetting, GeneralSetting>();
                //Service
                services.AddSingleton<IFolderService, FolderService>();
                //View
                services.AddTransient<IMainView, MainForm>();
                //Presenter
                services.AddSingleton<IPresenter<IMainView>, MainPresenter>();
                //services.AddSingleton<,> ();
            });

            Router.Configure(resolver);
            //var filders = resolver.Resolve<IFolderService>().GetOpenFolder();
            var view = Router.NavigateTo<IMainView>();
            //var view = new MainForm();
            //view.Model = filders;
            //view.Theme = BlackSugar.Model.Theme.Dark;
            Application.Run(view as Form);
            //Application.Run(new Form1());

            resolver.Release();
            view = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

           
        }
    }
}
