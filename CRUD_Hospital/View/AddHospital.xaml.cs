using AdonisUI.Controls;
using CRUD_Hospital.ViewModel;
using System;

namespace CRUD_Hospital.View
{
    public partial class AddHospital : AdonisWindow
    {
        public AddHospital()
        {
            InitializeComponent();
            var vm = new AddHospitalVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}

