namespace FactorialForge
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			NumericUpDownFactorial_ValueChanged(sender: null, e: EventArgs.Empty);
		}

		private void NumericUpDownFactorial_ValueChanged(object? sender, EventArgs e)
		{
			labelFactorial.Text = $"Factorial: {Factorializer.Factorial(n: (int)numericUpDownFactorial.Value)}";
		}
	}
}
