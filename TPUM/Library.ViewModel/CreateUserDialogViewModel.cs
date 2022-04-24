using Library.Model;
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
            if(IsUserNotValid())
            {
                CloseDialogWithResult(window, null);
            }
            else
            {
                CloseDialogWithResult(window, _person);
            }
        }

        private bool IsUserNotValid()
        {
            return string.IsNullOrEmpty(_person.firstName) || string.IsNullOrEmpty(_person.lastName);
        }

        private Person _person;
    }
}
