using System;
using Cpp2ILInjected;

namespace ElephantSocial.Model
{
	[Serializable]
	[Token(Token = "0x20008C5")]
	public class PlayerRequest : SocialBaseData
	{
		[Token(Token = "0x600252A")]
		[Address(RVA = "0x3DFE2BC", Offset = "0x3DFE2BC", Length = "0x4")]
		public PlayerRequest()
		{
		}
	}
}
