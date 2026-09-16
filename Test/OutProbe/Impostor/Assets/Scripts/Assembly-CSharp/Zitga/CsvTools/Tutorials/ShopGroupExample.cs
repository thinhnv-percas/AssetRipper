using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools.Tutorials
{
	[Token(Token = "0x200004B")]
	public class ShopGroupExample : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x200004C")]
		public class Resource
		{
			[Token(Token = "0x40000F7")]
			[FieldOffset(Offset = "0x10")]
			public int resType;

			[Token(Token = "0x40000F8")]
			[FieldOffset(Offset = "0x14")]
			public int resId;

			[Token(Token = "0x40000F9")]
			[FieldOffset(Offset = "0x18")]
			public int resNumber;

			[Token(Token = "0x60001A0")]
			[Address(RVA = "0xC05788", Offset = "0xC05788", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Resource()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200004D")]
		public class Reward
		{
			[Token(Token = "0x40000FA")]
			[FieldOffset(Offset = "0x10")]
			public int moneyType;

			[Token(Token = "0x40000FB")]
			[FieldOffset(Offset = "0x14")]
			public int moneyValue;

			[Token(Token = "0x60001A1")]
			[Address(RVA = "0xC05790", Offset = "0xC05790", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Reward()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200004E")]
		public class RewardStock
		{
			[Token(Token = "0x40000FC")]
			[FieldOffset(Offset = "0x10")]
			public int id;

			[Token(Token = "0x40000FD")]
			[FieldOffset(Offset = "0x14")]
			public int rate;

			[Token(Token = "0x40000FE")]
			[FieldOffset(Offset = "0x18")]
			public int stock;

			[Token(Token = "0x40000FF")]
			[FieldOffset(Offset = "0x20")]
			public Resource[] resources;

			[Token(Token = "0x4000100")]
			[FieldOffset(Offset = "0x28")]
			public Reward reward;

			[Token(Token = "0x60001A2")]
			[Address(RVA = "0xC05798", Offset = "0xC05798", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public RewardStock()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200004F")]
		public class Shop
		{
			[Token(Token = "0x4000101")]
			[FieldOffset(Offset = "0x10")]
			public int shopType;

			[Token(Token = "0x4000102")]
			[FieldOffset(Offset = "0x14")]
			public int groupRate;

			[Token(Token = "0x4000103")]
			[FieldOffset(Offset = "0x18")]
			public RewardStock[] rewardStocks;

			[Token(Token = "0x60001A3")]
			[Address(RVA = "0xC057A0", Offset = "0xC057A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Shop()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000050")]
		public class ShopGroup
		{
			[Token(Token = "0x4000104")]
			[FieldOffset(Offset = "0x10")]
			public int groupId;

			[Token(Token = "0x4000105")]
			[FieldOffset(Offset = "0x18")]
			public int[] stageMin;

			[Token(Token = "0x4000106")]
			[FieldOffset(Offset = "0x20")]
			public int stageMax;

			[Token(Token = "0x4000107")]
			[FieldOffset(Offset = "0x28")]
			public Shop[] shops;

			[Token(Token = "0x60001A4")]
			[Address(RVA = "0xC057A8", Offset = "0xC057A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ShopGroup()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000051")]
		public class ShopGroupDictionary : SerializableDictionary<int, ShopGroup>
		{
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0xC057B0", Offset = "0xC057B0", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35657]) = v37;\nL_001A:\n\tZitga.CsvTools.SerializableDictionary`2<System.Int32, Zitga.CsvTools.Tutorials.ShopGroupExample+ShopGroup>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ShopGroupDictionary()
			{
			}
		}

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x18")]
		public ShopGroup[] shopGroups;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x20")]
		public ShopGroupDictionary shopDict;

		[Token(Token = "0x600019F")]
		[Address(RVA = "0xC05780", Offset = "0xC05780", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ShopGroupExample()
		{
		}
	}
}
