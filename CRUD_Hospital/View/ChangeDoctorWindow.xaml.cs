using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
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

