using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scannette
{
    public class AdherentDatabase
    {

        List<Adherent> adherentList = new List<Adherent>();

        configurationFile configurationFile;

        public AdherentDatabase(configurationFile myConfigurationFile)
        {
            configurationFile = myConfigurationFile;

                var reader = new StreamReader(File.OpenRead(configurationFile.adherentFilePath));

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
                // values[4], values[5], values[2], values[3], values[0], values[1], values[6]

                Adherent myAdherent = new Adherent(values[5], values[4], Int32.Parse(values[2]), Int32.Parse(values[3]), values[0], values[1], bool.Parse(values[6]));
                adherentList.Add(myAdherent);
                }

            reader.Close();

        }

    public Adherent searchAdherentByCodeBar(string codeBar)
        {
            foreach (Adherent myAdherent in adherentList)
            {
                if (myAdherent.getCodeBar() == codeBar)
                {

                    return myAdherent;
                }
            }

            return null;
        }

        public bool deleteCompteWithId(string Id)
        {
            foreach (Adherent myAdherent in adherentList)
            {
                if (myAdherent.getCodeBar() == Id)
                {
                    adherentList.Remove(myAdherent);
                    return true;
                }
            }
            return false;
        }
        public void update()
        {
        
            var writer = new StreamWriter(File.OpenWrite(configurationFile.adherentFilePath));

            foreach (Adherent myAdherent in adherentList)
            {

                // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
                writer.WriteLine(myAdherent.getCodeBar() + ";" + myAdherent.getCredential() + ";" + myAdherent.getGrade().ToString() + ";" + myAdherent.getSolde().ToString() + ";" + myAdherent.getPrenom() + ";" + myAdherent.getNom() + ";" + myAdherent.getPolitiqueCredential().ToString());
            }



            writer.Close();


        }

        //Crée un adherent
        public void adherentCreate(string codeBar ,string motDePasse ,int grade ,int solde ,string prenom ,string nom, bool credencialité)
        {

            // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
            Adherent myNewAdherent = new Adherent(nom, prenom, grade, solde, codeBar, motDePasse, credencialité);

            Console.WriteLine("Création d'un nouveau adherent : " + nom + ";" + prenom + ";" + grade + ";" + solde + ";" + codeBar + ";" + motDePasse + ";" + credencialité);
            adherentList.Add(myNewAdherent);

            var writer = new StreamWriter(File.OpenWrite(configurationFile.dernièreActionFilePath));
            
            writer.WriteLine("Création d'un nouveau adherent : " + nom + ";" + prenom + ";" + grade + ";" + solde + ";" + codeBar + ";" + motDePasse + ";" + credencialité + " [ Date = " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " ]");
            writer.Close();
        }
    }
}
