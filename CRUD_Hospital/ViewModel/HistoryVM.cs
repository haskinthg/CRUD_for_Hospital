using CRUD_Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD_Hospital.ViewModel
{
    internal class HistoryVM: INotifyPropertyChanged
    {
        public Medicalhistory History { get; set; } = Data.FindHistory(Data.PatientId);
        public ObservableCollection<Disease> Diseases { get; } = Data.GetHistoryList(Data.MedicalHistoryId);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
