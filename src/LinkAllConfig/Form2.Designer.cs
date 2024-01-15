namespace LinkAllConfig;

partial class Form2
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
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
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		btnStartStop = new Button();
		btnPauseContinue = new Button();
		progressBar = new ProgressBar();
		SuspendLayout();
		// 
		// btnStartStop
		// 
		btnStartStop.Location = new Point(89, 64);
		btnStartStop.Name = "btnStartStop";
		btnStartStop.Size = new Size(192, 23);
		btnStartStop.TabIndex = 0;
		btnStartStop.Text = "btnStartStop";
		btnStartStop.UseVisualStyleBackColor = true;
		btnStartStop.Click += btnStartStop_ClickAsync;
		// 
		// btnPauseContinue
		// 
		btnPauseContinue.Location = new Point(89, 120);
		btnPauseContinue.Name = "btnPauseContinue";
		btnPauseContinue.Size = new Size(192, 23);
		btnPauseContinue.TabIndex = 0;
		btnPauseContinue.Text = "btnPauseContinue";
		btnPauseContinue.UseVisualStyleBackColor = true;
		btnPauseContinue.Click += BtnPauseContinue_ClickAsync;
		// 
		// progressBar
		// 
		progressBar.Location = new Point(12, 415);
		progressBar.Name = "progressBar";
		progressBar.Size = new Size(776, 23);
		progressBar.TabIndex = 1;
		// 
		// Form2
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(progressBar);
		Controls.Add(btnPauseContinue);
		Controls.Add(btnStartStop);
		Name = "Form2";
		Text = "Form2";
		Load += Form2_Load;
		ResumeLayout(false);
	}

	#endregion

	private Button btnStartStop;
	private Button btnPauseContinue;
	private ProgressBar progressBar;
}