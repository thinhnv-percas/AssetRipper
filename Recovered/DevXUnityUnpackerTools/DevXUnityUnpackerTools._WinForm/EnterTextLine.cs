using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevXUnityUnpackerTools._WinForm
{
	public class EnterTextLine : Form
	{
		internal static EnterTextLine _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A = new EnterTextLine();

		internal bool _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020;

		internal IContainer _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A;

		internal Button _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020;

		public TextBox textBox;

		internal static EnterTextLine _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A()
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A.Show();
			return _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		internal bool _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020()
		{
			return _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020(null);
		}

		internal bool _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020(IWin32Window _0020)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020 = false;
			ShowDialog(_0020);
			return _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020;
		}

		public EnterTextLine()
		{
			_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020();
		}

		internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020(object _0020, EventArgs _0020_000A)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020 = true;
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
			textBox = new TextBox();
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020 = new Button();
			SuspendLayout();
			textBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			textBox.Location = new Point(13, 12);
			textBox.Name = "textBox";
			textBox.ScrollBars = ScrollBars.Both;
			textBox.Size = new Size(598, 20);
			textBox.TabIndex = 0;
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.DialogResult = DialogResult.OK;
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.ImageAlign = ContentAlignment.MiddleLeft;
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.Location = new Point(493, 50);
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.Name = "bt_Save";
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.Size = new Size(118, 25);
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.TabIndex = 4;
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.Text = TranslationManager.TryGetTranslated(-837830687);
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.UseVisualStyleBackColor = true;
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020.Click += _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020;
			base.AcceptButton = _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(623, 87);
			base.Controls.Add(_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020);
			base.Controls.Add(textBox);
			base.MinimizeBox = false;
			base.Name = "EnterTextLine";
			base.StartPosition = FormStartPosition.CenterParent;
			Text = TranslationManager.TryGetTranslated(-462580864);
			base.TopMost = true;
			ResumeLayout(performLayout: false);
			PerformLayout();
		}
	}
}
