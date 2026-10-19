using System;
using Cpp2ILInjected;
using ElephantSocial.Model;

namespace ElephantSocial.Team.Model.Request
{
	[Serializable]
	[Token(Token = "0x20008BB")]
	public class PlayerJoinRequestsRequest : SocialBaseData
	{
		[Token(Token = "0x600251D")]
		[Address(RVA = "0x3DEFD94", Offset = "0x3DEFD94", Length = "0x4")]
		public PlayerJoinRequestsRequest()
		{
		}
	}
}
