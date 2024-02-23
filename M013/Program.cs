namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		try //Codeblock markieren -> Rechtsklick -> Snippet -> Surround With -> try(f)
		{
			Console.Write("Gib eine Zahl ein: ");
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exceptions sind die Fehler die auftreten könnten
			int x = int.Parse(eingabe); //3 Exceptions: ArgumentNullException, FormatException, OverflowException
		}
		catch (FormatException) //Hier wird nur die FormatException behandelt (keine Zahl eingegeben)
		{
            Console.WriteLine("Keine Zahl eingegeben");
        }
		catch (OverflowException) //Hier wird nur die OverflowException behandelt
		{
			Console.WriteLine("Zahl zu klein/groß");
		}
		catch (Exception e) //Exceptions sind in einer Vererbungshierarchie zueinander, Exception ist die Oberklasse aller Exceptions
		{
            //Dieser Block fängt alle anderen Fehler
            Console.WriteLine("Anderer Fehler");
            Console.WriteLine(e.Message); //Die C# interne Nachricht
            Console.WriteLine(e.StackTrace); //Ein Logoutput der uns Bescheid gibt, wo der Fehler im Code aufgetreten ist
        }
		finally //Wird immer ausgeführt
		{
            Console.WriteLine("Parsen fertig");
        }


		try
		{
			Fahrzeug f = new Fahrzeug();
			f.Beschleunige(500); //Exception
		}
		catch (ArgumentException e) //Benutzerdefinierte Fehlerbehandlung
		{
			Console.WriteLine(e.Message);
		}
	}

	//public static void ConnectToDB()
	//{
	//	try
	//	{
	//		SqlConnection conn = new SqlConnection("Server=WIN10-LK3;Database=Demo;Trusted_Connection=True;");
	//		conn.Open();
	//	}
	//	catch (SqlException)
	//	{
	//      Console.WriteLine("Verbindung fehlgeschlagen");
	//		//Logger.Log("Verbindung fehlgeschlagen");
	//		//GUI: TextBlock.Text = "Verbindung fehlgeschlagen";
	//	}
	//}

	//static double ZahlEingabe(string text)
	//{
	//	while (true)
	//	{
	//		Console.Write(text);
	//		string zahlInput = Console.ReadLine();
	//		double ergebnis;
	//		try
	//		{
	//			double x = double.Parse(zahlInput);
	//			return x;
	//		}
	//		catch { }
	//	}
	//}
}

public class Fahrzeug
{
	public void Beschleunige(int a)
	{
		if (a > 300)
		{
			//Console.WriteLine("Neue Beschleunigung ist nicht valide");
			throw new ArgumentException("Neue Beschleunigung ist nicht valide");
		}
    }
}