using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;

namespace M014;

internal class Program
{
	static void Main(string[] args)
	{
		//NuGet-Packages: Externe Pakete, die zum Projekt hinzugefügt werden können
		//Tools -> NuGet Package Manager -> Manage NuGet Packages
		//Paket + Projekt auswählen -> Install

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

		//Newtonsoft.Json
		//string json = JsonConvert.SerializeObject(fahrzeuge);
		//File.WriteAllText("Test.json", json);

		//string readJson = File.ReadAllText("Test.json");
		//Fahrzeug[] readFzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson);

		//System.Text.Json
		string json = JsonSerializer.Serialize(fahrzeuge);
		File.WriteAllText("Test.json", json);

		string readJson = File.ReadAllText("Test.json");
		Fahrzeug[] readFzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson);

		//XML
		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		StreamWriter sw = new StreamWriter("Test.xml");
		xml.Serialize(sw, fahrzeuge);
		sw.Close();

		StreamReader sr = new StreamReader("Test.xml");
		List<Fahrzeug> fzg = (List<Fahrzeug>) xml.Deserialize(sr);
	}

	public static void Intro()
	{
		//Drei wichtige Klassen: File, Directory, Path

		//Pfad zu einem Ordner + Pfad zu einer Datei
		//Den Ordner erstellen, die Datei beschreiben
		string folderPath = "Test";
		string filePath = Path.Combine(folderPath, "M014.txt"); //Hier werden noch keine Dateien/Ordner erstellt

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//Stream: Pipeline zu einer externen Resource
		//z.B.: Datei, DB, Webschnittstelle, ...

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.Flush();
		sw.Close(); //Streams müssen per Hand geschlossen werden

		using (StreamWriter sw2 = new StreamWriter(filePath))
		{
			sw.WriteLine("Test1");
			sw.WriteLine("Test2");
			sw.WriteLine("Test3");
		} //Hier wird automatisch .Dispose() aufgerufen

		//using-Statement: Schließt den Stream am Ende der Methode automatisch
		using StreamWriter sw3 = new(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");

		using StreamReader sr = new(filePath);

		//string alles = sr.ReadToEnd();

		List<string> lines = new();
		while (!sr.EndOfStream)
			lines.Add(sr.ReadLine());

		//Kurze Dateimethoden:
		File.ReadAllText(filePath);
		File.ReadAllLines(filePath);

		File.WriteAllText(filePath, "Test");
		File.WriteAllLines(filePath, lines);
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}

    public Fahrzeug()
    {
        
    }
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}