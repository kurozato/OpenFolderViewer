using System;
using System.Collections.Generic;
using BlackSugar.ViewModel;
using BlackSugar.Model;

namespace BlackSugar.View
{
    public interface IMainView
    {
        List<Folder> Model { get; set; }

        Theme Theme { get; set; }

        Content Content { get; set; }

        Action<Folder> SelectedAction { get; set; }

        Action<Folder> PinnedAction { get; set; }

        Action<Folder> UnPinnedAction { get; set; }

        Action<Content> SwitchAction { get; set; }

        void Exit();
    }
}
