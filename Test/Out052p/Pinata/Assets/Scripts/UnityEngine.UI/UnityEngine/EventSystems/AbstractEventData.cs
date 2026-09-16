using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200004C")]
	public abstract class AbstractEventData
	{
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x10")]
		protected bool m_Used;

		[Token(Token = "0x17000151")]
		public virtual bool used
		{
			[Token(Token = "0x60004D7")]
			[Address(RVA = "0xC40C30", Offset = "0xC40C30", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x60004D5")]
		[Address(RVA = "0xC40C1C", Offset = "0xC40C1C", Length = "0x8")]
		public virtual void Reset()
		{
		}

		[Token(Token = "0x60004D6")]
		[Address(RVA = "0xC40C24", Offset = "0xC40C24", Length = "0xC")]
		public virtual void Use()
		{
		}

		[Token(Token = "0x60004D8")]
		[Address(RVA = "0xC40C38", Offset = "0xC40C38", Length = "0x8")]
		protected internal AbstractEventData()
		{
		}
	}
}
