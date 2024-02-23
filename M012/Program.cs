using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		List<int> zahlen = Enumerable.Range(1, 20).ToList();

        Console.WriteLine(zahlen.Average());
        Console.WriteLine(zahlen.Min());
        Console.WriteLine(zahlen.Max());
        Console.WriteLine(zahlen.Sum());

		zahlen.First(); //Gibt das erste Element zurück, Exception (Absturz) wenn kein Element gefunden wurde
		zahlen.FirstOrDefault(); //Gibt das erste Element zurück, null/0 wenn kein Element gefunden wurde

		zahlen.Last(); //Gibt das letzte Element zurück, Exception wenn kein Element gefunden wurde
		zahlen.LastOrDefault(); //Gibt das letzte Element zurück, null/0 wenn kein Element gefunden wurde

		//zahlen.First(e => e % 50 == 0); //Finde das erste Element, welches durch 50 restlos teilbar ist (Absturz)
		zahlen.FirstOrDefault(e => e % 50 == 0); //Finde das erste Element, welches durch 50 restlos teilbar ist (0)
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Linq mit Objekten
		//Alle Fahrzeuge finden, die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV > 200);

		//Where:
		//Macht eine Schleife auf die Liste, und prüft bei jedem Element, ob die Bedingung in der Lambda Expression true ist
		//e: Das derzeitige Element der Schleife
		List<Fahrzeug> where = new();
		foreach (Fahrzeug e in fahrzeuge) //Die Where Funktion als Schleife
			if (e.MaxV > 200)
				where.Add(e);

		//Alle VWs mit mindestens 200km/h
		fahrzeuge.Where(e => e.MaxV > 200 && e.Marke == FahrzeugMarke.VW);

		//Sortiere die Liste nach Automarke
		fahrzeuge.OrderBy(e => e.Marke); //Aufsteigend sortieren
		fahrzeuge.OrderByDescending(e => e.Marke); //Absteigend sortieren

		//Sortiere nach Marke und danach Geschwindigkeit
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV).ThenBy(...).ThenBy(...); //Soviele Sortierungen wie benötigt

		//WICHTIG: Bei allen Linq Funktionen, wird niemals die originale Liste verändert

		//Können alle Fahrzeuge mindestens 200km/h fahren?
		fahrzeuge.All(e => e.MaxV > 200); //true oder false
		if (fahrzeuge.All(e => e.MaxV > 200))
		{
            Console.WriteLine("Alle Fahrzeuge fahren +200km/h");
        }

		//Kann ein oder mehr Fahrzeug(e) mindestens 200km/h fahren?
		fahrzeuge.Any(e => e.MaxV > 200); //true oder false
		if (fahrzeuge.Any(e => e.MaxV > 200))
		{
			Console.WriteLine("Mindestens ein Fahrzeug fährt +200km/h");
		}

		//Wieviele BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW); //4

		//Min/MinBy
		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit (int)
		fahrzeuge.MinBy(e => e.MaxV); //Das Objekt mit der kleinsten Geschwindigkeit (Fahrzeug)

		//Die 3 schnellsten Fahrzeuge
		fahrzeuge
			.OrderByDescending(e => e.MaxV)
			.Take(3);

		//Webshop
		int seite = 0;
		fahrzeuge.Skip(seite * 5).Take(5);
		//User klickt auf nächste Seite -> Skip(1 * 5).Take(5)

		//Select
		//Transformiert eine Liste
		//Hauptanwendungsfall: Einzelnes Feld aus der Liste entnehmen

		//Liste mit allen Geschwindigkeiten
		fahrzeuge.Select(e => e.MaxV); //int Liste

		//Was ist die Durchschnittsgeschwindigkeit von allen Autos?
		fahrzeuge.Select(e => e.MaxV).Average();
		fahrzeuge.Average(e => e.MaxV); //Average und Sum haben jeweils eine Funktion, die Select bereits inkludiert

		//Was haben wir für Automarken im Autohaus?
		fahrzeuge
			.Select(e => e.Marke) //Liste mit allen Marken erzeugen
			.Distinct(); //Duplikate entfernen

		//GroupBy
		//Bildet Gruppen anhand eines Kriteriums, und fügt jedes Element zu seiner entsprechenden Gruppe hinzu
		fahrzeuge.GroupBy(e => e.Marke);
		var x = fahrzeuge.GroupBy(e => e.Marke).ToLookup(e => e.Key); //GroupBy angreifbar machen
		Console.WriteLine(x[FahrzeugMarke.BMW]);
		#endregion

		#region Erweiterungsmethoden
		int zahl = 32874;
        Console.WriteLine(zahl.Quersumme());

        Console.WriteLine(38295.Quersumme());

		fahrzeuge.Shuffle();
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}