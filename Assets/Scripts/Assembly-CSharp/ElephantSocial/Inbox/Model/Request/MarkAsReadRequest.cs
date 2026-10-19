using System;
using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Inbox.Model.Request
{
	[Serializable]
	[Token(Token = "0x20008ED")]
	public class MarkAsReadRequest : SocialBaseData
	{
		[JsonProperty("id")]
		[Token(Token = "0x4001DDD")]
		[FieldOffset(Offset = "0x118")]
		public int Id;

		[Token(Token = "0x6002592")]
		[Address(RVA = "0x3E057CC", Offset = "0x3E057CC", Length = "0x8")]
		public MarkAsReadRequest()
		{
		}
	}
}
