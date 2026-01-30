using System;
using System.Collections.Generic;
using System.Linq;
using HomeLibrary.Models;

namespace HomeLibrary.Services
{
            // Główny serwis zarządzający książkami i autorami.
            // Implementujemy tu interfejs z ILibraryService.


    //Dziedziczenie
    public class LibraryService : ILibraryService
    {
        private readonly User _user; //przechowuje uzytkownika, do ktorego nalezy biblioteka.
        //To tez na przyszlosc do rozwiniecia apki. Reandonly= to pole mozna ustawic tylko raz, a potem nigdy nie wolno go zmieniac 
        // ustawiany w konstruktorze lub w przypadku deklaracji, potem nie moge zmienic



        // Kolekcje generyczne – przechowują książki i autorów.
        public List<Book> Books { get; } = new List<Book>();
        public List<Author> Authors { get; } = new List<Author>();

        public LibraryService(User user) //konstruktor klasy wywoluje sie w momencie tworzenia obiektu
        {
            _user = user;
        }

    // Wczytanie książek z JSON i LINQ do wyszukiwania autorow
        public void LoadBooks(DataService data)
        {
            Books.Clear(); //czyszcze listy ksiazek i autorow
            Authors.Clear();

            var loaded = data.LoadBooks(); //wczytuje ksiazki z pliku DataService 
            // i zapisuje do zmiennej loaded. data=obiekt klasy DataService,ktory zostal przekazany do metody LoadBooks

            Books.AddRange(loaded);

            //Tworze liste autorow na nowo, korzystajac z info. zapisanych w ksiazkach.
            //Bo autorzy nie byli zapisywani w pliku JSON- zapisywalam tylko ksiazki.
            //A kiedy wczytuje ksiazki, musze odbudowac liste autorow, zeby apka dzialala.

// PETLA- Odtwarzanie autorów na podstawie danych w książkach
            foreach (var b in Books)
            {
                var existing = Authors.FirstOrDefault(a =>
                    a.FirstName == b.AuthorFirstName &&
                    a.LastName == b.AuthorLastName &&
                    a.UserId == _user.Id);

                if (existing == null)
                {
                    Authors.Add(new Author
                    {
                        UserId = _user.Id,
                        FirstName = b.AuthorFirstName,
                        LastName = b.AuthorLastName,
                        Country = null,
                        Language = null
                    });
                }
            }
        }


        public Book AddBook(string title, Genre genre, string? lang,// Dodanie nowej książki wraz z autorem.
                            string firstName, string lastName,
                            string? country, string? language)
        {


        // Szukamy autora – LINQ, po to zeby moc miec wiele jego ksiazek i nie duplikowac danych w postaci jego imienia i nazwiska
        //Przeszukuje liste Authors. Jak znajde, zwracam autora, jak nie, zwracam null i tworze nowego.

//Uzycie LINQ -szukam autora, zeby nie dublowac danych jesli juz jest w bazie
            var author = Authors.FirstOrDefault(a =>
                a.FirstName == firstName &&
                a.LastName == lastName &&
                a.UserId == _user.Id);

//Instrukcja warunkowa
            if (author == null)
            {
                author = new Author
                {
                    UserId = _user.Id,
                    FirstName = firstName,
                    LastName = lastName,
                    Country = country,
                    Language = language //dodatkowo
                };
            //Dodaje go do Authors
                Authors.Add(author);
            }
            //tworze nowy obiekt Book i wypelniam pola
            var book = new Book 
            {
                UserId = _user.Id,
                AuthorId = author.Id,
                Title = title,
                Genre = genre,
                OriginalLanguage = lang, //to dodatkowo na przyszlosc
                AuthorFirstName = firstName,
                AuthorLastName = lastName
            };

            Books.Add(book); //dodaje nowo utworzona ksiazke do kolekcji
            return book;
        }

        public Author? GetAuthorById(Guid id) //tworze metode ktora zwraca autora jesli go znajdzie
        // ,,?" znaczy ze moze nie miec wartosci
        {
            return Authors.FirstOrDefault(a => a.Id == id);
        }

        //Usuwanie ksiazki o podanym ID, jesli istnieje
        public void DeleteBook(Guid id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
                Books.Remove(book);
        }
    }
}