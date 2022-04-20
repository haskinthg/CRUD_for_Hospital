using AdonisUI.Controls;
using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Hospital.ViewModel
{
    internal class FirstWindowVM:INotifyPropertyChanged
    {
        public ObservableCollection<Hospital> Hospitals { get; set; } = Data.GetAllHospitals();

        public ObservableCollection<Hospital> sHospital { get; set; } = new ObservableCollection<Hospital>();

        private Hospital _selectedHospital = new Hospital();
        public Hospital SelectedHospital
        {
            get { return _selectedHospital; }
            set { _selectedHospital = value; OnPropertyChanged("SelectedHospital"); }
        }


        public void UpdateHospitalTableInfo()
        {
            sHospital.Clear();
            sHospital.Add(SelectedHospital);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand selectedCommand;
        public RelayCommand SelectedCommand => selectedCommand ??
            (selectedCommand = new RelayCommand(obj =>
            {
                UpdateHospitalTableInfo();
            }
            ));

        private RelayCommand openMainWindowCommand;
        public RelayCommand OpenMainWindowCommand => openMainWindowCommand ??
            (openMainWindowCommand = new RelayCommand(obj =>
            {
                var main = new View.MainWindow();
                main.Show();
                Data.HospitalId = _selectedHospital.HospitalId;
                CloseAction();
            },
            obj=>SelectedHospital!=null));

        public Action CloseAction { get; set; }
    }
}
