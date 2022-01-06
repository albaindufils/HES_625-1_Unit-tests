using System;
using System.Collections.Generic;
using System.Drawing;
using BLL.EdgeMatrix;
using BLL.FilterRGB;

namespace BLL
{
    public class FilterManager : IFilterManager
    {
        private IFilterRGB MyFilter = new ApplyMyFilter();
        private IFilterRGB FilterSwap = new ApplyFilterSwap();
        private IFilterRGB FilterMegaGreen = new ApplyFilterMegaGreen();
        private IFilterRGB FilterBlackWhite = new ApplyBlackAndWhiteFIlter();
        private List<IFilterRGB> RGBFiltersList = null;
        private IFilterEdgeMatrix SobelFilter = new Sobel3x3Filter();
        private IFilterEdgeMatrix KirschFilter = new KirschFilter();
        private IFilterEdgeMatrix PrewittFilter = new PrewittFilter();
        private List<IFilterEdgeMatrix> EdgeMatrixFilterList = null;
        private List <Object> AllFiltersList = new List <Object> ();

        public FilterManager()
        {
            RGBFiltersList = getFilterRGBList();
            EdgeMatrixFilterList = getEdgeMatrixFilterList();
            AllFiltersList = getAllFiltersList();
        }

        public List<Object> getAllFiltersList()
        {
            AllFiltersList.AddRange(getFilterRGBList());
            AllFiltersList.AddRange(getEdgeMatrixFilterList());

            return AllFiltersList;
        }
 
        public List<IFilterRGB> getFilterRGBList()
        {
            RGBFiltersList = new List<IFilterRGB>();

            RGBFiltersList.Add(null);
            RGBFiltersList.Add(MyFilter);
            RGBFiltersList.Add(FilterSwap);
            RGBFiltersList.Add(FilterMegaGreen);
            RGBFiltersList.Add(FilterBlackWhite);

            return RGBFiltersList;
        }

        public List<IFilterEdgeMatrix> getEdgeMatrixFilterList()
        {
           EdgeMatrixFilterList = new List<IFilterEdgeMatrix>();

            EdgeMatrixFilterList.Add(null);
            EdgeMatrixFilterList.Add(SobelFilter);
            EdgeMatrixFilterList.Add(PrewittFilter);
            EdgeMatrixFilterList.Add(KirschFilter);

            return EdgeMatrixFilterList;
        }

        private Bitmap FilterRGBApplying(Bitmap sourceBitmap, string FilterName)
        {
            IFilterRGB FilterToApply = null;
            Bitmap FilteredImage = null;

            try
            {
                foreach (IFilterRGB item in RGBFiltersList)
                {
                    if (item != null)
                    {
                        if (FilterName.Equals(item.Name))
                        {
                            FilterToApply = item;

                            FilteredImage = FilterToApply.Filter(sourceBitmap);

                            return FilteredImage;
                        }
                    }
                    else FilteredImage = sourceBitmap;
                }
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine(e1);

            }
            catch (InvalidOperationException e2)
            {
                Console.WriteLine(e2);
            }

            return FilteredImage;
        }

        private Bitmap EdgeMatrixFilterApplying(Bitmap sourceBitmap, string FilterName)
        {
            IFilterEdgeMatrix FilterToApply = null;
            Bitmap FilteredImage = null;

            try
            {
                foreach (IFilterEdgeMatrix item in EdgeMatrixFilterList)
                {
                    if (item != null)
                    {
                        if (FilterName.Equals(item.Name))
                        {
                            FilterToApply = item;

                            FilteredImage = FilterToApply.ApplyEdgeMatrixFilter(sourceBitmap);

                            return FilteredImage;
                        }
                    }
                }
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine(e1);

            }
            catch (InvalidOperationException e2)
            {
                Console.WriteLine(e2);
            }

            return sourceBitmap;
        }

        public Bitmap ApplyFilter(Bitmap bmp, string FilterName)
        {
            Bitmap ImageResult = null;
            string FilterType;

            foreach (var item in AllFiltersList)
            {
                if (item != null)
                {
                    string type = item.GetType().ToString();
                    FilterType = type.Substring(0, type.LastIndexOf("."));
                }
                else
                    FilterType = "";

                switch (FilterType)
                {
                    case "BLL.FilterRGB":
                        IFilterRGB RGBFilter = (IFilterRGB)item;

                        if (RGBFilter.Name.Contains(FilterName))
                        return FilterRGBApplying(bmp, FilterName);
                        break;

                    case "BLL.EdgeMatrix":
                        IFilterEdgeMatrix EdgeFilter = (IFilterEdgeMatrix)item;

                        if (EdgeFilter.Name.Contains(FilterName))
                            return EdgeMatrixFilterApplying(bmp, FilterName);
                        break;

                    default:
                        ImageResult = bmp;
                        break;
                }
            }

            return ImageResult;
        }

        public IFilterRGB GetFilterRGB (int Rank)
        {
            return RGBFiltersList[Rank];
        }

        public IFilterEdgeMatrix GetFilteEdge(int Rank)
        {
            return EdgeMatrixFilterList[Rank];
        }
    }
}
