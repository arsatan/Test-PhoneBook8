using Dapper;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonInfo selectedPerson;

        public List<PersonInfo> Persons { get; set; }
        //public Person SelectedPerson
        //{
        //    get { return selectedPerson; }
        //    set
        //    {
        //        selectedPerson = value;
        //        OnPropertyChanged("SelectedPerson");
        //    }
        //}
        public MainViewModel()
        {
            //Persons = new ObservableCollection<Person>
            //{
            //    //new Person { Family="Иванов", Name="Иван", Father="Иванович", Street="Ленина ул", House = "1" },
            //    //new Person { Family="Петров", Name="Петр", Father="Петрович", Street="Правды ул", House="2а" }
            //};
            var dictionary = new Dictionary<string, object>
            {
                { "@phone", "%"},
            };
            var parameters = new DynamicParameters(dictionary);
            Persons = SqlitePersonsList.LoadPersons(parameters);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}