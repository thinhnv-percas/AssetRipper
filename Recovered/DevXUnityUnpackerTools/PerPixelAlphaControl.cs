using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[ToolboxBitmap(typeof(PictureBox))]
public class PerPixelAlphaControl : PictureBox
{
	internal struct _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A
	{
		public int x;

		public int y;

		public _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	internal struct _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020
	{
		public int cx;

		public int cy;

		public _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020(int cx, int cy)
		{
			this.cx = cx;
			this.cy = cy;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A
	{
		public byte Blue;

		public byte Green;

		public byte Red;

		public byte Alpha;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020
	{
		public byte BlendOp;

		public byte BlendFlags;

		public byte SourceConstantAlpha;

		public byte AlphaFormat;
	}

	public const int WM_CREATE = 1;

	internal const int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020 = 524288;

	internal const int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A = 2;

	internal const int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020 = 132;

	internal const int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A = 2;

	internal const byte _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020 = 0;

	internal const byte _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A = 1;

	protected override void WndProc(ref Message message)
	{
		if (message.Msg == 1 && base.Image != null)
		{
			SelectBitmap(new Bitmap(base.Image));
		}
		if (message.Msg == 132)
		{
			message.Result = (IntPtr)2;
		}
		else
		{
			base.WndProc(ref message);
		}
	}

	public void SelectBitmap(Bitmap bitmap)
	{
		SelectBitmap(bitmap, 255);
	}

	public void SelectBitmap(Bitmap bitmap, int opacity)
	{
		if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
		{
			throw new ApplicationException("The bitmap must be 32bpp with alpha-channel.");
		}
		IntPtr dC = GetDC(IntPtr.Zero);
		IntPtr intPtr = CreateCompatibleDC(dC);
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr _0020_000A = IntPtr.Zero;
		try
		{
			intPtr2 = bitmap.GetHbitmap(Color.FromArgb(0));
			_0020_000A = SelectObject(intPtr, intPtr2);
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020 _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020 = new _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020(bitmap.Width, bitmap.Height);
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A(0, 0);
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A2 = new _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A(base.Left, base.Top);
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020 _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020 = default(_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020);
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020.BlendOp = 0;
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020.BlendFlags = 0;
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020.SourceConstantAlpha = (byte)opacity;
			_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020.AlphaFormat = 1;
			UpdateLayeredWindow(base.Handle, dC, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A2, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020, intPtr, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A, 0, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020, 2);
		}
		finally
		{
			ReleaseDC(IntPtr.Zero, dC);
			if (intPtr2 != IntPtr.Zero)
			{
				SelectObject(intPtr, _0020_000A);
				DeleteObject(intPtr2);
			}
			DeleteDC(intPtr);
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool UpdateLayeredWindow(IntPtr _0020, IntPtr _0020_000A, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A _0020_0020, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020 _0020_000A_000A, IntPtr _0020_000A_0020, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A _0020_0020_000A, int _0020_0020_0020, ref _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020 _0020_000A_000A_000A, int _0020_000A_000A_0020);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern IntPtr CreateCompatibleDC(IntPtr _0020);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern IntPtr GetDC(IntPtr _0020);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern int ReleaseDC(IntPtr _0020, IntPtr _0020_000A);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool DeleteDC(IntPtr _0020);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern IntPtr SelectObject(IntPtr _0020, IntPtr _0020_000A);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool DeleteObject(IntPtr _0020);
}
