using System;
using System.Drawing;

namespace KnitupFramework.Drawing
{

    public static class DrawingUtility
    {

        public static Image CreateThumbnail(String iFullPath, 
            Int32 iMaxWidth, 
            Int32 iMaxHeight,
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
                        pDblRatio = (Double)pBmpRescaled.Width / pImgImage.Width;
                    }
                    else
                    {
                        pDblRatio = (Double)pBmpRescaled.Height / pImgImage.Height;
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

    }

}
