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

// NuGet Packages
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace ppSlideExtract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxResolution.SelectedIndex = 1;
#if !DEBUG
            comboBoxResolution.Items.RemoveAt(3);
#endif
        }

        private void cbMask_CheckedChanged(object sender, EventArgs e)
        {
            if(cbMask.Checked)
            {
                numMask.Enabled = true;
                cbShadow.Enabled = true;
                if (cbShadow.Checked)
                {
                    numShadow.Enabled = true;
                }
            }
            else
            {
                numMask.Enabled = false;
                numShadow.Enabled = false;
                cbShadow.Enabled = false;
            }
        }

        private void cbShadow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShadow.Checked)
            {
                numShadow.Enabled = true;
            }
            else
            {
                numShadow.Enabled = false;
            }
        }

        private void buttonInputFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "PowerPoint Files|*.ppt;*.pptx";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxInputFile.Text = ofd.FileName;
            }
        }

        private void buttonOutputFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputFolder.Text = fbd.SelectedPath;
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Author: Sven Wanzenried, 2020\n" +
            "License: GNU GPLv3\n" +
            "Source Code of this Software can be found at:\n" +
            "https://github.com/svenito92 \n\n" +
            "This Software uses 'Emgu CV' licensed under the GNU GPLv3\n" +
            "https://github.com/emgucv/emgucv \n\n" +
            "GNU GPLv3:\n" +
            "http://www.gnu.org/licenses/gpl-3.0.txt \n"
            );
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            var height = 0;
            var width = 0;
            var inputFile = textBoxInputFile.Text;
            var outputPath = textBoxOutputFolder.Text;
            if (!outputPath.EndsWith("\\")) { outputPath += "\\"; }

            if (!File.Exists(inputFile)) { MessageBox.Show("Chosen file does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!Directory.Exists(outputPath)) { Directory.CreateDirectory(outputPath); }


            switch (comboBoxResolution.SelectedIndex)
            {
                case 0:
                    width = 1280;
                    height = 720;
                    break;
                case 1:
                    width = 1920;
                    height = 1080;
                    break;
                case 2:
                    width = 3840;
                    height = 2160;
                    break;
                case 3:
                    width = 5;
                    height = 5;
                    break;
                default:
                    width = 1920;
                    height = 1080;
                    break;
            }

            var maskSlide = (int)numMask.Value;
            var shadowSlide = (int)numShadow.Value;
            var slideList = new List<int>();

            try
            {
                slideList = exportPPSlides(inputFile, outputPath, maskSlide, shadowSlide, height, width);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Argument Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbMask.Checked)
            {
                slideList.Remove((int)numMask.Value);
                if (cbShadow.Checked)
                {
                    slideList.Remove((int)numShadow.Value);
                    extractFromSlides(outputPath, slideList, maskSlide, shadowSlide);
                }
                else
                {
                    extractFromSlides(outputPath, slideList, maskSlide, 0);
                }
            }

        }

        private List<int> exportPPSlides(string filename, string outdir, int maskSlide, int shadowSlide, int height = 1080, int width = 1920, string slidePrefix = "Slide_")
        {
            var pptApp = new PowerPoint.Application();
            var pptPres = pptApp.Presentations.Open(filename);


            if (maskSlide > pptPres.Slides.Count + 1) { throw new ArgumentException("Mask slide value too high!"); }
            if (shadowSlide > pptPres.Slides.Count + 1) { throw new ArgumentException("Shadow slide value too high!"); }

            var slideList = new List<int>();
            foreach (PowerPoint.Slide s in pptPres.Slides)
            {
                s.Export(outdir + slidePrefix + s.SlideNumber + ".png", "png", width, height);
                slideList.Add(s.SlideNumber);
            }

            try
            {
                pptPres.Close();
                if (pptApp.Presentations.Count == 0)
                {
                    pptApp.Quit();
                }
            }
            catch { MessageBox.Show("PowerPoint could not be closed properly"); }

            return slideList;

        }

        private void extractFromSlides(string outdir, List<int> slideList, int maskSlide, int shadowSlide, string slidePrefix = "Slide_")
        {
            var mat_mask = CvInvoke.Imread(outdir + slidePrefix + maskSlide + ".png", ImreadModes.Grayscale);
            Mat mat_shadow_inv = null;

            if (shadowSlide > 0)
            {
                var mat_shadow = CvInvoke.Imread(outdir + slidePrefix + shadowSlide + ".png", ImreadModes.Grayscale);
                mat_shadow_inv = 255 - mat_shadow;
                mat_shadow.Dispose();
            }

            Mat mat_content = null;
            VectorOfMat mat_content_bgr = null;
            Mat mat_alpha = null;

            foreach (var slide in slideList)
            {
                // Read current image back from File
                mat_content = CvInvoke.Imread(outdir + slidePrefix + slide + ".png", ImreadModes.Color);

                // Split in Blue, Green and Red channel
                mat_content_bgr = new VectorOfMat(mat_content.Split());

                // Mask all channel so image gets blck where mask is black
                CvInvoke.Multiply(mat_content_bgr[0], mat_mask, mat_content_bgr[0], 1.0 / 255);
                CvInvoke.Multiply(mat_content_bgr[1], mat_mask, mat_content_bgr[1], 1.0 / 255);
                CvInvoke.Multiply(mat_content_bgr[2], mat_mask, mat_content_bgr[2], 1.0 / 255);

                // Create alpha layer for image
                mat_alpha = mat_mask.Clone();
                if (shadowSlide > 0)
                {
                    CvInvoke.Add(mat_mask, mat_shadow_inv, mat_alpha);
                }

                // Merge channels to one image again
                CvInvoke.Merge(new VectorOfMat(mat_content_bgr[0], mat_content_bgr[1], mat_content_bgr[2], mat_alpha), mat_content);

                // Save current extracted image with alpha layer
                mat_content.Save(outdir + "Extract_" + slide + ".png"); 
            }

            // Dispose all used elements
            if(mat_mask != null) { mat_mask.Dispose(); }
            if(mat_shadow_inv != null) { mat_shadow_inv.Dispose(); }
            if(mat_content != null) { mat_content.Dispose(); }
            if (mat_content_bgr != null) { mat_content_bgr.Dispose(); }
            if (mat_alpha != null) { mat_alpha.Dispose(); }
        }

    }
}
