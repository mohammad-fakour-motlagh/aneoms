using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlborzNirooEnginesObservationAndMonitoringSystem.Models;

namespace AlborzNirooEnginesObservationAndMonitoringSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            var apd1 = new AssemblyPartDefinition() { Description = "CrankShaft", NumberInParent = 1 };
            db.AssemblyPartDefinitions.Add(apd1);
            db.SaveChanges();
            var pnm1 = new PartNumberModel() { PartNumber = "8034708", PartNumberSpecificDescription = "cat_300",AssemblyPartDefinitionId=apd1.AssemblyPartDefinitionId };
            db.PartNumberModels.Add(pnm1);
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}