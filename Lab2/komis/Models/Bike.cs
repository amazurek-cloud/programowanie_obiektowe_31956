namespace Lab2.Models
{
    public class Bike : Vehicle
    {
        public string Color { get; set; }

        public Bike(string model, int year, string color)
            : base(model, year)
        {
            Color = color;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("BIKE");
            base.ShowInfo();
            Console.WriteLine($"Color: {Color}");
        }
    }
}