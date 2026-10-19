using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using UnityEngine;

namespace ElephantSocial.Tournament
{
	[Token(Token = "0x200085B")]
	public static class TournamentManager
	{
		[Token(Token = "0x4001C1C")]
		internal static readonly TournamentManagerService Service;

		[Token(Token = "0x60023D6")]
		[Address(RVA = "0x3DE804C", Offset = "0x3DE804C", Length = "0x104")]
		public static void add_OnTournamentsUpdated(Action value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManager::add_OnTournamentsUpdated");
		}

		[Token(Token = "0x60023D7")]
		[Address(RVA = "0x3DE8150", Offset = "0x3DE8150", Length = "0x104")]
		public static void remove_OnTournamentsUpdated(Action value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManager::remove_OnTournamentsUpdated");
		}

		[Token(Token = "0x60023D8")]
		[Address(RVA = "0x3DE8254", Offset = "0x3DE8254", Length = "0x8C")]
		public static void Init(Action onInitialized)
		{
			Service.Init(onInitialized);
		}

		[Token(Token = "0x60023D9")]
		[Address(RVA = "0x3DE82E0", Offset = "0x3DE82E0", Length = "0xF4")]
		public static List<Tournament> GetTournaments()
		{
			TournamentManagerService service = Service;
			if (Service == null)
			{
				return (List<Tournament>)(object)new NullReferenceException();
			}
			TournamentManagerService.TournamentManagerState tournamentManagerState = service._tournamentManagerState;
			if (tournamentManagerState.IsInitialized)
			{
				return tournamentManagerState.Tournaments;
			}
			ElephantLog.LogError("SocialTournament", "TournamentManager is not initialized.");
			return null;
		}

		[Token(Token = "0x60023DA")]
		[Address(RVA = "0x3DE83D4", Offset = "0x3DE83D4", Length = "0x8C")]
		public static Tournament GetTournamentById(int tournamentId)
		{
			return Service.GetTournamentById(tournamentId);
		}

		[Token(Token = "0x60023DB")]
		[Address(RVA = "0x3DE8460", Offset = "0x3DE8460", Length = "0x8C")]
		public static TournamentResult GetTournamentResultById(int tournamentId)
		{
			return Service.GetTournamentResultById(tournamentId);
		}

		[Token(Token = "0x60023DC")]
		[Address(RVA = "0x3DDDC78", Offset = "0x3DDDC78", Length = "0xB8")]
		public static long GetServerTime()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManager::GetServerTime");
			return default;
		}

		[Token(Token = "0x60023DD")]
		[Address(RVA = "0x3DE84EC", Offset = "0x3DE84EC", Length = "0x8C")]
		public static void IsOnline(Action<bool> onResult)
		{
			Service.IsOnline(onResult);
		}

		[Token(Token = "0x60023DE")]
		[Address(RVA = "0x3DE8578", Offset = "0x3DE8578", Length = "0x7C")]
		static TournamentManager()
		{
			TournamentManagerService service = new TournamentManagerService();
			Service = service;
		}
	}
}
