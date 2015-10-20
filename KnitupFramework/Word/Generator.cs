using KnitupFramework.Markdown;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using KnitupFramework.Project;
using System.IO;
using System.Windows.Forms;

namespace KnitupFramework.Word
{

    public class Generator
    {

        #region public events

        public event EventHandler<GeneratorGenerateEventArgs> GenerateProgress;

        #endregion

        #region private objects

        private KnitupProject cKPtProject = null;

        #endregion

        #region public properties

        public KnitupProject Project
        {
            get { return (cKPtProject); }
        }

        #endregion

        #region constructor / destructor

        public Generator(KnitupProject iProject)
        {
            cKPtProject = iProject;
        }

        #endregion

        #region private methods

        private void RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType iCounterType,
            Int32 iCounterValue,
            Int32 iCounterLimit,
            String iMessage,
            String iSubMessage)
        {
            GeneratorGenerateEventArgs pArgArgs = new GeneratorGenerateEventArgs()
            {
                CounterType = iCounterType,
                CounterValue = iCounterValue,
                CounterLimit = iCounterLimit,
                Message = iMessage,
                SubMessage = iSubMessage
            };
            if(GenerateProgress != null)
            {
                GenerateProgress(this, pArgArgs);
            }
        }

        #endregion

        #region public methods

        public void Generate()
        {
            RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Parsing Markdown.", "");

            List<String> pLisLines = new List<String>();
            using (StringReader pSRrReader = new StringReader(cKPtProject.MarkdownSource))
            {
                String pStrLine = pSRrReader.ReadLine();
                while (pStrLine != null)
                {
                    pLisLines.Add(pStrLine);
                    pStrLine = pSRrReader.ReadLine();
                }
            }
            Parser pParParser = Parser.Parse(pLisLines.ToArray());

            RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Creating intermediate files.", "");
            Dictionary<String, String> pDicIntermediateFiles = new Dictionary<String, String>();
            String pStrLogoTemp = Path.GetTempFileName();
            cKPtProject.Info.CompanyLogo.Save(pStrLogoTemp, System.Drawing.Imaging.ImageFormat.Jpeg);
            pDicIntermediateFiles.Add("logo", pStrLogoTemp);

            String pStrBackgroundTemp = Path.GetTempFileName();
            cKPtProject.Info.BackgroundImage.Save(pStrBackgroundTemp, System.Drawing.Imaging.ImageFormat.Jpeg);
            pDicIntermediateFiles.Add("background", pStrBackgroundTemp);

            //foreach (String curImageKey in Project.Images.Images.Keys)
            //{
            //    String pStrImageTemp = Path.GetTempFileName();
            //    cKPtProject.Images.Images[curImageKey].Save(pStrImageTemp, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    pDicIntermediateFiles.Add(curImageKey, pStrImageTemp);
            //}

            RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Initialising Microsoft Word automation.", "");
            dynamic pObjApp = null;
            try
            {
                pObjApp = Marshal.GetActiveObject("Word.Application");
                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Found active instance of Microsoft Word, reusing.", "");
            }
            catch (Exception ex)
            {
                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Creating new instance of Microsoft Word.", "");
                Type pTypApplication = Type.GetTypeFromProgID("Word.Application", "127.0.0.1", true);
                pObjApp = Activator.CreateInstance(pTypApplication);
            }
            pObjApp.Visible = true;
            dynamic pObjDoc = pObjApp.Documents.Add();

            RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Creating ordered section list from markdown parser.", "");
            List<Section> pLisOrderedSections = pParParser.CreateOrderedSectionList();

            dynamic pObjFirstSection = null;
            dynamic pObjActiveRange = null;
            dynamic pObjIntroSection = null;

            RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Creating cover page.", "");
            Section pSecCoverPageSection = pLisOrderedSections[0];
            if(pSecCoverPageSection.Heading.LineType == Parser.LineType.heading1)
            {
                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Creating primary header.", "");
                pObjFirstSection = pObjDoc.Sections.First;
                pObjFirstSection.PageSetup.DifferentFirstPageHeaderFooter = -1; //true
                dynamic pObjCoverPageHeader = pObjFirstSection.Headers.Item[2];
                dynamic pObjCoverPageHeaderRange = pObjCoverPageHeader.Range;
                pObjCoverPageHeaderRange.Text = pSecCoverPageSection.Heading.Line.Substring(pSecCoverPageSection.Heading.Line.IndexOf(' ') + 1).ToUpper();
                pObjCoverPageHeaderRange.Style = "Title";
                pObjCoverPageHeaderRange.ParagraphFormat.Alignment = 1;

                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Inserting shape.", "");
                dynamic pObjFirstPage = pObjDoc.ActiveWindow.Panes(1).Pages.Item(1);
                dynamic pObjHeaderBack = pObjCoverPageHeader.Shapes.AddShape(1, 0, 0, pObjFirstPage.Width, pObjDoc.PageSetup.TopMargin + 16);
                pObjHeaderBack.ZOrder(5);
                pObjHeaderBack.Fill.ForeColor = 0xffffff;

                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Inserting logo.", "");
                dynamic pObjLogo = pObjCoverPageHeader.Shapes.AddPicture(pDicIntermediateFiles["logo"]);
                pObjLogo.ZOrder(5);
                pObjLogo.Width = pObjDoc.PageSetup.TopMargin + 16;
                pObjLogo.Height = pObjDoc.PageSetup.TopMargin + 16;
                pObjLogo.Left = 430;
                pObjLogo.Top = -36;

                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Inserting background.", "");
                dynamic pObjPageBackground = pObjCoverPageHeader.Shapes.AddPicture(pDicIntermediateFiles["background"]);
                pObjPageBackground.ZOrder(5);
                pObjPageBackground.ZOrder(1);
                pObjPageBackground.Width = pObjFirstPage.Width;
                pObjPageBackground.Height = pObjFirstPage.Height;
                pObjPageBackground.IncrementLeft(-72);
                pObjPageBackground.IncrementTop(-36);

                pObjActiveRange = pObjFirstSection.Range;
                pObjActiveRange.InsertBreak(7);

                pObjIntroSection = pObjDoc.Sections.Add();

                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Creating secondary header.", "");
                dynamic pObjPrimaryHeader = pObjIntroSection.Headers.Item[1];
                dynamic pObjPrimaryHeaderRange = pObjPrimaryHeader.Range;
                pObjPrimaryHeaderRange.Text = String.Empty;

                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Inserting background.", "");
                pObjPageBackground = pObjPrimaryHeader.Shapes.AddPicture(pDicIntermediateFiles["background"]);
                pObjPageBackground.ZOrder(5);
                pObjPageBackground.ZOrder(1);
                pObjPageBackground.Width = pObjFirstPage.Width;
                pObjPageBackground.Height = pObjFirstPage.Height;
                dynamic pObjPageBackgroundSatEffect = pObjPageBackground.Fill.PictureEffects.Insert(0x18, 1);
                pObjPageBackgroundSatEffect.EffectParameters[1].Value = 0.1f;

                dynamic pObjPageBackgroundBACEffect = pObjPageBackground.Fill.PictureEffects.Insert(3, 2);
                pObjPageBackgroundBACEffect.EffectParameters[1].Value = 0.65f;
                pObjPageBackgroundBACEffect.EffectParameters[2].Value = 0.25f;

                dynamic pObjPageBackgroundSoftenEffect = pObjPageBackground.Fill.PictureEffects.Insert(0x19, 3);
                pObjPageBackgroundSoftenEffect.EffectParameters[1].Value = -0.5f;

                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Creating secondary footer.", "");
                dynamic pObjPrimaryFooter = pObjIntroSection.Footers.Item[1];
                dynamic pObjPrimaryFooterRange = pObjPrimaryFooter.Range;
                pObjPrimaryFooterRange.InsertAfter(String.Format("{0}\r\n", cKPtProject.Options.CopyrightMessage));
                pObjPrimaryFooterRange.InsertAfter("This pattern is protected by the copyright law and cannot be reproduced in any form.\r\n");
                pObjPrimaryFooterRange.Style = "Intense Emphasis";
                pObjPrimaryFooterRange.ParagraphFormat.Alignment = 2;

                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Inserting page number reference.", "");
                pObjPrimaryFooterRange.InsertAfter("Page | ");
                pObjPrimaryFooterRange.Collapse(0);
                pObjDoc.Fields.Add(pObjPrimaryFooterRange, 0x21);
            }
            else
            {
                throw new Exception("Markdown missing cover page heading.  It should be a level 1 heading.");
            }

            //write table of contents here
            //Object pObjTableOfContents = null;
            //dynamic pObjTableOfContents = null;
            String pStrTOCToken = String.Format("[{0}]", Guid.NewGuid().ToString());
            if(cKPtProject.Options.GenerateTableOfContents)
            {
                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Inserting table of contents placeholder.", "");

                Int32 pIntTOCStart = pObjActiveRange.End;
                pObjActiveRange.InsertAfter("Table Of Contents" + "\r\n");
                Int32 pIntTOCEnd = pObjActiveRange.End;
                pObjActiveRange.Start = pIntTOCStart;
                
                //we clone the heading 1 style here as otherwise it appears within the table
                //of contents as the first page and I don't know how to add the heading into
                //the toc itself, not as an entry.  So yeah, this is a bodge.
                dynamic pObjStyle = pObjDoc.Styles.Add("Heading 1 Copy");
                pObjStyle.Font = pObjDoc.Styles["Heading 1"].Font;
                pObjActiveRange.Style = String.Format("Heading 1 Copy");
                pObjActiveRange.Start = pIntTOCEnd;

                pIntTOCStart = pObjActiveRange.End;
                pObjActiveRange.InsertAfter(pStrTOCToken);
                pIntTOCEnd = pObjActiveRange.End;
                pObjActiveRange.Start = pIntTOCStart;
                pObjActiveRange.Style = String.Format("Normal");
                pObjActiveRange.Start = pIntTOCEnd;

                pObjActiveRange.InsertBreak(3);
                pObjActiveRange.InsertBreak(7);
            }

            //Write main body here
            for (Int32 pIntCurSection = 1; pIntCurSection < pLisOrderedSections.Count; pIntCurSection++)
            {
                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.limited, pIntCurSection, pLisOrderedSections.Count - 1, "Writing section", pLisOrderedSections[pIntCurSection].Heading.Line);

                Section pSecSection = pLisOrderedSections[pIntCurSection];
                switch (pSecSection.Heading.LineType)
                {
                    case Parser.LineType.heading2:
                    case Parser.LineType.heading3:
                    case Parser.LineType.heading4:
                    case Parser.LineType.heading5:
                    case Parser.LineType.heading6:
                        {
                            //heading style 1 to 5, (heading level - 1)
                            if (pIntCurSection > 2 && pSecSection.Heading.LineType == Parser.LineType.heading2)
                            {
                                pObjActiveRange.InsertBreak(7); //column break is 8

                                if (pIntCurSection == 14)
                                {
                                    //Start of our comlumned section
                                    pObjActiveRange.InsertBreak(3);
                                    pObjActiveRange.PageSetup.TextColumns.Add();
                                    pObjActiveRange.PageSetup.DifferentFirstPageHeaderFooter = 0;
                               }
                            }
                            Int32 pIntStart = pObjActiveRange.End;
                            pObjActiveRange.InsertAfter(pSecSection.Heading.Line.Substring(pSecSection.Heading.Line.IndexOf(' ') + 1) + "\r\n");
                            Int32 pIntEnd = pObjActiveRange.End;
                            pObjActiveRange.Start = pIntStart;
                            pObjActiveRange.Style = String.Format("Heading {0}", ((Int32)pSecSection.Heading.LineType) - 1);
                            pObjActiveRange.Start = pIntEnd;

                            Int32 pIntListStart = 0;
                            Int32 pIntListEnd = 0;
                            foreach (ParsedItem curSubItem in pSecSection.SubItems)
                            {
                                switch (curSubItem.LineType)
                                {
                                    case Parser.LineType.body:
                                        {
                                            pIntStart = pObjActiveRange.End;
                                            pObjActiveRange.InsertAfter(curSubItem.Line);
                                            pIntEnd = pObjActiveRange.End;
                                            pObjActiveRange.Start = pIntStart;
                                            pObjActiveRange.Style = "Normal";
                                            pObjActiveRange.Start = pIntEnd;

                                            break;
                                        }
                                    case Parser.LineType.listitemstart:
                                        {
                                            pIntListStart = pObjActiveRange.End;
                                            pObjActiveRange.InsertAfter(curSubItem.Line.Substring(curSubItem.Line.IndexOf(' ') + 1) + "\r\n");
                                            break;
                                        }
                                    case Parser.LineType.listitem:
                                        {
                                            pObjActiveRange.InsertAfter(curSubItem.Line.Substring(curSubItem.Line.IndexOf(' ') + 1) + "\r\n");
                                            break;
                                        }
                                    case Parser.LineType.listitemend:
                                        {
                                            pIntListEnd = pObjActiveRange.End;
                                            pObjActiveRange.InsertAfter(curSubItem.Line.Substring(curSubItem.Line.IndexOf(' ') + 1));
                                            pObjActiveRange.Start = pIntListStart;
                                            pObjActiveRange.ApplyBulletDefault();
                                            pObjActiveRange.Font.ColorIndex = 6;
                                            System.Diagnostics.Debug.WriteLine((String)pObjActiveRange.Text);
                                            pObjActiveRange.Start = pIntListEnd;
                                            break;
                                        }
                                    case Parser.LineType.blank:
                                        {
                                            pObjActiveRange.InsertAfter("\r\n");
                                            break;
                                        }
                                    case Parser.LineType.image:
                                        {
                                            String pStrImage = curSubItem.Line;
                                            Int32 pIntStartKey = pStrImage.IndexOf('(');
                                            Int32 pIntEndKey = pStrImage.IndexOf(')');
                                            Int32 pInLength = (pIntEndKey - pIntStartKey);
                                            String pStrKey = pStrImage.Substring(pIntStartKey + 1, pInLength - 1);

                                            pIntStart = pObjActiveRange.End;
                                            pObjActiveRange.InsertAfter(String.Empty);
                                            pIntEnd = pObjActiveRange.End;
                                            pObjActiveRange.Start = pIntStart;

                                            Clipboard.SetImage(Project.Images.Images[pStrKey]);
                                            pObjActiveRange.Paste();

                                            pObjActiveRange.Start = pIntEnd;


                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    case Parser.LineType.listitemstart:
                    case Parser.LineType.listitem:
                    case Parser.LineType.listitemend:
                    case Parser.LineType.body:
                        {
                            throw new ArgumentException("Unexpected line type met during word document generation.");
                        }
                }
            }

            if (cKPtProject.Options.GenerateTableOfContents)
            {
                RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Generating table of contents.", "");
                pObjDoc.SelectAllEditableRanges();
                if (pObjApp.Selection.Find.Execute(ref pStrTOCToken))
                {
                    pObjDoc.TablesOfContents.Add(pObjApp.Selection.Range, -1, 1, 2);
                }
            }

            RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Deleting intermediate files.", "");
            foreach (String curIntermediatFile in pDicIntermediateFiles.Keys)
            {
                File.Delete(pDicIntermediateFiles[curIntermediatFile]);
            }

            RaiseGenerateProgress(GeneratorGenerateEventArgs.ProgressCounterType.indeterminate, 0, 0, "Operation complete.", "");
        }



        #endregion

    }

}
