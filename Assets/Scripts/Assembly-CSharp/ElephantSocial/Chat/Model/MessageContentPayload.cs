using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000928")]
	public class MessageContentPayload
	{
		[JsonProperty("id")]
		[Token(Token = "0x1700043D")]
		[field: Token(Token = "0x4001EAF")]
		[field: FieldOffset(Offset = "0x10")]
		public string Id
		{
			[Token(Token = "0x60026DE")]
			[Address(RVA = "0x3E185B8", Offset = "0x3E185B8", Length = "0x8")]
			get;
			[Token(Token = "0x60026DF")]
			[Address(RVA = "0x3E185C0", Offset = "0x3E185C0", Length = "0x8")]
			set;
		}

		[JsonProperty("sender")]
		[Token(Token = "0x1700043E")]
		[field: Token(Token = "0x4001EB0")]
		[field: FieldOffset(Offset = "0x18")]
		public string SenderId
		{
			[Token(Token = "0x60026E0")]
			[Address(RVA = "0x3E185C8", Offset = "0x3E185C8", Length = "0x8")]
			get;
			[Token(Token = "0x60026E1")]
			[Address(RVA = "0x3E185D0", Offset = "0x3E185D0", Length = "0x8")]
			set;
		}

		[JsonProperty("sender_name")]
		[Token(Token = "0x1700043F")]
		[field: Token(Token = "0x4001EB1")]
		[field: FieldOffset(Offset = "0x20")]
		public string SenderName
		{
			[Token(Token = "0x60026E2")]
			[Address(RVA = "0x3E185D8", Offset = "0x3E185D8", Length = "0x8")]
			get;
			[Token(Token = "0x60026E3")]
			[Address(RVA = "0x3E185E0", Offset = "0x3E185E0", Length = "0x8")]
			set;
		}

		[JsonProperty("sender_profile_picture")]
		[Token(Token = "0x17000440")]
		[field: Token(Token = "0x4001EB2")]
		[field: FieldOffset(Offset = "0x28")]
		public string SenderProfilePicture
		{
			[Token(Token = "0x60026E4")]
			[Address(RVA = "0x3E185E8", Offset = "0x3E185E8", Length = "0x8")]
			get;
			[Token(Token = "0x60026E5")]
			[Address(RVA = "0x3E185F0", Offset = "0x3E185F0", Length = "0x8")]
			set;
		}

		[JsonProperty("payload_type")]
		[Token(Token = "0x17000441")]
		[field: Token(Token = "0x4001EB3")]
		[field: FieldOffset(Offset = "0x30")]
		public string PayloadType
		{
			[Token(Token = "0x60026E6")]
			[Address(RVA = "0x3E185F8", Offset = "0x3E185F8", Length = "0x8")]
			get;
			[Token(Token = "0x60026E7")]
			[Address(RVA = "0x3E18600", Offset = "0x3E18600", Length = "0x8")]
			set;
		}

		[JsonProperty("payload")]
		[Token(Token = "0x17000442")]
		[field: Token(Token = "0x4001EB4")]
		[field: FieldOffset(Offset = "0x38")]
		public MessagePayload SpecificPayload
		{
			[Token(Token = "0x60026E8")]
			[Address(RVA = "0x3E18608", Offset = "0x3E18608", Length = "0x8")]
			get;
			[Token(Token = "0x60026E9")]
			[Address(RVA = "0x3E18610", Offset = "0x3E18610", Length = "0x8")]
			set;
		}

		[JsonProperty("created_at")]
		[Token(Token = "0x17000443")]
		[field: Token(Token = "0x4001EB5")]
		[field: FieldOffset(Offset = "0x40")]
		public long CreatedAt
		{
			[Token(Token = "0x60026EA")]
			[Address(RVA = "0x3E18618", Offset = "0x3E18618", Length = "0x8")]
			get;
			[Token(Token = "0x60026EB")]
			[Address(RVA = "0x3E18620", Offset = "0x3E18620", Length = "0x8")]
			set;
		}

		[JsonProperty("updated_at")]
		[Token(Token = "0x17000444")]
		[field: Token(Token = "0x4001EB6")]
		[field: FieldOffset(Offset = "0x48")]
		public long UpdatedAt
		{
			[Token(Token = "0x60026EC")]
			[Address(RVA = "0x3E18628", Offset = "0x3E18628", Length = "0x8")]
			get;
			[Token(Token = "0x60026ED")]
			[Address(RVA = "0x3E18630", Offset = "0x3E18630", Length = "0x8")]
			set;
		}

		[JsonProperty("version")]
		[Token(Token = "0x17000445")]
		[field: Token(Token = "0x4001EB7")]
		[field: FieldOffset(Offset = "0x50")]
		public long Version
		{
			[Token(Token = "0x60026EE")]
			[Address(RVA = "0x3E18638", Offset = "0x3E18638", Length = "0x8")]
			get;
			[Token(Token = "0x60026EF")]
			[Address(RVA = "0x3E18640", Offset = "0x3E18640", Length = "0x8")]
			set;
		}

		[JsonProperty("deleted_at")]
		[Token(Token = "0x17000446")]
		[field: Token(Token = "0x4001EB8")]
		[field: FieldOffset(Offset = "0x58")]
		public long? DeletedAt
		{
			[Token(Token = "0x60026F0")]
			[Address(RVA = "0x3E18648", Offset = "0x3E18648", Length = "0xC")]
			get;
			[Token(Token = "0x60026F1")]
			[Address(RVA = "0x3E18654", Offset = "0x3E18654", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026F2")]
		[Address(RVA = "0x3E1865C", Offset = "0x3E1865C", Length = "0x8")]
		public MessageContentPayload()
		{
		}
	}
}
