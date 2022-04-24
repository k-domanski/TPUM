using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class CreateUserDialogViewModel : DialogViewModelBase<Person>
    {

        public ICommand createUserCommand { get; private set; }

        public Person person
        {
            get => _person;
            set 
            { 
                _person = value; 
            }
        }

        public CreateUserDialogViewModel(string title, string message) : base(title, message)
        {
            _person = new Person();
            createUserCommand = new RelayCommand<IDialogWindow>(CreateUser);
        }

        private void CreateUser(IDialogWindow window)
        {
            CloseDialogWithResult(window, _person);
        }

        private Person _person;
    }
}
