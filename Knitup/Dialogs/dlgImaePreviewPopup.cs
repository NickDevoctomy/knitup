using System.Drawing;
using System.Windows.Forms;

namespace Knitup.Dialogs
{
    public partial class dlgImaePreviewPopup : Form
    {

        #region public Properties

        public Image Image
        {
            get
            {
                return (picPreview.Image);
            }
            set
            {
                picPreview.Image = value;
            }
        }

        #endregion

        #region constructor / destructor

        public dlgImaePreviewPopup()
        {
            InitializeComponent();
        }

        #endregion

    }
}
