using CRUD_Hospital.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CRUD_Hospital.ViewModel
{
    internal class ShowVisitsPatientVM:INotifyPropertyChanged
    {
        public ObservableCollection<Visit> Visits { get; set; } = Data.GetVisitsOfPatient(Data.PatientId);
        public ShowVisitsPatientVM()
        {
            foreach (var item in Visits)
            {
                item.Doctor = Data.FindDoctor(item.DoctorId);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
