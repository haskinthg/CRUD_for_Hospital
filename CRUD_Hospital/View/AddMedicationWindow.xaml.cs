using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для AddMedicationWindow.xaml
    /// </summary>
    public partial class AddMedicationWindow : AdonisWindow
    {
        public AddMedicationWindow()
        {
            InitializeComponent();
            var vm = new ViewModel.AddMedicationWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
