using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200006F")]
	public class MetaUpgradeSystem : UpdateSystem
	{
		[SerializeField]
		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x28")]
		private GlobalEvent clickEvent;

		[SerializeField]
		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x30")]
		private GlobalVariableInt metaLevel;

		[SerializeField]
		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x38")]
		private GlobalVariableInt coins;

		[SerializeField]
		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x40")]
		private string metaUpgradeKey;

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0xCC687C", Offset = "0xCC687C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnAwake()
		{
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0xCC6880", Offset = "0xCC6880", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1ECBD40]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, deltaTime, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202376C]) = v44;\nL_001A:\n\tv49 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.clickEvent);\n\tv51 = v49 == 0;\n\tif (v51) goto L_006F;\n\tv64 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.metaLevel);\n\tv108 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tv110 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.MetaUpgradeConfig>::get_Item(v108.MetaUpgradeConfigs, this.metaUpgradeKey);\n\tv173 = v110.Data;\n\tv182 = v173._size < v64;\n\tv96 = ~v182;\n\tv93 = v173._size - v64;\n\tv87 = v93 == 0;\n\tv183 = ~v87;\n\tv72 = v96 & v183;\n\tif (v72) goto L_0045;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0045:\n\tv185 = v173._items;\n\tv119 = v185[v64 @ X0_v10 (System.Int32)];\n\tv189 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.coins);\n\tv104 = v189 - v119.NextUpgradeCost;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.coins, v104);\n\tv155 = v64 + 1;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.metaLevel, v155);\n\treturn;\nL_006F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			if ((bool)clickEvent)
			{
				int value = metaLevel.Value;
				GameConfig instance = GameConfig.Instance;
				MetaUpgradeConfig metaUpgradeConfig = ((Dictionary<string, MetaUpgradeConfig>)instance.MetaUpgradeConfigs).get_Item(metaUpgradeKey);
				List<MetaUpgradeData> data = metaUpgradeConfig.Data;
				bool flag = data.Count < value;
				bool flag2 = !flag;
				int num = data.Count - value;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				MetaUpgradeData[] items = data._items;
				MetaUpgradeData metaUpgradeData = items[value];
				int value2 = coins.Value;
				int value3 = value2 - metaUpgradeData.NextUpgradeCost;
				coins.Value = value3;
				int value4 = value + 1;
				metaLevel.Value = value4;
			}
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xCC69B8", Offset = "0xCC69B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MetaUpgradeSystem()
		{
		}
	}
}
