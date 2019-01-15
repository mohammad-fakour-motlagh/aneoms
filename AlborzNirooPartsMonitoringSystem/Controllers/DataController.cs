using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlborzNirooPartsMonitoringSystem.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        //GET: Data/InsertPartDefinition
        public ActionResult InsertPartDefinition()
        {
            return View();
        }

        //GET: Data/AddNewerPartNumber
        public ActionResult AddNewerPartNumber()
        {
            return View();
        }

        //GET: Data/AddPart
        public ActionResult AddPart()
        {
            return View();
        }
    }
}