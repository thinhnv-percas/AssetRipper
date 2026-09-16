using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace GBG.Pinata.ECS
{
	[HideMonoScript]
	[AttributeAttribute(Type = typeof(GlobalConfigAttribute), RVA = "0x74A13C", Offset = "0x74A13C")]
	[Token(Token = "0x200002D")]
	public class GameConfig : GlobalConfig<GameConfig>
	{
		[Token(Token = "0x40000A5")]
		private static GameConfig instanceRuntime;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74ACD8", Offset = "0x74ACD8")]
		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x18")]
		public UISettings UI;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AD10", Offset = "0x74AD10")]
		[Obsolete]
		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x20")]
		public GlobalVariablesIntDictionary GlobalIntegers;

		[Obsolete]
		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEventsDictionary GlobalEvents;

		[Obsolete]
		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x30")]
		public GlobalEventsIntDictionary GlobalEventsInt;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74ADE0", Offset = "0x74ADE0")]
		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x38")]
		public EnemySettings Enemy;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AE18", Offset = "0x74AE18")]
		[HideLabel]
		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x50")]
		public WeaponSettings Weapon;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AE64", Offset = "0x74AE64")]
		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x60")]
		public MetaUpgradeConfigs MetaUpgradeConfigs;

		[Token(Token = "0x17000002")]
		public new static GameConfig Instance
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0xCBE11C", Offset = "0xCBE11C", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1F02948]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2023715]) = v39;\nL_001E:\n\tgoto L_0027;\n\tv51 = *([v46 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v46, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv61 = UnityEngine.Object::op_Equality(v45.instanceRuntime, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_004C;\n\tv67 = Sirenix.Utilities.GlobalConfig`1<GBG.Pinata.ECS.GameConfig>::get_Instance();\n\tgoto L_003F;\n\tv92 = *([v88 @ X8_v11+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_003F;\n\tv100 = v88;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v100, v59, v60, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003F:\n\tv73 = UnityEngine.Object::Instantiate(v67);\n\tv77.instanceRuntime = v73;\nL_004C:\n\treturn v85.instanceRuntime;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (instanceRuntime == null)
				{
					GameConfig original = GlobalConfig<GameConfig>.Instance;
					GameConfig gameConfig = UnityEngine.Object.Instantiate(original);
					instanceRuntime = gameConfig;
				}
				return instanceRuntime;
			}
		}

		[Token(Token = "0x17000003")]
		public static GameConfig InstanceEditorOnly
		{
			[Token(Token = "0x600005C")]
			[Address(RVA = "0xCBEF98", Offset = "0xCBEF98", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1ED2FD0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023716]) = v35;\nL_0018:\n\treturnVal1 = Sirenix.Utilities.GlobalConfig`1<GBG.Pinata.ECS.GameConfig>::get_Instance();\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GlobalConfig<GameConfig>.Instance;
			}
		}

		[AttributeAttribute(Type = typeof(PropertyOrderAttribute), RVA = "0x74B6F0", Offset = "0x74B6F0")]
		[HideReferenceObjectPicker]
		[ShowInInspector]
		[Token(Token = "0x17000004")]
		private GameConfig RuntimeInstance
		{
			[Token(Token = "0x600005D")]
			[Address(RVA = "0xCBEFE0", Offset = "0xCBEFE0", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = *([2023717]) & 1;\n\tv11 = v10 == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_001B;\n\treturnVal2 = 0xCCDC04(this, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturn returnVal2;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023717]) = X8;\nL_001B:\n\treturn v37.instanceRuntime;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2023717]");
				if (0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CCDC04 (inside WeaponParametersProvider::.ctor +0x54)");
					GameConfig result = default(GameConfig);
					return result;
				}
				return instanceRuntime;
			}
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0xCBF030", Offset = "0xCBF030", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDF3C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023718]) = v38;\nL_001C:\n\tSirenix.Utilities.GlobalConfig`1<GBG.Pinata.ECS.GameConfig>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameConfig()
		{
		}
	}
}
