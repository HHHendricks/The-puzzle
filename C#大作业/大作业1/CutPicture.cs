using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大作业1
{
    class CutPicture
    {
        public static string path = "";
        public static List<Bitmap> BitmapList = null;


        /*
         将压缩之后的图片保存到.exe文件目录下的Picture文件夹中
         path是路径
         Width是宽度
         Height是高度
         */
        public static System.Drawing.Image Resize(string path, int Width, int Height)
        {
            Image thumbnail = null;
            try
            {
                var img = Image.FromFile(path);
                thumbnail = img.GetThumbnailImage(Width, Height, null, IntPtr.Zero);
                //thumbnail.Save(Application.StartupPath.ToString() + "\\Picture\\img.jpeg");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return thumbnail;
        }

        public static Bitmap Cut(Image b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }
            if (StartX + iWidth > w)        //求当前图片块到最右侧的距离
            {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }
    }
}
