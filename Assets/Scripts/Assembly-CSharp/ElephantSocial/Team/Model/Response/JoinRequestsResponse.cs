using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSocial.Team.Model.Response
{
	[Serializable]
	[Token(Token = "0x20008AF")]
	public class JoinRequestsResponse : List<TeamMemberResponse>
	{
		[Token(Token = "0x600250D")]
		[Address(RVA = "0x3DFEDC4", Offset = "0x3DFEDC4", Length = "0xA4")]
		public JoinRequestsResponse()
		{
		}
	}
}
