using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x2000071")]
	public struct SpriteState : IEquatable<SpriteState>
	{
		[SerializeField]
		[Token(Token = "0x4000239")]
		[FieldOffset(Offset = "0x0")]
		private Sprite m_HighlightedSprite;

		[SerializeField]
		[Token(Token = "0x400023A")]
		[FieldOffset(Offset = "0x8")]
		private Sprite m_PressedSprite;

		[FormerlySerializedAs("m_HighlightedSprite")]
		[SerializeField]
		[Token(Token = "0x400023B")]
		[FieldOffset(Offset = "0x10")]
		private Sprite m_SelectedSprite;

		[SerializeField]
		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x18")]
		private Sprite m_DisabledSprite;

		[Token(Token = "0x17000132")]
		public Sprite highlightedSprite
		{
			[Token(Token = "0x6000492")]
			[Address(RVA = "0x18377F4", Offset = "0x18377F4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000493")]
			[Address(RVA = "0x18377FC", Offset = "0x18377FC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000133")]
		public Sprite pressedSprite
		{
			[Token(Token = "0x6000494")]
			[Address(RVA = "0x1837804", Offset = "0x1837804", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000495")]
			[Address(RVA = "0x183780C", Offset = "0x183780C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000134")]
		public Sprite selectedSprite
		{
			[Token(Token = "0x6000496")]
			[Address(RVA = "0x1837814", Offset = "0x1837814", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000497")]
			[Address(RVA = "0x183781C", Offset = "0x183781C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000135")]
		public Sprite disabledSprite
		{
			[Token(Token = "0x6000498")]
			[Address(RVA = "0x1837824", Offset = "0x1837824", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000499")]
			[Address(RVA = "0x183782C", Offset = "0x183782C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600049A")]
		[Address(RVA = "0x1837834", Offset = "0x1837834", Length = "0x108")]
		public bool Equals(SpriteState other)
		{
			return false;
		}
	}
}
