using Knitup.Dialogs;
using KnitupFramework.Drawing;
using KnitupFramework.Project;
using KnitupFramework.Word;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Knitup
{
    public partial class frmMain : Form
    {

        #region private objects

        KnitupProject cKPtProject;
        Generator cGenWordGenerator = null;

        #endregion

        #region constructor / destructor

        public frmMain()
        {
            InitializeComponent();
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
            using (OpenFileDialog pOFDBrowse = new OpenFileDialog())
            {
                pOFDBrowse.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                pOFDBrowse.Filter = "Markdown Files (*.md)|*.md";
                pOFDBrowse.Title = "Browse For Document To Import...";
                pOFDBrowse.Multiselect = false;
                if (pOFDBrowse.ShowDialog() == DialogResult.OK)
                {
                    KnitupProject pKPtProject = new KnitupProject();
                    pKPtProject.MarkdownSource = File.ReadAllText(pOFDBrowse.FileName);
                    DisplayProject(pKPtProject);
                }
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
            using (SaveFileDialog pSFDSave = new SaveFileDialog())
            {
                pSFDSave.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                pSFDSave.Filter = "Knitup Projects (*.kup)|*.kup";
                pSFDSave.Title = "Save Project As...";
                pSFDSave.AddExtension = true;
                pSFDSave.OverwritePrompt = true;
                if (pSFDSave.ShowDialog() == DialogResult.OK)
                {
                    await cKPtProject.Save(pSFDSave.FileName, false);
                    UpdateSaveState();
                }
            }
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog pOFDBrowse = new OpenFileDialog())
            {
                pOFDBrowse.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                pOFDBrowse.Filter = "Knitup Projects (*.kup)|*.kup";
                pOFDBrowse.Title = "Browse for Project...";
                pOFDBrowse.Multiselect = false;
                if (pOFDBrowse.ShowDialog() == DialogResult.OK)
                {
                    KnitupProject pKPtProject = await KnitupProject.Load(pOFDBrowse.FileName);
                    DisplayProject(pKPtProject);
                }
            }
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
            using (OpenFileDialog pOFDBrowse = new OpenFileDialog())
            {
                pOFDBrowse.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                pOFDBrowse.Filter = "Supported Image Files (*.jpg)|*.jpg";
                pOFDBrowse.Title = "Browse For Company Logo...";
                pOFDBrowse.Multiselect = false;
                if (pOFDBrowse.ShowDialog() == DialogResult.OK)
                {
                    Image pImgLogo = DrawingUtility.CreateThumbnail(pOFDBrowse.FileName, 512, 512, Color.White);
                    picCompanyLogo.Image = pImgLogo;
                    cKPtProject.Info.CompanyLogo = pImgLogo;
                }
            }
        }

        private void picBackgroundImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog pOFDBrowse = new OpenFileDialog())
            {
                pOFDBrowse.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                pOFDBrowse.Filter = "Supported Image Files (*.jpg)|*.jpg";
                pOFDBrowse.Title = "Browse For Background Image...";
                pOFDBrowse.Multiselect = false;
                if (pOFDBrowse.ShowDialog() == DialogResult.OK)
                {
                    Image pImgBackground = DrawingUtility.CreateThumbnail(pOFDBrowse.FileName, 1358, 1920, Color.White);
                    picBackgroundImage.Image = pImgBackground;
                    cKPtProject.Info.BackgroundImage = pImgBackground;
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayProject(new KnitupProject());
            tclMain.SelectedTab = tpeInput;
        }

        private void CKPtProject_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //update title bar to reflect if isdirty or not
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

        #endregion

    }
}
