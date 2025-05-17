using Oman_Clinic_Appointment.Services;

namespace Oman_Clinic_Appointment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new ClinicService();

            while (true)
            {
                Console.WriteLine("\n========================================");

                Console.WriteLine("\nWelcome to Oman Clinic Appointment");
                Console.WriteLine("\n========================================");

                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Add New Doctor");
                Console.WriteLine("3. Search Doctor by Specialty");
                Console.WriteLine("4. Book Appointment");
                Console.WriteLine("5. View  Patient Appointments ");
                Console.WriteLine("6. View All Appointments");
                Console.WriteLine("0. Exit");
                Console.Write("Enter Your choice: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("-- Register New Patient-- ");

                        Console.Write("Enter Patient Name: ");
                        var pname = Console.ReadLine();
                        Console.Write("Enter National ID ");
                        var NationalID = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        var phone = Console.ReadLine();
                        Console.Write("Patient registered successfully: ");



                        service.RegisterPatient(pname, phone);
                        break;
                    case "2":
                        Console.Write("-- Add New Doctor :-- ");

                        Console.Write("Enter Doctor Name: ");
                        var dname = Console.ReadLine();
                        Console.Write(" Enter Specialty: ");
                        var spec = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        var phonen = Console.ReadLine();
                        Console.Write("Doctor added successfully: ");

                        service.RegisterDoctor(dname, spec);
                        break;
                    case "3":

                        Console.Write("Enter Specialty to search: ");
                        var s = Console.ReadLine();
                        var docs = service.GetDoctorsBySpecialty(s);
                        foreach (var doc in docs)
                            Console.WriteLine($"ID: {doc.DoctorId}, Name: {doc.Name}");
                        break;
                    case "4":
                        Console.Write("Patient ID: ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.Write("Doctor ID: ");
                        int did = int.Parse(Console.ReadLine());
                        Console.Write("Date (yyyy-mm-dd): ");
                        var date = DateTime.Parse(Console.ReadLine());
                        service.ScheduleAppointment(pid, did, date);
                        break;
                    case "5":
                        Console.Write("Patient ID: ");
                        int viewPid = int.Parse(Console.ReadLine());
                        service.ViewAppointmentsByPatient(viewPid);
                        break;
                    case "6":
                        service.ViewAllAppointments();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
    
}
