using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x200005C")]
	public struct Navigation : IEquatable<Navigation>
	{
		[Flags]
		[Token(Token = "0x200005D")]
		public enum Mode
		{
			[Token(Token = "0x40001AD")]
			None = 0,
			[Token(Token = "0x40001AE")]
			Horizontal = 1,
			[Token(Token = "0x40001AF")]
			Vertical = 2,
			[Token(Token = "0x40001B0")]
			Automatic = 3,
			[Token(Token = "0x40001B1")]
			Explicit = 4
		}

		[SerializeField]
		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x0")]
		private Mode m_Mode;

		[SerializeField]
		[Tooltip("Enables navigation to wrap around from last to first or first to last element. Does not work for automatic grid navigation")]
		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x4")]
		private bool m_WrapAround;

		[SerializeField]
		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x8")]
		private Selectable m_SelectOnUp;

		[SerializeField]
		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x10")]
		private Selectable m_SelectOnDown;

		[SerializeField]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x18")]
		private Selectable m_SelectOnLeft;

		[SerializeField]
		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x20")]
		private Selectable m_SelectOnRight;

		[Token(Token = "0x170000DC")]
		public Mode mode
		{
			[Token(Token = "0x6000367")]
			[Address(RVA = "0x182C934", Offset = "0x182C934", Length = "0x8")]
			get
			{
				return Mode.None;
			}
			[Token(Token = "0x6000368")]
			[Address(RVA = "0x182C93C", Offset = "0x182C93C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000DD")]
		public bool wrapAround
		{
			[Token(Token = "0x6000369")]
			[Address(RVA = "0x182C944", Offset = "0x182C944", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600036A")]
			[Address(RVA = "0x182C94C", Offset = "0x182C94C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000DE")]
		public Selectable selectOnUp
		{
			[Token(Token = "0x600036B")]
			[Address(RVA = "0x182C958", Offset = "0x182C958", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600036C")]
			[Address(RVA = "0x182C960", Offset = "0x182C960", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000DF")]
		public Selectable selectOnDown
		{
			[Token(Token = "0x600036D")]
			[Address(RVA = "0x182C968", Offset = "0x182C968", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600036E")]
			[Address(RVA = "0x182C970", Offset = "0x182C970", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E0")]
		public Selectable selectOnLeft
		{
			[Token(Token = "0x600036F")]
			[Address(RVA = "0x182C978", Offset = "0x182C978", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000370")]
			[Address(RVA = "0x182C980", Offset = "0x182C980", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E1")]
		public Selectable selectOnRight
		{
			[Token(Token = "0x6000371")]
			[Address(RVA = "0x182C988", Offset = "0x182C988", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000372")]
			[Address(RVA = "0x182C990", Offset = "0x182C990", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E2")]
		public static Navigation defaultNavigation
		{
			[Token(Token = "0x6000373")]
			[Address(RVA = "0x182C998", Offset = "0x182C998", Length = "0x20")]
			get
			{
				return default(Navigation);
			}
		}

		[Token(Token = "0x6000374")]
		[Address(RVA = "0x182C9B8", Offset = "0x182C9B8", Length = "0x118")]
		public bool Equals(Navigation other)
		{
			return false;
		}
	}
}
