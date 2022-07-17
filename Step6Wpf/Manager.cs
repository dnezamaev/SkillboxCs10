using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    /// <summary>
    /// Менеджер наследует функционал консультанта в дополнение к собственному.
    /// 
    /// Менеджер может изменять все данные.
    /// </summary>
    public class Manager : Consultant, ICreatorEmployee
    {
        public Manager(Bank bank) : base(bank) { }

        public override string FriendlyJobTitle => "Менеджер";

        /// <summary>
        /// Демонстрация полиморфизма из задания 2.
        /// </summary>
        public override string GetClientPassport(Client client)
        {
            // Менеджер имеет доступ к информации.
            return client.Passport;
        }

        public Client CreateClient(
            string firstName, string lastName, string middleName, 
            string passport, string phone)
        {
            CheckInput(firstName, lastName, middleName, passport);

            var parsedPhone = ParsePhone(phone);

            var client = new Client(firstName, lastName, middleName, passport, parsedPhone);

            Bank.Clients.Add(client);
            Bank.Logger.AddEvent(FriendlyJobTitle, "", ModificationTypes.Created);

            return client;
        }

        public override void SetClientData(
            Client client, 
            string firstName, string lastName, string middleName, 
            string passport, string phone)
        {
            CheckInput(firstName, lastName, middleName, passport);

            var parsedPhone = ParsePhone(phone);

            if (client.Phone != parsedPhone)
            {
                client.Phone = parsedPhone;
                Bank.Logger.AddEvent(FriendlyJobTitle, "телефон", ModificationTypes.Changed);
            }

            if (client.FirstName != firstName)
            {
                client.FirstName = firstName;
                Bank.Logger.AddEvent(FriendlyJobTitle, "имя", ModificationTypes.Changed);
            }

            if (client.LastName != lastName)
            {
                client.LastName = lastName;
                Bank.Logger.AddEvent(FriendlyJobTitle, "фамилия", ModificationTypes.Changed);
            }

            if (client.MiddleName != middleName)
            {
                client.MiddleName = middleName;
                Bank.Logger.AddEvent(FriendlyJobTitle, "отчество", ModificationTypes.Changed);
            }

            if (client.Passport != passport)
            {
                client.Passport = passport;
                Bank.Logger.AddEvent(FriendlyJobTitle, "паспорт", ModificationTypes.Changed);
            }
        }

        private void CheckInput(
            string firstName, string lastName, string middleName, 
            string passport, string phone = null)
        {
            if (!(
                Bank.CheckInputForSeparator(firstName) &&
                Bank.CheckInputForSeparator(lastName) &&
                Bank.CheckInputForSeparator(middleName) && 
                Bank.CheckInputForSeparator(passport) ))
            {
                throw new ArgumentException("Ошибка! Поля не должны содержать запятые.");
            }

            if (phone != null)
            {
                ParsePhone(phone);
            }
        }
    }
}
