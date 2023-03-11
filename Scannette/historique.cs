using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scannette
{
    public class historique
    {
        public int solde;
        public int debitCredit;
        public string date;
        public string intitulé;
        public historique(string myDate, string myIntitulé, int myDebitCredit, int mySolde)
        {
            solde = mySolde;
            debitCredit = myDebitCredit;
            date = myDate;
            intitulé = myIntitulé;
        }
    }
}
