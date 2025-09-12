using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace FactorialForge
{
	public partial class MainForm : Form
	{
		private readonly Stopwatch watch = new();

		private static void CountDigits(string input)
		{
			int[] counts = new int[10];

			foreach (char c in input)
			{
				if (char.IsDigit(c: c))
				{
					int digit = c - '0';
					counts[digit]++;
				}
			}

			StringBuilder sb = new();
			for (int i = 0; i < counts.Length; i++)
			{
				_ = sb.AppendLine(value: $"{i}: {counts[i]}");
			}

			_ = MessageBox.Show(text: sb.ToString(), caption: "Digit statistics", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
		}

		public MainForm()
		{
			InitializeComponent();
			watch.Start();
			watch.Stop();
			toolStripProgressBar.Visible = false;
			toolStripStatusLabelInfo.Text = $"Ready at {DateTime.Now:T}";
		}

		private async void NumericUpDownFactorial_ValueChanged(object? sender, EventArgs e)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = await Task.Run(function: () => Factorializer.FactorialBig(n: (long)numericUpDownFactorial.Value));
				textBoxFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownOddFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.OddFactorialBig(n: (long)numericUpDownOddFactorial.Value);
				textBoxOddFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownEvenFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.EvenFactorialBig(n: (long)numericUpDownEvenFactorial.Value);
				textBoxEvenFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownPrimeFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.PrimeFactorialBig(n: (long)numericUpDownPrimeFactorial.Value);
				textBoxPrimeFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;

		}

		private void NumericUpDownSubfactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.SubfactorialBig(n: (long)numericUpDownSubfactorial.Value);
				textBoxSubfactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void NumericUpDownDoubleFactorial_ValueChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = Factorializer.DoubleFactorialBig(n: (long)numericUpDownDoubleFactorial.Value);
				textBoxDoubleFactorial.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
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
				toolStripStatusLabelInfo.Text = "Copied to clipboard.";
			}
		}

		private void ButtonCopyToClipboardOddFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxOddFactorial.Text))
			{
				Clipboard.SetText(text: textBoxOddFactorial.Text);
				toolStripStatusLabelInfo.Text = "Copied to clipboard.";
			}
		}

		private void ButtonCopyToClipboardEvenFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxEvenFactorial.Text))
			{
				Clipboard.SetText(text: textBoxEvenFactorial.Text);
				toolStripStatusLabelInfo.Text = "Copied to clipboard.";
			}
		}

		private void ButtonCopyToClipboardPrimeFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxPrimeFactorial.Text))
			{
				Clipboard.SetText(text: textBoxPrimeFactorial.Text);
				toolStripStatusLabelInfo.Text = "Copied to clipboard.";
			}
		}

		private void ButtonCopyToClipboardSubfactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxSubfactorial.Text))
			{
				Clipboard.SetText(text: textBoxSubfactorial.Text);
				toolStripStatusLabelInfo.Text = "Copied to clipboard.";
			}
		}

		private void ButtonCopyToClipboardDoubleFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxDoubleFactorial.Text))
			{
				Clipboard.SetText(text: textBoxDoubleFactorial.Text);
				toolStripStatusLabelInfo.Text = "Copied to clipboard.";
			}
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
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
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
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
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
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
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
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
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
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
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
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}

		private void ButtonDigitStatisticsFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxFactorial.Text))
			{
				CountDigits(input: textBoxFactorial.Text);
			}
			else
			{
				_ = MessageBox.Show(text: "No factorial result to analyze.", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}

		private void ButtonDigitStatisticsOddFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxOddFactorial.Text))
			{
				CountDigits(input: textBoxOddFactorial.Text);
			}
			else
			{
				_ = MessageBox.Show(text: "No odd factorial result to analyze.", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}

		private void ButtonDigitStatisticsEvenFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxEvenFactorial.Text))
			{
				CountDigits(input: textBoxEvenFactorial.Text);
			}
			else
			{
				_ = MessageBox.Show(text: "No even factorial result to analyze.", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}

		private void ButtonDigitStatisticsPrimeFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxPrimeFactorial.Text))
			{
				CountDigits(input: textBoxPrimeFactorial.Text);
			}
			else
			{
				_ = MessageBox.Show(text: "No prime factorial result to analyze.", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}

		private void ButtonDigitStatisticsSubfactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxSubfactorial.Text))
			{
				CountDigits(input: textBoxSubfactorial.Text);
			}
			else
			{
				_ = MessageBox.Show(text: "No subfactorial result to analyze.", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}

		private void ButtonDigitFactorialDoubleFactorial_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(value: textBoxDoubleFactorial.Text))
			{
				CountDigits(input: textBoxDoubleFactorial.Text);
			}
			else
			{
				_ = MessageBox.Show(text: "No double factorial result to analyze.", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}
	}
}
