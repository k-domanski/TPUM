using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Model;
using System.Windows;

namespace Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand showOnlyAvailableCommand { get; set; }
        public ICommand createNewBookCommand { get; set; }
        public ICommand createNewUserCommand { get; set; }
        public ICommand createNewLendingCommand { get; set; }

        public IDialogService dialogService { get => _dialogService; set { _dialogService = value; } }

        public MainViewModel()
        {
            _modelLayer = ModelLayer.CreateDefault();
            createNewBookCommand = new ViewAction(HandleCreateBook);
            createNewUserCommand = new ViewAction(HandleCreateUser);
            createNewLendingCommand = new ViewAction(HandleCreateLending);
            showOnlyAvailableCommand = new RelayCommand<object>(HandleShowOnlyAvailable);
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

        public void HandleCreateBook()
        {
            var dialog = new CreateBookDialogViewModel("Dodaj", "Dodaj nową książkę.");
            var result = _dialogService.OpenDialog(dialog);
            if(result != null )
                _modelLayer.CreateBook(result);
        }

        public void HandleCreateUser()
        {
            var dialog = new CreateUserDialogViewModel("Dodaj", "Dodaj nowego użytkownika.");
            var result = _dialogService.OpenDialog(dialog);

            _modelLayer.CreateUser(result);
        }

        public void HandleCreateLending()
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

        public void HandleShowOnlyAvailable(object obj)
        {
            _modelLayer.ShouldApplyOnlyAvailableFilter((bool)obj);
        }

        #region Private
        private ModelLayer _modelLayer;
        private IDialogService _dialogService;
        #endregion
    }
}
