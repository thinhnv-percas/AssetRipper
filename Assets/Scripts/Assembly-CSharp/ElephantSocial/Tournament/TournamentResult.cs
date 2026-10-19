using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSocial.Model;
using ElephantSocial.Tournament.Model;
using ElephantSocial.Tournament.Network;

namespace ElephantSocial.Tournament
{
	[Token(Token = "0x2000858")]
	public class TournamentResult
	{
		[Token(Token = "0x4001C15")]
		[FieldOffset(Offset = "0x10")]
		public TournamentData TournamentData;

		[Token(Token = "0x4001C16")]
		[FieldOffset(Offset = "0x18")]
		private readonly TournamentRepository _tournamentRepository;

		[CompilerGenerated]
		[Token(Token = "0x4001C17")]
		private static Action<int, int> OnTournamentClaimed;

		[Token(Token = "0x170003C0")]
		public int TournamentId
		{
			[Token(Token = "0x60023CB")]
			[Address(RVA = "0x3DE4048", Offset = "0x3DE4048", Length = "0x1C")]
			get
			{
				TournamentData tournamentData = TournamentData;
				return tournamentData.tournamentID;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x60023CC")]
		[Address(RVA = "0x3DE0078", Offset = "0x3DE0078", Length = "0xD0")]
		internal static void add_OnTournamentClaimed(Action<int, int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentResult::add_OnTournamentClaimed");
		}

		[CompilerGenerated]
		[Token(Token = "0x60023CD")]
		[Address(RVA = "0x3DE7BDC", Offset = "0x3DE7BDC", Length = "0xD0")]
		internal static void remove_OnTournamentClaimed(Action<int, int> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentResult::remove_OnTournamentClaimed");
		}

		[Token(Token = "0x60023CE")]
		[Address(RVA = "0x3DE31E0", Offset = "0x3DE31E0", Length = "0xDC")]
		public TournamentResult(TournamentData tournamentData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentResult::.ctor");
		}

		[Token(Token = "0x60023CF")]
		[Address(RVA = "0x3DE7CAC", Offset = "0x3DE7CAC", Length = "0xEC")]
		public void GetBoard(Action<List<BoardPlayer>> onResponse)
		{
			TournamentData tournamentData = TournamentData;
			Action<TournamentBoardResponse> onResponse2 = delegate(TournamentBoardResponse boardPlayers)
			{
				if (onResponse != null)
				{
					onResponse(boardPlayers.boardPlayers);
				}
			};
			_tournamentRepository.GetBoard(tournamentData.tournamentID, tournamentData.scheduleID, onResponse2);
		}

		[Token(Token = "0x60023D0")]
		[Address(RVA = "0x3DE7DA0", Offset = "0x3DE7DA0", Length = "0x1BC")]
		public void Claim(Action onResponse, Action<string> onError)
		{
			TournamentData tournamentData = TournamentData;
			if (tournamentData.tournamentState == TournamentState.Completed)
			{
				Action onResponse2 = delegate
				{
					if (onResponse != null)
					{
						onResponse();
					}
					if (OnTournamentClaimed != null)
					{
						TournamentResult tournamentResult = this;
						TournamentData tournamentData2 = tournamentResult.TournamentData;
						OnTournamentClaimed(tournamentData2.tournamentID, tournamentData2.scheduleID);
					}
				};
				Action<string> onError2 = delegate(string message)
				{
					if (onError != null)
					{
						onError(message);
					}
				};
				_tournamentRepository.ClaimTournament(tournamentData.tournamentID, tournamentData.scheduleID, onResponse2, onError2);
			}
			else if (onError != null)
			{
				onError("Tournament is not completed.");
			}
		}
	}
}
