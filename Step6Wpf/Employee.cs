using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    public abstract class Employee : IEmployee
    {
        public abstract string FriendlyJobTitle { get; }

        public Bank Bank { get; private set; }

        public Employee(Bank bank)
        {
            Bank = bank;
        }

        public abstract string GetClientFirstName(Client client);

        public abstract string GetClientLastName(Client client);

        public abstract string GetClientMiddleName(Client client);

        public abstract string GetClientPassport(Client client);
      
        public abstract ulong GetClientPhone(Client client);

        public abstract void SetClientData(Client client, string firstName, string lastName, string middleName, string passport, string phone);
    }
}
