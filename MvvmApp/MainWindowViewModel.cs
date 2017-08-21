using MvvmApp.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFLocalizeExtension.Engine;

namespace MvvmApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Person currentPerson;
        public MainWindowViewModel()
        {
            ObservableCollectionPerson = new ObservableCollection<Person>();

            AddCommand = new RelayCommand(GenerateAndAddNewPerson);
            DeleteCommand = new RelayCommand(DeleteFirst);
            DeleteSelectedCommand = new RelayCommand(DeleteSelected, EnableDeleteSelected);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand DeleteSelectedCommand { get; private set; }
        public ICommand ChangeLanguageCommand { get; private set; }
        public ObservableCollection<Person> ObservableCollectionPerson { get; set; }

        public Person CurrentPerson
        {
            get
            {
                return currentPerson;
            }
            set
            {
                currentPerson = value;
            }
        }

        private void ChangeLanguage(object obj)
        {
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.Equals("pl-PL"))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");
            }
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
        }

        private void DeleteFirst(object obj)
        {
            ObservableCollectionPerson.RemoveAt(0);
        }
        private void DeleteSelected(object obj)
        {
            ObservableCollectionPerson.Remove(CurrentPerson);
        }

        private void GenerateAndAddNewPerson(object obj)
        {
            ObservableCollectionPerson.Add(new Person() { Name = Faker.Name.FullName(), Email = Faker.Internet.Email() });
        }
               
        private bool EnableDeleteSelected(object obj)
        {
            return CurrentPerson != null;
        }
    }
}
