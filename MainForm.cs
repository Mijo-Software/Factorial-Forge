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

		private async Task CalculateAndDisplayAsync(Func<BigInteger> calculation, TextBox targetTextBox)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = await Task.Run(function: calculation);
				targetTextBox.Text = $"{result}";
				watch.Stop();
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		private void CopyToClipboard(TextBox sourceTextBox)
		{
			if (!string.IsNullOrWhiteSpace(value: sourceTextBox.Text))
			{
				try
				{
					Clipboard.SetText(sourceTextBox.Text);
					toolStripStatusLabelInfo.Text = "Copied to clipboard.";
				}
				catch (System.Runtime.InteropServices.ExternalException)
				{
					_ = MessageBox.Show(text: "The clipboard could not be accessed. Please try again.", caption: "Clipboard Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					_ = MessageBox.Show(text: $"Error copying to clipboard: {ex.Message}");
				}
			}
		}

		private void SaveToFile(TextBox sourceTextBox, string title)
		{
			if (!string.IsNullOrWhiteSpace(value: sourceTextBox.Text))
			{
				using SaveFileDialog saveFileDialog = new()
				{
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = title
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(path: saveFileDialog.FileName, contents: sourceTextBox.Text);
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					catch (Exception ex)
					{
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}");
					}
				}
			}
		}

		private static void ShowDigitStatistics(TextBox sourceTextBox, string errorMessage)
		{
			if (!string.IsNullOrWhiteSpace(value: sourceTextBox.Text))
			{
				CountDigits(input: sourceTextBox.Text);
			}
			else
			{
				_ = MessageBox.Show(text: errorMessage, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
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
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.FactorialBig(n: (long)numericUpDownFactorial.Value),
				targetTextBox: textBoxFactorial
			);
		}

		private async void NumericUpDownOddFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.OddFactorialBig(n: (long)numericUpDownOddFactorial.Value),
				targetTextBox: textBoxOddFactorial
			);
		}

		private async void NumericUpDownEvenFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.EvenFactorialBig(n: (long)numericUpDownEvenFactorial.Value),
				targetTextBox: textBoxEvenFactorial
			);
		}

		private async void NumericUpDownPrimeFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.PrimeFactorialBig(n: (long)numericUpDownPrimeFactorial.Value),
				targetTextBox: textBoxPrimeFactorial
			);
		}

		private async void NumericUpDownSubfactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.SubfactorialBig(n: (long)numericUpDownSubfactorial.Value),
				targetTextBox: textBoxSubfactorial
			);
		}

		private async void NumericUpDownDoubleFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.DoubleFactorialBig(n: (long)numericUpDownDoubleFactorial.Value),
				targetTextBox: textBoxDoubleFactorial
			);
		}

		private void ButtonCopyToClipboardFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxFactorial);

		private void ButtonCopyToClipboardOddFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxOddFactorial);

		private void ButtonCopyToClipboardEvenFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxEvenFactorial);

		private void ButtonCopyToClipboardPrimeFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxPrimeFactorial);

		private void ButtonCopyToClipboardSubfactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxSubfactorial);

		private void ButtonCopyToClipboardDoubleFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxDoubleFactorial);

		private void ButtonSaveToFileFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxFactorial, title: "Save Factorial Result");

		private void ButtonSaveToFileOddFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxOddFactorial, title: "Save Odd Factorial Result");

		private void ButtonSaveToFileEvenFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxEvenFactorial, title: "Save Even Factorial Result");

		private void ButtonSaveToFilePrimeFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxPrimeFactorial, title: "Save Prime Factorial Result");

		private void ButtonSaveToFileSubfactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxSubfactorial, title: "Save Subfactorial Result");

		private void ButtonSaveToFileDoubleFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxDoubleFactorial, title: "Save Double Factorial Result");

		private void ButtonDigitStatisticsFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxFactorial, errorMessage: "No factorial result to analyze.");

		private void ButtonDigitStatisticsOddFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxOddFactorial, errorMessage: "No odd factorial result to analyze.");

		private void ButtonDigitStatisticsEvenFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxEvenFactorial, errorMessage: "No even factorial result to analyze.");

		private void ButtonDigitStatisticsPrimeFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxPrimeFactorial, errorMessage: "No prime factorial result to analyze.");

		private void ButtonDigitStatisticsSubfactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxSubfactorial, errorMessage: "No subfactorial result to analyze.");

		private void ButtonDigitFactorialDoubleFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxDoubleFactorial, errorMessage: "No double factorial result to analyze.");
	}
}
