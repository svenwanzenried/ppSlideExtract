using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// NuGet Packages
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace ppSlideExtract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            }

            var slideList = exportPPSlides(inputFile, outputPath, height, width);
            slideList.Remove((int)numMask.Value);
            slideList.Remove((int)numShadow.Value);
            if (cbMask.Checked)
            {
                if (cbShadow.Checked)
                {
                    doWithEmguCV(outputPath, slideList, (int)numMask.Value, (int)numShadow.Value);
                }
                else
                {
                    doWithEmguCV(outputPath, slideList, (int)numMask.Value, 0);
                }
            }
        }

        private List<int> exportPPSlides(string filename, string outdir, int height = 1080, int width = 1920, string slidePrefix = "Slide_")
        {
            var pptApp = new PowerPoint.Application();
            var pptPres = pptApp.Presentations.Open(filename);

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

        private void doWithEmguCV(string outdir, List<int> slideList, int maskSlide, int shadowSlide, string slidePrefix = "Slide_")
        {
            Image<Bgra, double> maskF, shadowF_inv = null;

            var mask = new Image<Bgra, byte>(outdir + slidePrefix + maskSlide + ".png");
            maskF = mask.Convert<Bgra, double>() / 255;
            mask.Dispose();

            if (shadowSlide > 0)
            {
                var shadow = new Image<Bgra, byte>(outdir + slidePrefix + shadowSlide + ".png");
                var shadowF = shadow.Convert<Bgra, double>() / 255;
                shadowF_inv = 1 - shadowF;
                shadowF_inv[3] += 1;
                shadow.Dispose();
            }

            foreach (var slide in slideList)
            {

                var content = new Image<Bgra, byte>(outdir + slidePrefix + slide + ".png");
                var contentF = content.Convert<Bgra, double>() / 255;
                content.Dispose();
                contentF = contentF.Mul(maskF);
                if (shadowSlide > 0)
                {
                    contentF[3] = shadowF_inv[0] + maskF[0];
                }
                else
                {
                    contentF[3] = maskF[0];
                }
                (contentF * 255).Save(outdir + "Banner_" + slidePrefix + slide + ".png");

                contentF.Dispose();
            }
            maskF.Dispose();
            if (shadowF_inv != null) { shadowF_inv.Dispose(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxResolution.SelectedIndex = 1;
        }
    }
}
