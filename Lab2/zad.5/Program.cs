namespace programowanie_obiektowe_31956;

//Zadanie 5: Dodaj metodę Wyplata(double kwota), która wypłaca pieniądze tylko jeśli saldo
//jest wystarczające

using System;
class KontoBankowe
{
private double saldo;
public void Wplata(double kwota) { saldo += kwota; }
public void Wyplata(double kwota) {
    if (saldo >=kwota)
    {
    saldo-=kwota;}
    else
    {Console.WriteLine ("Twoje saldo jest zbyt niskie, by wypłacić pieniadze");}

    }

public double PobierzSaldo() { return saldo; }
}

class Program

{
    static void Main()

    {
        KontoBankowe konto = new KontoBankowe();

        konto.Wplata(100);
        konto.Wplata(50);
        Console.WriteLine("Aktualne saldo: " + konto.PobierzSaldo());
        konto.Wyplata(200);
        konto.Wyplata(80);
        Console.WriteLine("Aktualne saldo: " + konto.PobierzSaldo());
    }
}
