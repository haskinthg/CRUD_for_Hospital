using CRUD_Hospital.ViewModel;

using AdonisUI.Controls;

namespace CRUD_Hospital.View
{
    public partial class MainWindow : AdonisWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();

        }
    }
}
