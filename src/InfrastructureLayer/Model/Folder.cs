using System;
using System.Collections.Generic;
using System.Text;

namespace BlackSugar.Model
{
    public class Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Folder() { }

        public Folder(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
