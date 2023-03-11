using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scannette
{
    public class CommentairesDataBase
    {

        List<Commentaire> commentaireList = new List<Commentaire>();

        configurationFile configurationFile;

        public CommentairesDataBase(configurationFile myConfigurationFile)
        {
            configurationFile = myConfigurationFile;

            var reader = new StreamReader(File.OpenRead(configurationFile.commentaireFilePath));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
                // values[4], values[5], values[2], values[3], values[0], values[1], values[6]

                Commentaire myCommentaire = new Commentaire(values[0].ToString());
                commentaireList.Add(myCommentaire);
            }

            reader.Close();

        }

        public void update()
        {

            var writer = new StreamWriter(File.OpenWrite(configurationFile.adherentFilePath));

            foreach (Commentaire myCommentaire in commentaireList)
            {

                // exemple : line
                writer.WriteLine(myCommentaire);
            }



            writer.Close();


        }

        //Crée un adherent
        public void adherentCreate(string line)
        {

            // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
            Commentaire myNewCommentaire = new Commentaire();

            Console.WriteLine(myNewCommentaire);
            commentaireList.Add(myNewCommentaire);

            var writer = new StreamWriter(File.OpenWrite(configurationFile.dernièreActionFilePath));

            writer.WriteLine("Création d'un nouveau adherent : " + nom + ";" + prenom + ";" + grade + ";" + solde + ";" + codeBar + ";" + motDePasse + ";" + credencialité + " [ Date = " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " ]");
            writer.Close();
        }
    }
}
