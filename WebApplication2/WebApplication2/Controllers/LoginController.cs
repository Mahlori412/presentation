using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblPatient p)
        {
            if(ModelState.IsValid)
            {
                using (ClinicEntities2 db = new ClinicEntities2())
                {
                    try
                    {
                        var g = db.tblPatients.Where(x => x.Patient_Code == p.Patient_Code
                                                   && x.Patient_Password == p.Patient_Password).FirstOrDefault();
                        //var d=db.tblDoctors.Where(x=>x.Doctor_Code )
                        if (g != null)
                        {
                            Session["PatientCode"] = g.Patient_Code.ToString();
                            Session["PatientID"] = g.Patient_Id.ToString();

                            return RedirectToAction("Index","AppointmentHome");
                        }
                        else if(p.Patient_Code =="Admin" && p.Patient_Password =="1234")
                        {
                            return RedirectToAction("Index", "Appointments");
                        }
                       
                    }
                    catch(Exception ex)
                    {

                    }
                    
                }               
            }
            return View(p);
        }
      
    }
}