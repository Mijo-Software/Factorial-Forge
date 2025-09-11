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
			textBoxFactorial.Text = $"Factorial: {Factorializer.FactorialBig(n: (int)numericUpDownFactorial.Value)}";
		}
	}
}
