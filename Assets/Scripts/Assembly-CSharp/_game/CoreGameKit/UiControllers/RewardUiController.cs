using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using _game.CoreGameKit.Ui.Animations;
using _game.Systems.RewardSystem.UnityBindings;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000538")]
	public class RewardUiController : UIController
	{
		[CompilerGenerated]
		[Token(Token = "0x200053A")]
		private sealed class _003C_003Ec__DisplayClass13_0
		{
			[Token(Token = "0x40011A2")]
			[FieldOffset(Offset = "0x10")]
			public Action callback;

			[Token(Token = "0x60015E7")]
			[Address(RVA = "0x3D15AE0", Offset = "0x3D15AE0", Length = "0x58")]
			public _003C_003Ec__DisplayClass13_0()
			{
			}

			internal void _003COnClaimClicked_003Eb__0()
			{
				if (callback != null)
				{
					callback();
				}
			}
		}

		[SerializeField]
		[Token(Token = "0x4001196")]
		[FieldOffset(Offset = "0x48")]
		private ItemGridView m_gridView;

		[SerializeField]
		[Token(Token = "0x4001197")]
		[FieldOffset(Offset = "0x50")]
		private Button m_claimButton;

		[SerializeField]
		[Token(Token = "0x4001198")]
		[FieldOffset(Offset = "0x58")]
		private TextView m_headerText;

		[SerializeField]
		[Token(Token = "0x4001199")]
		[FieldOffset(Offset = "0x60")]
		private float m_claimButtonDelay = 1f;

		[Inject(false)]
		[Token(Token = "0x400119A")]
		[FieldOffset(Offset = "0x68")]
		private CurrencyAnimationController _currencyAnimationController;

		[Inject(false)]
		[Token(Token = "0x400119B")]
		[FieldOffset(Offset = "0x70")]
		private IResourceService _resourceService;

		[Token(Token = "0x400119C")]
		[FieldOffset(Offset = "0x78")]
		private Action _onComplete;

		[Token(Token = "0x400119D")]
		[FieldOffset(Offset = "0x80")]
		private Tween _buttonDelayTween;

		[Token(Token = "0x400119E")]
		[FieldOffset(Offset = "0x90")]
		private readonly Dictionary<ResourceType, int> _pendingResourceAnimations;

		[Token(Token = "0x400119F")]
		[FieldOffset(Offset = "0x98")]
		private bool _hasHealthAnimation;

		[Token(Token = "0x60015DD")]
		[Address(RVA = "0x3D14D94", Offset = "0x3D14D94", Length = "0x230")]
		public void Show(IEnumerable<ShopItemData> items, Action onComplete = null, Action onRewardGiven = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardUiController::Show");
		}

		[Token(Token = "0x60015DE")]
		[Address(RVA = "0x3D154AC", Offset = "0x3D154AC", Length = "0x20")]
		public void UpdateHeader(string header)
		{
			TextView textView = default(TextView);
			textView.SetText(header);
		}

		[Token(Token = "0x60015DF")]
		[Address(RVA = "0x3D14FCC", Offset = "0x3D14FCC", Length = "0x4E0")]
		private unsafe void CollectResourceAnimations(List<ShopItemData> items)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardUiController::CollectResourceAnimations");
		}

		[Token(Token = "0x60015E0")]
		[Address(RVA = "0x3D15678", Offset = "0x3D15678", Length = "0x468")]
		private unsafe void OnClaimClicked()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardUiController::OnClaimClicked");
		}

		[Token(Token = "0x60015E1")]
		[Address(RVA = "0x3D15E14", Offset = "0x3D15E14", Length = "0x48")]
		public override void OnDisable()
		{
			base.OnDisable();
			if (_buttonDelayTween.isAlive)
			{
				_buttonDelayTween.Stop();
			}
		}

		[Token(Token = "0x60015E2")]
		[Address(RVA = "0x3D15E5C", Offset = "0x3D15E5C", Length = "0xBD4")]
		public unsafe void Test()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardUiController::Test");
		}

		[Token(Token = "0x60015E3")]
		[Address(RVA = "0x3D16A30", Offset = "0x3D16A30", Length = "0x94")]
		public RewardUiController()
		{
			Dictionary<ResourceType, int> pendingResourceAnimations = new Dictionary<ResourceType, int>();
			_pendingResourceAnimations = pendingResourceAnimations;
		}
	}
}
