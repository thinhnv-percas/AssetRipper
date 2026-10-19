using System;
using Cpp2ILInjected;
using ElephantSDK;

namespace ElephantSocial
{
	[Serializable]
	[Token(Token = "0x200081B")]
	public class SocialConfig
	{
		[Token(Token = "0x4001B31")]
		[FieldOffset(Offset = "0x10")]
		public ElephantEnvironment elephantEnvironment;

		[Token(Token = "0x600228D")]
		[Address(RVA = "0x3DD60FC", Offset = "0x3DD60FC", Length = "0x2C")]
		public SocialConfig(ElephantEnvironment elephantEnvironment)
		{
			this.elephantEnvironment = elephantEnvironment;
		}
	}
}
