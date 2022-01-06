using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using BLL;


namespace WinForms_TestDoble
{
    public partial class FormImageEdge : Form
    {
        static IFilterManager FilterManager = Program.FilterManager;
        private Bitmap originalBitmap = null;
        private Bitmap resultBitmap = null;
        private int SelectedRGBFilterNbr = 3;
        private int SelectedEdgeMatrixFilterNbr = 3;
        private List<Button> RGBFilterButtonsList = new List<Button>();
        private List<Button> EdgeFilterButtonsList = new List<Button>();
        private List<Button> AllFilterButtonsList = new List<Button>();


        public FormImageEdge()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originalBitmap = new Bitmap(Resources.leaf);

            if (originalBitmap == null)
            {
                resultBitmap = null;
            }

            InitForm();

            resultBitmap = originalBitmap;
            displayImage(resultBitmap);
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Select image ";
            OpenFileDialog.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png|Bitmap Images(*.bmp)|*.bmp";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(OpenFileDialog.FileName);
                originalBitmap = new Bitmap(streamReader.BaseStream);
                pictureBoxPreview.Image = originalBitmap;
                streamReader.Close();

                if (originalBitmap == null)
                {
                    resultBitmap = null;
                }

                resultBitmap = originalBitmap;

                InitForm();

            }
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

        private void InitFilterButton(Button button, int ListFilterRank)
        {
            if (button.Name.Contains("RGB"))
            {
                if (FilterManager.GetFilterRGB(ListFilterRank) != null)
                    button.Text = FilterManager.GetFilterRGB(ListFilterRank).Name;
                else button.Text = "None";

                return;
            }
            if (button.Name.Contains("Edge"))
            {
                if (FilterManager.GetFilteEdge(ListFilterRank) != null)
                    button.Text = FilterManager.GetFilteEdge(ListFilterRank).Name;
                else button.Text = "None";

                return;
            }
        }

        private List<Button> InitFilterButtonsList(List<Button> FilterButtonsList)
        {
            List<Button> list = new List<Button>();

            foreach (Button button in FilterButtonsList)
            {
                InitFilterButton(button, FilterButtonsList.IndexOf(button));
                button.Enabled = true;
                list.Add(button);
            }
            return list;
        }

        private List<Button> InitAllFilterButtonsList()
        {

            AllFilterButtonsList.AddRange(InitFilterButtonsList(GetRGBFilterButtonsList()));
            AllFilterButtonsList.AddRange(InitFilterButtonsList(GetEdgeFilterButtonsList()));

            return AllFilterButtonsList;
        }

        private List<Button> GetRGBFilterButtonsList()
        {
            RGBFilterButtonsList.Add(RGBFilterButton0);
            RGBFilterButtonsList.Add(RGBFilterButton1);
            RGBFilterButtonsList.Add(RGBFilterButton2);
            RGBFilterButtonsList.Add(RGBFilterButton3);
            RGBFilterButtonsList.Add(RGBFilterButton4);

            return RGBFilterButtonsList;
        }

        private List<Button> GetEdgeFilterButtonsList()
        {
            EdgeFilterButtonsList.Add(EdgeFilterbutton0);
            EdgeFilterButtonsList.Add(EdgeFilterbutton1);
            EdgeFilterButtonsList.Add(EdgeFilterbutton2);
            EdgeFilterButtonsList.Add(EdgeFilterbutton3);

            return EdgeFilterButtonsList;
        }

        private void InitForm()
        {
            InitAllFilterButtonsList();
            EdgeFiltersPanel.Visible = false;
        }

        private void RGBFilterButton0_Click(object sender, EventArgs e)
        {
            ApplyFilter(RGBFilterButton0);
        }

        private void RGBFilterButton1_Click(object sender, EventArgs e)
        {
            ApplyFilter(RGBFilterButton1);
        }

        private void RGBFilterButton2_Click(object sender, EventArgs e)
        {
            ApplyFilter(RGBFilterButton2);
        }

        private void RGBFilterButton3_Click(object sender, EventArgs e)
        {
            ApplyFilter(RGBFilterButton3);
        }

        private void RGBFilterButton4_Click(object sender, EventArgs e)
        {
            ApplyFilter(RGBFilterButton4);
        }

        private void EdgeFilterbutton0_Click(object sender, EventArgs e)
        {
            ApplyFilter(EdgeFilterbutton0);
        }

        private void EdgeFilterbutton1_Click(object sender, EventArgs e)
        {
            ApplyFilter(EdgeFilterbutton1);
        }

        private void EdgeFilterbutton2_Click(object sender, EventArgs e)
        {
            ApplyFilter(EdgeFilterbutton2);
        }

        private void EdgeFilterbutton3_Click(object sender, EventArgs e)
        {
            ApplyFilter(EdgeFilterbutton3);
        }

        void ApplyFilter(Button ButtonFilter)
        {
            ManagedNbrButtonFilterUsed(ButtonFilter);
            resultBitmap = FilterManager.ApplyFilter(resultBitmap, ButtonFilter.Text);
            displayImage(resultBitmap);
        }

        public void ManagedNbrButtonFilterUsed(Button ButtonFilter)
        {
            bool RGBFilterAvailable = CheckNbrFilterAvailable(SelectedRGBFilterNbr);
            bool EdgeFilterAvailable = CheckNbrFilterAvailable(SelectedEdgeMatrixFilterNbr);

            buttonSaveAs.Visible = true;

            if (ButtonFilter.Name.Contains("RGB"))
            {
                SelectedRGBFilterNbr--;
                ButtonFilter.Enabled = false;
                DisplayButtonsAndPanels(CheckNbrFilterAvailable(SelectedRGBFilterNbr), EdgeFilterAvailable);

                return;
            }

            if (ButtonFilter.Name.Contains("Edge"))
            {
                SelectedEdgeMatrixFilterNbr--;
                ButtonFilter.Enabled = false;
                DisplayButtonsAndPanels(RGBFilterAvailable, CheckNbrFilterAvailable(SelectedEdgeMatrixFilterNbr));

                return;
            }

        }

        private bool CheckNbrFilterAvailable(int NbrFilterAwailable)
        {
            if (NbrFilterAwailable > 0)
                return true;

            return false;
        }

        private void DisplayButtonsAndPanels(bool RGBFiltersAvailable, bool EdgeFiltersAvailable)
        {
            if (RGBFiltersAvailable)
            {
                RGBFiltersPanel.Visible = true;
            }
            else
                RGBFiltersPanel.Visible = false;

            if (EdgeFiltersAvailable)
            {
                EdgeFiltersPanel.Visible = true;
            }
            else
                EdgeFiltersPanel.Visible = false;

        }

        private void displayImage(Bitmap Image)
        {
            pictureBoxPreview.Image = Image;
        }
    }
}
