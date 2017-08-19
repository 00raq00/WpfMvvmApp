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
        public MainWindowViewModel()
        {
            ObservableCollectionPerson = new ObservableCollection<Person>();

            AddCommand = new RelayCommand(GenerateAndAddNewPerson);
            DeleteCommand = new RelayCommand(DeleteFirst);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
        }

        private void ChangeLanguage(object obj)
        {
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.Equals("pl-PL"))
            {
              System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");
            }
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
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
        public ICommand ChangeLanguageCommand { get; private set; }
        public ObservableCollection<Person> ObservableCollectionPerson { get; set; }
    }
}
