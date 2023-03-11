using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Scannette
{
    public partial class Form1 : Form
    {
        private bool passwordChar = true;

        configurationFile configurationFile;
        AdherentDatabase adherentDatabase;
        ProductDatabase productDatabase;
        dernièreActionFile actionFile;
        CommentairesDataBase commentairesDataBase;

        //, dernièreActionFile myDernièreActionFile, ProductDatabase myProductDataBase

        public Form1(configurationFile myConfigurationFile, AdherentDatabase myAdherentDatabase, dernièreActionFile myDernièreActionFile, ProductDatabase myProductDataBase, CommentairesDataBase myCommentairesDataBase)
        {
            configurationFile = myConfigurationFile;
            adherentDatabase = myAdherentDatabase;
            commentairesDataBase = myCommentairesDataBase;


            actionFile = myDernièreActionFile;
            productDatabase = myProductDataBase;
            if (configurationFile.nightMode == true)
            {
                this.BackColor = Color.Black;


            }
            else
            {

            }
            InitializeComponent();

            if (myConfigurationFile.debugMode > 0 && myConfigurationFile.debugMode < 4)
            {
                MessageBox.Show("Vous avez lancé NEPTUNE avec la configuration => Debug de niveau " + myConfigurationFile.debugMode, "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Console.WriteLine("OK pour le debug qui est au niveau : " + myConfigurationFile.debugMode);
                Console.WriteLine("OK pour le debug adherentFilePath : " + myConfigurationFile.adherentFilePath);
                Console.WriteLine("OK pour le debug productFilePath: " + myConfigurationFile.productFilePath);
                Console.WriteLine("OK pour le debug nightMode : " + myConfigurationFile.nightMode);

            }
            else if (myConfigurationFile.debugMode > 3 )
            {
                MessageBox.Show("Vous avez lancé NEPTUNE avec la configuration => Debug de niveau " + myConfigurationFile.debugMode + " .Ce niveau de debug mode n'est pas compatible. Veuillez appeler un conseiller numérique.", "ATTENTION", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        public Form1()
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {





        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ID = textBoxID.Text;

            Adherent adherent = adherentDatabase.searchAdherentByCodeBar(ID);

            if (adherent == null)
            {
                Console.WriteLine("Adherent inconnu");
                MessageBox.Show("Adherent inconnu", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (adherent.getGrade() > 1)
                {
                    if (adherent.getCredential() == textBoxPassword.Text)
                    {
                        Form2 form2 = new Form2(this, adherent, adherentDatabase, productDatabase, actionFile, configurationFile, commentairesDataBase) ;
                        form2.Show();
                        Console.WriteLine("Adherent connu");

                        actionFile.dernièreActionCreateLine("Connexion d'un adherent, code bar =(" + adherent.getCodeBar() + "), à [ " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " ]");

                        actionFile.update();

                        textBoxID.Text = "";
                        textBoxPassword.Text = "";

                        this.Hide();
                    } else
                    {
                        MessageBox.Show("Mot de passe invalide","ERREUR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }


                } else
                {
                    Form2 form2 = new Form2(this,adherent, adherentDatabase, productDatabase, actionFile, configurationFile, commentairesDataBase);
                    form2.Show();
                    Console.WriteLine("Adherent connu");

                    actionFile.dernièreActionCreateLine("Identification d'un adherent, code bar =(" + adherent.getCodeBar() + "), à [ " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " ]");

                    actionFile.update();

                    textBoxID.Text = "";
                    textBoxPassword.Text = "";
                    this.Hide();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop == true)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            string ID = textBoxID.Text;

            Adherent adherent = adherentDatabase.searchAdherentByCodeBar(ID);

            if (adherent != null && adherent.getGrade() > 1)
            {
                label5.Visible = true;
                textBoxPassword.Visible = true;
                checkBoxPasswordChar.Visible = true;
            }else
            {
                label5.Visible = false;
                textBoxPassword.Visible = false;
                checkBoxPasswordChar.Visible = false;
            }
        }

        private void checkBoxPasswordChar_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordChar == true)
            {
                passwordChar = false;
                textBoxPassword.PasswordChar = '\u0000';
            } else if (passwordChar == false)
            {
                passwordChar = true;
                textBoxPassword.PasswordChar = '*';
            }
        }
    }
}
