using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Serializable]
	[Token(Token = "0x2000018")]
	public class MultiPackData : ShopItemData
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000019")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400002D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400002E")]
			public static Action<ShopItemData> _003C_003E9__3_0;

			[Token(Token = "0x400002F")]
			public static Func<ShopItemData, ShopItemData> _003C_003E9__5_0;

			[Token(Token = "0x600004D")]
			[Address(RVA = "0x81D6558", Offset = "0x81D6558", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.RewardSystem.MultiPackData+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600004E")]
			[Address(RVA = "0x81D65BC", Offset = "0x81D65BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003COnPurchase_003Eb__3_0(ShopItemData data)
			{
				ShopItemData shopItemData = default(ShopItemData);
				shopItemData.OnPurchase();
			}

			internal ShopItemData _003CCopy_003Eb__5_0(ShopItemData data)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MultiPackData._003C_003Ec::_003CCopy_003Eb__5_0");
				return default;
			}
		}

		[SerializeReference]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x40")]
		public List<ShopItemData> dataList;

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81D5DA8", Offset = "0x81D5DA8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.sourceType = type;\n\tthis.dataList = dataList;\n\tthis.customTransactionData = customData;\n\treturn;\n")]
		public MultiPackData(string type, List<ShopItemData> dataList, string customData = "")
		{
			sourceType = type;
			this.dataList = dataList;
			customTransactionData = customData;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x81D5E0C", Offset = "0x81D5E0C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tthis.dataList = v64;\n\tv87 = count < 1;\n\tif (v87) goto L_0089;\n\tv191 = count;\n\tgoto L_0057;\nL_004A:\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::Add(v147, v195);\n\tv133 = v191 == 1;\n\tv191 = v191 - 1;\n\tif (v133) goto L_0089;\nL_0057:\n\tv109 = lootDrop.LootType;\n\tv195 = Unco.RewardSystem.RewardExtensions::ConvertToShopItemData(&v109 @ stack_-70_v3 (System.String), sourceType, \"\");\n\tv147 = this.dataList;\n\tgoto L_004A;\nL_0089:\n\tthis.sourceType = sourceType;\n\treturn;\nL_002A:\n\tSystem.Object::.ctor(this);\n\tv64 = new System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>();\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::.ctor(v64);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe MultiPackData(string sourceType, LootDrop lootDrop, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MultiPackData::.ctor");
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x81D6174", Offset = "0x81D6174", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv103 = this.dataList;\n\tgoto L_0017;\nL_0017:\n\tv54 = v52.<>9__3_0 == 0;\n\tif (v54) goto L_0047;\n\tv101 = v52.<>9__3_0;\nL_0027:\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::ForEach(v103, v101);\n\treturn;\nL_0047:\n\tgoto L_004F;\n\tv158 = this.dataList == 0;\n\tv98 = ~v158;\n\tv101 = v133;\n\tv103 = v103;\n\tif (v98) goto L_0027;\n\tthrow System.NullReferenceException;\nL_004F:\n\tv133 = new System.Action`1<Unco.RewardSystem.ShopItemData>();\n\tSystem.Action`1<Unco.RewardSystem.ShopItemData>::.ctor(v133, v128.<>9, Il2CppMethodInfo);\n\tv156.<>9__3_0 = v133;\n")]
		public override void OnPurchase()
		{
			List<ShopItemData> list = dataList;
			Action<object> action;
			if (_003C_003Ec._003C_003E9__3_0 != null)
			{
				action = (Action<object>)_003C_003Ec._003C_003E9__3_0;
			}
			else
			{
				Action<ShopItemData> action2 = (_003C_003Ec._003C_003E9__3_0 = delegate
				{
					ShopItemData shopItemData = default(ShopItemData);
					shopItemData.OnPurchase();
				});
				bool flag = dataList == null;
				bool flag2 = !flag;
				action = (Action<object>)action2;
				list = list;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			list.ForEach(action);
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x81D629C", Offset = "0x81D629C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv49 = new System.Collections.Generic.Queue`1<Unco.RewardSystem.ShopItemData>();\n\tSystem.Collections.Generic.Queue`1<Unco.RewardSystem.ShopItemData>::.ctor(v49, this.dataList);\n\treturn v49;\n")]
		public Queue<ShopItemData> ToQueue()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MultiPackData::ToQueue");
			return default;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x81D631C", Offset = "0x81D631C", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = 0xB79A000;\n\tv26 = *([B79A13F]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0035;\n\tv30 = *([B79A13E]) & 1;\n\tv31 = v30 == 0;\n\tif (v31) goto L_0040;\nL_0019:\n\tv60 = System.Object::MemberwiseClone(this);\n\tv72 = v60 == 0;\n\tv73 = ~v72;\nL_FFFFFFFF:\n\tv86 = v60;\n\tif (v73) goto L_0057;\nL_FFFFFFFF:\n\tv149 = v60;\n\tgoto L_008B;\nL_0035:\n\t*([v24 @ X19_v1+13F]) = 1;\n\tv326 = *([B79A13E]) & 1;\n\tv327 = v326 == 0;\n\tv53 = ~v327;\n\tif (v53) goto L_0019;\nL_0040:\n\t*([B79A13E]) = 1;\n\tv77 = System.Object::MemberwiseClone(this);\n\tv84 = v77 == 0;\nL_FFFFFFFF:\n\tv86 = v77;\nL_FFFFFFFF:\n\tv149 = v77;\n\tif (v84) goto L_008B;\nL_0057:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v169_asT @ TEMPCOND_v5 (Unco.RewardSystem.ShopItemData), typeof(Unco.RewardSystem.ShopItemData), v86 @ X19_v5 (System.Object)\n\tv169 = v169_asT == 0;\n\tif (v169) goto L_00D2;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v111_asT @ TEMPCOND_v7 (Unco.RewardSystem.MultiPackData), typeof(Unco.RewardSystem.MultiPackData), v86 @ X19_v5 (System.Object)\n\tv111 = v111_asT == 0;\nL_FFFFFFFF:\n\tv149 = v86;\n\tif (v111) goto L_00D2;\nL_008B:\n\tgoto L_0096;\n\tgoto L_00A4;\nL_FFFFFFFF:\n\tv263 = v283;\n\tv244 = v149 == 0;\n\tif (v244) goto L_00D3;\n\t*([v149 @ X19_v3 (System.Object)+40]) = v242;\n\treturn v149;\nL_00D2:\n\tv194 = new System.InvalidCastException();\nL_00D3:\n\tthrow v194;\nL_0096:\n\tv209 = v207.<>9__5_0 == 0;\n\tv210 = ~v209;\nL_FFFFFFFF:\n\tv263 = v207.<>9__5_0;\n\tif (v210) goto L_00B5;\nL_00A4:\n\tv283 = new System.Func`2<Unco.RewardSystem.ShopItemData, Unco.RewardSystem.ShopItemData>();\n\tSystem.Func`2<Unco.RewardSystem.ShopItemData, Unco.RewardSystem.ShopItemData>::.ctor(v283, v278.<>9, Il2CppMethodInfo);\n\tv332.<>9__5_0 = v283;\nL_00B5:\n\tv271 = System.Linq.Enumerable::Select(this.dataList, v263);\n\tv242 = new System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>();\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::.ctor(v242, v271);\n")]
		public override ShopItemData Copy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MultiPackData::Copy");
			return default;
		}
	}
}
