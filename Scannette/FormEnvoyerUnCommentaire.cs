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
    
    public partial class FormEnvoyerUnCommentaire : Form
    {
        CommentairesDataBase commentairesDataBase;
        Adherent adherent;
        public FormEnvoyerUnCommentaire(CommentairesDataBase myCommentairesDataBase, Adherent myAdherent)
        {
            adherent = myAdherent;
            commentairesDataBase = myCommentairesDataBase;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous envoyer ce commentaire" , "ATTENTION" , MessageBoxButtons.OKCancel , MessageBoxIcon.Warning) == DialogResult.OK)
            {
                commentairesDataBase.createCom(textBoxID.Text, adherent.getCodeBar());
                MessageBox.Show("Commentaire envoyé", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}
