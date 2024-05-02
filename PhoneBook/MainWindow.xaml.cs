using System.Buffers.Text;
using System.Data.Entity.Core.Metadata.Edm;
using System.Windows;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

        }
        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            FindByPhone.IsOpen = true;
        }
        private void ViewStreets_Click(object sender, RoutedEventArgs e)
        {
            WindowStreets windowStreets = new WindowStreets();
            windowStreets.ShowDialog();
        }
        private void CSVExport_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ItemCollection visiblePersons = MainView.Items;
            Tools.CSVHelper.CSVWriter(visiblePersons);
        }
    }
}