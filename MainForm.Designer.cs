namespace FactorialForge
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl = new TabControl();
			this.tabPageFactorial = new TabPage();
			this.labelNumber = new Label();
			this.textBoxFactorial = new TextBox();
			this.numericUpDownFactorial = new NumericUpDown();
			this.tabControl.SuspendLayout();
			this.tabPageFactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFactorial).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Appearance = TabAppearance.Buttons;
			this.tabControl.Controls.Add(this.tabPageFactorial);
			this.tabControl.Dock = DockStyle.Fill;
			this.tabControl.Location = new Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = true;
			this.tabControl.Size = new Size(253, 223);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageFactorial
			// 
			this.tabPageFactorial.Controls.Add(this.labelNumber);
			this.tabPageFactorial.Controls.Add(this.textBoxFactorial);
			this.tabPageFactorial.Controls.Add(this.numericUpDownFactorial);
			this.tabPageFactorial.Location = new Point(4, 27);
			this.tabPageFactorial.Name = "tabPageFactorial";
			this.tabPageFactorial.Padding = new Padding(3);
			this.tabPageFactorial.Size = new Size(245, 192);
			this.tabPageFactorial.TabIndex = 0;
			this.tabPageFactorial.Text = "Factorial";
			this.tabPageFactorial.UseVisualStyleBackColor = true;
			// 
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new Point(8, 8);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new Size(17, 15);
			this.labelNumber.TabIndex = 3;
			this.labelNumber.Text = "n:";
			// 
			// textBoxFactorial
			// 
			this.textBoxFactorial.Location = new Point(6, 35);
			this.textBoxFactorial.MaxLength = int.MaxValue;
			this.textBoxFactorial.Multiline = true;
			this.textBoxFactorial.Name = "textBoxFactorial";
			this.textBoxFactorial.PlaceholderText = "Factorial";
			this.textBoxFactorial.ScrollBars = ScrollBars.Vertical;
			this.textBoxFactorial.Size = new Size(231, 149);
			this.textBoxFactorial.TabIndex = 2;
			// 
			// numericUpDownFactorial
			// 
			this.numericUpDownFactorial.Location = new Point(31, 6);
			this.numericUpDownFactorial.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numericUpDownFactorial.Name = "numericUpDownFactorial";
			this.numericUpDownFactorial.Size = new Size(69, 23);
			this.numericUpDownFactorial.TabIndex = 0;
			this.numericUpDownFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownFactorial.ValueChanged += this.NumericUpDownFactorial_ValueChanged;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(253, 223);
			this.Controls.Add(this.tabControl);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Factorial Forge";
			this.tabControl.ResumeLayout(false);
			this.tabPageFactorial.ResumeLayout(false);
			this.tabPageFactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFactorial).EndInit();
			this.ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl;
		private TabPage tabPageFactorial;
		private NumericUpDown numericUpDownFactorial;
		private TextBox textBoxFactorial;
		private Label labelNumber;
	}
}
