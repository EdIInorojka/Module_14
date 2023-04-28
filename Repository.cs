using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1251
{

    public class Repository
    {
        static Random r;
        static Repository() { r = new Random(); }

        public List<Client> ClientDb { get; set; }
        public List<Department> DepartmentsDb { get; set; }

        private Repository(int CountDepartment, int CountEmployee)
        {
            ClientDb = new List<Client>();
            DepartmentsDb = new List<Department>();
            for (int i = 0; i < CountDepartment; i++)
            {
                DepartmentsDb.Add(new Department($"Департамент {i+1}", i));
            }
            for (int i = 0; i < CountEmployee; i++)
            {
                ClientDb.Add(
                        new Client($"Имя_{i+1}",
                                     i + 1,
                                     r.Next(1000, 1000000),
                                     r.Next(1000, 1000000),
                                     r.Next(DepartmentsDb.Count)));
            }
        }
        #region Методы для Окна
        public void AddDepMoney(int id, int sum) 
        {
            ClientDb[id - 1].depVallet += sum;
        }
        public void AddUnDepMoney(int id, int sum)
        {
            ClientDb[id - 1].unDepVallet += sum;
        }
        public void CloseDepVallet(int id) 
        {
            ClientDb[id-1].depVallet = 0;
        }
        public void CloseUnDepVallet(int id)
        {
            ClientDb[id-1].unDepVallet = 0;
        }
        public void AddNewVallet(string Name, int id) 
        {
            ClientDb.Add(new Client(Name, 0, 0, (id-1), 
                Convert.ToInt32(ClientDb[id-1].DepartamentId)));
        }
        public void AddNewClient(string Name, int a)
        {
            ClientDb.Add(new Client(Name, 0, 0,
                a,
                0));
        }
        public void DepMoneyChange(int id1, int id2, int money) 
        {
            if (ClientDb[id1 - 1].depVallet - money >= 0)
            {
                ClientDb[id1 - 1].depVallet -= money;
                ClientDb[id2 - 1].depVallet += money;
            }
            else { }
        }
        public void UnDepMoneyChange(int id1, int id2, int money)
        {
            if (ClientDb[id1 - 1].unDepVallet - money >= 0)
            {
                ClientDb[id1 - 1].unDepVallet -= money;
                ClientDb[id2 - 1].unDepVallet += money;
            }
            else { }
        }
#endregion
        public static Repository CreateRepository(int CountDepartment = 10, int CountEmployee = 100)
        {
            return new Repository(CountDepartment, CountEmployee);
        }
    }
}
