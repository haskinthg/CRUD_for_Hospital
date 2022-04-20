using AdonisUI.Controls;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Hospital.Model
{
    internal static class Data
    {
        public static int HospitalId { get; set; }
        public static int DepartmentId { get; set; }
        public static int PatientId { get; set; }
        public static int DoctorId { get; set; }
        
        public static Doctor FindDoctor(int id)
        {
            var doctor = new Doctor();
            using(var db = new dbhospitalsContext())
            {
                doctor = db.Doctors.FirstOrDefault(i=>i.DoctorId==id);
            }
            return doctor;
        }

        public static Patient FindPatient(int id)
        {
            var p = new Patient();
            using (var db = new dbhospitalsContext())
            {
                p = db.Patients.FirstOrDefault(i => i.PatientId == id);
            }
            return p;
        }

        public static ObservableCollection<Patient> GetAllPatients()
        {
            var all = new ObservableCollection<Patient>();
            using (var db = new dbhospitalsContext())
            {
                all = new ObservableCollection<Patient>(db.Patients);
            }
            return all;
        }

        public static ObservableCollection<Department> GetAllDepartments()
        {
            var all = new ObservableCollection<Department>();
            using (var db = new dbhospitalsContext())
            {
                all = new ObservableCollection<Department>(db.Departments);
            }
            return all;
        }

        public static ObservableCollection<Doctor> GetDoctors(int id)
        {
            var all = new ObservableCollection<Doctor>();
            using (var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter DepartmentId = new Npgsql.NpgsqlParameter("@DepartmentId",id);
                all = new ObservableCollection<Doctor>(db.Doctors.FromSqlRaw("SELECT * FROM DOCTORS WHERE Department_Id = @DepartmentId",DepartmentId));
            }
            return all;
        }
        public static ObservableCollection<Doctor> GetAllDoctors()
        {
            var all = new ObservableCollection<Doctor>();
            using (var db = new dbhospitalsContext())
            {
                all = new ObservableCollection<Doctor>(db.Doctors);
            }
            return all;
        }

        public static ObservableCollection<Hospital> GetAllHospitals()
        {
            var all = new ObservableCollection<Hospital>();
            using(var db = new dbhospitalsContext())
            {
                all = new ObservableCollection<Hospital>(db.Hospitals);
            }
            return all;
        }

        public static ObservableCollection<Visit> GetVisitsOfPatient(int id)
        {
            var all = new ObservableCollection<Visit>();
            using(var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter DoctorId = new Npgsql.NpgsqlParameter("@DoctorId", id);
                all = new ObservableCollection<Visit>(db.Visits.FromSqlRaw("SELECT * FROM VISITS WHERE DOCTOR_ID = @DoctorId", DoctorId));
            }
            return all;
        }

        public static void AddToPatients(Patient p)
        {
            using (var db = new dbhospitalsContext())
            {
                if (!db.Patients.Contains(p))
                {
                    db.Patients.Add(p);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToVisits(Visit v)
        {
            using(var db= new dbhospitalsContext())
            {
                if(!db.Visits.Contains(v))
                {
                    db.Visits.Add(v);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToDoctors(Doctor d)
        {
            using(var db = new dbhospitalsContext())
            {
                if(!db.Doctors.Contains(d))
                {
                    db.Doctors.Add(d);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToHospitals(Hospital h)
        {
            using( var db = new dbhospitalsContext())
            {
                if(db.Hospitals.Contains(h))
                {
                    db.Hospitals.Add(h);
                    db.SaveChanges();
                }
            }
        }


        public static void DeleteFromPatients(Patient p)
        {
            using(var db = new dbhospitalsContext())
            {
                db.Patients.Remove(p);
                db.SaveChanges();
            }
        }
        
        public static void UpdatePatient(Patient oldp, string First, string Second, string Last, long Phone)
        {
            using (var db = new dbhospitalsContext())
            {
                var searchPatient = db.Patients.Find(oldp);
                searchPatient.PFirstname= First;
                searchPatient.PSecondname= Second;
                searchPatient.PLastname= Last;
                searchPatient.PPhone= Phone;
                db.SaveChanges();
            }
        }
    }
}
