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
        Repository data;
        public static event Action<int, int, int, string> evlost;
        public static event Action<int, string> evadd;
        public static event Action<int, string> evdel;
        public static event Action<int> evaddnewvallet;
        public static event Action<int> evaddnewperson;
        public MainWindow()
        {
            InitializeComponent();
            data = Repository.CreateRepository();
            cbDepartment.ItemsSource = data.DepartmentsDb;
            evlost += ev_lost;
            evadd += ev_add;
            evdel += ev_del;
            evaddnewvallet += ev_addnv;
            evaddnewperson += ev_addnp;
        }
        #region методы
        public void ev_lost(int id1,int id2, int money, string vallet) 
        {
            Console.WriteLine($"{DateTime.Now.ToString("F")} Пользователь {id1} перевел {id2} {money} руб. {vallet}");
        }
        public void ev_add(int id, string vallet) 
        {
            Console.WriteLine($"{DateTime.Now.ToString("F")} Добавлен новый {vallet} счет пользователя {id}");
        }
        public void ev_del(int id, string vallet)
        {
            Console.WriteLine($"{DateTime.Now.ToString("F")} Удалён {vallet} счет пользователя {id}");
        }
        public void ev_addnv(int id)
        {
            Console.WriteLine($"{DateTime.Now.ToString("F")} Добавлен новый счет пользователя {id}");
        }
        public void ev_addnp(int id)
        {
            Console.WriteLine($"{DateTime.Now.ToString("F")} Добавлен новый пользователь {id}");
        }
        public void btnAddDepMoney(object sender, RoutedEventArgs e) 
        {
            data.AddDepMoney(Convert.ToInt32(SelectedId.Text), Convert.ToInt32(MoneyToAdd.Text));
            ev_add(Convert.ToInt32(SelectedId.Text), "депозитный");
        }
        public void btnAddUnDepMoney(object sender, RoutedEventArgs e)
        {
            data.AddUnDepMoney(Convert.ToInt32(SelectedId.Text), Convert.ToInt32(MoneyToAdd.Text));
            ev_add(Convert.ToInt32(SelectedId.Text), "недепозитный");
        }

        public void btnCloseDepVallet(object sender, RoutedEventArgs e) 
        {
            data.CloseDepVallet(Convert.ToInt32(SelectedId.Text));
            ev_del(Convert.ToInt32(SelectedId.Text), "депозитный");
        }
        public void btnCloseUnDepVallet(object sender, RoutedEventArgs e)
        {
            data.CloseUnDepVallet(Convert.ToInt32(SelectedId.Text));
            ev_del(Convert.ToInt32(SelectedId.Text), "недепозитный");
        }
        public void btnNewVallet(object sender, RoutedEventArgs e) 
        {
            data.AddNewVallet(Convert.ToString(SelectedName.Text), 
                Convert.ToInt32(SelectedId.Text));
            ev_addnv(Convert.ToInt32(SelectedId.Text));
        }
        public void btnAddNewClient(object sender, RoutedEventArgs e)
        {
            int a = 101;
            data.AddNewClient(Convert.ToString(text_AddNewClient.Text), a);
            ev_addnp(a);
            a++;
            
        }
        public void btnDepMoneyChange(object sender, RoutedEventArgs e)
        {
            data.DepMoneyChange(Convert.ToInt32(text_Id1.Text),
                Convert.ToInt32(text_Id2.Text),
                Convert.ToInt32(text_Money.Text));
            ev_lost(Convert.ToInt32(text_Id1.Text), 
                Convert.ToInt32(text_Id2.Text),
                Convert.ToInt32(text_Money.Text),
                "Счёт: недепозитный");
        }
        public void btnUnDepMoneyChange(object sender, RoutedEventArgs e)
        {
            data.UnDepMoneyChange(Convert.ToInt32(text_Id1.Text),
                Convert.ToInt32(text_Id2.Text),
                Convert.ToInt32(text_Money.Text));
            ev_lost(Convert.ToInt32(text_Id1.Text),
                Convert.ToInt32(text_Id2.Text),
                Convert.ToInt32(text_Money.Text),
                "Счёт: недепозитный");
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
