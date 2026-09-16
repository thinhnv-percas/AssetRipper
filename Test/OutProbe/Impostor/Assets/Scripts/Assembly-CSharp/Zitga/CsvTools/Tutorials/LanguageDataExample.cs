using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools.Tutorials
{
	[Token(Token = "0x2000046")]
	public class LanguageDataExample : ScriptableObject
	{
		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x18")]
		public StringStringDictionary data;

		[Token(Token = "0x600019B")]
		[Address(RVA = "0xC05720", Offset = "0xC05720", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LanguageDataExample()
		{
		}
	}
}
