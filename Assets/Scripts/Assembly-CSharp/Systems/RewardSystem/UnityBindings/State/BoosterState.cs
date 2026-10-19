using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;

namespace Systems.RewardSystem.UnityBindings.State
{
	[Token(Token = "0x2000029")]
	public class BoosterState : GenericElementVisualizerState
	{
		[SerializeField]
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_text;

		[SerializeField]
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x28")]
		private Image m_icon;

		[Inject(false)]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x30")]
		private BoosterDatabase _boosterDatabase;

		[Inject(false)]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x38")]
		private IBoosterService _boosterService;

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x3C6704C", Offset = "0x3C6704C", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v86_asT @ TEMPCOND_v3 (Unco.RewardSystem.BoosterShopItemData), typeof(Unco.RewardSystem.BoosterShopItemData), data @ X1 (Unco.RewardSystem.ShopItemData)\n\tv86 = v86_asT == 0;\n\tif (v86) goto L_00B9;\n\tv153 = _game.CoreGameKit.CoreSerivces.BoosterSystem.Core.BoosterDatabase::GetDefinition(this._boosterDatabase, *([data @ X1 (Unco.RewardSystem.ShopItemData)+40]));\n\tgoto L_0053;\nL_0053:\n\tv248 = UnityEngine.Object::op_Equality(v153, 0);\n\tv251 = v248 == 0;\n\tif (v251) goto L_0084;\n\treturn;\nL_0065:\n\tgoto L_0072;\nL_0072:\n\tUnityEngine.Debug::LogError(\"BoosterShopItemData is null\");\n\treturn;\nL_0084:\n\tUnityEngine.UI.Image::set_sprite(this.m_icon, v153.Icon);\n\tv174 = UnityEngine.Component::get_gameObject(this.m_text);\n\tv163 = data.Amount < 0;\n\tv162 = data.Amount == 0;\n\tv164 = data.Amount == data.Amount;\n\tv161 = ~v164;\n\tv262 = v163 == v161;\n\tv155 = ~v162;\n\tv160 = v262 & v155;\n\tUnityEngine.GameObject::SetActive(v174, v160);\n\tv154 = data.Amount;\n\tv266 = 0xB7D5000 + 0x538;\n\tv269 = \"il2cpp_vm_object_box\"(*([v266 @ X8_v18 (System.Int32)+80]), &v154 @ stack_-38_v3 (System.Double), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, data.Amount, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = System.String::Format(\"{0}\", v269);\n\tv226 = Unco.TextViewSystem.TextView::SetText(this.m_text, v175);\n\treturn;\nL_00B9:\n\tthrow System.InvalidCastException;\nL_0021:\n\tv44 = data == 0;\n\tif (v44) goto L_0065;\n")]
		public override void Visualize(ShopItemData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterState::Visualize");
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x3C67248", Offset = "0x3C67248", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\nL_002E:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v71_asT @ TEMPCOND_v4 (Unco.RewardSystem.BoosterShopItemData), typeof(Unco.RewardSystem.BoosterShopItemData), shopItemData @ X1 (Unco.RewardSystem.ShopItemData)\n\tv71 = v71_asT == 0;\n\tif (v71) goto L_0091;\n\tv118 = this._boosterService;\n\tv179 = *([v118 @ X20_v3 (_game.CoreGameKit.CoreSerivces.BoosterSystem.Core.IBoosterService)]);\n\tv221 = *([v179 @ X8_v13 (Il2CppClass<_game.CoreGameKit.CoreSerivces.BoosterSystem.Core.IBoosterService>)+12E]);\n\tv181 = *([v179 @ X8_v13 (Il2CppClass<_game.CoreGameKit.CoreSerivces.BoosterSystem.Core.IBoosterService>)+12E]) == 0;\n\tif (v181) goto L_006A;\n\tv222 = *([v179 @ X8_v13 (Il2CppClass<_game.CoreGameKit.CoreSerivces.BoosterSystem.Core.IBoosterService>)+B0]) + 8;\n\tv222 = v222 + 0x10;\n\tv205 = v221 - 1;\n\tv187 = v221 != 1;\nL_FFFFFFFF:\n\tv221 = v205;\n\tif (v187) goto L_0050;\nL_006A:\n\tv236 = _game.CoreGameKit.CoreSerivces.BoosterSystem.Core.IBoosterService::IsUnlocked(v118, *([shopItemData @ X1 (Unco.RewardSystem.ShopItemData)+40]));\n\tv238 = ~v236;\nL_FFFFFFFF:\n\tv299 = v236;\nL_FFFFFFFF:\n\tv294 = v236;\n\tif (v238) goto L_0082;\nL_006F:\n\tv273 = 0xB7D5000 + 0x538;\n\tv274 = *([v273 @ X8_v20 (System.Int32)+90]);\n\tv164 = *([v274 @ X8_v21+B8]);\n\tgoto L_0084;\nL_0074:\n\tv241 = *([v222 @ X10_v9]) + 3;\n\tv242 = v241 << 4;\n\tv243 = v179 + v242;\n\tv244 = v243 + 0x138;\n\t*([v244 @ X0_v16])(v249, v118, *([shopItemData @ X1 (Unco.RewardSystem.ShopItemData)+40]), *([v244 @ X0_v16+8]), methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv251 = ~v249;\n\tv252 = ~v251;\nL_FFFFFFFF:\n\tv299 = v249;\nL_FFFFFFFF:\n\tv294 = v249;\n\tif (v252) goto L_006F;\nL_0082:\n\tv164 = 0xB2F7000 + 0x2E0;\nL_FFFFFFFF:\n\tv299 = v294;\nL_0091:\n\tv111 = new System.InvalidCastException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0050:\n\tv227 = *([v222 @ X10_v9-8]) == _game.CoreGameKit.CoreSerivces.BoosterSystem.Core.IBoosterService;\n\tif (v227) goto L_0074;\nL_0084:\n\t*([reason @ X2 (System.String&)]) = *([v164 @ X8_v14 (System.Int32)]);\n\treturn v299;\n")]
		public override bool IsEnabled(ShopItemData shopItemData, out string reason)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterState::IsEnabled");
			reason = default;
			return default;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x47F6FA4", Offset = "0x47F6FA4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv41 = Unco.RewardSystem.BoosterShopItemData;\n\tv42 = shopItemData->klass;\n\tv45 = *([v42 @ X9_v2 (Il2CppClass<T>)+130]) < *([v41 @ X8_v6 (Il2CppClass<Unco.RewardSystem.BoosterShopItemData>)+130]);\n\tv46 = ~v45;\n\tif (v46) goto L_002C;\nL_002A:\n\treturn 0;\nL_002C:\n\tv83 = *([v41 @ X8_v6 (Il2CppClass<Unco.RewardSystem.BoosterShopItemData>)+130]) << 3;\n\tv84 = *([v42 @ X9_v2 (Il2CppClass<T>)+C8]) + v83;\n\tv88 = *([v84 @ X9_v4-8]) - Unco.RewardSystem.BoosterShopItemData;\n\tv90 = v88 == 0;\n\treturn v90;\nL_0012:\n\tv38 = shopItemData == 0;\n\tif (v38) goto L_002A;\n")]
		public override bool IsTypeOf<T>(T shopItemData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterState::IsTypeOf");
			return default;
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x3C673B0", Offset = "0x3C673B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.RewardSystem.GenericElementVisualizerState::.ctor(this);\n\treturn;\n")]
		public BoosterState()
		{
		}
	}
}
