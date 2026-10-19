using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Systems.ShopSystem.Scripts.Core;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.TextViewSystem;
using UnityEngine;
using _game.Scripts.Shop.View.Components;
using _game.Systems.ShopSystem.Scripts.Core;

namespace Systems.ShopSystem.Scripts.Ui.ShopGroups
{
	[Token(Token = "0x2000053")]
	public abstract class ShopGroupView : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x20")]
		protected ShopService _shopService;

		[Inject(false)]
		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x28")]
		protected internal Instancer _instancer;

		[Inject(false)]
		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x30")]
		protected internal ShopVisualHub _shopVisualHub;

		[SerializeField]
		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x38")]
		private TextView m_title;

		[SerializeField]
		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x40")]
		private PurchaseButton m_purchaseButton;

		[SerializeField]
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x48")]
		private TextView m_tagText;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x50")]
		protected internal ShopGroupRemote _config;

		[CompilerGenerated]
		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x58")]
		private Action OnPurchaseButtonTapped;

		[CompilerGenerated]
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x60")]
		private Action OnPurchaseCompleted;

		[CompilerGenerated]
		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x68")]
		private Action OnPurchaseFailed;

		[Token(Token = "0x17000032")]
		public string PackId
		{
			[Token(Token = "0x6000107")]
			[Address(RVA = "0x3C69648", Offset = "0x3C69648", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._config;\n\tv2 = this._config == 0;\n\tif (v2) goto L_0006;\n\treturn v0.groupKey;\nL_0006:\n\treturn 0;\n")]
			get
			{
				ShopGroupRemote config = _config;
				if (_config != null)
				{
					return config.groupKey;
				}
				return null;
			}
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x3C69660", Offset = "0x3C69660", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv56 = _game.Systems.ShopSystem.Scripts.Core.ShopService::GetGroupConfig(this._shopService, v44);\n\tthis._config = v56;\n\tv103 = this._config;\n\tv82 = this.m_tagText;\n\tv141 = v103.ItemVisualData == 0;\n\tif (v141) goto L_003C;\n\tv142 = this.m_tagText == 0;\n\tif (v142) goto L_004F;\n\tv158 = _game.Systems.ShopSystem.Scripts.Core.ShopVisualHub::OfferTagText(this._shopVisualHub, v103.ItemVisualData);\n\tv153 = *([v82 @ X21_v3 (UnityEngine.Component)]);\n\t*([v153 @ X8_v11 (Il2CppClass<UnityEngine.Component>)+178])(v150, this.m_tagText, v158, *([v153 @ X8_v11 (Il2CppClass<UnityEngine.Component>)+180]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_004F;\nL_003C:\n\tv143 = this.m_tagText == 0;\n\tif (v143) goto L_004F;\n\tv87 = UnityEngine.Component::get_transform(this.m_tagText);\n\tv88 = UnityEngine.Transform::get_parent(v87);\n\tv89 = UnityEngine.Component::get_gameObject(v88);\n\tUnityEngine.GameObject::SetActive(v89, 0);\nL_004F:\n\tv154 = this.m_title == 0;\n\tif (v154) goto L_005D;\n\tv104 = this._config;\n\tv165 = Unco.TextViewSystem.TextView::SetText(this.m_title, v104.groupVisualName);\n\tv91 = new System.Action();\n\tSystem.Action::.ctor(v91, this, Il2CppMethodInfo);\n\t_game.Scripts.Shop.View.Components.PurchaseButton::InitCostButtonWithoutPayment(this.m_purchaseButton, v105.costData, v91, 1);\n\treturn;\nL_005D:\n\tv92 = Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopGroupView::InnerInit(this);\n\tv105 = this._config;\n")]
		public void Init(string packId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupView::Init");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000109")]
		[Address(RVA = "0x3C697E8", Offset = "0x3C697E8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnPurchaseButtonTapped (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnPurchaseButtonTapped;\n\tgoto L_002C;\n")]
		public void add_OnPurchaseButtonTapped(Action value)
		{
			Action action = OnPurchaseButtonTapped;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnPurchaseButtonTapped, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010A")]
		[Address(RVA = "0x3C6988C", Offset = "0x3C6988C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnPurchaseButtonTapped (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnPurchaseButtonTapped;\n\tgoto L_002C;\n")]
		public void remove_OnPurchaseButtonTapped(Action value)
		{
			Action action = OnPurchaseButtonTapped;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnPurchaseButtonTapped, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010B")]
		[Address(RVA = "0x3C69930", Offset = "0x3C69930", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnPurchaseCompleted (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnPurchaseCompleted;\n\tgoto L_002C;\n")]
		public void add_OnPurchaseCompleted(Action value)
		{
			Action action = OnPurchaseCompleted;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnPurchaseCompleted, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010C")]
		[Address(RVA = "0x3C699D4", Offset = "0x3C699D4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnPurchaseCompleted (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnPurchaseCompleted;\n\tgoto L_002C;\n")]
		public void remove_OnPurchaseCompleted(Action value)
		{
			Action action = OnPurchaseCompleted;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnPurchaseCompleted, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010D")]
		[Address(RVA = "0x3C69A78", Offset = "0x3C69A78", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnPurchaseFailed (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnPurchaseFailed;\n\tgoto L_002C;\n")]
		public void add_OnPurchaseFailed(Action value)
		{
			Action action = OnPurchaseFailed;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnPurchaseFailed, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010E")]
		[Address(RVA = "0x3C69B1C", Offset = "0x3C69B1C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnPurchaseFailed (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnPurchaseFailed;\n\tgoto L_002C;\n")]
		public void remove_OnPurchaseFailed(Action value)
		{
			Action action = OnPurchaseFailed;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnPurchaseFailed, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x3C69BC0", Offset = "0x3C69BC0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tSystem.Action::Invoke(this.OnPurchaseButtonTapped);\n\tSystem.Action::.ctor(v81, this, Il2CppMethodInfo);\n\tv86 = this._shopService == 0;\n\tif (v86) goto L_004F;\n\t_game.Systems.ShopSystem.Scripts.Core.ShopService::PurchaseGroup(this._shopService, this._config, v73, v81);\n\treturn;\nL_004F:\n\tthrow v81;\nL_0024:\n\t;\n\tv58 = this.OnPurchaseButtonTapped == 0;\n\tif (v58) goto L_002E;\nL_002E:\n\tv73 = new System.Action();\n\tSystem.Action::.ctor(v73, this, Il2CppMethodInfo);\n\tv81 = new System.Action();\n")]
		private void OnPurchase()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopGroupView::OnPurchase");
		}

		[Token(Token = "0x6000110")]
		protected abstract void InnerInit();

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x3C69CB8", Offset = "0x3C69CB8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void DeInit()
		{
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x3C68610", Offset = "0x3C68610", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal ShopGroupView()
		{
		}
	}
}
