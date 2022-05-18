using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для AddVisitToDoctorWindow.xaml
    /// </summary>
    public partial class AddVisitToDoctorWindow : AdonisWindow
    {
        public AddVisitToDoctorWindow()
        {
            InitializeComponent();
            ViewModel.AddVisitToDoctorWindowVM vm = new ViewModel.AddVisitToDoctorWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
