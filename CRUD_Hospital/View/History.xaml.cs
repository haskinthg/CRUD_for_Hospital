using AdonisUI.Controls;

namespace CRUD_Hospital.View
{
    public partial class History : AdonisWindow
    {
        public History()
        {
            var vm = new ViewModel.HistoryVM();
            DataContext= vm;
            InitializeComponent();
        }
    }
}

