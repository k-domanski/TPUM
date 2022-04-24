using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    public abstract class DialogViewModelBase<T> : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public T DialogResult { get; set; }

        public DialogViewModelBase() : this(string.Empty, string.Empty) { }
        public DialogViewModelBase(string title) : this(title, string.Empty) { }
        public DialogViewModelBase(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CloseDialogWithResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;

            if(dialog != null)
            {
                dialog.DialogResult = true;
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
