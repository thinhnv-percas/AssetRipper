using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using UnityEngine;
using UnityEngine.UI;
using _game.Systems.ShopSystem.Scripts.Core;

[Token(Token = "0x200001B")]
public class IAPShopItemState : GenericElementVisualizerState
{
	[SerializeField]
	[Token(Token = "0x4000038")]
	[FieldOffset(Offset = "0x20")]
	private Image m_image;

	[SerializeField]
	[Token(Token = "0x4000039")]
	[FieldOffset(Offset = "0x28")]
	private TextView m_text;

	[Inject(false)]
	[Token(Token = "0x400003A")]
	[FieldOffset(Offset = "0x30")]
	private ShopVisualHub _shopVisualHub;

	[Token(Token = "0x6000079")]
	[Address(RVA = "0x3C65DD8", Offset = "0x3C65DD8", Length = "0x19C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0030:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v82_asT @ TEMPCOND_v4 (Unco.RewardSystem.IAPShopItemData), typeof(Unco.RewardSystem.IAPShopItemData), data @ X1 (Unco.RewardSystem.ShopItemData)\n\tv82 = v82_asT == 0;\n\tif (v82) goto L_00A0;\n\tv76 = Unco.RewardSystem.IAPItemType;\n\tv128 = System.Enum::ToString(&v76 @ stack_-48_v3 (Il2CppClass<Unco.RewardSystem.IAPItemType>));\n\tv240 = _game.Systems.ShopSystem.Scripts.Core.ShopVisualHub::GetShopIcon(this._shopVisualHub, v128);\n\tgoto L_005C;\nL_005C:\n\tv246 = UnityEngine.Object::op_Inequality(v240, 0);\n\tv248 = ~v246;\n\tv249 = ~v248;\n\tif (v249) goto L_007F;\n\tv264 = *([data @ X1 (Unco.RewardSystem.ShopItemData)+40]) == 1;\n\tif (v264) goto L_0095;\nL_0072:\n\treturn;\nL_007F:\n\tUnityEngine.UI.Image::set_sprite(this.m_image, v240);\n\tv272 = *([data @ X1 (Unco.RewardSystem.ShopItemData)+40]) != 1;\n\tif (v272) goto L_0072;\nL_0095:\n\tv218 = Unco.TextViewSystem.TextView::SetText(this.m_text, \"NoADS\");\n\treturn;\nL_00A0:\n\tthrow System.InvalidCastException;\n")]
	public override void Visualize(ShopItemData data)
	{
		global::AssetRipperInjected.RecoveryStub.Missing("IAPShopItemState::Visualize");
	}

	[Token(Token = "0x600007A")]
	[Address(RVA = "0x498E290", Offset = "0x498E290", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv43 = System.Object::GetType(shopItemData);\n\tgoto L_0025;\nL_0025:\n\tv57 = System.Type::GetTypeFromHandle(Unco.RewardSystem.IAPShopItemData);\n\treturnVal2 = System.Type::op_Equality(v43, v57);\n\treturn returnVal2;\n")]
	public override bool IsTypeOf<T>(T shopItemData)
	{
		Type type = shopItemData.GetType();
		Type typeFromHandle = typeof(IAPShopItemData);
		return type == typeFromHandle;
	}

	[Token(Token = "0x600007B")]
	[Address(RVA = "0x3C65F74", Offset = "0x3C65F74", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.RewardSystem.GenericElementVisualizerState::.ctor(this);\n\treturn;\n")]
	public IAPShopItemState()
	{
	}
}
