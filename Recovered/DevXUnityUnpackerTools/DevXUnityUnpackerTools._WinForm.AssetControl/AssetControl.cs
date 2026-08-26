using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevXUnityUnpackerTools._WinForm.AssetControl
{
	public class AssetControl : UserControl
	{
		internal IContainer _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A;

		internal PropertyGrid _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020;

		public AssetControl()
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

		internal void _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020()
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020 = new PropertyGrid();
			SuspendLayout();
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020.Location = new Point(210, 40);
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020.Name = "propertyGrid1";
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020.Size = new Size(203, 165);
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020);
			base.Name = "AssetControl";
			base.Size = new Size(694, 222);
			ResumeLayout(performLayout: false);
		}
	}
}
