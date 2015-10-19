using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.Project
{

    public class ProjectImages : INotifyPropertyChanged
    {

        #region public events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private objects

        private Dictionary<String, Image> cDicImages;

        #endregion

        #region public properties

        public IReadOnlyDictionary<String, Image> Images
        {
            get { return (cDicImages); }
        }

        #endregion

        #region constructor / destructor

        public ProjectImages()
        {
            cDicImages = new Dictionary<String, Image>();
        }

        #endregion

        #region public methods

        public void AddImage(String iID,
            Image iImage)
        {
            cDicImages.Add("images\\" + iID, iImage);
            NotifyPropertyChanged("Images");
        }

        public void RemoveImage(String iID)
        {
            cDicImages.Remove(iID);
            NotifyPropertyChanged("Images");
        }

        public void Load(ZipArchive iArchive)
        {
            JObject pJOtImages = null;
            ZipArchiveEntry pZAEImages = iArchive.GetEntry("images.json");
            if (pZAEImages != null)
            {
                using (Stream pStmImages = pZAEImages.Open())
                {
                    using (StreamReader pSRrReader = new StreamReader(pStmImages, Encoding.UTF8, false, 1024, true))
                    {
                        using (JsonTextReader pJTRReader = new JsonTextReader(pSRrReader))
                        {
                            pJOtImages = JObject.Load(pJTRReader);
                        }
                    }
                }
            }

            JArray pJAyImages = pJOtImages["images"].Value<JArray>(); ;
            foreach(JValue curImage in pJAyImages)
            {
                ZipArchiveEntry pZAEImage = iArchive.GetEntry(curImage.Value<String>());
                if (pZAEImage != null)
                {
                    using (Stream pStmImage = pZAEImage.Open())
                    {
                        Image pImgImage = Image.FromStream(pStmImage);
                        cDicImages.Add(curImage.Value<String>(), pImgImage);
                    }
                }
            }
        }

        public async Task Save(ZipArchive iArchive)
        {
            JObject pJOtImages = new JObject();
            JArray pJAyImages = new JArray();
            foreach(String curImage in Images.Keys)
            {
                pJAyImages.Add(new JValue(curImage));
            }
            pJOtImages.Add("images", pJAyImages);

            ZipArchiveEntry pZAEImages = iArchive.CreateEntry("images.json", CompressionLevel.Optimal);
            using (Stream pStmImages = pZAEImages.Open())
            {
                Byte[] pBytImages = System.Text.Encoding.UTF8.GetBytes(pJOtImages.ToString());
                await pStmImages.WriteAsync(pBytImages, 0, pBytImages.Length);
                await pStmImages.FlushAsync();
            }

            foreach (String curImage in Images.Keys)
            {
                ZipArchiveEntry pZAEImage = iArchive.CreateEntry(curImage, CompressionLevel.Optimal);
                using (Stream pStmImage = pZAEImage.Open())
                {
                    Images[curImage].Save(pStmImage, System.Drawing.Imaging.ImageFormat.Jpeg);    //TODO min compression
                    await pStmImage.FlushAsync();
                }
            }
        }

        #endregion

        #region private methods

        private void NotifyPropertyChanged(String iPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs pArgArgs = new PropertyChangedEventArgs(iPropertyName);
                PropertyChanged(this, pArgArgs);
            }
        }

        #endregion

    }

}
