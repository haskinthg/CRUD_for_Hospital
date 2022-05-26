using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CRUD_Hospital.ViewModel
{
    internal class AddDepartmentWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Department department = new Department();
        public Department Department
        {
            get { return department; }
            set { department = value; OnPropertyChanged("Department"); }
        }

        private RelayCommand addDepartment;
        public RelayCommand AddDepartment => addDepartment ??
            (addDepartment = new RelayCommand(obj =>
            {
                var department = obj as Department;
                department.HospitalId = Data.HospitalId;
                Data.AddToDepartments(department);
                CloseAction();
            }, obj => Department.DName != null));
        public Action CloseAction { get; set; }
    }
}
