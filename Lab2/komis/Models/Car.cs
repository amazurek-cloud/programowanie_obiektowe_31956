namespace Lab2.Models
{
    public class Car : Vehicle
    {
        public string Color { get; set; }

        public Car(string model, int year, string color)
            : base(model, year)
        {
            Color = color;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("CAR");
            base.ShowInfo();
            Console.WriteLine($"Color: {Color}");
        }
    }
}