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

        public Picture(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public List<string> AppliedFilter { get; set; }

        public byte[] ImageByteArray (Bitmap bmp)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bmp.Save(memoryStream, ImageFormat.Bmp);
                byte[] ImageByteArray = memoryStream.ToArray();
                return ImageByteArray;
            }
        }

    }
}
