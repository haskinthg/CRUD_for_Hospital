using AdonisUI.Controls;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для ShowVisitsPatient.xaml
    /// </summary>
    public partial class ShowVisitsPatient : AdonisWindow
    {
        public ShowVisitsPatient()
        {
            InitializeComponent();
            var vm = new ViewModel.ShowVisitsPatientVM();
            DataContext = vm;
        }
    }
}
