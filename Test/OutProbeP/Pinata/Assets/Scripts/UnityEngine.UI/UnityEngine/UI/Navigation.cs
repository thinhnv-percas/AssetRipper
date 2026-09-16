using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x200002E")]
	public struct Navigation : IEquatable<Navigation>
	{
		[Flags]
		[Token(Token = "0x200009D")]
		public enum Mode
		{
			[Token(Token = "0x40002B7")]
			None = 0,
			[Token(Token = "0x40002B8")]
			Horizontal = 1,
			[Token(Token = "0x40002B9")]
			Vertical = 2,
			[Token(Token = "0x40002BA")]
			Automatic = 3,
			[Token(Token = "0x40002BB")]
			Explicit = 4
		}

		[SerializeField]
		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x0")]
		private Mode m_Mode;

		[SerializeField]
		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x8")]
		private Selectable m_SelectOnUp;

		[SerializeField]
		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x10")]
		private Selectable m_SelectOnDown;

		[SerializeField]
		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x18")]
		private Selectable m_SelectOnLeft;

		[SerializeField]
		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x20")]
		private Selectable m_SelectOnRight;

		[Token(Token = "0x170000C7")]
		public Mode mode
		{
			[Token(Token = "0x60002E4")]
			[Address(RVA = "0x851D1C", Offset = "0x851D1C", Length = "0x8")]
			get
			{
				return Mode.None;
			}
			[Token(Token = "0x60002E5")]
			[Address(RVA = "0x851D24", Offset = "0x851D24", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000C8")]
		public Selectable selectOnUp
		{
			[Token(Token = "0x60002E6")]
			[Address(RVA = "0x851D2C", Offset = "0x851D2C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002E7")]
			[Address(RVA = "0x851D34", Offset = "0x851D34", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000C9")]
		public Selectable selectOnDown
		{
			[Token(Token = "0x60002E8")]
			[Address(RVA = "0x851D3C", Offset = "0x851D3C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002E9")]
			[Address(RVA = "0x851D44", Offset = "0x851D44", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000CA")]
		public Selectable selectOnLeft
		{
			[Token(Token = "0x60002EA")]
			[Address(RVA = "0x851D4C", Offset = "0x851D4C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002EB")]
			[Address(RVA = "0x851D54", Offset = "0x851D54", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000CB")]
		public Selectable selectOnRight
		{
			[Token(Token = "0x60002EC")]
			[Address(RVA = "0x851D5C", Offset = "0x851D5C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002ED")]
			[Address(RVA = "0x851D64", Offset = "0x851D64", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000CC")]
		public static Navigation defaultNavigation
		{
			[Token(Token = "0x60002EE")]
			[Address(RVA = "0xECA5D8", Offset = "0xECA5D8", Length = "0x168")]
			get
			{
				return default(Navigation);
			}
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x851D6C", Offset = "0x851D6C", Length = "0x314")]
		public bool Equals(Navigation other)
		{
			return false;
		}
	}
}
