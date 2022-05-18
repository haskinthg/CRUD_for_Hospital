using AdonisUI.Controls;

namespace CRUD_Hospital.View
{
    public partial class TreatmentWindow : AdonisWindow
    {
        public TreatmentWindow()
        {
            InitializeComponent();
            var vm = new ViewModel.TreatmentWindowVM();
            DataContext = vm;
        }
    }
}
