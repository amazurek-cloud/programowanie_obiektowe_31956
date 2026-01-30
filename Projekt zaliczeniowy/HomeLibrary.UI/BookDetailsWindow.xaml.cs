using System.Windows;
using HomeLibrary.Models;
using HomeLibrary.Services;

namespace HomeLibrary.UI
{
    // Okno szczegółów książki

//Dziedziczenie:okno dziedziczy po Window
//Polimorfizm: BookDetailsWindow może być traktowane jako Window
    public partial class BookDetailsWindow : Window
    {
//Hermetyzacja – prywatne pola, dostępne tylko w tej klasie
        private readonly Book _book; //readonly ustawione w konstruktorze i jzu nie zmieniane)
        private readonly LibraryService _library;
        private readonly Author? _author;

        public BookDetailsWindow(Book book, LibraryService library)
        {
            InitializeComponent();      //Interfejs użytkownika – uruchamia XAML

            _book = book;
            _library = library;

            // Pobieram autora książki
            _author = _library.GetAuthorById(book.AuthorId);

            //Interfejs:powiązanie danych z oknem
            DataContext = this;
        }
        public string TitleText => _book.Title;
        public string Genre => _book.Genre.ToString();

        public string ReadStatusText =>
            _book.ReadStatus == ReadStatus.Read ? "Przeczytana" : "Nieprzeczytana";

//Instrukcja warunkowa: sprawdzamy, czy jest ocena
        public string RatingText =>
            _book.Rating.HasValue ? $"{_book.Rating}/5" : "Brak oceny";

        // Sprawdzam czy jest komentarz
        public string CommentText =>
            string.IsNullOrWhiteSpace(_book.Comment) ? "Brak komentarza" : _book.Comment;

        // Sprawdzam czy jest data przeczytania
        public string DateReadText =>
            _book.DateRead.HasValue ? _book.DateRead.Value.ToShortDateString() : "—";

        //sprawdzam czy autor istnieje
        public string AuthorFullName =>
            _author is null ? "Autor nieznany" : $"{_author.FirstName} {_author.LastName}";

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // interfejs- otwieram okno edycji
            var editWindow = new EditBookWindow(_book, _library)
            {
                Owner = this
            };

            //sprawdzam czy użytkownik kliknął OK
            if (editWindow.ShowDialog() == true)
            {
                MessageBox.Show("Zaktualizowano dane książki.");
                Close();                //zamykam okno
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Instrukcja warunkowa:potwierdzenie usunięcia
            if (MessageBox.Show("Na pewno usunąć?", "Potwierdzenie", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                _library.DeleteBook(_book.Id);   // Usuwam książkę z kolekcji
                MessageBox.Show("Usunięto książkę");
                Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();                            //Interfejs: zamknięcie okna
        }
    }
}