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
    /// Логика взаимодействия для AddEditBooks.xaml
    /// </summary>
    public partial class AddEditBooks : Window
    {
        public AddEditBooks(Book book)
        {
            InitializeComponent();

            if (book != null)
            {
                btnAddEditUser.Content = "Завершити редагування";
                bookName.Text = book.Name;
                bookAuthor.Text = book.Author;
                bookGenre.Text = book.Genre;
                bookNumber.Text = book.Number.ToString();
            }
        }
    }
}
