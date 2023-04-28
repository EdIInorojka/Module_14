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

namespace Example_1251
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Repository data;

        public MainWindow()
        {
            InitializeComponent();
            data = Repository.CreateRepository();
            cbDepartment.ItemsSource = data.DepartmentsDb;
        }
        #region методы
        private void btnRef(object sender, RoutedEventArgs e)
        {
            cbDepartment.Items.Refresh();
            lvClients.Items.Refresh();
        }
        public void btnAddDepMoney(object sender, RoutedEventArgs e) 
        {
            data.AddDepMoney(Convert.ToInt32(SelectedId.Text), Convert.ToInt32(MoneyToAdd.Text));
        }
        public void btnAddUnDepMoney(object sender, RoutedEventArgs e)
        {
            data.AddUnDepMoney(Convert.ToInt32(SelectedId.Text), Convert.ToInt32(MoneyToAdd.Text));
        }

        public void btnCloseDepVallet(object sender, RoutedEventArgs e) 
        {
            data.CloseDepVallet(Convert.ToInt32(SelectedId.Text));
        }
        public void btnCloseUnDepVallet(object sender, RoutedEventArgs e)
        {
            data.CloseUnDepVallet(Convert.ToInt32(SelectedId.Text));
        }
        public void btnNewVallet(object sender, RoutedEventArgs e) 
        {
            data.AddNewVallet(Convert.ToString(SelectedName.Text), 
                Convert.ToInt32(SelectedId.Text));
        }
        public void btnAddNewClient(object sender, RoutedEventArgs e)
        {
            int a = 101;
            data.AddNewClient(Convert.ToString(text_AddNewClient.Text), a);
            a++;
        }
        #endregion
        #region MoneyChange
        public void DepMoneyChange(object sender, RoutedEventArgs e)
        {
            data.DepMoneyChange(Convert.ToInt32(id1.Text),
                Convert.ToInt32(id2.Text),
                Convert.ToInt32(moneytochange.Text));
        }
        public void UnDepMoneyChange(object sender, RoutedEventArgs e)
        {
            data.UnDepMoneyChange(Convert.ToInt32(id1.Text),
                Convert.ToInt32(id2.Text),
                Convert.ToInt32(moneytochange.Text));
        }
        #endregion

        private void CbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvClients.ItemsSource = data.ClientDb.Where(find);
        }


        private bool find(Client arg)
        {
            return arg.DepartamentId == (cbDepartment.SelectedItem as Department).DepartmentId;
        }
    }
}
