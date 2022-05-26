using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    public partial class AddServiceWindow : AdonisWindow
    {
        public AddServiceWindow()
        {
            InitializeComponent();
            var vm = new ViewModel.AddServiceWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
