using System;

namespace LZ4
{
	[Flags]
	public enum LZ4StreamFlags
	{
		None = 0x0,
		InteractiveRead = 0x1,
		HighCompression = 0x2,
		IsolateInnerStream = 0x4,
		Default = 0x0
	}
}
