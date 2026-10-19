using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSocial.HonorWall
{
	[Serializable]
	[Token(Token = "0x20008F2")]
	public class HonorWallResponse : List<Honor>
	{
		[Token(Token = "0x600259D")]
		[Address(RVA = "0x3E08750", Offset = "0x3E08750", Length = "0xA4")]
		public HonorWallResponse()
		{
		}
	}
}
