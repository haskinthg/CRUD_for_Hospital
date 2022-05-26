using AdonisUI.Controls;

namespace CRUD_Hospital.View
{
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
