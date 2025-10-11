/*// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");
//string message= "Hello, World!";
//Console.WriteLine(message);

int age=31;
string firstName="Artur";
string message=$"Hello {firstName}. You are {age} years old.";
Console.WriteLine(message);*/

//int age=31;

// Zad.1
//Zadanie 1: Napisz program, który pyta użytkownika o hasło, dopóki nie wpisze poprawnego
//(„admin123”).

/* string correct_password = "admin123";
string password;
do
{
    Console.WriteLine("Podaj poprawne haslo");
    password = Console.ReadLine();
    
}
while (password != correct_password);

Console.WriteLine("Zalogowano");
*/

//Zad.2
//Zadanie 2: Poproś użytkownika o podanie liczby większej od zera. Jeśli poda liczbę ujemną
//lub 0 — zapytaj ponownie

int liczba ;

do
{ Console.WriteLine("Podaj liczbę wieksza od 0"); 
    var liczba = int.Parse (Console.ReadLine());

} while (liczba > 0 );
Console.WriteLine("Poprawna liczba");