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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl = new TabControl();
			this.tabPageFactorial = new TabPage();
			this.labelFactorial = new Label();
			this.textBoxFactorial = new TextBox();
			this.numericUpDownFactorial = new NumericUpDown();
			this.tabPageOddFactorial = new TabPage();
			this.labelOddFactorial = new Label();
			this.textBoxOddFactorial = new TextBox();
			this.numericUpDownOddFactorial = new NumericUpDown();
			this.tabPageEvenFactorial = new TabPage();
			this.labelEvenFactorial = new Label();
			this.textBoxEvenFactorial = new TextBox();
			this.numericUpDownEvenFactorial = new NumericUpDown();
			this.tabPagePrimeFactorial = new TabPage();
			this.labelPrimeFactorial = new Label();
			this.textBoxPrimeFactorial = new TextBox();
			this.numericUpDownPrimeFactorial = new NumericUpDown();
			this.tabPageSubfactorial = new TabPage();
			this.labelSubfactorial = new Label();
			this.textBoxSubfactorial = new TextBox();
			this.numericUpDownSubfactorial = new NumericUpDown();
			this.statusStrip = new StatusStrip();
			this.toolStripStatusLabelTime = new ToolStripStatusLabel();
			this.toolStripProgressBar = new ToolStripProgressBar();
			this.toolStripContainer = new ToolStripContainer();
			this.tabControl.SuspendLayout();
			this.tabPageFactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFactorial).BeginInit();
			this.tabPageOddFactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownOddFactorial).BeginInit();
			this.tabPageEvenFactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEvenFactorial).BeginInit();
			this.tabPagePrimeFactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPrimeFactorial).BeginInit();
			this.tabPageSubfactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownSubfactorial).BeginInit();
			this.statusStrip.SuspendLayout();
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Appearance = TabAppearance.Buttons;
			this.tabControl.Controls.Add(this.tabPageFactorial);
			this.tabControl.Controls.Add(this.tabPageOddFactorial);
			this.tabControl.Controls.Add(this.tabPageEvenFactorial);
			this.tabControl.Controls.Add(this.tabPagePrimeFactorial);
			this.tabControl.Controls.Add(this.tabPageSubfactorial);
			this.tabControl.Dock = DockStyle.Fill;
			this.tabControl.Location = new Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = true;
			this.tabControl.Size = new Size(421, 264);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageFactorial
			// 
			this.tabPageFactorial.Controls.Add(this.labelFactorial);
			this.tabPageFactorial.Controls.Add(this.textBoxFactorial);
			this.tabPageFactorial.Controls.Add(this.numericUpDownFactorial);
			this.tabPageFactorial.Location = new Point(4, 27);
			this.tabPageFactorial.Name = "tabPageFactorial";
			this.tabPageFactorial.Padding = new Padding(3);
			this.tabPageFactorial.Size = new Size(413, 233);
			this.tabPageFactorial.TabIndex = 0;
			this.tabPageFactorial.Text = "Factorial";
			this.tabPageFactorial.UseVisualStyleBackColor = true;
			// 
			// labelFactorial
			// 
			this.labelFactorial.AutoSize = true;
			this.labelFactorial.Location = new Point(8, 8);
			this.labelFactorial.Name = "labelFactorial";
			this.labelFactorial.Size = new Size(67, 15);
			this.labelFactorial.TabIndex = 3;
			this.labelFactorial.Text = "n[0..10000]:";
			// 
			// textBoxFactorial
			// 
			this.textBoxFactorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBoxFactorial.Location = new Point(3, 35);
			this.textBoxFactorial.MaxLength = int.MaxValue;
			this.textBoxFactorial.Multiline = true;
			this.textBoxFactorial.Name = "textBoxFactorial";
			this.textBoxFactorial.PlaceholderText = "Factorial";
			this.textBoxFactorial.ScrollBars = ScrollBars.Vertical;
			this.textBoxFactorial.Size = new Size(407, 195);
			this.textBoxFactorial.TabIndex = 2;
			// 
			// numericUpDownFactorial
			// 
			this.numericUpDownFactorial.Location = new Point(81, 3);
			this.numericUpDownFactorial.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numericUpDownFactorial.Name = "numericUpDownFactorial";
			this.numericUpDownFactorial.Size = new Size(69, 23);
			this.numericUpDownFactorial.TabIndex = 0;
			this.numericUpDownFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownFactorial.ValueChanged += this.NumericUpDownFactorial_ValueChanged;
			// 
			// tabPageOddFactorial
			// 
			this.tabPageOddFactorial.Controls.Add(this.labelOddFactorial);
			this.tabPageOddFactorial.Controls.Add(this.textBoxOddFactorial);
			this.tabPageOddFactorial.Controls.Add(this.numericUpDownOddFactorial);
			this.tabPageOddFactorial.Location = new Point(4, 27);
			this.tabPageOddFactorial.Name = "tabPageOddFactorial";
			this.tabPageOddFactorial.Padding = new Padding(3);
			this.tabPageOddFactorial.Size = new Size(413, 233);
			this.tabPageOddFactorial.TabIndex = 1;
			this.tabPageOddFactorial.Text = "Odd Factorial";
			this.tabPageOddFactorial.UseVisualStyleBackColor = true;
			// 
			// labelOddFactorial
			// 
			this.labelOddFactorial.AutoSize = true;
			this.labelOddFactorial.Location = new Point(8, 8);
			this.labelOddFactorial.Name = "labelOddFactorial";
			this.labelOddFactorial.Size = new Size(67, 15);
			this.labelOddFactorial.TabIndex = 6;
			this.labelOddFactorial.Text = "n[0..10000]:";
			// 
			// textBoxOddFactorial
			// 
			this.textBoxOddFactorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBoxOddFactorial.Location = new Point(3, 35);
			this.textBoxOddFactorial.MaxLength = int.MaxValue;
			this.textBoxOddFactorial.Multiline = true;
			this.textBoxOddFactorial.Name = "textBoxOddFactorial";
			this.textBoxOddFactorial.PlaceholderText = "Odd Factorial";
			this.textBoxOddFactorial.ScrollBars = ScrollBars.Vertical;
			this.textBoxOddFactorial.Size = new Size(407, 195);
			this.textBoxOddFactorial.TabIndex = 5;
			// 
			// numericUpDownOddFactorial
			// 
			this.numericUpDownOddFactorial.Location = new Point(81, 3);
			this.numericUpDownOddFactorial.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numericUpDownOddFactorial.Name = "numericUpDownOddFactorial";
			this.numericUpDownOddFactorial.Size = new Size(69, 23);
			this.numericUpDownOddFactorial.TabIndex = 4;
			this.numericUpDownOddFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownOddFactorial.ValueChanged += this.NumericUpDownOddFactorial_ValueChanged;
			// 
			// tabPageEvenFactorial
			// 
			this.tabPageEvenFactorial.Controls.Add(this.labelEvenFactorial);
			this.tabPageEvenFactorial.Controls.Add(this.textBoxEvenFactorial);
			this.tabPageEvenFactorial.Controls.Add(this.numericUpDownEvenFactorial);
			this.tabPageEvenFactorial.Location = new Point(4, 27);
			this.tabPageEvenFactorial.Name = "tabPageEvenFactorial";
			this.tabPageEvenFactorial.Size = new Size(413, 233);
			this.tabPageEvenFactorial.TabIndex = 2;
			this.tabPageEvenFactorial.Text = "Even Factorial";
			this.tabPageEvenFactorial.UseVisualStyleBackColor = true;
			// 
			// labelEvenFactorial
			// 
			this.labelEvenFactorial.AutoSize = true;
			this.labelEvenFactorial.Location = new Point(8, 8);
			this.labelEvenFactorial.Name = "labelEvenFactorial";
			this.labelEvenFactorial.Size = new Size(67, 15);
			this.labelEvenFactorial.TabIndex = 9;
			this.labelEvenFactorial.Text = "n[0..10000]:";
			// 
			// textBoxEvenFactorial
			// 
			this.textBoxEvenFactorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBoxEvenFactorial.Location = new Point(3, 35);
			this.textBoxEvenFactorial.MaxLength = int.MaxValue;
			this.textBoxEvenFactorial.Multiline = true;
			this.textBoxEvenFactorial.Name = "textBoxEvenFactorial";
			this.textBoxEvenFactorial.PlaceholderText = "Even Factorial";
			this.textBoxEvenFactorial.ScrollBars = ScrollBars.Vertical;
			this.textBoxEvenFactorial.Size = new Size(407, 195);
			this.textBoxEvenFactorial.TabIndex = 8;
			// 
			// numericUpDownEvenFactorial
			// 
			this.numericUpDownEvenFactorial.Location = new Point(81, 3);
			this.numericUpDownEvenFactorial.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numericUpDownEvenFactorial.Name = "numericUpDownEvenFactorial";
			this.numericUpDownEvenFactorial.Size = new Size(69, 23);
			this.numericUpDownEvenFactorial.TabIndex = 7;
			this.numericUpDownEvenFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownEvenFactorial.ValueChanged += this.NumericUpDownEvenFactorial_ValueChanged;
			// 
			// tabPagePrimeFactorial
			// 
			this.tabPagePrimeFactorial.Controls.Add(this.labelPrimeFactorial);
			this.tabPagePrimeFactorial.Controls.Add(this.textBoxPrimeFactorial);
			this.tabPagePrimeFactorial.Controls.Add(this.numericUpDownPrimeFactorial);
			this.tabPagePrimeFactorial.Location = new Point(4, 27);
			this.tabPagePrimeFactorial.Name = "tabPagePrimeFactorial";
			this.tabPagePrimeFactorial.Size = new Size(413, 233);
			this.tabPagePrimeFactorial.TabIndex = 3;
			this.tabPagePrimeFactorial.Text = "Prime Factorial";
			this.tabPagePrimeFactorial.UseVisualStyleBackColor = true;
			// 
			// labelPrimeFactorial
			// 
			this.labelPrimeFactorial.AutoSize = true;
			this.labelPrimeFactorial.Location = new Point(8, 8);
			this.labelPrimeFactorial.Name = "labelPrimeFactorial";
			this.labelPrimeFactorial.Size = new Size(67, 15);
			this.labelPrimeFactorial.TabIndex = 6;
			this.labelPrimeFactorial.Text = "n[0..10000]:";
			// 
			// textBoxPrimeFactorial
			// 
			this.textBoxPrimeFactorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBoxPrimeFactorial.Location = new Point(3, 35);
			this.textBoxPrimeFactorial.MaxLength = int.MaxValue;
			this.textBoxPrimeFactorial.Multiline = true;
			this.textBoxPrimeFactorial.Name = "textBoxPrimeFactorial";
			this.textBoxPrimeFactorial.PlaceholderText = "Prime Factorial";
			this.textBoxPrimeFactorial.ScrollBars = ScrollBars.Vertical;
			this.textBoxPrimeFactorial.Size = new Size(407, 195);
			this.textBoxPrimeFactorial.TabIndex = 5;
			// 
			// numericUpDownPrimeFactorial
			// 
			this.numericUpDownPrimeFactorial.Location = new Point(81, 3);
			this.numericUpDownPrimeFactorial.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numericUpDownPrimeFactorial.Name = "numericUpDownPrimeFactorial";
			this.numericUpDownPrimeFactorial.Size = new Size(69, 23);
			this.numericUpDownPrimeFactorial.TabIndex = 4;
			this.numericUpDownPrimeFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownPrimeFactorial.ValueChanged += this.NumericUpDownPrimeFactorial_ValueChanged;
			// 
			// tabPageSubfactorial
			// 
			this.tabPageSubfactorial.Controls.Add(this.labelSubfactorial);
			this.tabPageSubfactorial.Controls.Add(this.textBoxSubfactorial);
			this.tabPageSubfactorial.Controls.Add(this.numericUpDownSubfactorial);
			this.tabPageSubfactorial.Location = new Point(4, 27);
			this.tabPageSubfactorial.Name = "tabPageSubfactorial";
			this.tabPageSubfactorial.Size = new Size(413, 233);
			this.tabPageSubfactorial.TabIndex = 4;
			this.tabPageSubfactorial.Text = "Subfactorial";
			this.tabPageSubfactorial.UseVisualStyleBackColor = true;
			// 
			// labelSubfactorial
			// 
			this.labelSubfactorial.AutoSize = true;
			this.labelSubfactorial.Location = new Point(8, 8);
			this.labelSubfactorial.Name = "labelSubfactorial";
			this.labelSubfactorial.Size = new Size(67, 15);
			this.labelSubfactorial.TabIndex = 6;
			this.labelSubfactorial.Text = "n[0..10000]:";
			// 
			// textBoxSubfactorial
			// 
			this.textBoxSubfactorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBoxSubfactorial.Location = new Point(3, 35);
			this.textBoxSubfactorial.MaxLength = int.MaxValue;
			this.textBoxSubfactorial.Multiline = true;
			this.textBoxSubfactorial.Name = "textBoxSubfactorial";
			this.textBoxSubfactorial.PlaceholderText = "Subfactorial";
			this.textBoxSubfactorial.ScrollBars = ScrollBars.Vertical;
			this.textBoxSubfactorial.Size = new Size(407, 195);
			this.textBoxSubfactorial.TabIndex = 5;
			// 
			// numericUpDownSubfactorial
			// 
			this.numericUpDownSubfactorial.Location = new Point(81, 3);
			this.numericUpDownSubfactorial.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numericUpDownSubfactorial.Name = "numericUpDownSubfactorial";
			this.numericUpDownSubfactorial.Size = new Size(69, 23);
			this.numericUpDownSubfactorial.TabIndex = 4;
			this.numericUpDownSubfactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownSubfactorial.ValueChanged += this.NumericUpDownSubfactorial_ValueChanged;
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = DockStyle.None;
			this.statusStrip.Items.AddRange(new ToolStripItem[] { this.toolStripStatusLabelTime, this.toolStripProgressBar });
			this.statusStrip.Location = new Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(421, 22);
			this.statusStrip.TabIndex = 4;
			// 
			// toolStripStatusLabelTime
			// 
			this.toolStripStatusLabelTime.AutoToolTip = true;
			this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
			this.toolStripStatusLabelTime.Size = new Size(304, 17);
			this.toolStripStatusLabelTime.Spring = true;
			this.toolStripStatusLabelTime.Text = "calculation time";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.AutoToolTip = true;
			this.toolStripProgressBar.MarqueeAnimationSpeed = 10;
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new Size(100, 16);
			this.toolStripProgressBar.Step = 1;
			this.toolStripProgressBar.Style = ProgressBarStyle.Marquee;
			// 
			// toolStripContainer
			// 
			// 
			// toolStripContainer.BottomToolStripPanel
			// 
			this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Controls.Add(this.tabControl);
			this.toolStripContainer.ContentPanel.Size = new Size(421, 264);
			this.toolStripContainer.Dock = DockStyle.Fill;
			this.toolStripContainer.Location = new Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new Size(421, 286);
			this.toolStripContainer.TabIndex = 1;
			this.toolStripContainer.TopToolStripPanelVisible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(421, 286);
			this.Controls.Add(this.toolStripContainer);
			this.Icon = (Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Factorial Forge";
			this.tabControl.ResumeLayout(false);
			this.tabPageFactorial.ResumeLayout(false);
			this.tabPageFactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFactorial).EndInit();
			this.tabPageOddFactorial.ResumeLayout(false);
			this.tabPageOddFactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownOddFactorial).EndInit();
			this.tabPageEvenFactorial.ResumeLayout(false);
			this.tabPageEvenFactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEvenFactorial).EndInit();
			this.tabPagePrimeFactorial.ResumeLayout(false);
			this.tabPagePrimeFactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPrimeFactorial).EndInit();
			this.tabPageSubfactorial.ResumeLayout(false);
			this.tabPageSubfactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownSubfactorial).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl;
		private TabPage tabPageFactorial;
		private NumericUpDown numericUpDownFactorial;
		private TextBox textBoxFactorial;
		private Label labelFactorial;
		private StatusStrip statusStrip;
		private ToolStripProgressBar toolStripProgressBar;
		private ToolStripContainer toolStripContainer;
		private TabPage tabPageOddFactorial;
		private Label labelOddFactorial;
		private TextBox textBoxOddFactorial;
		private NumericUpDown numericUpDownOddFactorial;
		private TabPage tabPageEvenFactorial;
		private Label labelEvenFactorial;
		private TextBox textBoxEvenFactorial;
		private NumericUpDown numericUpDownEvenFactorial;
		private ToolStripStatusLabel toolStripStatusLabelTime;
		private TabPage tabPagePrimeFactorial;
		private Label labelPrimeFactorial;
		private TextBox textBoxPrimeFactorial;
		private NumericUpDown numericUpDownPrimeFactorial;
		private TabPage tabPageSubfactorial;
		private Label labelSubfactorial;
		private TextBox textBoxSubfactorial;
		private NumericUpDown numericUpDownSubfactorial;
	}
}
