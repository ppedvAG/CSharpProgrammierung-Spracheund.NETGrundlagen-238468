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
    }
}
