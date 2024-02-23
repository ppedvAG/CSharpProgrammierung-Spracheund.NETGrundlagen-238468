using M013;

namespace M013_Tests;

[TestClass]
public class RechnerTests
{
	//View -> Test Explorer

	//Rechtsklick auf Projekt -> Add Project Reference -> Projekt auswählen -> OK

	Rechner r;

	[TestInitialize]
	public void Setup()
	{
		r = new Rechner();
	}

	[TestCleanup]
	public void Cleanup()
	{
		r = null;
	}

	[TestMethod]
	[TestCategory("Addiere")]
	public void TesteAddiere()
	{
		double ergebnis = r.Addiere(4, 5);

		//Assert Klasse: Gibt die Möglichkeit, Testergebnisse zu erzeugen
		Assert.AreEqual(9, ergebnis);
	}

	[TestMethod]
	[TestCategory("Subtrahiere")]
	public void TesteSubtrahiere()
	{
		double ergebnis = r.Subtrahiere(4, 5);

		//Assert Klasse: Gibt die Möglichkeit, Testergebnisse zu erzeugen
		Assert.AreEqual(-1, ergebnis);
	}
}