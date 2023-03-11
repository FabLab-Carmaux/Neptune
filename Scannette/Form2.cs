﻿using System;
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
        CommentairesDataBase commentairesDataBase;
        Form1 myForm1;
        public Form2(Form1 form1,Adherent adherent, AdherentDatabase adherentDatabase, ProductDatabase myProductDataBase, dernièreActionFile myDernièreActionFile, configurationFile myConfigurationFile, CommentairesDataBase myCommentairesDataBase)
        {
            myForm1 = form1;
            myAdherent = adherent;
            myAdherentDatabase = adherentDatabase;
            myProductDataBase2 = myProductDataBase;
            myDernièreActionFile2 = myDernièreActionFile;
            configurationFile = myConfigurationFile;
            commentairesDataBase = myCommentairesDataBase;

            InitializeComponent();

            label11.Text = adherent.getCodeBar();
            label9.Text = adherent.getPrenom();
            label8.Text = adherent.getNom();
            label7.Text = adherent.getSolde().ToString();
            
            if (adherent.getGrade() == 1)
            {
                label6.Text = "Membre";
                tabControlMembre.Visible = true;
                tabControlAdmin.Visible = false;
            }
            else if (adherent.getGrade() == 2)
            {
                label6.Text = "Gerant";
                tabControlMembre.Visible = false;
                tabControlAdmin.Visible = false;
            }
            else if (adherent.getGrade() == 3)
            {
                label6.Text = "Admin";
                tabControlMembre.Visible = false;
                tabControlAdmin.Visible = true;
            }
        }

        private void tabPageAddMember_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            myForm1.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormEnvoyerUnCommentaire formEnvoyerUnCommentaire = new FormEnvoyerUnCommentaire(commentairesDataBase, myAdherent);
            formEnvoyerUnCommentaire.Show();
        }
    }
}
