using M015.Models;
using System.Diagnostics;
using System.Windows;

namespace M015;

public partial class DataView : Window
{
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

	NorthwindContext context = new NorthwindContext();

	public DataView()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		DG.ItemsSource = fahrzeuge;
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		//Entity Framework
		//Übernimmt für uns das Erzeugen von SQL-Statements + das Erzeugen von Objekten aus Datensätzen

		//NuGet-Pakete
		//Microsoft.EFCore
		//Entsprechenden DB Treiber (z.B. Microsoft.EFCore.SqlServer)

		//Extension: EF Core Power Tools
		//NuGet-Pakete:
		//Microsoft.EFCore.Design
		//Microsoft.EFCore.Tools

		//Rechtsklick aufs Projekt -> EF Core Power Tools -> Reverse Engineer

		//Neuer Models Ordner mit einer C# Klasse für jede Datenbank Tabelle
		//+ Die Context Klasse
		//Diese Klasse ermöglicht den DB Zugriff (SELECT, INSERT, ...)

		List<Order> orders = context.Orders.Where(e => e.Freight >= 50).ToList(); //SELECT * FROM Orders WHERE freight > 50
		//Die Datenbank gibt die Datensätze zurück, und EF übersetzt das ganze in C# Objekte
		DG.ItemsSource = orders;
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
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}