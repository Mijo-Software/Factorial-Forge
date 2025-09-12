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
				BigInteger result = await Task.Run(function: () => Factorializer.FactorialBig(n: (long)numericUpDownFactorial.Value));
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
				BigInteger result = Factorializer.OddFactorialBig(n: (long)numericUpDownOddFactorial.Value);
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
				BigInteger result = Factorializer.EvenFactorialBig(n: (long)numericUpDownEvenFactorial.Value);
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
				BigInteger result = Factorializer.PrimeFactorialBig(n: (long)numericUpDownPrimeFactorial.Value);
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

		private void NumericUpDownSubfactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelTime.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.SubfactorialBig(n: (long)numericUpDownSubfactorial.Value);
				textBoxSubfactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelTime.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownDoubleFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelTime.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.DoubleFactorialBig(n: (long)numericUpDownDoubleFactorial.Value);
				textBoxDoubleFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelTime.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void ButtonCopyToClipboardFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxFactorial.Text))
			{
				Clipboard.SetText(text: textBoxFactorial.Text);
			}
			toolStripStatusLabelTime.Text = "Copied to clipboard.";
		}

		private void ButtonCopyToClipboardOddFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxOddFactorial.Text))
			{
				Clipboard.SetText(text: textBoxOddFactorial.Text);
			}
			toolStripStatusLabelTime.Text = "Copied to clipboard.";
		}

		private void ButtonCopyToClipboardEvenFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxEvenFactorial.Text))
			{
				Clipboard.SetText(text: textBoxEvenFactorial.Text);
			}
			toolStripStatusLabelTime.Text = "Copied to clipboard.";
		}

		private void ButtonCopyToClipboardPrimeFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxPrimeFactorial.Text))
			{
				Clipboard.SetText(text: textBoxPrimeFactorial.Text);
			}
			toolStripStatusLabelTime.Text = "Copied to clipboard.";
		}

		private void ButtonCopyToClipboardSubfactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxSubfactorial.Text))
			{
				Clipboard.SetText(text: textBoxSubfactorial.Text);
			}
			toolStripStatusLabelTime.Text = "Copied to clipboard.";
		}

		private void ButtonCopyToClipboardDoubleFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxDoubleFactorial.Text))
			{
				Clipboard.SetText(text: textBoxDoubleFactorial.Text);
			}
			toolStripStatusLabelTime.Text = "Copied to clipboard.";
		}

		private void ButtonSaveToFileFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxFactorial.Text))
			{
				using SaveFileDialog saveFileDialog = new()
				{
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = "Save Factorial Result"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(path: saveFileDialog.FileName, contents: textBoxFactorial.Text);
						toolStripStatusLabelTime.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}

		private void ButtonSaveToFileOddFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxOddFactorial.Text))
			{
				using SaveFileDialog saveFileDialog = new()
				{
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = "Save Odd Factorial Result"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(path: saveFileDialog.FileName, contents: textBoxOddFactorial.Text);
						toolStripStatusLabelTime.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}

		private void ButtonSaveToFileEvenFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxEvenFactorial.Text))
			{
				using SaveFileDialog saveFileDialog = new()
				{
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = "Save Even Factorial Result"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(path: saveFileDialog.FileName, contents: textBoxEvenFactorial.Text);
						toolStripStatusLabelTime.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}

		private void ButtonSaveToFilePrimeFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxPrimeFactorial.Text))
			{
				using SaveFileDialog saveFileDialog = new()
				{
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = "Save Prime Factorial Result"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(path: saveFileDialog.FileName, contents: textBoxPrimeFactorial.Text);
						toolStripStatusLabelTime.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}

		private void ButtonSaveToFileSubfactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxSubfactorial.Text))
			{
				using SaveFileDialog saveFileDialog = new()
				{
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = "Save Subfactorial Result"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(path: saveFileDialog.FileName, contents: textBoxSubfactorial.Text);
						toolStripStatusLabelTime.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}

		private void ButtonSaveToFileDoubleFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxDoubleFactorial.Text))
			{
				using SaveFileDialog saveFileDialog = new()
				{
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = "Save Double Factorial Result"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(path: saveFileDialog.FileName, contents: textBoxDoubleFactorial.Text);
						toolStripStatusLabelTime.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}
	}
}
