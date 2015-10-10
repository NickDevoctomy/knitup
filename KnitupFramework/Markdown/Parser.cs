using KnitupFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.Markdown
{

    public class Parser
    {

        #region public enums

        public enum LineType
        {
            none = 0,
            heading1 = 1,
            heading2 = 2,
            heading3 = 3,
            heading4 = 4,
            heading5 = 5,
            heading6 = 6,
            body = 7,
            listitemstart = 8,
            listitem = 9,
            listitemend = 10,
            blank = 11
        }

        #endregion

        #region private objects

        private List<ParsedItem> cLisItems;
        private List<Section> cLisSections;

        #endregion

        #region public properties

        public List<ParsedItem> Items
        {
            get { return (cLisItems); }
        }

        public List<Section> Sections
        {
            get { return (cLisSections); }
        }

        #endregion

        #region constructor / destructor

        private Parser()
        {
            cLisItems = new List<ParsedItem>();
            cLisSections = new List<Section>();
        }

        #endregion

        #region private methods

        private static LineType GetLineType(String iLine)
        {
            String pStrLine = iLine.Trim();
            if(String.IsNullOrWhiteSpace(pStrLine))
            {
                return (LineType.blank);
            }
            else
            {
                Int32 pIntTokenEnd = 0;
                pIntTokenEnd = iLine.IndexOf(' ');
                if(pIntTokenEnd > -1)
                {
                    String pStrToken = pStrLine.Substring(0, pIntTokenEnd);
                    if (pStrToken.StartsWith("#"))
                    {
                        String pStrHeadingType = String.Format("heading{0}", pStrToken.Length);
                        LineType pLTeType = (LineType)Enum.Parse(typeof(LineType), pStrHeadingType);
                        return (pLTeType);
                    }
                    else if (pStrToken == "*")
                    {
                        return (LineType.listitem);
                    }
                    else if (pStrToken.Contains('.'))
                    {
                        String pStrListItem = pStrToken.TrimEnd('.');
                        if (pStrListItem.IsDigits())
                        {
                            return (LineType.listitem);
                        }
                        else
                        {
                            return (LineType.body);
                        }
                    }
                    else
                    {
                        return (LineType.body);
                    }
                }
                else
                {
                    return (LineType.body);
                }
            }
        }

        private static void RecursiveCreateOrderedSectionList(Section iSection, List<Section> iListOutput)
        {
            iListOutput.Add(iSection);
            foreach (Section curSection in iSection.SubSections)
            {
                RecursiveCreateOrderedSectionList(curSection, iListOutput);
            }
        }

        #endregion

        #region public methods

        public static Parser Parse(String[] iMarkdownLines)
        {
            Parser pParParser = new Parser();
            LineType pLTeLastLineType = LineType.none;
            for(Int32 pIntCurLine = 0; pIntCurLine < iMarkdownLines.Length; pIntCurLine++)
            {
                String pStrCurLine = iMarkdownLines[pIntCurLine];
                LineType pLTeLineType = GetLineType(pStrCurLine);

                switch (pLTeLineType)
                {
                    case LineType.listitem:
                        {
                            if (pLTeLastLineType == LineType.listitem)
                            {
                                if(pIntCurLine < (iMarkdownLines.Length - 1))
                                {
                                    String pStrNextLine = iMarkdownLines[pIntCurLine + 1];
                                    LineType pLTeNextLineType = GetLineType(pStrNextLine);
                                    if(pLTeNextLineType != LineType.listitem)
                                    {
                                        pLTeLastLineType = LineType.listitemend;
                                    }
                                }
                            }
                            else
                            {
                                pLTeLineType = LineType.listitemstart;
                            }
                            break;
                        }
                }

                ParsedItem pPImItem = new ParsedItem()
                {
                    Line = pStrCurLine,
                    LineType = pLTeLineType
                };
                pParParser.cLisItems.Add(pPImItem);

                pLTeLastLineType = pLTeLineType;
            }

            Section pSecCurParentSection = null;
            ParsedItem pPImLastItem = null;
            for (Int32 pIntParsedItem = 0; pIntParsedItem < pParParser.cLisItems.Count; pIntParsedItem++)
            {
                ParsedItem pPImCurItem = pParParser.cLisItems[pIntParsedItem];

                if(pPImLastItem != null)
                {
                    if(pSecCurParentSection != null)
                    {
                        switch(pPImCurItem.LineType)
                        {
                            case LineType.body:
                                {
                                    pSecCurParentSection.SubItems.Add(pPImCurItem);
                                    break;
                                }
                            case LineType.heading1:
                            case LineType.heading2:
                            case LineType.heading3:
                            case LineType.heading4:
                            case LineType.heading5:
                            case LineType.heading6:
                                {
                                    //is this heading higher or lower than our current section heading
                                    if((Int32)pPImCurItem.LineType > (Int32)pSecCurParentSection.Heading.LineType)
                                    {
                                        Section pSecSection = new Section(pPImCurItem, pSecCurParentSection);
                                        pSecCurParentSection.SubSections.Add(pSecSection);
                                        pSecCurParentSection = pSecSection;
                                    }
                                    else
                                    {
                                        Boolean pBlnDropDown = true;
                                        while(pBlnDropDown)
                                        {
                                            if(pSecCurParentSection.ParentSection != null)
                                            {
                                                Int32 pIntParentSectionHeadingLevel = (Int32)pSecCurParentSection.ParentSection.Heading.LineType;
                                                Int32 pIntCurHeadingLevel = (Int32)pPImCurItem.LineType;
                                                if(pIntParentSectionHeadingLevel == (pIntCurHeadingLevel - 1))
                                                {
                                                    Section pSecSection = new Section(pPImCurItem, pSecCurParentSection);
                                                    pSecCurParentSection.SubSections.Add(pSecSection);
                                                    pSecCurParentSection = pSecSection;
                                                    pBlnDropDown = false;
                                                }
                                                else
                                                {
                                                    pSecCurParentSection = pSecCurParentSection.ParentSection;
                                                }
                                            }
                                            else
                                            {
                                                Section pSecSection = new Section(pPImCurItem, pSecCurParentSection);
                                                pSecCurParentSection.SubSections.Add(pSecSection);
                                                pSecCurParentSection = pSecSection;
                                                pBlnDropDown = false;
                                            }
                                        }
                                    }
                                    break;
                                }
                            case LineType.listitem:
                            case LineType.listitemend:
                            case LineType.listitemstart:
                                {
                                    pSecCurParentSection.SubItems.Add(pPImCurItem);
                                    break;
                                }
                            case LineType.blank:
                                {
                                    pSecCurParentSection.SubItems.Add(pPImCurItem);
                                    break;
                                }
                            default:
                                {
                                    throw new Exception(String.Format("Cannot parse LineType '{0}' as section.", pPImCurItem.LineType));
                                }
                        }
                    }
                    else
                    {
                        throw new Exception("No section has been defined.");
                    }
                }
                else
                {
                    if(pPImCurItem.LineType == LineType.heading1)
                    {
                        Section pSecSection = new Section(pPImCurItem, null);
                        pParParser.cLisSections.Add(pSecSection);
                        pSecCurParentSection = pSecSection;
                    }
                    else
                    {
                        throw new Exception("Document must start with a heading 1 item.");
                    }
                }

                pPImLastItem = pPImCurItem;
            }

            return (pParParser);
        }

        public List<Section> CreateOrderedSectionList()
        {
            List<Section> pLisSections = new List<Section>();
            foreach(Section curSection in Sections)
            {
                RecursiveCreateOrderedSectionList(curSection, pLisSections);
            }
            return (pLisSections);
        }

        #endregion

        #region base class overrides

        public String ToString(Int32 iMaxDepth)
        {
            StringBuilder pSBrString = new StringBuilder();

            foreach (Section curSection in cLisSections)
            {
                pSBrString.AppendLine(curSection.ToString(iMaxDepth));
            }

            return (pSBrString.ToString());
        }

        public override String ToString()
        {
            StringBuilder pSBrString = new StringBuilder();

            foreach(Section curSection in cLisSections)
            {
                pSBrString.AppendLine(curSection.ToString());
            }

            return (pSBrString.ToString());
        }

        #endregion

    }

}
