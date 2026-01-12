// zad.1 petla while:

//SPOSOB I

/*

string haslo = "admin123";
Console.WriteLine("Podaj haslo:");
string password = Console.ReadLine();
while (password != haslo)
{
    Console.WriteLine ("Błędne haslo. Wpisz ponownie");
    password = Console.ReadLine();
}
 */

//SPOSOB II


string poprawne_haslo = "admin123";
while (true)
{
    Console.WriteLine("Podaj haslo");
	string haslo = Console.ReadLine();
	if 
    (haslo == poprawne_haslo)
    {
		Console.WriteLine ("zalogowano");
		break;
    }
	else
    {
        Console.WriteLine("Błedne, wpisz ponownie");
    }
}


/* zad. 2 petla do while:
Zadanie 2: Poproś użytkownika o podanie liczby większej od zera. Jeśli poda liczbę ujemną
lub 0 — zapytaj ponownie. */


int liczba;

do
{
Console.Write("Podaj liczbę większą od zera ");
liczba = int.Parse(Console.ReadLine());
}
while
(liczba <= 0);
Console.WriteLine ("Podano prawidłową cyfrę");



//Zadanie 3: Utwórz tablicę z 5 nazwami miast i wypisz każde miasto w osobnej linii.

string[]miasta = {"Jędrzejów", "Kielce", "Kraków", "Warszawa", "Gdańsk"};

foreach (string miasto in miasta)
{
    Console.WriteLine ($"{miasto}");
}
