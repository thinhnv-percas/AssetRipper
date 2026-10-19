using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament
{
	[Serializable]
	[Token(Token = "0x200082B")]
	public class TournamentData
	{
		[JsonProperty("id")]
		[Token(Token = "0x4001BB2")]
		[FieldOffset(Offset = "0x10")]
		public int tournamentID;

		[JsonProperty("schedule_id")]
		[Token(Token = "0x4001BB3")]
		[FieldOffset(Offset = "0x14")]
		public int scheduleID;

		[JsonProperty("start_date")]
		[Token(Token = "0x4001BB4")]
		[FieldOffset(Offset = "0x18")]
		public long startDateUnix;

		[JsonProperty("end_date")]
		[Token(Token = "0x4001BB5")]
		[FieldOffset(Offset = "0x20")]
		public long endDateUnix;

		[JsonProperty("state")]
		[Token(Token = "0x4001BB6")]
		[FieldOffset(Offset = "0x28")]
		public TournamentState tournamentState;

		[Token(Token = "0x600231A")]
		[Address(RVA = "0x3DDC830", Offset = "0x3DDC830", Length = "0x8")]
		public TournamentData()
		{
		}
	}
}
