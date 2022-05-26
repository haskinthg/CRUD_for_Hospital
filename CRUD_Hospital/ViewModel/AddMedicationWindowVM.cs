using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CRUD_Hospital.ViewModel
{
    internal class AddMedicationWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Medication medication = new Medication { TreatmentId=Data.TreatmentId};
        public Medication Medication
        {
            get { return medication; }
            set { medication = value; OnPropertyChanged("Medication"); }
        }

        private RelayCommand addMedication;
        public RelayCommand AddMedication => addMedication ??
            (addMedication = new RelayCommand(obj =>
            {
                var m = obj as Medication;
                Data.AddToMedications(m);
                CloseAction();
            }, obj => Medication.MName != ""));

        public Action CloseAction { get; set; }
    }
}
