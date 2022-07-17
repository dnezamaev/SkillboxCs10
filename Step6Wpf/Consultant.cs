using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    /// <summary>
    /// Вместо серии и номера паспорта он видит символы: «******************»,
    /// — если поле не пустое. 
    /// 
    /// Консультант не может изменять поля «Фамилия», «Имя», «Отчество», 
    /// но может их просматривать.
    /// 
    /// Консультант может изменить «Номер телефона»,
    /// но при этом поле должно быть всегда заполнено.
    /// </summary>
    public class Consultant : Employee
    {
        public Consultant(Bank bank) : base(bank) { }

        public override string FriendlyJobTitle => "Консультант";

        public override string GetClientFirstName(Client client)
        {
            return client.FirstName;
        }

        public override string GetClientLastName(Client client)
        {
            return client.LastName;
        }

        public override string GetClientMiddleName(Client client)
        {
            return client.MiddleName;
        }

        public override UInt64 GetClientPhone(Client client)
        {
            return client.Phone;
        }

        /// <summary>
        /// Демонстрация полиморфизма из задания 1.
        /// </summary>
        public override string GetClientPassport(Client client)
        {
            // Консультант не имеет доступа к просмотру информации.
            if (string.IsNullOrEmpty(client.Passport))
            {
                return "";
            }

            return "******************";
        }

        public override void SetClientData(
            Client client,
            string firstName, string lastName, string middleName,
            string passport, string phone)
        {
            if (
                client.FirstName != firstName ||
                client.LastName != lastName ||
                client.MiddleName != middleName ||
                client.Passport != passport
                )
            {
                throw new ArgumentException(
                    "Недостаточно прав для редактирования клиента.");
            }

            SetClientPhone(client, phone);
        }

        /// <summary>
        /// Установить телефон клиента.
        /// </summary>
        protected void SetClientPhone(Client client, string phone)
        {
            var parsedPhone = ParsePhone(phone);

            if (client.Phone != parsedPhone)
            {
                client.Phone = parsedPhone;
                Bank.Logger.AddEvent(FriendlyJobTitle, "телефон", ModificationTypes.Changed);
            }
        }

        protected UInt64 ParsePhone(string phone)
        {
            // Консультант может изменить «Номер телефона»,
            // но при этом поле должно быть всегда заполнено.
            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("Телефон должен быть заполнен.");
            }

            if (!UInt64.TryParse(phone, out UInt64 parsedPhone))
            {
                throw new ArgumentException("Телефон должен содержать только цифры.");
            }

            return parsedPhone;
        }
    }
}
