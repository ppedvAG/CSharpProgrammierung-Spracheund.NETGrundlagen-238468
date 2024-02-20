#region Arrays
int[] zahlen; //Arrayvariable anlegen mit <Typ>[]
zahlen = new int[10]; //Leeres Array anlegen mit 10 Plätzen, Index 0-9
zahlen[2] = 5; //An Stelle 2 den Wert 5 hineinlegen
Console.WriteLine(zahlen[2]); //Wert an Stelle 5 auslesen

//Direkte Initialisierung
//Initiales befüllen von dem Array
zahlen = new int[] { 1, 2, 3, 4, 5 }; //Die 5 gegebenen Werte bilden das Array (Größe 5)
zahlen = new[] { 1, 2, 3, 4, 5 };
int[] zahlenDirekt = { 1, 2, 3, 4, 5 };
zahlen = [1, 2, 3, 4, 5]; //Neu seit C# 12

Console.WriteLine(zahlen.Length); //Länge des Arrays (10)
Console.WriteLine(zahlen.Contains(5)); //Ist der Wert 5 enthalten? -> true

//Mehrdimensionales Array
int[,] zweiDArray = new int[3, 5]; //Matrix 3x5
zweiDArray[1, 2] = 10;

Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen (2)
Console.WriteLine(zweiDArray.GetLength(0)); //Länge der ersten Dimension (3)
Console.WriteLine(zweiDArray.GetLength(1)); //Länge der ersten Dimension (5)
Console.WriteLine(zweiDArray.Length); //Gesamtanzahl der Elemente (15)

int[,,] dreiDArray = new int[3, 4, 5]; //Quader 3x4x5
dreiDArray[1, 2, 3] = 10;
#endregion

#region Bedingungen
if (zahlen.Contains(5)) //Wenn das zahlen Array 5 enthält, dann...
{
    Console.WriteLine("Zahlen enthält 5");
}
else //Wenn nicht...
{
	Console.WriteLine("Zahlen enthält nicht 5");
}

int zahl1 = 5;
if (zahl1 % 2 == 0) //Ist zahl1 gerade?
{
    Console.WriteLine("Die Zahl ist gerade");
}
else
{
    Console.WriteLine("Die Zahl ist ungerade");
}

if (!zahlen.Contains(5)) //Enthält Zahlen nicht 5?
{

}

//Ternary Operator (?-Operator): Ifs verkürzen

//Ohne Vereinfachungen
if (zahlen.Contains(5))
{
	Console.WriteLine("Zahlen enthält 5");
}
else //Wenn nicht...
{
	Console.WriteLine("Zahlen enthält nicht 5");
}

//Bei Einzeiligen Blöcken mit Klammern können die Klammern weggelassen werden
if (zahlen.Contains(5))
	Console.WriteLine("Zahlen enthält 5");
else
	Console.WriteLine("Zahlen enthält nicht 5");

Console.WriteLine(zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5"); //Code nach ? bei true, Code nach : bei false

//zahlen.Contains(5) ? Console.WriteLine("Zahlen enthält 5") : Console.WriteLine("Zahlen enthält nicht 5"); //WriteLine hat kein Ergebnis -> nicht möglich

string str = zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5";
Console.WriteLine(str);
#endregion