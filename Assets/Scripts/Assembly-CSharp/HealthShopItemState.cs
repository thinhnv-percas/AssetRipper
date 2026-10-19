using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using UnityEngine;
using UnityEngine.UI;
using _game.Systems.ShopSystem.Scripts.Core;

[Token(Token = "0x200001A")]
public class HealthShopItemState : GenericElementVisualizerState
{
	[SerializeField]
	[Token(Token = "0x4000035")]
	[FieldOffset(Offset = "0x20")]
	private Image m_image;

	[SerializeField]
	[Token(Token = "0x4000036")]
	[FieldOffset(Offset = "0x28")]
	private TextView m_text;

	[Inject(false)]
	[Token(Token = "0x4000037")]
	[FieldOffset(Offset = "0x30")]
	private ShopVisualHub _shopVisualHub;

	[Token(Token = "0x6000076")]
	[Address(RVA = "0x3C65BCC", Offset = "0x3C65BCC", Length = "0x204")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\nL_0033:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v87_asT @ TEMPCOND_v4 (Unco.RewardSystem.HealthShopItemData), typeof(Unco.RewardSystem.HealthShopItemData), data @ X1 (Unco.RewardSystem.ShopItemData)\n\tv87 = v87_asT == 0;\n\tif (v87) goto L_00B7;\n\tv80 = Unco.RewardSystem.HealthRewardType;\n\tv133 = System.Enum::ToString(&v80 @ stack_-48_v3 (Il2CppClass<Unco.RewardSystem.HealthRewardType>));\n\tv235 = _game.Systems.ShopSystem.Scripts.Core.ShopVisualHub::GetShopIcon(this._shopVisualHub, v133);\n\tgoto L_005F;\nL_005F:\n\tv241 = UnityEngine.Object::op_Inequality(v235, 0);\n\tv243 = ~v241;\n\tv244 = ~v243;\n\tif (v244) goto L_008B;\n\tv148 = this.m_text;\n\tv269 = data.Amount;\n\tv266 = *([data @ X1 (Unco.RewardSystem.ShopItemData)+40]) != 1;\nL_FFFFFFFF:\n\tv308 = data.Amount;\nL_FFFFFFFF:\n\tv323 = this.m_text;\n\tif (v266) goto L_0099;\nL_0074:\n\tv301 = v269 / 0x40AC200000000000;\n\tv302 = v301;\n\tv304 = 0xB7D5000 + 0x538;\n\tv307 = \"il2cpp_vm_object_box\"(*([v304 @ X8_v27 (System.Int32)+80]), &v302 @ stack_-48_v6 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v301, 0x40AC200000000000, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv143 = 0xB2E8000 + 0x180;\nL_FFFFFFFF:\n\tv131 = v307;\n\tgoto L_00A4;\nL_008B:\n\tUnityEngine.UI.Image::set_sprite(this.m_image, v235);\n\tv148 = this.m_text;\n\tv269 = data.Amount;\n\tv283 = *([data @ X1 (Unco.RewardSystem.ShopItemData)+40]) == 1;\nL_FFFFFFFF:\n\tv308 = data.Amount;\nL_FFFFFFFF:\n\tv323 = this.m_text;\n\tif (v283) goto L_0074;\nL_0099:\n\tv324 = v308;\n\tv326 = 0xB7D5000 + 0x538;\n\tv329 = \"il2cpp_vm_object_box\"(*([v326 @ X8_v19 (System.Int32)+80]), &v324 @ stack_-48_v5 (System.Double), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v308, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv143 = 0xB312000 + 0xDE8;\nL_FFFFFFFF:\n\tv131 = v329;\nL_FFFFFFFF:\n\tv148 = v323;\n\tv219 = Unco.TextViewSystem.TextView::SetText(v148, v135);\n\treturn;\nL_00B7:\n\tthrow System.InvalidCastException;\nL_00A4:\n\tv135 = System.String::Format(*([v143 @ X8_v15 (System.Int32)]), v131);\n")]
	public override void Visualize(ShopItemData data)
	{
		global::AssetRipperInjected.RecoveryStub.Missing("HealthShopItemState::Visualize");
	}

	[Token(Token = "0x6000077")]
	[Address(RVA = "0x498C334", Offset = "0x498C334", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv43 = System.Object::GetType(shopItemData);\n\tgoto L_0025;\nL_0025:\n\tv57 = System.Type::GetTypeFromHandle(Unco.RewardSystem.HealthShopItemData);\n\treturnVal2 = System.Type::op_Equality(v43, v57);\n\treturn returnVal2;\n")]
	public override bool IsTypeOf<T>(T shopItemData)
	{
		Type type = shopItemData.GetType();
		Type typeFromHandle = typeof(HealthShopItemData);
		return type == typeFromHandle;
	}

	[Token(Token = "0x6000078")]
	[Address(RVA = "0x3C65DD0", Offset = "0x3C65DD0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.RewardSystem.GenericElementVisualizerState::.ctor(this);\n\treturn;\n")]
	public HealthShopItemState()
	{
	}
}
