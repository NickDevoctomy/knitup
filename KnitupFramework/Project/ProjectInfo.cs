using KnitupFramework.Extensions;
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

    public class ProjectInfo : INotifyPropertyChanged
    {

        #region public events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private objects

        private Image cImgCompanyLogo;
        private Image cImgBackgroundImage;

        #endregion

        #region public properties

        public Image CompanyLogo
        {
            get
            {
                return (cImgCompanyLogo);
            }
            set
            {
                if(cImgCompanyLogo != value)
                {
                    cImgCompanyLogo = value;
                    NotifyPropertyChanged("CompanyLogo");
                }
            }
        }

        public Image BackgroundImage
        {
            get
            {
                return (cImgBackgroundImage);
            }
            set
            {
                if (cImgBackgroundImage != value)
                {
                    cImgBackgroundImage = value;
                    NotifyPropertyChanged("BackgroundImage");
                }
            }
        }

        #endregion

        #region public methods

        public void Load(ZipArchive iArchive)
        {
            ZipArchiveEntry pZAELogo = iArchive.GetEntry("logo.jpg");
            if(pZAELogo != null)
            {
                using (Stream pStmLogo = pZAELogo.Open())
                {
                    CompanyLogo = Image.FromStream(pStmLogo);
                }
            }

            ZipArchiveEntry pZAEBackground = iArchive.GetEntry("background.jpg");
            if (pZAEBackground != null)
            {
                using (Stream pStmBackgroundImage = pZAEBackground.Open())
                {
                    BackgroundImage = Image.FromStream(pStmBackgroundImage);
                }
            }
        }

        public async Task Save(ZipArchive iArchive)
        {
            if(CompanyLogo != null)
            {
                ZipArchiveEntry pZAELogo = iArchive.CreateEntry("logo.jpg", CompressionLevel.Optimal);
                using (Stream pStmLogo = pZAELogo.Open())
                {
                    await CompanyLogo.ToStreamMaxJPEGAsync(pStmLogo);
                    await pStmLogo.FlushAsync();
                }
            }

            if(BackgroundImage != null)
            {
                ZipArchiveEntry pZAEBackground = iArchive.CreateEntry("background.jpg", CompressionLevel.Optimal);
                using (Stream pStmBackgroundImage = pZAEBackground.Open())
                {
                    await BackgroundImage.ToStreamMaxJPEGAsync(pStmBackgroundImage);
                    await pStmBackgroundImage.FlushAsync();
                }
            }
        }

        #endregion

        #region private methods

        private void NotifyPropertyChanged(String iPropertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChangedEventArgs pArgArgs = new PropertyChangedEventArgs(iPropertyName);
                PropertyChanged(this, pArgArgs);
            }
        }

        #endregion

    }

}
