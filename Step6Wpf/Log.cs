using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    /// <summary>
    /// Лог изменения данных.
    /// </summary>
    public class Log
    {
        private ObservableCollection<LogEvent> events;

        public Log()
        {
            events = new ObservableCollection<LogEvent>();
        }

        public ObservableCollection<LogEvent> Events { get => events; }

        /// <summary>
        /// Добавить событие.
        /// </summary>
        /// <param name="who">Кто иницииатор события.</param>
        /// <param name="whatModified">Что изменил.</param>
        /// <param name="how">Как изменил.</param>
        public void AddEvent(string who, string whatModified, ModificationTypes how)
        {
            events.Add(new LogEvent(DateTime.Now, whatModified, how, who));
        }
    }
}
