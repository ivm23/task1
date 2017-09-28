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

namespace DigDes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap bmp_for_draw;
     
        private void LoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bmp_for_draw = new Bitmap(open_dialog.FileName);
                    pictureBox1.ClientSize = new Size(bmp_for_draw.Width, bmp_for_draw.Height);
                    pictureBox1.Image = bmp_for_draw;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Impossible to open selected file",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
            var wightPicture = bmp_for_draw.Width;
            var heightPicture = bmp_for_draw.Height;
            string writePath = @"..\..\..\resultConversionPictureToASCII.txt";
            StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);
            char[] ascii = new char[] { '#', '@', '%', '^', '&', '*', '+', '/', '\\', '|', '~' };

           
            for (int j = 0; j < heightPicture; ++j)
            {
                for (int i = 0; i < wightPicture; ++i)
                {
                    Color color = bmp_for_draw.GetPixel(i, j);
                    int sb = (int)(color.GetBrightness() * 10);
                    sw.Write(ascii[sb]);
                }
                sw.WriteLine();
            }
        }
    }
}