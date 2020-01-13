using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AppointmentsController : Controller
    {
        private ClinicEntities2 db = new ClinicEntities2();

        // GET: Appointments
        public ActionResult Index()
        {
            var tblAppointments = db.tblAppointments.Include(t => t.tblDoctor).Include(t => t.tblPatient);
            return View(tblAppointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAppointment tblAppointment = db.tblAppointments.Find(id);
            if (tblAppointment == null)
            {
                return HttpNotFound();
            }
            return View(tblAppointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.Doctor_Code = new SelectList(db.tblDoctors, "Doctor_Code", "Doctor_Name");
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Appointment_Id,Appointment_Date,Appointment_Time,Appointment_Type,Doctor_Code,Patient_Code,Appointment_Room,Appointment_Code,Status")] tblAppointment tblAppointment)
        {
            if (ModelState.IsValid)
            {
                tblAppointment.Status = "Pending";
                db.tblAppointments.Add(tblAppointment);
                db.SaveChanges();
                return RedirectToAction("Index","AppointmentHome");
            }

            ViewBag.Doctor_Code = new SelectList(db.tblDoctors, "Doctor_Code", "Doctor_Name", tblAppointment.Doctor_Code);
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name", tblAppointment.Patient_Code);
            return View(tblAppointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAppointment tblAppointment = db.tblAppointments.Find(id);
            if (tblAppointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctor_Code = new SelectList(db.tblDoctors, "Doctor_Code", "Doctor_Name", tblAppointment.Doctor_Code);
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name", tblAppointment.Patient_Code);
            return View(tblAppointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Appointment_Id,Appointment_Date,Appointment_Time,Appointment_Type,Doctor_Code,Patient_Code,Appointment_Room,Appointment_Code,Status")] tblAppointment tblAppointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAppointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor_Code = new SelectList(db.tblDoctors, "Doctor_Code", "Doctor_Name", tblAppointment.Doctor_Code);
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name", tblAppointment.Patient_Code);
            return View(tblAppointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAppointment tblAppointment = db.tblAppointments.Find(id);
            if (tblAppointment == null)
            {
                return HttpNotFound();
            }
            return View(tblAppointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblAppointment tblAppointment = db.tblAppointments.Find(id);
            db.tblAppointments.Remove(tblAppointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
