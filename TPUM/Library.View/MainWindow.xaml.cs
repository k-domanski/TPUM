using Library.ViewModel;
using System;
using System.Windows;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel _vm = (MainViewModel)DataContext;
            _vm.dialogService = new DialogService();
        }
    }
}
