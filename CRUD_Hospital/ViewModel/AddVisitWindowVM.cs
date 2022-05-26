using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD_Hospital.ViewModel
{
    internal class AddVisitWindowVM:INotifyPropertyChanged
    {
        public ObservableCollection<Doctor> Doctors { get; set; } = Data.GetAllDoctors();

        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }
        private int hours;
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

        private Doctor _selectedDoctor;
        public Doctor SelectedDoctor
        {
            get
            {
                return _selectedDoctor;
            }
            set
            {
                Data.DoctorId = value.DoctorId;
                _selectedDoctor = value;
                OnPropertyChanged("SelectedDoctor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Visit Visit { get;set; } = new Visit();
        private RelayCommand addVisitCommand;
        public RelayCommand AddVisitCommand => addVisitCommand ??
            (addVisitCommand = new RelayCommand(obj =>
            { 
                Visit v = obj as Visit;
                v.VDate = DateOnly.FromDateTime(date);
                v.VTine = new TimeOnly(hours, minutes);
                v.DoctorId=_selectedDoctor.DoctorId;
                v.PatientId=Data.PatientId;
                Data.AddToVisits(v);
                CloseAction();

            }));
        public Action CloseAction { get; set; }
    }
}

