using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MyVideoExplorer
{
    class MyImage
    {

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static bool SaveJpgImage(Image sourceImage, string targetPath, long quality=90L) 
        {
	        bool ret = false;
            try
            {
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                EncoderParameters imageEncoderParameters = new EncoderParameters(1);
                EncoderParameter imageEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                imageEncoderParameters.Param[0] = imageEncoderParameter;

                sourceImage.Save(targetPath, jgpEncoder, imageEncoderParameters);
                ret = true;
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }
            if (sourceImage != null)
            {
                sourceImage.Dispose();
            }
            return ret;
        }

        public static Image GetThumbnail(string sourcePath, int canvasWidth, int canvasHeight, Color canvasBackColor)
        {
	        bool error;
	
	        error = true;
	        Image sourceImage = null;
	        Image thumbnailImage = null;
	        Graphics graphic = null;

	        // load the source image	
	        try 
	        {
		        sourceImage = Image.FromFile(sourcePath);
		        error = false;
	        }
	        catch (OutOfMemoryException) 
	        {
                // meh, Image.FromFile will throw this if file is invalid/corrupted
                MyLog.Add("Invalid Image; Unable to read " + sourcePath);
                sourceImage = null;
	        }	
	        catch (Exception ei) 
	        {
		        MyLog.Add(ei.ToString());
	        }

	        if (!error)
	        {

		        int sourceWidth = sourceImage.Width;
		        int sourceHeight = sourceImage.Height;
			
		        // create the canvas for thumbnail image
		        error = true;
		        try
		        {
			        // thumbnailImage = new Bitmap(canvasWidth, canvasHeight, PixelFormat.Format24bppRgb);
			        thumbnailImage = new Bitmap(canvasWidth, canvasHeight);			

			        // thumbnailImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);			
			        error = false;
		        }
		        catch (Exception et) 
		        {
			        MyLog.Add(et.ToString());		
		        }	

		        if (!error)
		        {
			        // figure out the ratio
			        double ratioWidth = (double) canvasWidth / (double) sourceWidth;
			        double ratioHeight = (double) canvasHeight / (double) sourceHeight;
			        // use whichever multiplier is smaller
			        double ratio = ratioWidth < ratioHeight ? ratioWidth : ratioHeight;
			
			        // get the new thumbnail height and width    
			        int thumbnailWidth = Convert.ToInt32(sourceWidth * ratio);
			        int thumbnailHeight = Convert.ToInt32(sourceHeight * ratio);

			        // calculate the X,Y position of the upper-left corner (one of these will always be zero)
			        int thumbnailPosX = Convert.ToInt32((canvasWidth - (sourceWidth * ratio)) / 2);
			        int thumbnailPosY = Convert.ToInt32((canvasHeight - (sourceHeight * ratio)) / 2);

			        // resize image to thumbnail
			        error = true;
			        try 
			        {				
				        graphic = Graphics.FromImage(thumbnailImage);

				        // quality of thumbnail
				        graphic.CompositingQuality = CompositingQuality.HighQuality;
				        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;			
				        graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
				        graphic.SmoothingMode = SmoothingMode.HighQuality;
				
				        // back color
				        graphic.Clear(canvasBackColor);
				
				        // create thumbnail from source
				        graphic.DrawImage(sourceImage, thumbnailPosX, thumbnailPosY, thumbnailWidth, thumbnailHeight);
				        error = false;
			        }
			        catch (Exception et) 
			        {
				        MyLog.Add(et.ToString());		
			        }	

			        if (!error)
			        {
				        // all looks good
			        }
		        }
	        }
	
	        // dispose of objects used to create thumbnail
	        if (sourceImage != null) 
	        {
		        sourceImage.Dispose();				
	        }
	        if (graphic != null) 
	        {
		        graphic.Dispose();				
	        }
		
	        if (!error) 
	        {
		        // all looks good, return thumbnail
		        return thumbnailImage;
	        }
	        else
	        {
		        if (thumbnailImage != null) 
		        {
			        thumbnailImage.Dispose();				
		        }		
		        return null;
	        }
        }

        public static Image GetImageFromFile(string filePath)
        {
            Image image = null;
            try 
            {
                // image = Image.FromFile(filePath); // nopes locks

                // make copy of image so doesnt lock image, dir, etc
                byte[] bytes = File.ReadAllBytes(filePath);
                MemoryStream memoryStream = new MemoryStream(bytes);
                image = Image.FromStream(memoryStream);
                
            }
            catch (OutOfMemoryException)
            {
                // meh, Image.FromFile will throw this if file is invalid/corrupted
                MyLog.Add("Invalid Image; Unable to read " + filePath);
                image = null;
            }
            catch (Exception ei)
            {
                MyLog.Add(ei.ToString());
                image = null;
            }
            return image;
        }
    }
}
