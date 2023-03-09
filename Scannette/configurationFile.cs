using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scannette
{
    public class configurationFile
    {
        public string configurationFilePath = @".\configuration.txt";
        public string productFilePath;
        public string adherentFilePath;
        public bool nightMode;
        public int debugMode;
        public string dernièreActionFilePath;

        public configurationFile()
        {
            StreamReader reader = new StreamReader(File.OpenRead(configurationFilePath));

            

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('=');

                if (values[0] == "adherentFilePath")
                {
                    adherentFilePath = values[1];
                }
                if (values[0] == "productFilePath")
                {
                    productFilePath = values[1];
                }
                if (values[0] == "nightMode")
                {
                    nightMode = Convert.ToBoolean(values[1]);
                }
                if (values[0] == "debugMode")
                {
                    debugMode = Convert.ToInt32(values[1]);
                }
                if (values[0] == "dernièreActionFilePath")
                {
                    dernièreActionFilePath = values[1];
                }
            }

        }


    }
}

