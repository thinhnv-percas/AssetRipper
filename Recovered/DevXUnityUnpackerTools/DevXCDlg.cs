using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class DevXCDlg : Form
{
	private IContainer _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A;

	public DevXCControl devXCControl;

	public DevXCDlg()
	{
		_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A != null)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A.Dispose();
		}
		base.Dispose(disposing);
	}

	private void _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020()
	{
		devXCControl = new DevXCControl();
		SuspendLayout();
		devXCControl.Dock = DockStyle.Fill;
		devXCControl.Location = new Point(0, 0);
		devXCControl.Name = "devXCControl";
		devXCControl.Size = new Size(1103, 718);
		devXCControl.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1103, 718);
		base.Controls.Add(devXCControl);
		base.Name = "DevXCDlg";
		Text = TranslationManager.TryGetTranslated(107627491);
		ResumeLayout(performLayout: false);
	}
}
