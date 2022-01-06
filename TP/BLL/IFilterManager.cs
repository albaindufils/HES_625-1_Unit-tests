using System.Collections.Generic;
using System.Drawing;
using BLL.FilterRGB;
using BLL.EdgeMatrix;


namespace BLL
{
    public interface IFilterManager
    {
        public List<IFilterRGB> getFilterRGBList();

        public List<IFilterEdgeMatrix> getEdgeMatrixFilterList();

        public Bitmap ApplyFilter(Bitmap bmp, string FilterName);

        public IFilterRGB GetFilterRGB(int Rank);

        public IFilterEdgeMatrix GetFilteEdge(int Rank);
    }
}
