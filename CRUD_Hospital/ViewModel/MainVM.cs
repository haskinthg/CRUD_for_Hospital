using CRUD_Hospital.Command;
using CRUD_Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CRUD_Hospital.ViewModel
{
    internal class MainVM : INotifyPropertyChanged

    {
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();
        public ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();
        public ObservableCollection<Department> Departments { get; } = Data.GetAllDepartments();
        public MainVM()
        {
            UpdatePatients();
        }

        private string filterPatient="";
        public string FilterPatient
        {
            get { return filterPatient; }
            set { filterPatient = value; OnPropertyChanged("FilterPatient"); }
        }

        private string filterDoctor="";
        public string FilterDoctor
        {
            get { return filterDoctor; }
            set { filterDoctor = value; OnPropertyChanged("FilterDoctor"); }
        }

        private RelayCommand searchInPatients;
        public RelayCommand SearchInPatients => searchInPatients ??
            (searchInPatients = new RelayCommand(obj =>
            {
                Patients.Clear();
                foreach (var a in Data.SearchInPatient(FilterPatient))
                    Patients.Add(a);
            },
            obj => FilterPatient!=""));


        private RelayCommand resetTablePatient;
        public RelayCommand ResetTablePatient => resetTablePatient ??
            (resetTablePatient = new RelayCommand(obj =>
            {
                UpdatePatients();
                FilterPatient = "";
            }));

        private RelayCommand searchInDoctors;
        public RelayCommand SearchInDoctors => searchInDoctors ??
            (searchInDoctors = new RelayCommand(obj =>
            {
                Doctors.Clear();
                foreach (var a in Data.SearchInDoctor(FilterDoctor))
                    Doctors.Add(a);
            },
                obj => SelectedDepartment != null && FilterDoctor!=""));


        private RelayCommand resetTableDoctor;
        public RelayCommand ResetTableDoctor => resetTableDoctor ??
            (resetTableDoctor = new RelayCommand(obj =>
            {
                UpdateDoctors();
                FilterDoctor = "";
            },
                obj => SelectedDepartment != null));

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

        public void UpdateDepartments()
        {
            Departments.Clear();
            foreach(var item in Data.GetAllDepartments())
                Departments.Add(item);
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

        private Department _selectedDepartment = new() { HospitalId = Data.HospitalId };
        public Department SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                if (value != null) Data.DepartmentId = value.DepartmentId;
                OnPropertyChanged("SelectedDepartment");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Patient AddPatient = new() { HospitalId = Data.HospitalId };
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

        private Doctor addDoctor = new();
        public Doctor AddDoctor
        {
            get { return addDoctor; }
            set { addDoctor = value; OnPropertyChanged("AddDoctor"); }
        }

        private void clearAddPatient()
        {
            addPatient.PLastname = "";
            addPatient.PFirstname = "";
            addPatient.PPhone = null;
            addPatient.PSecondname = "";
        }


        private RelayCommand addPatientCommand;
        public RelayCommand AddPatientCommand => addPatientCommand ??
                    (addPatientCommand = new RelayCommand(obj =>
                   {
                       if (addPatient.PPhone != null && addPatient.PFirstname != null && addPatient.PLastname != null && addPatient.PSecondname != null)
                       {
                           Patient patient = obj as Patient;
                           Data.AddToPatients(patient);
                           clearAddPatient();
                           UpdatePatients();
                       }
                   }));
        void ClearAdd()
        {
            addPatient = new Patient { HospitalId = Data.HospitalId };
            AddDoctor = new Doctor();
        }
        private RelayCommand removePatientCommand;
        public RelayCommand RemovePatientCommand => removePatientCommand ??
                    (removePatientCommand = new RelayCommand(obj =>
                    {
                        Patient sPatient = obj as Patient;
                        Data.DeleteFromPatients(sPatient);
                        UpdatePatients();
                    },
                    (obj) => SelectedPatient != null));

        private RelayCommand removeDoctorCommand;
        public RelayCommand RemoveDoctorCommand => removeDoctorCommand ??
            (removeDoctorCommand = new RelayCommand(obj =>
            {
                Doctor doctor = obj as Doctor;
                Data.DeleteFromDoctors(doctor);
                UpdateDoctors();
            },
                obj=>SelectedDoctor != null));

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

        private RelayCommand showHistoryCommand;
        public RelayCommand ShowHistoryCommand => showHistoryCommand ??
            (showHistoryCommand = new RelayCommand(obj =>
            {
                Data.PatientId = _selectedPatient.PatientId;
                var window = new View.History();
                window.Show();
            }));


        private RelayCommand addDoctorCommand;
        public RelayCommand AddDoctorCommand => addDoctorCommand ??
            (addDoctorCommand = new RelayCommand(obj =>
            {
                if (addDoctor.DFisrtname != null && addDoctor.DSecondname != null &&
                addDoctor.DJobtitle != null && addDoctor.DLastname != null && addDoctor.DSecondname != null)
                {
                    Doctor doctor = obj as Doctor;
                    doctor.DepartmentId = Data.DepartmentId;
                    Data.AddToDoctors(doctor);
                    UpdateDoctors();
                    ClearAdd();
                }

            }));
        
        private RelayCommand returnToHospitals;
        public RelayCommand ReturnToHospitals => returnToHospitals ??
            (returnToHospitals = new RelayCommand(obj =>
            {
                var window = new View.FirstWindow();
                window.Show();
                CloseAction();
            }));

        private RelayCommand changePatientCommand;
        public RelayCommand ChangePatientCommand => changePatientCommand ??
            (changePatientCommand = new RelayCommand(obj =>
            {
                var patient = obj as Patient;
                Data.PatientId = patient.PatientId;
                var w = new View.ChangePatientWindow();
                w.Show();
                w.Closed += WPatient_Closed;
            }, obj=> SelectedPatient!=null));


        private RelayCommand changeDoctorCommand;
        public RelayCommand ChangeDoctorCommand => changeDoctorCommand ??
            (changeDoctorCommand = new RelayCommand(obj =>
            {
                var d = obj as Doctor;
                Data.DoctorId = d.DoctorId;
                var w = new View.ChangeDoctorWindow();
                w.Show();
                w.Closed += WDoctor_Closed;
            }, obj => SelectedDoctor != null));

        private void WPatient_Closed(object? sender, EventArgs e)
        {
            UpdatePatients();
        }

        private void WDoctor_Closed(object? sender, EventArgs e)
        {
            UpdateDoctors();
        }

        private RelayCommand openAddDepartmentCommand;
        public RelayCommand OpenAddDepartmentCommand => openAddDepartmentCommand ??
            (openAddDepartmentCommand = new RelayCommand(obj =>
           {
               var win = new View.AddDepartmentWindow();
               win.Show();
               win.Closed += WinDepartmentsClosed;
           }));

        private void WinDepartmentsClosed(object? sender, EventArgs e)
        {
            UpdateDepartments();
        }

        public Action CloseAction { get; set; }
    }
}
