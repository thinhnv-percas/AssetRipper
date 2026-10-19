using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSocial.Model;

namespace ElephantSocial.Leaderboard
{
	[Serializable]
	[Token(Token = "0x20008D3")]
	public class LeaderboardRecords
	{
		[Token(Token = "0x4001DA8")]
		[FieldOffset(Offset = "0x10")]
		public long next;

		[Token(Token = "0x4001DA9")]
		[FieldOffset(Offset = "0x18")]
		public List<BoardPlayer> records;

		[Token(Token = "0x600255D")]
		[Address(RVA = "0x3E04978", Offset = "0x3E04978", Length = "0x8C")]
		public List<BoardPlayer> GetRecords()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E395]");
			List<BoardPlayer> result;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				result = records;
				if (records != null)
				{
					goto IL_0061;
				}
			}
			else
			{
				_ = 1;
				result = records;
				if (records != null)
				{
					goto IL_0061;
				}
			}
			return new List<BoardPlayer>();
			IL_0061:
			return result;
		}

		[Token(Token = "0x600255E")]
		[Address(RVA = "0x3E04A04", Offset = "0x3E04A04", Length = "0x8")]
		public LeaderboardRecords()
		{
		}
	}
}
