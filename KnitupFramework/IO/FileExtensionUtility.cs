using KnitupFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnitupFramework.IO
{

    public static class FileExtensionUtility
    {

        #region public methods

        public static String GetFileExtensionFilterString(FileExtensionCollection iExtensionCollection,
            Boolean iIncludeAllSupported, 
            Boolean iIncludeAddWildcard)
        {
            List<FileExtensionGroup> pLisProcessedGroups = new List<FileExtensionGroup>();

            StringBuilder pSBrIndividualExtensions = new StringBuilder();
            StringBuilder pSBrAllExtensionsListed = new StringBuilder();
            foreach(FileExtension curExtension in iExtensionCollection.Extensions.Values)
            {
                pSBrAllExtensionsListed.Append(String.Format("*.{0};", curExtension.Extension));
                if(curExtension.Group == null)
                {
                    pSBrIndividualExtensions.Append(String.Format("{0} (*.{1})|*.{1}|", curExtension.ShortDescription, curExtension.Extension));
                }
                else
                {
                    if (!pLisProcessedGroups.Contains(curExtension.Group))
                    {
                        FileExtensionCollection pFEXGroup = iExtensionCollection.GetExtensionGroup(curExtension.Group);
                        StringBuilder pSBrAllGroupExtensionsListed = new StringBuilder();
                        foreach (FileExtension curGroupExtension in pFEXGroup.Extensions.Values)
                        {
                            pSBrAllGroupExtensionsListed.Append(String.Format("*.{0};", curGroupExtension.Extension));
                        }
                        pSBrAllGroupExtensionsListed.Length -= 1;
                        StringBuilder pSBrGroupFilter = new StringBuilder();
                        pSBrGroupFilter.Append(String.Format("{0} (", pFEXGroup.Description));
                        pSBrGroupFilter.Append(pSBrAllGroupExtensionsListed.ToString());
                        pSBrGroupFilter.Append(")|");
                        pSBrGroupFilter.Append(pSBrAllGroupExtensionsListed.ToString());
                        pSBrGroupFilter.Append("|");
                        pSBrIndividualExtensions.Append(pSBrGroupFilter.ToString());
                        pLisProcessedGroups.Add(curExtension.Group);
                    }
                }
            }
            pSBrAllExtensionsListed.Length -= 1;
            pSBrIndividualExtensions.Length -= 1;

            StringBuilder pSBrAllSupported = new StringBuilder();
            pSBrAllSupported.Append(String.Format("{0} (", iExtensionCollection.Description));
            pSBrAllSupported.Append(pSBrAllExtensionsListed.ToString());
            pSBrAllSupported.Append(")|");
            pSBrAllSupported.Append(pSBrAllExtensionsListed.ToString());

            StringBuilder pSBrExtensionString = new StringBuilder();

            if (iIncludeAllSupported)
            {
                pSBrExtensionString.Append(pSBrAllSupported.ToString());
                pSBrExtensionString.Append("|");
            }
            pSBrExtensionString.Append(pSBrIndividualExtensions.ToString());

            if(iIncludeAddWildcard)
            {
                pSBrExtensionString.Append("|All Files (*.*)|*.*");
            }

            return (pSBrExtensionString.ToString());
        }

        public static Boolean GetImageFileNameFromDialog(FileExtensionCollection iExtensionCollection,
            String iTitle,
            out List<String> oFiles,
            Boolean iMultiSelect = false)
        {
            oFiles = new List<String>();
            using (OpenFileDialog pOFDBrowse = new OpenFileDialog())
            {
                pOFDBrowse.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                pOFDBrowse.Filter = iExtensionCollection.GetFilterString(true, true);
                pOFDBrowse.Title = iTitle;
                pOFDBrowse.Multiselect = iMultiSelect;
                if (pOFDBrowse.ShowDialog() == DialogResult.OK)
                {
                    if(iMultiSelect)
                    {
                        oFiles.AddRange(pOFDBrowse.FileNames);
                    }
                    else
                    {
                        oFiles.Add(pOFDBrowse.FileName);
                    }
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
        }

        #endregion

    }

}
