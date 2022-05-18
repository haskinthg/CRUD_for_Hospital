using AdonisUI.Controls;
using CRUD_Hospital.ViewModel;
using System;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
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
