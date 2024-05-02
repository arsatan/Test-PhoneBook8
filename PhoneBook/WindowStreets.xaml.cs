using System.Windows;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для WindowStreets.xaml
    /// </summary>
    public partial class WindowStreets : Window
    {
        public WindowStreets()
        {
            InitializeComponent();
            DataContext = new StreetsViewModel();
        }
    }
}
