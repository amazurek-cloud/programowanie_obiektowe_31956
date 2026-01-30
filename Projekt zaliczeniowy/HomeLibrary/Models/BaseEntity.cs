using System;

namespace HomeLibrary.Models
{
// Klasa abstrakcyjna. Kazda klasa ktora po niej dziedziczy dostaje unikalne ID,
                        // date utworzenia,mozliwosc polimorficznego wyswietlania info
    public abstract class BaseEntity
    {
// Hermetyzacja – publiczny odczyt, prywatny zapis
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        // Deklaracja polimorfizmu. Nadpisanie w Book.cs albo np. w Loan.cs
        public virtual void PrintInfo()
        {
            Console.WriteLine($"ID: {Id}, Utworzono: {CreatedAt}");
        }
    }
}