using System;
using System.Collections;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Leaderboard.Model;
using ElephantSocial.Model;

namespace ElephantSocial.Leaderboard.Network
{
	[Token(Token = "0x20008D5")]
	public class LeaderboardOps : SocialOps
	{
		[Token(Token = "0x6002561")]
		[Address(RVA = "0x3E04B20", Offset = "0x3E04B20", Length = "0x27C")]
		public IEnumerator UpdateScore(BoardPlayer boardPlayer, int leaderboardId, string operation, int score, Action<GenericResponse<BoardPlayer>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LeaderboardOps::UpdateScore");
			return default;
		}

		[Token(Token = "0x6002562")]
		[Address(RVA = "0x3E04DF4", Offset = "0x3E04DF4", Length = "0x210")]
		public IEnumerator GetScore(int leaderboardId, Action<GenericResponse<BoardPlayer>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LeaderboardOps::GetScore");
			return default;
		}

		[Token(Token = "0x6002563")]
		[Address(RVA = "0x3E05030", Offset = "0x3E05030", Length = "0x210")]
		public IEnumerator GetLeaderboard(int leaderboardId, Action<GenericResponse<LeaderboardContainer>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LeaderboardOps::GetLeaderboard");
			return default;
		}

		[Token(Token = "0x6002564")]
		[Address(RVA = "0x3E05240", Offset = "0x3E05240", Length = "0x8")]
		public LeaderboardOps()
		{
		}
	}
}
