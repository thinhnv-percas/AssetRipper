using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Utils.Apple
{
	[Serializable]
	[Token(Token = "0x200000A")]
	public class iOSFrameworkDescription
	{
		[Delayed]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x18")]
		public bool IsWeak;

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x16337D4", Offset = "0x16337D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public iOSFrameworkDescription()
		{
		}
	}
}
