using Library.DAL.SQL.Entity;
using Library.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для SelectUserWindow.xaml
    /// </summary>
    public partial class SelectUserWindow : Window
    {
        public User SelectedUser { get; set; }

        private readonly UsersProvider _provider;
        private List<User> _users => _provider.GetAllUsers().ToList();

        public SelectUserWindow(UsersProvider provider)
        {
            InitializeComponent();

            _provider = provider;
            UpdateDataSource(_users);
        }

        private void UpdateDataSource(IEnumerable<User> users)
        {
            usersList.ItemsSource = users;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if(usersList.SelectedItem == null)
            {
                MessageBox.Show("Оберіть користувача котрому буде видана книга", "Вибір користувача");
                return;
            }
            else
            {
                SelectedUser = (User)usersList.SelectedItem;
                Close();
            }
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            usersList.ItemsSource = _provider.GetUsersByNameOrLastName(searchBar.Text);
        }
    }
}
