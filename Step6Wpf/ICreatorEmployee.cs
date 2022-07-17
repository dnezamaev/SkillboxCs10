using System;

namespace Step6Wpf
{
    public interface ICreatorEmployee
    {
        Client CreateClient(
            string firstName, string lastName, string middleName, 
            string passport, string phone);
    }
}