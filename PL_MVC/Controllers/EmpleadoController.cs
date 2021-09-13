using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }
        [HttpGet]
        public JsonResult GetAllJS()
        {

            ML.Result result = BL.Empleado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetByIdJS(int IdEmpleado)
        {

            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
      
        [HttpGet]
        public JsonResult DeleteJS(int IdEmpleado)
        {

            ML.Result result = BL.Empleado.Delete(IdEmpleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddJS(ML.Empleado empleado)
        {

            ML.Result result = BL.Empleado.Add(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateJS(ML.Empleado empleado)
        {

            ML.Result result = BL.Empleado.Update(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}