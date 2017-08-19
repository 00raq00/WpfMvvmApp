using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            ObservableCollectionPerson = new ObservableCollection<Person>();

            AddCommand = new RelayCommand(GenerateAndAddNewPerson);
            DeleteCommand = new RelayCommand(DeleteFirst);
        }

        private void DeleteFirst(object obj)
        {
            ObservableCollectionPerson.RemoveAt(0);
        }

        private void GenerateAndAddNewPerson(object obj)
        {
            ObservableCollectionPerson.Add(new Person() { Name = Faker.Name.FullName(), Email = Faker.Internet.Email() });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<Person> ObservableCollectionPerson { get; set; }
    }
}
