using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSession.Models;

namespace WebSession.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Connexion()
        {
            var Authentifie = HttpContext.User.Identity.IsAuthenticated; // Booleen pour savoir si on a un cookie
            ViewData["Authentifie"] = Authentifie;
            Personne personne = null;
            if (Authentifie)
            {
                using (var db = new Model1())
                {
                    personne = (from p in db.Personnes
                                where p.Login == HttpContext.User.Identity.Name
                                select p).FirstOrDefault();
                }
            }
            return View(personne);
        }
        [HttpPost]
        public ActionResult Connexion(Personne personne)
        {
            //Initialisation d'une Personne perso
            Personne perso = null;
            var db = new Model1();
            // Si le model renvoyer dans le form est valide
            if (ModelState.IsValid)
            {
                perso = (from p in db.Personnes
                         where p.Login.Equals(personne.Login) && p.Password.Equals(personne.Password)
                         select p).FirstOrDefault();
                if (perso != null)
                {
                    FormsAuthentication.SetAuthCookie(perso.Login.ToString(), false);
                    ViewData["Authentifie"] = true;
                    return Redirect("/");
                }
            }
            return View(personne);
        }
        public ActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inscription(Personne personne)
        {
            if (ModelState.IsValid)
            {
                using (var model = new Model1())
                {
                    model.Personnes.Add(personne);
                    model.SaveChanges();
                }
                FormsAuthentication.SetAuthCookie(personne.Login.ToString(), true);
                return Redirect("/");
            }
            return View(personne);
        }
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}