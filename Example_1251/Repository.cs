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
        public List<Vallets> ValletsDb { get; set; }
        public List<Department> DepartmentsDb { get; set; }

        public Repository(int CountDepartment, int CountEmployee)
        {
            ClientDb = new List<Client>();
            ValletsDb = new List<Vallets>();
            DepartmentsDb = new List<Department>();

            for (int i = 0; i < CountDepartment; i++)
            {
                DepartmentsDb.Add(new Department($"Департамент {i+1}", i));
            }

            for (int i = 0; i < CountEmployee; i++)
            {
                ClientDb.Add(
                        new Client($"Имя_{i+1}", 
                                     r.Next(1000, 1000000),
                                     r.Next(1000, 1000000),
                                     i+1,
                                     r.Next(DepartmentsDb.Count)));
            }
        }
        #region Методы для
        public void AddDepMoney(int id, int sum) 
        {
            ClientDb[id - 1].DepVallet += sum;
        }
        public void AddUnDepMoney(int id, int sum)
        {
            ClientDb[id - 1].UnDepVallet += sum;
        }
        public void CloseDepVallet(int id) 
        {
            ClientDb[id-1].DepVallet = 0;
        }
        public void CloseUnDepVallet(int id)
        {
            ClientDb[id-1].UnDepVallet = 0;
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
            if (ClientDb[id1 - 1].DepVallet - money >= 0)
            {
                ClientDb[id1 - 1].DepVallet -= money;
                ClientDb[id2 - 1].DepVallet += money;
            }
            else { }
        }
        public void UnDepMoneyChange(int id1, int id2, int money)
        {
            if (ClientDb[id1 - 1].UnDepVallet - money >= 0)
            {
                ClientDb[id1 - 1].UnDepVallet -= money;
                ClientDb[id2 - 1].UnDepVallet += money;
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
