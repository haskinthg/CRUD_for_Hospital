using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD_Hospital.ViewModel
{
    internal class ChangePatientWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Patient patient = Data.FindPatient(Data.PatientId);
        public Patient Patient { get { return patient; } set { patient = value; OnPropertyChanged("Patient"); } }

        private RelayCommand changeCommand;
        public RelayCommand ChangeCommand => changeCommand ??
            (changeCommand = new RelayCommand(obj =>
            {
                Patient oldPatient = Data.FindPatient(Data.PatientId);
                Data.UpdatePatient(oldPatient, Patient.PFirstname, Patient.PSecondname, Patient.PLastname, (long)Patient.PPhone);
                CloseAction();
            }));

        public Action CloseAction { get; set; }
    }
    
}

