using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSocial.Team.Model.Response
{
	[Serializable]
	[Token(Token = "0x20008B1")]
	public class TeamsListResponse : List<TeamResponse>
	{
		[Token(Token = "0x600250F")]
		[Address(RVA = "0x3DFEE70", Offset = "0x3DFEE70", Length = "0xA4")]
		public TeamsListResponse()
		{
		}
	}
}
