using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD_Hospital.ViewModel
{
    internal class AddVisitToDoctorWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public ObservableCollection<Patient> Patients { get; set; } = Data.GetAllPatients();

        public Action CloseAction { get; set; }

        private DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }
        private int hours=8;
        public int Hours
        {
            get { return hours; }
            set { hours = value; OnPropertyChanged("Hours"); }
        }
        private int minutes;
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; OnPropertyChanged("Minutes"); }
        }
        private Patient patient;
        public Patient Patient
        {
            get { return patient; }
            set { patient = value; OnPropertyChanged("Patient"); }
        }

        private string filter = "";
        public string Filter 
        {
            get { return filter; }
            set { filter = value; OnPropertyChanged("Filter"); }
        }

        private RelayCommand searchInPatients;
        public RelayCommand SearchInPatients => searchInPatients ??
            (searchInPatients = new RelayCommand(obj =>
            {
                Patients.Clear();
                foreach (var a in Data.SearchInPatient(Filter))
                    Patients.Add(a);
            }));

        private Visit visit = new Visit();
        public Visit Visit 
        { 
            get { return visit; }
            set { visit = value; OnPropertyChanged("Visit"); }
        }
        private RelayCommand addVisitCommand;
        public RelayCommand AddVisitCommand => addVisitCommand ??
            (addVisitCommand = new RelayCommand(obj =>
            {
                Visit v = obj as Visit;
                v.VDate = date;
                v.VTine = new TimeOnly(hours, minutes);
                v.DoctorId = Data.DoctorId;
                v.PatientId = Patient.PatientId;
                Data.AddToVisits(v);
                CloseAction();
            }, obj=> Visit.VTine!=null&&Visit.VDate!=null&&Visit.DoctorId!=null&&Visit.PatientId!=null
            ));


    }
}
