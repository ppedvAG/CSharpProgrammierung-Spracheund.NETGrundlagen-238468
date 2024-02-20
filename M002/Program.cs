#region Variable
//Variable: <Typ> <Name>;
int Zahl;
Zahl = 5;
Console.WriteLine(Zahl); //cw + Tab

/*
	Mehrzeilige
	Kommentare
*/

//Datentypen
//Ganze Zahlen: byte, short, int, long
long l = 2983749813274981374;

//Kommazahlen: float, double, decimal
double d = 8321471.218471294;
float f = 21984.21857419f;
decimal m = 21984.21857419m;

//Texttypen: char, string
string s = "Hallo"; //Doppelte Hochkomma
char c = 'A'; //Einzelne Hochkomma

//Boolean
bool bt = true;
bool bf = false;
#endregion

#region Strings
//Strings verbinden
string kombi = "Der Text ist " + s + ", die Zahl ist " + Zahl + ", die Kommazahl ist " + d;
Console.WriteLine(kombi);

//String Interpolation ($-String): Ermöglicht, Code in einen String einzubinden
string interpolation = $"Der Text ist {s}, die Zahl ist {Zahl}, die Kommazahl ist {d}";
Console.WriteLine(interpolation);

//Escape Sequenzen: Untippbare Zeichen in einen String einbauen
//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
string umbruch = "Umbruch \n Umbruch"; //\n: Zeilenumbruch
Console.WriteLine(umbruch);

string pfad = "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.1\\System.Threading.Overlapped.dll";
Console.WriteLine(pfad);

//Verbatim String (@-String): String der Escape Sequenzen ignoriert
string umbruch2 = @"Umbruch \n Umbruch";
string pfad2 = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.1\System.Security.Claims.dll";
Console.WriteLine(umbruch2);
#endregion

#region Eingabe
//string input = Console.ReadLine(); //Wartet, bis der User Enter drückt, und schreibt dann seine Eingabe in die Input Variable
//Console.WriteLine($"Du hast {input} eingegeben");

//Console.Write("Gib eine Zahl ein: "); //Write: Macht am Ende der Zeile keinen Umbruch
//Console.ReadLine(); //Eingabeaufforderung auf der selben Zeile

//ConsoleKeyInfo info = Console.ReadKey(); //Wartet auf genau einen Input (ohne Enter)
//Console.WriteLine($"Du hast {info.Key} gedrückt"); //ConsoleKeyInput: Enthält mehrere Informationen zum gedrückten Key
#endregion

#region Konvertierungen
//Drei Richtungen
//beliebiger Typ -> string
//string -> beliebiger Typ
//beliebiger Typ -> beliebiger Typ

//ToString()
string zahlAlsString = Zahl.ToString();

//<Typ>.Parse(...)
Console.Write("Gib eine Zahl ein: ");
string zahlInput = Console.ReadLine();
int x = int.Parse(zahlInput); //Parse: Versucht, den String zu einer Zahl umzuwandeln
Console.WriteLine($"Deine Zahl mal zwei ist {x * 2}");

//Typecast, Casting, Cast
double y = 38925.985723;
int z = (int) y; //Explizite Konvertierung: Umwandlung von double zu int erzwingen mittels Cast
Console.WriteLine(z); //Kommastellen werden abgeschnitten
double a = z; //Implizite Konvertierung: Alle ints passen in double hinein
#endregion

#region Arithmetik
int zahl1 = 4;
int zahl2 = 7;

Console.WriteLine(zahl1 + zahl2); //Berechnet die Summe, lässt die Variablen unberührt
Console.WriteLine(zahl1);
Console.WriteLine(zahl2);

zahl1 += zahl2; //Berechnet die Summe und schreibt das Ergebnis in die linke Variable hinein
Console.WriteLine("-------------");
Console.WriteLine(zahl1);
Console.WriteLine(zahl2);

//Modulo: Rest der Division
Console.WriteLine(zahl2 % zahl1); //Sind die zwei Zahlen restlos teilbar?
Console.WriteLine(zahl1 % 2); //Ist die Zahl gerade?

zahl1++; //zahl1 += 1
zahl1--; //zahl1 -= 1

Math.Floor(4.5); //Abrunden
Math.Ceiling(4.5); //Aufrunden
Math.Round(4.5); //Rundet auf oder ab, .5 wird zum nächsten geraden Wert gerundet

Math.Round(4.5); //4
Math.Round(5.5); //6

//Auf X Kommastellen runden
double r = Math.Round(43294.328753, 2); //Auf 2 Kommastellen runden
Console.WriteLine(r);

//Divisionen
Console.WriteLine(8 / 5); //1
Console.WriteLine(8 / 5.0); //1.6
Console.WriteLine(8.0 / 5); //1.6
Console.WriteLine(8d / 5); //1.6
Console.WriteLine(8f / 5); //1.6
Console.WriteLine(8m / 5); //1.6
Console.WriteLine((double) zahl1 / zahl2); //Konvertierung erzwingen um eine Kommadivision durchzuführen
#endregion