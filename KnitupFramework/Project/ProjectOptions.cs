using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

    public class ProjectOptions : INotifyPropertyChanged
    {

        #region public events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private objects

        private String cStrCopyrightMessage = String.Empty;

        #endregion

        #region public properties

        public String CopyrightMessage
        {
            get
            {
                return (cStrCopyrightMessage);
            }
            set
            {
                if(cStrCopyrightMessage != value)
                {
                    cStrCopyrightMessage = value;
                    NotifyPropertyChanged("CopyrightMessage");
                }
            }
        }

        #endregion

        #region public methods

        public JObject ToJSON()
        {
            JObject pJOtJSON = new JObject();

            pJOtJSON.Add("CopyrightMessage", new JValue(CopyrightMessage));

            return (pJOtJSON);
        }

        public void Load(ZipArchive iArchive)
        {
            ZipArchiveEntry pZAEOptions = iArchive.GetEntry("options.json");
            if (pZAEOptions != null)
            {
                using (Stream pStmOptions = pZAEOptions.Open())
                {
                    using(StreamReader pSRrReader = new StreamReader(pStmOptions, Encoding.UTF8, false))
                    {
                        JsonTextReader pJTRReader = new JsonTextReader(pSRrReader);
                        JObject pJOtOptions = JObject.Load(pJTRReader);

                        CopyrightMessage = pJOtOptions["CopyrightMessage"].Value<String>();
                    }
                }
            }
        }

        public async Task Save(ZipArchive iArchive)
        {
            ZipArchiveEntry pZAEOptions = iArchive.CreateEntry("options.json", CompressionLevel.Optimal);
            using (Stream pStmOptions = pZAEOptions.Open())
            {
                JObject pJOtOptions = ToJSON();
                Byte[] pBytOptions = System.Text.Encoding.UTF8.GetBytes(pJOtOptions.ToString());
                await pStmOptions.WriteAsync(pBytOptions, 0, pBytOptions.Length);
                await pStmOptions.FlushAsync();
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
