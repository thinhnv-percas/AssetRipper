using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Coffee.UIExtensions;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.TextViewSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace _game.CoreGameKit.Ui.Animations
{
	[Token(Token = "0x2000574")]
	public class CurrencyVisualizer : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000575")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40012C8")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40012C9")]
			public static Action<TextView, float> _003C_003E9__29_0;

			[Token(Token = "0x40012CA")]
			public static Action<TextView, float> _003C_003E9__30_0;

			[Token(Token = "0x60016EF")]
			[Address(RVA = "0x3D243F0", Offset = "0x3D243F0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60016F0")]
			[Address(RVA = "0x3D24454", Offset = "0x3D24454", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CAnimateGoldAmount_003Eb__29_0(TextView ct, float value)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CurrencyVisualizer._003C_003Ec::_003CAnimateGoldAmount_003Eb__29_0");
			}

			internal void _003CAnimateGoldAmount_003Eb__30_0(TextView ct, float value)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CurrencyVisualizer._003C_003Ec::_003CAnimateGoldAmount_003Eb__30_0");
			}
		}

		[SerializeField]
		[Token(Token = "0x40012B9")]
		[FieldOffset(Offset = "0x20")]
		private ResourceType m_type;

		[SerializeField]
		[Token(Token = "0x40012BA")]
		[FieldOffset(Offset = "0x28")]
		private TextView m_currencyText;

		[SerializeField]
		[Token(Token = "0x40012BB")]
		[FieldOffset(Offset = "0x30")]
		private Transform m_visualParent;

		[FormerlySerializedAs("m_hideOnStart")]
		[SerializeField]
		[Token(Token = "0x40012BC")]
		[FieldOffset(Offset = "0x38")]
		private bool m_showOnlyDuringAnimation;

		[SerializeField]
		[Token(Token = "0x40012BD")]
		[FieldOffset(Offset = "0x40")]
		private UIParticleAttractor m_attractor;

		[SerializeField]
		[Token(Token = "0x40012BE")]
		[FieldOffset(Offset = "0x48")]
		private Transform m_scaleParent;

		[SerializeField]
		[Token(Token = "0x40012BF")]
		[FieldOffset(Offset = "0x50")]
		private ShakeSettings m_scaleSettings;

		[SerializeField]
		[Token(Token = "0x40012C0")]
		[FieldOffset(Offset = "0x90")]
		private TweenSettings m_countUpSettings;

		[Token(Token = "0x40012C1")]
		[FieldOffset(Offset = "0xC0")]
		private Tween _tween;

		[Token(Token = "0x40012C2")]
		[FieldOffset(Offset = "0xD0")]
		private Tween _countTween;

		[Token(Token = "0x40012C3")]
		[FieldOffset(Offset = "0xE0")]
		private bool _isCalledOnce;

		[Token(Token = "0x40012C4")]
		[FieldOffset(Offset = "0xE4")]
		internal int _amount;

		[Token(Token = "0x40012C5")]
		[FieldOffset(Offset = "0xE8")]
		private IResourceService _resourceService;

		[Token(Token = "0x40012C6")]
		[FieldOffset(Offset = "0xF0")]
		private ParticleAnimationRegistry _registry;

		[Token(Token = "0x40012C7")]
		[FieldOffset(Offset = "0xF8")]
		private bool _animationCalled;

		[Token(Token = "0x1700020B")]
		public UIParticleAttractor Attractor
		{
			[Token(Token = "0x60016E1")]
			[Address(RVA = "0x3D23ABC", Offset = "0x3D23ABC", Length = "0x8")]
			get
			{
				return m_attractor;
			}
		}

		[Token(Token = "0x1700020C")]
		public ResourceType ResourceType
		{
			[Token(Token = "0x60016E2")]
			[Address(RVA = "0x3D23AC4", Offset = "0x3D23AC4", Length = "0x8")]
			get
			{
				return m_type;
			}
		}

		[Token(Token = "0x1700020D")]
		public Transform VisualParent
		{
			[Token(Token = "0x60016E3")]
			[Address(RVA = "0x3D23ACC", Offset = "0x3D23ACC", Length = "0x8")]
			get
			{
				return m_visualParent;
			}
		}

		[Token(Token = "0x1700020E")]
		public bool ShowOnlyDuringAnimation
		{
			[Token(Token = "0x60016E4")]
			[Address(RVA = "0x3D23AD4", Offset = "0x3D23AD4", Length = "0x8")]
			get
			{
				return m_showOnlyDuringAnimation;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60016E5")]
		[Address(RVA = "0x3D23ADC", Offset = "0x3D23ADC", Length = "0x124")]
		public void Init(ParticleAnimationRegistry registry, IResourceService resourceService)
		{
			ParticleAnimationRegistry registry2 = default(ParticleAnimationRegistry);
			_registry = registry2;
			_resourceService = resourceService;
			_registry.AddVisualizer(this);
			UIParticleAttractor attractor = Attractor;
			UnityAction call = AnimateHolder;
			attractor.onAttracted.AddListener(call);
			if (ShowOnlyDuringAnimation)
			{
				GameObject gameObject = VisualParent.gameObject;
				gameObject.SetActive(value: false);
			}
			if (!_animationCalled)
			{
				UpdateVisualizer();
			}
		}

		[Token(Token = "0x60016E6")]
		[Address(RVA = "0x3D23DA0", Offset = "0x3D23DA0", Length = "0xAC")]
		private void OnDisable()
		{
			if (_registry != null)
			{
				_registry.RemoveVisualizer(this);
			}
			UIParticleAttractor attractor = Attractor;
			UnityAction call = AnimateHolder;
			attractor.onAttracted.RemoveListener(call);
		}

		[Token(Token = "0x60016E7")]
		[Address(RVA = "0x3D21144", Offset = "0x3D21144", Length = "0x130")]
		public void UpdateVisualizer()
		{
			double amount = _resourceService.GetAmount(ResourceType);
			double num2 = default(double);
			double num = num2;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string text = num.ToString(invariantCulture);
			m_currencyText.SetText(text);
		}

		[Token(Token = "0x60016E8")]
		[Address(RVA = "0x3D23F50", Offset = "0x3D23F50", Length = "0xA0")]
		private void SetText(double amount)
		{
			double num = amount;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string text = num.ToString(invariantCulture);
			m_currencyText.SetText(text);
		}

		[Token(Token = "0x60016E9")]
		[Address(RVA = "0x3D23FF0", Offset = "0x3D23FF0", Length = "0x94")]
		public void AnimateHolder()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyVisualizer::AnimateHolder");
		}

		[Token(Token = "0x60016EA")]
		[Address(RVA = "0x3D23074", Offset = "0x3D23074", Length = "0x8")]
		public Tween AnimateGoldAmountByRequest()
		{
			return AnimateGoldAmount(_amount);
		}

		[Token(Token = "0x60016EB")]
		[Address(RVA = "0x3D24084", Offset = "0x3D24084", Length = "0x1DC")]
		public Tween AnimateGoldAmount(int amount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyVisualizer::AnimateGoldAmount");
			return default;
		}

		[Token(Token = "0x60016EC")]
		[Address(RVA = "0x3D24260", Offset = "0x3D24260", Length = "0x188")]
		public Tween AnimateGoldAmount(int amount, int endAmount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyVisualizer::AnimateGoldAmount");
			return default;
		}

		[Token(Token = "0x60016ED")]
		[Address(RVA = "0x3D20EFC", Offset = "0x3D20EFC", Length = "0xB4")]
		public void SetAnimRequest(int amount, int currentAmount)
		{
			_animationCalled = true;
			_isCalledOnce = false;
			int num = currentAmount - amount;
			_amount = amount;
			double num2 = num;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string text = num2.ToString(invariantCulture);
			m_currencyText.SetText(text);
		}

		[Token(Token = "0x60016EE")]
		[Address(RVA = "0x3D243E8", Offset = "0x3D243E8", Length = "0x8")]
		public CurrencyVisualizer()
		{
		}
	}
}
