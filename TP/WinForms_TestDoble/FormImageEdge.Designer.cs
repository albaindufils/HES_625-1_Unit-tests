
namespace WinForms_TestDoble
{
    partial class FormImageEdge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelErrors = new System.Windows.Forms.Label();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.SuperposeFilter = new System.Windows.Forms.Label();
            this.RGBFilterButton1 = new System.Windows.Forms.Button();
            this.RGBFilterButton2 = new System.Windows.Forms.Button();
            this.ApplyingFilter = new System.Windows.Forms.Label();
            this.RGBFilterButton0 = new System.Windows.Forms.Button();
            this.RGBFiltersPanel = new System.Windows.Forms.Panel();
            this.RGBFilterButton4 = new System.Windows.Forms.Button();
            this.RGBFilterButton3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EdgeFilterbutton0 = new System.Windows.Forms.Button();
            this.EdgeFilterbutton1 = new System.Windows.Forms.Button();
            this.EdgeFilterbutton2 = new System.Windows.Forms.Button();
            this.EdgeFilterbutton3 = new System.Windows.Forms.Button();
            this.EdgeFiltersPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.RGBFiltersPanel.SuspendLayout();
            this.EdgeFiltersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(13, 12);
            this.buttonLoadImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(261, 60);
            this.buttonLoadImage.TabIndex = 0;
            this.buttonLoadImage.Text = "Load new Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxPreview.Location = new System.Drawing.Point(282, 12);
            this.pictureBoxPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(559, 709);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 1;
            this.pictureBoxPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Applying Edge filter(s)";
            // 
            // labelErrors
            // 
            this.labelErrors.Location = new System.Drawing.Point(624, 24);
            this.labelErrors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(229, 58);
            this.labelErrors.TabIndex = 6;
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(12, 661);
            this.buttonSaveAs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(261, 60);
            this.buttonSaveAs.TabIndex = 16;
            this.buttonSaveAs.Text = "Save Image";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // SuperposeFilter
            // 
            this.SuperposeFilter.AutoSize = true;
            this.SuperposeFilter.Location = new System.Drawing.Point(5, 38);
            this.SuperposeFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SuperposeFilter.Name = "SuperposeFilter";
            this.SuperposeFilter.Size = new System.Drawing.Size(155, 15);
            this.SuperposeFilter.TabIndex = 23;
            this.SuperposeFilter.Text = "(You can superpose 3 filters)";
            // 
            // RGBFilterButton1
            // 
            this.RGBFilterButton1.AutoSize = true;
            this.RGBFilterButton1.Location = new System.Drawing.Point(73, 114);
            this.RGBFilterButton1.Name = "RGBFilterButton1";
            this.RGBFilterButton1.Size = new System.Drawing.Size(107, 25);
            this.RGBFilterButton1.TabIndex = 28;
            this.RGBFilterButton1.Click += new System.EventHandler(this.RGBFilterButton1_Click);
            // 
            // RGBFilterButton2
            // 
            this.RGBFilterButton2.AutoSize = true;
            this.RGBFilterButton2.Location = new System.Drawing.Point(73, 164);
            this.RGBFilterButton2.Name = "RGBFilterButton2";
            this.RGBFilterButton2.Size = new System.Drawing.Size(107, 25);
            this.RGBFilterButton2.TabIndex = 29;
            this.RGBFilterButton2.Click += new System.EventHandler(this.RGBFilterButton2_Click);
            // 
            // ApplyingFilter
            // 
            this.ApplyingFilter.AutoSize = true;
            this.ApplyingFilter.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ApplyingFilter.Location = new System.Drawing.Point(5, 8);
            this.ApplyingFilter.Name = "ApplyingFilter";
            this.ApplyingFilter.Size = new System.Drawing.Size(196, 30);
            this.ApplyingFilter.TabIndex = 30;
            this.ApplyingFilter.Text = "Applying RGB filter";
            // 
            // RGBFilterButton0
            // 
            this.RGBFilterButton0.AutoSize = true;
            this.RGBFilterButton0.Location = new System.Drawing.Point(73, 64);
            this.RGBFilterButton0.Name = "RGBFilterButton0";
            this.RGBFilterButton0.Size = new System.Drawing.Size(107, 25);
            this.RGBFilterButton0.TabIndex = 31;
            this.RGBFilterButton0.Click += new System.EventHandler(this.RGBFilterButton0_Click);
            // 
            // RGBFiltersPanel
            // 
            this.RGBFiltersPanel.Controls.Add(this.RGBFilterButton4);
            this.RGBFiltersPanel.Controls.Add(this.RGBFilterButton3);
            this.RGBFiltersPanel.Controls.Add(this.RGBFilterButton0);
            this.RGBFiltersPanel.Controls.Add(this.ApplyingFilter);
            this.RGBFiltersPanel.Controls.Add(this.RGBFilterButton2);
            this.RGBFiltersPanel.Controls.Add(this.RGBFilterButton1);
            this.RGBFiltersPanel.Controls.Add(this.SuperposeFilter);
            this.RGBFiltersPanel.Location = new System.Drawing.Point(13, 78);
            this.RGBFiltersPanel.Name = "RGBFiltersPanel";
            this.RGBFiltersPanel.Size = new System.Drawing.Size(262, 301);
            this.RGBFiltersPanel.TabIndex = 33;
            // 
            // RGBFilterButton4
            // 
            this.RGBFilterButton4.AutoSize = true;
            this.RGBFilterButton4.Location = new System.Drawing.Point(73, 264);
            this.RGBFilterButton4.Name = "RGBFilterButton4";
            this.RGBFilterButton4.Size = new System.Drawing.Size(107, 25);
            this.RGBFilterButton4.TabIndex = 33;
            this.RGBFilterButton4.Click += new System.EventHandler(this.RGBFilterButton4_Click);
            // 
            // RGBFilterButton3
            // 
            this.RGBFilterButton3.AutoSize = true;
            this.RGBFilterButton3.Location = new System.Drawing.Point(73, 214);
            this.RGBFilterButton3.Name = "RGBFilterButton3";
            this.RGBFilterButton3.Size = new System.Drawing.Size(107, 25);
            this.RGBFilterButton3.TabIndex = 32;
            this.RGBFilterButton3.Click += new System.EventHandler(this.RGBFilterButton3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "(You can superpose 3 filters)";
            // 
            // EdgeFilterbutton0
            // 
            this.EdgeFilterbutton0.Location = new System.Drawing.Point(74, 75);
            this.EdgeFilterbutton0.Name = "EdgeFilterbutton0";
            this.EdgeFilterbutton0.Size = new System.Drawing.Size(107, 25);
            this.EdgeFilterbutton0.TabIndex = 34;
            this.EdgeFilterbutton0.UseVisualStyleBackColor = true;
            this.EdgeFilterbutton0.Click += new System.EventHandler(this.EdgeFilterbutton0_Click);
            // 
            // EdgeFilterbutton1
            // 
            this.EdgeFilterbutton1.Location = new System.Drawing.Point(74, 125);
            this.EdgeFilterbutton1.Name = "EdgeFilterbutton1";
            this.EdgeFilterbutton1.Size = new System.Drawing.Size(107, 25);
            this.EdgeFilterbutton1.TabIndex = 35;
            this.EdgeFilterbutton1.UseVisualStyleBackColor = true;
            this.EdgeFilterbutton1.Click += new System.EventHandler(this.EdgeFilterbutton1_Click);
            // 
            // EdgeFilterbutton2
            // 
            this.EdgeFilterbutton2.Location = new System.Drawing.Point(74, 175);
            this.EdgeFilterbutton2.Name = "EdgeFilterbutton2";
            this.EdgeFilterbutton2.Size = new System.Drawing.Size(107, 25);
            this.EdgeFilterbutton2.TabIndex = 36;
            this.EdgeFilterbutton2.UseVisualStyleBackColor = true;
            this.EdgeFilterbutton2.Click += new System.EventHandler(this.EdgeFilterbutton2_Click);
            // 
            // EdgeFilterbutton3
            // 
            this.EdgeFilterbutton3.Location = new System.Drawing.Point(74, 225);
            this.EdgeFilterbutton3.Name = "EdgeFilterbutton3";
            this.EdgeFilterbutton3.Size = new System.Drawing.Size(107, 25);
            this.EdgeFilterbutton3.TabIndex = 37;
            this.EdgeFilterbutton3.UseVisualStyleBackColor = true;
            this.EdgeFilterbutton3.Click += new System.EventHandler(this.EdgeFilterbutton3_Click);
            // 
            // EdgeFiltersPanel
            // 
            this.EdgeFiltersPanel.Controls.Add(this.EdgeFilterbutton3);
            this.EdgeFiltersPanel.Controls.Add(this.EdgeFilterbutton2);
            this.EdgeFiltersPanel.Controls.Add(this.EdgeFilterbutton1);
            this.EdgeFiltersPanel.Controls.Add(this.EdgeFilterbutton0);
            this.EdgeFiltersPanel.Controls.Add(this.label2);
            this.EdgeFiltersPanel.Controls.Add(this.label1);
            this.EdgeFiltersPanel.Location = new System.Drawing.Point(12, 385);
            this.EdgeFiltersPanel.Name = "EdgeFiltersPanel";
            this.EdgeFiltersPanel.Size = new System.Drawing.Size(263, 270);
            this.EdgeFiltersPanel.TabIndex = 38;
            // 
            // FormImageEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 733);
            this.Controls.Add(this.EdgeFiltersPanel);
            this.Controls.Add(this.RGBFiltersPanel);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.buttonSaveAs);
            this.Controls.Add(this.labelErrors);
            this.Controls.Add(this.buttonLoadImage);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormImageEdge";
            this.Text = "Single Color Edge Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.RGBFiltersPanel.ResumeLayout(false);
            this.RGBFiltersPanel.PerformLayout();
            this.EdgeFiltersPanel.ResumeLayout(false);
            this.EdgeFiltersPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadImage;
        public System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Label SuperposeFilter;
        private System.Windows.Forms.Button RGBFilterButton1;
        private System.Windows.Forms.Button RGBFilterButton2;
        private System.Windows.Forms.Label ApplyingFilter;
        private System.Windows.Forms.Button RGBFilterButton0;
        private System.Windows.Forms.Panel RGBFiltersPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EdgeFilterbutton0;
        private System.Windows.Forms.Button EdgeFilterbutton1;
        private System.Windows.Forms.Button EdgeFilterbutton2;
        private System.Windows.Forms.Button EdgeFilterbutton3;
        private System.Windows.Forms.Button RGBFilterButton3;
        private System.Windows.Forms.Panel EdgeFiltersPanel;
        private System.Windows.Forms.Button RGBFilterButton4;
    }
}

