using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200086B")]
	public class TournamentJoinRequest : BaseTournamentRequest
	{
		[JsonProperty("segment_id")]
		[Token(Token = "0x4001C3B")]
		[FieldOffset(Offset = "0x120")]
		public int SegmentId;

		[Token(Token = "0x6002420")]
		[Address(RVA = "0x3DE8A6C", Offset = "0x3DE8A6C", Length = "0x40")]
		public TournamentJoinRequest(int tournamentId, int scheduleID, int segmentId)
			: base(tournamentId, scheduleID)
		{
			base.tournamentId = tournamentId;
			base.scheduleID = scheduleID;
			SegmentId = segmentId;
		}
	}
}
