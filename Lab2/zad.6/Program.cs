namespace programowanie_obiektowe_31956;

// Zadanie 6: Dodaj klasę Kot, która również dziedziczy po Zwierze i ma metodę Miaucz().
class Zwierze
{
 public void Jedz() => Console.WriteLine("Zwierzę je");
}
class Pies : Zwierze
{
 public void Szczekaj() => Console.WriteLine("Hau hau!");
}

class Kot : Zwierze
{
    public void Miaucz() => Console.WriteLine("Miau miau!");
}
public class Program
{
    public static void Main()
    {

    Pies Lusiapies = new Pies();
    Lusiapies.Jedz();
    Lusiapies.Szczekaj();

    Kot Rysiukot= new Kot();
    Rysiukot.Miaucz();
    Rysiukot.Jedz();
    
    }
}

