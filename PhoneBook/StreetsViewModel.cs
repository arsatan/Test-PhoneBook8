using Dapper;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook
{
    public class StreetsViewModel : INotifyPropertyChanged
    {
        public List<StreetInfo> Streets { get; set; }
        public StreetsViewModel()
        {
            var dictionary = new Dictionary<string, object>
            {
                { "@street", "%"},
            };
            var parameters = new DynamicParameters(dictionary);
            Streets = SqliteStreetsList.LoadStreets(parameters);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}