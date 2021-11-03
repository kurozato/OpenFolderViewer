using System;
using System.Collections.Generic;
using System.Text;
using BlackSugar.SimpleMvp.WinForm;
using BlackSugar.View;
using BlackSugar.ViewModel;
using BlackSugar.Model;
using BlackSugar.Service;

namespace BlackSugar.Presenter
{
    public class MainPresenter : Presenter<IMainView>
    {
        private IFolderService _service;

        public MainPresenter(
            IFolderService service)
        {
            _service = service;
        }

        protected override void InitializeView()
        {
            _view.Theme = Theme.Dark; //_service.GetTheme();
            _view.Content = Content.Pins;
            _view.Model = _service.GetOpenFolder();
            _view.SelectedAction = folder => SelectedResult(folder);
            _view.PinnedAction = folder => PinnedResult(folder);
            _view.UnPinnedAction = folder => UnPinnedResult(folder);
            _view.SwitchAction = content => SwitchResult(content);
        }

        private void SelectedResult(Folder folder)
        {
            _service.Select(folder);
            _view.Exit();
        }

        private void PinnedResult(Folder folder)
        {
            _service.TogglePin(folder, true);
        }

        private void UnPinnedResult(Folder folder)
        {
            _service.TogglePin(folder, false);
            _view.Model = _service.GetPinsFolder();
        }

        private void SwitchResult(Content content)
        {
            switch (content)
            {
                case Content.Current:
                    _view.Model = _service.GetOpenFolder();
                    break;
                case Content.Pins:
                    _view.Model = _service.GetPinsFolder();
                    break;
                default:
                    break;
            }
        }
    }
}
