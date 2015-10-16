namespace Knitup
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tclMain = new System.Windows.Forms.TabControl();
            this.tpeInput = new System.Windows.Forms.TabPage();
            this.scrBuild = new System.Windows.Forms.SplitContainer();
            this.scrInput = new System.Windows.Forms.SplitContainer();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.tspInput = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wbrHTMLPreview = new System.Windows.Forms.WebBrowser();
            this.txtBuildOutput = new System.Windows.Forms.TextBox();
            this.tpeDesign = new System.Windows.Forms.TabPage();
            this.lblBackgroundImage = new System.Windows.Forms.Label();
            this.lblCompanyLogo = new System.Windows.Forms.Label();
            this.tpeOptions = new System.Windows.Forms.TabPage();
            this.chkGenerateTableOfContents = new System.Windows.Forms.CheckBox();
            this.txtCopyrightMessage = new System.Windows.Forms.TextBox();
            this.lblCopyrightMessage = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbInputZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsbInputZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbInputPreview = new System.Windows.Forms.ToolStripButton();
            this.tsbBuildWordDocument = new System.Windows.Forms.ToolStripButton();
            this.tsbFileOpen = new System.Windows.Forms.ToolStripButton();
            this.picBackgroundImage = new System.Windows.Forms.PictureBox();
            this.picCompanyLogo = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tclMain.SuspendLayout();
            this.tpeInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrBuild)).BeginInit();
            this.scrBuild.Panel1.SuspendLayout();
            this.scrBuild.Panel2.SuspendLayout();
            this.scrBuild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrInput)).BeginInit();
            this.scrInput.Panel1.SuspendLayout();
            this.scrInput.Panel2.SuspendLayout();
            this.scrInput.SuspendLayout();
            this.tspInput.SuspendLayout();
            this.tpeDesign.SuspendLayout();
            this.tpeOptions.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tclMain
            // 
            this.tclMain.Controls.Add(this.tpeInput);
            this.tclMain.Controls.Add(this.tpeDesign);
            this.tclMain.Controls.Add(this.tpeOptions);
            this.tclMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclMain.Location = new System.Drawing.Point(0, 33);
            this.tclMain.Name = "tclMain";
            this.tclMain.SelectedIndex = 0;
            this.tclMain.Size = new System.Drawing.Size(1278, 761);
            this.tclMain.TabIndex = 0;
            // 
            // tpeInput
            // 
            this.tpeInput.Controls.Add(this.scrBuild);
            this.tpeInput.Location = new System.Drawing.Point(4, 29);
            this.tpeInput.Name = "tpeInput";
            this.tpeInput.Padding = new System.Windows.Forms.Padding(3);
            this.tpeInput.Size = new System.Drawing.Size(1270, 728);
            this.tpeInput.TabIndex = 0;
            this.tpeInput.Text = "Input";
            this.tpeInput.UseVisualStyleBackColor = true;
            // 
            // scrBuild
            // 
            this.scrBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrBuild.Location = new System.Drawing.Point(3, 3);
            this.scrBuild.Name = "scrBuild";
            this.scrBuild.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scrBuild.Panel1
            // 
            this.scrBuild.Panel1.Controls.Add(this.scrInput);
            // 
            // scrBuild.Panel2
            // 
            this.scrBuild.Panel2.Controls.Add(this.txtBuildOutput);
            this.scrBuild.Size = new System.Drawing.Size(1264, 722);
            this.scrBuild.SplitterDistance = 361;
            this.scrBuild.TabIndex = 2;
            // 
            // scrInput
            // 
            this.scrInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrInput.Location = new System.Drawing.Point(0, 0);
            this.scrInput.Name = "scrInput";
            // 
            // scrInput.Panel1
            // 
            this.scrInput.Panel1.Controls.Add(this.txtInput);
            this.scrInput.Panel1.Controls.Add(this.tspInput);
            // 
            // scrInput.Panel2
            // 
            this.scrInput.Panel2.Controls.Add(this.wbrHTMLPreview);
            this.scrInput.Panel2Collapsed = true;
            this.scrInput.Size = new System.Drawing.Size(1264, 361);
            this.scrInput.SplitterDistance = 641;
            this.scrInput.TabIndex = 1;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.Black;
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(0, 31);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(1264, 330);
            this.txtInput.TabIndex = 0;
            // 
            // tspInput
            // 
            this.tspInput.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tspInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFileOpen,
            this.toolStripSeparator3,
            this.tsbInputZoomIn,
            this.tsbInputZoomOut,
            this.toolStripSeparator1,
            this.tsbInputPreview,
            this.toolStripSeparator2,
            this.tsbBuildWordDocument});
            this.tspInput.Location = new System.Drawing.Point(0, 0);
            this.tspInput.Name = "tspInput";
            this.tspInput.Size = new System.Drawing.Size(1264, 31);
            this.tspInput.TabIndex = 1;
            this.tspInput.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // wbrHTMLPreview
            // 
            this.wbrHTMLPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrHTMLPreview.Location = new System.Drawing.Point(0, 0);
            this.wbrHTMLPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrHTMLPreview.Name = "wbrHTMLPreview";
            this.wbrHTMLPreview.Size = new System.Drawing.Size(96, 100);
            this.wbrHTMLPreview.TabIndex = 0;
            // 
            // txtBuildOutput
            // 
            this.txtBuildOutput.BackColor = System.Drawing.Color.Black;
            this.txtBuildOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuildOutput.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuildOutput.ForeColor = System.Drawing.Color.White;
            this.txtBuildOutput.Location = new System.Drawing.Point(0, 0);
            this.txtBuildOutput.Multiline = true;
            this.txtBuildOutput.Name = "txtBuildOutput";
            this.txtBuildOutput.ReadOnly = true;
            this.txtBuildOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBuildOutput.Size = new System.Drawing.Size(1264, 357);
            this.txtBuildOutput.TabIndex = 1;
            // 
            // tpeDesign
            // 
            this.tpeDesign.Controls.Add(this.picBackgroundImage);
            this.tpeDesign.Controls.Add(this.lblBackgroundImage);
            this.tpeDesign.Controls.Add(this.lblCompanyLogo);
            this.tpeDesign.Controls.Add(this.picCompanyLogo);
            this.tpeDesign.Location = new System.Drawing.Point(4, 29);
            this.tpeDesign.Name = "tpeDesign";
            this.tpeDesign.Padding = new System.Windows.Forms.Padding(3);
            this.tpeDesign.Size = new System.Drawing.Size(1270, 728);
            this.tpeDesign.TabIndex = 1;
            this.tpeDesign.Text = "Design";
            this.tpeDesign.UseVisualStyleBackColor = true;
            // 
            // lblBackgroundImage
            // 
            this.lblBackgroundImage.AutoSize = true;
            this.lblBackgroundImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackgroundImage.Location = new System.Drawing.Point(325, 43);
            this.lblBackgroundImage.Name = "lblBackgroundImage";
            this.lblBackgroundImage.Size = new System.Drawing.Size(160, 20);
            this.lblBackgroundImage.TabIndex = 3;
            this.lblBackgroundImage.Text = "Background Image";
            // 
            // lblCompanyLogo
            // 
            this.lblCompanyLogo.AutoSize = true;
            this.lblCompanyLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyLogo.Location = new System.Drawing.Point(23, 43);
            this.lblCompanyLogo.Name = "lblCompanyLogo";
            this.lblCompanyLogo.Size = new System.Drawing.Size(128, 20);
            this.lblCompanyLogo.TabIndex = 1;
            this.lblCompanyLogo.Text = "Company Logo";
            // 
            // tpeOptions
            // 
            this.tpeOptions.Controls.Add(this.chkGenerateTableOfContents);
            this.tpeOptions.Controls.Add(this.txtCopyrightMessage);
            this.tpeOptions.Controls.Add(this.lblCopyrightMessage);
            this.tpeOptions.Location = new System.Drawing.Point(4, 29);
            this.tpeOptions.Name = "tpeOptions";
            this.tpeOptions.Size = new System.Drawing.Size(1270, 728);
            this.tpeOptions.TabIndex = 2;
            this.tpeOptions.Text = "Options";
            this.tpeOptions.UseVisualStyleBackColor = true;
            // 
            // chkGenerateTableOfContents
            // 
            this.chkGenerateTableOfContents.AutoSize = true;
            this.chkGenerateTableOfContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGenerateTableOfContents.Location = new System.Drawing.Point(27, 108);
            this.chkGenerateTableOfContents.Name = "chkGenerateTableOfContents";
            this.chkGenerateTableOfContents.Size = new System.Drawing.Size(259, 24);
            this.chkGenerateTableOfContents.TabIndex = 5;
            this.chkGenerateTableOfContents.Text = "Generate Table of Contents";
            this.chkGenerateTableOfContents.UseVisualStyleBackColor = true;
            this.chkGenerateTableOfContents.CheckedChanged += new System.EventHandler(this.chkGenerateTableOfContents_CheckedChanged);
            // 
            // txtCopyrightMessage
            // 
            this.txtCopyrightMessage.Location = new System.Drawing.Point(27, 66);
            this.txtCopyrightMessage.Name = "txtCopyrightMessage";
            this.txtCopyrightMessage.Size = new System.Drawing.Size(501, 26);
            this.txtCopyrightMessage.TabIndex = 3;
            this.txtCopyrightMessage.TextChanged += new System.EventHandler(this.txtCopyrightMessage_TextChanged);
            // 
            // lblCopyrightMessage
            // 
            this.lblCopyrightMessage.AutoSize = true;
            this.lblCopyrightMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyrightMessage.Location = new System.Drawing.Point(23, 43);
            this.lblCopyrightMessage.Name = "lblCopyrightMessage";
            this.lblCopyrightMessage.Size = new System.Drawing.Size(162, 20);
            this.lblCopyrightMessage.TabIndex = 2;
            this.lblCopyrightMessage.Text = "Copyright Message";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.importToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markdownToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // markdownToolStripMenuItem
            // 
            this.markdownToolStripMenuItem.Name = "markdownToolStripMenuItem";
            this.markdownToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
            this.markdownToolStripMenuItem.Text = "Markdown...";
            this.markdownToolStripMenuItem.Click += new System.EventHandler(this.markdownToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordDocumentToolStripMenuItem});
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.compileToolStripMenuItem.Text = "Compile";
            // 
            // wordDocumentToolStripMenuItem
            // 
            this.wordDocumentToolStripMenuItem.Name = "wordDocumentToolStripMenuItem";
            this.wordDocumentToolStripMenuItem.Size = new System.Drawing.Size(229, 30);
            this.wordDocumentToolStripMenuItem.Text = "Word Document";
            this.wordDocumentToolStripMenuItem.Click += new System.EventHandler(this.wordDocumentToolStripMenuItem_Click);
            // 
            // tsbInputZoomIn
            // 
            this.tsbInputZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInputZoomIn.Image = global::Knitup.Properties.Resources.Zoom_In_24;
            this.tsbInputZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInputZoomIn.Name = "tsbInputZoomIn";
            this.tsbInputZoomIn.Size = new System.Drawing.Size(28, 28);
            this.tsbInputZoomIn.Text = "Zoom In";
            this.tsbInputZoomIn.Click += new System.EventHandler(this.tsbInputZoomIn_Click);
            // 
            // tsbInputZoomOut
            // 
            this.tsbInputZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInputZoomOut.Image = global::Knitup.Properties.Resources.Zoom_Out_24;
            this.tsbInputZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInputZoomOut.Name = "tsbInputZoomOut";
            this.tsbInputZoomOut.Size = new System.Drawing.Size(28, 28);
            this.tsbInputZoomOut.Text = "Zoom Out";
            this.tsbInputZoomOut.Click += new System.EventHandler(this.tsbInputZoomOut_Click);
            // 
            // tsbInputPreview
            // 
            this.tsbInputPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInputPreview.Image = global::Knitup.Properties.Resources.Preview_24;
            this.tsbInputPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInputPreview.Name = "tsbInputPreview";
            this.tsbInputPreview.Size = new System.Drawing.Size(28, 28);
            this.tsbInputPreview.Text = "HTML Preview";
            this.tsbInputPreview.Click += new System.EventHandler(this.tsbInputPreview_Click);
            // 
            // tsbBuildWordDocument
            // 
            this.tsbBuildWordDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBuildWordDocument.Image = global::Knitup.Properties.Resources.Microsoft_Word_New_24;
            this.tsbBuildWordDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuildWordDocument.Name = "tsbBuildWordDocument";
            this.tsbBuildWordDocument.Size = new System.Drawing.Size(28, 28);
            this.tsbBuildWordDocument.Text = "Build Word Document";
            this.tsbBuildWordDocument.Click += new System.EventHandler(this.tsbBuildWordDocument_Click);
            // 
            // tsbFileOpen
            // 
            this.tsbFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFileOpen.Image = global::Knitup.Properties.Resources.Open_24;
            this.tsbFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileOpen.Name = "tsbFileOpen";
            this.tsbFileOpen.Size = new System.Drawing.Size(28, 28);
            this.tsbFileOpen.Text = "Open...";
            this.tsbFileOpen.Click += new System.EventHandler(this.tsbFileOpen_Click);
            // 
            // picBackgroundImage
            // 
            this.picBackgroundImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picBackgroundImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackgroundImage.Location = new System.Drawing.Point(329, 66);
            this.picBackgroundImage.Name = "picBackgroundImage";
            this.picBackgroundImage.Size = new System.Drawing.Size(181, 256);
            this.picBackgroundImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackgroundImage.TabIndex = 4;
            this.picBackgroundImage.TabStop = false;
            this.picBackgroundImage.Click += new System.EventHandler(this.picBackgroundImage_Click);
            // 
            // picCompanyLogo
            // 
            this.picCompanyLogo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picCompanyLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCompanyLogo.Location = new System.Drawing.Point(27, 66);
            this.picCompanyLogo.Name = "picCompanyLogo";
            this.picCompanyLogo.Size = new System.Drawing.Size(256, 256);
            this.picCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCompanyLogo.TabIndex = 2;
            this.picCompanyLogo.TabStop = false;
            this.picCompanyLogo.Click += new System.EventHandler(this.picCompanyLogo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 794);
            this.Controls.Add(this.tclMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.Text = "Knitup";
            this.tclMain.ResumeLayout(false);
            this.tpeInput.ResumeLayout(false);
            this.scrBuild.Panel1.ResumeLayout(false);
            this.scrBuild.Panel2.ResumeLayout(false);
            this.scrBuild.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrBuild)).EndInit();
            this.scrBuild.ResumeLayout(false);
            this.scrInput.Panel1.ResumeLayout(false);
            this.scrInput.Panel1.PerformLayout();
            this.scrInput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrInput)).EndInit();
            this.scrInput.ResumeLayout(false);
            this.tspInput.ResumeLayout(false);
            this.tspInput.PerformLayout();
            this.tpeDesign.ResumeLayout(false);
            this.tpeDesign.PerformLayout();
            this.tpeOptions.ResumeLayout(false);
            this.tpeOptions.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tclMain;
        private System.Windows.Forms.TabPage tpeInput;
        private System.Windows.Forms.TabPage tpeDesign;
        private System.Windows.Forms.SplitContainer scrInput;
        private System.Windows.Forms.ToolStrip tspInput;
        private System.Windows.Forms.ToolStripButton tsbInputPreview;
        private System.Windows.Forms.ToolStripButton tsbInputZoomIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbInputZoomOut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblCompanyLogo;
        private System.Windows.Forms.PictureBox picCompanyLogo;
        private System.Windows.Forms.TabPage tpeOptions;
        private System.Windows.Forms.Label lblCopyrightMessage;
        private System.Windows.Forms.TextBox txtCopyrightMessage;
        private System.Windows.Forms.PictureBox picBackgroundImage;
        private System.Windows.Forms.Label lblBackgroundImage;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.WebBrowser wbrHTMLPreview;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordDocumentToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scrBuild;
        private System.Windows.Forms.TextBox txtBuildOutput;
        private System.Windows.Forms.CheckBox chkGenerateTableOfContents;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbBuildWordDocument;
        private System.Windows.Forms.ToolStripButton tsbFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

