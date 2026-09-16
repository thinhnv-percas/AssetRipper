using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x2000036")]
	public struct SpriteState : IEquatable<SpriteState>
	{
		[SerializeField]
		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x0")]
		private Sprite m_HighlightedSprite;

		[SerializeField]
		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x8")]
		private Sprite m_PressedSprite;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729A38", Offset = "0x729A38")]
		[SerializeField]
		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x10")]
		private Sprite m_SelectedSprite;

		[SerializeField]
		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x18")]
		private Sprite m_DisabledSprite;

		[Token(Token = "0x17000118")]
		public Sprite highlightedSprite
		{
			[Token(Token = "0x60003FC")]
			[Address(RVA = "0x852080", Offset = "0x852080", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003FD")]
			[Address(RVA = "0x852088", Offset = "0x852088", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000119")]
		public Sprite pressedSprite
		{
			[Token(Token = "0x60003FE")]
			[Address(RVA = "0x852090", Offset = "0x852090", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003FF")]
			[Address(RVA = "0x852098", Offset = "0x852098", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700011A")]
		public Sprite selectedSprite
		{
			[Token(Token = "0x6000400")]
			[Address(RVA = "0x8520A0", Offset = "0x8520A0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000401")]
			[Address(RVA = "0x8520A8", Offset = "0x8520A8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700011B")]
		public Sprite disabledSprite
		{
			[Token(Token = "0x6000402")]
			[Address(RVA = "0x8520B0", Offset = "0x8520B0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000403")]
			[Address(RVA = "0x8520B8", Offset = "0x8520B8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000404")]
		[Address(RVA = "0x8520C0", Offset = "0x8520C0", Length = "0x1E8")]
		public bool Equals(SpriteState other)
		{
			return false;
		}
	}
}
