using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace Ekran_Görüntüsü_Alma
{
    public partial class Form1 : Form
    {
        #region Değişkenler

        ImageFormat image; 
        Bitmap btm; 
        Graphics ssal;
        
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                Thread.Sleep(600);
                btm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                ssal = Graphics.FromImage(btm);
                ssal.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                switch (saveFileDialog1.FilterIndex)
                {
                    case 0: image = ImageFormat.Bmp; break;
                    case 1: image = ImageFormat.Png; break;
                    case 2: image = ImageFormat.Jpeg; break;
                }

                btm.Save(saveFileDialog1.FileName, image);
                this.Show();
            }
        }
    }
}
