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
    /// Логика взаимодействия для ActiveLendingsWindow.xaml
    /// </summary>
    public partial class ActiveLendingsWindow : Window
    {
        private readonly BooksProvider _booksProvider;
        private readonly UsersProvider _usersProvider;
        private readonly LendingsProvider _lendingsProvider;

        private List<Lending> _lendings => _lendingsProvider.GetAllLendings().ToList();

        public ActiveLendingsWindow(LendingsProvider lendingsProvider, BooksProvider booksProvider, UsersProvider usersProvider)
        {
            InitializeComponent();

            _lendingsProvider = lendingsProvider;
            _booksProvider = booksProvider;
            _usersProvider = usersProvider;

            UpdateDataSource(_lendings);
        }

        private void UpdateDataSource(IEnumerable<Lending> lendings)
        {
            lendingsList.ItemsSource = lendings;
        }

        private void btnDeleteLending_Click(object sender, RoutedEventArgs e)
        {
            if(lendingsList.SelectedItem == null)
            {
                MessageBox.Show("Оберіть видачу, яку хочете завершити", "Завершення видачі");
                return;
            }

            Book selectedBook = ((Lending)lendingsList.SelectedItem).Book;
            User selectedUser = ((Lending)lendingsList.SelectedItem).User;
            Lending selectedLending = (Lending)lendingsList.SelectedItem;

            Book bookNewNumber = new Book()
            {
                ID = selectedBook.ID,
                Name = selectedBook.Name,
                Author = selectedBook.Author,
                Genre = selectedBook.Genre,
                Number = selectedBook.Number + 1
            };

            var lendingsBook = bookNewNumber.Lendings == null ? new List<Lending>() : bookNewNumber.Lendings.ToList();
            lendingsBook.Remove(selectedLending);
            bookNewNumber.Lendings = lendingsBook;

            _booksProvider.Update(bookNewNumber.ID, bookNewNumber);

            User newUser = new User()
            {
                ID = selectedUser.ID,
                Name = selectedUser.Name,
                LastName = selectedUser.LastName,
                Phone = selectedUser.Phone
            };

            var lendingsUser = newUser.Lendings == null ? new List<Lending>() : newUser.Lendings.ToList();
            lendingsUser.Add(selectedLending);
            newUser.Lendings = lendingsUser;

            _usersProvider.Update(newUser.ID, newUser);

            _lendingsProvider.Remove((Lending)lendingsList.SelectedItem);

            UpdateDataSource(_lendings);
        }

        private void btnAddLending_Click(object sender, RoutedEventArgs e)
        {
            SelectBookWindow selectBookWindow = new SelectBookWindow(_booksProvider);

            selectBookWindow.ShowDialog();

            Book selectedBook = selectBookWindow.SelectedBook;

            if(selectedBook == null)
            {
                return;
            }

            SelectUserWindow selectUserWindow = new SelectUserWindow(_usersProvider);

            selectUserWindow.ShowDialog();

            User selectedUser = selectUserWindow.SelectedUser;

            if( selectedUser == null)
            {
                return;
            }

            AddNewLending addNewLending = new AddNewLending(selectedBook, selectedUser, _lendingsProvider, _booksProvider, _usersProvider);

            addNewLending.ShowDialog();

            UpdateDataSource(_lendings);
        }
    }
}
