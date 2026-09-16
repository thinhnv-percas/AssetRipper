using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000098")]
	public class BaseEventData : AbstractEventData
	{
		[Token(Token = "0x40002AE")]
		[FieldOffset(Offset = "0x18")]
		private readonly EventSystem m_EventSystem;

		[Token(Token = "0x1700018F")]
		public BaseInputModule currentInputModule
		{
			[Token(Token = "0x60005F3")]
			[Address(RVA = "0x18425A4", Offset = "0x18425A4", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000190")]
		public GameObject selectedObject
		{
			[Token(Token = "0x60005F4")]
			[Address(RVA = "0x18425C0", Offset = "0x18425C0", Length = "0x1C")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005F5")]
			[Address(RVA = "0x18425DC", Offset = "0x18425DC", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0x1842558", Offset = "0x1842558", Length = "0x28")]
		public BaseEventData(EventSystem eventSystem)
		{
		}
	}
}
