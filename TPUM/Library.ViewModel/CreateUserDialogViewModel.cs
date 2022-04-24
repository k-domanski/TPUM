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
        public ICommand generateUserIDCommand { get; private set; }

        public Person person
        {
            get => _person;
            set 
            { 
                _person = value; 
            }
        }

        public Guid id 
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public CreateUserDialogViewModel(string title, string message) : base(title, message)
        {
            _person = new Person();
            createUserCommand = new RelayCommand<IDialogWindow>(CreateUser);
            generateUserIDCommand = new ViewAction(GenerateUserID);
        }

        private void CreateUser(IDialogWindow window)
        {
            _person.id = _id;
            CloseDialogWithResult(window, _person);
        }

        private void GenerateUserID()
        {
            id = Guid.NewGuid();
        }


        private Person _person;
        private Guid _id;

    }
}
