using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools.Tutorials
{
	[Token(Token = "0x2000045")]
	public class ConstData : ScriptableObject
	{
		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x18")]
		public int maxhp;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x20")]
		public string type;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x28")]
		public int[] intarray;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x30")]
		public float[] floatarray;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x38")]
		public string[] stringarray;

		[Token(Token = "0x600019A")]
		[Address(RVA = "0xC05718", Offset = "0xC05718", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConstData()
		{
		}
	}
}
