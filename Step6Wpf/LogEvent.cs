using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    /// <summary>
    /// Возможные типы событий.
    /// </summary>
    public enum ModificationTypes 
    { 
        /// <summary>
        /// Создание записи о клиенте.
        /// </summary>
        Created, 
        /// <summary>
        /// Изменение записи о клиенте.
        /// </summary>
        Changed 
    }

    /// <summary>
    /// Событие изменения, read-only.
    /// </summary>
    public class LogEvent
    {
        public LogEvent(
            DateTime modificationTime, 
            string modifiedField,
            ModificationTypes modificationType,
            string modificationSubject)
        {
            ModificationTime = modificationTime;
            ModifiedField = modifiedField;
            ModificationType = modificationType;
            ModificationSubject = modificationSubject;
        }

        /// <summary>
        /// дата и время изменения записи
        /// </summary>
        public DateTime ModificationTime { get; private set; }

        /// <summary>
        /// какие данные изменены
        /// </summary>
        public string ModifiedField { get; private set; }

        /// <summary>
        /// тип изменений
        /// </summary>
        public ModificationTypes ModificationType { get; private set; }

        /// <summary>
        /// кто изменил данные (консультант или менеджер)
        /// </summary>
        public string ModificationSubject { get; private set; }

        private static Dictionary<ModificationTypes, string> ModifDispayNames
            = new Dictionary<ModificationTypes, string>()
            {
                { ModificationTypes.Created, "создал клиента" },
                { ModificationTypes.Changed, "изменил" },
            };


        public string DispayString 
        {
            get =>
                $"{ModificationTime}: {ModificationSubject} " +
                $"{ModifDispayNames[ModificationType]} {ModifiedField}";
        }
    }
}
