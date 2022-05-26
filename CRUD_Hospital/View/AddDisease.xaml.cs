using AdonisUI.Controls;
using System;
namespace CRUD_Hospital.View
{
    public partial class AddDisease : AdonisWindow
    {
        public AddDisease()
        {
            InitializeComponent();
            var vm = new ViewModel.AddDiseaseVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
