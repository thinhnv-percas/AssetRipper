using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSocial.Team.Model
{
	[Serializable]
	[Token(Token = "0x20008AB")]
	public class PlayerJoinRequestsResponse : List<TeamMemberResponse>
	{
		[Token(Token = "0x6002509")]
		[Address(RVA = "0x3DFED08", Offset = "0x3DFED08", Length = "0xA4")]
		public PlayerJoinRequestsResponse()
		{
		}
	}
}
