using System.ComponentModel.DataAnnotations.Schema;

namespace programowanie_obiektowe_31956;

//Zadanie 7: Utwórz tablicę Zwierze[] z obiektami różnych zwierząt i wywołaj DajGlos() w pętli foreach.
 class Zwierze
{
 public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
}
class Pies : Zwierze
{
 public override void DajGlos() => Console.WriteLine("Hau hau!");
}
class Kot : Zwierze
{
 public override void DajGlos() => Console.WriteLine("Miau!");
}

class Kogut: Zwierze
{
    public override void DajGlos() => Console.WriteLine("Kukuryku!");
}

class Krowa: Zwierze
{

    public override void DajGlos() => Console.WriteLine("Muuuuu!");
}
public class Program
{
    public static void Main()
    {
        Zwierze[] zwierzeta =
        {
            new Pies(),
            new Kot(),
            new Kogut(), 
            new Krowa()
        };


    foreach (Zwierze z in zwierzeta)
    {
        z.DajGlos();
    }
    }
}

