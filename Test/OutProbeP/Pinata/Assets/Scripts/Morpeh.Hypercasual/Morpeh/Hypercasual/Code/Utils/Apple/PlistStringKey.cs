using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Utils.Apple
{
	[Serializable]
	[Token(Token = "0x200000C")]
	public class PlistStringKey
	{
		[Delayed]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Delayed]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x18")]
		public string Value;

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x16337CC", Offset = "0x16337CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlistStringKey()
		{
		}
	}
}
