using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools.Tutorials
{
	[Token(Token = "0x2000047")]
	public class RankingData : ScriptableObject
	{
		[Token(Token = "0x2000048")]
		public enum Country
		{
			[Token(Token = "0x40000EA")]
			gb = 1,
			[Token(Token = "0x40000EB")]
			de = 2,
			[Token(Token = "0x40000EC")]
			fi = 3,
			[Token(Token = "0x40000ED")]
			be = 4
		}

		[Serializable]
		[Token(Token = "0x2000049")]
		public class Item
		{
			[Token(Token = "0x40000EE")]
			[FieldOffset(Offset = "0x10")]
			public int ranking;

			[Token(Token = "0x40000EF")]
			[FieldOffset(Offset = "0x18")]
			public string driver;

			[Token(Token = "0x40000F0")]
			[FieldOffset(Offset = "0x20")]
			public string constructor;

			[Token(Token = "0x40000F1")]
			[FieldOffset(Offset = "0x28")]
			public int score;

			[Token(Token = "0x40000F2")]
			[FieldOffset(Offset = "0x2C")]
			public int podium;

			[Token(Token = "0x40000F3")]
			[FieldOffset(Offset = "0x30")]
			public Country country;

			[Token(Token = "0x40000F4")]
			[FieldOffset(Offset = "0x38")]
			public string[] win;

			[Token(Token = "0x600019D")]
			[Address(RVA = "0xC05730", Offset = "0xC05730", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Item()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200004A")]
		public class ItemDictionary : SerializableDictionary<int, Item>
		{
			[Token(Token = "0x600019E")]
			[Address(RVA = "0xC05738", Offset = "0xC05738", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35656]) = v37;\nL_001A:\n\tZitga.CsvTools.SerializableDictionary`2<System.Int32, Zitga.CsvTools.Tutorials.RankingData+Item>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ItemDictionary()
			{
			}
		}

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x18")]
		public ItemDictionary itemDict;

		[Token(Token = "0x600019C")]
		[Address(RVA = "0xC05728", Offset = "0xC05728", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RankingData()
		{
		}
	}
}
