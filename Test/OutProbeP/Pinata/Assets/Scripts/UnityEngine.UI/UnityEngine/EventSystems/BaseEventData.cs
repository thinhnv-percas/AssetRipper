using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200004D")]
	public class BaseEventData : AbstractEventData
	{
		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x18")]
		private readonly EventSystem m_EventSystem;

		[Token(Token = "0x17000152")]
		public BaseInputModule currentInputModule
		{
			[Token(Token = "0x60004DA")]
			[Address(RVA = "0xC40D1C", Offset = "0xC40D1C", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000153")]
		public GameObject selectedObject
		{
			[Token(Token = "0x60004DB")]
			[Address(RVA = "0xC40D3C", Offset = "0xC40D3C", Length = "0x20")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004DC")]
			[Address(RVA = "0xC40D5C", Offset = "0xC40D5C", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x60004D9")]
		[Address(RVA = "0xC40CF0", Offset = "0xC40CF0", Length = "0x2C")]
		public BaseEventData(EventSystem eventSystem)
		{
		}
	}
}
