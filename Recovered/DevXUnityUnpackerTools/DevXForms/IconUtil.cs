using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DevXForms
{
	public class IconUtil
	{
		private struct _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A
		{
			public IntPtr hIcon;

			public int iIcon;

			public uint dwAttributes;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string szDisplayName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		private const int _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A = 256;

		private const int _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020 = 1;

		private const int _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A = 0;

		[DllImport("Shell32.dll")]
		private static extern IntPtr SHGetFileInfo(string _0020, uint _0020_000A, ref _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A _0020_0020, int _0020_000A_000A, uint _0020_000A_0020);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool DestroyIcon(IntPtr _0020);

		public static Bitmap GetIcon(string filename)
		{
			_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A = default(_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A);
			SHGetFileInfo(filename, 0u, ref _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A, Marshal.SizeOf((object)_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A), 257u);
			Bitmap result = Icon.FromHandle(_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A.hIcon).ToBitmap();
			DestroyIcon(_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A.hIcon);
			return result;
		}
	}
}
