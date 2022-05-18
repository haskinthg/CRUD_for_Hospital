using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD_Hospital.ViewModel
{
    internal class TreatmentWindowVM: INotifyPropertyChanged
    {
        public ObservableCollection<Service> Services { get; set; } = Data.GetAllServices(Data.TreatmentId);
        public ObservableCollection<Medication> Medications { get; set; } = Data.GetAllMedications(Data.TreatmentId);
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Service service;
        public Service Service
        {
            get { return service; }
            set { service = value; OnPropertyChanged("Service"); }
        }

        private Medication medication;
        public Medication Medication
        {
            get { return medication; }
            set { medication = value; OnPropertyChanged("Medication"); }
        }

        private Treatment treatment = Data.FindTreatment(Data.TreatmentId);

        private short days = Data.FindTreatment(Data.TreatmentId).Countdays;
        public short Days
        {
            get { return days; }
            set { days = value; OnPropertyChanged("Days"); }
        }

        private void UpdateTables()
        {
            Services.Clear();
            Medications.Clear();
            foreach(var i in Data.GetAllServices(Data.TreatmentId))
                Services.Add(i);
            foreach(var i in Data.GetAllMedications(Data.TreatmentId))
                Medications.Add(i);
        }

        private RelayCommand addMedicationCommand;
        public RelayCommand AddMedicationCommand => addMedicationCommand ??
            (addMedicationCommand = new RelayCommand(obj =>
            {
                var win = new View.AddMedicationWindow();
                win.Show();
                win.Closed += Win_Closed;
            }));

        private RelayCommand removeMedicationCommand;
        public RelayCommand RemoveMedicationCommand => removeMedicationCommand ??
            (removeMedicationCommand = new RelayCommand(obj =>
            {
                var m = obj as Medication;
                Data.DeleteFromMedications(m);
                UpdateTables();
            },obj=> Medication!=null));

        private RelayCommand addServiceCommand;
        public RelayCommand AddServiceCommand => addServiceCommand ??
            (addServiceCommand = new RelayCommand(obj =>
            {
                var win = new View.AddServiceWindow();
                win.Show();
                win.Closed += Win_Closed;
            }));

        private void Win_Closed(object? sender, EventArgs e)
        {
            UpdateTables();
        }

        private RelayCommand removeServiceCommand;
        public RelayCommand RemoveServiceCommand => removeServiceCommand ??
            (removeServiceCommand = new RelayCommand(obj =>
            {
                var services = obj as Service;
                Data.DeleteFromServices(services);
                UpdateTables();
            }, obj=> Service!=null));

        private RelayCommand updateTreatment;
        public RelayCommand UpdateTreatment => updateTreatment ??
            (updateTreatment = new RelayCommand(obj =>
            {
                Data.UpdateTreatment(treatment, Days);
            }, obj=> Days!=treatment.Countdays));
    }
}
