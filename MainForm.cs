using System.Diagnostics;
using System.Numerics;
using System.Text;

/// <summary>
/// The FactorialForge namespace contains classes and logic for advanced factorial calculations,
/// digit statistics analysis, and user interface components for displaying and exporting results.
/// </summary>
namespace FactorialForge
{
	/// <summary>
	/// Main application form for FactorialForge.
	/// Provides UI and logic for calculating, displaying, and exporting various types of factorials and their digit statistics.
	/// Handles user interactions, asynchronous calculations, clipboard operations, and file saving.
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Stopwatch instance used to measure the duration of factorial calculations and update the status bar.
		/// </summary>
		private readonly Stopwatch watch = new();

		/// <summary>
		/// Analyzes the digit frequency in the given input string.
		/// Counts the occurrences of each digit (0-9) and displays the statistics in a message box.
		/// Non-digit characters are ignored.
		/// </summary>
		/// <param name="input">The string to analyze for digit frequency.</param>
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

		/// <summary>
		/// Executes a factorial-related calculation asynchronously and displays the result in the specified textbox.
		/// Updates the status bar and progress bar during calculation.
		/// Shows an error message if the calculation fails.
		/// </summary>
		/// <param name="calculation">A delegate that performs the calculation and returns a BigInteger result.</param>
		/// <param name="targetTextBox">The textbox where the result will be displayed.</param>
		/// <returns>A Task representing the asynchronous operation.</returns>
		private async Task CalculateAndDisplayAsync(Func<BigInteger> calculation, TextBox targetTextBox)
		{
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			try
			{
				watch.Restart();
				BigInteger result = await Task.Run(function: calculation);
				watch.Stop();
				targetTextBox.Text = $"{result}";
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			catch (Exception ex)
			{
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			toolStripProgressBar.Visible = false;
		}

		/// <summary>
		/// Copies the text from the specified textbox to the clipboard.
		/// Updates the status bar to indicate success.
		/// Displays an error message if copying fails or if the textbox is empty.
		/// </summary>
		/// <param name="sourceTextBox">The textbox containing the text to copy.</param>
		private void CopyToClipboard(TextBox sourceTextBox)
		{
			if (!string.IsNullOrWhiteSpace(value: sourceTextBox.Text))
			{
				try
				{
					Clipboard.SetText(sourceTextBox.Text);
					toolStripStatusLabelInfo.Text = "Copied to clipboard.";
				}
				catch (Exception ex)
				{
					_ = MessageBox.Show(text: $"Error copying to clipboard: {ex.Message}", caption: "Clipboard Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Saves the text from the specified textbox to a file using a SaveFileDialog.
		/// Sets the dialog title and file filter as specified.
		/// Updates the status bar on success and shows an error message if saving fails or if the textbox is empty.
		/// </summary>
		/// <param name="sourceTextBox">The textbox containing the text to save.</param>
		/// <param name="title">The title for the SaveFileDialog window.</param>
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

		/// <summary>
		/// Displays digit frequency statistics for the text in the specified textbox.
		/// If the textbox is empty, shows the provided error message in a message box.
		/// Otherwise, analyzes and displays the digit statistics using CountDigits.
		/// </summary>
		/// <param name="sourceTextBox">The textbox containing the text to analyze.</param>
		/// <param name="errorMessage">The error message to display if the textbox is empty.</param>
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

		/// <summary>
		/// Initializes a new instance of the MainForm class.
		/// Sets up the UI components, initializes the stopwatch, and updates the status bar to indicate readiness.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			watch.Start();
			watch.Stop();
			toolStripProgressBar.Visible = false;
			toolStripStatusLabelInfo.Text = $"Ready at {DateTime.Now:T}";
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownFactorial control.
		/// Calculates the factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownFactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownFactorial_ValueChanged(object? sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.FactorialBig(n: (long)numericUpDownFactorial.Value),
				targetTextBox: textBoxFactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownOddFactorial control.
		/// Calculates the odd factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownOddFactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownOddFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.OddFactorialBig(n: (long)numericUpDownOddFactorial.Value),
				targetTextBox: textBoxOddFactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownEvenFactorial control.
		/// Calculates the even factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownEvenFactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownEvenFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.EvenFactorialBig(n: (long)numericUpDownEvenFactorial.Value),
				targetTextBox: textBoxEvenFactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownPrimeFactorial control.
		/// Calculates the prime factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownPrimeFactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownPrimeFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.PrimeFactorialBig(n: (long)numericUpDownPrimeFactorial.Value),
				targetTextBox: textBoxPrimeFactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownSubfactorial control.
		/// Calculates the subfactorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownSubfactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownSubfactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.SubfactorialBig(n: (long)numericUpDownSubfactorial.Value),
				targetTextBox: textBoxSubfactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownDoubleFactorial control.
		/// Calculates the double factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownDoubleFactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownDoubleFactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.DoubleFactorialBig(n: (long)numericUpDownDoubleFactorial.Value),
				targetTextBox: textBoxDoubleFactorial
			);
		}
		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownRisingFactorialX control.
		/// Calculates the rising factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownRisingFactorialX).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownRisingFactorialX_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.RisingFactorialBig(x: (long)numericUpDownRisingFactorialX.Value,
				n: (long)numericUpDownRisingFactorialN.Value),
				targetTextBox: textBoxRisingFactorial
			);
		}
		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownFallingFactorialX control.
		/// Calculates the falling factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownFallingFactorialX).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownFallingFactorialX_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.FallingFactorialBig(x: (long)numericUpDownFallingFactorialX.Value,
				n: (long)numericUpDownFallingFactorialN.Value),
				targetTextBox: textBoxFallingFactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownRisingFactorialN control.
		/// Triggers the calculation and display logic for the rising factorial by delegating to NumericUpDownRisingFactorialX_ValueChanged.
		/// Ensures that changes to either parameter (X or N) update the result.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownRisingFactorialN).</param>
		/// <param name="e">The event data.</param>
		private void NumericUpDownRisingFactorialN_ValueChanged(object sender, EventArgs e)
			=> NumericUpDownRisingFactorialX_ValueChanged(sender: sender, e: e);

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownFallingFactorialN control.
		/// Triggers the calculation and display logic for the falling factorial by delegating to NumericUpDownFallingFactorialX_ValueChanged.
		/// Ensures that changes to either parameter (X or N) update the result.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownFallingFactorialN).</param>
		/// <param name="e">The event data.</param>
		private void NumericUpDownFallingFactorialN_ValueChanged(object sender, EventArgs e)
			=> NumericUpDownFallingFactorialX_ValueChanged(sender: sender, e: e);

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownMultiFactorialX control.
		/// Calculates the multi-factorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownMultiFactorialX).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownMultiFactorialX_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.MultiFactorialBig(x: (long)numericUpDownMultiFactorialX.Value,
				n: (long)numericUpDownMultiFactorialN.Value),
				targetTextBox: textBoxMultiFactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownMultiFactorialN control.
		/// Triggers the calculation and display logic for the multi factorial by delegating to NumericUpDownMultiFactorialX_ValueChanged.
		/// Ensures that changes to either parameter (X or N) update the result.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownMultiFactorialN).</param>
		/// <param name="e">The event data.</param>
		private void NumericUpDownMultiFactorialN_ValueChanged(object sender, EventArgs e)
			=> NumericUpDownMultiFactorialX_ValueChanged(sender: sender, e: e);

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownSuperfactorial control.
		/// Calculates the superfactorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownSuperfactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownSuperfactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.SuperfactorialBig(n: (long)numericUpDownSuperfactorial.Value),
				targetTextBox: textBoxSuperfactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownHyperfactorial control.
		/// Calculates the hyperfactorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownHyperfactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownHyperfactorial_ValueChanged(object sender, EventArgs e)
		{
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.HyperfactorialBig(n: (long)numericUpDownHyperfactorial.Value),
				targetTextBox: textBoxHyperfactorial
			);
		}

		/// <summary>
		/// Handles the click event for the "Copy Factorial Result to Clipboard" button.
		/// Copies the current factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Odd Factorial Result to Clipboard" button.
		/// Copies the current odd factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardOddFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxOddFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Even Factorial Result to Clipboard" button.
		/// Copies the current even factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardEvenFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxEvenFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Prime Factorial Result to Clipboard" button.
		/// Copies the current prime factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardPrimeFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxPrimeFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Subfactorial Result to Clipboard" button.
		/// Copies the current subfactorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardSubfactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxSubfactorial);

		/// <summary>
		/// Handles the click event for the "Copy Double Factorial Result to Clipboard" button.
		/// Copies the current double factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardDoubleFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxDoubleFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Rising Factorial Result to Clipboard" button.
		/// Copies the current rising factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardRisingFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxRisingFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Falling Factorial Result to Clipboard" button.
		/// Copies the current falling factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardFallingFactorial_Click(object sender, EventArgs e)
			 => CopyToClipboard(sourceTextBox: textBoxFallingFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Multi Factorial Result to Clipboard" button.
		/// Copies the current multi factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardMultiFactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxMultiFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Superfactorial Result to Clipboard" button.
		/// Copies the current superfactorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardSuperfactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxSuperfactorial);

		/// <summary>
		/// Handles the click event for the "Copy Hyperfactorial Result to Clipboard" button.
		/// Copies the current hyperfactorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardHyperfactorial_Click(object sender, EventArgs e)
			=> CopyToClipboard(sourceTextBox: textBoxHyperfactorial);

		/// <summary>
		/// Handles the click event for the "Save Factorial Result" button.
		/// Opens a SaveFileDialog to save the current factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxFactorial, title: "Save Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Odd Factorial Result" button.
		/// Opens a SaveFileDialog to save the current odd factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileOddFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxOddFactorial, title: "Save Odd Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Even Factorial Result" button.
		/// Opens a SaveFileDialog to save the current even factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileEvenFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxEvenFactorial, title: "Save Even Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Prime Factorial Result" button.
		/// Opens a SaveFileDialog to save the current prime factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>

		private void ButtonSaveToFilePrimeFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxPrimeFactorial, title: "Save Prime Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Subfactorial Result" button.
		/// Opens a SaveFileDialog to save the current subfactorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileSubfactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxSubfactorial, title: "Save Subfactorial Result");

		/// <summary>
		/// Handles the click event for the "Save Double Factorial Result" button.
		/// Opens a SaveFileDialog to save the current double factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileDoubleFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxDoubleFactorial, title: "Save Double Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Rising Factorial Result" button.
		/// Opens a SaveFileDialog to save the current rising factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileRisingFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxRisingFactorial, title: "Save Rising Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Falling Factorial Result" button.
		/// Opens a SaveFileDialog to save the current falling factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileFallingFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxFallingFactorial, title: "Save Falling Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Multi Factorial Result" button.
		/// Opens a SaveFileDialog to save the current multi factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileMultiFactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxMultiFactorial, title: "Save Multi Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Superfactorial Result" button.
		/// Opens a SaveFileDialog to save the current superfactorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileSuperfactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxSuperfactorial, title: "Save Superfactorial Result");

		/// <summary>
		/// Handles the click event for the "Save Hyperfactorial Result" button.
		/// Opens a SaveFileDialog to save the current hyperfactorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileHyperfactorial_Click(object sender, EventArgs e)
			=> SaveToFile(sourceTextBox: textBoxHyperfactorial, title: "Save Hyperfactorial Result");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Factorial)" button.
		/// Shows a digit frequency analysis for the current factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxFactorial, errorMessage: "No factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Odd Factorial)" button.
		/// Shows a digit frequency analysis for the current odd factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsOddFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxOddFactorial, errorMessage: "No odd factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Even Factorial)" button.
		/// Shows a digit frequency analysis for the current even factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsEvenFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxEvenFactorial, errorMessage: "No even factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Prime Factorial)" button.
		/// Shows a digit frequency analysis for the current prime factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsPrimeFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxPrimeFactorial, errorMessage: "No prime factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Subfactorial)" button.
		/// Shows a digit frequency analysis for the current subfactorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsSubfactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxSubfactorial, errorMessage: "No subfactorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Double Factorial)" button.
		/// Shows a digit frequency analysis for the current double factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitFactorialDoubleFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxDoubleFactorial, errorMessage: "No double factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Rising Factorial)" button.
		/// Shows a digit frequency analysis for the current rising factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsRisingFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxRisingFactorial, errorMessage: "No rising factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Falling Factorial)" button.
		/// Shows a digit frequency analysis for the current falling factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsFallingFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxFallingFactorial, errorMessage: "No falling factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Multi Factorial)" button.
		/// Shows a digit frequency analysis for the current multi factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsMultiFactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxMultiFactorial, errorMessage: "No multi factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Superfactorial)" button.
		/// Shows a digit frequency analysis for the current superfactorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsSuperfactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxSuperfactorial, errorMessage: "No superfactorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Hyperfactorial)" button.
		/// Shows a digit frequency analysis for the current hyperfactorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsHyperfactorial_Click(object sender, EventArgs e)
			=> ShowDigitStatistics(sourceTextBox: textBoxHyperfactorial, errorMessage: "No hyperfactorial result to analyze.");
	}
}
