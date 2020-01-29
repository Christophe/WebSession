using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSession.Models;

namespace WebSession.Controllers
{
    public class BuyController : Controller
    {
        static Model1 model = new Model1();
        // Methode pour acheter un item
        public ActionResult GetPanier()
        {
            // Affiche la liste des items
            ViewBag.list = model.Items.ToList();
            ViewBag.panier = Session["panier"];

            return View("Panier");
        }
        //[HttpPost]
        public ActionResult Panier(Item item)
        {
            if (Session["panier"] == null)
            {
                Session["panier"] = new List<Item>();
            }
            // On recherche un produit ou des produits par l'id et on le sauvegarde en session 
            // Si l'id de item existe dans la liste Items

            if (model.Items.Find(item.Id) != null)
            {
                item = model.Items.Find(item.Id);
                // Alors on sauvegarde cet item en session
                var list = (List<Item>)Session["panier"];
                list.Add(item);
                ViewBag.panier = list;
                return View("Achat");
            }
            return RedirectToAction("GetPanier");
        }

        public ActionResult Achat()
        {

            return View("Achat");
        }
    }
}