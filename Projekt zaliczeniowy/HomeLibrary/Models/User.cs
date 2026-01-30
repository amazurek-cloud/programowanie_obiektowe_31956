namespace HomeLibrary.Models
{
    // Dziedziczenie – User dziedziczy po Person.
    public class User : Person
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Kompozycja – użytkownik posiada profil.
        public Profile Profile { get; set; } = new Profile();

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Login: {Login}, Nick: {Profile.Nickname}");
        }
    }
}