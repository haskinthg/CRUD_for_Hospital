using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace CRUD_Hospital.ViewModel
{
    internal class MainVM : INotifyPropertyChanged

    {
        public ObservableCollection<Patient> Patients { get; set; } = Data.GetAllPatients();
        public ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();
        public ObservableCollection<Department> Departments { get; } = Data.GetAllDepartments();

        public void UpdatePatients()
        {
            Patients.Clear();
            foreach (var item in Data.GetAllPatients())
                Patients.Add(item);
        }

        public void UpdateDoctors()
        {
            Doctors.Clear();
            foreach (var item in Data.GetDoctors(_selectedDepartment.DepartmentId))
                Doctors.Add(item);
        }

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
            set
            {
                _selectedPatient = value;
                OnPropertyChanged("SelectedPatient");
            }
        }

        private Department _selectedDepartment = new Department() { HospitalId = Data.HospitalId };
        public Department SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged("SelectedDepartment");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Patient AddPatient = new Patient { HospitalId = 1 };
        public Patient addPatient
        {
            get
            {
                return AddPatient;
            }
            set
            {
                AddPatient = value;
                OnPropertyChanged("addPatient");
            }
        }
        private void clearAddPatient()
        {
            AddPatient.PLastname = "";
            AddPatient.PFirstname = "";
            AddPatient.PPhone = null;
            AddPatient.PSecondname = "";
        }


        private RelayCommand addPatientCommand;
        public RelayCommand AddPatientCommand => addPatientCommand ??
                    (addPatientCommand = new RelayCommand(obj =>
                   {
                       Patient patient = obj as Patient;
                       Data.AddToPatients(patient);
                       clearAddPatient();
                       UpdatePatients();
                   },
                    (obj) => addPatient.PPhone != null && addPatient.PFirstname != null && addPatient.PLastname != null && addPatient.PSecondname != null));

        private RelayCommand removePatientCommand;
        public RelayCommand RemovePatientCommand => removePatientCommand ??
                    (removePatientCommand = new RelayCommand(obj =>
                    {
                        Patient sPatient = obj as Patient;
                        Data.DeleteFromPatients(sPatient);
                        UpdatePatients();
                    },
                    (obj) => SelectedPatient != null));

        private RelayCommand selectedCommand;
        public RelayCommand SelectedCommand => selectedCommand ??
            (selectedCommand = new RelayCommand(obj =>
            {
                UpdateDoctors();
            },
                obj => SelectedDepartment != null
            ));

        private RelayCommand addVisitWindowCommand;
        public RelayCommand AddVisitWndowCommand => addVisitWindowCommand ??
            (addVisitWindowCommand = new RelayCommand(obj =>
            {
                Data.PatientId = _selectedPatient.PatientId;
                var window = new View.AddVisitWindow();
                window.Show();

            }));

        private Doctor selectedDoctor;
        public Doctor SelectedDoctor
        {
            get { return selectedDoctor; }
            set { selectedDoctor = value; OnPropertyChanged("SelectedDoctor"); }

        }

        private RelayCommand showVisitsCommand;
        public RelayCommand ShowVisitsCommand => showVisitsCommand ??
            (showVisitsCommand = new RelayCommand(obj =>
            {
                Data.DoctorId = SelectedDoctor.DoctorId;
                var window = new View.ShowVisitsPatient();
                window.Show();
            }));
    }
}
