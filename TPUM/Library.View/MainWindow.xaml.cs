using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            _vm.createBookService = new DialogService();
            _vm.createUserSercive = new DialogService();
        }

        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);
        //    MainViewModel _vm = (MainViewModel)DataContext;
        //    _vm.PersonWindow = new Lazy<IWindow>(() => new PersonWindow());
        //}
    }
}
