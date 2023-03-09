using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scannette
{
    public class ProductDatabase
    {

        List<Produit> produitList = new List<Produit>();

        public ProductDatabase(configurationFile myConfigurationFile)
        {

            var reader = new StreamReader(File.OpenRead(myConfigurationFile.productFilePath));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                Produit myProduit = new Produit(values[1], values[2], Int32.Parse(values[3]), values[4], Int32.Parse(values[5])) ;
                produitList.Add(myProduit);
            }
            reader.Close();
        }

        public Produit searchProduitByCodeBar(string codeBarre)
        {
            foreach (Produit produit in produitList)
            {
                if (produit.getCodeBar() == codeBarre)
                {
                    return produit;
                }
            }

            return null;
        }
    }
}
