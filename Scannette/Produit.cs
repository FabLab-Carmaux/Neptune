using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scannette
{
    public class Produit
    {
        private string nom;
        private string codeBarre;
        private float prix;
        private string contenance;
        public int nombreDansLeFrigo;

        public Produit(string myCodeBarre, string myNom, float myPrix, string myCntenance, int myNombreFrigo)
        {
            nom = myNom;
            codeBarre = myCodeBarre;
            prix = myPrix;
            contenance = myCntenance;
            nombreDansLeFrigo = myNombreFrigo;
        }

//
// Get settings
//
        public string getNom()
        {
            return nom;
        }

        public string getCodeBar()
        {
            return codeBarre;
        }

        public float getPrice()
        {
            return prix;
        }

        public string getContenance()
        {
            return contenance;
        }

        public int getNomberIntoFrigo()
        {
            return nombreDansLeFrigo;
        }

//
// Set settings
//
        public void setNom(string newName)
        {
            nom = newName;
        }

        public void setCodeBar(string newCodeBar)
        {
            codeBarre = newCodeBar;
        }

        public void setPrice(float newPrice)
        {
            prix = newPrice;
        }

        public void setContenance(string newContenance)
        {
            contenance = newContenance;
        }

        public void setNomberIntoFrigo(int newNomberIntoFrigo)
        {
            nombreDansLeFrigo = newNomberIntoFrigo;
        }
//
// Other
//
        public bool ilYADansLeFrigo(int myNombreFrigo)
        {
            if (myNombreFrigo > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
