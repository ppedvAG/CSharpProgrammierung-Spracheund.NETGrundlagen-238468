namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		#region Polymorphismus
		//Polymorphismus
		//Typkompatibilität
		//Welche Typen sind mit welchen anderen Typen kompatibel?

		//Ein Objekt ist immer mit sich selbst oder einer Oberklasse kompatibel
		Mensch m = new Mensch();

		Lebewesen l = new Mensch();
		l = new Hund();

		//Jeder Typ in C# ist ein object
		//-> Jedes Objekt ist mit einer Variable vom Typ object kompatibel
		object o = new object();
		o = new Mensch();
		o = new Lebewesen();
		o = 123;
		o = true;
		o = "Hallo";

		Test(new Mensch());
		Test(123);
		Test("Hallo");

		PrintLebewesen(new Lebewesen());
		PrintLebewesen(new Mensch());
		PrintLebewesen(new Hund());
		#endregion

		#region Typen
		//Typ
		//Jede Klasse/Struct/Enum/Interface/... stellt einen Typen dar
		//z.B. Lebewesen ist ein Typ, object ist ein Typ, Wochentag (enum) ist auch ein Typ

		//Zwei Möglichkeiten um an ein Typ Objekt zu kommen

		//Typ über Objekt holen
		Type mt = m.GetType();

		//Typ über Klassenname holen
		Type tt = typeof(Mensch);

        Console.WriteLine(mt.Name); //Mensch
		#endregion

		#region Typvergleiche
		object x = new Mensch();
		//Wie kann ich zur Laufzeit herausfinden, was für ein Objekt hinter x steckt?

		//Genauer Typvergleich
		if (x.GetType() == typeof(Mensch))
		{
			//Ist x genau ein Mensch (und keine Unterklasse)?
			//true
		}

		if (x.GetType() == typeof(Lebewesen))
		{
			//Ist x genau ein Lebewesen (und keine Unterklasse)?
			//false
		}

		//Vererbungshiearchietypvergleich
		if (x is Mensch)
		{
			//Ist x ein Mensch oder eine Unterklasse von Mensch?
			//true
		}

		if (x is Lebewesen)
		{
			//Ist x ein Lebewesen oder eine Unterklasse von Lebewesen?
			//true
		}

		if (x is object)
		{
			//Ist x ein object oder eine Unterklasse von object?
			//true
		}
		#endregion

		#region Beispiel
		Lebewesen[] zoo = new Lebewesen[5]; //Dieses Array kann alle Lebewesen enthalten
		zoo[0] = new Mensch();
		//zoo[1] = new Lebewesen();
		zoo[2] = new Katze();
		zoo[3] = new Hund();
		zoo[4] = new Hund();

		foreach (Lebewesen lw in zoo)
		{
			if (lw is Mensch) //Per Typvergleich prüfen, ob das derzeitige Objekt ein Mensch ist
			{
				Mensch mensch = (Mensch) lw;
				//Nachdem wir hier im Code sind, hat der Typvergleich in der if true ergeben
				//Dementsprechend ist lw ein Mensch
				//Per Cast können wir jetzt das Lebewesen ansprechen und auf die Menschspezifischen Eigenschaften zugreifen
				Console.WriteLine(mensch.Adresse);
				mensch.Sprechen();
			}

			if (lw is Katze)
			{
				Katze k = (Katze) lw;
				k.Miau();
			}

			lw.WasBinIch(); //Durch abstract wissen wir, das jede Unterklasse diese Methode hat
        }
		#endregion
	}

	/// <summary>
	/// Diese Methode kann über den object Parameter alles empfangen
	/// </summary>
	public static void Test(object o) { }

	/// <summary>
	/// Diese Methode kann beliebige Objekte zurückgeben
	/// </summary>
	public static object Test()
	{
		return new Mensch();
		return 123;
		return "Hallo";
	}

	/// <summary>
	/// Hier können alle Lebewesen übergeben werden (Lebewesen, Mensch, Hund)
	/// </summary>
	public static void PrintLebewesen(Lebewesen l) { }
}

/// <summary>
/// abstract: Definiert, das diese Klasse nur eine Strukturklasse darstellt
/// Die Klasse definiert nur Member (Methoden, Properties, Konstruktoren, ...) und zwingt die Unterklassen eine Implementation zu machen
/// Von dieser Klasse können jetzt keine Objekte mehr erstellt werden (nurnoch von den Unterklassen)
/// </summary>
public abstract class Lebewesen
{
	/// <summary>
	/// Diese Methode hat keinen Body -> Unterklassen müssen eine Implementation haben
	/// </summary>
	public abstract void WasBinIch();
}

public class Mensch : Lebewesen
{
	public string Adresse { get; set; }

	public void Sprechen() { }

	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Mensch");
    }
}

public class Hund : Lebewesen
{
	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Hund");
    }
}

public class Katze : Lebewesen
{
	public void Miau() { }

	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin eine Katze");
    }
}