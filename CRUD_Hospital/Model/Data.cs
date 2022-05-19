using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CRUD_Hospital.Model
{
    internal static class Data
    {
        public static int HospitalId { get; set; }
        public static int DepartmentId { get; set; }
        public static int PatientId { get; set; }
        public static int DoctorId { get; set; }
        public static int MedicalHistoryId { get; set; }
        public static int TreatmentId { get; set; }

        public static ObservableCollection<Patient> SearchInPatient(string filter)
        {
            var patients = new ObservableCollection<Patient>();
            using(var db = new dbhospitalsContext())
            {

                    Npgsql.NpgsqlParameter f = new("@filter", filter);

                    patients = new ObservableCollection<Patient>(
                        db.Patients.FromSqlRaw($"select * from patients " +
                        $"where p_firstname like concat('%',@filter,'%') or " +
                        $"p_secondname like concat('%',@filter,'%') or " +
                        $"cast(p_phone as text) like concat('%',@filter,'%') or " +
                        $"p_lastname like concat('%',@filter,'%')", f));
            }
            return patients;
        }

        public static ObservableCollection<Doctor> SearchInDoctor(string filter)
        {
            var doctors = new ObservableCollection<Doctor>();
            using(var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter f = new("@filter", filter);
                doctors = new ObservableCollection<Doctor>(
                    db.Doctors.FromSqlRaw($"select * from doctors " +
                    $"where d_fisrtname like concat('%',@filter,'%') or " +
                    $"d_secondname like concat('%', @filter, '%') or " +
                    $"d_lastname like concat('%',@filter,'%') or " +
                    $"d_jobtitle like concat('%',@filter,'%') or " +
                    $"cast(d_phone as text) like concat('%',@filter,'%')", f));
            }
            return doctors;
        }

        public static Doctor FindDoctor(int id)
        {
            var doctor = new Doctor();
            using (var db = new dbhospitalsContext())
            {
                doctor = db.Doctors.FirstOrDefault((i => i.DoctorId == id));
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
        public static Treatment FindTreatment(int id)
        {
            var t = new Treatment();
            using(var db = new dbhospitalsContext())
            {
                t= db.Treatments.FirstOrDefault(i => i.TreatmentId == id);
            }
            return t;
        }

        public static Medicalhistory FindHistory(int id)
        {
            var m = new Medicalhistory();
            using (var db = new dbhospitalsContext())
            {
                if (db.Medicalhistories.Any(i => i.PatientId == id))
                {
                    m = db.Medicalhistories.FirstOrDefault(i => i.PatientId == id);
                    MedicalHistoryId = m.MedicalhistoryId;
                }
                else
                {
                    m = new Medicalhistory { PatientId = id };
                    db.Medicalhistories.Add(m);
                    db.SaveChanges();
                    m = db.Medicalhistories.FirstOrDefault(i => i.PatientId == id);
                }
            }
            return m;
        }

        public static ObservableCollection<Patient> GetAllPatients()
        {
            var all = new ObservableCollection<Patient>();
            using (var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter HosId = new("@HospitalId", HospitalId);
                
                all = new ObservableCollection<Patient>(db.Patients.FromSqlRaw("select * from patients where hospital_id = @HospitalId", HosId));
            }
            return all;
        }

        public static ObservableCollection<Department> GetAllDepartments()
        {
            var all = new ObservableCollection<Department>();
            using (var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter HosId = new("@HospitalId",HospitalId);
                all = new ObservableCollection<Department>(db.Departments.FromSqlRaw("select * from departments where hospital_id = @HospitalId", HosId));
            }
            return all;
        }

        public static ObservableCollection<Doctor> GetDoctors(int id)
        {
            var all = new ObservableCollection<Doctor>();
            using (var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter DepartmentId = new Npgsql.NpgsqlParameter("@DepartmentId", id);
                all = new ObservableCollection<Doctor>(db.Doctors.FromSqlRaw("SELECT * FROM DOCTORS WHERE Department_Id = @DepartmentId", DepartmentId));
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
            using (var db = new dbhospitalsContext())
            {
                all = new ObservableCollection<Hospital>(db.Hospitals);
            }
            return all;
        }

        public static ObservableCollection<Service> GetAllServices(int ID)
        {
            var all = new ObservableCollection<Service>();
            using(var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter id = new("@id", ID);
                all = new ObservableCollection<Service>(db.Services.FromSqlRaw("select * from services where treatment_id = @id", id));
            }
            return all;
        }

        public static ObservableCollection<Medication> GetAllMedications(int ID)
        {
            var all = new ObservableCollection<Medication>();
            using (var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter id = new("@id", ID);
                all = new ObservableCollection<Medication>(db.Medications.FromSqlRaw("select * from medications where treatment_id = @id", id));
            }
            return all;
        }

        public static ObservableCollection<Visit> GetVisitsOfPatient(int id)
        {
            var all = new ObservableCollection<Visit>();
            using (var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter DoctorId = new Npgsql.NpgsqlParameter("@DoctorId", id);
                all = new ObservableCollection<Visit>(db.Visits.FromSqlRaw("SELECT * FROM VISITS WHERE DOCTOR_ID = @DoctorId", DoctorId));
            }
            return all;
        }

        public static ObservableCollection<Disease> GetHistoryList(int id)
        {
            var all = new ObservableCollection<Disease>();
            using (var db = new dbhospitalsContext())
            {
                Npgsql.NpgsqlParameter HistoryId = new Npgsql.NpgsqlParameter("@HistoryId", id);
                all = new ObservableCollection<Disease>(db.Diseases.FromSqlRaw("SELECT * FROM DISEASES WHERE MEDICALHISTIRY_ID = @HistoryId", HistoryId));
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
            using (var db = new dbhospitalsContext())
            {
                if (!db.Visits.Contains(v))
                {
                    db.Visits.Add(v);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToDoctors(Doctor d)
        {
            using (var db = new dbhospitalsContext())
            {
                if (!db.Doctors.Contains(d))
                {
                    db.Doctors.Add(d);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToHospitals(Hospital h)
        {
            using (var db = new dbhospitalsContext())
            {
                if (!db.Hospitals.Contains(h))
                {
                        db.Hospitals.Add(h);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToDiseases(Disease d)
        {
            using(var db = new dbhospitalsContext())
            {
                if (!db.Diseases.Contains(d))
                {
                    db.Diseases.Add(d);
                    db.SaveChanges();
                }
            }
        }

        public static int AddToTreatments(Treatment t)
        {
            using(var db =new dbhospitalsContext())
            {
                if (!db.Treatments.Any(h=>h.VisitId==t.VisitId))
                {
                    db.Treatments.Add(t);
                    db.SaveChanges();
                }
                else t = db.Treatments.FirstOrDefault(h=>h.VisitId==t.VisitId);
            }
            return t.TreatmentId;
        }

        public static void AddToMedications(Medication m)
        {
            using (var db = new dbhospitalsContext())
            {
                if (!db.Medications.Contains(m))
                {
                    db.Medications.Add(m);
                    db.SaveChanges();
                }
            }
        }

        public static void AddToServices(Service s)
        {
            using (var db = new dbhospitalsContext())
            {
                if (!db.Services.Contains(s))
                {
                    db.Services.Add(s);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteFromPatients(Patient p)
        {
            using (var db = new dbhospitalsContext())
            {
                db.Patients.Remove(p);
                db.SaveChanges();
            }
        }

        public static void DeleteFromDoctors(Doctor d)
        {
            using (var db = new dbhospitalsContext())
            {
                db.Doctors.Remove(d);
                db.SaveChanges();
            }
        }

        public static void DeleteFromHospitals(Hospital h)
        {
            using(var db = new dbhospitalsContext())
            {
                db.Hospitals.Remove(h);
                db.SaveChanges();
            }
        }

        public static void DeleteFromVisits(Visit v)
        {
            using (var db = new dbhospitalsContext())
            {
                db.Visits.Remove(v);
                db.SaveChanges();
            }
        }

        public static void DeleteFromDiseases(Disease d)
        {
            using(var db = new dbhospitalsContext())
            {
                db.Diseases.Remove(d);
                db.SaveChanges();
            }
        }

        public static void DeleteFromMedications(Medication m)
        {
            using(var db =new dbhospitalsContext())
            {
                db.Medications.Remove(m);
                db.SaveChanges();
            }
        }

        public static void DeleteFromServices(Service s)
        {
            using(var db = new dbhospitalsContext())
            {
                db.Services.Remove(s);
                db.SaveChanges();
            }
        }

        public static void UpdatePatient(Patient oldp, string First, string Second, string Last, long Phone)
        {
            using (var db = new dbhospitalsContext())
            {
                var searchPatient = db.Patients.FirstOrDefault(p=>p.PatientId==oldp.PatientId);
                searchPatient.PFirstname = First;
                searchPatient.PSecondname = Second;
                searchPatient.PLastname = Last;
                searchPatient.PPhone = Phone;
                db.SaveChanges();
            }
        }

        public static void UpdateDoctor(Doctor old, string First, string Second, string Last, long Phone, string job)
        {
            using(var db =new dbhospitalsContext())
            {
                var d = db.Doctors.FirstOrDefault(p=>p.DoctorId==old.DoctorId);
                d.DFisrtname = First;
                d.DSecondname = Second;
                d.DLastname = Last;
                d.DPhone = Phone;
                d.DJobtitle = job;
                db.SaveChanges();
            }
        }

        public static void UpdateTreatment(Treatment old, short days)
        {
            using(var db = new dbhospitalsContext())
            {
                var search = new Treatment();
                search = db.Treatments.FirstOrDefault(u => u.TreatmentId==old.TreatmentId);
                search.Countdays = days;
                db.SaveChanges();
            }
        }
    }
}
