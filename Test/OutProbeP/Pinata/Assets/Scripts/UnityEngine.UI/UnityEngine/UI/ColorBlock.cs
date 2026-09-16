using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 88)]
	[Token(Token = "0x2000007")]
	public struct ColorBlock : IEquatable<ColorBlock>
	{
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728260", Offset = "0x728260")]
		[SerializeField]
		[Token(Token = "0x4000019")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private Color m_NormalColor;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7282AC", Offset = "0x7282AC")]
		[SerializeField]
		[Token(Token = "0x400001A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private Color m_HighlightedColor;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7282F8", Offset = "0x7282F8")]
		[SerializeField]
		[Token(Token = "0x400001B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private Color m_PressedColor;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728344", Offset = "0x728344")]
		[SerializeField]
		[Token(Token = "0x400001C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private Color m_SelectedColor;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728390", Offset = "0x728390")]
		[SerializeField]
		[Token(Token = "0x400001D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		private Color m_DisabledColor;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7283DC", Offset = "0x7283DC")]
		[SerializeField]
		[Token(Token = "0x400001E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		private float m_ColorMultiplier;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x72841C", Offset = "0x72841C")]
		[SerializeField]
		[Token(Token = "0x400001F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x54")]
		private float m_FadeDuration;

		[Token(Token = "0x17000009")]
		public Color normalColor
		{
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x84BFF4", Offset = "0x84BFF4", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x84C000", Offset = "0x84C000", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000A")]
		public Color highlightedColor
		{
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x84C00C", Offset = "0x84C00C", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600002E")]
			[Address(RVA = "0x84C018", Offset = "0x84C018", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000B")]
		public Color pressedColor
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x84C024", Offset = "0x84C024", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x84C030", Offset = "0x84C030", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000C")]
		public Color selectedColor
		{
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x84C03C", Offset = "0x84C03C", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x84C048", Offset = "0x84C048", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000D")]
		public Color disabledColor
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x84C054", Offset = "0x84C054", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000034")]
			[Address(RVA = "0x84C060", Offset = "0x84C060", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000E")]
		public float colorMultiplier
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x84C06C", Offset = "0x84C06C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000036")]
			[Address(RVA = "0x84C074", Offset = "0x84C074", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700000F")]
		public float fadeDuration
		{
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x84C07C", Offset = "0x84C07C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x84C084", Offset = "0x84C084", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000010")]
		public static ColorBlock defaultColorBlock
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0xC4F350", Offset = "0xC4F350", Length = "0x330")]
			get
			{
				return default(ColorBlock);
			}
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x84C08C", Offset = "0x84C08C", Length = "0x8")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x84C094", Offset = "0x84C094", Length = "0x40")]
		public bool Equals(ColorBlock other)
		{
			return false;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0xC4F680", Offset = "0xC4F680", Length = "0x40")]
		public static bool operator ==(ColorBlock point1, ColorBlock point2)
		{
			return false;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0xC4F6C0", Offset = "0xC4F6C0", Length = "0xC0")]
		public static bool operator !=(ColorBlock point1, ColorBlock point2)
		{
			return false;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x84C0D4", Offset = "0x84C0D4", Length = "0x4C")]
		public override int GetHashCode()
		{
			return 0;
		}
	}
}
