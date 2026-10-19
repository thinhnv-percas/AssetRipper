using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200090E")]
	public class HelpRequestData
	{
		[JsonProperty("requested")]
		[Token(Token = "0x170003EB")]
		[field: Token(Token = "0x4001E54")]
		[field: FieldOffset(Offset = "0x10")]
		public int Requested
		{
			[Token(Token = "0x6002620")]
			[Address(RVA = "0x3E17B84", Offset = "0x3E17B84", Length = "0x8")]
			get;
			[Token(Token = "0x6002621")]
			[Address(RVA = "0x3E17B8C", Offset = "0x3E17B8C", Length = "0x8")]
			set;
		}

		[JsonProperty("received")]
		[Token(Token = "0x170003EC")]
		[field: Token(Token = "0x4001E55")]
		[field: FieldOffset(Offset = "0x14")]
		public int Received
		{
			[Token(Token = "0x6002622")]
			[Address(RVA = "0x3E17B94", Offset = "0x3E17B94", Length = "0x8")]
			get;
			[Token(Token = "0x6002623")]
			[Address(RVA = "0x3E17B9C", Offset = "0x3E17B9C", Length = "0x8")]
			set;
		}

		[JsonProperty("senders")]
		[Token(Token = "0x170003ED")]
		[field: Token(Token = "0x4001E56")]
		[field: FieldOffset(Offset = "0x18")]
		public List<string> Senders
		{
			[Token(Token = "0x6002624")]
			[Address(RVA = "0x3E17BA4", Offset = "0x3E17BA4", Length = "0x8")]
			get;
			[Token(Token = "0x6002625")]
			[Address(RVA = "0x3E17BAC", Offset = "0x3E17BAC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002626")]
		[Address(RVA = "0x3E17BB4", Offset = "0x3E17BB4", Length = "0x8")]
		public HelpRequestData()
		{
		}
	}
}
