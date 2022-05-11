using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Hospital.ViewModel
{
     class AddHospitalVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Hospital addHospital = new Hospital();
        public Hospital AddHospital 
        { 
            get { return addHospital; } 
            set { addHospital = value; OnPropertyChanged("Hospital"); }
        }

        private RelayCommand addHospitalCommand;
        public RelayCommand AddHospitalCommand => addHospitalCommand ??
            (addHospitalCommand = new RelayCommand(obj =>
            {
                Hospital hospital = obj as Hospital;
                Data.AddToHospitals(hospital);
                CloseAction();
            },
                obj => addHospital.HCity != null && addHospital.HAddress != null && addHospital.HName != null));

        public Action CloseAction { get; set; }
        
    }
}
