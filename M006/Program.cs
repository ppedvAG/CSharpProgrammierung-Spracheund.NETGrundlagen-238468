using M006.Data;

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		//new Person(): Erstelle ein Objekt aus der Klasse
		//Hier können jetzt konkrete Werte eingefüllt werden
		Person p = new Person();
		//p.vorname = "Max"; //Nicht möglich, da private
		p.SetVorname("Max"); //Zugriff auf das Feld gewähren, aber nur eingeschränkt
        Console.WriteLine(p.GetVorname());

		p.Nachname = "Mustermann"; //Hier ist kein SetNachname erforderlich
        Console.WriteLine(p.Nachname); //Nachname kann wie eine normale Variable benutzt werden

        //p.VollerName = ""; //Read Only
        Console.WriteLine(p.VollerName);



		Person p2 = new Person("Max", "Mustermann"); //Durch den Konstruktor müssen die Werte übergeben werden
        Console.WriteLine(p2.VollerName);

		Person p3 = new Person("Max", "Muster", 20);

		//Namespaces
		//Organisationseinheiten, ermöglichen das Gruppieren von Typen in Pakete
		//Jedes Projekt sollte einen Standardnamespace haben z.B. M006
		//Jeder Namespaces kann nochmal unterteilt werden in weitere Namespaces z.B. M006.Data
		//Nachdem Person jetzt in M006.Data ist, ist sie hier nichtmehr sichtbar -> using
		//using: Importiert alle Typen aus dem gegebenen Namespace
		//Jeder Typ sollte immer in dem Ordner sein der mit seinem Namespace zusammenhängt

		//Beispiele:
		//System: Standarddinge
		//System.IO: Dateienverarbeitung
		//System.Net: Netzwerkbasierte Dinge
		//System.Net.Http: HTTP-basierte Dinge




		//Assozation von Objekten
		//Verschachteln von Objekten in anderen Objekten
		//z.B. Person enthält string
		//string enthält Zeichen (chars)
		//chars sind Zahlen
		Person t = new Person("Lukas", "Kern", 25);
		Person t1 = new Person("", "", 48);
		Person t2 = new Person("", "", 42);
		Person t3 = new Person("", "", 26);
		Kurs k = new Kurs("C# Grundkurs", 4, Kurstyp.Virtuell, t, t1, t2, t3);
		k.PersonenAusgeben();
    }
}