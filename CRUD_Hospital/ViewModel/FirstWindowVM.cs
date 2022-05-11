using AdonisUI.Controls;
using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;

namespace CRUD_Hospital.ViewModel
{
    internal class FirstWindowVM:INotifyPropertyChanged
    {
        public ObservableCollection<Hospital> Hospitals { get; set; } = Data.GetAllHospitals();

        private Hospital _selectedHospital;
        public Hospital SelectedHospital
        {
            get { return _selectedHospital; }
            set { _selectedHospital = value;
                Data.HospitalId = value.HospitalId;
                OnPropertyChanged("SelectedHospital"); }
        }
        private void UpdateHospotals()
        {
            Hospitals.Clear();
            foreach(var item in Data.GetAllHospitals())
                Hospitals.Add(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand openMainWindowCommand;
        public RelayCommand OpenMainWindowCommand => openMainWindowCommand ??
            (openMainWindowCommand = new RelayCommand(obj =>
            {
                var main = new View.MainWindow();
                main.Show();
                CloseAction();
            },
            obj=>SelectedHospital!=null));

        private RelayCommand openAddHospitalCommand;
        public RelayCommand OpenAddHospitalCommand => openAddHospitalCommand ??
            (openAddHospitalCommand = new RelayCommand(obj =>
            {
                var w = new View.AddHospital();
                w.Show();
                w.Closed += W_Closed;
            }));

        private void W_Closed(object? sender, EventArgs e)
        {
            UpdateHospotals();
        }

        private RelayCommand removeHospital;
        public RelayCommand RemoveHospital => removeHospital ??
            (removeHospital = new RelayCommand(obj =>
            {
                Hospital hospital = obj as Hospital;
                Data.DeleteFromHospitals(hospital);
                UpdateHospotals();
            }, 
                obj => SelectedHospital != null));


        public Action CloseAction { get; set; }
    }
}
