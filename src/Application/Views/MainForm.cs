using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BlackSugar.Utility;
using BlackSugar.Model;
using BlackSugar.ViewModel;

namespace BlackSugar.View
{
    public partial class MainForm : Form, IMainView
    {

        private Color _foreColor;
        private Color _backColor;
        private Color _selectColor;

        private List<Folder> _model;

        public List<Folder> Model {
            get => _model;
            set{
                _model = value;
                SetItem(_model);
            }
        }
        private Theme _theme;
        public Theme Theme { 
            get => _theme; 
            set {
                _theme = value;
                SetTheme(_theme);
            }
        }
        public Content Content { get; set; }
        public Action<Folder> SelectedAction { get; set; }
        public Action<Folder> PinnedAction { get; set; }
        public Action<Folder> UnPinnedAction { get; set; }
        public Action<Content> SwitchAction { get; set; }
        public void Exit() => Close();

        public MainForm()
        {
            InitializeComponent();

            this.Load += (s, e) => ToggleContent(Content.Current);

            btnClose.Click += (s, e) => this.Close();
            lblCurrent.Click += (s, e) => ToggleContent(Content.Current);
            lblPins.Click += (s, e) => ToggleContent(Content.Pins);

            UIHelper.SetWindowTitleBar(pnlHeader, this);
            UIHelper.SetWindowTitleBar(pnlSide, this);
            UIHelper.SetWindowTitleBar(lblLogo, this);
            UIHelper.SetWindowTitleBar(picDropAria, this);

            lstFolder.ItemDrag += (s, e) => {
                lstFolder.DoDragDrop((ListViewItem)e.Item, DragDropEffects.Copy | DragDropEffects.Move);
            };
 
            this.AllowDrop = true;

            UIHelper.AllowDragDrop(lblPins, data => TogglePinnedAction(ConvertFolder(data)));
            UIHelper.AllowDragDrop(pnlSide, data => TogglePinnedAction(ConvertFolder(data)));
            UIHelper.AllowDragDrop(lstFolder, data => { });

            lblCurrent.Click += (s, e) => SwitchAction(Content.Current);
            lblPins.Click += (s, e) => SwitchAction(Content.Pins);
            lstFolder.DoubleClick += (s, e) => SelectedAction(ConvertFolder(lstFolder.SelectedItems[0]));

            lstFolder.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                    SelectedAction(ConvertFolder(lstFolder.SelectedItems[0]));
                else if (e.Control == true && (e.KeyCode == Keys.F || e.KeyCode == Keys.Q))
                    txtFilter.Focus();
            };
            txtFilter.TextChanged += (s, e) => {
                Func<Folder, bool> filter
                        = w => w.Path.ToUpper().IndexOf(txtFilter.Text.ToUpper().Trim()) >= 0;

                if (txtFilter.Text.Trim().Length == 0)
                    SetItem(_model);
                else
                    SetItem(_model.Where(filter).ToList());
            };

        }

        private void TogglePinnedAction(Folder folder)
        {
            if (Content == Content.Current)
                PinnedAction(folder);
            else
                UnPinnedAction(folder);
        }

        private Folder ConvertFolder(object data)
        {
            var item = data as ListViewItem;
            if (item != null)
                return new Folder(item.SubItems[0].Text, item.SubItems[1].Text);
            else
                return default;
        }

        private void Coloring(Color foreColor, Color backColor)
        {
            var lineColor1 = ColorTranslator.FromHtml("#707070");

            UIHelper.SetColor(this, null, backColor);
            UIHelper.SetColor(btnClose, foreColor, backColor);
            UIHelper.SetColor(pnlSide, null, backColor);
            UIHelper.SetColor(pnlHeader, null, backColor);
            UIHelper.SetColor(lblLogo, foreColor, backColor);
            UIHelper.SetColor(txtFilter, foreColor, backColor);

            UIHelper.SetColor(lineSide, null, lineColor1);
        
            UIHelper.SetColor(lstFolder, backColor, Color.Black, foreColor, Color.Gray);
        }

        private void ToggleContent(Content content)
        {
            var old = ContentHepler.ContentToStrig(Content);
            var current = ContentHepler.ContentToStrig(content);

            Switch(old, true);
            Switch(current, false);

            switch (content)
            {
                case Content.Current:
                    DrawVerticalText("Drop  Item  Here.\n       Item  is  Pinned.");
                    break;
                case Content.Pins:
                    DrawVerticalText("Drop  Item  Here.\n       Item  is  UnPinned.");
                    break;
            }

            Content = content;
        }

        private void Switch(string name, bool off)
        {
            var label = UIHelper.FindControl("lbl" + name, this);
            var line = UIHelper.FindControl("line" + name, this);
            if(off)
            {
                UIHelper.SetColor(label, _foreColor, _backColor);
                UIHelper.SetColor(line, null, _backColor);
            }
            else
            {
                UIHelper.SetColor(label, _selectColor, _backColor);
                UIHelper.SetColor(line, null, _selectColor);
            }
        }

        private void SetTheme(Theme theme)
        {
            _foreColor = ColorGetter.GetForeColor(theme);
            _backColor = ColorGetter.GetBackColor(theme);
            _selectColor = ColorGetter.GetSelectColor(theme);

            Coloring(_foreColor, _backColor);
        }

        private void SetItem(List<Folder> models)
        {
            lstFolder.View = System.Windows.Forms.View.Tile;
            lstFolder.FullRowSelect = true;
            lstFolder.MultiSelect = false;
            lstFolder.TileSize = new Size(lstFolder.Width - 20, 40);
            lstFolder.Columns.AddRange(new ColumnHeader[] { new ColumnHeader(), new ColumnHeader() });
            
            lstFolder.BeginUpdate();

            lstFolder.Items.Clear();

            foreach (var model in models)
            {
                ListViewItem item = new ListViewItem(new string[] { model.Name, model.Path });
                
                item.UseItemStyleForSubItems = false;
                item.SubItems[0].ForeColor = Color.White;
                lstFolder.Items.Add(item);
            };

            lstFolder.EndUpdate();
        }

        private void DrawVerticalText(string text)
        {
            var canvas = new Bitmap(picDropAria.Width, picDropAria.Height);

            using (var g = Graphics.FromImage(canvas))
            {
                //ワールド変換を平行移動、90度回転
                g.TranslateTransform(40, picDropAria.Height);
                g.RotateTransform(-90F);
                using (var fnt = new Font("Bahnschrift Light", 9))
                {
                    g.DrawString(text, fnt, Brushes.White, 0, 0);
                    picDropAria.Image = canvas;
                }
            }
        }

    }
}
