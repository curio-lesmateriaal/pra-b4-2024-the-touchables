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
    public class ShopController
    {
        public static Home Window { get; set; }

        public void Start()
        {
            // Stel de prijslijst in aan de rechter kant
            ShopManager.SetShopPriceList("Prijzen:\nFoto 10x15: €2.55\nFotoboek: €14.99\nPoster: €9.99");

            // Stel de bon in onderaan het scherm
            ShopManager.SetShopReceipt("Eindbedrag\n€");

            // Vul de productlijst met producten
            ShopManager.Products.Add(new KioskProduct() { Name = "Foto 10x15", Price = 2.55m, Description = "Afdrukken van uw favoriete foto's" });
            ShopManager.Products.Add(new KioskProduct() { Name = "Fotoboek", Price = 14.99m, Description = "Een mooi fotoboek met al uw herinneringen" });
            ShopManager.Products.Add(new KioskProduct() { Name = "Poster", Price = 9.99m, Description = "Een grote poster van uw foto" });

            // Update dropdown met producten
            ShopManager.UpdateDropDownProducts();
        }

        // Wordt uitgevoerd wanneer er op de Toevoegen knop is geklikt
        public void AddButtonClick()
        {
            // Implementatie voor toevoegen knop
        }

        // Wordt uitgevoerd wanneer er op de Resetten knop is geklikt
        public void ResetButtonClick()
        {
            // Implementatie voor resetten knop
        }

        // Wordt uitgevoerd wanneer er op de Save knop is geklikt
        public void SaveButtonClick()
        {
            // Implementatie voor save knop
        }
    }
}
