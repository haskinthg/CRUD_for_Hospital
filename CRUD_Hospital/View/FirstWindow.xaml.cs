using AdonisUI.Controls;
using CRUD_Hospital.ViewModel;
using System;

namespace CRUD_Hospital.View
{
    public partial class FirstWindow : AdonisWindow
    {
        public FirstWindow()
        {
            InitializeComponent();
            FirstWindowVM vm = new FirstWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
