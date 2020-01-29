using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSession.Models;

namespace WebSession.Controllers
{
    public class ListController : Controller
    {
        static Model1 model = new Model1();

        // Methode List
        public ActionResult List()
        {
            ViewBag.list = model.Items.ToList();
            return View();
        }
        [Authorize]
        // Methode pour retourner la vue AjouterList
        public ActionResult GetAjouterList()
        {
            return View("AjouterList");
        }
        // Methode pour ajouter un produit (methode Post)
        [HttpPost]
        public ActionResult AjouterList(Item item)
        {
            // Si le model est valide
            if (ModelState.IsValid)
            {
                model.Items.Add(item);
                model.SaveChanges();
                return View("../Home/Index");
            }
            return View("List"); 
        }
    }
}