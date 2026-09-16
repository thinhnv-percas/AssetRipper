using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x200000B")]
	public struct ColorBlock : IEquatable<ColorBlock>
	{
		[SerializeField]
		[FormerlySerializedAs("normalColor")]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x0")]
		private Color m_NormalColor;

		[SerializeField]
		[FormerlySerializedAs("highlightedColor")]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x10")]
		private Color m_HighlightedColor;

		[SerializeField]
		[FormerlySerializedAs("pressedColor")]
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x20")]
		private Color m_PressedColor;

		[SerializeField]
		[FormerlySerializedAs("m_HighlightedColor")]
		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x30")]
		private Color m_SelectedColor;

		[SerializeField]
		[FormerlySerializedAs("disabledColor")]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x40")]
		private Color m_DisabledColor;

		[Range(1f, 5f)]
		[SerializeField]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x50")]
		private float m_ColorMultiplier;

		[SerializeField]
		[FormerlySerializedAs("fadeDuration")]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x54")]
		private float m_FadeDuration;

		[Token(Token = "0x400002C")]
		public static ColorBlock defaultColorBlock;

		[Token(Token = "0x1700000B")]
		public Color normalColor
		{
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x16C2DDC", Offset = "0x16C2DDC", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x16C2DE8", Offset = "0x16C2DE8", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000C")]
		public Color highlightedColor
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x16C2DF4", Offset = "0x16C2DF4", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x16C2E00", Offset = "0x16C2E00", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000D")]
		public Color pressedColor
		{
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x16C2E0C", Offset = "0x16C2E0C", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x16C2E18", Offset = "0x16C2E18", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000E")]
		public Color selectedColor
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x16C2E24", Offset = "0x16C2E24", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x16C2E30", Offset = "0x16C2E30", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000F")]
		public Color disabledColor
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x16C2E3C", Offset = "0x16C2E3C", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x16C2E48", Offset = "0x16C2E48", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000010")]
		public float colorMultiplier
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x16C2E54", Offset = "0x16C2E54", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x16C2E5C", Offset = "0x16C2E5C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000011")]
		public float fadeDuration
		{
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x16C2E64", Offset = "0x16C2E64", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x16C2E6C", Offset = "0x16C2E6C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x16C2E74", Offset = "0x16C2E74", Length = "0x78")]
		static ColorBlock()
		{
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x16C2EEC", Offset = "0x16C2EEC", Length = "0xC0")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x16C2FAC", Offset = "0x16C2FAC", Length = "0x1F8")]
		public bool Equals(ColorBlock other)
		{
			return false;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x16C31A4", Offset = "0x16C31A4", Length = "0x94")]
		public static bool operator ==(ColorBlock point1, ColorBlock point2)
		{
			return false;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x16C3238", Offset = "0x16C3238", Length = "0x98")]
		public static bool operator !=(ColorBlock point1, ColorBlock point2)
		{
			return false;
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x16C32D0", Offset = "0x16C32D0", Length = "0x6C")]
		public override int GetHashCode()
		{
			return 0;
		}
	}
}
