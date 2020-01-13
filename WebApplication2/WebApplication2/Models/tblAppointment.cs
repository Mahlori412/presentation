//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblAppointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAppointment()
        {
            this.tblInvoices = new HashSet<tblInvoice>();
        }
    
        public int Appointment_Id { get; set; }
        
        public System.DateTime Appointment_Date { get; set; }
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> Appointment_Time { get; set; }
        public string Appointment_Type { get; set; }
        public string Doctor_Code { get; set; }
        public string Patient_Code { get; set; }
        public string Appointment_Room { get; set; }
        public string Appointment_Code { get; set; }
        public string Status { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
        public virtual tblPatient tblPatient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblInvoice> tblInvoices { get; set; }
    }
}