using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    public interface IEmployee
    {
        string FriendlyJobTitle { get; }

        string GetClientFirstName(Client client);

        string GetClientLastName(Client client);

        string GetClientMiddleName(Client client);

        string GetClientPassport(Client client);

        UInt64 GetClientPhone(Client client);

        void SetClientData(
            Client client, 
            string firstName, string lastName, string middleName, 
            string passport, string phone);
    }
}
