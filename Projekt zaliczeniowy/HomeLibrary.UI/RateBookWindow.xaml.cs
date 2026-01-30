using System.Windows;
using System.Windows.Controls;

namespace HomeLibrary.UI
{
//Dziedziczenie: RateBookWindow dziedziczy po Window
//Polimorfizm – obiekt RateBookWindow może być traktowany jako Window
    public partial class RateBookWindow : Window
    {
//Hermetyzacja: prywatny setter, tylko klasa może ustawić wartość
        public int Rating { get; private set; }

// Hermetyzacja prywatny setter to samo tylko z dot. komentarza
        public string? Comment { get; private set; }

        public RateBookWindow()
        {
            InitializeComponent();      // Interfejs użytkownika: inicjalizacja elementów XAML
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
//Instrukcja warunkowa(sprawdzam, czy wybrano ocenę i czy da się ją sparsować)
            if (RatingBox.SelectedItem is ComboBoxItem item &&
                int.TryParse(item.Content.ToString(), out int rating))
            {
                Rating = rating;        // zapis wybranej oceny
                Comment = CommentBox.Text; // zapis komentarza użytkownika

                DialogResult = true;    // Interfejs użytkownika – zamyka okno i zwraca wynik
            }
            else
            {
//  Interfejs użytkownika= komunikat dla użytkownika
                MessageBox.Show("Wybierz ocenę od 1 do 5.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;       // Interfejs użytkownika: zamyka okno bez zapisu
        }
    }
}