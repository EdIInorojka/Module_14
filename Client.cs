using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Microsoft.TeamFoundation.Server;
using System;

namespace Example_1251
{
    public class Client : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Инициализация через делегат
        public string Name { get; set; }
        public int PersonId { get; set; }
        public int DepVallet { get; set; }
        public int depVallet
        {
            get { return this.DepVallet; }
            set
            {
                this.DepVallet = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(this.DepVallet)));
            }
        }
        public int UnDepVallet { get; set; }
        public int unDepVallet
        {
            get { return this.UnDepVallet; }
            set
            {
                this.UnDepVallet = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(this.UnDepVallet)));
            }
        }
        public int DepartamentId { get; private set; }
        #endregion
        public Client(string Name, 
            int PersonId, 
            int depVallet, 
            int unDepVallet, 
            int DepartamentId)
        {
            this.Name = Name;
            this.PersonId = PersonId;
            this.depVallet = depVallet;
            this.unDepVallet = unDepVallet;
            this.DepartamentId = DepartamentId;

        }
    }
}
