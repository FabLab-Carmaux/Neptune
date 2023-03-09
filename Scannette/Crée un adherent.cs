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
    public partial class Crée_un_adherent : Form
    {
        AdherentDatabase myAdherentDatabase;
        dernièreActionFile myDernièreActionFile2;
        Adherent myAdherent2;
        public Crée_un_adherent(AdherentDatabase adherentDatabase, dernièreActionFile myDernièreActionFile, Adherent myAdherent)
        {
            myAdherentDatabase = adherentDatabase;
            myDernièreActionFile2 = myDernièreActionFile;
            myAdherent2 = myAdherent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void buttonCreateAccouteCreate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBoxIDAccoute.Text != "" && textBoxMdpAccoute.Text != "")
            {


                if (MessageBox.Show("Attention voulez vous crée un compte avec ces informations.", "ATTENTION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    Console.WriteLine("Cancel");
                }
                else
                {
                    Console.WriteLine("OK");

                    string codeBar = textBoxIDAccoute.Text;
                    string motDePasse = textBoxMdpAccoute.Text;
                    int solde = trackBarPoint.Value;
                    int grade = trackBarGrade.Value;
                    string prenom = textBox1.Text;
                    string nom = textBox2.Text;
                    bool credential = false;

                    myAdherentDatabase.adherentCreate(codeBar, motDePasse, grade, solde, prenom, nom, credential);
                    
                    myAdherentDatabase.update();
                    
                    myDernièreActionFile2.dernièreActionCreateLine("Création d'un nouveau adherent à partir du compte, =(" + myAdherent2.getCodeBar() + ").Adherent crée = [ " + codeBar + ";" + motDePasse + ";" + grade + ";" + solde + ";" + prenom + ";" + nom + ";" + credential + " ]");
                    myDernièreActionFile2.update();

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Vous avez oublier une information", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trackBarGrade_Scroll(object sender, EventArgs e)
        {
            labelGradeSelected.Text = trackBarGrade.Value.ToString();
        }

        private void trackBarPoint_Scroll(object sender, EventArgs e)
        {
            labelSoldeSelected.Text = trackBarPoint.Value.ToString();
        }
    }
}
