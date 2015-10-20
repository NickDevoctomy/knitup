namespace Knitup.Dialogs
{
    partial class frmSelectProjectImage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.panPreview = new System.Windows.Forms.Panel();
            this.lbxImages = new System.Windows.Forms.ListBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butOK);
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 81);
            this.panel1.TabIndex = 1;
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(492, 15);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(152, 52);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(650, 15);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(152, 52);
            this.butCancel.TabIndex = 0;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // panPreview
            // 
            this.panPreview.Controls.Add(this.picPreview);
            this.panPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.panPreview.Location = new System.Drawing.Point(505, 0);
            this.panPreview.Margin = new System.Windows.Forms.Padding(0);
            this.panPreview.Name = "panPreview";
            this.panPreview.Padding = new System.Windows.Forms.Padding(16);
            this.panPreview.Size = new System.Drawing.Size(309, 351);
            this.panPreview.TabIndex = 3;
            // 
            // lbxImages
            // 
            this.lbxImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxImages.FormattingEnabled = true;
            this.lbxImages.ItemHeight = 20;
            this.lbxImages.Location = new System.Drawing.Point(0, 0);
            this.lbxImages.Name = "lbxImages";
            this.lbxImages.Size = new System.Drawing.Size(505, 351);
            this.lbxImages.TabIndex = 4;
            this.lbxImages.SelectedIndexChanged += new System.EventHandler(this.lbxImages_SelectedIndexChanged);
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(16, 16);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(277, 319);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 3;
            this.picPreview.TabStop = false;
            // 
            // frmSelectProjectImage
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(814, 432);
            this.Controls.Add(this.lbxImages);
            this.Controls.Add(this.panPreview);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectProjectImage";
            this.Text = "Knitup - Select Project Image";
            this.panel1.ResumeLayout(false);
            this.panPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.ListBox lbxImages;
    }
}