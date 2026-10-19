using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008B6")]
	public class IncrementStatRequest : SocialBaseData
	{
		[JsonProperty("incr_val")]
		[Token(Token = "0x170003E1")]
		[field: Token(Token = "0x4001D52")]
		[field: FieldOffset(Offset = "0x118")]
		public int IncrementValue
		{
			[Token(Token = "0x6002514")]
			[Address(RVA = "0x3DFEF14", Offset = "0x3DFEF14", Length = "0x8")]
			get;
			[Token(Token = "0x6002515")]
			[Address(RVA = "0x3DFEF1C", Offset = "0x3DFEF1C", Length = "0x8")]
			set;
		}

		[JsonProperty("stat_meta_id")]
		[Token(Token = "0x170003E2")]
		[field: Token(Token = "0x4001D53")]
		[field: FieldOffset(Offset = "0x120")]
		public string StatId
		{
			[Token(Token = "0x6002516")]
			[Address(RVA = "0x3DFEF24", Offset = "0x3DFEF24", Length = "0x8")]
			get;
			[Token(Token = "0x6002517")]
			[Address(RVA = "0x3DFEF2C", Offset = "0x3DFEF2C", Length = "0xC")]
			set;
		}

		[Token(Token = "0x6002518")]
		[Address(RVA = "0x3DF0640", Offset = "0x3DF0640", Length = "0x4")]
		public IncrementStatRequest()
		{
		}
	}
}
