using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Leaderboard.Network;
using ElephantSocial.Model;
using ElephantUniTask.Threading.Tasks;
using UnityEngine;

namespace ElephantSocial.Leaderboard
{
	[Token(Token = "0x20008C8")]
	public class Leaderboard : GenericResponseOps
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20008C9")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001D85")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001D86")]
			public static Action<string> _003C_003E9__7_3;

			[Token(Token = "0x4001D87")]
			public static Func<BoardPlayer, int> _003C_003E9__15_0;

			[Token(Token = "0x4001D88")]
			public static Func<BoardPlayer, int> _003C_003E9__16_0;

			[Token(Token = "0x600253B")]
			[Address(RVA = "0x3E03DBC", Offset = "0x3E03DBC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600253C")]
			[Address(RVA = "0x3E03E20", Offset = "0x3E03E20", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CInit_003Eb__7_3(string cachingError)
			{
				string message = default(string);
				ElephantLog.LogError("LeaderboardCache", message);
			}

			internal int _003CSortLeaderboard_003Eb__15_0(BoardPlayer player)
			{
				return player.score;
			}

			internal int _003CUpdatePlayer_003Eb__16_0(BoardPlayer player)
			{
				return player.score;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20008CD")]
		private sealed class _003C_003Ec__DisplayClass19_0
		{
			[Token(Token = "0x4001D93")]
			[FieldOffset(Offset = "0x10")]
			public Action<Action<LeaderboardContainer>, Action<string>> requestLeaderboardAction;

			[Token(Token = "0x4001D94")]
			[FieldOffset(Offset = "0x18")]
			public Leaderboard _003C_003E4__this;

			[Token(Token = "0x4001D95")]
			[FieldOffset(Offset = "0x20")]
			public Action onInitialized;

			[Token(Token = "0x4001D96")]
			[FieldOffset(Offset = "0x28")]
			public Action<string> onError;

			[Token(Token = "0x600254B")]
			[Address(RVA = "0x3E041DC", Offset = "0x3E041DC", Length = "0x8")]
			public _003C_003Ec__DisplayClass19_0()
			{
			}

			internal void _003CInitLeaderboardCache_003Eb__0(Action<LeaderboardContainer> action, Action<string> error)
			{
				if (requestLeaderboardAction == null)
				{
					return;
				}
				Action<LeaderboardContainer> arg = delegate(LeaderboardContainer response)
				{
					if (action != null)
					{
						action(response);
					}
				};
				Action<string> arg2 = delegate(string x)
				{
					if (error != null)
					{
						error(x);
					}
				};
				requestLeaderboardAction(arg, arg2);
			}

			internal void _003CInitLeaderboardCache_003Eb__1(LeaderboardContainer x)
			{
				ElephantLog.Log("Leaderboard", "Global Leaderboard cached");
				LeaderboardRecords global = x.global;
				Leaderboard leaderboard = _003C_003E4__this;
				leaderboard.nextUnixSeconds = global.next;
				if (onInitialized != null)
				{
					onInitialized();
				}
			}

			internal void _003CInitLeaderboardCache_003Eb__2(string error)
			{
				ElephantLog.LogError("Leaderboard", error);
				if (onError != null)
				{
					onError(error);
				}
			}
		}

		[Token(Token = "0x4001D7F")]
		[FieldOffset(Offset = "0x10")]
		private readonly LeaderboardOps _leaderboardOps;

		[Token(Token = "0x4001D80")]
		[FieldOffset(Offset = "0x18")]
		private LeaderboardContainerCache _leaderboardContainerCache;

		[Token(Token = "0x4001D81")]
		[FieldOffset(Offset = "0x20")]
		private int leaderboardId;

		[Token(Token = "0x4001D82")]
		[FieldOffset(Offset = "0x28")]
		private BoardPlayer boardPlayer;

		[Token(Token = "0x4001D83")]
		[FieldOffset(Offset = "0x30")]
		private bool _isInitializeRequested;

		[Token(Token = "0x4001D84")]
		[FieldOffset(Offset = "0x38")]
		private long nextUnixSeconds;

		[Token(Token = "0x600252D")]
		[Address(RVA = "0x3DFF2E8", Offset = "0x3DFF2E8", Length = "0x84")]
		public Leaderboard(int leaderboardId)
		{
			LeaderboardOps leaderboardOps = new LeaderboardOps();
			_leaderboardOps = leaderboardOps;
			this.leaderboardId = leaderboardId;
		}

		[Token(Token = "0x600252E")]
		[Address(RVA = "0x3DFF36C", Offset = "0x3DFF36C", Length = "0x194")]
		public void Init(Action onResponse, Action<string> onError)
		{
			if (_isInitializeRequested)
			{
				ElephantLog.LogError("Leaderboard", "Multiple init requested");
				return;
			}
			Action action2 = default(Action);
			Action<BoardPlayer> onResponse2 = delegate
			{
				Leaderboard leaderboard = this;
				BoardPlayer boardPlayer = default(BoardPlayer);
				leaderboard.boardPlayer = boardPlayer;
				Action<Action<LeaderboardContainer>, Action<string>> requestLeaderboardAction = RequestLeaderboardContainer;
				Action action = action2;
				if (action2 == null)
				{
					action = (action2 = delegate
					{
						Leaderboard leaderboard2 = this;
						leaderboard2._isInitializeRequested = true;
						if (onResponse != null)
						{
							onResponse();
						}
					});
				}
				Action<string> onError3 = _003C_003Ec._003C_003E9__7_3;
				if (_003C_003Ec._003C_003E9__7_3 == null)
				{
					Action<string> action3 = (_003C_003Ec._003C_003E9__7_3 = delegate
					{
						string message = default(string);
						ElephantLog.LogError("LeaderboardCache", message);
					});
					bool flag = this == null;
					bool flag2 = !flag;
					action = action;
					onError3 = action3;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				InitLeaderboardCache(requestLeaderboardAction, action, onError3);
			};
			Action<string> onError2 = delegate(string error)
			{
				if (onError != null)
				{
					onError(error);
				}
			};
			InitPlayer(onResponse2, onError2);
		}

		[Token(Token = "0x600252F")]
		[Address(RVA = "0x3DFF67C", Offset = "0x3DFF67C", Length = "0x220")]
		public void SetScore(int score, Action<BoardPlayer> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Leaderboard::SetScore");
		}

		[Token(Token = "0x6002530")]
		[Address(RVA = "0x3DFF89C", Offset = "0x3DFF89C", Length = "0x200")]
		public void AddScore(int scoreToAdd, Action<BoardPlayer> onResponse, Action<string> onError)
		{
			BoardPlayer boardPlayer = this.boardPlayer;
			if (this.boardPlayer != null)
			{
				int score = boardPlayer.score + scoreToAdd;
				boardPlayer.score = score;
				Action<BoardPlayer> action = default(Action<BoardPlayer>);
				Action<GenericResponse<BoardPlayer>> onResponse2 = delegate(GenericResponse<BoardPlayer> response)
				{
					Action<BoardPlayer> onResponse3 = action;
					if (action == null)
					{
						onResponse3 = (action = delegate(BoardPlayer x)
						{
							if (onResponse != null)
							{
								Leaderboard leaderboard = this;
								BoardPlayer obj = leaderboard.boardPlayer.Clone();
								onResponse(obj);
							}
							Leaderboard leaderboard2 = this;
							BoardPlayer boardPlayer2 = leaderboard2.boardPlayer;
							boardPlayer2.score = x.score;
						});
					}
					GenericResponseOps.HandleResponse(response, onResponse3, onError);
				};
				IEnumerator routine = _leaderboardOps.UpdateScore(this.boardPlayer, leaderboardId, "incr", scoreToAdd, onResponse2, onError);
				Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
			}
			else
			{
				onError("Board player not initialized!");
				ElephantLog.LogError("Leaderboard", "Board player not initialized!");
			}
		}

		[Token(Token = "0x6002531")]
		[Address(RVA = "0x3DFFA9C", Offset = "0x3DFFA9C", Length = "0x1D8")]
		public void GetLeaderboard(Action<LeaderboardContainer> onResponse, Action<string> onError)
		{
			if (_leaderboardContainerCache != null)
			{
				Action<LeaderboardContainer> response = delegate(LeaderboardContainer leaderboardContainer)
				{
					LeaderboardRecords global = leaderboardContainer.global;
					Leaderboard leaderboard = this;
					leaderboard.nextUnixSeconds = global.next;
					leaderboard.SortLeaderboardContainer(leaderboardContainer, onResponse);
				};
				Action<string> onError2 = delegate(string x)
				{
					if (onError != null)
					{
						onError(x);
					}
				};
				_leaderboardContainerCache.GetData(response, onError2);
			}
			else
			{
				if (onError != null)
				{
					onError("Leaderboard caching system is not initialized.");
				}
				ElephantLog.LogError("Leaderboard", "Leaderboard caching system is not initialized.");
			}
		}

		[Token(Token = "0x6002532")]
		[Address(RVA = "0x3DFFC74", Offset = "0x3DFFC74", Length = "0x8")]
		public long GetNextUnixSeconds()
		{
			return nextUnixSeconds;
		}

		[Token(Token = "0x6002533")]
		[Address(RVA = "0x3DFFC7C", Offset = "0x3DFFC7C", Length = "0x100")]
		public BoardPlayer GetBoardPlayer()
		{
			if (_isInitializeRequested)
			{
				RenewPlayerData();
				BoardPlayer boardPlayer = this.boardPlayer;
				BoardPlayer boardPlayer2 = new BoardPlayer();
				boardPlayer2.FillBaseData(this.boardPlayer);
				boardPlayer2.score = boardPlayer.score;
				return boardPlayer2;
			}
			ElephantLog.LogError("Leaderboard", "Leaderboard not initialized!");
			return null;
		}

		[Token(Token = "0x6002534")]
		[Address(RVA = "0x3DFFD7C", Offset = "0x3DFFD7C", Length = "0xC4")]
		private void RenewPlayerData()
		{
			if (_isInitializeRequested)
			{
				Social instance = Social.Instance;
				Player player = instance.GetPlayer();
				boardPlayer.FillBaseData(player);
			}
			else
			{
				ElephantLog.LogError("Leaderboard", "Leaderboard not initialized!");
			}
		}

		[Token(Token = "0x6002535")]
		[Address(RVA = "0x3DFFE40", Offset = "0x3DFFE40", Length = "0x18C")]
		private void SortLeaderboardContainer(LeaderboardContainer leaderboardContainer, Action<LeaderboardContainer> onResponse)
		{
			if (boardPlayer != null)
			{
				RenewPlayerData();
				LeaderboardRecords global = leaderboardContainer.global;
				List<BoardPlayer> records = leaderboardContainer.global.GetRecords();
				List<BoardPlayer> records2 = ((Leaderboard)(object)records).UpdatePlayer(boardPlayer, records);
				global.records = records2;
				LeaderboardRecords global2 = leaderboardContainer.global;
				List<BoardPlayer> records3 = leaderboardContainer.global.GetRecords();
				List<BoardPlayer> records4 = SortLeaderboard(records3);
				global2.records = records4;
				LeaderboardRecords local = leaderboardContainer.local;
				List<BoardPlayer> records5 = leaderboardContainer.local.GetRecords();
				List<BoardPlayer> records6 = ((Leaderboard)(object)records5).UpdatePlayer(boardPlayer, records5);
				local.records = records6;
				LeaderboardRecords local2 = leaderboardContainer.local;
				List<BoardPlayer> records7 = leaderboardContainer.local.GetRecords();
				List<BoardPlayer> records8 = SortLeaderboard(records7);
				local2.records = records8;
				onResponse?.Invoke(leaderboardContainer);
			}
			else
			{
				ElephantLog.LogError("Leaderboard", "Board player is not initialized before sorting the leaderboard.");
			}
		}

		[Token(Token = "0x6002536")]
		[Address(RVA = "0x3E002AC", Offset = "0x3E002AC", Length = "0x13C")]
		private static List<BoardPlayer> SortLeaderboard(List<BoardPlayer> list)
		{
			if (list != null)
			{
				bool flag = _003C_003Ec._003C_003E9__15_0 == null;
				bool flag2 = !flag;
				Func<object, int> keySelector = (Func<object, int>)_003C_003Ec._003C_003E9__15_0;
				if (!flag2)
				{
					keySelector = (Func<object, int>)(_003C_003Ec._003C_003E9__15_0 = (BoardPlayer player) => player.score);
				}
				IOrderedEnumerable<object> source = list.OrderByDescending(keySelector);
				return (List<BoardPlayer>)(object)source.ToList();
			}
			return null;
		}

		[Token(Token = "0x6002537")]
		[Address(RVA = "0x3DFFFCC", Offset = "0x3DFFFCC", Length = "0x2E0")]
		private List<BoardPlayer> UpdatePlayer(BoardPlayer targetBoardPlayer, List<BoardPlayer> boardPlayerList)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Leaderboard::UpdatePlayer");
			return default;
		}

		[Token(Token = "0x6002538")]
		[Address(RVA = "0x3E003E8", Offset = "0x3E003E8", Length = "0x194")]
		private void RequestLeaderboardContainer(Action<LeaderboardContainer> onResponse, Action<string> onError)
		{
			Action<LeaderboardContainer> action2 = default(Action<LeaderboardContainer>);
			Action<string> action5 = default(Action<string>);
			Action<GenericResponse<LeaderboardContainer>> onResponse2 = delegate
			{
				//IL_0009: Expected O, but got I4
				object obj = 192471040;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E38D]");
				Action<LeaderboardContainer> action;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					action = action2;
					if (action2 != null)
					{
						goto IL_0061;
					}
				}
				else
				{
					_ = 1;
					action = action2;
					if (action2 != null)
					{
						goto IL_0061;
					}
				}
				Action<LeaderboardContainer> action3 = (action2 = delegate(LeaderboardContainer lbContainer)
				{
					if (onResponse != null)
					{
						onResponse(lbContainer);
					}
				});
				int num = 187473920 + 2440;
				Action<string> action4 = action5;
				bool flag = action5 == null;
				bool flag2 = !flag;
				action = action3;
				int num2 = num;
				Action<LeaderboardContainer> action6 = action3;
				if (flag2)
				{
					goto IL_00a5;
				}
				goto IL_0162;
				IL_00a5:
				Il2CppRuntime.Boundary("MANAGED", "Method not found @4983120 (ElephantSocial.GenericResponseOps::HandleResponse, and 1 more at this address)");
				return;
				IL_0162:
				Action<string> action7 = (action5 = delegate(string x)
				{
					if (onError != null)
					{
						onError(x);
					}
				});
				num = num2;
				action4 = action7;
				action = action6;
				goto IL_00a5;
				IL_0061:
				num = 187473920 + 2440;
				action4 = action5;
				bool flag3 = action5 == null;
				num2 = num;
				action6 = action;
				if (!flag3)
				{
					goto IL_00a5;
				}
				goto IL_0162;
			};
			Action<string> onError2 = delegate(string x)
			{
				if (onError != null)
				{
					onError(x);
				}
			};
			IEnumerator leaderboard = _leaderboardOps.GetLeaderboard(leaderboardId, onResponse2, onError2);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(leaderboard);
		}

		[Token(Token = "0x6002539")]
		[Address(RVA = "0x3DFF500", Offset = "0x3DFF500", Length = "0x17C")]
		private void InitPlayer(Action<BoardPlayer> onResponse, Action<string> onError)
		{
			Social instance = Social.Instance;
			Player player = instance.GetPlayer();
			Action<BoardPlayer> action = default(Action<BoardPlayer>);
			Action<GenericResponse<BoardPlayer>> onResponse2 = delegate(GenericResponse<BoardPlayer> response)
			{
				Action<BoardPlayer> onResponse3 = action;
				if (action == null)
				{
					onResponse3 = (action = delegate(BoardPlayer x)
					{
						if (onResponse != null)
						{
							BoardPlayer obj = x.Clone();
							onResponse(obj);
						}
					});
				}
				GenericResponseOps.HandleResponse(response, onResponse3, onError);
			};
			IEnumerator score = _leaderboardOps.GetScore(leaderboardId, onResponse2, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(score);
		}

		[Token(Token = "0x600253A")]
		[Address(RVA = "0x3E0057C", Offset = "0x3E0057C", Length = "0x3840")]
		private void InitLeaderboardCache(Action<Action<LeaderboardContainer>, Action<string>> requestLeaderboardAction, Action onInitialized, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Leaderboard::InitLeaderboardCache");
		}
	}
}
