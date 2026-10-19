using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.ResourceSystem.Visual;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;
using _game.Systems.ShopSystem;
using _game.Systems.ShopSystem.Scripts.Core;

namespace Systems.ResourceSystem.UnityBindigs
{
	[Token(Token = "0x200003C")]
	public class ResourceState : GenericElementVisualizerState
	{
		[CompilerGenerated]
		[Token(Token = "0x200003D")]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			[Token(Token = "0x400008B")]
			[FieldOffset(Offset = "0x10")]
			public ResourceItemData resourceData;

			[Token(Token = "0x60000D2")]
			[Address(RVA = "0x3C67BF4", Offset = "0x3C67BF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass6_0()
			{
			}

			internal bool _003CVisualize_003Eb__0(Pair<ResourceType, RarityType> x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ResourceState._003C_003Ec__DisplayClass6_0::_003CVisualize_003Eb__0");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_text;

		[SerializeField]
		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x28")]
		private Image m_icon;

		[SerializeField]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x30")]
		private List<Pair<ResourceType, RarityType>> m_rarityPairs;

		[SerializeField]
		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x38")]
		private Image m_frame;

		[Inject(false)]
		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x40")]
		private ResourceVisualHub _resourceVisualHub;

		[Inject(false)]
		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x48")]
		private ShopVisualHub _shopVisualHub;

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x3C67958", Offset = "0x3C67958", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv68 = data == 0;\n\tif (v68) goto L_007E;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v231_asT @ TEMPCOND_v5 (Unco.RewardSystem.ResourceItemData), typeof(Unco.RewardSystem.ResourceItemData), data @ X1 (Unco.RewardSystem.ShopItemData)\n\tv231 = v231_asT == 0;\n\tif (v231) goto L_00FB;\n\tv186 = v55 + 0x10;\n\tv55.resourceData = data;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v92_asT @ TEMPCOND_v7 (Unco.RewardSystem.ResourceItemData), typeof(Unco.RewardSystem.ResourceItemData), data @ X1 (Unco.RewardSystem.ShopItemData)\n\tv92 = v92_asT == 0;\n\tif (v92) goto L_00FB;\n\tv285 = v55.resourceData;\n\tv341 = v55.resourceData == 0;\n\tv170 = ~v341;\n\tif (v170) goto L_008E;\n\tgoto L_00F9;\nL_007E:\n\tv186 = v55 + 0x10;\n\tv55.resourceData = 0;\n\tv285 = v55.resourceData;\nL_008E:\n\tgoto L_0094;\n\tv159 = Unco.TextViewSystem.TextView::SetText(this.m_text, v158);\n\tv192 = *([v186 @ X22_v5]);\n\tv345 = Unco.ResourceSystem.Visual.ResourceVisualHub::GetSprite(this._resourceVisualHub, *([v192 @ X8_v8+40]));\n\tUnityEngine.UI.Image::set_sprite(this.m_icon, v345);\n\tv162 = new System.Predicate`1<Unco.Utils.Pair`2<Unco.ResourceSystem.ResourceType, _game.Systems.ShopSystem.RarityType>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<Unco.ResourceSystem.ResourceType, _game.Systems.ShopSystem.RarityType>>::.ctor(v162, v55, Il2CppMethodInfo);\n\tv166 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Int32Enum>>::FindIndex(this.m_rarityPairs, v162);\n\tv118 = v166 == -1;\n\tif (v118) goto L_00E3;\n\tv164 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Int32Enum>>::get_Item(this.m_rarityPairs, 0);\n\tv152 = v164 >> 0x20;\n\tv168 = _game.Systems.ShopSystem.Scripts.Core.ShopVisualHub::GetRarityVisual(this._shopVisualHub, v152);\n\tv360 = v168 == 0;\n\tv179 = ~v360;\n\tif (v179) goto L_00F7;\n\tgoto L_00F9;\nL_00E3:\n\tv168 = _game.Systems.ShopSystem.Scripts.Core.ShopVisualHub::GetRarityVisual(this._shopVisualHub, 1);\nL_00F7:\n\tUnityEngine.UI.Image::set_sprite(this.m_frame, v168.Frame);\n\treturn;\nL_00F9:\n\tthrow System.NullReferenceException;\nL_00FB:\n\tthrow System.InvalidCastException;\nL_002E:\n\tv55 = new Systems.ResourceSystem.UnityBindigs.ResourceState+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v55);\nL_0094:\n\tv158 = Unco.Utils.NumberConverter::Format(v285.Amount, 2);\n")]
		public override void Visualize(ShopItemData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceState::Visualize");
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x4C60F4C", Offset = "0x4C60F4C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv45 = shopItemData->klass;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v76_asT @ Z_v3 (Unco.RewardSystem.ResourceItemData), typeof(Unco.RewardSystem.ResourceItemData), shopItemData @ X1 (T)\n\tv76 = v76_asT != 0;\n\tif (v76) goto L_003F;\nL_003C:\n\treturn 0;\nL_003F:\n\tv138 = _game.Systems.ShopSystem.Scripts.Core.ShopResourceItemData;\n\tv155 = *([v45 @ X10_v2 (Il2CppClass<T>)+130]) < *([v138 @ X9_v5 (Il2CppClass<_game.Systems.ShopSystem.Scripts.Core.ShopResourceItemData>)+130]);\n\tv132 = ~v155;\n\tif (v132) goto L_0052;\n\treturn 1;\nL_0052:\n\tv107 = *([v138 @ X9_v5 (Il2CppClass<_game.Systems.ShopSystem.Scripts.Core.ShopResourceItemData>)+130]) << 3;\n\tv156 = *([v45 @ X10_v2 (Il2CppClass<T>)+C8]) + v107;\n\tv130 = *([v156 @ X8_v7-8]) - _game.Systems.ShopSystem.Scripts.Core.ShopResourceItemData;\n\tv124 = v130 == 0;\n\tv109 = ~v124;\n\treturn v109;\nL_0015:\n\tv39 = shopItemData == 0;\n\tif (v39) goto L_003C;\n")]
		public override bool IsTypeOf<T>(T shopItemData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceState::IsTypeOf");
			return default;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x3C67BFC", Offset = "0x3C67BFC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = UnityEngine.Component::get_gameObject(this.m_frame);\n\tUnityEngine.GameObject::SetActive(v16, b);\n\treturn;\n")]
		public void SetFrameEnabled(bool b)
		{
			GameObject gameObject = m_frame.gameObject;
			gameObject.SetActive(b);
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x3C67C38", Offset = "0x3C67C38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.RewardSystem.GenericElementVisualizerState::.ctor(this);\n\treturn;\n")]
		public ResourceState()
		{
		}
	}
}
