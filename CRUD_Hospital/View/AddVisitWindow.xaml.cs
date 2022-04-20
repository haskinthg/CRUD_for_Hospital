using AdonisUI.Controls;
using CRUD_Hospital.ViewModel;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для AddVisitWindowxaml.xaml
    /// </summary>
    public partial class AddVisitWindow : AdonisWindow
    {
        public AddVisitWindow()
        {
            InitializeComponent();
            DataContext = new AddVisitWindowVM();
        }
    }
}
