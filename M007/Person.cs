namespace M007;

/// <summary>
/// Klasse: Bauplan für Objekte, hier wird die Struktur der Objekte festgelegt über Variablen, Methoden, ...
/// Objekt: Fertige Datenstruktur die aus einer Klasse erzeugt wird
/// Objekt enthält konkrete Werte, Klasse enthält nur Definitionen
/// 
/// Klassen sind Datentypen
/// Mithilfe von Klassen können komplexe Datenstrukturen dargestellt werden
/// Simple Datentypen: int, double, string, bool, ...
/// Komplexe Datentypen: Person, Kurs, ...
/// </summary>
public class Person
{
	//Eigenschaften: Vorname, Nachname, Alter, ...
	//Funktionen: Sprechen, ...

	#region Variable/Feld
	//Felder sind normale Variablen
	//Felder sollten von außen nicht angreifbar sein, sondern nur über Get-/Set Methoden benutzt werden können
	//Warum? Weil der Benutzer bei direktem Zugriff auf das Feld, alles mit dem Feld machen könnte
	//z.B. Zahlen im Vornamen, ...

	/// <summary>
	/// private: Kann nur innerhalb der Klasse angegriffen werden
	/// </summary>
	private string vorname;

	public void SetVorname(string vorname)
	{
        if (vorname.All(char.IsLetter) && vorname.Length >= 3 && vorname.Length <= 15) //Prüfen, ob der Vorname den der User setzen möchte, valide ist
			this.vorname = vorname; //this: Greife aus der Methode hinaus
		//Hier gibt es den Parameter vorname, und das Feld vorname
		//Mittels this differenzieren welches der beiden Felder gemeint ist
	}

	public string GetVorname()
	{
		return vorname;
	}
	#endregion

	#region Property
	//Property/Eigenschaft: Gibt die Möglichkeit, Get-Set Methoden zu vereinfachen
	private string nachname;

	public string Nachname
	{
		get
		{
			return nachname;
		}
		set
		{
			//Hier gibt es keinen Parameter namens nachname
			//Der Parameter wird im Setter als 'value' bezeichnet
			if (value.All(char.IsLetter) && value.Length >= 3 && value.Length <= 15)
				nachname = value;
		}
	}

	//Drei Arten von Properties
	//Full Property: private Feld und Getter + Setter mit Code (siehe oben)
	//Auto Property: Funktioniert wie ein normales Feld, aber hat bestimmte Vorteile
	//Get-Only Property: Kann nicht beschrieben werden, berechnet nur Werte

	/// <summary>
	/// Auto-Property
	/// Einzelne Accessoren (Get oder Set) können mit einem Access Modifier (private) belegt werden
	/// Verwendung: Json, UI
	/// </summary>
	public int Alter { get; set; }

	public string VollerName
	{
		get
		{
			return vorname + " " + nachname;
		}
	}

	public string VollerName2
	{
		get => vorname + " " + nachname;
	}

	public string VollerName3 => vorname + " " + nachname;
	#endregion

	#region Konstruktor
	/// <summary>
	/// Konstruktor: Code der bei Erstellung (new) des Objekts ausgeführt wird
	/// Standardkonstruktor existiert immer, es sei denn er wird überschrieben
	/// </summary>
	public Person()
	{
		Console.WriteLine("Person wurde erstellt");
		Zaehler++;
	}

	/// <summary>
	/// Hier wird der Standardkonstruktor gelöscht
	/// Bei Erstellung einer Person muss vorname und nachname angegeben werden
	/// </summary>
	public Person(string vorname, string nachname) : this()
	{
		this.vorname = vorname;
		this.nachname = nachname;
	}

	/// <summary>
	/// Konstruktoren verketten:
	/// Wenn dieser Konstruktor ausgeführt wird, wird der Konstruktor darüber in der Kette auch ausgeführt
	/// Über die Parameter in this(...) wird der Konstruktor ausgewählt der verkettet werden soll
	/// </summary>
	public Person(string vorname, string nachname, int alter) : this(vorname, nachname)
	{
		//this.vorname = vorname;
		//this.nachname = nachname;
		this.Alter = alter;
	}
	#endregion

	public static int Zaehler { get; set; }
}