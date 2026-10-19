using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200087B")]
	public class StateInfo
	{
		[JsonProperty("tournament_id")]
		[Token(Token = "0x4001C59")]
		[FieldOffset(Offset = "0x10")]
		public int tournamentId;

		[JsonProperty("schedule_id")]
		[Token(Token = "0x4001C5A")]
		[FieldOffset(Offset = "0x14")]
		public int scheduleId;

		[JsonProperty("start_date")]
		[Token(Token = "0x4001C5B")]
		[FieldOffset(Offset = "0x18")]
		public long startDateUnix;

		[JsonProperty("end_date")]
		[Token(Token = "0x4001C5C")]
		[FieldOffset(Offset = "0x20")]
		public long endDateUnix;

		[JsonProperty("state")]
		[Token(Token = "0x4001C5D")]
		[FieldOffset(Offset = "0x28")]
		public TournamentState tournamentState;

		[Token(Token = "0x6002452")]
		[Address(RVA = "0x3DE9804", Offset = "0x3DE9804", Length = "0x8")]
		public StateInfo()
		{
		}
	}
}
