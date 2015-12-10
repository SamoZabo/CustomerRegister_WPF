using CustomerRegister.Model;
using CustomerRegister.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace CustomerRegister
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            List = new ObservableCollection<Customer>();
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value;
                OnPropertyChanged("Customer");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Customer> _list;
        public ObservableCollection<Customer> List { get { return _list; } set
            {
                _list = value;
                OnPropertyChanged("List");
            } }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Customer _customer;
        private CustomerRepository db;
        private ViewModel _model;

        public MainWindow()
        {
            InitializeComponent();
            db = new CustomerRepository();
            var c = db.GetAll().Last();
            _model = new ViewModel
            {                 
                Customer = new Customer(c, c.Id),
                List = new ObservableCollection<Customer>(db.GetAll())
            };
            DataContext = _model;
        }

        private void Rbtn_Checked(object sender, RoutedEventArgs e)
        {
            if (Private_Rbtn.IsChecked == true)
            {
                CompanyNameTextBox.Text = string.Empty;
                CompanyNameTextBox.IsEnabled = false;
            }
             else if (Company_Rbtn.IsChecked == true)
            {
                CompanyNameTextBox.IsEnabled = true;
            }
        }

        private void ClearBoxes()
        {
            _model.Customer = new Customer();
        }

        private void Create_btn_Click(object o, RoutedEventArgs e)
        {
            _model.Customer = new Customer(_model.Customer, Guid.NewGuid());
            db.Save(_model.Customer);
            _model.List.Add(_model.Customer);
        }

        private void Update_btn_Click(object o, RoutedEventArgs e)
        {
            db.Save(_model.Customer);
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            ClearBoxes();
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            db.Remove(_model.Customer.Id);
            ClearBoxes();
            GetListBySearch();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var customer = CustomerListView.SelectedItem as Customer;
            if (customer != null)
            {
                _model.Customer = new Customer(customer, customer.Id);
            }
        }

        private void SearchTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListBySearch();
        }

        private void GetListBySearch()
        {
            if (Search_Email_Rbtn.IsChecked.HasValue && Search_Email_Rbtn.IsChecked.Value)
            {
                _model.List = new ObservableCollection<Customer>(db.GetBySearch(SearchTxtBox.Text, string.Empty));
            }
            else if (Search_Phone_Rbtn.IsChecked.HasValue && Search_Phone_Rbtn.IsChecked.Value)
            {
                _model.List = new ObservableCollection<Customer>(db.GetBySearch(string.Empty, SearchTxtBox.Text));
            }
            else
            {
                _model.List = new ObservableCollection<Customer>(db.GetAll());
            }
        }
    }
}
