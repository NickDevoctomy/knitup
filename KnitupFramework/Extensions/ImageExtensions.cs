using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace KnitupFramework.Extensions
{

    public static class ImageExtensions
    {

        #region private methods

        private static ImageCodecInfo GetEncoder(ImageFormat iFormat)
        {
            ImageCodecInfo[] pICICodecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo curCodec in pICICodecs)
            {
                if (curCodec.FormatID == iFormat.Guid)
                {
                    return (curCodec);
                }
            }
            return null;
        }

        #endregion

        #region public methods

        public async static Task ToStreamMaxJPEGAsync(this Image iImage,
            Stream iStream)
        {
            using (EncoderParameters pEPsParams = new EncoderParameters(1))
            {
                EncoderParameter pEPrParam = new EncoderParameter(Encoder.Quality, 100L);
                pEPsParams.Param[0] = pEPrParam;
                using (Bitmap pBmpCopy = new Bitmap(iImage))
                {
                    pBmpCopy.Save(iStream, GetEncoder(ImageFormat.Jpeg), pEPsParams);
                }
                await iStream.FlushAsync();
            }
        }

        #endregion

    }

}
