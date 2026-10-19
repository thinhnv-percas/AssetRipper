using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.Scripts.TweenerSystem;
using _game.Scripts.TweenerSystem.TweenElements.Transform;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.PaymentSystem.Flow;

namespace _game.CoreGameKit.Ui.Animations
{
	[Token(Token = "0x2000576")]
	public class LevelEndCurrencyAnimationExecutor : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000577")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40012DA")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40012DB")]
			public static Action<LevelEndCurrencyAnimationExecutor> _003C_003E9__17_0;

			[Token(Token = "0x60016F9")]
			[Address(RVA = "0x3D24EC8", Offset = "0x3D24EC8", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60016FA")]
			[Address(RVA = "0x3D24F2C", Offset = "0x3D24F2C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003COnAdSuccess_003Eb__17_0(LevelEndCurrencyAnimationExecutor t)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelEndCurrencyAnimationExecutor._003C_003Ec::_003COnAdSuccess_003Eb__17_0");
			}
		}

		[SerializeField]
		[Token(Token = "0x40012CB")]
		[FieldOffset(Offset = "0x20")]
		private float m_delay;

		[SerializeField]
		[Token(Token = "0x40012CC")]
		[FieldOffset(Offset = "0x28")]
		private TextView m_text;

		[SerializeField]
		[Token(Token = "0x40012CD")]
		[FieldOffset(Offset = "0x30")]
		private TextView m_2xText;

		[SerializeField]
		[Token(Token = "0x40012CE")]
		[FieldOffset(Offset = "0x38")]
		private CurrencyVisualizer m_visualizer;

		[SerializeField]
		[Token(Token = "0x40012CF")]
		[FieldOffset(Offset = "0x40")]
		private UncoButton m_button;

		[SerializeField]
		[Token(Token = "0x40012D0")]
		[FieldOffset(Offset = "0x48")]
		private UncoButton m_adButton;

		[SerializeField]
		[Token(Token = "0x40012D1")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform m_animationSource;

		[SerializeField]
		[Token(Token = "0x40012D2")]
		[FieldOffset(Offset = "0x58")]
		private Tweener m_multiplyTweener;

		[SerializeField]
		[Token(Token = "0x40012D3")]
		[FieldOffset(Offset = "0x60")]
		private TextViewNumberTweenElement m_numberTweenElement;

		[Inject(false)]
		[Token(Token = "0x40012D4")]
		[FieldOffset(Offset = "0x68")]
		private PaymentFlowController _paymentFlowController;

		[Inject(false)]
		[Token(Token = "0x40012D5")]
		[FieldOffset(Offset = "0x70")]
		private IBaseLayerCompleteService completeService;

		[Inject(false)]
		[Token(Token = "0x40012D6")]
		[FieldOffset(Offset = "0x78")]
		private ParticleAnimationRegistry _registry;

		[Token(Token = "0x40012D7")]
		[FieldOffset(Offset = "0x80")]
		private CurrencyAnimationController _currencyAnimationController;

		[Token(Token = "0x40012D8")]
		[FieldOffset(Offset = "0x88")]
		private IResourceService _resourceService;

		[Token(Token = "0x40012D9")]
		[FieldOffset(Offset = "0x90")]
		private LootDrop _reward;

		[Inject(false)]
		[Token(Token = "0x60016F3")]
		[Address(RVA = "0x3D247E4", Offset = "0x3D247E4", Length = "0x288")]
		private unsafe void Inject(LevelContext levelContext, IResourceService resourceService, CurrencyAnimationController currencyAnimationController)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelEndCurrencyAnimationExecutor::Inject");
		}

		[Token(Token = "0x60016F4")]
		[Address(RVA = "0x3D24A6C", Offset = "0x3D24A6C", Length = "0x20")]
		private void OnDestroy()
		{
			_registry.RemoveVisualizer(m_visualizer);
		}

		[Token(Token = "0x60016F5")]
		[Address(RVA = "0x3D24A8C", Offset = "0x3D24A8C", Length = "0x258")]
		private void OnAdSuccess()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelEndCurrencyAnimationExecutor::OnAdSuccess");
		}

		[Token(Token = "0x60016F6")]
		[Address(RVA = "0x3D24CE4", Offset = "0x3D24CE4", Length = "0x44")]
		private void OnAdFailed()
		{
			m_button.SetInteractable(isInteractable: true);
			m_adButton.SetInteractable(isInteractable: true);
		}

		[Token(Token = "0x60016F7")]
		[Address(RVA = "0x3D24D28", Offset = "0x3D24D28", Length = "0x8")]
		public LevelEndCurrencyAnimationExecutor()
		{
		}
	}
}
