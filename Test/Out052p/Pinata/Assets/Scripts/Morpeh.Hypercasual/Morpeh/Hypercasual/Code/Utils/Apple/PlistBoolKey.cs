using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Utils.Apple
{
	[Serializable]
	[Token(Token = "0x200000D")]
	public class PlistBoolKey
	{
		[Delayed]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x18")]
		public bool Value;

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x16337AC", Offset = "0x16337AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlistBoolKey()
		{
		}
	}
}
