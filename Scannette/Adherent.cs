using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scannette
{
    public class Adherent
    {
        private const int minimumPasswordLetter = 8;
        private const int gradeAdmin = 3;
        private const int gradeGerant = 2;
        private const int gradeMembre = 1;
        private string nom;
        private string prenom;
        private int grade;
        private int solde;
        private string codeBar;
        private string credential;
        private bool politiqueConfidencial;

        public Adherent(string myNom, string myPrenom, int myGrade, int mySolde, string myCodeBar, string myCredential, bool myPolitiqueConfidencial)
        {
            nom = myNom;
            prenom = myPrenom;
            grade = myGrade;
            solde = mySolde;
            codeBar = myCodeBar;
            credential = myCredential;
            politiqueConfidencial = myPolitiqueConfidencial;
        }

//
// Get settings
//
        public int getMinimumPasswordLetter()
        {
            return minimumPasswordLetter;
        }

        public int getVarAdmin()
        {
            return gradeAdmin;
        }

        public int getVarGerant()
        {
            return gradeGerant;
        }

        public int getVarMembre()
        {
            return gradeMembre;
        }

        public string getCodeBar()
        {
            return codeBar;
        }

        public string getNom()
        {
            return nom;
        }

        public string getPrenom()
        {
            return prenom;
        }

        public int getGrade()
        {
            return grade;
        }

        public int getSolde()
        {
            return solde;
        }

        public string getCredential()
        {
            return credential;
        }

        public bool getPolitiqueCredential()
        {
            return politiqueConfidencial;
        }

//
// Set settings
//

        public void setPolitiqueConfidencial(bool newPolitiqueConfidential)
        {
            politiqueConfidencial = newPolitiqueConfidential;
        }

        public void setSolde(int newSolde)
        {
            solde = newSolde;
        }

        public void setGrade(int newGrade)
        {
            grade = newGrade;
        }

        public void setPrenom(string newPrenom)
        {
            prenom = newPrenom;
        }

        public void setNom(string newNom)
        {
            nom = newNom;
        }

        public bool setCredential(string newCredential)
        {
            
            if (newCredential.Length < minimumPasswordLetter)
            {
                return false;
            }
            else
            {
                credential = newCredential;
                return true;
            }
        }

        public void setCodeBar(string newCodeBar)
        {
            codeBar = newCodeBar;
        }

//
// Other
//

        public bool isAdmin()
        {
            if (grade == 3)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool isGerant()
        {
            if (grade == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isPasswordCorrect(string myPassword)
        {
            if (myPassword == credential)
            {
                return true;
            } else
            {
                return false;
            }

        }


    }
}
