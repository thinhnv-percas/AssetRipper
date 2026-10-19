using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000929")]
	public class MessagePayload
	{
		[JsonProperty("text_message")]
		[Token(Token = "0x17000447")]
		[field: Token(Token = "0x4001EB9")]
		[field: FieldOffset(Offset = "0x10")]
		public string TextMessage
		{
			[Token(Token = "0x60026F3")]
			[Address(RVA = "0x3E18664", Offset = "0x3E18664", Length = "0x8")]
			get;
			[Token(Token = "0x60026F4")]
			[Address(RVA = "0x3E1866C", Offset = "0x3E1866C", Length = "0x8")]
			set;
		}

		[JsonProperty("help_request")]
		[Token(Token = "0x17000448")]
		[field: Token(Token = "0x4001EBA")]
		[field: FieldOffset(Offset = "0x18")]
		public HelpRequestData HelpRequest
		{
			[Token(Token = "0x60026F5")]
			[Address(RVA = "0x3E18674", Offset = "0x3E18674", Length = "0x8")]
			get;
			[Token(Token = "0x60026F6")]
			[Address(RVA = "0x3E1867C", Offset = "0x3E1867C", Length = "0x8")]
			set;
		}

		[JsonProperty("reward")]
		[Token(Token = "0x17000449")]
		[field: Token(Token = "0x4001EBB")]
		[field: FieldOffset(Offset = "0x20")]
		public RewardData Reward
		{
			[Token(Token = "0x60026F7")]
			[Address(RVA = "0x3E18684", Offset = "0x3E18684", Length = "0x8")]
			get;
			[Token(Token = "0x60026F8")]
			[Address(RVA = "0x3E1868C", Offset = "0x3E1868C", Length = "0x8")]
			set;
		}

		[JsonProperty("join_request")]
		[Token(Token = "0x1700044A")]
		[field: Token(Token = "0x4001EBC")]
		[field: FieldOffset(Offset = "0x28")]
		public JoinRequestData JoinRequest
		{
			[Token(Token = "0x60026F9")]
			[Address(RVA = "0x3E18694", Offset = "0x3E18694", Length = "0x8")]
			get;
			[Token(Token = "0x60026FA")]
			[Address(RVA = "0x3E1869C", Offset = "0x3E1869C", Length = "0x8")]
			set;
		}

		[JsonProperty("join_accept")]
		[Token(Token = "0x1700044B")]
		[field: Token(Token = "0x4001EBD")]
		[field: FieldOffset(Offset = "0x30")]
		public JoinAcceptData JoinAccept
		{
			[Token(Token = "0x60026FB")]
			[Address(RVA = "0x3E186A4", Offset = "0x3E186A4", Length = "0x8")]
			get;
			[Token(Token = "0x60026FC")]
			[Address(RVA = "0x3E186AC", Offset = "0x3E186AC", Length = "0x8")]
			set;
		}

		[JsonProperty("join_reject")]
		[Token(Token = "0x1700044C")]
		[field: Token(Token = "0x4001EBE")]
		[field: FieldOffset(Offset = "0x38")]
		public JoinRejectData JoinReject
		{
			[Token(Token = "0x60026FD")]
			[Address(RVA = "0x3E186B4", Offset = "0x3E186B4", Length = "0x8")]
			get;
			[Token(Token = "0x60026FE")]
			[Address(RVA = "0x3E186BC", Offset = "0x3E186BC", Length = "0x8")]
			set;
		}

		[JsonProperty("kick")]
		[Token(Token = "0x1700044D")]
		[field: Token(Token = "0x4001EBF")]
		[field: FieldOffset(Offset = "0x40")]
		public KickData Kick
		{
			[Token(Token = "0x60026FF")]
			[Address(RVA = "0x3E186C4", Offset = "0x3E186C4", Length = "0x8")]
			get;
			[Token(Token = "0x6002700")]
			[Address(RVA = "0x3E186CC", Offset = "0x3E186CC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002701")]
		[Address(RVA = "0x3E186D4", Offset = "0x3E186D4", Length = "0x8")]
		public MessagePayload()
		{
		}
	}
}
