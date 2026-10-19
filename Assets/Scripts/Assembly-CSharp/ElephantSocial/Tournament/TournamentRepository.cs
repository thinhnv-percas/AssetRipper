using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using ElephantSocial.Tournament.Model;
using ElephantSocial.Tournament.Network;
using UnityEngine;
using UnityEngine.Networking;

namespace ElephantSocial.Tournament
{
	[Token(Token = "0x200084C")]
	public class TournamentRepository
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200084D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001C02")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001C03")]
			public static Func<TournamentDataStore.OfflineScore, PlayerScore> _003C_003E9__10_0;

			[Token(Token = "0x60023AC")]
			[Address(RVA = "0x3DE59D4", Offset = "0x3DE59D4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60023AD")]
			[Address(RVA = "0x3DE5A38", Offset = "0x3DE5A38", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal PlayerScore _003CSyncOfflineScores_003Eb__10_0(TournamentDataStore.OfflineScore s)
			{
				return new PlayerScore
				{
					Score = s.Score,
					Date = s.Timestamp,
					Online = false
				};
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000855")]
		private sealed class _003C_003Ec__DisplayClass7_0
		{
			[Token(Token = "0x4001C0E")]
			[FieldOffset(Offset = "0x10")]
			public int tournamentId;

			[Token(Token = "0x4001C0F")]
			[FieldOffset(Offset = "0x14")]
			public int scheduleId;

			[Token(Token = "0x4001C10")]
			[FieldOffset(Offset = "0x18")]
			public int score;

			[Token(Token = "0x4001C11")]
			[FieldOffset(Offset = "0x20")]
			public Action<int> onSuccess;

			[Token(Token = "0x4001C12")]
			[FieldOffset(Offset = "0x28")]
			public Action<string> onError;

			[Token(Token = "0x60023C3")]
			[Address(RVA = "0x3DE51B8", Offset = "0x3DE51B8", Length = "0x8")]
			public _003C_003Ec__DisplayClass7_0()
			{
			}

			internal void _003CAddScore_003Eb__0(GenericResponse<TournamentAddScoreResponse> response)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentRepository._003C_003Ec__DisplayClass7_0::_003CAddScore_003Eb__0");
			}

			internal void _003CAddScore_003Eb__1(string error)
			{
				if (TournamentDataStore._instance != null)
				{
					TournamentDataStore value = TournamentDataStore._instance.Value;
					value.SaveOfflineScore(tournamentId, scheduleId, score);
					if (onSuccess != null)
					{
						onSuccess(score);
					}
					return;
				}
				throw new NullReferenceException();
			}

			internal void _003CAddScore_003Eb__2(UnityWebRequest failedRequest)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentRepository._003C_003Ec__DisplayClass7_0::_003CAddScore_003Eb__2");
			}
		}

		[Token(Token = "0x4001C01")]
		[FieldOffset(Offset = "0x10")]
		internal readonly TournamentOps _tournamentOps;

		[Token(Token = "0x60023A1")]
		[Address(RVA = "0x3DE0A50", Offset = "0x3DE0A50", Length = "0x16C")]
		public void GetTournaments(Action<TournamentsResponse> onResponse)
		{
			Action<GenericResponse<TournamentsResponse>> onResponse2 = delegate(GenericResponse<TournamentsResponse> response)
			{
				TournamentsResponse tournamentsResponse2;
				List<TournamentData> tournaments3;
				if (response != null && response.data != null)
				{
					if (TournamentDataStore._instance != null)
					{
						TournamentDataStore value = TournamentDataStore._instance.Value;
						TournamentDataStore.Save("TournamentResponseStoreKey", response.data);
						if (onResponse != null)
						{
							onResponse(response.data);
						}
						return;
					}
				}
				else if (TournamentDataStore._instance != null)
				{
					TournamentDataStore value2 = TournamentDataStore._instance.Value;
					TournamentsResponse tournamentsResponse = ((!TournamentDataStore.Load<TournamentsResponse>("TournamentResponseStoreKey", out var loadedData)) ? null : loadedData);
					if (onResponse == null)
					{
						return;
					}
					tournamentsResponse2 = new TournamentsResponse();
					List<TournamentData> tournaments2 = new List<TournamentData>();
					tournamentsResponse2.tournaments = tournaments2;
					if (tournamentsResponse != null)
					{
						tournaments3 = tournamentsResponse.tournaments;
						if (tournamentsResponse.tournaments != null)
						{
							goto IL_017e;
						}
					}
					List<TournamentData> list = new List<TournamentData>();
					tournaments3 = list;
					goto IL_017e;
				}
				throw new NullReferenceException();
				IL_017e:
				tournamentsResponse2.tournaments = tournaments3;
				DateTimeOffset utcNow = DateTimeOffset.UtcNow;
				DateTimeOffset dateTimeOffset = utcNow;
				long serverTime = dateTimeOffset.ToUnixTimeSeconds();
				tournamentsResponse2.serverTime = serverTime;
				onResponse(tournamentsResponse2);
			};
			Action<string> onError = delegate
			{
				if (TournamentDataStore._instance == null)
				{
					throw new NullReferenceException();
				}
				TournamentDataStore value = TournamentDataStore._instance.Value;
				TournamentsResponse tournamentsResponse = ((!TournamentDataStore.Load<TournamentsResponse>("TournamentResponseStoreKey", out var loadedData)) ? null : loadedData);
				if (onResponse == null)
				{
					return;
				}
				TournamentsResponse tournamentsResponse2 = new TournamentsResponse();
				List<TournamentData> tournaments2 = new List<TournamentData>();
				tournamentsResponse2.tournaments = tournaments2;
				List<TournamentData> tournaments3;
				if (tournamentsResponse != null)
				{
					tournaments3 = tournamentsResponse.tournaments;
					if (tournamentsResponse.tournaments != null)
					{
						goto IL_0127;
					}
				}
				List<TournamentData> list = new List<TournamentData>();
				tournaments3 = list;
				goto IL_0127;
				IL_0127:
				tournamentsResponse2.tournaments = tournaments3;
				DateTimeOffset utcNow = DateTimeOffset.UtcNow;
				DateTimeOffset dateTimeOffset = utcNow;
				long serverTime = dateTimeOffset.ToUnixTimeSeconds();
				tournamentsResponse2.serverTime = serverTime;
				onResponse(tournamentsResponse2);
			};
			IEnumerator tournaments = _tournamentOps.GetTournaments(onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(tournaments);
		}

		[Token(Token = "0x60023A2")]
		[Address(RVA = "0x3DE2C38", Offset = "0x3DE2C38", Length = "0x16C")]
		public void GetMyTournaments(Action<MyTournamentsResponse> onResponse)
		{
			Action<GenericResponse<MyTournamentsResponse>> onResponse2 = delegate(GenericResponse<MyTournamentsResponse> response)
			{
				MyTournamentsResponse myTournamentsResponse2;
				List<TournamentAndScheduleId> myTournamentIds2;
				if (response != null && response.data != null)
				{
					if (TournamentDataStore._instance != null)
					{
						TournamentDataStore value = TournamentDataStore._instance.Value;
						TournamentDataStore.Save("MyTournamentsResponseKey", response.data);
						if (onResponse != null)
						{
							onResponse(response.data);
						}
						return;
					}
				}
				else if (TournamentDataStore._instance != null)
				{
					TournamentDataStore value2 = TournamentDataStore._instance.Value;
					MyTournamentsResponse myTournamentsResponse = ((!TournamentDataStore.Load<MyTournamentsResponse>("MyTournamentsResponseKey", out var loadedData)) ? null : loadedData);
					if (onResponse == null)
					{
						return;
					}
					myTournamentsResponse2 = new MyTournamentsResponse();
					List<TournamentAndScheduleId> myTournamentIds = new List<TournamentAndScheduleId>();
					myTournamentsResponse2.myTournamentIds = myTournamentIds;
					if (myTournamentsResponse != null)
					{
						myTournamentIds2 = myTournamentsResponse.myTournamentIds;
						if (myTournamentsResponse.myTournamentIds != null)
						{
							goto IL_017e;
						}
					}
					List<TournamentAndScheduleId> list = new List<TournamentAndScheduleId>();
					myTournamentIds2 = list;
					goto IL_017e;
				}
				throw new NullReferenceException();
				IL_017e:
				myTournamentsResponse2.myTournamentIds = myTournamentIds2;
				onResponse(myTournamentsResponse2);
			};
			Action<string> onError = delegate
			{
				if (TournamentDataStore._instance == null)
				{
					throw new NullReferenceException();
				}
				TournamentDataStore value = TournamentDataStore._instance.Value;
				MyTournamentsResponse myTournamentsResponse = ((!TournamentDataStore.Load<MyTournamentsResponse>("MyTournamentsResponseKey", out var loadedData)) ? null : loadedData);
				if (onResponse == null)
				{
					return;
				}
				MyTournamentsResponse myTournamentsResponse2 = new MyTournamentsResponse();
				List<TournamentAndScheduleId> myTournamentIds = new List<TournamentAndScheduleId>();
				myTournamentsResponse2.myTournamentIds = myTournamentIds;
				List<TournamentAndScheduleId> myTournamentIds2;
				if (myTournamentsResponse != null)
				{
					myTournamentIds2 = myTournamentsResponse.myTournamentIds;
					if (myTournamentsResponse.myTournamentIds != null)
					{
						goto IL_0127;
					}
				}
				List<TournamentAndScheduleId> list = new List<TournamentAndScheduleId>();
				myTournamentIds2 = list;
				goto IL_0127;
				IL_0127:
				myTournamentsResponse2.myTournamentIds = myTournamentIds2;
				onResponse(myTournamentsResponse2);
			};
			IEnumerator myTournaments = _tournamentOps.GetMyTournaments(onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(myTournaments);
		}

		[Token(Token = "0x60023A3")]
		[Address(RVA = "0x3DDD99C", Offset = "0x3DDD99C", Length = "0x18C")]
		public void GetBoard(int tournamentId, int scheduleId, Action<TournamentBoardResponse> onResponse)
		{
			Action<GenericResponse<TournamentBoardResponse>> onResponse2 = delegate(GenericResponse<TournamentBoardResponse> response)
			{
				TournamentBoardResponse tournamentBoardResponse2;
				List<BoardPlayer> boardPlayers;
				if (response != null && response.data != null)
				{
					if (TournamentDataStore._instance != null)
					{
						TournamentDataStore value = TournamentDataStore._instance.Value;
						value.SetTournamentBoardResponse(tournamentId, scheduleId, response.data);
						if (onResponse != null)
						{
							onResponse(response.data);
						}
						return;
					}
				}
				else if (TournamentDataStore._instance != null)
				{
					TournamentDataStore value2 = TournamentDataStore._instance.Value;
					TournamentBoardResponse tournamentBoardResponse = value2.GetTournamentBoardResponse(tournamentId, scheduleId);
					if (onResponse == null)
					{
						return;
					}
					tournamentBoardResponse2 = new TournamentBoardResponse();
					if (tournamentBoardResponse != null)
					{
						boardPlayers = tournamentBoardResponse.boardPlayers;
						if (tournamentBoardResponse.boardPlayers != null)
						{
							goto IL_0152;
						}
					}
					List<BoardPlayer> list = new List<BoardPlayer>();
					boardPlayers = list;
					goto IL_0152;
				}
				throw new NullReferenceException();
				IL_0152:
				tournamentBoardResponse2.boardPlayers = boardPlayers;
				onResponse(tournamentBoardResponse2);
			};
			Action<string> onError = delegate
			{
				if (TournamentDataStore._instance == null)
				{
					throw new NullReferenceException();
				}
				TournamentDataStore value = TournamentDataStore._instance.Value;
				TournamentBoardResponse tournamentBoardResponse = value.GetTournamentBoardResponse(tournamentId, scheduleId);
				if (onResponse == null)
				{
					return;
				}
				TournamentBoardResponse tournamentBoardResponse2 = new TournamentBoardResponse();
				List<BoardPlayer> boardPlayers;
				if (tournamentBoardResponse != null)
				{
					boardPlayers = tournamentBoardResponse.boardPlayers;
					if (tournamentBoardResponse.boardPlayers != null)
					{
						goto IL_00fb;
					}
				}
				List<BoardPlayer> list = new List<BoardPlayer>();
				boardPlayers = list;
				goto IL_00fb;
				IL_00fb:
				tournamentBoardResponse2.boardPlayers = boardPlayers;
				onResponse(tournamentBoardResponse2);
			};
			IEnumerator board = _tournamentOps.GetBoard(tournamentId, scheduleId, onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(board);
		}

		[Token(Token = "0x60023A4")]
		[Address(RVA = "0x3DE2A3C", Offset = "0x3DE2A3C", Length = "0x16C")]
		public void GetMyTournamentResults(Action<MyTournamentResultsResponse> onResponse)
		{
			Action<GenericResponse<MyTournamentResultsResponse>> onResponse2 = delegate(GenericResponse<MyTournamentResultsResponse> response)
			{
				MyTournamentResultsResponse myTournamentResultsResponse2;
				List<TournamentData> myTournamentResults3;
				if (response != null && response.data != null)
				{
					if (TournamentDataStore._instance != null)
					{
						TournamentDataStore value = TournamentDataStore._instance.Value;
						TournamentDataStore.Save("MyTournamentResultsResponseKey", response.data);
						if (onResponse != null)
						{
							onResponse(response.data);
						}
						return;
					}
				}
				else if (TournamentDataStore._instance != null)
				{
					TournamentDataStore value2 = TournamentDataStore._instance.Value;
					MyTournamentResultsResponse myTournamentResultsResponse = ((!TournamentDataStore.Load<MyTournamentResultsResponse>("MyTournamentResultsResponseKey", out var loadedData)) ? null : loadedData);
					if (onResponse == null)
					{
						return;
					}
					myTournamentResultsResponse2 = new MyTournamentResultsResponse();
					List<TournamentData> myTournamentResults2 = new List<TournamentData>();
					myTournamentResultsResponse2.myTournamentResults = myTournamentResults2;
					if (myTournamentResultsResponse != null)
					{
						myTournamentResults3 = myTournamentResultsResponse.myTournamentResults;
						if (myTournamentResultsResponse.myTournamentResults != null)
						{
							goto IL_017e;
						}
					}
					List<TournamentData> list = new List<TournamentData>();
					myTournamentResults3 = list;
					goto IL_017e;
				}
				throw new NullReferenceException();
				IL_017e:
				myTournamentResultsResponse2.myTournamentResults = myTournamentResults3;
				onResponse(myTournamentResultsResponse2);
			};
			Action<string> onError = delegate
			{
				if (TournamentDataStore._instance == null)
				{
					throw new NullReferenceException();
				}
				TournamentDataStore value = TournamentDataStore._instance.Value;
				MyTournamentResultsResponse myTournamentResultsResponse = ((!TournamentDataStore.Load<MyTournamentResultsResponse>("MyTournamentResultsResponseKey", out var loadedData)) ? null : loadedData);
				if (onResponse == null)
				{
					return;
				}
				MyTournamentResultsResponse myTournamentResultsResponse2 = new MyTournamentResultsResponse();
				List<TournamentData> myTournamentResults2 = new List<TournamentData>();
				myTournamentResultsResponse2.myTournamentResults = myTournamentResults2;
				List<TournamentData> myTournamentResults3;
				if (myTournamentResultsResponse != null)
				{
					myTournamentResults3 = myTournamentResultsResponse.myTournamentResults;
					if (myTournamentResultsResponse.myTournamentResults != null)
					{
						goto IL_0127;
					}
				}
				List<TournamentData> list = new List<TournamentData>();
				myTournamentResults3 = list;
				goto IL_0127;
				IL_0127:
				myTournamentResultsResponse2.myTournamentResults = myTournamentResults3;
				onResponse(myTournamentResultsResponse2);
			};
			IEnumerator myTournamentResults = _tournamentOps.GetMyTournamentResults(onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(myTournamentResults);
		}

		[Token(Token = "0x60023A5")]
		[Address(RVA = "0x3DDCD60", Offset = "0x3DDCD60", Length = "0x14C")]
		public void JoinTournament(int tournamentId, int scheduleId, int segmentId, Action<TournamentJoinResponse> onResponse, Action<string> onError)
		{
			Action<GenericResponse<TournamentJoinResponse>> onResponse2 = delegate(GenericResponse<TournamentJoinResponse> response)
			{
				if (onResponse != null)
				{
					onResponse(response.data);
				}
			};
			IEnumerator routine = _tournamentOps.JoinTournament(tournamentId, scheduleId, segmentId, onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
		}

		[Token(Token = "0x60023A6")]
		[Address(RVA = "0x3DE4EEC", Offset = "0x3DE4EEC", Length = "0x13C")]
		public void ClaimTournament(int tournamentId, int scheduleId, Action onResponse, Action<string> onError)
		{
			Action<GenericResponse<TournamentFinishResponse>> onResponse2 = delegate
			{
				if (onResponse != null)
				{
					onResponse();
				}
			};
			IEnumerator routine = _tournamentOps.ClaimTournament(tournamentId, scheduleId, onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
		}

		[Token(Token = "0x60023A7")]
		[Address(RVA = "0x3DDD22C", Offset = "0x3DDD22C", Length = "0x238")]
		public void AddScore(int tournamentId, int scheduleId, int score, Action<int> onSuccess, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentRepository::AddScore");
		}

		[Token(Token = "0x60023A8")]
		[Address(RVA = "0x3DDD5E8", Offset = "0x3DDD5E8", Length = "0x14C")]
		public void AddMatch(int tournamentId, int scheduleId, List<ScoreUpdate> updates, Action onSuccess, Action<string> onError)
		{
			Action<GenericResponse<object>> onResponse = delegate
			{
				if (onSuccess != null)
				{
					onSuccess();
				}
			};
			IEnumerator routine = _tournamentOps.AddMatch(tournamentId, scheduleId, updates, onResponse, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
		}

		[Token(Token = "0x60023A9")]
		[Address(RVA = "0x3DDD764", Offset = "0x3DDD764", Length = "0x144")]
		public void ListMatches(int tournamentId, int scheduleId, Action<List<TournamentMatchItem>> onResponse, Action<string> onError)
		{
			Action<GenericResponse<List<TournamentMatchItem>>> onResponse2 = delegate(GenericResponse<List<TournamentMatchItem>> response)
			{
				if (response != null && response.data != null)
				{
					if (onResponse != null)
					{
						onResponse(response.data);
					}
				}
				else if (onResponse != null)
				{
					List<TournamentMatchItem> obj = new List<TournamentMatchItem>();
					onResponse(obj);
				}
			};
			IEnumerator routine = _tournamentOps.ListMatches(tournamentId, scheduleId, onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
		}

		[Token(Token = "0x60023AA")]
		[Address(RVA = "0x3DE1524", Offset = "0x3DE1524", Length = "0x3F4")]
		public void SyncOfflineScores(int tournamentId, int scheduleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentRepository::SyncOfflineScores");
		}

		[Token(Token = "0x60023AB")]
		[Address(RVA = "0x3DDCAE8", Offset = "0x3DDCAE8", Length = "0x78")]
		public TournamentRepository()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentRepository::.ctor");
		}
	}
}
