using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook
{
    public class PersonInfo : INotifyPropertyChanged
    {
        private string id_man;
        private string family;
        private string name;
        private string father;
        private string street;
        private string house;
        private string phone_home;
        private string phone_work;
        private string phone_mobile;
        public string Id_man
        {
            get { return id_man; }
            set
            {
                id_man = value;
                OnPropertyChanged("Id_man");
            }
        }
        public string Family
        {
            get { return family; }
            set
            {
                family = value;
                OnPropertyChanged("Family");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Father
        {
            get { return father; }
            set
            {
                father = value;
                OnPropertyChanged("Father");
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
        public string House
        {
            get { return house; }
            set
            {
                house = value;
                OnPropertyChanged("House");
            }
        }
        public string Phone_home
        {
            get { return phone_home; }
            set
            {
                phone_home = value;
                OnPropertyChanged("Phone_home");
            }
        }
        public string Phone_work
        {
            get { return phone_work; }
            set
            {
                phone_work = value;
                OnPropertyChanged("Phone_work");
            }
        }
        public string Phone_mobile
        {
            get { return phone_mobile; }
            set
            {
                phone_mobile = value;
                OnPropertyChanged("Phone_mobile");
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