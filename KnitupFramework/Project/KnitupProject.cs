using KnitupFramework.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.Project
{

    public class KnitupProject : INotifyPropertyChanged
    {

        #region public events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private objects

        private String cStrFullPath = String.Empty;
        private String cStrMarkdownSource = String.Empty;
        private ProjectInfo cPIoInfo;
        private ProjectOptions cPOsOptions;
        private ProjectImages cPIsImages;
        private Boolean cBlnIsDirty = true;

        #endregion

        #region public properties

        public String FullPath
        {
            get { return (cStrFullPath); }
        }


        public String MarkdownSource
        {
            get
            {
                return (cStrMarkdownSource);
            }
            set
            {
                if(cStrMarkdownSource != value)
                {
                    cStrMarkdownSource = value;
                    if(!cBlnIsDirty)
                    {
                        //increment version number here
                        cBlnIsDirty = true;
                    }
                    NotifyPropertyChanged("MarkdownSource");
                }
            }
        }

        public ProjectInfo Info
        {
            get { return (cPIoInfo); }
        }

        public ProjectOptions Options
        {
            get { return (cPOsOptions); }
        }

        public ProjectImages Images
        {
            get { return (cPIsImages); }
        }

        public Boolean IsDirty
        {
            get { return (cBlnIsDirty); }
        }

        #endregion

        #region constructor / destructor

        public KnitupProject()
        {
            cPIoInfo = new ProjectInfo();
            cPIoInfo.PropertyChanged += CPIoInfo_PropertyChanged;

            cPOsOptions = new ProjectOptions();
            cPOsOptions.PropertyChanged += CPOsOptions_PropertyChanged;

            cPIsImages = new ProjectImages();
            cPIsImages.PropertyChanged += CPIsImages_PropertyChanged;
        }

        #endregion

        #region public methods

        public static async Task<KnitupProject> Load(String iFullPath)
        {
            using (FileStream pFSmArchive = File.Open(iFullPath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (ZipArchive pZAeArchive = new ZipArchive(pFSmArchive, ZipArchiveMode.Read, true))
                {
                    KnitupProject pKPtProject = new KnitupProject();

                    pKPtProject.cStrFullPath = iFullPath;

                    ZipArchiveEntry pZAESource = pZAeArchive.GetEntry("input.md");
                    using (Stream pStmSource = pZAESource.Open())
                    {
                        using (MemoryStream pMSmSource = new MemoryStream())
                        {
                            await pStmSource.CopyToAsync(pMSmSource);
                            pKPtProject.cStrMarkdownSource = System.Text.Encoding.UTF8.GetString(pMSmSource.ToArray());
                        }
                    }

                    pKPtProject.Info.Load(pZAeArchive);
                    pKPtProject.Options.Load(pZAeArchive);
                    pKPtProject.Images.Load(pZAeArchive);

                    return (pKPtProject);
                }
            }
        }

        public async Task Save(String iFullPath, Boolean iClean = true)
        {
            using (FileStream pFSmArchive = File.Open(iFullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (ZipArchive pZAeArchive = new ZipArchive(pFSmArchive, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry pZAESource = pZAeArchive.CreateEntry("input.md", CompressionLevel.Optimal);
                    using (Stream pStmSource = pZAESource.Open())
                    {
                        using (MemoryStream pMSmSource = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(MarkdownSource)))
                        {
                            await pMSmSource.CopyToAsync(pStmSource);
                        }
                    }

                    await Info.Save(pZAeArchive);
                    await Options.Save(pZAeArchive);
                    await Images.Save(pZAeArchive);

                    if(iClean) cBlnIsDirty = false;
                    cStrFullPath = iFullPath;
                }
            }
        }

        public Generator CreateWordGenerator()
        {
            return (new Generator(this));
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

        #region object events

        private void CPIoInfo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            cBlnIsDirty = true;
            NotifyPropertyChanged("Info");
        }

        private void CPOsOptions_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            cBlnIsDirty = true;
            NotifyPropertyChanged("Options");
        }

        private void CPIsImages_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            cBlnIsDirty = true;
            NotifyPropertyChanged("Images");
        }

        #endregion

    }

}
