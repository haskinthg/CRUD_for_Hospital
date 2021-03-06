using AdonisUI.Controls;
using CRUD_Hospital.ViewModel;
using System;

namespace CRUD_Hospital.View
{
    public partial class AddVisitWindow : AdonisWindow
    {
        public AddVisitWindow()
        {
            InitializeComponent();
            AddVisitWindowVM vm = new AddVisitWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}

