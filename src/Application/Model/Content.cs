using System;
using System.Collections.Generic;
using System.Text;

namespace BlackSugar.ViewModel
{
    public enum Content
    {
        Current,
        Pins
    }

    public class ContentHepler
    {
        public static Content ConvertContent(string name)
        {
            return Enum.Parse<Content>(name);
        }

        public static string ContentToStrig(Content content)
        {
            return Enum.GetName(typeof(Content), content);
        }
    }
}
