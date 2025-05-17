using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Oman_Clinic_Appointment.Data;
using Oman_Clinic_Appointment.Model;

namespace Oman_Clinic_Appointment.Services
{
    public class ClinicService
    {
        private readonly ClinicContext _context;

        public ClinicService()
        {
            _context = new ClinicContext();
        }

        public void RegisterPatient(string name, string phone)
        {
            var patient = new Patient { Name = name, PhoneNumber = phone };
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void RegisterDoctor(string name, string specialty)
        {
            var doctor = new Doctor { Name = name, Specialty = specialty };
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public List<Doctor> GetDoctorsBySpecialty(string specialty)
        {
            return _context.Doctors
                .Where(d => d.Specialty == specialty)
                .ToList();
        }

        public void ScheduleAppointment(int patientId, int doctorId, DateTime date)
        {
            var isAvailable = !_context.Appointments.Any(a =>
                a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date);

            if (isAvailable)
            {
                var appt = new Appointment
                {
                    PatientId = patientId,
                    DoctorId = doctorId,
                    AppointmentDate = date
                };
                _context.Appointments.Add(appt);
                _context.SaveChanges();
                Console.WriteLine("Appointment scheduled successfully.");
            }
            else
            {
                Console.WriteLine("Doctor is already booked on that date.");
            }
        }

        public void ViewAppointmentsByPatient(int patientId)
        {
            var appointments = _context.Appointments
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .ToList();

            foreach (var appt in appointments)
            {
                Console.WriteLine($"{appt.AppointmentDate.ToShortDateString()} - Dr. {appt.Doctor.Name} ({appt.Doctor.Specialty})");
            }
        }

        public void ViewAllAppointments()
        {
            var appointments = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToList();

            foreach (var appt in appointments)
            {
                Console.WriteLine($"{appt.AppointmentDate.ToShortDateString()}: {appt.Patient.Name} with Dr. {appt.Doctor.Name} ({appt.Doctor.Specialty})");
            }
        }
    }
}


