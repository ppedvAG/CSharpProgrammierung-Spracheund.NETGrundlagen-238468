namespace M012;

public static class ExtensionMethods
{
	public static int Quersumme(this int x) //Mit this <Typ> sich auf einen bestimmten Typen beziehen
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x) //Eigene Linq Methode
	{
		return x.OrderBy(e => Random.Shared.Next());
	}
}
