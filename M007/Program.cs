namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		//Enumerable.Range(0, 1_000_000_000).ToList(); //Wird automatisch am Ende des Programms eingesammelt

		#region Static
		//Static: Global, statische Member können von überall angegriffen werden
		Console.WriteLine(); //Statischer Zugriff über Console.
							 //Console c = new Console(); //Konsole kann nicht erstellt werden, weil static

		//Person.Alter = 10; //Hier wird ein Objekt benötigt, weil Alter individuell ist
		Person p = new Person();
		p.Alter = 10;

        Console.WriteLine(DateTime.Now);

		for (int i = 0; i < 10; i++)
			new Person();

		Console.WriteLine(Person.Zaehler); //Möglich, weil static
		#endregion

		#region Werte-/Referenztypen
		//struct vs class

		//Zuweisung
		//class: referenziert
		//struct: kopiert

		//Vergleich
		//class: Speicheradressen
		//struct: Inhalte
		#endregion

		#region Null
		//Null: kein Wert
		Person p2 = null; //Variable ist hier null
        //Console.WriteLine(p2.Alter); //p2 enthält kein Objekt

		if (p2 != null) //Wenn in p2 etwas enthalten ist
            Console.WriteLine(p2.Alter);

		//Nicht nullable: int, double, char, float, bool, ... (structs)
		//int x = null; //Nicht möglich
		int? x = null; //? am Ende eines Typens macht diesen Typen nullable
        #endregion

        #region Datumswerte
        //DateTime und TimeSpan

        //DateTime: fixer Zeitpunkt mit Jahr, Montag, Tag, Stunde, Minute, Sekunde, ...
        Console.WriteLine(DateTime.Now);

        Console.WriteLine(new DateTime(2000, 1, 1));

        Console.WriteLine(DateTime.Now - new DateTime(2000, 1, 1));

        Console.WriteLine(DateTime.Now + TimeSpan.FromHours(60)); //Datumswerte addieren
        #endregion
    }

	/// <summary>
	/// Code, der beim Aufräumen durch den GC ausgeführt wird
	/// </summary>
	~Program()
	{
        Console.WriteLine("Programm Ende");
    }
}