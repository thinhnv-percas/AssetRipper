using System;
using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.HonorWall
{
	[Serializable]
	[Token(Token = "0x20008F0")]
	public class HonorWallGrantRequest : SocialBaseData
	{
		[JsonProperty("id")]
		[Token(Token = "0x4001DE1")]
		[FieldOffset(Offset = "0x118")]
		public int id;

		[Token(Token = "0x600259B")]
		[Address(RVA = "0x3E08740", Offset = "0x3E08740", Length = "0x8")]
		public HonorWallGrantRequest()
		{
		}
	}
}
