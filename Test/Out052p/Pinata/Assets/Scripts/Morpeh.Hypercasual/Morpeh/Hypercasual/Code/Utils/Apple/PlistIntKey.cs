using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Utils.Apple
{
	[Serializable]
	[Token(Token = "0x200000E")]
	public class PlistIntKey
	{
		[Delayed]
		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Delayed]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x18")]
		public int Value;

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x16337BC", Offset = "0x16337BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlistIntKey()
		{
		}
	}
}
