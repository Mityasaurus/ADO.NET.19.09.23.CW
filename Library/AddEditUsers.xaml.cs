using Library.DAL.SQL.Entity;
using Library.Services;
using System;
using System.Windows;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AddEditUsers.xaml
    /// </summary>
    public partial class AddEditUsers : Window
    {
        private readonly UsersProvider _provider;
        private User? oldUser;

        public AddEditUsers(User user, UsersProvider provider)
        {
            InitializeComponent();

            _provider = provider;
            oldUser = null;

            if(user != null)
            {
                oldUser = user;
                btnAddEditUser.Content = "Завершити редагування";
                userLastName.Text = user.LastName;
                userName.Text = user.Name;
                userPhone.Text = user.Phone;
            }
        }

        private void btnAddEditUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (oldUser == null)
                {
                    User newUser = new User()
                    {
                        Name = userName.Text,
                        LastName = userLastName.Text,
                        Phone = userPhone.Text,
                    };

                    _provider.AddUser(newUser);

                    Close();
                }
                else
                {
                    User editedUser = new User()
                    {
                        ID = oldUser.ID,
                        Name = userName.Text,
                        LastName = userLastName.Text,
                        Phone = userPhone.Text,
                    };

                    _provider.Update(oldUser.ID, editedUser);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильний формат даних", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
