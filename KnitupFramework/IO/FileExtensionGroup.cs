using System;

namespace KnitupFramework.IO
{

    public class FileExtensionGroup
    {

        #region public constants

        public static readonly FileExtensionGroup EXTENSION_GROUP_IMAGE_JPG = new FileExtensionGroup("JPG", "Joint Photographic Group Images");

        #endregion

        #region public properties


        public String Name { get; private set; }

        public String Description { get; private set; }

        #endregion

        #region constructor / destructor
        
        public FileExtensionGroup(String iName,
            String iDescription)
        {
            Name = iName;
            Description = iDescription;
        }

        #endregion

    }


}
