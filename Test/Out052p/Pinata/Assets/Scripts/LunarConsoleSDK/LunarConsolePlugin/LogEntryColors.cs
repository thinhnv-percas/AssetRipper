using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePlugin
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public class LogEntryColors
	{
		[SerializeField]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x10")]
		public Color32 foreground;

		[SerializeField]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x14")]
		public Color32 background;

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x13D58F0", Offset = "0x13D58F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LogEntryColors()
		{
		}
	}
}
