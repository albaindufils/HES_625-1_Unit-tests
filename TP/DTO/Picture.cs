using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace DTO
{
    public class Picture
    {
        private string name;
        private string path;
        private List<string> appliedFIlters = new List<string>();

        public Picture() { }
        public Picture(string Name)
        {
            name = Name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Path 
        {
            get { return path; }
            set { path = value; }
        }

        public List<string> AppliedFilters 
        {
            get { return appliedFIlters; }
            set { appliedFIlters = value; }
        }

    }
}
