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

    public partial class dlgSelectProjectImage : Form
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

        public String SelectedImageID { get; private set; }

        #endregion

        #region constructor / destructor

        public dlgSelectProjectImage()
        {
            InitializeComponent();
        }

        #endregion

        #region private methods

        private void ListImages()
        {
            lbxImages.Items.Clear();
            foreach (ProjectImage curImage in Images.Images.Values)
            {
                lbxImages.Items.Add(curImage);
            }
        }

        #endregion

        #region object events

        private void lbxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxImages.SelectedIndex > -1)
            {
                ProjectImage pPIeImage = (ProjectImage)lbxImages.SelectedItem;
                picPreview.Image = pPIeImage.Image;
                SelectedImageID = pPIeImage.ID;
            }
        }

        #endregion


    }

}
