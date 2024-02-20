#region Schleifen
//Schleife: Läuft solange, die gegebene Bedingung true ist
using System.Net;

int a = 0;
int b = 10;
while (a < b) //Am Ende der Schleife wird jedes mal geprüft, ob die Bedingung noch true ist
{
    Console.WriteLine($"while: {a}");
    a++;
} //Springe zum Anfang zurück

a = 0;

//do-while Schleife: Code in der Schleife wird immer einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
do
{
	Console.WriteLine($"do-while: {a}");
	a++;
}
while (a < b); //Bei a = 20 wird der Code hier trotzdem ausgeführt

//break und continue
//break: Beendet die Schleife
//continue: Springe zum Schleifenkopf, ab dem continue Keyword wird der Code danach übersprungen

a = 0;

//do-while ohne do-while
while (true) //Endlosschleife
{
    Console.WriteLine($"while true: {a}");
	a++;

	if (a == 5)
		continue; //Überspringe bei a = 5 allen Code der danach kommt

    Console.WriteLine();
    if (a >= 10) //Wenn a = 10 oder mehr, beende die Schleife
		break;
}

//for-Schleife: Schleife die bis zu einer bestimmten Bedingung läuft, aber einen Zähler integriert hat
//for + Tab
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"for: {i}");
}

//forr + Tab
for (int i = 10 - 1; i >= 0; i--)
{
	Console.WriteLine($"forr: {i}");
}

//Array durchgehen
int[] zahlen = [2, 5, 1, 29, 68, 19, 37, 57];
for (int i = 0; i < zahlen.Length; i++) //Lege eine Variable mit Inhalt 0 an, gehe bis zum Maximum des Arrays und gib die derzeitige Zahl auf der Konsole aus
{
	//Console.WriteLine(zahlen[i + 1]); //Schleife mit Index kann daneben greifen
	Console.WriteLine(zahlen[i]);
}

//foreach + Tab
foreach (int i in zahlen)
{
    Console.WriteLine(i);
}

string[] zeichenArray = ["A", "B", "C"];
foreach (string zeichen in zeichenArray) //Variable in der Schleife passt sich auf den Arraytypen an
{
    Console.WriteLine(zeichen);
}
#endregion

#region Enums
//Enum: Liste von Konstanten
//Wird als eigener Typ erstellt, der die ganzen Konstanten enthält

HttpStatusCode code = HttpStatusCode.NotFound; //Variable, welchen den NotFound Zustand speichert
if (code == HttpStatusCode.NotFound)
{
    Console.WriteLine("Nicht gefunden");
}

//Fehleranfällig
//string strCode = "NotFound";
//if (strCode == "NotFound")
//{
//	Console.WriteLine("Nicht gefunden");
//}

Wochentag heute = Wochentag.Di;
if (heute == Wochentag.Di)
{
    Console.WriteLine("Heute ist Dienstag");
}

//Hinter jedem Enumwert steht immer ein int
//Jeder Enumwert ist nur ein benannter int
Console.WriteLine((int) heute); //Den Wert hinter Dienstag holen (1)
Console.WriteLine((Wochentag) 1); //Aus einem int einen Wochentag machen (Di)

//Alle Enumwerte in einer Schleife ausgeben
Wochentag[] tage = Enum.GetValues<Wochentag>();
foreach (Wochentag tag in tage)
{
	Console.WriteLine(tag);
}
#endregion

#region Switch
Wochentag wochentag = Wochentag.Di;
if (wochentag == Wochentag.Mo)
	Console.WriteLine("Wochenanfang");
else if (wochentag == Wochentag.Di || wochentag == Wochentag.Mi || wochentag == Wochentag.Do || wochentag == Wochentag.Fr)
	Console.WriteLine("Unter der Woche");
else if (wochentag == Wochentag.Sa || wochentag == Wochentag.So)
	Console.WriteLine("Wochenende");
else
	Console.WriteLine("Fehler");

//Switch: if-else Bäume vereinfachen
//Strg + . auf das switch Keyword -> Add cases
switch (wochentag)
{
	case Wochentag.Mo: //Effektiv eine if
		Console.WriteLine("Wochenanfang");
		break; //Am Ende jedes Cases muss ein break stehen
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
		Console.WriteLine("Unter der Woche");
		break;
	case Wochentag.Sa:
	case Wochentag.So:
		Console.WriteLine("Wochenende");
		break;
	default: //Alles andere
		Console.WriteLine("Fehler");
		break;
}
#endregion

//Eigenes Enum muss am Ende der Datei stehen
//Enumwerte können eine Zuweisung bekommen, nachfolgende Werte werden dann aufgeschoben
enum Wochentag
{
	Mo = 1, Di, Mi, Do, Fr, Sa, So
}