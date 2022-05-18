using AdonisUI.Controls;

namespace CRUD_Hospital.View
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
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
