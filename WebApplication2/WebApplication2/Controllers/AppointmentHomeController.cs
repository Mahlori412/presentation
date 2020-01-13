using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AppointmentHomeController : Controller
    {
        // GET: AppointmentHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewStatus(tblAppointment a)
        {
            var db = new ClinicEntities2();
            var g = db.tblAppointments.Where(x => x.Patient_Code == a.Patient_Code
                                                 ).FirstOrDefault();
            //var d=db.tblDoctors.Where(x=>x.Doctor_Code )
            try
            {
                if (g != null)
                {
                    Session["PatientCode"] = g.Patient_Code .ToString();
                   ViewBag.Status=g.Status;
                }
            }
            catch (Exception ex)
            {

            }
           
          
            return View(a);
        }
    }
}