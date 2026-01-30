using System;

namespace HomeLibrary.Models
{
    public class Book : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid AuthorId { get; set; }

        // Hermetyzacja – same publiczne właściwości. Pokaz inny przyklad lepiej.
        public string Title { get; set; } = string.Empty;

        public string AuthorFirstName { get; set; } = string.Empty;
        public string AuthorLastName { get; set; } = string.Empty;

        public Genre Genre { get; set; }
        public string? OriginalLanguage { get; set; }

        public ReadStatus ReadStatus { get; set; } = ReadStatus.Unread;
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? DateRead { get; set; }

        public CopyStatus CopyStatus { get; set; } = CopyStatus.Available;

    
        public void MarkAsRead(int rating, string? comment)
        {
            ReadStatus = ReadStatus.Read;
            Rating = rating;
            Comment = comment;
            DateRead = DateTime.Now;
        }

        public void MarkAsUnread()
        {
            ReadStatus = ReadStatus.Unread;
            Rating = null;
            Comment = null;
            DateRead = null;
        }

        // Polimorfizm= tu przyklad nadpisania metody wirtualnej z BaseEntity.cs,a wywolanie jest w:
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"{Title} - {AuthorFirstName} {AuthorLastName}");
        }
    }
}