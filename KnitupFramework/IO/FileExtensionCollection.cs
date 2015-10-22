using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.IO
{

    public class FileExtensionCollection
    {

        #region public constants

        public static FileExtensionCollection EXTENSION_COLLECTION_IMAGE_ALL
        {
            get
            {
                Dictionary<String, FileExtension> pDicExtensions = new Dictionary<String, FileExtension>();
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_BMP.Extension, FileExtension.EXTENSION_IMAGE_BMP);
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_EMF.Extension, FileExtension.EXTENSION_IMAGE_EMF);
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_GIF.Extension, FileExtension.EXTENSION_IMAGE_GIF);
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_JPEG.Extension, FileExtension.EXTENSION_IMAGE_JPEG);
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_JPG.Extension, FileExtension.EXTENSION_IMAGE_JPG);
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_PNG.Extension, FileExtension.EXTENSION_IMAGE_PNG);
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_TIFF.Extension, FileExtension.EXTENSION_IMAGE_TIFF);
                pDicExtensions.Add(FileExtension.EXTENSION_IMAGE_WMF.Extension, FileExtension.EXTENSION_IMAGE_WMF);
                return (new FileExtensionCollection("Images", "All Suppoprted Image Types", pDicExtensions));
            }
        }

        public static FileExtensionCollection EXTENSION_COLLECTION_KNITUP_PROJECT
        {
            get
            {
                Dictionary<String, FileExtension> pDicExtensions = new Dictionary<String, FileExtension>();
                pDicExtensions.Add(FileExtension.EXTENSION_KNITUP_PROJECT.Extension, FileExtension.EXTENSION_KNITUP_PROJECT);
                return (new FileExtensionCollection("Projects", "All Suppoprted Project Types", pDicExtensions));
            }
        }

        public static FileExtensionCollection EXTENSION_COLLECTION_IMPORT_DOCUMENT
        {
            get
            {
                Dictionary<String, FileExtension> pDicExtensions = new Dictionary<String, FileExtension>();
                pDicExtensions.Add(FileExtension.EXTENSION_DOCUMENT_MARKDOWN.Extension, FileExtension.EXTENSION_DOCUMENT_MARKDOWN);
                return (new FileExtensionCollection("Documents", "All Suppoprted Document Types", pDicExtensions));
            }
        }


        #endregion

        #region public properties

        public String Name { get; private set; }

        public String Description { get; private set; }

        public Dictionary<String, FileExtension> Extensions { get; private set; }

        #endregion

        #region constructor / destructor

        public FileExtensionCollection(String iName,
            String iDescription,
            Dictionary<String, FileExtension> iExtensions)
        {
            Name = iName;
            Description = iDescription;
            Extensions = iExtensions;
        }

        #endregion

    }

}
