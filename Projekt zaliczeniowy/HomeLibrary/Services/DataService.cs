using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HomeLibrary.Models;

namespace HomeLibrary.Services
{
    // Klasa odpowiedzialna za zapis i odczyt danych w formacie JSON.
    public class DataService
    {
        private readonly string _filePath;

        public DataService(string filePath)
        {
            _filePath = filePath;
        }



        // Zapis listy książek do pliku JSON.
        // Kolekcja generyczna List<Book>.
        public void SaveBooks(List<Book> books) //metoda zapisz ksiazki
        {
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions 
            //zamiana listy books na JSON i formatuje zeby byl ladny i czytelny
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json); //zapisuje ten JSON do pliku pod 
            // sciezka _filePath i nadpisuje jego zawartosc
        }




        // Odczyt książek z pliku JSON.
        // Jeśli plik nie istnieje – zwracamy pustą listę.
        public List<Book> LoadBooks()
        {
            if (!File.Exists(_filePath))
                return new List<Book>(); //sprawdza czy plik istnieje,jak nie to zwraca pusta liste

            var json = File.ReadAllText(_filePath); //wczytuje zawartosc pliku jako tekst

            return JsonSerializer.Deserialize<List<Book>>(json) //proba zamiany tekstu JSON na List<Book>
            //jak deserializacja sie nie uda (bo np. plik pusty) to operator ?? zwaraca nowa pusta liste null
                   ?? new List<Book>(); //??= jesli wartosc po lewej str jest null, to uzyj ten po prawej
        }
    }
}