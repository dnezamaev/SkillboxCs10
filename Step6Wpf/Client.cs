using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    /// <summary>
    /// Клиент банка.
    /// </summary>
    public class Client
    {
        public Client(
            string firstName, string lastName, string middleName, 
            string passport, UInt64 phone)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Phone = phone;
            Passport = passport;
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Номер телефона. 
        /// Предполагается отсутствие добавочных, которые могут содержать нецифровые символы.
        /// </summary>
        public UInt64 Phone { get; set; }

        /// <summary>
        /// Серия, номер паспорта. Предполагается, что могут быть значащие нулевые символы в начале.
        /// Например, 0001 234567. Поэтому тип string.
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// Полное имя для отображения.
        /// </summary>
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }
    }
}
