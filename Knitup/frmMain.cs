using Knitup.Dialogs;
using KnitupFramework.Drawing;
using KnitupFramework.IO;
using KnitupFramework.Project;
using KnitupFramework.Word;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knitup
{
    public partial class frmMain : Form
    {

        #region private objects

        KnitupProject cKPtProject;
        Generator cGenWordGenerator = null;
        System.Timers.Timer cTimPreviewTimer;
        Point cPntMousePos = Point.Empty;
        dlgImaePreviewPopup cDlgPreviewPopup;

        #endregion

        #region constructor / destructor

        public frmMain()
        {
            InitializeComponent();
            cTimPreviewTimer = new System.Timers.Timer(250);
            cTimPreviewTimer.Elapsed += CTimPreviewTimer_Elapsed;
            ApplySettings();
            DisplayProject(new KnitupProject());
        }

        #endregion

        #region private methods

        private void CheckInputZoomLevel()
        {
            float pFltCurSize = txtInput.Font.Size;
            tsbInputZoomIn.Enabled = (pFltCurSize < 46);
            tsbInputZoomOut.Enabled = (pFltCurSize > 8);
        }

        private void DisplayProject(KnitupProject iProject)
        {
            txtInput.Text = iProject.MarkdownSource;

            //Input
            cKPtProject = iProject;

            //Design
            picCompanyLogo.Image = iProject.Info.CompanyLogo;
            picBackgroundImage.Image = iProject.Info.BackgroundImage;

            //Options
            txtCopyrightMessage.Text = cKPtProject.Options.CopyrightMessage;
            chkGenerateTableOfContents.Checked = cKPtProject.Options.GenerateTableOfContents;

            //Images
            lbxImages.Items.Clear();
            foreach(ProjectImage curImage in cKPtProject.Images.Images.Values)
            {
                lbxImages.Items.Add(curImage);
            }

            UpdateSaveState();
            cKPtProject.PropertyChanged += CKPtProject_PropertyChanged;
        }

        private void ApplySettings()
        {
            float pFltCurSize = Properties.Settings.Default.EditorFontSize;
            txtInput.Font = new Font(txtInput.Font.FontFamily, pFltCurSize);
            CheckInputZoomLevel();
        }

        private void UpdateSaveState()
        {
            saveToolStripMenuItem.Enabled = cKPtProject.IsDirty;
            saveAsToolStripMenuItem.Enabled = !String.IsNullOrEmpty(cKPtProject.FullPath);
        }

        private async Task OpenProject()
        {
            List<String> pLisImages = null;
            if (FileExtensionUtility.GetImageFileNameFromDialog(FileExtensionCollection.EXTENSION_COLLECTION_KNITUP_PROJECT,
                "Browse For Knitup Project...",
                out pLisImages,
                false))
            {
                KnitupProject pKPtProject = await KnitupProject.Load(pLisImages[0]);
                DisplayProject(pKPtProject);
            }
        }

        #endregion

        #region object events

        private void tsbInputPreview_Click(object sender, EventArgs e)
        {
            tsbInputPreview.Checked = !tsbInputPreview.Checked;
            scrInput.Panel2Collapsed = !tsbInputPreview.Checked;
        }

        private void tsbInputZoomIn_Click(object sender, EventArgs e)
        {
            float pFltCurSize = txtInput.Font.Size;
            if(pFltCurSize < 46)
            {
                pFltCurSize += 1;
                txtInput.Font = new Font(txtInput.Font.FontFamily, pFltCurSize);
                CheckInputZoomLevel();
            }
        }

        private void tsbInputZoomOut_Click(object sender, EventArgs e)
        {
            float pFltCurSize = txtInput.Font.Size;
            if (pFltCurSize > 8)
            {
                pFltCurSize -= 1;
                txtInput.Font = new Font(txtInput.Font.FontFamily, pFltCurSize);
                CheckInputZoomLevel();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void markdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> pLisImages = null;
            if (FileExtensionUtility.GetImageFileNameFromDialog(FileExtensionCollection.EXTENSION_COLLECTION_IMPORT_DOCUMENT,
                "Browse For Document To Import...",
                out pLisImages,
                false))
            {
                KnitupProject pKPtProject = new KnitupProject();
                pKPtProject.MarkdownSource = File.ReadAllText(pLisImages[0]);
                DisplayProject(pKPtProject);
            }
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(cKPtProject.FullPath))
            {
                using (SaveFileDialog pSFDSave = new SaveFileDialog())
                {
                    pSFDSave.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    pSFDSave.Filter = "Knitup Projects (*.kup)|*.kup";
                    pSFDSave.Title = "Save Project As...";
                    pSFDSave.AddExtension = true;
                    pSFDSave.OverwritePrompt = true;
                    if (pSFDSave.ShowDialog() == DialogResult.OK)
                    {
                        await cKPtProject.Save(pSFDSave.FileName);
                        UpdateSaveState();
                    }
                }
            }
            else
            {
                await cKPtProject.Save(cKPtProject.FullPath);
                UpdateSaveState();
            }
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cKPtProject.FullPath))
            {
                using (SaveFileDialog pSFDSave = new SaveFileDialog())
                {
                    pSFDSave.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    pSFDSave.Filter = "Knitup Projects (*.kup)|*.kup";
                    pSFDSave.Title = "Save Project...";
                    pSFDSave.AddExtension = true;
                    pSFDSave.OverwritePrompt = true;
                    if (pSFDSave.ShowDialog() == DialogResult.OK)
                    {
                        await cKPtProject.Save(pSFDSave.FileName, true);
                        UpdateSaveState();
                    }
                }
            }
            else
            {
                await cKPtProject.Save(cKPtProject.FullPath, true);
                UpdateSaveState();
            }
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OpenProject();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (dlgSettings pDlgSettings = new dlgSettings())
            {
                if (pDlgSettings.ShowDialog() == DialogResult.OK)
                {
                    ApplySettings();
                }
            }

        }

        private void picCompanyLogo_Click(object sender, EventArgs e)
        {
            List<String> pLisImages = null;
            if (FileExtensionUtility.GetImageFileNameFromDialog(FileExtensionCollection.EXTENSION_COLLECTION_IMAGE_ALL,
                "Browse For Company Logo...",
                out pLisImages,
                false))
            {
                Image pImgLogo = DrawingUtility.CreateThumbnail(pLisImages[0], 512, 512, Color.White);
                picCompanyLogo.Image = pImgLogo;
                cKPtProject.Info.CompanyLogo = pImgLogo;
            }
        }

        private void picBackgroundImage_Click(object sender, EventArgs e)
        {
            List<String> pLisImages = null;
            if (FileExtensionUtility.GetImageFileNameFromDialog(FileExtensionCollection.EXTENSION_COLLECTION_IMAGE_ALL,
                "Browse For Background Image...",
                out pLisImages,
                false))
            {
                Image pImgBackground = DrawingUtility.ResizeImage(pLisImages[0], 1358, 1920, true);
                picBackgroundImage.Image = pImgBackground;
                cKPtProject.Info.BackgroundImage = pImgBackground;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayProject(new KnitupProject());
            tclMain.SelectedTab = tpeInput;
        }

        private void CKPtProject_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateSaveState();
        }

        private void txtCopyrightMessage_TextChanged(object sender, EventArgs e)
        {
            cKPtProject.Options.CopyrightMessage = txtCopyrightMessage.Text;
        }

        private void wordDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtBuildOutput.Clear();
            txtBuildOutput.AppendText("Starting Build.\r\n");
            txtBuildOutput.AppendText("Generating Word document.\r\n");
            cGenWordGenerator = cKPtProject.CreateWordGenerator();
            cGenWordGenerator.GenerateProgress += CGenWordGenerator_GenerateProgress;
            cGenWordGenerator.Generate();
        }

        private void CGenWordGenerator_GenerateProgress(object sender, GeneratorGenerateEventArgs e)
        {
            if (e.CounterType == GeneratorGenerateEventArgs.ProgressCounterType.indeterminate)
            {
                txtBuildOutput.AppendText(String.Format("{0}.\r\n", e.Message));
            }
            else if (e.CounterType == GeneratorGenerateEventArgs.ProgressCounterType.limited)
            {
                txtBuildOutput.AppendText(String.Format("{0} {1}/{2}.\r\n", e.Message, e.CounterValue, e.CounterLimit));
            }
        }

        private void chkGenerateTableOfContents_CheckedChanged(object sender, EventArgs e)
        {
            cKPtProject.Options.GenerateTableOfContents = chkGenerateTableOfContents.Checked;
        }

        private void tsbBuildWordDocument_Click(object sender, EventArgs e)
        {
            txtBuildOutput.Clear();
            txtBuildOutput.AppendText("Starting Build.\r\n");
            txtBuildOutput.AppendText("Generating Word document.\r\n");
            cGenWordGenerator = cKPtProject.CreateWordGenerator();
            cGenWordGenerator.GenerateProgress += CGenWordGenerator_GenerateProgress;
            cGenWordGenerator.Generate();
        }

        private async void tsbFileOpen_Click(object sender, EventArgs e)
        {
            await OpenProject();
        }

        private void tsbAddImage_Click(object sender, EventArgs e)
        {
            List<String> pLisImages = null;
            if(FileExtensionUtility.GetImageFileNameFromDialog(FileExtensionCollection.EXTENSION_COLLECTION_IMAGE_ALL,
                "Browse For Image...",
                out pLisImages,
                true))
            {
                foreach (String curImage in pLisImages)
                {
                    Image pImgImage = Image.FromFile(curImage);
                    String pStrName = Path.GetFileNameWithoutExtension(new FileInfo(curImage).Name);
                    ProjectImage pPIeImage = cKPtProject.Images.AddImage(pStrName, pImgImage);
                    lbxImages.Items.Add(pPIeImage);
                }
            }
        }

        private void lbxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxImages.SelectedIndex > -1)
            {
                ProjectImage pPIeImage = (ProjectImage)lbxImages.SelectedItem;
                picPreview.Image = cKPtProject.Images.Images[pPIeImage.ID].Image;
            }
        }

        private void tsbRemoveImage_Click(object sender, EventArgs e)
        {
            if (lbxImages.SelectedIndex > -1)
            {
                ProjectImage pPIeImage = (ProjectImage)lbxImages.SelectedItem;
                cKPtProject.Images.RemoveImage(pPIeImage.ID);
                lbxImages.Items.Remove(pPIeImage);
                picPreview.Image = null;
            }
        }

        private void tsbInsertImage_Click(object sender, EventArgs e)
        {
            if (cKPtProject.Images.Images.Count > 0)
            {
                using (dlgSelectProjectImage pSPISelect = new dlgSelectProjectImage())
                {
                    pSPISelect.Images = cKPtProject.Images;
                    if (pSPISelect.ShowDialog() == DialogResult.OK)
                    {
                        String pStrImage = String.Format("![{0}]({1})", "Caption For Your Image Goes Here", pSPISelect.SelectedImageID);
                        Int32 pIntStart = txtInput.SelectionStart;
                        txtInput.Text = txtInput.Text.Insert(txtInput.SelectionStart, pStrImage);
                        txtInput.SelectionStart = pIntStart;
                        txtInput.SelectionLength = 0;
                        txtInput.ScrollToCaret();
                    }
                }
            }
            else
            {
                MessageBox.Show("You must first add an image to the project through the 'images' tab.", 
                    "Insert Image");
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            cKPtProject.MarkdownSource = txtInput.Text;
        }

        private void CTimPreviewTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            cTimPreviewTimer.Stop();
            Invoke(new MethodInvoker(delegate() {
                if(!String.IsNullOrEmpty(txtInput.Text))
                {
                    Int32 pIntCharIndex = txtInput.GetCharIndexFromPosition(cPntMousePos);
                    Int32 pIntLine = txtInput.GetLineFromCharIndex(pIntCharIndex);
                    Int32 pIntStart = txtInput.GetFirstCharIndexFromLine(pIntLine);
                    Int32 pIntEnd = txtInput.Text.IndexOf("\r", pIntStart);
                    String pStrLine = txtInput.Text.Substring(pIntStart, pIntEnd - pIntStart);

                    Int32 pIntStartKey = pStrLine.IndexOf('(');
                    Int32 pIntEndKey = pStrLine.IndexOf(')');
                    if(pIntStartKey > -1 && pIntEndKey > pIntStartKey)
                    {
                        Int32 pInLength = (pIntEndKey - pIntStartKey);
                        String pStrKey = pStrLine.Substring(pIntStartKey + 1, pInLength - 1);

                        if (cDlgPreviewPopup != null)
                        {
                            cDlgPreviewPopup.Dispose();
                            cDlgPreviewPopup = null;
                        }
                        cDlgPreviewPopup = new dlgImaePreviewPopup();
                        cDlgPreviewPopup.Opacity = 0.75f;
                        cDlgPreviewPopup.TopMost = true;
                        cDlgPreviewPopup.StartPosition = FormStartPosition.Manual;
                        cDlgPreviewPopup.Location = txtInput.PointToScreen(cPntMousePos);
                        Image pImgThumb = DrawingUtility.LowQualityScaledThumbnail(cKPtProject.Images.Images[pStrKey].Image,
                            200,
                            200);
                        cDlgPreviewPopup.Image = pImgThumb;
                        cDlgPreviewPopup.Show();
                        cDlgPreviewPopup.Size = new Size(pImgThumb.Width, pImgThumb.Height);
                    }
                }
            }));
        }

        private void txtInput_MouseLeave(object sender, EventArgs e)
        {
            cTimPreviewTimer.Stop();
        }

        private void txtInput_MouseMove(object sender, MouseEventArgs e)
        {
            cTimPreviewTimer.Stop();
            if(e.Location != cPntMousePos)
            {
                if (cDlgPreviewPopup != null)
                {
                    cDlgPreviewPopup.Dispose();
                    cDlgPreviewPopup = null;
                }
                cPntMousePos = e.Location;
                cTimPreviewTimer.Start();
            }
        }

        #endregion

    }
}
