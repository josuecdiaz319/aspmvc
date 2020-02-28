using Lab.Demo.EF.Entities;
using Lab.Demo.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Lab.Demo.EF.MVC.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionLogic context;


        public RegionController() => context = new RegionLogic();

        // GET: Region
        public ActionResult Index()
        {
            List<Region> regions = context.GetAll();

            return View(regions);
        }
        public ActionResult ModifyForm(Region region)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Modify(Region region)
        {
            if(context.GetOne(region.RegionID) == null)
            {
                SetMessage("Modificar Región", "La región seleccionada no existe.", "alert alert-danger");
                return View("Notification");
            }
            context.update(region);
            SetMessage("Modificar Región", "La región ha sido actualizada.", "alert alert-success");
            return View("Notification");
        }
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Region region)
        {
            if(context.GetOne(region.RegionID) != null)
            {
                SetMessage("Crear Región", "La región que se ingresó ya existe.", "alert alert-danger");
                return View("Notification");
            }
            context.Add(region);
            SetMessage("Crear Región", "La región ha sido creada con éxito.", "alert alert-success");
            return View("Notification");
        }
        [HttpPost]
        public JsonResult Delete(int RegionID, string RegionDescription)
        {
            Region region = context.GetOne(RegionID);
            string message; 
            if (region != null && region.RegionDescription.Trim() == RegionDescription)
            {
                context.delete(RegionID);
                message = "Region deleted successfully";
            }
            else
                message = "Region does not exist";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        private void SetMessage(string header, string message, string style)
        {
            ViewBag.Header = header;
            ViewBag.Message = message;
            ViewBag.MessageStyle = style;
        }
    }
}