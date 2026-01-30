namespace HomeLibrary.Models
{
    // Dziedziczenie – Person dziedziczy po BaseEntity
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }
}