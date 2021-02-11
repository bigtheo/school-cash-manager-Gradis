using System;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmApercuAvantImpression : Form
    {
        public FrmApercuAvantImpression()
        {
            InitializeComponent();
            AfficherLeFichier();
        }

        private void AfficherLeFichier()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ficher_rapport.pdf");
            axFoxitCtl1.OpenFile(fileName);
        }
    }
}