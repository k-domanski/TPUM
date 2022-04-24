using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        public PersonViewModel()
        {
            //createNewUserCommand = new ViewAction((obj) => CreateUser(), null);
            //generateUserIDCommand = new ViewAction((obj) => GenerateUserID(), null);
        }

        public string firstName { get => _firstName; set { _firstName = value; RaisePropertyChanged(); } }
        public string lastName { get => _lastName; set { _lastName = value; RaisePropertyChanged(); } }
        public Guid id { get => _id; set { _id= value; RaisePropertyChanged(); } }

        public ICommand createNewUserCommand { get; set; }
        public ICommand generateUserIDCommand { get; set; }

        public void CreateUser()
        {
            if (person == null)
            {
                MessageBox.Show(firstName + '\n' + lastName + '\n' + id.ToString(), "Created new User", MessageBoxButton.OK, MessageBoxImage.Information);
                person = new Person();
                person.firstName = firstName;
                person.lastName = lastName;
                person.id = id;
            }
        }

        public void GenerateUserID()
        {
            id = Guid.NewGuid();
        }
        public Person person { get; set; }
        private string _firstName;
        private string _lastName;
        private Guid _id;
    }
}
