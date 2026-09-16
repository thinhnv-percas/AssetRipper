using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePlugin
{
	[Serializable]
	[Token(Token = "0x2000012")]
	public class ExceptionWarningSettings
	{
		[SerializeField]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x10")]
		public ExceptionWarningDisplayMode displayMode;

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x13D58E0", Offset = "0x13D58E0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.displayMode = 3;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExceptionWarningSettings()
		{
			displayMode = ExceptionWarningDisplayMode.All;
		}
	}
}
