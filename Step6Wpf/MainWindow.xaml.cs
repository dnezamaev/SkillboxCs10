using System;
using System.Windows;
using System.Windows.Controls;

namespace Step6Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bank bank;

        public MainWindow()
        {
            bank = new Bank();

            try
            {
                bank.Load();
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить данные клиентов.");
            }

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            employeeComboBox.ItemsSource = bank.Employees;
            employeeComboBox.DisplayMemberPath = "FriendlyJobTitle";
            employeeComboBox.SelectedIndex = 0;

            clientsListBox.ItemsSource = bank.Clients;
            clientsListBox.DisplayMemberPath = "FullName";

            logListBox.ItemsSource = bank.Logger.Events;
            logListBox.DisplayMemberPath = "DispayString";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                bank.Save();
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить данные клиентов.");
                return;
            }
        }

        private IEmployee SelectedEmployee 
        {
            get => employeeComboBox.SelectedItem as IEmployee;
        }

        private void employeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clientsListBox_SelectionChanged(null, null);
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var employee = SelectedEmployee as ICreatorEmployee;

            if (employee == null)
            {
                MessageBox.Show("Недостаточно прав для создания клиента.");
                return;
            }

            try
            {
                employee.CreateClient(
                    firstNameTextBox.Text,
                    lastNameTextBox.Text,
                    middleNameTextBox.Text,
                    passportTextBox.Text,
                    phoneTextBox.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientsListBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Для сохранения изменений выберите клиента " +
                    "из списка справа или создайте нового.");

                return;
            }

            var client = clientsListBox.SelectedItem as Client;
            var employee = SelectedEmployee;

            try
            {
                employee.SetClientData(
                    client,
                    firstNameTextBox.Text,
                    lastNameTextBox.Text,
                    middleNameTextBox.Text,
                    passportTextBox.Text,
                    phoneTextBox.Text);

                clientsListBox.Items.Refresh();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private void clientsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var client = clientsListBox.SelectedItem as Client;
            var employee = SelectedEmployee;

            if (client == null)
            { 
                return; 
            }

            firstNameTextBox.Text = employee.GetClientFirstName(client);
            lastNameTextBox.Text = employee.GetClientLastName(client);
            middleNameTextBox.Text = employee.GetClientMiddleName(client);
            passportTextBox.Text = employee.GetClientPassport(client);
            phoneTextBox.Text = employee.GetClientPhone(client).ToString();
        }
    }
}
