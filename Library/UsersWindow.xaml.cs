using Library.DAL.SQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddEditUsers addEditUsers = new AddEditUsers(null);

            addEditUsers.ShowDialog();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (usersList.SelectedItem != null)
            {
                AddEditUsers addEditUsers = new AddEditUsers((User)usersList.SelectedItem);

                addEditUsers.ShowDialog();
            }
        }
    }
}
