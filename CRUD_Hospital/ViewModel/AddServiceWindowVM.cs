using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CRUD_Hospital.ViewModel
{
    internal class AddServiceWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Service service = new Service { TreatmentId = Data.TreatmentId };
        public Service Service
        {
            get { return service; }
            set { service = value; OnPropertyChanged("Service"); }
        }
        private RelayCommand addService;
        public RelayCommand AddService => addService ??
            (addService = new RelayCommand(obj =>
            {
                var service = obj as Service;
                Data.AddToServices(service);
                CloseAction();
            }, obj => Service.SName != "" && Service.SPrice != null));
        public Action CloseAction { get; set; }
    }
}
