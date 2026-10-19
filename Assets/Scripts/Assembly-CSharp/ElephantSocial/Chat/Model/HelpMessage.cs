using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200091E")]
	public class HelpMessage : ChatMessage
	{
		[Token(Token = "0x1700041B")]
		[field: Token(Token = "0x4001E8D")]
		[field: FieldOffset(Offset = "0x38")]
		public int Max
		{
			[Token(Token = "0x600268F")]
			[Address(RVA = "0x3E182FC", Offset = "0x3E182FC", Length = "0x8")]
			get;
			[Token(Token = "0x6002690")]
			[Address(RVA = "0x3E18304", Offset = "0x3E18304", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700041C")]
		[field: Token(Token = "0x4001E8E")]
		[field: FieldOffset(Offset = "0x3C")]
		public int Received
		{
			[Token(Token = "0x6002691")]
			[Address(RVA = "0x3E1830C", Offset = "0x3E1830C", Length = "0x8")]
			get;
			[Token(Token = "0x6002692")]
			[Address(RVA = "0x3E18314", Offset = "0x3E18314", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700041D")]
		[field: Token(Token = "0x4001E8F")]
		[field: FieldOffset(Offset = "0x40")]
		public List<string> Senders
		{
			[Token(Token = "0x6002693")]
			[Address(RVA = "0x3E1831C", Offset = "0x3E1831C", Length = "0x8")]
			get;
			[Token(Token = "0x6002694")]
			[Address(RVA = "0x3E18324", Offset = "0x3E18324", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700041E")]
		[field: Token(Token = "0x4001E90")]
		[field: FieldOffset(Offset = "0x48")]
		public bool IsHelpedByMe
		{
			[Token(Token = "0x6002695")]
			[Address(RVA = "0x3E1832C", Offset = "0x3E1832C", Length = "0x8")]
			get;
			[Token(Token = "0x6002696")]
			[Address(RVA = "0x3E18334", Offset = "0x3E18334", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x6002697")]
		[Address(RVA = "0x3E0F11C", Offset = "0x3E0F11C", Length = "0xA8")]
		public HelpMessage(int requestedAmount)
		{
			List<string> list = new List<string>();
			Senders = list;
			Type = ChatMessageType.HELP;
			Max = requestedAmount;
		}

		[Token(Token = "0x6002698")]
		[Address(RVA = "0x3E0F1C4", Offset = "0x3E0F1C4", Length = "0xC")]
		public void Help()
		{
			IsHelpedByMe = true;
		}
	}
}
