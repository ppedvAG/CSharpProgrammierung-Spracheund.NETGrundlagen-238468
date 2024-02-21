namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch();
		m.Alter = 20; //Alter wurde vererbt
		m.Bewegen(10); //Bewegen wird auch vererbt
		m.WasBinIch();

        Console.WriteLine(m);
    }
}

/// <summary>
/// Vererbung: Ermöglicht, die Spezifizierung von Klassen
/// Beispiel: Oberbegriff Lebewesen, spezifiziert Mensch, Hund, Katze, ...
/// </summary>
public class Lebewesen
{
	public int Alter { get; set; }

	public void Bewegen(int distanz)
	{
        Console.WriteLine($"Das Lebewesen bewegt sich um {distanz}m.");
    }

	/// <summary>
	/// Wenn in einer Oberklasse ein Konstruktor definiert wird, muss in den Unterklassen eine Verkettung stattfinden
	/// </summary>
	public Lebewesen(int alter)
	{
		Alter = alter;
	}

	/// <summary>
	/// virtual: Ermöglicht, in den Unterklassen eine Überschreibung durchzuführen, um den Code aus der Oberklasse zu verändern
	/// </summary>
	public virtual void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Lebewesen");
    }

	/// <summary>
	/// ToString(): Gibt eine String Repräsentation von dem Objekt zurück
	/// </summary>
	public override string ToString()
	{
		return "ein Lebewesen";
	}
}

public class Mensch : Lebewesen //Vererbung festlegen
{
	//Alter und Bewegen wird von Lebewesen übernommen

	public string Name { get; set; }

	/// <summary>
	/// Strg + . -> Generate Constructor
	/// Hier einfach neue Attribute hinzufügen per normale Eingabe
	/// base: Greife aus dieser Klasse hinaus, im Vererbungskontext
	/// </summary>
	public Mensch(int alter, string name) : base(alter)
	{
		Name = name;
	}

	public Mensch() : base(0) { }

	/// <summary>
	/// override eintippen -> Abstand -> Methode auswählen
	/// </summary>
	public override void WasBinIch()
	{
        //base.WasBinIch(); //base: Führe die Methode aus der Oberklasse aus
        Console.WriteLine("Ich bin ein Mensch");
	}
}

public class Hund : Lebewesen
{
	public Hund(int alter) : base(alter)
	{
	}
}