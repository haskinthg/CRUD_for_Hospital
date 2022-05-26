using CRUD_Hospital.ViewModel;
using AdonisUI.Controls;
using System;

namespace CRUD_Hospital.View
{
    public partial class MainWindow : AdonisWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);

        }

    }
}
