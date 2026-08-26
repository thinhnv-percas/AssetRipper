using DevXUnityUnpackerTools.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class BinaryAnalizerDlg : Form
{
	internal IContainer _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A;

	internal ToolStrip _0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020;

	internal ToolStripButton _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A;

	internal ToolStripSeparator _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A;

	public BinaryAnalizerControl binaryAnalizerControl;

	public BinaryAnalizerDlg()
	{
		_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020();
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020(object _0020, EventArgs _0020_000A)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "Open code file";
		openFileDialog.FileName = null;
		openFileDialog.Filter = "All file|*.*";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			binaryAnalizerControl._0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A(Path.GetFileNameWithoutExtension(openFileDialog.FileName), File.ReadAllBytes(openFileDialog.FileName));
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A != null)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A.Dispose();
		}
		base.Dispose(disposing);
	}

	internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020()
	{
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020 = new ToolStrip();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A = new ToolStripButton();
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A = new ToolStripSeparator();
		binaryAnalizerControl = new BinaryAnalizerControl();
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.SuspendLayout();
		SuspendLayout();
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Items.AddRange(new ToolStripItem[2]
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A,
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A
		});
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Location = new Point(0, 0);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Name = "toolStrip1";
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Size = new Size(986, 25);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.TabIndex = 0;
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Text = TranslationManager.TryGetTranslated(-409732557);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A.Image = Resources.OpenFolder16;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A.Name = "bt_OpenBinFile";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A.Size = new Size(111, 22);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A.Text = TranslationManager.TryGetTranslated(-744652303);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020;
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A.Name = "toolStripSeparator1";
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A.Size = new Size(6, 25);
		binaryAnalizerControl.Dock = DockStyle.Fill;
		binaryAnalizerControl.Location = new Point(0, 25);
		binaryAnalizerControl.Name = "binaryAnalizerControl";
		binaryAnalizerControl.Size = new Size(986, 585);
		binaryAnalizerControl.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(986, 610);
		base.Controls.Add(binaryAnalizerControl);
		base.Controls.Add(_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020);
		base.Name = "BinaryAnalizerDlg";
		Text = TranslationManager.TryGetTranslated(-2107155431);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.ResumeLayout(performLayout: false);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
