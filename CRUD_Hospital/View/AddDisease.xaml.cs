using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для AddDisease.xaml
    /// </summary>
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
