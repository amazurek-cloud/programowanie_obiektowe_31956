namespace HomeLibrary.Models
{
    //Dziedziczenie: Profile dziedziczy po BaseEntity
    public class Profile : BaseEntity
    {
        public string Nickname { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string GenerateDescription()
        {
            if (string.IsNullOrWhiteSpace(Description))
                return $"Profil: {Nickname}";

            return $"{Nickname} - {Description}";
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Nick: {Nickname}, Opis: {Description}");
        }
    }
}