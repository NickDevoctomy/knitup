using KnitupFramework.Project;
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

    public partial class frmSelectProjectImage : Form
    {

        #region private objects

        private ProjectImages cPIsImages;

        #endregion

        #region public properties

        public ProjectImages Images
        {
            get
            {
                return (cPIsImages);
            }
            set
            {
                cPIsImages = value;
                ListImages();
            }
        }

        public String SelectedImageKey { get; private set; }

        #endregion

        #region constructor / destructor

        public frmSelectProjectImage()
        {
            InitializeComponent();
        }

        #endregion

        #region private methods

        private void ListImages()
        {
            lbxImages.Items.Clear();
            foreach (String curImageKey in Images.Images.Keys)
            {
                lbxImages.Items.Add(curImageKey.Replace("images\\", String.Empty));
            }
        }

        #endregion

        #region object events

        private void lbxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxImages.SelectedIndex > -1)
            {
                String pStrKey = lbxImages.SelectedItem.ToString();
                picPreview.Image = Images.Images["images\\" + pStrKey];
                SelectedImageKey = pStrKey;
            }
        }

        #endregion


    }

}
