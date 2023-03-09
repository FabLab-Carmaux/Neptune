using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scannette
{
    public class dernièreActionFile
    {
        configurationFile configurationFile;
        List<Action> actionList = new List<Action>();

        public dernièreActionFile(configurationFile myConfigurationFile)
        {
            configurationFile = myConfigurationFile;

            var reader = new StreamReader(File.OpenRead(myConfigurationFile.dernièreActionFilePath));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                Action myAction = new Action(line);
                actionList.Add(myAction);
            }
            reader.Close();
        }

        public void dernièreActionCreateLine(string line)
        {

            // exemple : Création d'un nouveau adherent : REY;azzddzd;1;0;006BCC;N7ge8uZy3;False [ Date = 12/21/2022 18:51:02 ]
            Action myNewAction = new Action(line);

            //Console.WriteLine(Action);
            actionList.Add(myNewAction);

            var writer = new StreamWriter(File.OpenWrite(configurationFile.dernièreActionFilePath));
            // DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")

            writer.WriteLine(actionList);

            writer.Close();
        }
        public void update()
        {

            var writer = new StreamWriter(File.OpenWrite(configurationFile.dernièreActionFilePath));

            foreach (Action myAction in actionList)
            {

                // exemple : 001AAA100;azerty;2;10;Arthur;REY;true
                writer.WriteLine(myAction.line);
            }



            writer.Close();


        }
    }
}
