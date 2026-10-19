using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSocial.Model;
using ElephantSocial.Tournament.Model;
using ElephantSocial.Tournament.Network;
using UnityEngine;

namespace ElephantSocial.Tournament
{
	[Token(Token = "0x200082C")]
	public class Tournament
	{
		[CompilerGenerated]
		[Token(Token = "0x4001BB7")]
		internal static Action OnTournamentJoined;

		[Token(Token = "0x4001BB8")]
		[FieldOffset(Offset = "0x10")]
		public TournamentData TournamentData;

		[Token(Token = "0x4001BB9")]
		[FieldOffset(Offset = "0x18")]
		private readonly TournamentRepository _tournamentRepository;

		[Token(Token = "0x4001BBA")]
		[FieldOffset(Offset = "0x20")]
		public bool HasJoined;

		[Token(Token = "0x170003B8")]
		public int TournamentId
		{
			[Token(Token = "0x600231D")]
			[Address(RVA = "0x3DDC9B8", Offset = "0x3DDC9B8", Length = "0x1C")]
			get
			{
				TournamentData tournamentData = TournamentData;
				return tournamentData.tournamentID;
			}
		}

		[Token(Token = "0x170003B9")]
		public long StartTime
		{
			[Token(Token = "0x600231E")]
			[Address(RVA = "0x3DDC9D4", Offset = "0x3DDC9D4", Length = "0x1C")]
			get
			{
				TournamentData tournamentData = TournamentData;
				return tournamentData.startDateUnix;
			}
		}

		[Token(Token = "0x170003BA")]
		public long EndTime
		{
			[Token(Token = "0x600231F")]
			[Address(RVA = "0x3DDC9F0", Offset = "0x3DDC9F0", Length = "0x1C")]
			get
			{
				TournamentData tournamentData = TournamentData;
				return tournamentData.endDateUnix;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x600231B")]
		[Address(RVA = "0x3DDC838", Offset = "0x3DDC838", Length = "0xC0")]
		internal static void add_OnTournamentJoined(Action value)
		{
			Action action = OnTournamentJoined;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnTournamentJoined, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600231C")]
		[Address(RVA = "0x3DDC8F8", Offset = "0x3DDC8F8", Length = "0xC0")]
		internal static void remove_OnTournamentJoined(Action value)
		{
			Action action = OnTournamentJoined;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnTournamentJoined, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x6002320")]
		[Address(RVA = "0x3DDCA0C", Offset = "0x3DDCA0C", Length = "0xDC")]
		public Tournament(TournamentData tournamentData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tournament::.ctor");
		}

		[Token(Token = "0x6002321")]
		[Address(RVA = "0x3DDCB60", Offset = "0x3DDCB60", Length = "0x24")]
		public bool IsRunning()
		{
			TournamentData tournamentData = TournamentData;
			int num = (int)(tournamentData.tournamentState - 1);
			return num == 0;
		}

		[Token(Token = "0x6002322")]
		[Address(RVA = "0x3DDCB84", Offset = "0x3DDCB84", Length = "0x1D4")]
		public void Join(Action<List<BoardPlayer>> onResponse, Action<string> onError, int segmentId = 0)
		{
			TournamentData tournamentData = TournamentData;
			if (tournamentData.tournamentState == TournamentState.Running)
			{
				Action<TournamentJoinResponse> onResponse2 = delegate(TournamentJoinResponse tournamentJoinResponse)
				{
					Tournament tournament = this;
					tournament.HasJoined = true;
					if (OnTournamentJoined != null)
					{
						OnTournamentJoined();
					}
					if (onResponse != null)
					{
						onResponse(tournamentJoinResponse.boardPlayers);
					}
				};
				Action<string> onError2 = delegate(string message)
				{
					if (onError != null)
					{
						onError(message);
					}
				};
				_tournamentRepository.JoinTournament(tournamentData.tournamentID, tournamentData.scheduleID, segmentId, onResponse2, onError2);
			}
			else if (onError != null)
			{
				onError("Tournament is not in a running state.");
			}
		}

		[Token(Token = "0x6002323")]
		[Address(RVA = "0x3DDCEAC", Offset = "0x3DDCEAC", Length = "0x2A8")]
		public unsafe void AddScore(int score, Action onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tournament::AddScore");
		}

		[Token(Token = "0x6002324")]
		[Address(RVA = "0x3DDD464", Offset = "0x3DDD464", Length = "0x17C")]
		public void AddMatch(List<ScoreUpdate> scoreUpdates, Action onResponse, Action<string> onError)
		{
			if (HasJoined)
			{
				TournamentData tournamentData = TournamentData;
				if (tournamentData.tournamentState == TournamentState.Running)
				{
					Action<string> onError2 = delegate(string error)
					{
						if (onError != null)
						{
							onError(error);
						}
					};
					_tournamentRepository.AddMatch(tournamentData.tournamentID, tournamentData.scheduleID, scoreUpdates, onResponse, onError2);
					return;
				}
			}
			if (onError != null)
			{
				onError("Cannot add match to this tournament.");
			}
		}

		[Token(Token = "0x6002325")]
		[Address(RVA = "0x3DDD734", Offset = "0x3DDD734", Length = "0x30")]
		public void ListMatches(Action<List<TournamentMatchItem>> onResponse, Action<string> onError)
		{
			TournamentData tournamentData = TournamentData;
			_tournamentRepository.ListMatches(tournamentData.tournamentID, tournamentData.scheduleID, onResponse, onError);
		}

		[Token(Token = "0x6002326")]
		[Address(RVA = "0x3DDD8A8", Offset = "0x3DDD8A8", Length = "0xEC")]
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

		[Token(Token = "0x6002327")]
		[Address(RVA = "0x3DDDB28", Offset = "0x3DDDB28", Length = "0x150")]
		public long GetRemainingSeconds()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tournament::GetRemainingSeconds");
			return default;
		}
	}
}
