using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace DTO_
{
    public class ImageIO 
    {
        //Method to load a file
        public Bitmap readFile()
        {
            Bitmap file = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            //Filter image types accepted
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                file = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();
            }
            return file;
        }

        //Method to save a file
        public void writeFile(Bitmap bitmap)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Specify a file name and file path";
            //Filter image types accepted
            sfd.Filter = "Png Images(.png)|.png|Jpeg Images(.jpg)|.jpg|Bitmap Images(.bmp)|.bmp";

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
                bitmap.Save(streamWriter.BaseStream, imgFormat);
                streamWriter.Flush();
                streamWriter.Close();

                bitmap = null;
            }
        }
    }
}
