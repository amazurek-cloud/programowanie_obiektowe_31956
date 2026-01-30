using System;
using System.Linq;
using System.Windows;
using HomeLibrary.Models;
using HomeLibrary.Services;

namespace HomeLibrary.UI
{
    // Interfejs użytkownika – klasa okna WPF dziedziczy po Window (polimorfizm: StatystykiWindow → Window)
    public partial class StatystykiWindow : Window
    {
// Hermetyzacja
// Polimorfizm – ReportService może korzystać z różnych implementacji LibraryService
        private readonly ReportService _reports;

        public StatystykiWindow(ReportService reports)
        {
            InitializeComponent();      // Interfejs użytkownika – inicjalizacja elementów XAML
            _reports = reports;

            LoadGenres();               // wczytanie listy gatunków
            LoadStats();                // wczytanie statystyk
        }

        private void LoadGenres()
        {
            //LINQ – Cast<Genre>() konwertuje tablicę enumów na kolekcję generyczną
            GenreComboBox.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();

            GenreComboBox.SelectionChanged += GenreComboBox_SelectionChanged;
        }//jeśli użytkownik zmieni wybór w liście rozwijanej (ComboBox), to uruchom tę konkretną metodę
        // Inaczej Gdy ktoś kliknie i wybierze inny gatunek, to wykonuje sie kod odpowiedzialny za przeliczenie statystyk


        private void LoadStats()
        {
            //Interfejs użytkownika – ustawianie tekstu w kontrolkach
            //Program liczy, ile książek zostało przeczytanych, używając metody CountReadBooks()
            // a potem wyświetla ten wynik w oknie, ustawiając tekst kontrolki ReadCountText

            ReadCountText.Text = $"Przeczytane książki: {_reports.CountReadBooks()}";
            UnreadCountText.Text = $"Nieprzeczytane książki: {_reports.CountUnreadBooks()}";

            // Instrukcja warunkowa – sprawdzamy, czy wybrano gatunek
            if (GenreComboBox.SelectedItem is Genre g)
            {
                GenreCountText.Text = $"Książki w gatunku {g}: {_reports.CountByGenre(g)}";
            }
        }

        private void GenreComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        // Ta metoda uruchamia się automatycznie, kiedy użytkownik zmieni wybór w ComboBoxie.
        // i sprawdza, jaki gatunek został wybrany i wyświetla liczbę książek tego gatunku.
        {
            // Instrukcja warunkowa – sprawdzamy wybrany gatunek
            if (GenreComboBox.SelectedItem is Genre g)
            {
                GenreCountText.Text = $"Książki w gatunku {g}: {_reports.CountByGenre(g)}";
            }
        }
    }
}