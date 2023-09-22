using Library.DAL.SQL.Entity;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly BooksProvider _provider;
        private Book? oldBook;

        public AddEditBooks(Book book, BooksProvider booksProvider)
        {
            InitializeComponent();

            _provider = booksProvider;
            oldBook = null;

            if (book != null)
            {
                oldBook = book;
                btnAddEditBook.Content = "Завершити редагування";
                bookName.Text = book.Name;
                bookAuthor.Text = book.Author;
                bookGenre.Text = book.Genre;
                bookNumber.Text = book.Number.ToString();
            }
        }

        private void btnAddEditBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (oldBook == null)
                {
                    Book newBook = new Book()
                    {
                        Name = bookName.Text,
                        Author = bookAuthor.Text,
                        Genre = bookGenre.Text,
                        Number = int.Parse(bookNumber.Text)
                    };

                    _provider.AddBook(newBook);

                    Close();
                }
                else
                {
                    Book editedBook = new Book()
                    {
                        ID = oldBook.ID,
                        Name = bookName.Text,
                        Author = bookAuthor.Text,
                        Genre = bookGenre.Text,
                        Number = int.Parse(bookNumber.Text)
                    };

                    _provider.Update(oldBook.ID, editedBook);

                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильний формат даних", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
