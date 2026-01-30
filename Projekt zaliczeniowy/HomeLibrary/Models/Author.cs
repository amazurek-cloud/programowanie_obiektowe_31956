namespace HomeLibrary.Models
{
    public class Author : BaseEntity
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? Country { get; set; }
        public string? Language { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }
}