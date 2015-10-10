using KnitupFramework.Markdown;
using KnitupFramework.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //String[] pStrMarkdownLines = File.ReadAllLines(@"C:\Users\nickp\Dropbox\Mum\Remastered\Nativity_2015_v1.0.md");
            //Parser pParParser = Parser.Parse(pStrMarkdownLines);
            //Generator pGenGenerator = new Generator(pParParser);
            //pGenGenerator.Generate();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
