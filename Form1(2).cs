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


        private void FromCMYKtoRGB()
        {
            float r, g, b;
            float c = float.Parse(txtCyanVal.Text) / 100;
            float m = float.Parse(txtMagentaVal.Text) / 100;
            float y = float.Parse(txtYellowVal.Text) / 100;
            float k = float.Parse(txtKeyVal.Text) / 100;

            r = (255 * (1 - c) * (1 - k));
            g = (255 * (1 - m) * (1 - k));
            b = (255 * (1 - y) * (1 - k));

            rgbVal.Text = "R:" + Math.Truncate(r).ToString() + "G:" + Math.Truncate(g).ToString() + "B:" + Math.Truncate(b).ToString();
            txtRedVal.Text = Math.Truncate(r).ToString();
            txtGreenVal.Text = Math.Truncate(g).ToString();
            txtBlueVal.Text = Math.Truncate(b).ToString();
        }

        private void FromHSVtoRGB()
        {
            float r, g, b;
            float h = float.Parse(txtHueVal.Text) / 360f;
            float s = float.Parse(txtSaturationVal.Text) / 100;
            float v = float.Parse(txtValueVal.Text) / 100;

            if (s == 0)
            {
                r = g = b = v;
            }

            else
            {
                float i = (float)Math.Floor(h * 6);
                float f = h * 6 - i;
                float p = v * (1 - s);
                float q = v * (1 - f * s);
                float t = v * (1 - (1 - f) * s);

                i = i % 6;

                switch ((int)i)
                {
                    case 0: r = v; g = t; b = p; break;
                    case 1: r = q; g = v; b = p; break;
                    case 2: r = p; g = v; b = t; break;
                    case 3: r = p; g = q; b = v; break;
                    case 4: r = t; g = p; b = v; break;
                    case 5: r = v; g = p; b = q; break;
                    default: r = g = b = 0; break;
                }
            }

            r = r * 100;
            g = g * 100;
            b = b * 100;
            rgbVal.Text = "R:" + Math.Truncate(r).ToString() + "G:" + Math.Truncate(g).ToString() + "B:" + Math.Truncate(b).ToString();
            txtRedVal.Text = Math.Truncate(r).ToString();
            txtGreenVal.Text = Math.Truncate(g).ToString();
            txtBlueVal.Text = Math.Truncate(b).ToString();
        }
        private void ChangeColor(object sender, EventArgs e)
        {
            Color clr = new Color();
            clr = Color.FromArgb(Convert.ToInt32(txtRedVal.Text), Convert.ToInt32(txtGreenVal.Text), Convert.ToInt32(txtBlueVal.Text));

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

            rgbVal.Text = "R:" + clr.R.ToString() + "G:" + clr.G.ToString() + "B:" + clr.B.ToString();
            txtHueVal.Text = Math.Truncate(clr.GetHue()).ToString();
            txtSaturationVal.Text = Math.Truncate(clr.GetSaturation() * 100).ToString();
            txtValueVal.Text = Math.Truncate(clr.GetBrightness() * 200).ToString();
            pnlSmallScreen.BackColor = clr;
            pnlSelectedCol.BackColor = clr;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeColor(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FromHSVtoRGB();
            int r = int.Parse(txtRedVal.Text);
            int g = int.Parse(txtGreenVal.Text);
            int b = int.Parse(txtBlueVal.Text);
            if (r > 255 || r < 0 || g > 255 || g < 0 || b > 255 || b < 0)
            {
                DialogResult result = MessageBox.Show(
            "OUT OF RANGE",
            "WARNING",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
                r = 0;
                g = 0;
                b = 0;
                rgbVal.Text = "R:" + r.ToString() + "G:" + g.ToString() + "B:" + b.ToString();
                txtRedVal.Text = r.ToString();
                txtGreenVal.Text = g.ToString();
                txtBlueVal.Text = b.ToString();
            }

            ChangeColor(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FromCMYKtoRGB();
            int r = int.Parse(txtRedVal.Text);
            int g = int.Parse(txtGreenVal.Text);
            int b = int.Parse(txtBlueVal.Text);
            if (r > 255 || r < 0 || g > 255 || g < 0 || b > 255 || b < 0)
            {
                DialogResult result = MessageBox.Show(
            "OUT OF RANGE",
            "WARNING",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
                r = 0;
                g = 0;
                b = 0;
                rgbVal.Text = "R:" + r.ToString() + "G:" + g.ToString() + "B:" + b.ToString();
                txtRedVal.Text = r.ToString();
                txtGreenVal.Text = g.ToString();
                txtBlueVal.Text = b.ToString();
            }
            ChangeColor(sender, e);
        }
    }
}
