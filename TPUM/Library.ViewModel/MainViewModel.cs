using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Library.Model;

namespace Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand showOnlyAvailableCommand { get; private set; }
        public ICommand createNewBookCommand { get; private set; }
        public ICommand createNewUserCommand { get; private set; }
        public ICommand createNewLendingCommand { get; private set; }
        public ICommand connectCommand { get; private set; }

        public IDialogService dialogService { get => _dialogService; set { _dialogService = value; } }

        public MainViewModel()
        {
            _modelLayer = ModelLayer.CreateDefault();
            createNewBookCommand = new ViewAction(HandleCreateBook);
            createNewUserCommand = new ViewAction(HandleCreateUser);
            createNewLendingCommand = new ViewAction(HandleCreateLending);
            showOnlyAvailableCommand = new RelayCommand<object>(HandleShowOnlyAvailable);
            connectCommand = new ViewAction(HandleConnect);
        }

        public ObservableCollection<Book> books
        {
            get => _modelLayer.books;
        }

        public ObservableCollection<Person> people
        {
            get => _modelLayer.users;
        }

        public ObservableCollection<Lending> lendings
        {
            get => _modelLayer.lendings;
        }

        public ObservableCollection<Message> messages
        {
            get => _modelLayer.messages;
        }

        private void HandleCreateBook()
        {
            var dialog = new CreateBookDialogViewModel("Dodaj", "Dodaj nową książkę.");
            var result = _dialogService.OpenDialog(dialog);
            _modelLayer.CreateBook(result);
        }

        private void HandleCreateUser()
        {
            var dialog = new CreateUserDialogViewModel("Dodaj", "Dodaj nowego użytkownika.");
            var result = _dialogService.OpenDialog(dialog);

            _modelLayer.CreateUser(result);
        }

        private void HandleCreateLending()
        {
            var dialog = new CreateLendingDialogViewModel(_modelLayer.CreateCopy(), "Dodaj", "Dodaj nowe wypożyczenie.");
            var result = _dialogService.OpenDialog(dialog);

            if (result != null && !_modelLayer.CanCreateLending(result))
            {
                _dialogService.OpenDialog(new AlertDialogViewModel("Niepowodzenie", "Nie można utwożyć wypożyczenia!"));
                return;
            }
            _modelLayer.CreateLending(result);
        }

        private void HandleShowOnlyAvailable(object obj)
        {
            _modelLayer.ShouldApplyOnlyAvailableFilter((bool)obj);
        }

        private void HandleConnect()
        {
            _modelLayer.Connect();
        }

        #region Private
        private ModelLayer _modelLayer;
        private IDialogService _dialogService;
        #endregion
    }
}
