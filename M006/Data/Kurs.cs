namespace M006.Data;

public class Kurs
{
	//Felder: Teilnehmer, Trainer, Titel, Dauer, Kurstyp
	//Methoden: TeilnehmerHinzufügen, PersonenAusgeben
	//Konstruktor: Alle Felder + beliebig viele Teilnehmer

	public string Titel { get; private set; }

	public int Dauer { get; set; }

	public Kurstyp Typ { get; private set; }

	public Person Trainer { get; set; }

	public Person[] Teilnehmer { get; private set; }

	//Strg + . -> Generate Constructor
	public Kurs(string titel, int dauer, Kurstyp typ, Person trainer, params Person[] teilnehmer)
	{
		Titel = titel;
		Dauer = dauer;
		Typ = typ;
		Trainer = trainer;
		Teilnehmer = teilnehmer;
	}

	public void TeilnehmerHinzufuegen(params Person[] p)
	{
		Teilnehmer = Teilnehmer.Concat(p).ToArray();
	}

	public void PersonenAusgeben()
	{
        Console.WriteLine($"Trainer: {Trainer.VollerName}");
		for (int i = 0;  i < Teilnehmer.Length; i++)
			Console.WriteLine($"Teilnehmer {i + 1}: {Teilnehmer[i].VollerName}");
	}
}