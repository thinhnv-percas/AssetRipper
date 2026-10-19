using System;
using Cpp2ILInjected;
using ElephantSocial.Model;

namespace ElephantSocial.Team.Model.Request
{
	[Serializable]
	[Token(Token = "0x20008B7")]
	public class JoinRequestsRequest : SocialBaseData
	{
		[Token(Token = "0x6002519")]
		[Address(RVA = "0x3DEFAD8", Offset = "0x3DEFAD8", Length = "0x4")]
		public JoinRequestsRequest()
		{
		}
	}
}
