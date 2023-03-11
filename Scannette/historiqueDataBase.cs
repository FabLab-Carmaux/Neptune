using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scannette
{
    public class historiqueDataBase
    {
        configurationFile configurationFile;
        List<historique> historiqueList = new List<historique>();

        public historiqueDataBase(configurationFile myConfigurationFile)
        {
            configurationFile = myConfigurationFile;

            var reader = new StreamReader(File.OpenRead(myConfigurationFile.historiqueFilePath));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                historique myHistorique = new historique(values[0], values[1], Int32.Parse(values[2]), Int32.Parse(values[3]));
                historiqueList.Add(myHistorique);
            }
            reader.Close();
        }

        public System.Collections.Generic.List<historique> GetList()
        {
            return historiqueList;
        }

        public void dernièreActionCreateHistorique()
        {

            //// exemple : Création d'un nouveau adherent : REY;azzddzd;1;0;006BCC;N7ge8uZy3;False [ Date = 12/21/2022 18:51:02 ]
            //Action myNewAction = new Action(line);

            ////Console.WriteLine(Action);
            //actionList.Add(myNewAction);

            //var writer = new StreamWriter(File.OpenWrite(configurationFile.dernièreActionFilePath));
            //// DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")

            //writer.WriteLine(actionList);

            //writer.Close();
        }
        public void update()
        {

            var writer = new StreamWriter(File.OpenWrite(configurationFile.dernièreActionFilePath));

            foreach (historique myHistorique in historiqueList)
            {

                // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
                writer.WriteLine(myHistorique);
            }



            writer.Close();


        }
    }
}
