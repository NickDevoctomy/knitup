using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.Markdown
{

    public class Section
    {

        #region private objects

        private ParsedItem cPImHeading;
        private Section cSecParentSection;
        private List<ParsedItem> cLisSubItems;
        private List<Section> cLisSubSections = new List<Section>();
        private Int32 cIntColumns = 0;

        #endregion

        #region public properties

        public ParsedItem Heading
        {
            get { return (cPImHeading); }
        }

        public Section ParentSection
        {
            get { return (cSecParentSection); }
        }

        public List<ParsedItem> SubItems
        {
            get { return (cLisSubItems); }
        }

        public List<Section> SubSections
        {
            get { return (cLisSubSections); }
        }

        #endregion

        #region constructor / destructor

        public Section(ParsedItem iHeading, Section iParentSection)
        {
            cPImHeading = iHeading;
            cSecParentSection = iParentSection;
            cLisSubItems = new List<ParsedItem>();
            cLisSubSections = new List<Section>();
        }

        #endregion

        #region private methods

        private static String RecursiveToString(Section iSection, Int32 iMaxDepth)
        {
            StringBuilder pSBrString = new StringBuilder();

            if(iMaxDepth == -1 || (Int32)iSection.Heading.LineType <= iMaxDepth)
            {
                pSBrString.AppendLine(iSection.Heading.Line.ToString());
                foreach (Section curSection in iSection.SubSections)
                {
                    pSBrString.Append(RecursiveToString(curSection, iMaxDepth));
                }
            }

            return (pSBrString.ToString());
        }

        #endregion

        #region base class overrides

        public String ToString(Int32 iMaxDepth)
        {
            StringBuilder pSBrString = new StringBuilder();
            pSBrString.Append(RecursiveToString(this, iMaxDepth));
            return (pSBrString.ToString());
        }

        public override string ToString()
        {
            StringBuilder pSBrString = new StringBuilder();
            pSBrString.Append(RecursiveToString(this, -1));
            return (pSBrString.ToString());
        }

        #endregion


    }

}
