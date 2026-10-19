using System;
using Systems.WinStreakBonusSystem.Core;
using Systems.WinStreakBonusSystem.Data;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RewardSystem;
using UnityEngine;
using UnityEngine.UI;
using _game.Systems.RewardSystem.UnityBindings;

namespace Systems.WinStreakBonusSystem.UnityBindings.UI
{
	[Token(Token = "0x2000020")]
	public class WinStreakBonusState : GenericElementVisualizerState
	{
		[SerializeField]
		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x20")]
		private FormattableText m_text;

		[SerializeField]
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x28")]
		private Image m_icon;

		[Inject(false)]
		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x30")]
		private WinStreakBonusDatabase _winStreakBonusDatabase;

		[Inject(false)]
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x38")]
		private WinStreakBonusService _winStreakBonusService;

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x3C661A4", Offset = "0x3C661A4", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v90_asT @ TEMPCOND_v5 (Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData), typeof(Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData), data @ X1 (Unco.RewardSystem.ShopItemData)\n\tv90 = v90_asT == 0;\n\tif (v90) goto L_00AA;\n\tgoto L_0054;\n\tUnityEngine.UI.Image::set_sprite(this.m_icon, v194.icon);\n\t// 101 NewArr v292 @ X0_v21 (System.Object[]), typeof(System.Object[]), 1\n\tv148 = data.Amount;\n\tv202 = 0xB7D5000 + 0x538;\n\tv195 = \"il2cpp_vm_object_box\"(*([v202 @ X8_v22 (System.Int32)+80]), &v148 @ stack_-48_v5 (System.Double), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, data.Amount, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv295 = v195 == 0;\n\tif (v295) goto L_007E;\n\tv221 = 0x21C11D0(v195, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv223 = v221 == 0;\n\tif (v223) goto L_00AC;\nL_007E:\n\tv292[0] = v195;\n\t_game.Systems.RewardSystem.UnityBindings.FormattableText::SetText(this.m_text, v292);\n\treturn;\nL_0097:\n\tgoto L_00A6;\nL_00A6:\n\tUnityEngine.Debug::LogError(\"WinStreakBonusShopItemData is null\");\n\treturn;\nL_00AA:\n\tv128 = new System.InvalidCastException();\n\tv181 = new System.IndexOutOfRangeException();\nL_00AC:\n\tv229 = new System.ArrayTypeMismatchException();\n\tthrow v229;\nL_0020:\n\tv48 = data == 0;\n\tif (v48) goto L_0097;\nL_0054:\n\tv194 = new Systems.WinStreakBonusSystem.Data.WinStreakBonusUIConfig();\n\tSystem.Object::.ctor(v194);\n")]
		public override void Visualize(ShopItemData data)
		{
			if (data != null)
			{
				if (!(data is WinStreakBonusShopItemData))
				{
					InvalidCastException ex = new InvalidCastException();
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					goto IL_0128;
				}
				WinStreakBonusUIConfig winStreakBonusUIConfig = new WinStreakBonusUIConfig();
				m_icon.sprite = winStreakBonusUIConfig.icon;
				object[] array = new object[1];
				double amount = data.Amount;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj = default(object);
				if (obj != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						goto IL_0128;
					}
				}
				array[0] = obj;
				m_text.SetText(array);
				return;
			}
			Debug.LogError("WinStreakBonusShopItemData is null");
			return;
			IL_0128:
			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
			throw ex3;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x42B0C10", Offset = "0x42B0C10", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv41 = Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData;\n\tv42 = shopItemData->klass;\n\tv45 = *([v42 @ X9_v2 (Il2CppClass<T>)+130]) < *([v41 @ X8_v6 (Il2CppClass<Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData>)+130]);\n\tv46 = ~v45;\n\tif (v46) goto L_002C;\nL_002A:\n\treturn 0;\nL_002C:\n\tv83 = *([v41 @ X8_v6 (Il2CppClass<Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData>)+130]) << 3;\n\tv84 = *([v42 @ X9_v2 (Il2CppClass<T>)+C8]) + v83;\n\tv88 = *([v84 @ X9_v4-8]) - Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData;\n\tv90 = v88 == 0;\n\treturn v90;\nL_0012:\n\tv38 = shopItemData == 0;\n\tif (v38) goto L_002A;\n")]
		public override bool IsTypeOf<T>(T shopItemData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinStreakBonusState::IsTypeOf");
			return default;
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x3C663F0", Offset = "0x3C663F0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v67_asT @ TEMPCOND_v4 (Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData), typeof(Systems.WinStreakBonusSystem.Data.WinStreakBonusShopItemData), shopItemData @ X1 (Unco.RewardSystem.ShopItemData)\n\tv67 = v67_asT == 0;\n\tif (v67) goto L_004D;\n\tv151 = 0xB7D5000 + 0x538;\n\tv152 = *([v151 @ X8_v13 (System.Int32)+90]);\n\tv139 = *([v152 @ X8_v14+B8]);\n\t*([reason @ X2 (System.String&)]) = *([v139 @ X8_v15]);\n\treturn 1;\nL_004D:\n\tv107 = new System.InvalidCastException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n")]
		public override bool IsEnabled(ShopItemData shopItemData, out string reason)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinStreakBonusState::IsEnabled");
			reason = default;
			return default;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x3C664E0", Offset = "0x3C664E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.RewardSystem.GenericElementVisualizerState::.ctor(this);\n\treturn;\n")]
		public WinStreakBonusState()
		{
		}
	}
}
