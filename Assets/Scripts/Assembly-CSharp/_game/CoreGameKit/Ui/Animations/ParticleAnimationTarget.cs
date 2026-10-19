using Coffee.UIExtensions;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace _game.CoreGameKit.Ui.Animations
{
	[Token(Token = "0x200057A")]
	public class ParticleAnimationTarget : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40012E2")]
		[FieldOffset(Offset = "0x20")]
		private string m_key;

		[SerializeField]
		[Token(Token = "0x40012E3")]
		[FieldOffset(Offset = "0x28")]
		private UIParticleAttractor m_attractor;

		[SerializeField]
		[Token(Token = "0x40012E4")]
		[FieldOffset(Offset = "0x30")]
		private Transform m_visualParent;

		[SerializeField]
		[Token(Token = "0x40012E5")]
		[FieldOffset(Offset = "0x38")]
		private bool m_showOnlyDuringAnimation;

		[SerializeField]
		[Token(Token = "0x40012E6")]
		[FieldOffset(Offset = "0x40")]
		private Transform m_scaleParent;

		[SerializeField]
		[Token(Token = "0x40012E7")]
		[FieldOffset(Offset = "0x48")]
		private ShakeSettings m_scaleSettings;

		[Token(Token = "0x40012E8")]
		[FieldOffset(Offset = "0x88")]
		private Tween _shakeTween;

		[Token(Token = "0x40012E9")]
		[FieldOffset(Offset = "0x98")]
		private ParticleAnimationRegistry _registry;

		[Token(Token = "0x1700020F")]
		public string Key
		{
			[Token(Token = "0x6001706")]
			[Address(RVA = "0x3D25488", Offset = "0x3D25488", Length = "0x8")]
			get
			{
				return m_key;
			}
		}

		[Token(Token = "0x17000210")]
		public UIParticleAttractor Attractor
		{
			[Token(Token = "0x6001707")]
			[Address(RVA = "0x3D25490", Offset = "0x3D25490", Length = "0x8")]
			get
			{
				return m_attractor;
			}
		}

		[Token(Token = "0x17000211")]
		public Transform VisualParent
		{
			[Token(Token = "0x6001708")]
			[Address(RVA = "0x3D25498", Offset = "0x3D25498", Length = "0x8")]
			get
			{
				return m_visualParent;
			}
		}

		[Token(Token = "0x17000212")]
		public bool ShowOnlyDuringAnimation
		{
			[Token(Token = "0x6001709")]
			[Address(RVA = "0x3D254A0", Offset = "0x3D254A0", Length = "0x8")]
			get
			{
				return m_showOnlyDuringAnimation;
			}
		}

		[Inject(false)]
		[Token(Token = "0x600170A")]
		[Address(RVA = "0x3D254A8", Offset = "0x3D254A8", Length = "0x104")]
		public void Init(ParticleAnimationRegistry registry)
		{
			ParticleAnimationRegistry registry2 = default(ParticleAnimationRegistry);
			_registry = registry2;
			_registry.AddTarget(Key, this);
			UIParticleAttractor attractor = Attractor;
			UnityAction call = AnimateHolder;
			attractor.onAttracted.AddListener(call);
			if (ShowOnlyDuringAnimation)
			{
				GameObject gameObject = VisualParent.gameObject;
				gameObject.SetActive(value: false);
			}
		}

		[Token(Token = "0x600170B")]
		[Address(RVA = "0x3D255AC", Offset = "0x3D255AC", Length = "0xB0")]
		private void OnDisable()
		{
			if (_registry != null)
			{
				_registry.RemoveTarget(Key, this);
			}
			UIParticleAttractor attractor = Attractor;
			UnityAction call = AnimateHolder;
			attractor.onAttracted.RemoveListener(call);
		}

		[Token(Token = "0x600170C")]
		[Address(RVA = "0x3D2565C", Offset = "0x3D2565C", Length = "0xD8")]
		public void AnimateHolder()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleAnimationTarget::AnimateHolder");
		}

		[Token(Token = "0x600170D")]
		[Address(RVA = "0x3D25734", Offset = "0x3D25734", Length = "0x8")]
		public ParticleAnimationTarget()
		{
		}
	}
}
