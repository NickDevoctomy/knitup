namespace Knitup.Dialogs
{
    partial class dlgSettings
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.tclSettings = new System.Windows.Forms.TabControl();
            this.tpeSettingsInput = new System.Windows.Forms.TabPage();
            this.lblEditorFontSize = new System.Windows.Forms.Label();
            this.nudEditorFontSize = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.tclSettings.SuspendLayout();
            this.tpeSettingsInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditorFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butOK);
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 81);
            this.panel1.TabIndex = 0;
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(356, 15);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(152, 52);
            this.butCancel.TabIndex = 0;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(198, 15);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(152, 52);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // tclSettings
            // 
            this.tclSettings.Controls.Add(this.tpeSettingsInput);
            this.tclSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tclSettings.Location = new System.Drawing.Point(0, 0);
            this.tclSettings.Name = "tclSettings";
            this.tclSettings.SelectedIndex = 0;
            this.tclSettings.Size = new System.Drawing.Size(520, 537);
            this.tclSettings.TabIndex = 1;
            // 
            // tpeSettingsInput
            // 
            this.tpeSettingsInput.Controls.Add(this.nudEditorFontSize);
            this.tpeSettingsInput.Controls.Add(this.lblEditorFontSize);
            this.tpeSettingsInput.Location = new System.Drawing.Point(4, 29);
            this.tpeSettingsInput.Name = "tpeSettingsInput";
            this.tpeSettingsInput.Padding = new System.Windows.Forms.Padding(3);
            this.tpeSettingsInput.Size = new System.Drawing.Size(512, 504);
            this.tpeSettingsInput.TabIndex = 0;
            this.tpeSettingsInput.Text = "Input";
            this.tpeSettingsInput.UseVisualStyleBackColor = true;
            // 
            // lblEditorFontSize
            // 
            this.lblEditorFontSize.AutoSize = true;
            this.lblEditorFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditorFontSize.Location = new System.Drawing.Point(23, 64);
            this.lblEditorFontSize.Name = "lblEditorFontSize";
            this.lblEditorFontSize.Size = new System.Drawing.Size(139, 20);
            this.lblEditorFontSize.TabIndex = 0;
            this.lblEditorFontSize.Text = "Editor Font Size";
            // 
            // nudEditorFontSize
            // 
            this.nudEditorFontSize.Location = new System.Drawing.Point(27, 87);
            this.nudEditorFontSize.Maximum = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.nudEditorFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudEditorFontSize.Name = "nudEditorFontSize";
            this.nudEditorFontSize.Size = new System.Drawing.Size(469, 26);
            this.nudEditorFontSize.TabIndex = 1;
            this.nudEditorFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // dlgSettings
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(520, 618);
            this.Controls.Add(this.tclSettings);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgSettings";
            this.Text = "Kintup - Settings";
            this.panel1.ResumeLayout(false);
            this.tclSettings.ResumeLayout(false);
            this.tpeSettingsInput.ResumeLayout(false);
            this.tpeSettingsInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditorFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.TabControl tclSettings;
        private System.Windows.Forms.TabPage tpeSettingsInput;
        private System.Windows.Forms.NumericUpDown nudEditorFontSize;
        private System.Windows.Forms.Label lblEditorFontSize;
    }
}