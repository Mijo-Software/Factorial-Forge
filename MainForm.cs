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
			// Array to hold counts for digits 0-9
			int[] counts = new int[10];
			// Counter for the number of different digits found
			int digits = 0;
			// Iterate through each character in the input string
			foreach (char c in input)
			{
				// Check if the character is a digit
				if (char.IsDigit(c: c))
				{
					// Convert character to its corresponding digit value
					int digit = c - '0';
					// Increment the count for this digit
					counts[digit]++;
				}
			}
			// Build the result string to display
			StringBuilder sb = new();
			// Append each digit and its count to the StringBuilder
			for (int i = 0; i < counts.Length; i++)
			{
				// Count how many different digits were found
				if (counts[i] > 0)
				{
					// Increment the count of different digits
					digits++;
				}
				// Append the digit and its count
				_ = sb.AppendLine(value: $"{i}: {counts[i]}");
			}
			// Append the total sum of digits
			_ = sb.AppendLine(value: $"\nΣ: {counts.Sum()}");
			// Calculate and append the mean of the digits
			if (digits > 0)
			{
				double mean = (double)counts.Sum() / digits;
				_ = sb.AppendLine(value: $"⌀: {mean:F2}");
			}
			else
			{
				_ = sb.AppendLine(value: "⌀: N/A (no digits found)");
			}
			// Show the digit statistics in a message box
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
			// Update status bar and show progress bar
			toolStripStatusLabelInfo.Text = "Calculating...";
			toolStripProgressBar.Visible = true;
			// Perform the calculation asynchronously
			try
			{
				// Restart and stop the stopwatch to measure calculation time
				watch.Restart();
				// Run the calculation on a background thread
				BigInteger result = await Task.Run(function: calculation);
				// Stop the stopwatch after calculation completes
				watch.Stop();
				// Display the result in the target textbox
				targetTextBox.Text = $"{result}";
				// Update the status bar with the elapsed time
				toolStripStatusLabelInfo.Text = $"Calculation completed in {watch.ElapsedMilliseconds} ms.";
			}
			// Handle any exceptions that occur during calculation
			catch (Exception ex)
			{
				// Show an error message box with the exception details
				_ = MessageBox.Show(text: $"Error: {ex.Message}");
			}
			// Hide the progress bar after calculation is done
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
			// Check if the textbox is not empty or whitespace
			if (!string.IsNullOrWhiteSpace(value: sourceTextBox.Text))
			{
				// Attempt to copy the text to the clipboard
				try
				{
					// Set the clipboard text to the content of the textbox
					Clipboard.SetText(sourceTextBox.Text);
					// Update the status bar to indicate successful copy
					toolStripStatusLabelInfo.Text = "Copied to clipboard.";
				}
				// Handle any exceptions that occur during clipboard operations
				catch (Exception ex)
				{
					// Show an error message box with the exception details
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
			// Check if the textbox is not empty or whitespace
			if (!string.IsNullOrWhiteSpace(value: sourceTextBox.Text))
			{
				// Create and configure the SaveFileDialog
				using SaveFileDialog saveFileDialog = new()
				{
					// Set the file filter to allow text files and all files
					Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
					Title = title
				};
				// Show the dialog and check if the user confirmed the save operation
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					// Attempt to write the textbox content to the selected file
					try
					{
						// Write the content of the textbox to the specified file
						File.WriteAllText(path: saveFileDialog.FileName, contents: sourceTextBox.Text);
						// Update the status bar to indicate successful save
						toolStripStatusLabelInfo.Text = $"Saved to {saveFileDialog.FileName}.";
					}
					// Handle any exceptions that occur during file operations
					catch (Exception ex)
					{
						// Show an error message box with the exception details
						_ = MessageBox.Show(text: $"Error saving file: {ex.Message}", caption: "File Save Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
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
			// Check if the textbox is not empty or whitespace
			if (!string.IsNullOrWhiteSpace(value: sourceTextBox.Text))
			{
				// Analyze and display the digit statistics
				CountDigits(input: sourceTextBox.Text);
			}
			// If the textbox is empty, show the provided error message
			else
			{
				// Show an error message box indicating no data to analyze
				_ = MessageBox.Show(text: errorMessage, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Initializes a new instance of the MainForm class.
		/// Sets up the UI components, initializes the stopwatch, and updates the status bar to indicate readiness.
		/// </summary>
		public MainForm()
		{
			// Initialize UI components
			InitializeComponent();
			// Start and stop the stopwatch to initialize it
			watch.Start();
			watch.Stop();
			// Set the progress bar to be invisible initially
			toolStripProgressBar.Visible = false;
			// Update the status bar to indicate the application is ready
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
			// Perform the factorial calculation and display the result
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
			// Perform the odd factorial calculation and display the result
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
			// Perform the even factorial calculation and display the result
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
			// Perform the prime factorial calculation and display the result
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
			// Perform the subfactorial calculation and display the result
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
			// Perform the double factorial calculation and display the result
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
			// Perform the rising factorial calculation and display the result
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
			// Perform the falling factorial calculation and display the result
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
			// Delegate to the X value changed handler to recalculate
			=> NumericUpDownRisingFactorialX_ValueChanged(sender: sender, e: e);

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownFallingFactorialN control.
		/// Triggers the calculation and display logic for the falling factorial by delegating to NumericUpDownFallingFactorialX_ValueChanged.
		/// Ensures that changes to either parameter (X or N) update the result.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownFallingFactorialN).</param>
		/// <param name="e">The event data.</param>
		private void NumericUpDownFallingFactorialN_ValueChanged(object sender, EventArgs e)
			// Delegate to the X value changed handler to recalculate
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
			// Perform the multi-factorial calculation and display the result
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
			// Delegate to the X value changed handler to recalculate
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
			// Perform the superfactorial calculation and display the result
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
			// Perform the hyperfactorial calculation and display the result
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.HyperfactorialBig(n: (long)numericUpDownHyperfactorial.Value),
				targetTextBox: textBoxHyperfactorial
			);
		}

		/// <summary>
		/// Handles the ValueChanged event for the numericUpDownSuperduperfactorial control.
		/// Calculates the superduperfactorial for the selected value asynchronously and displays the result in the corresponding textbox.
		/// Updates the status bar with calculation time and handles any errors that occur during calculation.
		/// </summary>
		/// <param name="sender">The event source (numericUpDownSuperduperfactorial).</param>
		/// <param name="e">The event data.</param>
		private async void NumericUpDownSuperduperfactorial_ValueChanged(object sender, EventArgs e)
		{
			// Perform the superduperfactorial calculation and display the result
			await CalculateAndDisplayAsync(
				calculation: () => Factorializer.SuperduperfactorialBig(n: (long)numericUpDownSuperduperfactorial.Value),
				targetTextBox: textBoxSuperduperfactorial
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
			// Copy the factorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Odd Factorial Result to Clipboard" button.
		/// Copies the current odd factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardOddFactorial_Click(object sender, EventArgs e)
			// Copy the odd factorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxOddFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Even Factorial Result to Clipboard" button.
		/// Copies the current even factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardEvenFactorial_Click(object sender, EventArgs e)
			// Copy the even factorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxEvenFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Prime Factorial Result to Clipboard" button.
		/// Copies the current prime factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardPrimeFactorial_Click(object sender, EventArgs e)
			// Copy the prime factorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxPrimeFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Subfactorial Result to Clipboard" button.
		/// Copies the current subfactorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardSubfactorial_Click(object sender, EventArgs e)
			// Copy the subfactorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxSubfactorial);

		/// <summary>
		/// Handles the click event for the "Copy Double Factorial Result to Clipboard" button.
		/// Copies the current double factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardDoubleFactorial_Click(object sender, EventArgs e)
			// Copy the double factorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxDoubleFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Rising Factorial Result to Clipboard" button.
		/// Copies the current rising factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardRisingFactorial_Click(object sender, EventArgs e)
			// Copy the rising factorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxRisingFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Falling Factorial Result to Clipboard" button.
		/// Copies the current falling factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardFallingFactorial_Click(object sender, EventArgs e)
			 // Copy the falling factorial result to the clipboard
			 => CopyToClipboard(sourceTextBox: textBoxFallingFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Multi Factorial Result to Clipboard" button.
		/// Copies the current multi factorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardMultiFactorial_Click(object sender, EventArgs e)
			// Copy the multi factorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxMultiFactorial);

		/// <summary>
		/// Handles the click event for the "Copy Superfactorial Result to Clipboard" button.
		/// Copies the current superfactorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardSuperfactorial_Click(object sender, EventArgs e)
			// Copy the superfactorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxSuperfactorial);

		/// <summary>
		/// Handles the click event for the "Copy Hyperfactorial Result to Clipboard" button.
		/// Copies the current hyperfactorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardHyperfactorial_Click(object sender, EventArgs e)
			// Copy the hyperfactorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxHyperfactorial);

		/// <summary>
		/// Handles the click event for the "Copy Superduperfactorial Result to Clipboard" button.
		/// Copies the current superduperfactorial result from the textbox to the clipboard.
		/// Displays an error message if copying fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonCopyToClipboardSuperduperfactorial_Click(object sender, EventArgs e)
			// Copy the superduperfactorial result to the clipboard
			=> CopyToClipboard(sourceTextBox: textBoxSuperduperfactorial);

		/// <summary>
		/// Handles the click event for the "Save Factorial Result" button.
		/// Opens a SaveFileDialog to save the current factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileFactorial_Click(object sender, EventArgs e)
			// Save the factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxFactorial, title: "Save Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Odd Factorial Result" button.
		/// Opens a SaveFileDialog to save the current odd factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileOddFactorial_Click(object sender, EventArgs e)
			// Save the odd factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxOddFactorial, title: "Save Odd Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Even Factorial Result" button.
		/// Opens a SaveFileDialog to save the current even factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileEvenFactorial_Click(object sender, EventArgs e)
			// Save the even factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxEvenFactorial, title: "Save Even Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Prime Factorial Result" button.
		/// Opens a SaveFileDialog to save the current prime factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>

		private void ButtonSaveToFilePrimeFactorial_Click(object sender, EventArgs e)
			// Save the prime factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxPrimeFactorial, title: "Save Prime Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Subfactorial Result" button.
		/// Opens a SaveFileDialog to save the current subfactorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileSubfactorial_Click(object sender, EventArgs e)
			// Save the subfactorial result to a file
			=> SaveToFile(sourceTextBox: textBoxSubfactorial, title: "Save Subfactorial Result");

		/// <summary>
		/// Handles the click event for the "Save Double Factorial Result" button.
		/// Opens a SaveFileDialog to save the current double factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileDoubleFactorial_Click(object sender, EventArgs e)
			// Save the double factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxDoubleFactorial, title: "Save Double Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Rising Factorial Result" button.
		/// Opens a SaveFileDialog to save the current rising factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileRisingFactorial_Click(object sender, EventArgs e)
			// Save the rising factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxRisingFactorial, title: "Save Rising Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Falling Factorial Result" button.
		/// Opens a SaveFileDialog to save the current falling factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileFallingFactorial_Click(object sender, EventArgs e)
			// Save the falling factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxFallingFactorial, title: "Save Falling Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Multi Factorial Result" button.
		/// Opens a SaveFileDialog to save the current multi factorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileMultiFactorial_Click(object sender, EventArgs e)
			// Save the multi factorial result to a file
			=> SaveToFile(sourceTextBox: textBoxMultiFactorial, title: "Save Multi Factorial Result");

		/// <summary>
		/// Handles the click event for the "Save Superfactorial Result" button.
		/// Opens a SaveFileDialog to save the current superfactorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileSuperfactorial_Click(object sender, EventArgs e)
			// Save the superfactorial result to a file
			=> SaveToFile(sourceTextBox: textBoxSuperfactorial, title: "Save Superfactorial Result");

		/// <summary>
		/// Handles the click event for the "Save Hyperfactorial Result" button.
		/// Opens a SaveFileDialog to save the current hyperfactorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileHyperfactorial_Click(object sender, EventArgs e)
			// Save the hyperfactorial result to a file
			=> SaveToFile(sourceTextBox: textBoxHyperfactorial, title: "Save Hyperfactorial Result");

		/// <summary>
		/// Handles the click event for the "Save Superduperfactorial Result" button.
		/// Opens a SaveFileDialog to save the current superduperfactorial result to a file.
		/// Displays an error message if saving fails or if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonSaveToFileSuperduperfactorial_Click(object sender, EventArgs e)
			// Save the superduperfactorial result to a file
			=> SaveToFile(sourceTextBox: textBoxSuperduperfactorial, title: "Save Superduperfactorial Result");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Factorial)" button.
		/// Shows a digit frequency analysis for the current factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxFactorial, errorMessage: "No factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Odd Factorial)" button.
		/// Shows a digit frequency analysis for the current odd factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsOddFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the odd factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxOddFactorial, errorMessage: "No odd factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Even Factorial)" button.
		/// Shows a digit frequency analysis for the current even factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsEvenFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the even factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxEvenFactorial, errorMessage: "No even factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Prime Factorial)" button.
		/// Shows a digit frequency analysis for the current prime factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsPrimeFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the prime factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxPrimeFactorial, errorMessage: "No prime factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Subfactorial)" button.
		/// Shows a digit frequency analysis for the current subfactorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsSubfactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the subfactorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxSubfactorial, errorMessage: "No subfactorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Double Factorial)" button.
		/// Shows a digit frequency analysis for the current double factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitFactorialDoubleFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the double factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxDoubleFactorial, errorMessage: "No double factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Rising Factorial)" button.
		/// Shows a digit frequency analysis for the current rising factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsRisingFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the rising factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxRisingFactorial, errorMessage: "No rising factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Falling Factorial)" button.
		/// Shows a digit frequency analysis for the current falling factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsFallingFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the falling factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxFallingFactorial, errorMessage: "No falling factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Multi Factorial)" button.
		/// Shows a digit frequency analysis for the current multi factorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsMultiFactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the multi factorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxMultiFactorial, errorMessage: "No multi factorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Superfactorial)" button.
		/// Shows a digit frequency analysis for the current superfactorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsSuperfactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the superfactorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxSuperfactorial, errorMessage: "No superfactorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Hyperfactorial)" button.
		/// Shows a digit frequency analysis for the current hyperfactorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsHyperfactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the hyperfactorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxHyperfactorial, errorMessage: "No hyperfactorial result to analyze.");

		/// <summary>
		/// Handles the click event for the "Digit Statistics (Superduperfactorial)" button.
		/// Shows a digit frequency analysis for the current Superduperfactorial result.
		/// Displays an error message if no result is available.
		/// </summary>
		/// <param name="sender">The event source.</param>
		/// <param name="e">The event data.</param>
		private void ButtonDigitStatisticsSuperduperfactorial_Click(object sender, EventArgs e)
			// Show digit statistics for the superduperfactorial result
			=> ShowDigitStatistics(sourceTextBox: textBoxSuperduperfactorial, errorMessage: "No superduperfactorial result to analyze.");
	}
}