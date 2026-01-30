using System;
using System.Linq;
using System.Windows;
using HomeLibrary.Models;
using HomeLibrary.Services;


// Główne okno aplikacji – interfejs użytkownika.
namespace HomeLibrary.UI
{
 
//Dziedziczenie: MainWindow dziedziczy po Window
//Polimorfizm: MainWindow może być traktowane jako Window
    public partial class MainWindow : Window
    {
//Hermetyzacja(prywatne pola, dostępne tylko w tej klasie)
        private User _user;
        private LibraryService _library;
        private ReportService _reports;
        private DataService _data;

        public MainWindow()
        {
            InitializeComponent();      // Interfejs użytkownika – uruchamia XAML

            // Tworzymy użytkownika (obiekt klasy User)
            _user = new User
            {
                Login = "admin",
                Password = "admin",
                FirstName = "Alicja",
                LastName = "Bibliotekarz",
                Profile = new Profile
                {
                    Nickname = "Bibliotekarz",
                    Description = "Domowa biblioteka – wersja WPF"
                }
            };

            // Inicjalizacja serwisów
            _library = new LibraryService(_user);   // Polimorfizm – serwis pracuje na użytkowniku
            _reports = new ReportService(_library);
            _data = new DataService("books.json");  // Zapis/odczyt JSON – DataService obsługuje plik

            // Wczytanie danych z pliku JSON
            _library.LoadBooks(_data);              //Odczyt JSON

// Instrukcja warunkowa – sprawdzamy, czy lista książek jest pusta

            if (!_library.Books.Any()) //LINQ bo uzylismy .Any()
            {
                // Dodajemy przykładową książkę
                var b = _library.AddBook(
                    "Przejscia perkusyjne",
                    Genre.Other,
                    "en",
                    "Adam",
                    "Kowalski",
                    "Polska",
                    "polski"
                );

                b.MarkAsRead(5, "Praktyczne");
            }

            RefreshBooksList();
        }

        private void RefreshBooksList()
        {
            BooksList.ItemsSource = null;
            BooksList.ItemsSource = _library.Books;   // Kolekcja generyczna:Books to List<Book>
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            //Interfejs użytkownika – okienka InputBox
            var title = Microsoft.VisualBasic.Interaction.InputBox(
                "Podaj tytuł książki:", "Nowa książka", "");

            //Instrukcja warunkowa: sprawdzam, czy tytuł jest pusty
            if (string.IsNullOrWhiteSpace(title))
                return;

            var firstName = Microsoft.VisualBasic.Interaction.InputBox(
                "Podaj imię autora:", "Autor", "");

            var lastName = Microsoft.VisualBasic.Interaction.InputBox(
                "Podaj nazwisko autora:", "Autor", "");

            var genreText = Microsoft.VisualBasic.Interaction.InputBox(
                "Podaj gatunek (Fantasy, SciFi, Horror, Novel, Romance, Thriller, Biography):",
                "Gatunek",
                "Novel"
            );

            //Instrukcja warunkowa
            //Enum.TryParse sprawdzam czy gatunek jest poprawny
            if (!Enum.TryParse(genreText, true, out Genre genre))
            {
                MessageBox.Show("Niepoprawny gatunek — ustawiono Novel.");
                genre = Genre.Novel;
            }

            // Dodanie książki
            var book = _library.AddBook(
                title,
                genre,
                null,
                firstName,
                lastName,
                null,
                null
            );

            MessageBox.Show($"Dodano książkę: {book.Title}");
            RefreshBooksList();
        }

        private void MarkRead_Click(object sender, RoutedEventArgs e)
        {
//Instrukcja warunkowa – sprawdzam, czy wybrano książkę
            if (BooksList.SelectedItem == null)
            {
                MessageBox.Show("Wybierz książkę z listy.");
                return;
            }

            Book book = (Book)BooksList.SelectedItem;

            //Interfejs użytkownika – otwieramy okno oceniania
            var rateWindow = new RateBookWindow
            {
                Owner = this
            };

            //Sprawdzam, czy użytkownik kliknął OK
            if (rateWindow.ShowDialog() == true)
            {
                book.MarkAsRead(rateWindow.Rating, rateWindow.Comment);
                MessageBox.Show("Książka oznaczona jako przeczytana.");
                RefreshBooksList();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //LINQ: .ToList()
            // Zapis JSON – SaveBooks zapisuje dane do pliku JSON
            _data.SaveBooks(_library.Books.ToList());

            MessageBox.Show("Zapisano książki do pliku JSON.");
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            //Ssprawdzam, czy wybrano książkę
            if (BooksList.SelectedItem == null)
            {
                MessageBox.Show("Wybierz książkę z listy.");
                return;
            }

            Book book = (Book)BooksList.SelectedItem;

            // Otwieram okno szczegółów
            var window = new BookDetailsWindow(book, _library);
            window.ShowDialog();

            RefreshBooksList();
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            // Otwieram okno statystyk
            var statsWindow = new StatystykiWindow(_reports);
            statsWindow.Owner = this;
            statsWindow.ShowDialog();
        }
    }
}