﻿using System;
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
    public class InvoicesController : Controller
    {
        private ClinicEntities2 db = new ClinicEntities2();

        // GET: Invoices
        public ActionResult Index()
        {
            var tblInvoices = db.tblInvoices.Include(t => t.tblAppointment).Include(t => t.tblPatient);
            return View(tblInvoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            if (tblInvoice == null)
            {
                return HttpNotFound();
            }
            return View(tblInvoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.Appointment_Code = new SelectList(db.tblAppointments, "Appointment_Code", "Appointment_Code");
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bill_Id,Bill_Date,Appointment_Code,Bill_Code,Patient_Code")] tblInvoice tblInvoice)
        {
            if (ModelState.IsValid)
            {
                db.tblInvoices.Add(tblInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Appointment_Code = new SelectList(db.tblAppointments, "Appointment_Code", "Appointment_Code", tblInvoice.Appointment_Code);
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name", tblInvoice.Patient_Code);
            return View(tblInvoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            if (tblInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Appointment_Code = new SelectList(db.tblAppointments, "Appointment_Code", "Appointment_Type", tblInvoice.Appointment_Code);
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name", tblInvoice.Patient_Code);
            return View(tblInvoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bill_Id,Bill_Date,Appointment_Code,Bill_Code,Patient_Code")] tblInvoice tblInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Appointment_Code = new SelectList(db.tblAppointments, "Appointment_Code", "Appointment_Type", tblInvoice.Appointment_Code);
            ViewBag.Patient_Code = new SelectList(db.tblPatients, "Patient_Code", "Patient_Name", tblInvoice.Patient_Code);
            return View(tblInvoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            if (tblInvoice == null)
            {
                return HttpNotFound();
            }
            return View(tblInvoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            db.tblInvoices.Remove(tblInvoice);
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
