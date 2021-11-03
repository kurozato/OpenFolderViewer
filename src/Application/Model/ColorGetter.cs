using BlackSugar.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlackSugar.ViewModel
{
    public class ColorGetter
    {


        private Color _fColor = ColorTranslator.FromHtml("#ffffff");
        private Color _bColor = ColorTranslator.FromHtml("#161618");
        private Color _sColor = ColorTranslator.FromHtml("#EFC862");

        public static Color GetBackColor(Theme theme)
        {
            if(theme == Theme.Dark) 
                return ColorTranslator.FromHtml("#161618");
            else
                return ColorTranslator.FromHtml("#161618");
        }

        public static Color GetForeColor(Theme theme)
        {
            if (theme == Theme.Dark)
                return ColorTranslator.FromHtml("#ffffff");
            else
                return ColorTranslator.FromHtml("#ffffff");
        }

        public static Color GetSelectColor(Theme theme)
        {
            if (theme == Theme.Dark)
                return ColorTranslator.FromHtml("#EFC862");
            else
                return ColorTranslator.FromHtml("#EFC862");
        }
    }
}
