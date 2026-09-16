using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools.Tutorials
{
	[Token(Token = "0x2000043")]
	public class RandomLevels : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x2000044")]
		public class RandomLevelsData
		{
			[Token(Token = "0x40000DE")]
			[FieldOffset(Offset = "0x10")]
			public int emptyBox;

			[Token(Token = "0x40000DF")]
			[FieldOffset(Offset = "0x14")]
			public int fillBox;

			[Token(Token = "0x40000E0")]
			[FieldOffset(Offset = "0x18")]
			public int totalBox;

			[Token(Token = "0x40000E1")]
			[FieldOffset(Offset = "0x1C")]
			public int numberColors;

			[Token(Token = "0x6000199")]
			[Address(RVA = "0xC05710", Offset = "0xC05710", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public RandomLevelsData()
			{
			}
		}

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x18")]
		public RandomLevelsData[] randomlevelsDatas;

		[Token(Token = "0x6000198")]
		[Address(RVA = "0xC05708", Offset = "0xC05708", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RandomLevels()
		{
		}
	}
}
