using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000097")]
	public abstract class AbstractEventData
	{
		[Token(Token = "0x40002AD")]
		[FieldOffset(Offset = "0x10")]
		protected bool m_Used;

		[Token(Token = "0x1700018E")]
		public virtual bool used
		{
			[Token(Token = "0x60005F0")]
			[Address(RVA = "0x1842594", Offset = "0x1842594", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x60005EE")]
		[Address(RVA = "0x1842580", Offset = "0x1842580", Length = "0x8")]
		public virtual void Reset()
		{
		}

		[Token(Token = "0x60005EF")]
		[Address(RVA = "0x1842588", Offset = "0x1842588", Length = "0xC")]
		public virtual void Use()
		{
		}

		[Token(Token = "0x60005F1")]
		[Address(RVA = "0x184259C", Offset = "0x184259C", Length = "0x8")]
		protected internal AbstractEventData()
		{
		}
	}
}
