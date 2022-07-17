using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Step6Wpf
{
    public class Bank
    {
        private List<IEmployee> employees;

        public Log Logger { get; private set; }

        public Manager Manager { get; private set; }

        public Consultant Consultant { get; private set; }

        public ObservableCollection<Client> Clients { get; private set; }

        public Bank() 
        { 
            Logger = new Log();
            Manager = new Manager(this);
            Consultant = new Consultant(this);

            employees = new List<IEmployee>() { Consultant, Manager };
            Clients = new ObservableCollection<Client>();
        }

        public IEnumerable<IEmployee> Employees { get => employees; }

        public string ClientsFile { get; set; } = "clients.txt";

        public string ClientsFileSeparator { get; set; } = ",";

        /// <summary>
        /// Сохранение данных по заданию 2 (рекомендуется текстовый файл с разделителем).
        /// </summary>
        public void Save()
        {
            using (var writer = File.CreateText(ClientsFile))
            {
                foreach (var client in Clients)
                {
                    var line = 
                        string.Join(",", new string[]
                        {
                            client.FirstName,
                            client.LastName,
                            client.MiddleName,
                            client.Passport,
                            client.Phone.ToString()
                        }
                    );

                    writer.WriteLine(line);
                }
            }
        }

        public void Load()
        {
            if (!File.Exists(ClientsFile))
            {
                return;
            }

            var lines = 
                File.ReadAllLines(ClientsFile)
                .Select(x => x.Split(',')
                );

            foreach (var item in lines)
            {
                var client = new Client(
                    item[0],
                    item[1],
                    item[2],
                    item[3],
                    UInt64.Parse(item[4])
                    );

                Clients.Add(client);
            }
        }

        public bool CheckInputForSeparator(string text)
        {
            return !text.Contains(',');
        }
    }
}
