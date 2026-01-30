using System.Collections.Generic;
using HomeLibrary.Models;

namespace HomeLibrary.Services
{
    /// Przykład wykorzystania interfejsów.
    /// Definiuje kontrakt dla serwisu biblioteki.
    public interface ILibraryService //deklaruje interfejs
    {
        List<Book> Books { get; } //implementacja ma miec wlasnosc tylko do odczytu zawierajaca liste ksiazek
        List<Author> Authors { get; } //tylko do odczytu-lista autorow

        void LoadBooks(DataService data); //metoda dla kazdej klasy implementujacej interfejs, ktora wczytuje ksiazki z podanego DataService
        Book AddBook(string title, Genre genre, string? lang,//metoda dodawania nowej ksaizki na podstawie przekazanych danych i zwraca obiekt Book
                     string firstName, string lastName,
                     string? country, string? language);

        Author? GetAuthorById(Guid id); //metoda zapisana w interfejsie, ktora szuka autora po jego ID, to na przyszlosc
        // moze zwrocic obiekt author, ale dzieki ,,?" moze tez zwrocic null
        void DeleteBook(Guid id); //metoda, ktora usuwa ksiazki o podanym ID
    }
}