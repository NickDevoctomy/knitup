using System;
using System.Windows.Forms;
using KnitupFramework.IO;

namespace Knitup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //"Text files (*.txt)|*.txt|All files (*.*)|*.*"

            //All Suppoprted Image Types (*.bmp,*.gif,*.jpeg,*.jpg,*.png)|*.bmp,*.gif,*.jpeg,*.jpg,*.png|
            //BMP Image (*.bmp)|*.bmp|
            //GIF Image (*.gif)|*.gif|
            //JPEG Image (*.jpeg)|*.jpeg|
            //JPG Image (*.jpg)|*.jpg|
            //PNG Image (*.png)|*.png

            string pants = FileExtensionUtility.GetFileExtensionFilterString(FileExtensionCollection.EXTENSION_COLLECTION_IMAGE_ALL,
                true,
                true);

            using (OpenFileDialog pop = new OpenFileDialog())
            {
                pop.Filter = pants;
                pop.ShowDialog();
            }
            return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
