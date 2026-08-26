using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	public struct ERRORCALLBACK_INFO
	{
		public RESULT result;

		public ERRORCALLBACK_INSTANCETYPE instancetype;

		public IntPtr instance;

		internal IntPtr _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A;

		internal IntPtr _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020;

		public string functionname => Marshal.PtrToStringAnsi(_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A);

		public string functionparams => Marshal.PtrToStringAnsi(_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020);
	}
}
