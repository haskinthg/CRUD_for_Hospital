using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CRUD_Hospital.ViewModel
{
    internal class ShowVisitsPatientVM:INotifyPropertyChanged
    {
        public ObservableCollection<Visit> Visits { get; set; } = Data.GetVisitsOfPatient(Data.DoctorId);
        public ShowVisitsPatientVM()
        {
            foreach (var item in Visits)
            {
                item.Patient = Data.FindPatient(item.PatientId);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand openAddVisitToDoctorCommand;
        public RelayCommand OpenAddVisitToDoctorCommand => openAddVisitToDoctorCommand ??
            (openAddVisitToDoctorCommand = new RelayCommand(obj =>
           {
               var win = new View.AddVisitToDoctorWindow();
               win.Show();
               win.Closed += Win_Closed;
           }));

        private void Win_Closed(object? sender, System.EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            Visits.Clear();
            foreach (var d in Data.GetVisitsOfPatient(Data.DoctorId))
            {
                Visits.Add(d);

            }
            foreach (var item in Visits)
            {
                item.Patient = Data.FindPatient(item.PatientId);
            }
        }

        private Visit selectedVisit;
        public Visit SelectedVisit
        {
            get { return selectedVisit; }
            set { selectedVisit = value; OnPropertyChanged("SelectedVisit"); }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand => removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Visit v = obj as Visit;
                        Data.DeleteFromVisits(v);
                        UpdateTable();
                    },
                    (obj) => SelectedVisit != null));

        private RelayCommand treatmentCommand;
        public RelayCommand TreatmentCommand => treatmentCommand ??
            (treatmentCommand = new RelayCommand(obj =>
            {
                Treatment t = new Treatment { Countdays = 0, VisitId = SelectedVisit.VisitId };
                Data.TreatmentId = Data.AddToTreatments(t);
                var win = new View.TreatmentWindow();
                win.Show();
            }, obj => SelectedVisit != null));
    }
}
