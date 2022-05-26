using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    public partial class ChangePatientWindow : AdonisWindow
    {
        public ChangePatientWindow()
        {
            InitializeComponent();
            var vm = new ViewModel.ChangePatientWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}

