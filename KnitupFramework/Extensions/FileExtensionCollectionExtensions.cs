using KnitupFramework.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnitupFramework.Extensions
{

    public static class FileExtensionCollectionExtensions
    {

        #region public methods

        public static String GetFilterString(this FileExtensionCollection iExtensionCollection,
            Boolean iIncludeAllSupported,
            Boolean iIncludeAllFiles)
        {
            return (FileExtensionUtility.GetFileExtensionFilterString(iExtensionCollection,
                iIncludeAllSupported,
                iIncludeAllFiles));
        }

        public static FileExtensionCollection GetExtensionGroup(this FileExtensionCollection iExtensionCollection,
            FileExtensionGroup iGroup)
        {
            Dictionary<String, FileExtension> pDicExtensions = new Dictionary<String, FileExtension>();
            foreach(FileExtension curExtension in iExtensionCollection.Extensions.Values)
            {
                if(curExtension.Group == iGroup)
                {
                    pDicExtensions.Add(curExtension.Extension, curExtension);
                }
            }
            FileExtensionCollection pFECGroup = new FileExtensionCollection(iGroup.Name, iGroup.Description, pDicExtensions);
            return (pFECGroup);
        }

        #endregion

    }

}
