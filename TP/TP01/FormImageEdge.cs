using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using Image.Classes;

//My take on and implementation of http://www.getcodesamples.com/src/25E5A923
namespace Image
{
    public partial class FormImageEdge : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        private int nbSelectedFilter = 3;

        public FormImageEdge()
        {
            InitializeComponent();

            cmbApplyFilter.SelectedIndex = 0;
            listBoxXEdgeFilter.SelectedIndex = 0 ;
            listBoxXEdgeFilter.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            originalBitmap = new Bitmap(Image.Properties.Resources.sassafras);
            pictureBoxPreview.Image = originalBitmap;

            if (originalBitmap == null)
            {
                cmbApplyFilter.Visible = false;
                previewBitmap = null;
            }

            previewBitmap = originalBitmap;
            isActivatedEdgeDetection(false);

            chartarea.Series.Add("plot");
            chartarea.Series["plot"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void isActivatedEdgeDetection (bool activ)
        {
            listBoxXEdgeFilter.Visible = activ;
            listBoxYEdgeFilter.Visible = activ;
            trackBarThreshold.Visible = activ;
            textBoxData.Visible = activ;
            buttonPlotCoords.Visible = activ;
            buttonApplyEdgeFilters.Visible = activ;           
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (!cmbApplyFilter.Visible)
            {
                filterAndEdgeFilterDone();
            }

            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Select image ";
            OpenFileDialog.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png|Bitmap Images(*.bmp)|*.bmp";

            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(OpenFileDialog.FileName);
                originalBitmap = new Bitmap(streamReader.BaseStream);
                pictureBoxPreview.Image = originalBitmap;
                streamReader.Close();

                if (originalBitmap == null)
                {
                    cmbApplyFilter.Visible = false;
                    label7.Visible = false;
                    previewBitmap = null;
                }

                previewBitmap = originalBitmap;

                filtersElementIsVisible();

            }
        }

        private void filterAndEdgeFilterDone()
        {
            originalBitmap = null;
            previewBitmap = null;
            resultBitmap = null;
            pictureBoxPreview.Image = originalBitmap;
            pictureBoxResult.Image = originalBitmap;

            cmbApplyFilter.SelectedIndex = 0;
            listBoxXEdgeFilter.SelectedIndex = 0;
            listBoxXEdgeFilter.SelectedIndex = 0;

            isActivatedEdgeDetection(false);
            filtersElementIsVisible();


        }

        private void buttonApplyEdgeFilters_Click(object sender, EventArgs e)
        {

                if (listBoxYEdgeFilter.SelectedItem.ToString().Length > 0 && listBoxYEdgeFilter.SelectedItem.ToString().Length > 0)
                {
                cmbApplyFilter.Visible= false;
                edgeFilter(listBoxYEdgeFilter.SelectedItem.ToString(), listBoxYEdgeFilter.SelectedItem.ToString());
                ConvertToXYCoord(pictureBoxResult);


            }
            else
                {
                    labelErrors.Text = "2 edge filters must be selected";
                }
            
        }


        private void CheckResultImage()
        {
            if (resultBitmap == null || previewBitmap == null)
                buttonSaveAs.Visible = false;
            else
                buttonSaveAs.Visible = true;
        }

        private void FilterListSelectedIndexChangedEventHandler(object sender, EventArgs e)
        {
            if (previewBitmap == null)
            {
                CheckResultImage();
                return;
            }

            buttonSaveAs.Visible = true;
            Bitmap selectedSource = originalBitmap;

            if (selectedSource != null)
            {
                if (resultBitmap != null)
                    selectedSource = resultBitmap;
                if (cmbApplyFilter.SelectedItem.ToString() == "Select one filter type")
                {
                    CheckResultImage();
                    return;
                }
                else
                {
                    if (cmbApplyFilter.SelectedItem.ToString() == "None")
                        resultBitmap = selectedSource;
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Mia Filter")
                        resultBitmap = selectedSource.ApplyMiaFilter();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "One Filter")
                        resultBitmap = selectedSource.ApplyOneFilter();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Rainbow Filter")
                        resultBitmap = selectedSource.ApplyRainbowFilter();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Black'n White Filter")
                        resultBitmap = selectedSource.BlackWhite();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Swapp Filter")
                        resultBitmap = selectedSource.ApplyFilterSwap();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Swap Filter Divide")
                        resultBitmap = selectedSource.ApplyFilterSwapDivide();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Mega Green Filter")
                        resultBitmap = selectedSource.ApplyFilterMegaGreen();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Mega Blue Filter")
                        resultBitmap = selectedSource.ApplyFilterMegaBlue();

                    pictureBoxResult.Image = resultBitmap;
                    isActivatedEdgeDetection(true);
                    ManagePossibilityFilterNumber();
                    manageTextLabel7();

                }
            }
        }

        private void ManagePossibilityFilterNumber ()
        {
            nbSelectedFilter --;

            if (nbSelectedFilter < 1)
            {
                cmbApplyFilter.Visible = false;
                label7.Visible = false;
                nbSelectedFilter = 3;
            }

        }

        private void filtersElementIsVisible()
        {
            if (previewBitmap != null)
            {
                cmbApplyFilter.Visible = true;
                label7.Visible = true;

                return;
            }

            cmbApplyFilter.Visible = false;
            label7.Visible = false;
        }

        private void manageTextLabel7 (){
            label7.Text = "You can superpose " + nbSelectedFilter + " filters";
        }

        /*Edge filter */
        /// </summary>
        /// <param name="xfilter"></param>
        /// <param name="yfilter"></param>
        public void edgeFilter(string xfilter, string yfilter)
        {
            double[,] xFilterMatrix;
            double[,] yFilterMatrix;
            switch (xfilter)
	        {
                case "Laplacian3x3":
                    xFilterMatrix = FilterEdgerMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    xFilterMatrix = FilterEdgerMatrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    xFilterMatrix = FilterEdgerMatrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    xFilterMatrix = FilterEdgerMatrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    xFilterMatrix = FilterEdgerMatrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    xFilterMatrix = FilterEdgerMatrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    xFilterMatrix = FilterEdgerMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    xFilterMatrix = FilterEdgerMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    xFilterMatrix = FilterEdgerMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    xFilterMatrix = FilterEdgerMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    xFilterMatrix = FilterEdgerMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    xFilterMatrix = FilterEdgerMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    xFilterMatrix = FilterEdgerMatrix.Laplacian3x3;
                    break;
	        }
            
            switch (yfilter)
	        {
                case "Laplacian3x3":
                    yFilterMatrix = FilterEdgerMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    yFilterMatrix = FilterEdgerMatrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    yFilterMatrix = FilterEdgerMatrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    yFilterMatrix = FilterEdgerMatrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    yFilterMatrix = FilterEdgerMatrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    yFilterMatrix = FilterEdgerMatrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    yFilterMatrix = FilterEdgerMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    yFilterMatrix = FilterEdgerMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    yFilterMatrix = FilterEdgerMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    yFilterMatrix = FilterEdgerMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    yFilterMatrix = FilterEdgerMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    yFilterMatrix = FilterEdgerMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    yFilterMatrix = FilterEdgerMatrix.Laplacian3x3;
                    break;
	        }

            if (pictureBoxPreview.Image.Size.Height > 0)
            {
                Bitmap newbitmap = new Bitmap(pictureBoxPreview.Image);
                BitmapData newbitmapData = new BitmapData();
                newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

                byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
                byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

                Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
                newbitmap.UnlockBits(newbitmapData);

                double blue = 0.0;
                double green = 0.0;
                double red = 0.0;

                double blueX = 0.0;
                double greenX = 0.0;
                double redX = 0.0;

                double blueY = 0.0;
                double greenY = 0.0;
                double redY = 0.0;

                double blueTotal = 0.0;
                double greenTotal = 0.0;
                double redTotal = 0.0;

                int filterOffset = 1;
                int calcOffset = 0;

                int byteOffset = 0;

                for (int offsetY = filterOffset; offsetY <
                    newbitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX <
                        newbitmap.Width - filterOffset; offsetX++)
                    {
                        blueX = greenX = redX = 0;
                        blueY = greenY = redY = 0;

                        blueTotal = greenTotal = redTotal = 0.0;

                        byteOffset = offsetY *
                                     newbitmapData.Stride +
                                     offsetX * 4;

                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                             (filterY * newbitmapData.Stride);

                                blueX += (double)(pixelbuff[calcOffset]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenX += (double)(pixelbuff[calcOffset + 1]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redX += (double)(pixelbuff[calcOffset + 2]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                blueY += (double)(pixelbuff[calcOffset]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenY += (double)(pixelbuff[calcOffset + 1]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redY += (double)(pixelbuff[calcOffset + 2]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];
                            }
                        }

                        //blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                        blueTotal = 0;
                        greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                        //redTotal = Math.Sqrt((redX * redX) + (redY * redY));
                        redTotal = 0;

                        if (blueTotal > 255)
                        { blueTotal = 255; }
                        else if (blueTotal < 0)
                        { blueTotal = 0; }

                        if (greenTotal > 255)
                        { greenTotal = 255; }
                        else if (greenTotal < 0)
                        { greenTotal = 0; }

                        try
                        {
                            if (greenTotal < Convert.ToInt32(trackBarThreshold.Value))
                            {
                                greenTotal = 0;
                            }
                            else
                            {
                                greenTotal = 255;
                            }
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }
                        

                        if (redTotal > 255)
                        { redTotal = 255; }
                        else if (redTotal < 0)
                        { redTotal = 0; }

                        resultbuff[byteOffset] = (byte)(blueTotal);
                        resultbuff[byteOffset + 1] = (byte)(greenTotal);
                        resultbuff[byteOffset + 2] = (byte)(redTotal);
                        resultbuff[byteOffset + 3] = 255;
                    }
                }

                Bitmap resultbitmap = new Bitmap(newbitmap.Width, newbitmap.Height);

                BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                         resultbitmap.Width, resultbitmap.Height),
                                                          ImageLockMode.WriteOnly,
                                                      PixelFormat.Format32bppArgb);

                Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
                resultbitmap.UnlockBits(resultData);
                pictureBoxResult.Image = resultbitmap;
            }
            else
            {
                labelErrors.Text = "You must load an image";
            }
        }

        public void ConvertToXYCoord(PictureBox pictureBoxelem)
        {
            string coord = "";
            int width = pictureBoxelem.Image.Width;
            int height = pictureBoxelem.Image.Height;
            System.Drawing.Size size = new System.Drawing.Size(width, height);
            Bitmap bitmapIMG = new Bitmap(pictureBoxResult.Image, width, height);

            List<Image.coord> coorArray = new List<Image.coord>();

            int x = 0;
            int y = 0;
            double newX;
            double newY;

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    Color pixelColor = Color.FromArgb(bitmapIMG.GetPixel(x, y).ToArgb());
                    if (pixelColor.Name != "ff000000" && pixelColor.Name != "0")
                    {
                        //coord = coord + x.ToString() + "," + y.ToString() + "|";
                        newX = Convert.ToDouble(x);
                        newY = Convert.ToDouble(y);
                        int angle = 110;

                        //Rotate
                        newX = newX * Math.Cos(angle) - newY * Math.Sin(angle);
                        newY = newX * Math.Sin(angle) + newY * Math.Cos(angle);

                        coord = coord + newX.ToString() + "," + newY.ToString() + "|";
                    }
                } 
            }

            textBoxData.Text = coord;
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            if (resultBitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    resultBitmap = null;
                }
                Dispose();
                new FormImageEdge();
            }

        }

        private void buttonPlotCoords_Click(object sender, EventArgs e)
        {
            chartarea.Series["plot"].Points.Clear();

            if (textBoxData.Text.Length > 1)
            {
                chartarea.Visible = true;
                chartarea.Width = 500;
                chartarea.Height = 500;

                Button Close = new Button();
                Close.Click += new System.EventHandler(Close_Click);
                Close.BackColor = System.Drawing.Color.LightGray;
                Close.Text = "Close";
                chartarea.Controls.Add(Close);

                string[] coords = textBoxData.Text.Split('|');
                for (int i = 0; i < coords.Length; i++)
                {
                    if (coords[i] != "")
                    {
                        double newX = Convert.ToDouble(coords[i].Split(',')[0]);
                        double newY = Convert.ToDouble(coords[i].Split(',')[1]);

                        chartarea.Series["plot"].Points.AddXY(newX, newY);
                    }
                    
                }
            }
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            chartarea.Visible = false;
        }

    }
}

        
