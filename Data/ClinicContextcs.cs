using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oman_Clinic_Appointment.Model;

namespace Oman_Clinic_Appointment.Data
{
    public class ClinicContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Clinics;"+"Integrated Security=True;Connect Timeout=30;Encrypt=True; ");
         


    }
       public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
       public DbSet<Appointment> Appointments { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Appointment>()
                 .HasIndex(a => new { a.DoctorId, a.AppointmentDate })
                 .IsUnique();
         }
    }
}
