using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000025")]
	public struct TMP_Offset
	{
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x0")]
		private float m_Left;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x4")]
		private float m_Right;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x8")]
		private float m_Top;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0xC")]
		private float m_Bottom;

		[Token(Token = "0x4000120")]
		private static readonly TMP_Offset k_ZeroOffset;

		[Token(Token = "0x17000025")]
		public float left
		{
			[Token(Token = "0x6000127")]
			[Address(RVA = "0x15D0094", Offset = "0x15D0094", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000128")]
			[Address(RVA = "0x15D009C", Offset = "0x15D009C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000026")]
		public float right
		{
			[Token(Token = "0x6000129")]
			[Address(RVA = "0x15D00A4", Offset = "0x15D00A4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600012A")]
			[Address(RVA = "0x15D00AC", Offset = "0x15D00AC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000027")]
		public float top
		{
			[Token(Token = "0x600012B")]
			[Address(RVA = "0x15D00B4", Offset = "0x15D00B4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600012C")]
			[Address(RVA = "0x15D00BC", Offset = "0x15D00BC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000028")]
		public float bottom
		{
			[Token(Token = "0x600012D")]
			[Address(RVA = "0x15D00C4", Offset = "0x15D00C4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600012E")]
			[Address(RVA = "0x15D00CC", Offset = "0x15D00CC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000029")]
		public float horizontal
		{
			[Token(Token = "0x600012F")]
			[Address(RVA = "0x15D00D4", Offset = "0x15D00D4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000130")]
			[Address(RVA = "0x15D00DC", Offset = "0x15D00DC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002A")]
		public float vertical
		{
			[Token(Token = "0x6000131")]
			[Address(RVA = "0x15D00E4", Offset = "0x15D00E4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000132")]
			[Address(RVA = "0x15D00EC", Offset = "0x15D00EC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002B")]
		public static TMP_Offset zero
		{
			[Token(Token = "0x6000133")]
			[Address(RVA = "0x15D00F4", Offset = "0x15D00F4", Length = "0x5C")]
			get
			{
				return default(TMP_Offset);
			}
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x15D0150", Offset = "0x15D0150", Length = "0xC")]
		public TMP_Offset(float left, float right, float top, float bottom)
		{
			m_Left = 0f;
			m_Right = 0f;
			m_Top = 0f;
			m_Bottom = 0f;
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x15D015C", Offset = "0x15D015C", Length = "0xC")]
		public TMP_Offset(float horizontal, float vertical)
		{
			m_Left = 0f;
			m_Right = 0f;
			m_Top = 0f;
			m_Bottom = 0f;
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x15D0168", Offset = "0x15D0168", Length = "0x28")]
		public static bool operator ==(TMP_Offset lhs, TMP_Offset rhs)
		{
			return false;
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x15D0190", Offset = "0x15D0190", Length = "0xB0")]
		public static bool operator !=(TMP_Offset lhs, TMP_Offset rhs)
		{
			return false;
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x15D0240", Offset = "0x15D0240", Length = "0x14")]
		public static TMP_Offset operator *(TMP_Offset a, float b)
		{
			return default(TMP_Offset);
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x15D0254", Offset = "0x15D0254", Length = "0x64")]
		public override int GetHashCode()
		{
			return 0;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x15D02B8", Offset = "0x15D02B8", Length = "0x78")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0x15D0330", Offset = "0x15D0330", Length = "0xA8")]
		public bool Equals(TMP_Offset other)
		{
			return false;
		}
	}
}
