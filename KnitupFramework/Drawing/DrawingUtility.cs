using System;
using System.Drawing;

namespace KnitupFramework.Drawing
{

    public static class DrawingUtility
    {

        public static System.Drawing.Image ResizeImage(String iFullPath,
            int Width,
            int Height,
            bool needToFill)
        {
            using (Image pImgOriginal = Image.FromFile(iFullPath))
            {
                return (ResizeImage(pImgOriginal,
                    Width,
                    Height,
                    needToFill));
            }
        }

        public static System.Drawing.Image ResizeImage(Image iImage, 
            Int32 iWidth,
            Int32 iHeight, 
            Boolean iNeedToFill)
        {
            Int32 pIntSourceWidth = iImage.Width;
            Int32 pIntSourceHeight = iImage.Height;
            Int32 pIntSourceX = 0;
            Int32 pIntSourceY = 0;
            Double pDblDestX = 0;
            Double pDblDestY = 0;
            Double pDblNScale = 0;
            Double pDblNScaleW = 0;
            Double pDblNScaleH = 0;

            pDblNScaleW = ((Double)iWidth / (Double)pIntSourceWidth);
            pDblNScaleH = ((Double)iHeight / (Double)pIntSourceHeight);
            if (!iNeedToFill)
            {
                pDblNScale = Math.Min(pDblNScaleH, pDblNScaleW);
            }
            else
            {
                pDblNScale = Math.Max(pDblNScaleH, pDblNScaleW);
                pDblDestY = (iHeight - pIntSourceHeight * pDblNScale) / 2;
                pDblDestX = (iWidth - pIntSourceWidth * pDblNScale) / 2;
            }

            if (pDblNScale > 1)
                pDblNScale = 1;

            Int32 pIntDestWidth = (int)Math.Round(pIntSourceWidth * pDblNScale);
            Int32 pIntDestHeight = (int)Math.Round(pIntSourceHeight * pDblNScale);

            Bitmap pBmpBuffer = new System.Drawing.Bitmap(pIntDestWidth + (int)Math.Round(2 * pDblDestX), pIntDestHeight + (int)Math.Round(2 * pDblDestY));
            using (Graphics pGraBuffer = Graphics.FromImage(pBmpBuffer))
            {
                pGraBuffer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                pGraBuffer.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                pGraBuffer.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                pGraBuffer.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                Rectangle pRecDest = new Rectangle((int)Math.Round(pDblDestX), (int)Math.Round(pDblDestY), pIntDestWidth, pIntDestHeight);
                Rectangle pRecSource = new Rectangle(pIntSourceX, pIntSourceY, pIntSourceWidth, pIntSourceHeight);
                pGraBuffer.DrawImage(iImage, pRecDest, pRecSource, GraphicsUnit.Pixel);

                return(pBmpBuffer);
            }
        }

        public static Image CreateThumbnail(String iFullPath, 
            Int32 iMaxWidth, 
            Int32 iMaxHeight,
            Int32 iMargin,
            Color iBackingColour)
        {
            Image pImgImage = Image.FromFile(iFullPath);
            Bitmap pBmpRescaled = new Bitmap(iMaxWidth, iMaxHeight);
            using (pImgImage)
            {
                using (Graphics pGraRescaled = Graphics.FromImage(pBmpRescaled))
                {
                    pGraRescaled.Clear(iBackingColour);

                    Double pDblRatio = 0;
                    if (pImgImage.Width > pImgImage.Height)
                    {
                        pDblRatio = (Double)(pBmpRescaled.Width - iMargin) / pImgImage.Width;
                    }
                    else
                    {
                        pDblRatio = (Double)(pBmpRescaled.Height - iMargin) / pImgImage.Height;
                    }
                    Double pDblRescaledWidth = pImgImage.Width * pDblRatio;
                    Double pDblRescaledHeight = pImgImage.Height * pDblRatio;
                    Double pDblXPos = (pBmpRescaled.Width / 2 - pDblRescaledWidth / 2);
                    Double pDblYPos = (pBmpRescaled.Height / 2 - pDblRescaledHeight / 2);

                    pGraRescaled.DrawImage(pImgImage,
                        new Rectangle((Int32)pDblXPos, (Int32)pDblYPos, (Int32)pDblRescaledWidth, (Int32)pDblRescaledHeight),
                        new Rectangle(0, 0, pImgImage.Width, pImgImage.Height),
                        GraphicsUnit.Pixel);
                }
            }
            return (pBmpRescaled);
        }

        public static Image LowQualityScaledThumbnail(Image iImage,
            Int32 iMaxWidth,
            Int32 iMaxHeight)
        {
            Double pDblRatio = 0;
            if (iImage.Width > iImage.Height)
            {
                pDblRatio = (Double)iMaxWidth / iImage.Width;
            }
            else
            {
                pDblRatio = (Double)iMaxHeight / iImage.Height;
            }
            Double pDblRescaledWidth = iImage.Width * pDblRatio;
            Double pDblRescaledHeight = iImage.Height * pDblRatio;
            return (iImage.GetThumbnailImage((Int32)pDblRescaledWidth, (Int32)pDblRescaledHeight, null, IntPtr.Zero));
        }

    }

}
