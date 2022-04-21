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
    internal class AddDiseaseVM:INotifyPropertyChanged
    {
        private Disease disease = new Disease { MedicalhistiryId=Data.MedicalHistoryId};
        public Disease Disease { get { return disease; } set { disease = value; OnPropertyChanged("Disease"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand addDiseaseCommand;
        public RelayCommand AddDiseaseCommand => addDiseaseCommand ??
            (addDiseaseCommand = new RelayCommand(obj =>
            {
                Disease disease = obj as Disease;
                Data.AddToDiseases(disease);
                CloseAction();
            }));
        public Action CloseAction { get; set; }

    }
}
