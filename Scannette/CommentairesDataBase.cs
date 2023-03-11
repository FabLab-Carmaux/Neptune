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
        configurationFile configurationFile;
        List<Commentaire> commentaireList = new List<Commentaire>();

        public CommentairesDataBase(configurationFile myConfigurationFile)
        {
            configurationFile = myConfigurationFile;

            var reader = new StreamReader(File.OpenRead(myConfigurationFile.commentaireFilePath));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                Commentaire myCommentaire = new Commentaire(line);
                commentaireList.Add(myCommentaire);
            }
            reader.Close();

        }

        //Crée un adherent
        public void createCom(string line, string adherentCodeBar)
        {

            // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
            Commentaire myNewCommentaire = new Commentaire(line);
            commentaireList.Add(myNewCommentaire);

            Console.WriteLine("Ajout d'un nouveau commentaire : [" + line +"] par : "+ adherentCodeBar + "[ Date = " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " ]");

            var writer = new StreamWriter(File.OpenWrite(configurationFile.commentaireFilePath));

            writer.WriteLine(myNewCommentaire.line);
            writer.Close();
        }
    }
}
