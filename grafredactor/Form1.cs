using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafredactor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FileInfo fn;
        string newpath;
        Bitmap bmp;


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;

                bmp = new Bitmap(Image.FromFile(dialog.FileName), width, height);

                pictureBox1.Image = bmp;
            }


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Pen blackPen = new Pen(Color.Red, 5);
            blackPen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;

            int X = e.X;
            int Y = e.Y;

            Graphics g = Graphics.FromImage(pictureBox1.Image);

            Point to4ka1 = new Point(X, Y);
            Point to4ka2 = new Point(X, Y + 1);


            if (e.Button == MouseButtons.Left)
            {
               // g.FillEllipse(Brushes.Black, e.X, e.Y, 1, 1);
                g.DrawLine(blackPen, to4ka1, to4ka2);
            }


            //g.DrawLine(blackPen, e.X, e.Y, e.X, e.Y);

             blackPen.Dispose();
             g.Dispose();

            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            // If selected, save
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // Get the user-selected file name
                string fileName = savedialog.FileName;
                // Get the extension
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                // Save file
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
