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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow();

            usersWindow.ShowDialog();
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            AddEditBooks addEditBooks = new AddEditBooks(null);

            addEditBooks.ShowDialog();
        }

        private void btnEditBook_Click(object sender, RoutedEventArgs e)
        {
            if (booksList.SelectedItem != null)
            {
                AddEditBooks addEditBooks = new AddEditBooks((Book)booksList.SelectedItem);

                addEditBooks.ShowDialog();
            }
        }
    }
}
