using Dapper;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для UserControlFindByPhone.xaml
    /// </summary>
    public partial class UserControlFindByPhone : UserControl
    {
        public List<PersonInfo> Persons { get; set; } = new List<PersonInfo>();
        public UserControlFindByPhone()
        {
            InitializeComponent();
        }

        public void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumber.Text.Trim();
            var dictionary = new Dictionary<string, object>
            {           
                { "@phone", phoneNumber}
            };
            var parameters = new DynamicParameters(dictionary);
            Persons = SqlitePersonsList.LoadPersons(parameters);
            Window parentWindow = Window.GetWindow(this);
            //parentWindow.DataContext = Persons;
            DataGrid mainView = (DataGrid)parentWindow.FindName("MainView");
            if (Persons.Count > 0)
            {
                
                mainView.ItemsSource = Persons;
            }
            else
            {
                dictionary = new Dictionary<string, object>
            {
                { "@phone", "%"}
            };
                mainView.ItemsSource = SqlitePersonsList.LoadPersons(new DynamicParameters(dictionary));
                MessageBox.Show("Нет абонентов, удовлетворяющих критерию поиска.", "Результат", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            } 
            CancelButton_Click(sender, e);
        }
        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentwin = Window.GetWindow(this);
            Popup popup = (Popup)parentwin.FindName("FindByPhone");
            popup.IsOpen = false;
        }
    }
}
