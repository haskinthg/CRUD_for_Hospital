using AdonisUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для AddVisitToDoctorWindow.xaml
    /// </summary>
    public partial class AddVisitToDoctorWindow : AdonisWindow
    {
        public AddVisitToDoctorWindow()
        {
            InitializeComponent();
            ViewModel.AddVisitToDoctorWindowVM vm = new ViewModel.AddVisitToDoctorWindowVM();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
