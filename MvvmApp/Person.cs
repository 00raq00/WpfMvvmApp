using System.ComponentModel;

namespace MvvmApp
{
    public class Person : INotifyPropertyChanged
    {
        private string email;
        
        //if Name is changed UI doens't know about it
        public string Name { get; set; }


        //if Email is changed UI know about it and about changing FullName
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                    RaisePropertyChanged("FullName");
                }
            }
        }

        public string FullName
        {
            get
            {
                return Name + " --> email: " + Email;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}