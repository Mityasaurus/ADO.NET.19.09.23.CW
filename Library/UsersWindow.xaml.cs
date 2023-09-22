using Library.DAL.SQL.Entity;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        private readonly UsersProvider _provider;
        private List<User> _users => _provider.GetAllUsers().ToList();

        public UsersWindow(UsersProvider provider)
        {
            InitializeComponent();

            _provider = provider;

            UpdateDataSource(_users);
        }

        private void UpdateDataSource(IEnumerable<User> users)
        {
            usersList.ItemsSource = users;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddEditUsers addEditUsers = new AddEditUsers(null, _provider);

            addEditUsers.ShowDialog();

            UpdateDataSource(_users);
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (usersList.SelectedItem != null)
            {
                AddEditUsers addEditUsers = new AddEditUsers((User)usersList.SelectedItem, _provider);

                addEditUsers.ShowDialog();

                UpdateDataSource(_users);
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _provider.Remove((User)usersList.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Оберіть користувача для видалення", "Видалення користувача");
            }

            UpdateDataSource(_users);
        }
    }
}
