using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scannette
{
    public partial class Form2 : Form
    {
        private bool passwordChar = true;

        Adherent myAdherent;
        AdherentDatabase myAdherentDatabase;
        ProductDatabase myProductDataBase2;
        dernièreActionFile myDernièreActionFile2;
        configurationFile configurationFile;
        public Form2(Adherent adherent, AdherentDatabase adherentDatabase, ProductDatabase myProductDataBase, dernièreActionFile myDernièreActionFile, configurationFile myConfigurationFile)
        {
            myAdherent = adherent;
            myAdherentDatabase = adherentDatabase;
            myProductDataBase2 = myProductDataBase;
            myDernièreActionFile2 = myDernièreActionFile;
            configurationFile = myConfigurationFile;

            InitializeComponent();

            if (adherent.getGrade() == 1)
            {
                tabControl1.TabPages[1].Hide();
            }
            else if (adherent.getGrade() == 2)
            {
                tabControl1.TabPages[1].Show();
            }
            else if (adherent.getGrade() == 3)
            {
                tabControl1.TabPages[1].Show();
            }
        }
    }
}
