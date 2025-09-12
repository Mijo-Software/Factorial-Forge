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
			this.statusStrip = new StatusStrip();
			this.toolStripProgressBar = new ToolStripProgressBar();
			this.toolStripContainer = new ToolStripContainer();
			this.tabControl.SuspendLayout();
			this.tabPageFactorial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFactorial).BeginInit();
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
			this.tabControl.Dock = DockStyle.Fill;
			this.tabControl.Location = new Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = true;
			this.tabControl.Size = new Size(253, 227);
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
			this.tabPageFactorial.Size = new Size(245, 196);
			this.tabPageFactorial.TabIndex = 0;
			this.tabPageFactorial.Text = "Factorial";
			this.tabPageFactorial.UseVisualStyleBackColor = true;
			// 
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new Point(8, 8);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new Size(67, 15);
			this.labelNumber.TabIndex = 3;
			this.labelNumber.Text = "n[0..10000]:";
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
			this.textBoxFactorial.Size = new Size(239, 158);
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
			// statusStrip
			// 
			this.statusStrip.Dock = DockStyle.None;
			this.statusStrip.Items.AddRange(new ToolStripItem[] { this.toolStripProgressBar });
			this.statusStrip.Location = new Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(253, 22);
			this.statusStrip.TabIndex = 4;
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
			this.toolStripContainer.ContentPanel.Size = new Size(253, 227);
			this.toolStripContainer.Dock = DockStyle.Fill;
			this.toolStripContainer.Location = new Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new Size(253, 249);
			this.toolStripContainer.TabIndex = 1;
			this.toolStripContainer.TopToolStripPanelVisible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(253, 249);
			this.Controls.Add(this.toolStripContainer);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Factorial Forge";
			this.tabControl.ResumeLayout(false);
			this.tabPageFactorial.ResumeLayout(false);
			this.tabPageFactorial.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFactorial).EndInit();
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
		private Label labelNumber;
		private StatusStrip statusStrip;
		private ToolStripProgressBar toolStripProgressBar;
		private ToolStripContainer toolStripContainer;
	}
}
