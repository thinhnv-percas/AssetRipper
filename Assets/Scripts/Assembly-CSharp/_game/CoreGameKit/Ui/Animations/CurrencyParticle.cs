using Coffee.UIExtensions;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Ui.Animations
{
	[Token(Token = "0x2000573")]
	public class CurrencyParticle : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40012B7")]
		[FieldOffset(Offset = "0x20")]
		private UIParticle m_uiParticle;

		[SerializeField]
		[Token(Token = "0x40012B8")]
		[FieldOffset(Offset = "0x28")]
		private ParticleSystem m_particleSystem;

		[Token(Token = "0x17000209")]
		public UIParticle UIParticle
		{
			[Token(Token = "0x60016D9")]
			[Address(RVA = "0x3D2388C", Offset = "0x3D2388C", Length = "0x8")]
			get
			{
				return m_uiParticle;
			}
		}

		[Token(Token = "0x1700020A")]
		public ParticleSystem ParticleSystem
		{
			[Token(Token = "0x60016DA")]
			[Address(RVA = "0x3D23894", Offset = "0x3D23894", Length = "0x8")]
			get
			{
				return m_particleSystem;
			}
		}

		[Token(Token = "0x60016DB")]
		[Address(RVA = "0x3D2389C", Offset = "0x3D2389C", Length = "0x160")]
		private void Awake()
		{
			Object particleSystem;
			if (!(UIParticle == null))
			{
				particleSystem = ParticleSystem;
			}
			else
			{
				UIParticle component = GetComponent<UIParticle>();
				m_uiParticle = component;
				particleSystem = ParticleSystem;
			}
			if (particleSystem == null)
			{
				ParticleSystem componentInChildren = GetComponentInChildren<ParticleSystem>();
				m_particleSystem = componentInChildren;
			}
		}

		[Token(Token = "0x60016DC")]
		[Address(RVA = "0x3D22654", Offset = "0x3D22654", Length = "0xD4")]
		public void OnGet()
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: true);
			if (ParticleSystem != null)
			{
				ParticleSystem.Clear();
				ParticleSystem.Stop();
			}
		}

		[Token(Token = "0x60016DD")]
		[Address(RVA = "0x3D22740", Offset = "0x3D22740", Length = "0xD8")]
		public void OnRelease()
		{
			if (ParticleSystem != null)
			{
				ParticleSystem.Stop();
				ParticleSystem.Clear();
			}
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}

		[Token(Token = "0x60016DE")]
		[Address(RVA = "0x3D20CEC", Offset = "0x3D20CEC", Length = "0xB8")]
		public void Play()
		{
			if (ParticleSystem != null)
			{
				ParticleSystem.Play();
			}
		}

		[Token(Token = "0x60016DF")]
		[Address(RVA = "0x3D239FC", Offset = "0x3D239FC", Length = "0xB8")]
		public void Stop()
		{
			if (ParticleSystem != null)
			{
				ParticleSystem.Stop();
			}
		}

		[Token(Token = "0x60016E0")]
		[Address(RVA = "0x3D23AB4", Offset = "0x3D23AB4", Length = "0x8")]
		public CurrencyParticle()
		{
		}
	}
}
