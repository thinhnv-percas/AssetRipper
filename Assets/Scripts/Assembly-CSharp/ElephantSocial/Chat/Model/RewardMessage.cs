using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000923")]
	public class RewardMessage : ChatMessage
	{
		[Token(Token = "0x17000434")]
		[field: Token(Token = "0x4001EA6")]
		[field: FieldOffset(Offset = "0x38")]
		public string RewardId
		{
			[Token(Token = "0x60026C7")]
			[Address(RVA = "0x3E1848C", Offset = "0x3E1848C", Length = "0x8")]
			get;
			[Token(Token = "0x60026C8")]
			[Address(RVA = "0x3E18494", Offset = "0x3E18494", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000435")]
		[field: Token(Token = "0x4001EA7")]
		[field: FieldOffset(Offset = "0x40")]
		public int MaxReceiver
		{
			[Token(Token = "0x60026C9")]
			[Address(RVA = "0x3E1849C", Offset = "0x3E1849C", Length = "0x8")]
			get;
			[Token(Token = "0x60026CA")]
			[Address(RVA = "0x3E184A4", Offset = "0x3E184A4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000436")]
		[field: Token(Token = "0x4001EA8")]
		[field: FieldOffset(Offset = "0x48")]
		public List<string> Receivers
		{
			[Token(Token = "0x60026CB")]
			[Address(RVA = "0x3E184AC", Offset = "0x3E184AC", Length = "0x8")]
			get;
			[Token(Token = "0x60026CC")]
			[Address(RVA = "0x3E184B4", Offset = "0x3E184B4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026CD")]
		[Address(RVA = "0x3E0F1D0", Offset = "0x3E0F1D0", Length = "0x98")]
		public RewardMessage()
		{
			List<string> list = new List<string>();
			Receivers = list;
			Type = ChatMessageType.REWARD;
		}
	}
}
