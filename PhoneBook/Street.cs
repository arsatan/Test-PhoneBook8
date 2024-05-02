using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook
{
    public class StreetInfo : INotifyPropertyChanged
    {
        private string id_street;
        private string street;
        private int count;
        public string Id
        {
            get { return id_street; }
            set
            {
                id_street = value;
                OnPropertyChanged("Id_street");
            }
        }
        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}