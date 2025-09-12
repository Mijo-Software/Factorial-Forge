using System.Numerics;

namespace FactorialForge
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			toolStripProgressBar.Visible = false;
		}

		private async void NumericUpDownFactorial_ValueChanged(object? sender, EventArgs e)
		{
			toolStripProgressBar.Visible = true;
			try
			{
				BigInteger result = await Task.Run(function: () => Factorializer.FactorialBig(n: (int)numericUpDownFactorial.Value));
				textBoxFactorial.Text = $"{(int)numericUpDownFactorial.Value}! = {result}";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownOddFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripProgressBar.Visible = true;
			try
			{
				BigInteger result = Factorializer.OddFactorialBig(n: (int)numericUpDownOddFactorial.Value);
				textBoxOddFactorial.Text = $"{(int)numericUpDownOddFactorial.Value}! = {result}";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}
	}
}
