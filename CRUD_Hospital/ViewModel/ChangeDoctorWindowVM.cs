using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD_Hospital.ViewModel
{
    internal class ChangeDoctorWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Doctor doctor = Data.FindDoctor(Data.DoctorId);
        public Doctor Doctor { get { return doctor; } set { doctor = value; OnPropertyChanged("Doctor"); } }

        private RelayCommand changeCommand;
        public RelayCommand ChangeCommand => changeCommand ??
            (changeCommand = new RelayCommand(obj =>
            {
                Doctor old = Data.FindDoctor(Data.DoctorId);
                Data.UpdateDoctor(old, Doctor.DFisrtname, Doctor.DSecondname, Doctor.DLastname, (long)Doctor.DPhone, Doctor.DJobtitle);
                CloseAction();
            }));

        public Action CloseAction { get; set; }
    }
}

