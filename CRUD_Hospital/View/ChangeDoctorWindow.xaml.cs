using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeDoctorWindow.xaml
    /// </summary>
    public partial class ChangeDoctorWindow : AdonisWindow
    {
        public ChangeDoctorWindow()
        {
            InitializeComponent();
            var vm = new ViewModel.ChangeDoctorWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
