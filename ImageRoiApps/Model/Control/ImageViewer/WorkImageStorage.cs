﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace ClipXmlReader.Model.Control.ImageViewer
{
    public class WorkImageStorage
    {

        protected BitmapImage _baseimage = null;
        public BitmapImage BaseImage
        {
            get
            {
                return _baseimage;
            }
        }


        public void LoadImage(string filepath)
        {
            /*
            if (_baseimage != null)
            {
                _baseimage.Dispose();
            }
            */

            _baseimage = new BitmapImage( new Uri(filepath));
        }



    }
}
