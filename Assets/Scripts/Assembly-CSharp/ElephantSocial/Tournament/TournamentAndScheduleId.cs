using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament
{
	[Serializable]
	[Token(Token = "0x200082A")]
	public class TournamentAndScheduleId
	{
		[JsonProperty("tournament_id")]
		[Token(Token = "0x4001BB0")]
		[FieldOffset(Offset = "0x10")]
		public int tournamentId;

		[JsonProperty("schedule_id")]
		[Token(Token = "0x4001BB1")]
		[FieldOffset(Offset = "0x14")]
		public int scheduleId;

		[JsonProperty("id")]
		[Token(Token = "0x170003B7")]
		private int id
		{
			[Token(Token = "0x6002318")]
			[Address(RVA = "0x3DDC820", Offset = "0x3DDC820", Length = "0x8")]
			set
			{
				tournamentId = value;
			}
		}

		[Token(Token = "0x6002319")]
		[Address(RVA = "0x3DDC828", Offset = "0x3DDC828", Length = "0x8")]
		public TournamentAndScheduleId()
		{
		}
	}
}
