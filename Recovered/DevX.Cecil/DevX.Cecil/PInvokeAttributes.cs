using System;

namespace DevX.Cecil
{
	[Flags]
	public enum PInvokeAttributes : ushort
	{
		NoMangle = 0x1,
		CharSetMask = 0x6,
		CharSetNotSpec = 0x0,
		CharSetAnsi = 0x2,
		CharSetUnicode = 0x4,
		CharSetAuto = 0x6,
		SupportsLastError = 0x40,
		CallConvMask = 0x700,
		CallConvWinapi = 0x100,
		CallConvCdecl = 0x200,
		CallConvStdCall = 0x300,
		CallConvThiscall = 0x400,
		CallConvFastcall = 0x500
	}
}
