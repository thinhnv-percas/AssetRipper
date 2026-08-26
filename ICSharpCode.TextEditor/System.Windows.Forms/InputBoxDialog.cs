using System.Drawing;

namespace System.Windows.Forms;

internal class InputBoxDialog : Form
{
	private Label lblPrompt;

	public TextBox txtInput;

	private Button btnOK;

	private Button btnCancel;

	public InputBoxDialog(string prompt, string title)
		: this(prompt, title, int.MinValue, int.MinValue)
	{
	}

	public InputBoxDialog(string prompt, string title, int xPos, int yPos)
	{
		if (xPos != int.MinValue && yPos != int.MinValue)
		{
			base.StartPosition = FormStartPosition.Manual;
			base.Location = new Point(xPos, yPos);
		}
		InitializeComponent();
		lblPrompt.Text = prompt;
		Text = title;
		SizeF sizeF = CreateGraphics().MeasureString(prompt, lblPrompt.Font, lblPrompt.Width);
		if (sizeF.Height > (float)lblPrompt.Height)
		{
			base.Height += (int)sizeF.Height - lblPrompt.Height;
		}
		txtInput.SelectionStart = 0;
		txtInput.SelectionLength = txtInput.Text.Length;
		txtInput.Focus();
	}

	private void InitializeComponent()
	{
		this.lblPrompt = new System.Windows.Forms.Label();
		this.txtInput = new System.Windows.Forms.TextBox();
		this.btnOK = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.lblPrompt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblPrompt.BackColor = System.Drawing.SystemColors.Control;
		this.lblPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPrompt.Location = new System.Drawing.Point(12, 9);
		this.lblPrompt.Name = "lblPrompt";
		this.lblPrompt.Size = new System.Drawing.Size(302, 71);
		this.lblPrompt.TabIndex = 3;
		this.txtInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtInput.Location = new System.Drawing.Point(8, 88);
		this.txtInput.Name = "txtInput";
		this.txtInput.Size = new System.Drawing.Size(381, 20);
		this.txtInput.TabIndex = 0;
		this.txtInput.Text = "";
		this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnOK.Location = new System.Drawing.Point(326, 8);
		this.btnOK.Name = "btnOK";
		this.btnOK.Size = new System.Drawing.Size(64, 24);
		this.btnOK.TabIndex = 1;
		this.btnOK.Text = "&OK";
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(326, 40);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(64, 24);
		this.btnCancel.TabIndex = 2;
		this.btnCancel.Text = "&Cancel";
		base.AcceptButton = this.btnOK;
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		base.CancelButton = this.btnCancel;
		base.ClientSize = new System.Drawing.Size(398, 117);
		base.Controls.Add(this.txtInput);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnOK);
		base.Controls.Add(this.lblPrompt);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "InputBoxDialog";
		base.ResumeLayout(false);
	}
}
