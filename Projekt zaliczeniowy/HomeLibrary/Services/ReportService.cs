using System.Linq;
using HomeLibrary.Models;

namespace HomeLibrary.Services
{
    /// Serwis generujący proste statystyki.
    /// Przykład wykorzystania LINQ.
    public class ReportService //zadaniem tej klasy liczenie roznych rzeczy w biblio.
    {
        private readonly LibraryService _library; //przechowuje adres do obiektu LibraryService, ktory zostal wczensiej stworzony

        public ReportService(LibraryService library) 
        //tworze obiekt ReportService,ale musze przekazac mu biblio- obiekt LibraryService
        //jak generuje raport to ten kod zapewnia ze będzie ten raport oparty na bibliotece w LibraryService
        {
            _library = library;
        }


//LINQ - przechodze przez liste ksiazek w biblio i licze tylko te przeczytane        
        public int CountReadBooks()
        {
            return _library.Books.Count(b => b.ReadStatus == ReadStatus.Read);
        } 
//LINQ - liczy nieprzeczytane
        public int CountUnreadBooks()
        {
            return _library.Books.Count(b => b.ReadStatus == ReadStatus.Unread);
        }
//LINQ - liczy ksiazki o gatunku, ktory podam w parametrze
        public int CountByGenre(Genre genre)
        {
            return _library.Books.Count(b => b.Genre == genre);
        }
    }
}