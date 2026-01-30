using System;
using System.Linq;
using System.Windows;
using HomeLibrary.Models;
using HomeLibrary.Services;

namespace HomeLibrary.UI
{
//Dziedziczenie – to okno dziedziczy po Window
//Polimorfizm – EditBookWindow może być traktowane jako Window
    public partial class EditBookWindow : Window
    {
        //Hermetyzacja – prywatne pola, dostępne tylko w tej klasie
        private readonly Book _book;
        private readonly LibraryService _library;
        private readonly Author? _author;

        public EditBookWindow(Book book, LibraryService library)
        {
            InitializeComponent();      // interfejs uruchamia XAML

            _book = book;
            _library = library;

            //Pobieram autora książki
            _author = _library.GetAuthorById(book.AuthorId);

            //Interfejs użytkownika bo wypełniam pola tekstowe danymi książki
            TitleBox.Text = _book.Title;
            FirstNameBox.Text = _author?.FirstName ?? "";
            LastNameBox.Text = _author?.LastName ?? "";
            CommentBox.Text = _book.Comment ?? "";
            RatingBox.Text = _book.Rating?.ToString() ?? "";
            ReadCheck.IsChecked = _book.ReadStatus == ReadStatus.Read;

            //Kolekcja generyczna: lista gatunków (IEnumerable<Genre>)
            GenreBox.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            GenreBox.SelectedItem = _book.Genre;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Interfejs użytkownika: pobieram dane z pól
            _book.Title = TitleBox.Text;

            //Instrukcja warun: sprawdzam czy wybrano gatunek
            if (GenreBox.SelectedItem is Genre g)
                _book.Genre = g;

            //Instrukcja warunkowa:sprawdzam, czy autor istnieje
            if (_author != null)
            {
                _author.FirstName = FirstNameBox.Text;
                _author.LastName = LastNameBox.Text;
            }

            // Aktualizacja danych autora w książce
            _book.AuthorFirstName = FirstNameBox.Text;
            _book.AuthorLastName = LastNameBox.Text;

// ✔ Instrukcja warunkowa:sprawdzam status przeczytania
            bool isRead = ReadCheck.IsChecked == true;

            if (isRead)
            {
//Instrukcja warunkowa: sprawdzam poprawność oceny
                if (!int.TryParse(RatingBox.Text, out int rating) ||
                    rating < 1 || rating > 5)
                {
                    MessageBox.Show("Podaj ocenę od 1 do 5, aby oznaczyć książkę jako przeczytaną.");
                    return;
                }

                string? comment = CommentBox.Text;

                // Oznaczam książkę jako przeczytaną
                _book.MarkAsRead(rating, comment);
            }
            else
            {
                // Oznaczylam książkę jako nieprzeczytaną
                _book.MarkAsUnread();
            }

            // Interfejs użyt:zamykamy okno i zwracamy wynik
            DialogResult = true;
            Close();
        }
    }
}