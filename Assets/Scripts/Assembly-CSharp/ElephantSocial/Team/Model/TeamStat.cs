using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model
{
	[Serializable]
	[Token(Token = "0x20008AD")]
	public class TeamStat
	{
		[JsonProperty("previous_stats")]
		[Token(Token = "0x4001D32")]
		[FieldOffset(Offset = "0x10")]
		public Objective[] PreviousObjectives;

		[JsonProperty("current_stats")]
		[Token(Token = "0x4001D33")]
		[FieldOffset(Offset = "0x18")]
		public Objective[] CurrentObjectives;

		[Token(Token = "0x600250B")]
		[Address(RVA = "0x3DFEDB4", Offset = "0x3DFEDB4", Length = "0x8")]
		public TeamStat()
		{
		}
	}
}
