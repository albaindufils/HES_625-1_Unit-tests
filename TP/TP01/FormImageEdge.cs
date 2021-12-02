using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ImageUtils;
using Image.Classes;
using Image;

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

            originalBitmap = new Bitmap(Properties.Resources.sassafras);
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

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalBitmap = Tool.LoadImage(OpenFileDialog.FileName);
                pictureBoxPreview.Image = originalBitmap;

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
                Bitmap tmp = FilterEdgeMatrix.EdgeFilter(new Bitmap(pictureBoxResult.Image), listBoxYEdgeFilter.SelectedItem.ToString(), listBoxYEdgeFilter.SelectedItem.ToString(), Convert.ToInt32(trackBarThreshold.Value));
                if(tmp != null )
                {
                    pictureBoxResult.Image = tmp;
                    resultBitmap = tmp;
                    ConvertToXYCoord(pictureBoxResult);
                } else
                {
                    labelErrors.Text = "Error found with edge";
                }
                
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
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Black'n White Filter")
                        resultBitmap = selectedSource.BlackWhite();
                    else if (cmbApplyFilter.SelectedItem.ToString() == "Swap Filter")
                        resultBitmap = selectedSource.ApplyFilterSwap();
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
       

        public void ConvertToXYCoord(PictureBox pictureBoxelem)
        {
            string coord = "";
            int width = pictureBoxelem.Image.Width;
            int height = pictureBoxelem.Image.Height;
            System.Drawing.Size size = new System.Drawing.Size(width, height);
            Bitmap bitmapIMG = new Bitmap(pictureBoxResult.Image, width, height);

            List<Coordinate> coorArray = new List<Coordinate>();

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

                if (sfd.ShowDialog() == DialogResult.OK)
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

        
