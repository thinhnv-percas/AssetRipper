using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FMOD
{
	public struct StringWrapper
	{
		private IntPtr _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020;

		public static implicit operator string(StringWrapper fstring)
		{
			if (fstring._0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020 == IntPtr.Zero)
			{
				return "";
			}
			int i;
			for (i = 0; Marshal.ReadByte(fstring._0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020, i) != 0; i++)
			{
			}
			if (i > 0)
			{
				byte[] array = new byte[i];
				Marshal.Copy(fstring._0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020, array, 0, i);
				return Encoding.UTF8.GetString(array, 0, i);
			}
			return "";
		}
	}
}
