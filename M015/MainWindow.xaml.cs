using System.Windows;
using System.Windows.Controls;

namespace M015;

public partial class MainWindow : Window
{
	public int Counter;

	public MainWindow()
	{
		InitializeComponent();

		CB.ItemsSource = new List<string>() { "T1", "T2", "T3" };
		LB.ItemsSource = new List<string>() { "T1", "T2", "T3", "T4", "T5", "T6" };
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//Events
		//Ermöglichen die Verbindung von GUI und Backend
		//In der GUI wird das Event angehängt an die entsprechende Komponente
		//Im Backend wird dann der Code festgelegt, der bei dem Event passieren soll

		//Counter++;
		//TB.Text = "Zähler: " + Counter;

		//TB.Text = Eingabe.Text;

		Counter++;
		Progress.Value = Counter;
    }

	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//Wenn der User ein Element auswählt, soll dieses in den TextBlock geschrieben werden
		TB.Text = CB.SelectedItem + " ausgewählt";
	}

	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = string.Join(", ", LB.SelectedItems.OfType<string>());
	}

	private void Check_Checked(object sender, RoutedEventArgs e)
	{
		TB.Text = "Check checked";
	}

	private void Check_Unchecked(object sender, RoutedEventArgs e)
	{
		TB.Text = "Check unchecked";
	}

	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		TB.Text = Slide.Value.ToString();
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		DataView dv = new DataView();
		dv.Show();
	}
}