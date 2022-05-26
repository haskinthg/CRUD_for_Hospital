using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    public partial class AddDepartmentWindow : AdonisWindow
    {
        public AddDepartmentWindow()
        {
            InitializeComponent();
            var vm = new ViewModel.AddDepartmentWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
