using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using ElephantSocial.Tournament.Network;
using UnityEngine;

namespace ElephantSocial.Tournament
{
	[Token(Token = "0x2000835")]
	internal class TournamentManagerService
	{
		[Token(Token = "0x2000836")]
		internal class TournamentManagerState
		{
			[Token(Token = "0x4001BD5")]
			[FieldOffset(Offset = "0x10")]
			public List<Tournament> Tournaments;

			[Token(Token = "0x4001BD6")]
			[FieldOffset(Offset = "0x18")]
			public List<TournamentResult> TournamentResults;

			[Token(Token = "0x4001BD7")]
			[FieldOffset(Offset = "0x20")]
			public long ServerTime;

			[Token(Token = "0x4001BD8")]
			[FieldOffset(Offset = "0x28")]
			public bool IsInitialized;

			[Token(Token = "0x600236E")]
			[Address(RVA = "0x3DDFEF4", Offset = "0x3DDFEF4", Length = "0xE0")]
			public TournamentManagerState()
			{
				List<Tournament> tournaments = new List<Tournament>();
				Tournaments = tournaments;
				List<TournamentResult> tournamentResults = new List<TournamentResult>();
				TournamentResults = tournamentResults;
			}
		}

		[Token(Token = "0x2000837")]
		private class UpdateConfig
		{
			[Token(Token = "0x4001BD9")]
			[FieldOffset(Offset = "0x10")]
			public float CheckInterval;

			[Token(Token = "0x4001BDA")]
			[FieldOffset(Offset = "0x14")]
			public float EndingSoonInterval;

			[Token(Token = "0x600236F")]
			[Address(RVA = "0x3DDFFD4", Offset = "0x3DDFFD4", Length = "0xA4")]
			public UpdateConfig()
			{
				RemoteConfig instance = RemoteConfig.GetInstance();
				float checkInterval = instance.GetFloat("tournament_update_interval", 30f);
				CheckInterval = checkInterval;
				RemoteConfig instance2 = RemoteConfig.GetInstance();
				float endingSoonInterval = instance2.GetFloat("tournament_ending_soon_update_interval", 5f);
				EndingSoonInterval = endingSoonInterval;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000838")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001BDB")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001BDC")]
			public static Func<TournamentResult, int> _003C_003E9__7_1;

			[Token(Token = "0x4001BDD")]
			public static Func<TournamentData, Tournament> _003C_003E9__17_1;

			[Token(Token = "0x4001BDE")]
			public static Func<Tournament, bool> _003C_003E9__17_4;

			[Token(Token = "0x4001BDF")]
			public static Predicate<Tournament> _003C_003E9__27_1;

			[Token(Token = "0x6002370")]
			[Address(RVA = "0x3DE3508", Offset = "0x3DE3508", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6002371")]
			[Address(RVA = "0x3DE356C", Offset = "0x3DE356C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal int _003CGetTournamentResultById_003Eb__7_1(TournamentResult t)
			{
				TournamentData tournamentData = t.TournamentData;
				return tournamentData.scheduleID;
			}

			internal Tournament _003CFetchTournamentData_003Eb__17_1(TournamentData tournamentData)
			{
				return new Tournament(tournamentData);
			}

			internal bool _003CFetchTournamentData_003Eb__17_4(Tournament t)
			{
				return t.HasJoined;
			}

			internal bool _003CHandleTournamentJoined_003Eb__27_1(Tournament t)
			{
				return t.HasJoined;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200083A")]
		private sealed class _003C_003Ec__DisplayClass17_0
		{
			[Token(Token = "0x4001BE1")]
			[FieldOffset(Offset = "0x10")]
			public TournamentManagerService _003C_003E4__this;

			[Token(Token = "0x4001BE2")]
			[FieldOffset(Offset = "0x18")]
			public bool isInitialFetch;

			[Token(Token = "0x4001BE3")]
			[FieldOffset(Offset = "0x20")]
			public Action onComplete;

			[Token(Token = "0x6002379")]
			[Address(RVA = "0x3DE0A48", Offset = "0x3DE0A48", Length = "0x8")]
			public _003C_003Ec__DisplayClass17_0()
			{
			}

			internal unsafe void _003CFetchTournamentData_003Eb__0(TournamentsResponse tournamentsResponse)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService._003C_003Ec__DisplayClass17_0::_003CFetchTournamentData_003Eb__0");
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200083B")]
		private sealed class _003C_003Ec__DisplayClass17_1
		{
			[Token(Token = "0x4001BE4")]
			[FieldOffset(Offset = "0x10")]
			public List<Tournament> tournaments;

			[Token(Token = "0x4001BE5")]
			[FieldOffset(Offset = "0x18")]
			public TournamentsResponse tournamentsResponse;

			[Token(Token = "0x4001BE6")]
			[FieldOffset(Offset = "0x20")]
			public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

			[Token(Token = "0x600237B")]
			[Address(RVA = "0x3DE38E0", Offset = "0x3DE38E0", Length = "0x8")]
			public _003C_003Ec__DisplayClass17_1()
			{
			}

			internal unsafe void _003CFetchTournamentData_003Eb__2(MyTournamentsResponse myTournamentsResponse)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService._003C_003Ec__DisplayClass17_1::_003CFetchTournamentData_003Eb__2");
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200083C")]
		private sealed class _003C_003Ec__DisplayClass17_2
		{
			[Token(Token = "0x4001BE7")]
			[FieldOffset(Offset = "0x10")]
			public MyTournamentsResponse myTournamentsResponse;

			[Token(Token = "0x4001BE8")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals2;

			[Token(Token = "0x600237D")]
			[Address(RVA = "0x3DE39D8", Offset = "0x3DE39D8", Length = "0x8")]
			public _003C_003Ec__DisplayClass17_2()
			{
			}

			internal unsafe void _003CFetchTournamentData_003Eb__3(MyTournamentResultsResponse resultsResponse)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService._003C_003Ec__DisplayClass17_2::_003CFetchTournamentData_003Eb__3");
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200083D")]
		private sealed class _003C_003Ec__DisplayClass17_3
		{
			[Token(Token = "0x4001BE9")]
			[FieldOffset(Offset = "0x10")]
			public TournamentData newResultData;

			[Token(Token = "0x600237F")]
			[Address(RVA = "0x3DE3FEC", Offset = "0x3DE3FEC", Length = "0x8")]
			public _003C_003Ec__DisplayClass17_3()
			{
			}

			internal bool _003CFetchTournamentData_003Eb__5(TournamentResult r)
			{
				TournamentData tournamentData = r.TournamentData;
				TournamentData tournamentData2 = newResultData;
				if (tournamentData.tournamentID == tournamentData2.tournamentID)
				{
					int num = tournamentData.scheduleID - tournamentData2.scheduleID;
					return num == 0;
				}
				return false;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200083E")]
		private sealed class _003C_003Ec__DisplayClass18_0
		{
			[Token(Token = "0x4001BEA")]
			[FieldOffset(Offset = "0x10")]
			public Tournament tournament;

			[Token(Token = "0x6002381")]
			[Address(RVA = "0x3DE0DDC", Offset = "0x3DE0DDC", Length = "0x8")]
			public _003C_003Ec__DisplayClass18_0()
			{
			}

			internal bool _003CProcessJoinedTournaments_003Eb__0(TournamentAndScheduleId id)
			{
				Tournament tournament = this.tournament;
				TournamentData tournamentData = tournament.TournamentData;
				if (id.tournamentId == tournamentData.tournamentID)
				{
					int num = id.scheduleId - tournamentData.scheduleID;
					return num == 0;
				}
				return false;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200083F")]
		private sealed class _003C_003Ec__DisplayClass19_0
		{
			[Token(Token = "0x4001BEB")]
			[FieldOffset(Offset = "0x10")]
			public int processedCount;

			[Token(Token = "0x4001BEC")]
			[FieldOffset(Offset = "0x18")]
			public List<Tournament> joinedTournaments;

			[Token(Token = "0x4001BED")]
			[FieldOffset(Offset = "0x20")]
			public Action onComplete;

			[Token(Token = "0x4001BEE")]
			[FieldOffset(Offset = "0x28")]
			public Action<List<BoardPlayer>> _003C_003E9__0;

			[Token(Token = "0x6002383")]
			[Address(RVA = "0x3DE0FF0", Offset = "0x3DE0FF0", Length = "0x8")]
			public _003C_003Ec__DisplayClass19_0()
			{
			}

			internal void _003CFetchBoardsForJoinedTournaments_003Eb__0(List<BoardPlayer> _)
			{
				int num = ++processedCount;
				List<Tournament> list = joinedTournaments;
				if (num == list.Count && onComplete != null)
				{
					onComplete();
				}
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000840")]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			[Token(Token = "0x4001BEF")]
			[FieldOffset(Offset = "0x10")]
			public int tournamentId;

			[Token(Token = "0x4001BF0")]
			[FieldOffset(Offset = "0x14")]
			public int scheduleId;

			[Token(Token = "0x6002385")]
			[Address(RVA = "0x3DE151C", Offset = "0x3DE151C", Length = "0x8")]
			public _003C_003Ec__DisplayClass20_0()
			{
			}

			internal bool _003CSyncOfflineScores_003Eb__0(TournamentData t)
			{
				if (t.tournamentID == tournamentId)
				{
					int num = t.scheduleID - scheduleId;
					return num == 0;
				}
				return false;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000841")]
		private sealed class _003C_003Ec__DisplayClass22_0
		{
			[Token(Token = "0x4001BF1")]
			[FieldOffset(Offset = "0x10")]
			public List<Tournament> newTournaments;

			[Token(Token = "0x4001BF2")]
			[FieldOffset(Offset = "0x18")]
			public Func<Tournament, bool> _003C_003E9__0;

			[Token(Token = "0x6002387")]
			[Address(RVA = "0x3DE1FA8", Offset = "0x3DE1FA8", Length = "0x8")]
			public _003C_003Ec__DisplayClass22_0()
			{
			}

			internal bool _003CCheckTournamentStates_003Eb__0(Tournament existingTournament)
			{
				Func<Tournament, bool> predicate = delegate(Tournament t)
				{
					TournamentData tournamentData = t.TournamentData;
					Tournament tournament = existingTournament;
					TournamentData tournamentData2 = tournament.TournamentData;
					int num = tournamentData.tournamentID - tournamentData2.tournamentID;
					bool flag = num == 0;
					return !flag;
				};
				return newTournaments.All((Func<object, bool>)predicate);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000847")]
		private sealed class _003C_003Ec__DisplayClass26_0
		{
			[Token(Token = "0x4001BF9")]
			[FieldOffset(Offset = "0x10")]
			public TournamentData newResultData;

			[Token(Token = "0x6002393")]
			[Address(RVA = "0x3DE31D8", Offset = "0x3DE31D8", Length = "0x8")]
			public _003C_003Ec__DisplayClass26_0()
			{
			}

			internal bool _003CHandleTournamentClaimed_003Eb__1(TournamentResult r)
			{
				TournamentData tournamentData = r.TournamentData;
				TournamentData tournamentData2 = newResultData;
				if (tournamentData.tournamentID == tournamentData2.tournamentID)
				{
					int num = tournamentData.scheduleID - tournamentData2.scheduleID;
					return num == 0;
				}
				return false;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200084B")]
		private sealed class _003CUpdateTournamentsRoutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001BFE")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001BFF")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001C00")]
			[FieldOffset(Offset = "0x20")]
			public TournamentManagerService _003C_003E4__this;

			[Token(Token = "0x170003BE")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600239E")]
				[Address(RVA = "0x3DE46F4", Offset = "0x3DE46F4", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170003BF")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60023A0")]
				[Address(RVA = "0x3DE473C", Offset = "0x3DE473C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600239B")]
			[Address(RVA = "0x3DE1990", Offset = "0x3DE1990", Length = "0x2C")]
			public _003CUpdateTournamentsRoutine_003Ed__21(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600239C")]
			[Address(RVA = "0x3DE4614", Offset = "0x3DE4614", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600239D")]
			[Address(RVA = "0x3DE4618", Offset = "0x3DE4618", Length = "0xDC")]
			private bool MoveNext()
			{
				if ((uint)_003C_003E1__state < 2u)
				{
					TournamentManagerService tournamentManagerService = _003C_003E4__this;
					_003C_003E1__state = -1;
					TournamentManagerState tournamentManagerState = tournamentManagerService._tournamentManagerState;
					if (tournamentManagerState.IsInitialized)
					{
						tournamentManagerService.FetchTournamentData(isInitialFetch: false);
						float updateInterval = tournamentManagerService.GetUpdateInterval();
						WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(updateInterval);
						_003C_003E2__current = waitForSecondsRealtime;
						_003C_003E1__state = 1;
						return true;
					}
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600239F")]
			[Address(RVA = "0x3DE46FC", Offset = "0x3DE46FC", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x4001BCF")]
		[FieldOffset(Offset = "0x10")]
		internal Action OnTournamentsUpdated;

		[Token(Token = "0x4001BD0")]
		[FieldOffset(Offset = "0x18")]
		private readonly TournamentRepository _tournamentRepository;

		[Token(Token = "0x4001BD1")]
		[FieldOffset(Offset = "0x20")]
		internal TournamentManagerState _tournamentManagerState;

		[Token(Token = "0x4001BD2")]
		[FieldOffset(Offset = "0x28")]
		private readonly UpdateConfig _config;

		[Token(Token = "0x4001BD3")]
		[FieldOffset(Offset = "0x30")]
		internal float _lastServerTimeUpdateTime;

		[Token(Token = "0x4001BD4")]
		[FieldOffset(Offset = "0x38")]
		private readonly TournamentOps _tournamentOps;

		[CompilerGenerated]
		[Token(Token = "0x6002356")]
		[Address(RVA = "0x3DDFB04", Offset = "0x3DDFB04", Length = "0xA4")]
		public void add_OnTournamentsUpdated(Action value)
		{
			Action action = OnTournamentsUpdated;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnTournamentsUpdated, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6002357")]
		[Address(RVA = "0x3DDFBA8", Offset = "0x3DDFBA8", Length = "0xA4")]
		public void remove_OnTournamentsUpdated(Action value)
		{
			Action action = OnTournamentsUpdated;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnTournamentsUpdated, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x6002358")]
		[Address(RVA = "0x3DDFC4C", Offset = "0x3DDFC4C", Length = "0x2A0")]
		public TournamentManagerService()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::.ctor");
		}

		[Token(Token = "0x6002359")]
		[Address(RVA = "0x3DE0148", Offset = "0x3DE0148", Length = "0xE4")]
		public void Init(Action onComplete)
		{
			Action onComplete2 = delegate
			{
				TournamentManagerService tournamentManagerService = this;
				TournamentManagerState tournamentManagerState = tournamentManagerService._tournamentManagerState;
				tournamentManagerState.IsInitialized = true;
				if (onComplete != null)
				{
					onComplete();
				}
				_003CUpdateTournamentsRoutine_003Ed__21 _003CUpdateTournamentsRoutine_003Ed__22 = (_003CUpdateTournamentsRoutine_003Ed__21)FormatterServices.GetUninitializedObject(typeof(_003CUpdateTournamentsRoutine_003Ed__21));
				_003CUpdateTournamentsRoutine_003Ed__22._003C_003E1__state = 0;
				_003CUpdateTournamentsRoutine_003Ed__22._003C_003E4__this = this;
				Coroutine coroutine = ElephantCore.Instance.StartCoroutine(_003CUpdateTournamentsRoutine_003Ed__22);
			};
			FetchTournamentData(isInitialFetch: true, onComplete2);
		}

		[Token(Token = "0x600235A")]
		[Address(RVA = "0x3DE0324", Offset = "0x3DE0324", Length = "0x94")]
		public List<Tournament> GetTournaments()
		{
			TournamentManagerState tournamentManagerState = _tournamentManagerState;
			if (tournamentManagerState.IsInitialized)
			{
				return tournamentManagerState.Tournaments;
			}
			ElephantLog.LogError("SocialTournament", "TournamentManager is not initialized.");
			return null;
		}

		[Token(Token = "0x600235B")]
		[Address(RVA = "0x3DE043C", Offset = "0x3DE043C", Length = "0x150")]
		public Tournament GetTournamentById(int tournamentId)
		{
			TournamentManagerState tournamentManagerState = _tournamentManagerState;
			if (tournamentManagerState.IsInitialized)
			{
				Predicate<Tournament> match = delegate(Tournament t)
				{
					TournamentData tournamentData = t.TournamentData;
					int num = tournamentData.tournamentID - tournamentId;
					return num == 0;
				};
				return tournamentManagerState.Tournaments.Find(match);
			}
			ElephantLog.LogError("SocialTournament", "TournamentManager is not initialized.");
			return null;
		}

		[Token(Token = "0x600235C")]
		[Address(RVA = "0x3DE0594", Offset = "0x3DE0594", Length = "0x244")]
		public TournamentResult GetTournamentResultById(int tournamentId)
		{
			TournamentManagerState tournamentManagerState = _tournamentManagerState;
			if (tournamentManagerState.IsInitialized)
			{
				Func<TournamentResult, bool> predicate = delegate(TournamentResult t)
				{
					TournamentData tournamentData = t.TournamentData;
					int num = tournamentData.tournamentID - tournamentId;
					return num == 0;
				};
				IEnumerable<object> source = tournamentManagerState.TournamentResults.Where((Func<object, bool>)predicate);
				bool flag = _003C_003Ec._003C_003E9__7_1 == null;
				bool flag2 = !flag;
				Func<object, int> keySelector = (Func<object, int>)_003C_003Ec._003C_003E9__7_1;
				if (!flag2)
				{
					keySelector = (Func<object, int>)(_003C_003Ec._003C_003E9__7_1 = delegate(TournamentResult t)
					{
						TournamentData tournamentData = t.TournamentData;
						return tournamentData.scheduleID;
					});
				}
				IOrderedEnumerable<object> source2 = source.OrderByDescending(keySelector);
				return (TournamentResult)source2.FirstOrDefault();
			}
			ElephantLog.LogError("SocialTournament", "TournamentManager is not initialized.");
			return null;
		}

		[Token(Token = "0x600235D")]
		[Address(RVA = "0x3DE07E0", Offset = "0x3DE07E0", Length = "0x58")]
		public long GetServerTime()
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected I8, but got Unknown
			//IL_0060: Expected F4, but got I8
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			TournamentManagerState tournamentManagerState = _tournamentManagerState;
			float num = realtimeSinceStartup - _lastServerTimeUpdateTime;
			float num2 = ((num != 1f / 0f) ? num : (-9.223372E+18f));
			return (long)(num2 + tournamentManagerState.ServerTime);
		}

		[Token(Token = "0x600235E")]
		[Address(RVA = "0x3DE0838", Offset = "0x3DE0838", Length = "0x10C")]
		public void IsOnline(Action<bool> onResult)
		{
			Action onSuccess = delegate
			{
				if (onResult != null)
				{
					onResult(obj: true);
				}
			};
			Action onError = delegate
			{
				if (onResult != null)
				{
					onResult(obj: false);
				}
			};
			_tournamentOps.TournamentHealthCheck(onSuccess, onError);
		}

		[Token(Token = "0x600235F")]
		[Address(RVA = "0x3DE0234", Offset = "0x3DE0234", Length = "0xF0")]
		private unsafe void FetchTournamentData(bool isInitialFetch, Action onComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::FetchTournamentData");
		}

		[Token(Token = "0x6002360")]
		[Address(RVA = "0x3DE0BBC", Offset = "0x3DE0BBC", Length = "0x220")]
		private unsafe void ProcessJoinedTournaments(List<TournamentAndScheduleId> tournamentIds)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::ProcessJoinedTournaments");
		}

		[Token(Token = "0x6002361")]
		[Address(RVA = "0x3DE0DE4", Offset = "0x3DE0DE4", Length = "0x20C")]
		private unsafe void FetchBoardsForJoinedTournaments(List<Tournament> joinedTournaments, Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::FetchBoardsForJoinedTournaments");
		}

		[Token(Token = "0x6002362")]
		[Address(RVA = "0x3DE0FF8", Offset = "0x3DE0FF8", Length = "0x524")]
		private void SyncOfflineScores()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::SyncOfflineScores");
		}

		[IteratorStateMachine(typeof(_003CUpdateTournamentsRoutine_003Ed__21))]
		[Token(Token = "0x6002363")]
		[Address(RVA = "0x3DE1918", Offset = "0x3DE1918", Length = "0x78")]
		private IEnumerator UpdateTournamentsRoutine()
		{
			_003CUpdateTournamentsRoutine_003Ed__21 _003CUpdateTournamentsRoutine_003Ed__22 = (_003CUpdateTournamentsRoutine_003Ed__21)FormatterServices.GetUninitializedObject(typeof(_003CUpdateTournamentsRoutine_003Ed__21));
			_003CUpdateTournamentsRoutine_003Ed__22._003C_003E1__state = 0;
			_003CUpdateTournamentsRoutine_003Ed__22._003C_003E4__this = this;
			return _003CUpdateTournamentsRoutine_003Ed__22;
		}

		[Token(Token = "0x6002364")]
		[Address(RVA = "0x3DE19BC", Offset = "0x3DE19BC", Length = "0x5EC")]
		private unsafe bool CheckTournamentStates(List<Tournament> newTournaments, long time)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::CheckTournamentStates");
			return default;
		}

		[Token(Token = "0x6002365")]
		[Address(RVA = "0x3DE2030", Offset = "0x3DE2030", Length = "0x880")]
		private unsafe void UpdateTournamentState(List<Tournament> newTournaments, long time)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::UpdateTournamentState");
		}

		[Token(Token = "0x6002366")]
		[Address(RVA = "0x3DE1FB8", Offset = "0x3DE1FB8", Length = "0x78")]
		private bool AreTournamentDatasEqual(TournamentData a, TournamentData b)
		{
			if (a.tournamentID == b.tournamentID && a.scheduleID == b.scheduleID && a.startDateUnix == b.startDateUnix && a.endDateUnix == b.endDateUnix)
			{
				int num = a.tournamentState - b.tournamentState;
				return num == 0;
			}
			return false;
		}

		[Token(Token = "0x6002367")]
		[Address(RVA = "0x3DE28C0", Offset = "0x3DE28C0", Length = "0xEC")]
		private float GetUpdateInterval()
		{
			//IL_0084: Expected F4, but got I
			//IL_006e: Expected F4, but got I
			TournamentManagerState tournamentManagerState = _tournamentManagerState;
			Func<Tournament, bool> predicate = delegate(Tournament t)
			{
				TournamentData tournamentData = t.TournamentData;
				TournamentManagerState tournamentManagerState2 = _tournamentManagerState;
				long num3 = tournamentData.endDateUnix - tournamentManagerState2.ServerTime;
				if (num3 >= 1)
				{
					UpdateConfig config2 = _config;
					bool flag2 = config2.CheckInterval < (float)num3;
					bool flag3 = config2.CheckInterval == config2.CheckInterval;
					bool flag4 = num3 == num3;
					bool flag5 = flag3 && flag4;
					bool flag6 = !flag5;
					return flag2 == flag6;
				}
				return false;
			};
			bool flag = tournamentManagerState.Tournaments.Any((Func<object, bool>)predicate);
			UpdateConfig config = _config;
			if (flag)
			{
				int num = 20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v5 (ElephantSocial.Tournament.TournamentManagerService+UpdateConfig)+v109 @ X9_v5 (System.Int32)]");
				return 0f;
			}
			int num2 = 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v5 (ElephantSocial.Tournament.TournamentManagerService+UpdateConfig)+v110 @ X9_v4 (System.Int32)]");
			return 0f;
		}

		[Token(Token = "0x6002368")]
		[Address(RVA = "0x3DE29AC", Offset = "0x3DE29AC", Length = "0x90")]
		private unsafe void HandleTournamentClaimed(int tournamentId, int scheduleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerService::HandleTournamentClaimed");
		}

		[Token(Token = "0x6002369")]
		[Address(RVA = "0x3DE2BA8", Offset = "0x3DE2BA8", Length = "0x90")]
		private void HandleTournamentJoined()
		{
			Action<MyTournamentsResponse> onResponse = delegate(MyTournamentsResponse myTournamentsResponse)
			{
				List<TournamentAndScheduleId> myTournamentIds = myTournamentsResponse.myTournamentIds;
				if (myTournamentIds.Count >= 1)
				{
					ProcessJoinedTournaments(myTournamentIds);
					TournamentManagerState tournamentManagerState = _tournamentManagerState;
					Predicate<object> match;
					if (_003C_003Ec._003C_003E9__27_1 != null)
					{
						bool flag = tournamentManagerState.Tournaments == null;
						bool flag2 = !flag;
						match = (Predicate<object>)_003C_003Ec._003C_003E9__27_1;
						if (!flag2)
						{
							throw new NullReferenceException();
						}
					}
					else
					{
						match = (Predicate<object>)(_003C_003Ec._003C_003E9__27_1 = (Tournament t) => t.HasJoined);
					}
					Tournament tournament = tournamentManagerState.Tournaments.Find(match);
					if (tournament != null)
					{
						List<Tournament> list = new List<Tournament>();
						list.Add(tournament);
						((TournamentManagerService)(object)list).FetchBoardsForJoinedTournaments(list, (Action)null);
					}
				}
				if (OnTournamentsUpdated != null)
				{
					OnTournamentsUpdated();
				}
			};
			_tournamentRepository.GetMyTournaments(onResponse);
		}

		[Token(Token = "0x600236A")]
		[Address(RVA = "0x3DE03B8", Offset = "0x3DE03B8", Length = "0x84")]
		private bool EnsureInitialized()
		{
			TournamentManagerState tournamentManagerState = _tournamentManagerState;
			if (!tournamentManagerState.IsInitialized)
			{
				ElephantLog.LogError("SocialTournament", "TournamentManager is not initialized.");
			}
			return tournamentManagerState.IsInitialized;
		}
	}
}
