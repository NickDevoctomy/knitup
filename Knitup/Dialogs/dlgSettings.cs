using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knitup.Dialogs
{
    public partial class dlgSettings : Form
    {

        #region constructor / destructor

        public dlgSettings()
        {
            InitializeComponent();
            DisplaySettings();
        }

        #endregion

        #region private methods

        private void DisplaySettings()
        {
            nudEditorFontSize.Value = Properties.Settings.Default.EditorFontSize;
        }

        private void ApplySettings()
        {
            Properties.Settings.Default.EditorFontSize = (Int32)nudEditorFontSize.Value;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region object events

        private void butOK_Click(object sender, EventArgs e)
        {
            ApplySettings();
            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
