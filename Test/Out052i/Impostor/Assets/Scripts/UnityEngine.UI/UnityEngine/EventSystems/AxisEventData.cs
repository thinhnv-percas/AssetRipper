using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000096")]
	public class AxisEventData : BaseEventData
	{
		[Token(Token = "0x1700018C")]
		[field: Token(Token = "0x40002AB")]
		[field: FieldOffset(Offset = "0x20")]
		public Vector2 moveVector
		{
			[Token(Token = "0x60005E9")]
			[Address(RVA = "0x18424D0", Offset = "0x18424D0", Length = "0x8")]
			get;
			[Token(Token = "0x60005EA")]
			[Address(RVA = "0x18424D8", Offset = "0x18424D8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700018D")]
		[field: Token(Token = "0x40002AC")]
		[field: FieldOffset(Offset = "0x28")]
		public MoveDirection moveDir
		{
			[Token(Token = "0x60005EB")]
			[Address(RVA = "0x18424E0", Offset = "0x18424E0", Length = "0x8")]
			get;
			[Token(Token = "0x60005EC")]
			[Address(RVA = "0x18424E8", Offset = "0x18424E8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60005ED")]
		[Address(RVA = "0x18424F0", Offset = "0x18424F0", Length = "0x68")]
		public AxisEventData(EventSystem eventSystem)
			: base(null)
		{
		}
	}
}
