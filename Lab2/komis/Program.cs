using Lab2.Models;
using Newtonsoft.Json;

//tworze pelna sciezke do json
var path = Path.Combine(Directory.GetCurrentDirectory(), "data.json");

var settings = new JsonSerializerSettings
{
    TypeNameHandling = TypeNameHandling.Auto,
    Formatting = Formatting.Indented
};

List<Vehicle> data;

//wczytuuje dane z pliku json
if (File.Exists(path))
{
    var txt = File.ReadAllText(path);
    data = JsonConvert.DeserializeObject<List<Vehicle>>(txt, settings) ?? new List<Vehicle>();
}
else
{
    data = new List<Vehicle>();
}

bool continueApp = true;

do
{
    Console.WriteLine("\n=== KOMIS SAMOCHODOWY ===");
    Console.WriteLine("1. Lista pojazdów");
    Console.WriteLine("2. Dodaj Car");
    Console.WriteLine("3. Dodaj Bike");
    Console.WriteLine("4. Usuń pojazd");
    Console.WriteLine("5. Zmień kolor auta");
    Console.WriteLine("6. Zmień kolor motoru");
    Console.WriteLine("0. Exit");

    var option = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (option)
    {
        case '1':
            ShowList();
            break;
        case '2':
            AddCar();
            break;
        case '3':
            AddBike();
            break;
        case '4':
            RemoveVehicle();
            break;
        case '5':
            ModifyCarColor();
            break;
        case '6':
            ModifyBikeColor();
            break;
        case '0':
            continueApp = false;
            break;
        default:
            Console.WriteLine("Nieznana opcja");
            break;
    }

    SaveData();   // zapisuje sobie dp json po kazdej operacji

} while (continueApp);

return;

//ponizej metody

void SaveData()
{
    var json = JsonConvert.SerializeObject(data, settings);
    File.WriteAllText(path, json);
}

void ShowList()
{
    if (data.Count == 0)
    {
        Console.WriteLine("Brak pojazdów w komisie.");
        return;
    }

    for (int i = 0; i < data.Count; i++)
    {
        Console.WriteLine($"\nID: {i}");
        data[i].ShowInfo();
    }
}

void AddCar()
{
    Console.WriteLine("Podaj model:");
    var model = Console.ReadLine();

    Console.WriteLine("Podaj rok:");
    var success = int.TryParse(Console.ReadLine(), out int year);

    Console.WriteLine("Podaj kolor:");
    var color = Console.ReadLine();

    if (!success || model == null || color == null)
    {
        Console.WriteLine("Niepoprawne dane.");
        return;
    }

    data.Add(new Car(model, year, color));
    Console.WriteLine("Dodano samochód.");
}

void AddBike()
{
    Console.WriteLine("Podaj model:");
    var model = Console.ReadLine();

    Console.WriteLine("Podaj rok:");
    var success = int.TryParse(Console.ReadLine(), out int year);

    Console.WriteLine("Podaj kolor:");
    var color = Console.ReadLine();

    if (!success || model == null || color == null)
    {
        Console.WriteLine("Niepoprawne dane.");
        return;
    }

    data.Add(new Bike(model, year, color));
    Console.WriteLine("Dodano motor.");
}

void RemoveVehicle()
{
    Console.WriteLine("Podaj ID pojazdu do usunięcia:");
    var success = int.TryParse(Console.ReadLine(), out int id);

    if (!success || id < 0 || id >= data.Count)
    {
        Console.WriteLine("Niepoprawne ID.");
        return;
    }

    data.RemoveAt(id);
    Console.WriteLine("Usunięto pojazd.");
}

void ModifyCarColor()
{
    Console.WriteLine("Podaj ID auta do zmiany koloru:");
    var success = int.TryParse(Console.ReadLine(), out int id);

    if (!success || id < 0 || id >= data.Count)
    {
        Console.WriteLine("Niepoprawne ID.");
        return;
    }

    if (data[id] is not Car car)
    {
        Console.WriteLine("Wybrany pojazd nie jest samochodem.");
        return;
    }

    Console.WriteLine("Podaj nowy kolor:");
    var newColor = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(newColor))
    {
        Console.WriteLine("Niepoprawny kolor.");
        return;
    }

    car.Color = newColor;
    Console.WriteLine("Zmieniono kolor auta.");
}

void ModifyBikeColor()
{
    Console.WriteLine("Podaj ID motoru do zmiany koloru:");
    var success = int.TryParse(Console.ReadLine(), out int id);

    if (!success || id < 0 || id >= data.Count)
    {
        Console.WriteLine("Niepoprawne ID.");
        return;
    }

    if (data[id] is not Bike bike)
    {
        Console.WriteLine("Wybrany pojazd nie jest motorem.");
        return;
    }

    Console.WriteLine("Podaj nowy kolor:");
    var newColor = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(newColor))
    {
        Console.WriteLine("Niepoprawny kolor.");
        return;
    }

    bike.Color = newColor;
    Console.WriteLine("Zmieniono kolor motoru.");
}