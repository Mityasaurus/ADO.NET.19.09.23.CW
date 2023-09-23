using Library.Services;
using System.Collections.Generic;
using System.Windows;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        private readonly BooksProvider _booksProvider;
        private readonly UsersProvider _usersProvider;
        private readonly LendingsProvider _lendingsProvider;
        private List<string> reports = new List<string>();

        public ReportsWindow(BooksProvider booksProvider, UsersProvider usersProvider, LendingsProvider lendingsProvider)
        {
            InitializeComponent();

            _booksProvider = booksProvider;
            _usersProvider = usersProvider;
            _lendingsProvider = lendingsProvider;

            InitializeReports();
            reportsComboBox.ItemsSource = reports;
        }

        private void InitializeReports()
        {
            reports.Add("Список користувачів, які прострочили срок здачі книги");
            reports.Add("Список книг, яких не залишилось в наявності");
            reports.Add("Список користувачів, які мають на руках 3 або більше книг");
            reports.Add("Топ-3 найпопулярніші книги поточного місяця");
        }

        private void UpdateDataSource(IEnumerable<object> values)
        {
            reportList.ItemsSource = values;
        }

        private void btnMakeReport_Click(object sender, RoutedEventArgs e)
        {
            if(reportsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Оберіть потрібнй звіт зі списку", "Формування звіту");
                return;
            }

            int choice = reportsComboBox.SelectedIndex;

            switch(choice)
            {
                case 0:
                    UpdateDataSource(_lendingsProvider.GetOverdueUsers());
                    break;
                case 1:
                    UpdateDataSource(_booksProvider.GetBooksWithZeroNumber());
                    break;
                case 2:
                    UpdateDataSource(_usersProvider.GetUsersMoreThan3Books());
                    break;
                case 3:
                    UpdateDataSource(_booksProvider.GetTop3MostPopularBooksThisMonth());
                    break;
            }
        }
    }
}
