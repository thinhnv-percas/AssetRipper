using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Utils.Apple
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public class PlistFloatKey
	{
		[Delayed]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Delayed]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x18")]
		public float Value;

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x16337B4", Offset = "0x16337B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlistFloatKey()
		{
		}
	}
}
