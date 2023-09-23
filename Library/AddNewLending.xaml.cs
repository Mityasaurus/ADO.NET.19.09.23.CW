using Library.DAL.SQL.Entity;
using Library.Services;
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
    /// Логика взаимодействия для AddNewLending.xaml
    /// </summary>
    public partial class AddNewLending : Window
    {
        private readonly LendingsProvider _lendingsProvider;
        private readonly BooksProvider _booksProvider;
        private readonly UsersProvider _usersProvider;
        private readonly Book _book;
        private readonly User _user;
        public AddNewLending(Book book, User user, LendingsProvider lendingsProvider, BooksProvider booksProvider, UsersProvider usersProvider)
        {
            InitializeComponent();

            _lendingsProvider = lendingsProvider;
            _booksProvider = booksProvider;
            _usersProvider = usersProvider;
            activeBook.Text = $"Обрана книга - {book}";
            activeUser.Text = $"Обраний користувач - {user}";

            _book = book;
            _user = user;
        }

        private void btnCancelLending_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddLending_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime issueDate = DateTime.Parse(issueDateBox.Text);
                DateTime dueDate = DateTime.Parse(dueDateBox.Text);

                Lending newLending = new Lending()
                {
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Book = _book,
                    User = _user,
                    BookID = _book.ID,
                    UserID = _user.ID
                };

                _lendingsProvider.AddLending(newLending);

                Book bookNewNumber = new Book()
                {
                    ID = _book.ID,
                    Name = _book.Name,
                    Author = _book.Author,
                    Genre = _book.Genre,
                    Number = _book.Number - 1,
                };

                var lendingsBook = bookNewNumber.Lendings == null ? new List<Lending>() : bookNewNumber.Lendings.ToList();
                lendingsBook.Add(newLending);
                bookNewNumber.Lendings = lendingsBook;

                _booksProvider.Update(_book.ID, bookNewNumber);

                User newUser = new User()
                {
                    ID = _user.ID,
                    Name = _user.Name,
                    LastName = _user.LastName,
                    Phone = _user.Phone
                };

                var lendingsUser = newUser.Lendings == null ? new List<Lending>() : newUser.Lendings.ToList();
                lendingsUser.Add(newLending);
                newUser.Lendings = lendingsUser;

                _usersProvider.Update(_user.ID, newUser);

                Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Неправильний формат даних", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
