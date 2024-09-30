using System;
using System.Drawing;
using System.Windows.Forms;

namespace Color_Picker2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ChangeColor(object sender, MouseEventArgs e)
        {
            Bitmap pixelData = (Bitmap)picSpectrum.Image;
            Color clr = pixelData.GetPixel(Math.Abs(e.X), Math.Abs(e.Y));
            rgbVal.Text = "R:" + clr.R.ToString() + "G:" + clr.G.ToString() + "B:" + clr.B.ToString();
            txtRedVal.Text = clr.R.ToString();
            txtGreenVal.Text = clr.G.ToString();
            txtBlueVal.Text = clr.B.ToString();
            txtHueVal.Text = Math.Truncate(clr.GetHue()).ToString();
            txtSaturationVal.Text = Math.Truncate(clr.GetSaturation() * 100).ToString();
            txtValueVal.Text = Math.Truncate(clr.GetBrightness() * 200).ToString();

            double k = Math.Min(1 - clr.R / 255f, Math.Min(1 - clr.G / 255f, 1 - clr.B / 255f));

            if (k < 1)
            {
                double c = (1 - clr.R / 255f - k) / (1 - k);
                double m = (1 - clr.G / 255f - k) / (1 - k);
                double y = (1 - clr.B / 255f - k) / (1 - k);

                if (c * 100 <= 0)
                {
                    c = 0;
                }


                if (m * 100 <= 0)
                {
                    m = 0;
                }


                if (y * 100 <= 0)
                {
                    y = 0;
                }

                txtKeyVal.Text = Math.Truncate(k * 100).ToString();
                txtCyanVal.Text = Math.Truncate(c * 100).ToString();
                txtMagentaVal.Text = Math.Truncate(m * 100).ToString();
                txtYellowVal.Text = Math.Truncate(y * 100).ToString();

            }
            else
            {
                txtKeyVal.Text = "1";
                txtCyanVal.Text = "0";
                txtMagentaVal.Text = "0";
                txtYellowVal.Text = "0";
            }

            pnlSmallScreen.BackColor = clr;
            pnlSelectedCol.BackColor = clr;
        }
        private void picSpectrum_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeColor(sender, e);
        }

        private void picSpectrum_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                ChangeColor(sender, e);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Change_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                rgbVal.Text = "R:" + colorDialog1.Color.R.ToString() + "G:" + colorDialog1.Color.G.ToString() + "B:" + colorDialog1.Color.B.ToString();
                txtRedVal.Text = colorDialog1.Color.R.ToString();
                txtGreenVal.Text = colorDialog1.Color.G.ToString();
                txtBlueVal.Text = colorDialog1.Color.B.ToString();
                txtHueVal.Text = Math.Truncate(colorDialog1.Color.GetHue()).ToString();
                txtSaturationVal.Text = Math.Truncate(colorDialog1.Color.GetSaturation() * 100).ToString();
                txtValueVal.Text = Math.Truncate(colorDialog1.Color.GetBrightness() * 200).ToString();
                pnlSmallScreen.BackColor = colorDialog1.Color;
                pnlSelectedCol.BackColor = colorDialog1.Color;
                double k = Math.Min(1 - colorDialog1.Color.R / 255f, Math.Min(1 - colorDialog1.Color.G / 255f, 1 - colorDialog1.Color.B / 255f));

                if (k < 1)
                {
                    double c = (1 - colorDialog1.Color.R / 255f - k) / (1 - k);
                    double m = (1 - colorDialog1.Color.G / 255f - k) / (1 - k);
                    double y = (1 - colorDialog1.Color.B / 255f - k) / (1 - k);

                    if (c * 100 <= 0)
                    {
                        c = 0;
                    }


                    if (m * 100 <= 0)
                    {
                        m = 0;
                    }


                    if (y * 100 <= 0)
                    {
                        y = 0;
                    }

                    txtKeyVal.Text = Math.Truncate(k * 100).ToString();
                    txtCyanVal.Text = Math.Truncate(c * 100).ToString();
                    txtMagentaVal.Text = Math.Truncate(m * 100).ToString();
                    txtYellowVal.Text = Math.Truncate(y * 100).ToString();

                }
                else
                {
                    txtKeyVal.Text = "1";
                    txtCyanVal.Text = "0";
                    txtMagentaVal.Text = "0";
                    txtYellowVal.Text = "0";
                }
            }
        }
    }
}
