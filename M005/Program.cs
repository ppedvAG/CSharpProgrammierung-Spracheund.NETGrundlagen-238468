namespace M005;

internal class Program
{
	/// <summary>
	/// Main Methode: Einstiegspunkt des Programms
	/// In jedem Programm muss immer eine Main Methode existieren
	/// Bei der Öffnungsklammer startet das Programm, wenn es ausgeführt wird
	/// </summary>
	static void Main(string[] args)
	{
		PrintAddiere(4, 5);
		PrintAddiere(3, 9);
		PrintAddiere(3, 2);
		PrintAddiere(5, 5);
		PrintAddiere(1, 2);
		PrintAddiere(8, 7);

		int summe = Addiere(4, 8); //Hier das Ergebnis der Funktion in eine Variable speichern
        Console.WriteLine($"Die Summe ist {summe}");

		Console.WriteLine(123); //Überladung von Methoden: Methoden mit dem selben Namen können in der Klasse mehrmals definiert werden, wenn sich die Parameter unterscheiden
		Console.WriteLine("123"); //1 von 18 Overloads

		Addiere(1, 2); //int Overload
		Addiere(2.2, 3.3); //double Overload

		Summiere(1, 2, 3); //3 Parameter
		Summiere(1, 2, 3, 4, 5, 6, 7); //7 Parameter
		Summiere(2);
		Summiere(); //Auch keine Parameter sind beliebig viele Parameter

		Subtrahiere(4, 5); //Hier wird der Standardwert hinter z übernommen
		Subtrahiere(4, 5, 2); //Hier wird z überschrieben

		PrintPerson(adresse: "Zuhause");
		PrintPerson(nachname: "Mustermann", adresse: "Zuhause");
		PrintPerson(alter: 19);

		AddiereOderSubtrahiere(4, 8);
		AddiereOderSubtrahiere(4, 8);
		AddiereOderSubtrahiere(4, 8);
		AddiereOderSubtrahiere(4, 8);
		AddiereOderSubtrahiere(4, 8);
		AddiereOderSubtrahiere(4, 8, false); //Sonderfall
		AddiereOderSubtrahiere(4, 8);
		AddiereOderSubtrahiere(4, 8);

		//out Parameter: Ermöglicht, mehrere Werte bei einer Funktion zurückzugeben

		//int.Parse("abc"); //Absturz
		int ergebnis; //Hier muss ein dedizierte Variable angelegt werden
		bool funktioniert = int.TryParse("123", out ergebnis); //Hier wird per out-Keyword der Parameter mit der Variable verbunden
		//Wenn TryParse funktioniert hat, steht das Ergebnis in der ergebnis Variable
		if (funktioniert)
		{
            Console.WriteLine($"Die Zahl ist {ergebnis}");
        }
		else
		{
            Console.WriteLine("Parsen hat nicht funktioniert");
        }

		(int, int) x = AddiereUndSubtrahiere(3, 4);
        Console.WriteLine($"Summe: {x.Item1}");
        Console.WriteLine($"Differenz: {x.Item2}");
    }

	/// <summary>
	/// Aufbau einer Funktion:
	/// Rückgabetyp Name(Par1, Par2, Par3, ...)
	/// { Body }
	/// 
	/// void: Kein Ergebnis
	/// nicht void: Ergebnis
	/// </summary>
	static void PrintAddiere(int x, int y)
	{
        Console.WriteLine($"{x} + {y} = {x + y}");
    }

	/// <summary>
	/// Rückgabetyp int -> Per return muss ein int zurückgegeben werden
	/// </summary>
	static int Addiere(int x, int y)
	{
		return x + y; //Gib ein Ergebnis zurück und beende die Funktion
        Console.WriteLine(); //Unreachable Code detected
    }

	/// <summary>
	/// Wenn ein oder zwei doubles als Parameter übergeben werden, wird diese Funktion ausgewählt statt der int Funktion
	/// </summary>
	static double Addiere(double x, double y)
	{
		return x + y;
	}

	/// <summary>
	/// params: Gibt die Möglichkeit, beliebig viele Parameter zu übergeben
	/// Der params Parameter muss ein Array sein
	/// </summary>
	static int Summiere(params int[] x)
	{
		return x.Sum();
	}

	/// <summary>
	/// Optionale Parameter: Parameter mit einem vordefinierten Wert, dieser Parameter kann überschrieben werden
	/// </summary>
	static int Subtrahiere(int x, int y, int z = 0)
	{
		return x - y - z;
	}

	/// <summary>
	/// Methode konfigurierbar machen, alle Parameter sind optional und können dann direkt gesetzt werden bei Methodenaufruf
	/// </summary>
	static void PrintPerson(string vorname = "", string nachname = "", int alter = 0, string adresse = "")
	{
		//...
	}

	static int AddiereOderSubtrahiere(int x, int y, bool add = true)
	{
		if (add)
			return x + y;
		else
			return x - y;
	}

	/// <summary>
	/// Tupel: Gruppierung mehrerer Werte in eine Variable
	/// </summary>
	static (int, int) AddiereUndSubtrahiere(int x, int y)
	{
		return (x + y, x - y);
	}
}
