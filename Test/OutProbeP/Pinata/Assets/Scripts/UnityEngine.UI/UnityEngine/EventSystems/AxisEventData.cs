using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200004B")]
	public class AxisEventData : BaseEventData
	{
		[Token(Token = "0x1700014F")]
		[field: Token(Token = "0x4000196")]
		[field: FieldOffset(Offset = "0x20")]
		public Vector2 moveVector
		{
			[Token(Token = "0x60004D0")]
			[Address(RVA = "0xC40C40", Offset = "0xC40C40", Length = "0x8")]
			get;
			[Token(Token = "0x60004D1")]
			[Address(RVA = "0xC40C48", Offset = "0xC40C48", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000150")]
		[field: Token(Token = "0x4000197")]
		[field: FieldOffset(Offset = "0x28")]
		public MoveDirection moveDir
		{
			[Token(Token = "0x60004D2")]
			[Address(RVA = "0xC40C50", Offset = "0xC40C50", Length = "0x8")]
			get;
			[Token(Token = "0x60004D3")]
			[Address(RVA = "0xC40C58", Offset = "0xC40C58", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0xC40C60", Offset = "0xC40C60", Length = "0x90")]
		public AxisEventData(EventSystem eventSystem)
			: base(null)
		{
		}
	}
}
