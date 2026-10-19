using System;
using Cpp2ILInjected;
using ElephantSocial.Model;

namespace ElephantSocial.Inbox.Model.Request
{
	[Serializable]
	[Token(Token = "0x20008EC")]
	public class GetInboxRequest : SocialBaseData
	{
		[Token(Token = "0x6002591")]
		[Address(RVA = "0x3E05518", Offset = "0x3E05518", Length = "0x8")]
		public GetInboxRequest()
		{
		}
	}
}
