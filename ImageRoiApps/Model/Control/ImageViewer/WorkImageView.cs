using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

using System.Runtime.InteropServices;

namespace ClipXmlReader.Model.Control.ImageViewer
{


    public class WorkImageView
    {


        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);



        protected WorkImageStorage _storage_object;

        public WorkImageStorage StorageObject
        {
            get
            {
                return _storage_object;
            }
        }

        public WorkImageView(WorkImageStorage storage)
        {
            _storage_object = storage;
        }


#if NETFRAMEWORK
        Bitmap _holding_viewimage;
        public Image HoldingViewImage
        {
            get
            {
                return _holding_viewimage;
            }
        }

        
        public BitmapSource HoldingViewImageSource
        {
            get
            {
                IntPtr source = _holding_viewimage.GetHbitmap();
                var imagesource = Imaging.CreateBitmapSourceFromHBitmap(source,
                                  IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                DeleteObject(source);

                return imagesource;
            }
        }
#else
        BitmapImage _holding_viewimage;
        public BitmapImage HoldingViewImage
        {
            get
            {
                return _holding_viewimage;
            }
        }


        public BitmapSource HoldingViewImageSource
        {
            get
            {
                return null;
            }
        }
#endif


        public void ResampleViewImage(double rate)
        {

#if NETFRAMEWORK
            if( _holding_viewimage != null)
            {
                _holding_viewimage.Dispose();
                _holding_viewimage = null;
            }

            int width = (int)(_storage_object.BaseImage.Width / rate + 0.5);
            int height = (int)(_storage_object.BaseImage.Height / rate + 0.5);

            Bitmap newbitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(newbitmap);
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(_storage_object.BaseImage, 0, 0, width, height);
            g.Dispose();
            _holding_viewimage = newbitmap;
#else

#endif
        }
    }
}
