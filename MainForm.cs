using System.Diagnostics;
using System.Numerics;

namespace FactorialForge
{
	public partial class MainForm : Form
	{
		private readonly Stopwatch watch = new();

		public MainForm()
		{
			InitializeComponent();
			watch.Start();
			watch.Stop();
			toolStripProgressBar.Visible = false;
			toolStripStatusLabelTime.Text = $"Ready at {DateTime.Now:T}";
		}

		private async void NumericUpDownFactorial_ValueChanged(object? sender, EventArgs e)
		{
			toolStripStatusLabelTime.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = await Task.Run(function: () => Factorializer.FactorialBig(n: (int)numericUpDownFactorial.Value));
				textBoxFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelTime.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownOddFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelTime.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.OddFactorialBig(n: (int)numericUpDownOddFactorial.Value);
				textBoxOddFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelTime.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownEvenFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelTime.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.EvenFactorialBig(n: (int)numericUpDownEvenFactorial.Value);
				textBoxEvenFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelTime.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownPrimeFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelTime.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.PrimeFactorialBig(n: (int)numericUpDownPrimeFactorial.Value);
				textBoxPrimeFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelTime.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;

		}
	}
}
