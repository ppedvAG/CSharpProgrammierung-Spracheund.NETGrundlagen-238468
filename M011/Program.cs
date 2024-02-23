using System.Net.Http.Headers;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generische Datentypen (Generic)
		//Gibt die Möglichkeit, eine Klasse/Methode zu definieren, die zur Erstellung noch keinen fixen Typen hat
		//Bei der Instanzierung wird dann ein fixer Typ benötigt
		//Wird generell als T bezeichnet

		//List: Funktioniert wie Array, ist aber beliebig groß/passt ihre Größe auf die Elemente an
		List<int> ints = new List<int>();
		ints.Add(1); //Add(T item) wird zu Add(int item)
		ints.Add(2); //Add(T item) wird zu Add(int item)
		ints.Add(3); //Add(T item) wird zu Add(int item)
		ints.Add(4); //Add(T item) wird zu Add(int item)

		foreach (int i in ints) //Schleife wie bei Array
		{
            Console.WriteLine(i);
        }

		ints.Remove(3); //Keine leeren Elemente/Elemente werden aufgeschoben

		Console.WriteLine(ints[1]); //Index wie bei Array

		List<string> strings = new List<string>();
		strings.Add("A"); //T wird zu string

		Console.WriteLine(ints.Count); //Anzahl der Elemente mit Count statt Length

		/////////////////////////////////////////////////////////////////////////////////

		//Dictionary: Liste von Schlüssel-Wert Paaren
		Dictionary<string, int> einwohnerzahlen = new(); //Target-Typed new: Ergänzt den Typen bei new() von Links
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);

		Console.WriteLine(einwohnerzahlen["Wien"]); //Holt den Wert hinter dem gegebenen Key

		//var: Ergänzt den Typen anhand des Objekts
		//Strg + . -> Use explicit type instead of var -> KeyValuePair<string, int>
		foreach (KeyValuePair<string, int> kv in einwohnerzahlen)
		{
            Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
        }

		//einwohnerzahlen.Add("Paris", 2_160_000); //Der selbe Key darf nicht zwei mal existieren
		if (!einwohnerzahlen.ContainsKey("Paris")) //Vorher prüfen, ob der Key bereits existiert
			einwohnerzahlen.Add("Paris", 2_160_000);

        Console.WriteLine(einwohnerzahlen.Keys); //Keys separat entnehmen
		Console.WriteLine(einwohnerzahlen.Values); //Values separat entnehmen

        Console.WriteLine(einwohnerzahlen.Count); //Anzahl der Elemente
    }
}
