namespace programowanie_obiektowe_31956;


//zad. 4 Utwórz klasę Osoba z polami Imie, Wiek i metodą PrzedstawSie(). Utwórz kilka
//obiektów i wywołaj tę metodę

class Osoba
{
    public string Imie;
    public int Wiek;
    public void PrzedstawSie()
    {
        Console.WriteLine($"Czesc! Jestem {Imie} i mam lat {Wiek}! ");
    }
}

class Program
{
    static void Main()
    {
Osoba o= new Osoba();
o.Imie= "Leo";
o.Wiek= 3;

Osoba b=new Osoba();
b.Imie= "Basia";
b.Wiek=29;

Osoba c=new Osoba();
c.Imie="Czesław";
c.Wiek=67;

Osoba d=new Osoba
{
    Imie="Dariusz",
    Wiek=99
};

o.PrzedstawSie();
b.PrzedstawSie();
c.PrzedstawSie();
d.PrzedstawSie();
    }
}   
