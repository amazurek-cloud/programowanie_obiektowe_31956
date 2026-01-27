namespace Lab2.Models
{
    public abstract class Vehicle
    {
        public string Model { get; }
        public int Year { get; }

        public Vehicle(string model, int year)
        {
            Model = model;
            Year = year;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
        }

        public virtual void ShowInfo(string header)
        {
            Console.WriteLine(header);
            ShowInfo();
        }
    }
}