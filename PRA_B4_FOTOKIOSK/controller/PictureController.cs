using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class PictureController
    {
        // De window die we laten zien op het scherm
        public static Home Window { get; set; }

        // De lijst met fotos die we laten zien
        public List<KioskPhoto> PicturesToDisplay = new List<KioskPhoto>();

        // Start methode die wordt aangeroepen wanneer de foto pagina opent.
        public void Start()
        {
            // Huidige dagnummer verkrijgen (0 = Zondag t/m 6 = Zaterdag)
            var now = DateTime.Now;
            int vandaagDagNummer = (int)now.DayOfWeek;

            // Initializeer de lijst met fotos
            // WAARSCHUWING. ZONDER FILTER LAADT DIT ALLES!
            // foreach is een for-loop die door een array loopt
            foreach (string dir in Directory.GetDirectories(@"../../../fotos"))
            {
                /**
                 * dir string is de map waar de fotos in staan. Bijvoorbeeld:
                 * \fotos\0_Zondag
                 */
                // Verkrijg alleen de mapnaam zonder het pad
                string mapNaam = Path.GetFileName(dir);

                // Split de mapnaam op het onderstrepingsteken
                string[] delen = mapNaam.Split('_');

                if (delen.Length > 1)
                {
                    // Probeer het eerste deel te parsen naar een integer
                    if (int.TryParse(delen[0], out int mapDagNummer))
                    {
                        // Vergelijk met het huidige dagnummer
                        if (mapDagNummer == vandaagDagNummer)
                        {
                            foreach (string file in Directory.GetFiles(dir))
                            {
                                /**
                                 * file string is de file van de foto. Bijvoorbeeld:
                                 * \fotos\0_Zondag\10_05_30_id8824.jpg
                                 */
                                PicturesToDisplay.Add(new KioskPhoto() { Id = 0, Source = file });
                            }
                        }
                    }
                }
            }

            // Update de fotos
            PictureManager.UpdatePictures(PicturesToDisplay);
        }

        // Wordt uitgevoerd wanneer er op de Refresh knop is geklikt
        public void RefreshButtonClick()
        {
            // Herlaad de foto's
            PicturesToDisplay.Clear();
            Start();
        }
    }
}
