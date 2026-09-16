using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools.Tutorials
{
	[Token(Token = "0x2000040")]
	public class FirstLevels : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x2000041")]
		public class Boxes
		{
			[Token(Token = "0x40000D8")]
			[FieldOffset(Offset = "0x10")]
			public int[] box1;

			[Token(Token = "0x6000196")]
			[Address(RVA = "0xC056F8", Offset = "0xC056F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Boxes()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000042")]
		public class FirstLevelsData
		{
			[Token(Token = "0x40000D9")]
			[FieldOffset(Offset = "0x10")]
			public int emptyBox;

			[Token(Token = "0x40000DA")]
			[FieldOffset(Offset = "0x14")]
			public int fillBox;

			[Token(Token = "0x40000DB")]
			[FieldOffset(Offset = "0x18")]
			public int totalBox;

			[Token(Token = "0x40000DC")]
			[FieldOffset(Offset = "0x20")]
			public Boxes[] boxes;

			[Token(Token = "0x6000197")]
			[Address(RVA = "0xC05700", Offset = "0xC05700", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public FirstLevelsData()
			{
			}
		}

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x18")]
		public FirstLevelsData[] firstLevelsDatas;

		[Token(Token = "0x6000195")]
		[Address(RVA = "0xC056F0", Offset = "0xC056F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FirstLevels()
		{
		}
	}
}
