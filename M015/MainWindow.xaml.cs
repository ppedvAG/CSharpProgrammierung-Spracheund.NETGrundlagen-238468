using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M015;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		try
		{
			Fahrzeug f = new Fahrzeug();
			f.Beschleunige(500);
		}
		catch (ArgumentException e)
		{
			TB.Text = e.Message;
		}
	}
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