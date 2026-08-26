using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	public struct TAG
	{
		public TAGTYPE type;

		public TAGDATATYPE datatype;

		private IntPtr _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A;

		public IntPtr data;

		public uint datalen;

		public bool updated;

		public string name => Marshal.PtrToStringAnsi(_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A);
	}
}
