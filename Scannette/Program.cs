using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scannette
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            configurationFile myConfigurationFile = null;
            AdherentDatabase myAdherentDatabase = null;
            dernièreActionFile myDernièreActionFile = null;
            ProductDatabase myProductDatabase = null;
            try
            {
                myConfigurationFile = new configurationFile();
            }
            catch (Exception ex)
            {
 

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Application.MessageLoop == true)
                {
                    Application.Exit();
                }
                else
                {
                    Environment.Exit(1);
                }
            }


            try
            {
                 myAdherentDatabase = new AdherentDatabase(myConfigurationFile);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Application.MessageLoop == true)
                {
                    Application.Exit();
                }
                else
                {
                    Environment.Exit(1);
                }
            }

            try
            {
                myDernièreActionFile = new dernièreActionFile(myConfigurationFile);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Application.MessageLoop == true)
                {
                    Application.Exit();
                }
                else
                {
                    Environment.Exit(1);
                }
            }

            try
            {
                myProductDatabase = new ProductDatabase(myConfigurationFile);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Application.MessageLoop == true)
                {
                    Application.Exit();
                }
                else
                {
                    Environment.Exit(1);
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(myConfigurationFile, myAdherentDatabase, myDernièreActionFile, myProductDatabase));
        }
    }
}
