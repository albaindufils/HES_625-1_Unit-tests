using System;
using System.Drawing;
using System.IO;

namespace ImageUtils
{
    public class Coordinate
    {
        public double x { get; set; }
        public double y { get; set; }
       
        
    }
    public class Tool
    {
        public static Bitmap LoadImage(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            Bitmap bitmap = new Bitmap(streamReader.BaseStream);
            streamReader.Close();
            return bitmap;
        }
}

    
}
