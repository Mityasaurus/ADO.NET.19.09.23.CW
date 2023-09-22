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
    /// Логика взаимодействия для SelectBookWindow.xaml
    /// </summary>
    public partial class SelectBookWindow : Window
    {
        public Book SelectedBook { get; set; }

        private readonly BooksProvider _provider;
        private List<Book> _books => _provider.GetAllBooks().ToList();

        public SelectBookWindow(BooksProvider provider)
        {
            InitializeComponent();

            _provider = provider;
            UpdateDataSource(_books);
        }

        private void UpdateDataSource(IEnumerable<Book> books)
        {
            booksList.ItemsSource = books;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (booksList.SelectedItem == null)
            {
                MessageBox.Show("Оберіть книгу, яка буде видана", "Вибір книги");
                return;
            }
            
            if(((Book)booksList.SelectedItem).Number <= 0)
            {
                MessageBox.Show("Цієї книги немає в навності", "Вибір книги");
                return;
            }

            SelectedBook = (Book)booksList.SelectedItem;
            Close();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            booksList.ItemsSource = _provider.GetBooksByName(searchBar.Text);
        }
    }
}
