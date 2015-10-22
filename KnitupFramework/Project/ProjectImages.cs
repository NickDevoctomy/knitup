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
using KnitupFramework.Extensions;

namespace KnitupFramework.Project
{

    public class ProjectImages : INotifyPropertyChanged
    {

        #region public events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private objects

        private Dictionary<String, ProjectImage> cDicImages;

        #endregion

        #region public properties

        public IReadOnlyDictionary<String, ProjectImage> Images
        {
            get { return (cDicImages); }
        }

        #endregion

        #region constructor / destructor

        public ProjectImages()
        {
            cDicImages = new Dictionary<String, ProjectImage>();
        }

        #endregion

        #region public methods

        public ProjectImage AddImage(String iName,
            Image iImage)
        {
            ProjectImage pPIeImage = new ProjectImage(iName, iImage);
            cDicImages.Add(pPIeImage.ID, pPIeImage);
            NotifyPropertyChanged("Images");
            return (pPIeImage);
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
            foreach(JObject curImage in pJAyImages)
            {
                ProjectImage pPIeImage = ProjectImage.FromJSON(curImage);
                ZipArchiveEntry pZAEImage = iArchive.GetEntry(pPIeImage.ID);
                if (pZAEImage != null)
                {
                    using (Stream pStmImage = pZAEImage.Open())
                    {
                        pPIeImage.Image = Image.FromStream(pStmImage);
                        cDicImages.Add(pPIeImage.ID, pPIeImage);
                    }
                }
            }
        }

        public async Task Save(ZipArchive iArchive)
        {
            JObject pJOtImages = new JObject();
            JArray pJAyImages = new JArray();
            foreach(ProjectImage curImage in Images.Values)
            {
                pJAyImages.Add(curImage.ToJSON());
            }
            pJOtImages.Add("images", pJAyImages);

            ZipArchiveEntry pZAEImages = iArchive.CreateEntry("images.json", CompressionLevel.Optimal);
            using (Stream pStmImages = pZAEImages.Open())
            {
                Byte[] pBytImages = System.Text.Encoding.UTF8.GetBytes(pJOtImages.ToString());
                await pStmImages.WriteAsync(pBytImages, 0, pBytImages.Length);
                await pStmImages.FlushAsync();
            }

            foreach (ProjectImage curImage in Images.Values)
            {
                ZipArchiveEntry pZAEImage = iArchive.CreateEntry(curImage.ID, CompressionLevel.Optimal);
                using (Stream pStmImage = pZAEImage.Open())
                {
                    await curImage.Image.ToStreamMaxJPEGAsync(pStmImage);
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
