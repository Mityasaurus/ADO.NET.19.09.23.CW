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
    /// Логика взаимодействия для AddEditUsers.xaml
    /// </summary>
    public partial class AddEditUsers : Window
    {
        public AddEditUsers(User user)
        {
            InitializeComponent();

            if(user != null)
            {
                btnAddEditUser.Content = "Завершити редагування";
                userLastName.Text = user.LastName;
                userName.Text = user.Name;
                userPhone.Text = user.Phone;
            }
        }
    }
}
