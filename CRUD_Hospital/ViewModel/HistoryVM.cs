using CRUD_Hospital.Command;
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
        private void UpdateTable()
        {
            Diseases.Clear();
            foreach (Disease d in Data.GetHistoryList(Data.MedicalHistoryId))
            {
                Diseases.Add(d);
            }
        }
        private RelayCommand showAddDisease;
        public RelayCommand ShowAddDisease => showAddDisease ??
            (showAddDisease = new RelayCommand(obj =>
            {
                var window = new View.AddDisease();
                Data.MedicalHistoryId = History.MedicalhistoryId;
                window.Show();
                window.Closed += Window_Closed;
            }));

        private void Window_Closed(object? sender, EventArgs e)
        {
            UpdateTable();
        }

        private Disease selectedDisease;
        public Disease SelectedDisease
        {
            get { return selectedDisease; }
            set { selectedDisease = value; OnPropertyChanged("SelectedDisease"); }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand => removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        var v = obj as Disease;
                        Data.DeleteFromDiseases(v);
                        UpdateTable();
                    },
                    (obj) => SelectedDisease != null));
    }
}
