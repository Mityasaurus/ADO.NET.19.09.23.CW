using Library.DAL.SQL;
using Library.DAL.SQL.Entity;
using Library.DAL.SQL.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BooksProvider booksProvider;
        private List<Book> _books => booksProvider.GetAllBooks().ToList();

        private readonly UsersProvider usersProvider;
        private List<User> _users => usersProvider.GetAllUsers().ToList();

        private readonly LendingsProvider lendingsProvider;
        private List<Lending> _lendings => lendingsProvider.GetAllLendings().ToList();

        public MainWindow()
        {
            InitializeComponent();

            LibraryContext context = new LibraryContext();

            var repositoryBooks = new Repository<Book>(context);

            booksProvider = new BooksProvider(repositoryBooks);

            var repositoryUsers = new Repository<User>(context);

            usersProvider = new UsersProvider(repositoryUsers);

            var repositoryLendings = new Repository<Lending>(context);

            lendingsProvider = new LendingsProvider(repositoryLendings);

            UpdateDataSource(_books);

            { var users = _users; }

            { var lendings = _lendings; }
        }

        private void UpdateDataSource(IEnumerable<Book> source)
        {
            booksList.ItemsSource = source;
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow(usersProvider);

            usersWindow.ShowDialog();
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            AddEditBooks addEditBooks = new AddEditBooks(null, booksProvider);

            addEditBooks.ShowDialog();

            UpdateDataSource(_books);
        }

        private void btnEditBook_Click(object sender, RoutedEventArgs e)
        {
            if(booksList.SelectedItem == null)
            {
                MessageBox.Show("Оберіть книгу для редагування", "Редагування книги");
                return;
            }

            if (booksList.SelectedItem != null)
            {
                AddEditBooks addEditBooks = new AddEditBooks((Book)booksList.SelectedItem, booksProvider);

                addEditBooks.ShowDialog();

                UpdateDataSource(_books);
            }
        }

        private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                booksProvider.Remove((Book)booksList.SelectedItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Оберіть книгу для видалення", "Видалення книги");
            }

            UpdateDataSource(_books);
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string filter = searchBar.Text;

            if(filterName.IsChecked == true)
            {
                UpdateDataSource(booksProvider.GetBooksByName(filter));
            }
            else if(filterAuthor.IsChecked == true)
            {
                UpdateDataSource(booksProvider.GetBooksByAuthor(filter));
            }
            else if (filterGenre.IsChecked == true)
            {
                UpdateDataSource(booksProvider.GetBooksByGenre(filter));
            }
        }

        private void btnLendings_Click(object sender, RoutedEventArgs e)
        {
            ActiveLendingsWindow activeLendingsWindow = new ActiveLendingsWindow(lendingsProvider, booksProvider, usersProvider);
            
            activeLendingsWindow.ShowDialog();

            UpdateDataSource(_books);
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reportsWindow = new ReportsWindow(booksProvider, usersProvider, lendingsProvider);

            reportsWindow.ShowDialog();
        }
    }
}
