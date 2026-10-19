using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Inbox.Model.Response
{
	[Serializable]
	[Token(Token = "0x20008EB")]
	public class InboxResponse
	{
		[JsonProperty("items")]
		[Token(Token = "0x4001DDC")]
		[FieldOffset(Offset = "0x10")]
		public InboxItem[] Items;

		[Token(Token = "0x6002590")]
		[Address(RVA = "0x3E08008", Offset = "0x3E08008", Length = "0x8")]
		public InboxResponse()
		{
		}
	}
}
