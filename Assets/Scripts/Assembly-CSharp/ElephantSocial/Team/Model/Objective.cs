using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model
{
	[Serializable]
	[Token(Token = "0x20008AE")]
	public class Objective
	{
		[JsonProperty("id")]
		[Token(Token = "0x4001D34")]
		[FieldOffset(Offset = "0x10")]
		public string Id;

		[JsonProperty("name")]
		[Token(Token = "0x4001D35")]
		[FieldOffset(Offset = "0x18")]
		public string Name;

		[JsonProperty("description")]
		[Token(Token = "0x4001D36")]
		[FieldOffset(Offset = "0x20")]
		public string Description;

		[JsonProperty("value")]
		[Token(Token = "0x4001D37")]
		[FieldOffset(Offset = "0x28")]
		public long Value;

		[JsonProperty("goal")]
		[Token(Token = "0x4001D38")]
		[FieldOffset(Offset = "0x30")]
		public long Goal;

		[JsonProperty("end_date")]
		[Token(Token = "0x4001D39")]
		[FieldOffset(Offset = "0x38")]
		public long EndDate;

		[Token(Token = "0x600250C")]
		[Address(RVA = "0x3DFEDBC", Offset = "0x3DFEDBC", Length = "0x8")]
		public Objective()
		{
		}
	}
}
