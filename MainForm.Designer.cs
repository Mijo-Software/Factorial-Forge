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
			this.buttonDigitStatisticsFactorial = new Button();
			this.buttonSaveToFileFactorial = new Button();
			this.buttonCopyToClipboardFactorial = new Button();
			this.labelFactorial = new Label();
			this.textBoxFactorial = new TextBox();
			this.numericUpDownFactorial = new NumericUpDown();
			this.tabPageOddFactorial = new TabPage();
			this.buttonDigitStatisticsOddFactorial = new Button();
			this.buttonSaveToFileOddFactorial = new Button();
			this.buttonCopyToClipboardOddFactorial = new Button();
			this.labelOddFactorial = new Label();
			this.textBoxOddFactorial = new TextBox();
			this.numericUpDownOddFactorial = new NumericUpDown();
			this.tabPageEvenFactorial = new TabPage();
			this.buttonDigitStatisticsEvenFactorial = new Button();
			this.buttonSaveToFileEvenFactorial = new Button();
			this.buttonCopyToClipboardEvenFactorial = new Button();
			this.labelEvenFactorial = new Label();
			this.textBoxEvenFactorial = new TextBox();
			this.numericUpDownEvenFactorial = new NumericUpDown();
			this.tabPagePrimeFactorial = new TabPage();
			this.buttonDigitStatisticsPrimeFactorial = new Button();
			this.buttonSaveToFilePrimeFactorial = new Button();
			this.buttonCopyToClipboardPrimeFactorial = new Button();
			this.labelPrimeFactorial = new Label();
			this.textBoxPrimeFactorial = new TextBox();
			this.numericUpDownPrimeFactorial = new NumericUpDown();
			this.tabPageSubfactorial = new TabPage();
			this.buttonDigitStatisticsSubfactorial = new Button();
			this.buttonSaveToFileSubfactorial = new Button();
			this.buttonCopyToClipboardSubfactorial = new Button();
			this.labelSubfactorial = new Label();
			this.textBoxSubfactorial = new TextBox();
			this.numericUpDownSubfactorial = new NumericUpDown();
			this.tabPageDoubleFactorial = new TabPage();
			this.buttonDigitFactorialDoubleFactorial = new Button();
			this.buttonSaveToFileDoubleFactorial = new Button();
			this.buttonCopyToClipboardDoubleFactorial = new Button();
			this.labelDoubleFactorial = new Label();
			this.textBoxDoubleFactorial = new TextBox();
			this.numericUpDownDoubleFactorial = new NumericUpDown();
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
			this.tabPageDoubleFactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownDoubleFactorial).BeginInit();
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
			this.tabControl.Controls.Add(this.tabPageDoubleFactorial);
			this.tabControl.Dock = DockStyle.Fill;
			this.tabControl.Location = new Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = true;
			this.tabControl.Size = new Size(518, 308);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageFactorial
			// 
			this.tabPageFactorial.Controls.Add(this.buttonDigitStatisticsFactorial);
			this.tabPageFactorial.Controls.Add(this.buttonSaveToFileFactorial);
			this.tabPageFactorial.Controls.Add(this.buttonCopyToClipboardFactorial);
			this.tabPageFactorial.Controls.Add(this.labelFactorial);
			this.tabPageFactorial.Controls.Add(this.textBoxFactorial);
			this.tabPageFactorial.Controls.Add(this.numericUpDownFactorial);
			this.tabPageFactorial.Location = new Point(4, 27);
			this.tabPageFactorial.Name = "tabPageFactorial";
			this.tabPageFactorial.Padding = new Padding(3);
			this.tabPageFactorial.Size = new Size(510, 277);
			this.tabPageFactorial.TabIndex = 0;
			this.tabPageFactorial.Text = "Factorial";
			this.tabPageFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonDigitStatisticsFactorial
			// 
			this.buttonDigitStatisticsFactorial.Image = (Image)resources.GetObject("buttonDigitStatisticsFactorial.Image");
			this.buttonDigitStatisticsFactorial.Location = new Point(388, 3);
			this.buttonDigitStatisticsFactorial.Name = "buttonDigitStatisticsFactorial";
			this.buttonDigitStatisticsFactorial.Size = new Size(119, 24);
			this.buttonDigitStatisticsFactorial.TabIndex = 6;
			this.buttonDigitStatisticsFactorial.Text = "Digit statistics";
			this.buttonDigitStatisticsFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonDigitStatisticsFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonDigitStatisticsFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonSaveToFileFactorial
			// 
			this.buttonSaveToFileFactorial.Image = (Image)resources.GetObject("buttonSaveToFileFactorial.Image");
			this.buttonSaveToFileFactorial.Location = new Point(292, 3);
			this.buttonSaveToFileFactorial.Name = "buttonSaveToFileFactorial";
			this.buttonSaveToFileFactorial.Size = new Size(90, 24);
			this.buttonSaveToFileFactorial.TabIndex = 5;
			this.buttonSaveToFileFactorial.Text = "Save to file";
			this.buttonSaveToFileFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonSaveToFileFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonSaveToFileFactorial.UseVisualStyleBackColor = true;
			this.buttonSaveToFileFactorial.Click += this.ButtonSaveToFileFactorial_Click;
			// 
			// buttonCopyToClipboardFactorial
			// 
			this.buttonCopyToClipboardFactorial.Image = (Image)resources.GetObject("buttonCopyToClipboardFactorial.Image");
			this.buttonCopyToClipboardFactorial.Location = new Point(156, 3);
			this.buttonCopyToClipboardFactorial.Name = "buttonCopyToClipboardFactorial";
			this.buttonCopyToClipboardFactorial.Size = new Size(130, 24);
			this.buttonCopyToClipboardFactorial.TabIndex = 4;
			this.buttonCopyToClipboardFactorial.Text = "Copy to clipboard";
			this.buttonCopyToClipboardFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCopyToClipboardFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonCopyToClipboardFactorial.UseVisualStyleBackColor = true;
			this.buttonCopyToClipboardFactorial.Click += this.ButtonCopyToClipboardFactorial_Click;
			// 
			// labelFactorial
			// 
			this.labelFactorial.AutoSize = true;
			this.labelFactorial.Location = new Point(8, 8);
			this.labelFactorial.Name = "labelFactorial";
			this.labelFactorial.Size = new Size(67, 15);
			this.labelFactorial.TabIndex = 3;
			this.labelFactorial.Text = "n[0..99999]:";
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
			this.textBoxFactorial.Size = new Size(504, 239);
			this.textBoxFactorial.TabIndex = 2;
			// 
			// numericUpDownFactorial
			// 
			this.numericUpDownFactorial.Location = new Point(81, 3);
			this.numericUpDownFactorial.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
			this.numericUpDownFactorial.Name = "numericUpDownFactorial";
			this.numericUpDownFactorial.Size = new Size(69, 23);
			this.numericUpDownFactorial.TabIndex = 0;
			this.numericUpDownFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownFactorial.ValueChanged += this.NumericUpDownFactorial_ValueChanged;
			// 
			// tabPageOddFactorial
			// 
			this.tabPageOddFactorial.Controls.Add(this.buttonDigitStatisticsOddFactorial);
			this.tabPageOddFactorial.Controls.Add(this.buttonSaveToFileOddFactorial);
			this.tabPageOddFactorial.Controls.Add(this.buttonCopyToClipboardOddFactorial);
			this.tabPageOddFactorial.Controls.Add(this.labelOddFactorial);
			this.tabPageOddFactorial.Controls.Add(this.textBoxOddFactorial);
			this.tabPageOddFactorial.Controls.Add(this.numericUpDownOddFactorial);
			this.tabPageOddFactorial.Location = new Point(4, 27);
			this.tabPageOddFactorial.Name = "tabPageOddFactorial";
			this.tabPageOddFactorial.Padding = new Padding(3);
			this.tabPageOddFactorial.Size = new Size(510, 277);
			this.tabPageOddFactorial.TabIndex = 1;
			this.tabPageOddFactorial.Text = "Odd Factorial";
			this.tabPageOddFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonDigitStatisticsOddFactorial
			// 
			this.buttonDigitStatisticsOddFactorial.Image = (Image)resources.GetObject("buttonDigitStatisticsOddFactorial.Image");
			this.buttonDigitStatisticsOddFactorial.Location = new Point(388, 3);
			this.buttonDigitStatisticsOddFactorial.Name = "buttonDigitStatisticsOddFactorial";
			this.buttonDigitStatisticsOddFactorial.Size = new Size(119, 24);
			this.buttonDigitStatisticsOddFactorial.TabIndex = 9;
			this.buttonDigitStatisticsOddFactorial.Text = "Digit statistics";
			this.buttonDigitStatisticsOddFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonDigitStatisticsOddFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonDigitStatisticsOddFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonSaveToFileOddFactorial
			// 
			this.buttonSaveToFileOddFactorial.Image = (Image)resources.GetObject("buttonSaveToFileOddFactorial.Image");
			this.buttonSaveToFileOddFactorial.Location = new Point(292, 3);
			this.buttonSaveToFileOddFactorial.Name = "buttonSaveToFileOddFactorial";
			this.buttonSaveToFileOddFactorial.Size = new Size(90, 24);
			this.buttonSaveToFileOddFactorial.TabIndex = 8;
			this.buttonSaveToFileOddFactorial.Text = "Save to file";
			this.buttonSaveToFileOddFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonSaveToFileOddFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonSaveToFileOddFactorial.UseVisualStyleBackColor = true;
			this.buttonSaveToFileOddFactorial.Click += this.ButtonSaveToFileOddFactorial_Click;
			// 
			// buttonCopyToClipboardOddFactorial
			// 
			this.buttonCopyToClipboardOddFactorial.Image = (Image)resources.GetObject("buttonCopyToClipboardOddFactorial.Image");
			this.buttonCopyToClipboardOddFactorial.Location = new Point(156, 3);
			this.buttonCopyToClipboardOddFactorial.Name = "buttonCopyToClipboardOddFactorial";
			this.buttonCopyToClipboardOddFactorial.Size = new Size(130, 24);
			this.buttonCopyToClipboardOddFactorial.TabIndex = 7;
			this.buttonCopyToClipboardOddFactorial.Text = "Copy to clipboard";
			this.buttonCopyToClipboardOddFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCopyToClipboardOddFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonCopyToClipboardOddFactorial.UseVisualStyleBackColor = true;
			this.buttonCopyToClipboardOddFactorial.Click += this.ButtonCopyToClipboardOddFactorial_Click;
			// 
			// labelOddFactorial
			// 
			this.labelOddFactorial.AutoSize = true;
			this.labelOddFactorial.Location = new Point(8, 8);
			this.labelOddFactorial.Name = "labelOddFactorial";
			this.labelOddFactorial.Size = new Size(67, 15);
			this.labelOddFactorial.TabIndex = 6;
			this.labelOddFactorial.Text = "n[0..99999]:";
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
			this.textBoxOddFactorial.Size = new Size(504, 239);
			this.textBoxOddFactorial.TabIndex = 5;
			// 
			// numericUpDownOddFactorial
			// 
			this.numericUpDownOddFactorial.Location = new Point(81, 3);
			this.numericUpDownOddFactorial.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
			this.numericUpDownOddFactorial.Name = "numericUpDownOddFactorial";
			this.numericUpDownOddFactorial.Size = new Size(69, 23);
			this.numericUpDownOddFactorial.TabIndex = 4;
			this.numericUpDownOddFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownOddFactorial.ValueChanged += this.NumericUpDownOddFactorial_ValueChanged;
			// 
			// tabPageEvenFactorial
			// 
			this.tabPageEvenFactorial.Controls.Add(this.buttonDigitStatisticsEvenFactorial);
			this.tabPageEvenFactorial.Controls.Add(this.buttonSaveToFileEvenFactorial);
			this.tabPageEvenFactorial.Controls.Add(this.buttonCopyToClipboardEvenFactorial);
			this.tabPageEvenFactorial.Controls.Add(this.labelEvenFactorial);
			this.tabPageEvenFactorial.Controls.Add(this.textBoxEvenFactorial);
			this.tabPageEvenFactorial.Controls.Add(this.numericUpDownEvenFactorial);
			this.tabPageEvenFactorial.Location = new Point(4, 27);
			this.tabPageEvenFactorial.Name = "tabPageEvenFactorial";
			this.tabPageEvenFactorial.Size = new Size(510, 277);
			this.tabPageEvenFactorial.TabIndex = 2;
			this.tabPageEvenFactorial.Text = "Even Factorial";
			this.tabPageEvenFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonDigitStatisticsEvenFactorial
			// 
			this.buttonDigitStatisticsEvenFactorial.Image = (Image)resources.GetObject("buttonDigitStatisticsEvenFactorial.Image");
			this.buttonDigitStatisticsEvenFactorial.Location = new Point(388, 3);
			this.buttonDigitStatisticsEvenFactorial.Name = "buttonDigitStatisticsEvenFactorial";
			this.buttonDigitStatisticsEvenFactorial.Size = new Size(119, 24);
			this.buttonDigitStatisticsEvenFactorial.TabIndex = 12;
			this.buttonDigitStatisticsEvenFactorial.Text = "Digit statistics";
			this.buttonDigitStatisticsEvenFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonDigitStatisticsEvenFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonDigitStatisticsEvenFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonSaveToFileEvenFactorial
			// 
			this.buttonSaveToFileEvenFactorial.Image = (Image)resources.GetObject("buttonSaveToFileEvenFactorial.Image");
			this.buttonSaveToFileEvenFactorial.Location = new Point(292, 3);
			this.buttonSaveToFileEvenFactorial.Name = "buttonSaveToFileEvenFactorial";
			this.buttonSaveToFileEvenFactorial.Size = new Size(90, 24);
			this.buttonSaveToFileEvenFactorial.TabIndex = 11;
			this.buttonSaveToFileEvenFactorial.Text = "Save to file";
			this.buttonSaveToFileEvenFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonSaveToFileEvenFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonSaveToFileEvenFactorial.UseVisualStyleBackColor = true;
			this.buttonSaveToFileEvenFactorial.Click += this.ButtonSaveToFileEvenFactorial_Click;
			// 
			// buttonCopyToClipboardEvenFactorial
			// 
			this.buttonCopyToClipboardEvenFactorial.Image = (Image)resources.GetObject("buttonCopyToClipboardEvenFactorial.Image");
			this.buttonCopyToClipboardEvenFactorial.Location = new Point(156, 3);
			this.buttonCopyToClipboardEvenFactorial.Name = "buttonCopyToClipboardEvenFactorial";
			this.buttonCopyToClipboardEvenFactorial.Size = new Size(130, 24);
			this.buttonCopyToClipboardEvenFactorial.TabIndex = 10;
			this.buttonCopyToClipboardEvenFactorial.Text = "Copy to clipboard";
			this.buttonCopyToClipboardEvenFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCopyToClipboardEvenFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonCopyToClipboardEvenFactorial.UseVisualStyleBackColor = true;
			this.buttonCopyToClipboardEvenFactorial.Click += this.ButtonCopyToClipboardEvenFactorial_Click;
			// 
			// labelEvenFactorial
			// 
			this.labelEvenFactorial.AutoSize = true;
			this.labelEvenFactorial.Location = new Point(8, 8);
			this.labelEvenFactorial.Name = "labelEvenFactorial";
			this.labelEvenFactorial.Size = new Size(67, 15);
			this.labelEvenFactorial.TabIndex = 9;
			this.labelEvenFactorial.Text = "n[0..99999]:";
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
			this.textBoxEvenFactorial.Size = new Size(504, 239);
			this.textBoxEvenFactorial.TabIndex = 8;
			// 
			// numericUpDownEvenFactorial
			// 
			this.numericUpDownEvenFactorial.Location = new Point(81, 3);
			this.numericUpDownEvenFactorial.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
			this.numericUpDownEvenFactorial.Name = "numericUpDownEvenFactorial";
			this.numericUpDownEvenFactorial.Size = new Size(69, 23);
			this.numericUpDownEvenFactorial.TabIndex = 7;
			this.numericUpDownEvenFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownEvenFactorial.ValueChanged += this.NumericUpDownEvenFactorial_ValueChanged;
			// 
			// tabPagePrimeFactorial
			// 
			this.tabPagePrimeFactorial.Controls.Add(this.buttonDigitStatisticsPrimeFactorial);
			this.tabPagePrimeFactorial.Controls.Add(this.buttonSaveToFilePrimeFactorial);
			this.tabPagePrimeFactorial.Controls.Add(this.buttonCopyToClipboardPrimeFactorial);
			this.tabPagePrimeFactorial.Controls.Add(this.labelPrimeFactorial);
			this.tabPagePrimeFactorial.Controls.Add(this.textBoxPrimeFactorial);
			this.tabPagePrimeFactorial.Controls.Add(this.numericUpDownPrimeFactorial);
			this.tabPagePrimeFactorial.Location = new Point(4, 27);
			this.tabPagePrimeFactorial.Name = "tabPagePrimeFactorial";
			this.tabPagePrimeFactorial.Size = new Size(510, 277);
			this.tabPagePrimeFactorial.TabIndex = 3;
			this.tabPagePrimeFactorial.Text = "Prime Factorial";
			this.tabPagePrimeFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonDigitStatisticsPrimeFactorial
			// 
			this.buttonDigitStatisticsPrimeFactorial.Image = (Image)resources.GetObject("buttonDigitStatisticsPrimeFactorial.Image");
			this.buttonDigitStatisticsPrimeFactorial.Location = new Point(388, 3);
			this.buttonDigitStatisticsPrimeFactorial.Name = "buttonDigitStatisticsPrimeFactorial";
			this.buttonDigitStatisticsPrimeFactorial.Size = new Size(119, 24);
			this.buttonDigitStatisticsPrimeFactorial.TabIndex = 9;
			this.buttonDigitStatisticsPrimeFactorial.Text = "Digit statistics";
			this.buttonDigitStatisticsPrimeFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonDigitStatisticsPrimeFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonDigitStatisticsPrimeFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonSaveToFilePrimeFactorial
			// 
			this.buttonSaveToFilePrimeFactorial.Image = (Image)resources.GetObject("buttonSaveToFilePrimeFactorial.Image");
			this.buttonSaveToFilePrimeFactorial.Location = new Point(292, 3);
			this.buttonSaveToFilePrimeFactorial.Name = "buttonSaveToFilePrimeFactorial";
			this.buttonSaveToFilePrimeFactorial.Size = new Size(90, 24);
			this.buttonSaveToFilePrimeFactorial.TabIndex = 8;
			this.buttonSaveToFilePrimeFactorial.Text = "Save to file";
			this.buttonSaveToFilePrimeFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonSaveToFilePrimeFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonSaveToFilePrimeFactorial.UseVisualStyleBackColor = true;
			this.buttonSaveToFilePrimeFactorial.Click += this.ButtonSaveToFilePrimeFactorial_Click;
			// 
			// buttonCopyToClipboardPrimeFactorial
			// 
			this.buttonCopyToClipboardPrimeFactorial.Image = (Image)resources.GetObject("buttonCopyToClipboardPrimeFactorial.Image");
			this.buttonCopyToClipboardPrimeFactorial.Location = new Point(156, 3);
			this.buttonCopyToClipboardPrimeFactorial.Name = "buttonCopyToClipboardPrimeFactorial";
			this.buttonCopyToClipboardPrimeFactorial.Size = new Size(130, 24);
			this.buttonCopyToClipboardPrimeFactorial.TabIndex = 7;
			this.buttonCopyToClipboardPrimeFactorial.Text = "Copy to clipboard";
			this.buttonCopyToClipboardPrimeFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCopyToClipboardPrimeFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonCopyToClipboardPrimeFactorial.UseVisualStyleBackColor = true;
			this.buttonCopyToClipboardPrimeFactorial.Click += this.ButtonCopyToClipboardPrimeFactorial_Click;
			// 
			// labelPrimeFactorial
			// 
			this.labelPrimeFactorial.AutoSize = true;
			this.labelPrimeFactorial.Location = new Point(8, 8);
			this.labelPrimeFactorial.Name = "labelPrimeFactorial";
			this.labelPrimeFactorial.Size = new Size(67, 15);
			this.labelPrimeFactorial.TabIndex = 6;
			this.labelPrimeFactorial.Text = "n[0..99999]:";
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
			this.textBoxPrimeFactorial.Size = new Size(504, 239);
			this.textBoxPrimeFactorial.TabIndex = 5;
			// 
			// numericUpDownPrimeFactorial
			// 
			this.numericUpDownPrimeFactorial.Location = new Point(81, 3);
			this.numericUpDownPrimeFactorial.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
			this.numericUpDownPrimeFactorial.Name = "numericUpDownPrimeFactorial";
			this.numericUpDownPrimeFactorial.Size = new Size(69, 23);
			this.numericUpDownPrimeFactorial.TabIndex = 4;
			this.numericUpDownPrimeFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownPrimeFactorial.ValueChanged += this.NumericUpDownPrimeFactorial_ValueChanged;
			// 
			// tabPageSubfactorial
			// 
			this.tabPageSubfactorial.Controls.Add(this.buttonDigitStatisticsSubfactorial);
			this.tabPageSubfactorial.Controls.Add(this.buttonSaveToFileSubfactorial);
			this.tabPageSubfactorial.Controls.Add(this.buttonCopyToClipboardSubfactorial);
			this.tabPageSubfactorial.Controls.Add(this.labelSubfactorial);
			this.tabPageSubfactorial.Controls.Add(this.textBoxSubfactorial);
			this.tabPageSubfactorial.Controls.Add(this.numericUpDownSubfactorial);
			this.tabPageSubfactorial.Location = new Point(4, 27);
			this.tabPageSubfactorial.Name = "tabPageSubfactorial";
			this.tabPageSubfactorial.Size = new Size(510, 277);
			this.tabPageSubfactorial.TabIndex = 4;
			this.tabPageSubfactorial.Text = "Subfactorial";
			this.tabPageSubfactorial.UseVisualStyleBackColor = true;
			// 
			// buttonDigitStatisticsSubfactorial
			// 
			this.buttonDigitStatisticsSubfactorial.Image = (Image)resources.GetObject("buttonDigitStatisticsSubfactorial.Image");
			this.buttonDigitStatisticsSubfactorial.Location = new Point(388, 3);
			this.buttonDigitStatisticsSubfactorial.Name = "buttonDigitStatisticsSubfactorial";
			this.buttonDigitStatisticsSubfactorial.Size = new Size(119, 24);
			this.buttonDigitStatisticsSubfactorial.TabIndex = 9;
			this.buttonDigitStatisticsSubfactorial.Text = "Digit statistics";
			this.buttonDigitStatisticsSubfactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonDigitStatisticsSubfactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonDigitStatisticsSubfactorial.UseVisualStyleBackColor = true;
			// 
			// buttonSaveToFileSubfactorial
			// 
			this.buttonSaveToFileSubfactorial.Image = (Image)resources.GetObject("buttonSaveToFileSubfactorial.Image");
			this.buttonSaveToFileSubfactorial.Location = new Point(292, 3);
			this.buttonSaveToFileSubfactorial.Name = "buttonSaveToFileSubfactorial";
			this.buttonSaveToFileSubfactorial.Size = new Size(90, 24);
			this.buttonSaveToFileSubfactorial.TabIndex = 8;
			this.buttonSaveToFileSubfactorial.Text = "Save to file";
			this.buttonSaveToFileSubfactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonSaveToFileSubfactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonSaveToFileSubfactorial.UseVisualStyleBackColor = true;
			this.buttonSaveToFileSubfactorial.Click += this.ButtonSaveToFileSubfactorial_Click;
			// 
			// buttonCopyToClipboardSubfactorial
			// 
			this.buttonCopyToClipboardSubfactorial.Image = (Image)resources.GetObject("buttonCopyToClipboardSubfactorial.Image");
			this.buttonCopyToClipboardSubfactorial.Location = new Point(156, 3);
			this.buttonCopyToClipboardSubfactorial.Name = "buttonCopyToClipboardSubfactorial";
			this.buttonCopyToClipboardSubfactorial.Size = new Size(130, 24);
			this.buttonCopyToClipboardSubfactorial.TabIndex = 7;
			this.buttonCopyToClipboardSubfactorial.Text = "Copy to clipboard";
			this.buttonCopyToClipboardSubfactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCopyToClipboardSubfactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonCopyToClipboardSubfactorial.UseVisualStyleBackColor = true;
			this.buttonCopyToClipboardSubfactorial.Click += this.ButtonCopyToClipboardSubfactorial_Click;
			// 
			// labelSubfactorial
			// 
			this.labelSubfactorial.AutoSize = true;
			this.labelSubfactorial.Location = new Point(8, 8);
			this.labelSubfactorial.Name = "labelSubfactorial";
			this.labelSubfactorial.Size = new Size(67, 15);
			this.labelSubfactorial.TabIndex = 6;
			this.labelSubfactorial.Text = "n[0..99999]:";
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
			this.textBoxSubfactorial.Size = new Size(504, 239);
			this.textBoxSubfactorial.TabIndex = 5;
			// 
			// numericUpDownSubfactorial
			// 
			this.numericUpDownSubfactorial.Location = new Point(81, 3);
			this.numericUpDownSubfactorial.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
			this.numericUpDownSubfactorial.Name = "numericUpDownSubfactorial";
			this.numericUpDownSubfactorial.Size = new Size(69, 23);
			this.numericUpDownSubfactorial.TabIndex = 4;
			this.numericUpDownSubfactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownSubfactorial.ValueChanged += this.NumericUpDownSubfactorial_ValueChanged;
			// 
			// tabPageDoubleFactorial
			// 
			this.tabPageDoubleFactorial.Controls.Add(this.buttonDigitFactorialDoubleFactorial);
			this.tabPageDoubleFactorial.Controls.Add(this.buttonSaveToFileDoubleFactorial);
			this.tabPageDoubleFactorial.Controls.Add(this.buttonCopyToClipboardDoubleFactorial);
			this.tabPageDoubleFactorial.Controls.Add(this.labelDoubleFactorial);
			this.tabPageDoubleFactorial.Controls.Add(this.textBoxDoubleFactorial);
			this.tabPageDoubleFactorial.Controls.Add(this.numericUpDownDoubleFactorial);
			this.tabPageDoubleFactorial.Location = new Point(4, 27);
			this.tabPageDoubleFactorial.Name = "tabPageDoubleFactorial";
			this.tabPageDoubleFactorial.Size = new Size(510, 277);
			this.tabPageDoubleFactorial.TabIndex = 5;
			this.tabPageDoubleFactorial.Text = "Doube Factorial";
			this.tabPageDoubleFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonDigitFactorialDoubleFactorial
			// 
			this.buttonDigitFactorialDoubleFactorial.Image = (Image)resources.GetObject("buttonDigitFactorialDoubleFactorial.Image");
			this.buttonDigitFactorialDoubleFactorial.Location = new Point(388, 3);
			this.buttonDigitFactorialDoubleFactorial.Name = "buttonDigitFactorialDoubleFactorial";
			this.buttonDigitFactorialDoubleFactorial.Size = new Size(119, 24);
			this.buttonDigitFactorialDoubleFactorial.TabIndex = 9;
			this.buttonDigitFactorialDoubleFactorial.Text = "Digit statistics";
			this.buttonDigitFactorialDoubleFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonDigitFactorialDoubleFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonDigitFactorialDoubleFactorial.UseVisualStyleBackColor = true;
			// 
			// buttonSaveToFileDoubleFactorial
			// 
			this.buttonSaveToFileDoubleFactorial.Image = (Image)resources.GetObject("buttonSaveToFileDoubleFactorial.Image");
			this.buttonSaveToFileDoubleFactorial.Location = new Point(292, 3);
			this.buttonSaveToFileDoubleFactorial.Name = "buttonSaveToFileDoubleFactorial";
			this.buttonSaveToFileDoubleFactorial.Size = new Size(90, 24);
			this.buttonSaveToFileDoubleFactorial.TabIndex = 8;
			this.buttonSaveToFileDoubleFactorial.Text = "Save to file";
			this.buttonSaveToFileDoubleFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonSaveToFileDoubleFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonSaveToFileDoubleFactorial.UseVisualStyleBackColor = true;
			this.buttonSaveToFileDoubleFactorial.Click += this.ButtonSaveToFileDoubleFactorial_Click;
			// 
			// buttonCopyToClipboardDoubleFactorial
			// 
			this.buttonCopyToClipboardDoubleFactorial.Image = (Image)resources.GetObject("buttonCopyToClipboardDoubleFactorial.Image");
			this.buttonCopyToClipboardDoubleFactorial.Location = new Point(156, 3);
			this.buttonCopyToClipboardDoubleFactorial.Name = "buttonCopyToClipboardDoubleFactorial";
			this.buttonCopyToClipboardDoubleFactorial.Size = new Size(130, 24);
			this.buttonCopyToClipboardDoubleFactorial.TabIndex = 7;
			this.buttonCopyToClipboardDoubleFactorial.Text = "Copy to clipboard";
			this.buttonCopyToClipboardDoubleFactorial.TextAlign = ContentAlignment.MiddleRight;
			this.buttonCopyToClipboardDoubleFactorial.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.buttonCopyToClipboardDoubleFactorial.UseVisualStyleBackColor = true;
			this.buttonCopyToClipboardDoubleFactorial.Click += this.ButtonCopyToClipboardDoubleFactorial_Click;
			// 
			// labelDoubleFactorial
			// 
			this.labelDoubleFactorial.AutoSize = true;
			this.labelDoubleFactorial.Location = new Point(8, 8);
			this.labelDoubleFactorial.Name = "labelDoubleFactorial";
			this.labelDoubleFactorial.Size = new Size(67, 15);
			this.labelDoubleFactorial.TabIndex = 6;
			this.labelDoubleFactorial.Text = "n[0..99999]:";
			// 
			// textBoxDoubleFactorial
			// 
			this.textBoxDoubleFactorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBoxDoubleFactorial.Location = new Point(3, 35);
			this.textBoxDoubleFactorial.MaxLength = int.MaxValue;
			this.textBoxDoubleFactorial.Multiline = true;
			this.textBoxDoubleFactorial.Name = "textBoxDoubleFactorial";
			this.textBoxDoubleFactorial.PlaceholderText = "Double Factorial";
			this.textBoxDoubleFactorial.ScrollBars = ScrollBars.Vertical;
			this.textBoxDoubleFactorial.Size = new Size(504, 239);
			this.textBoxDoubleFactorial.TabIndex = 5;
			// 
			// numericUpDownDoubleFactorial
			// 
			this.numericUpDownDoubleFactorial.Location = new Point(81, 3);
			this.numericUpDownDoubleFactorial.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
			this.numericUpDownDoubleFactorial.Name = "numericUpDownDoubleFactorial";
			this.numericUpDownDoubleFactorial.Size = new Size(69, 23);
			this.numericUpDownDoubleFactorial.TabIndex = 4;
			this.numericUpDownDoubleFactorial.TextAlign = HorizontalAlignment.Center;
			this.numericUpDownDoubleFactorial.ValueChanged += this.NumericUpDownDoubleFactorial_ValueChanged;
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = DockStyle.None;
			this.statusStrip.Items.AddRange(new ToolStripItem[] { this.toolStripStatusLabelTime, this.toolStripProgressBar });
			this.statusStrip.Location = new Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(518, 22);
			this.statusStrip.TabIndex = 4;
			// 
			// toolStripStatusLabelTime
			// 
			this.toolStripStatusLabelTime.AutoToolTip = true;
			this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
			this.toolStripStatusLabelTime.Size = new Size(401, 17);
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
			this.toolStripContainer.ContentPanel.Size = new Size(518, 308);
			this.toolStripContainer.Dock = DockStyle.Fill;
			this.toolStripContainer.Location = new Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new Size(518, 330);
			this.toolStripContainer.TabIndex = 1;
			this.toolStripContainer.TopToolStripPanelVisible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(518, 330);
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
			this.tabPageDoubleFactorial.ResumeLayout(false);
			this.tabPageDoubleFactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownDoubleFactorial).EndInit();
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
		private TabPage tabPageDoubleFactorial;
		private Label labelDoubleFactorial;
		private TextBox textBoxDoubleFactorial;
		private NumericUpDown numericUpDownDoubleFactorial;
		private Button buttonCopyToClipboardFactorial;
		private Button buttonDigitStatisticsFactorial;
		private Button buttonSaveToFileFactorial;
		private Button buttonDigitStatisticsOddFactorial;
		private Button buttonSaveToFileOddFactorial;
		private Button buttonCopyToClipboardOddFactorial;
		private Button buttonDigitStatisticsEvenFactorial;
		private Button buttonSaveToFileEvenFactorial;
		private Button buttonCopyToClipboardEvenFactorial;
		private Button buttonDigitStatisticsPrimeFactorial;
		private Button buttonSaveToFilePrimeFactorial;
		private Button buttonCopyToClipboardPrimeFactorial;
		private Button buttonDigitStatisticsSubfactorial;
		private Button buttonSaveToFileSubfactorial;
		private Button buttonCopyToClipboardSubfactorial;
		private Button buttonDigitFactorialDoubleFactorial;
		private Button buttonSaveToFileDoubleFactorial;
		private Button buttonCopyToClipboardDoubleFactorial;
	}
}
