using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Morpeh.Hypercasual.Code.Utils.Apple
{
	[Serializable]
	[Token(Token = "0x2000010")]
	public class PlistKeys
	{
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x10")]
		public List<PlistStringKey> StringKeys;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x18")]
		public List<PlistIntKey> IntKeys;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x20")]
		public List<PlistBoolKey> BoolKeys;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x28")]
		public List<PlistFloatKey> FloatKeys;

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x16337C4", Offset = "0x16337C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlistKeys()
		{
		}
	}
}
