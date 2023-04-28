using System.Runtime.InteropServices;

namespace Example_1251
{
    public class Client
    {
        public string Name { get; set; }
        public int DepVallet { get; set; }
        public int UnDepVallet { get; set; }
        public int PersonId { get; set; }
        public int DepartamentId { get; private set; }

        public Client(string Name, int depVallet, int UndepVallet, int personId, int DepId)
        {
            this.Name = Name;
            this.DepVallet = depVallet;
            this.UnDepVallet = UndepVallet;
            this.PersonId = personId;
            this.DepartamentId = DepId;
        }
    }
    public class Vallets : Client 
    {
        public Vallets(string Name, int depVallet, int UndepVallet, int personId, int DepId)
            :base(Name, depVallet, UndepVallet, personId, DepId) { }
    }
}
