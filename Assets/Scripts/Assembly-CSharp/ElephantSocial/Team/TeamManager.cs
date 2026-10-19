using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSocial.Team.Model.Enum;
using ElephantSocial.Team.Model.Response;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Team
{
	[Token(Token = "0x2000888")]
	public static class TeamManager
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200088A")]
		private struct _003CCreateTeam_003Ed__12 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CA3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CA4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<Team> _003C_003Et__builder;

			[Token(Token = "0x4001CA5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string name;

			[Token(Token = "0x4001CA6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public int requiredLevel;

			[Token(Token = "0x4001CA7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public TeamType type;

			[Token(Token = "0x4001CA8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public int badge;

			[Token(Token = "0x4001CA9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public string description;

			[Token(Token = "0x4001CAA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002499")]
			[Address(RVA = "0x3DF1D44", Offset = "0x3DF1D44", Length = "0x5C0")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CCreateTeam_003Ed__12::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600249A")]
			[Address(RVA = "0x3DF263C", Offset = "0x3DF263C", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CCreateTeam_003Ed__12::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200088B")]
		private struct _003CGetMyJoinRequests_003Ed__15 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CAB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CAC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<string>> _003C_003Et__builder;

			[Token(Token = "0x4001CAD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<List<string>>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600249B")]
			[Address(RVA = "0x3DF2698", Offset = "0x3DF2698", Length = "0x5C4")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CGetMyJoinRequests_003Ed__15::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600249C")]
			[Address(RVA = "0x3DF2D28", Offset = "0x3DF2D28", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CGetMyJoinRequests_003Ed__15::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200088C")]
		private struct _003CGetMyTeamId_003Ed__14 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CAE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CAF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<string> _003C_003Et__builder;

			[Token(Token = "0x4001CB0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<string>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600249D")]
			[Address(RVA = "0x3DF2D84", Offset = "0x3DF2D84", Length = "0x5C0")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CGetMyTeamId_003Ed__14::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600249E")]
			[Address(RVA = "0x3DF3410", Offset = "0x3DF3410", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CGetMyTeamId_003Ed__14::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200088D")]
		private struct _003CGetTeam_003Ed__13 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CB1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CB2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<Team> _003C_003Et__builder;

			[Token(Token = "0x4001CB3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string teamId;

			[Token(Token = "0x4001CB4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600249F")]
			[Address(RVA = "0x3DF346C", Offset = "0x3DF346C", Length = "0x5C8")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CGetTeam_003Ed__13::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024A0")]
			[Address(RVA = "0x3DF3B18", Offset = "0x3DF3B18", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CGetTeam_003Ed__13::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200088E")]
		private struct _003CIsUserOnline_003Ed__16 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CB5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CB6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001CB7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<bool>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024A1")]
			[Address(RVA = "0x3DF3B74", Offset = "0x3DF3B74", Length = "0x558")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CIsUserOnline_003Ed__16::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024A2")]
			[Address(RVA = "0x3DF418C", Offset = "0x3DF418C", Length = "0x5C")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				IAsyncStateMachine stateMachine2 = default(IAsyncStateMachine);
				_003C_003Et__builder.SetStateMachine(stateMachine2);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200088F")]
		private struct _003CSearch_003Ed__11 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CB8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CB9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<Team>> _003C_003Et__builder;

			[Token(Token = "0x4001CBA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string term;

			[Token(Token = "0x4001CBB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<List<TeamResponse>>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024A3")]
			[Address(RVA = "0x3DF41E8", Offset = "0x3DF41E8", Length = "0x838")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CSearch_003Ed__11::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024A4")]
			[Address(RVA = "0x3DF4B04", Offset = "0x3DF4B04", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CSearch_003Ed__11::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000890")]
		private struct _003CSuggestedTeams_003Ed__10 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CBC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CBD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<Team>> _003C_003Et__builder;

			[Token(Token = "0x4001CBE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<List<TeamResponse>>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024A5")]
			[Address(RVA = "0x3DF4B60", Offset = "0x3DF4B60", Length = "0x84C")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CSuggestedTeams_003Ed__10::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024A6")]
			[Address(RVA = "0x3DF53AC", Offset = "0x3DF53AC", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamManager._003CSuggestedTeams_003Ed__10::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x4001C9F")]
		private static Action OnTeamJoined;

		[CompilerGenerated]
		[Token(Token = "0x4001CA0")]
		private static Action OnTeamLeft;

		[CompilerGenerated]
		[Token(Token = "0x4001CA1")]
		private static Action OnTeamCreated;

		[CompilerGenerated]
		[Token(Token = "0x6002486")]
		[Address(RVA = "0x3DF0A5C", Offset = "0x3DF0A5C", Length = "0xEC")]
		public static void add_OnTeamJoined(Action value)
		{
			Action action = OnTeamJoined;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnTeamJoined, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6002487")]
		[Address(RVA = "0x3DF0B48", Offset = "0x3DF0B48", Length = "0xEC")]
		public static void remove_OnTeamJoined(Action value)
		{
			Action action = OnTeamJoined;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnTeamJoined, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6002488")]
		[Address(RVA = "0x3DF0C34", Offset = "0x3DF0C34", Length = "0xF0")]
		public static void add_OnTeamLeft(Action value)
		{
			Action action = OnTeamLeft;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnTeamLeft, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6002489")]
		[Address(RVA = "0x3DF0D24", Offset = "0x3DF0D24", Length = "0xF0")]
		public static void remove_OnTeamLeft(Action value)
		{
			Action action = OnTeamLeft;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnTeamLeft, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600248A")]
		[Address(RVA = "0x3DF0E14", Offset = "0x3DF0E14", Length = "0xF0")]
		public static void add_OnTeamCreated(Action value)
		{
			Action action = OnTeamCreated;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnTeamCreated, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600248B")]
		[Address(RVA = "0x3DF0F04", Offset = "0x3DF0F04", Length = "0xF0")]
		public static void remove_OnTeamCreated(Action value)
		{
			Action action = OnTeamCreated;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnTeamCreated, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x600248C")]
		[Address(RVA = "0x3DF0FF4", Offset = "0x3DF0FF4", Length = "0x2DC")]
		static TeamManager()
		{
			Action b = delegate
			{
				if (OnTeamJoined != null)
				{
					OnTeamJoined();
				}
			};
			Delegate obj = TeamService.OnTeamJoined;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, b);
				if ((object)obj2 == null || (object)obj2.GetType() == typeof(Action))
				{
					Delegate obj3 = Interlocked.CompareExchange(ref TeamService.OnTeamJoined, (Action)obj2, (Action)obj);
					bool flag = (object)obj3 == obj;
					obj = obj3;
					if (!flag)
					{
						continue;
					}
					Action b2 = delegate
					{
						if (OnTeamLeft != null)
						{
							OnTeamLeft();
						}
					};
					Delegate obj4 = TeamService.OnTeamLeft;
					while (true)
					{
						Delegate obj5 = Delegate.Combine(obj4, b2);
						if ((object)obj5 != null && (object)obj5.GetType() != typeof(Action))
						{
							break;
						}
						Delegate obj6 = Interlocked.CompareExchange(ref TeamService.OnTeamLeft, (Action)obj5, (Action)obj4);
						bool flag2 = (object)obj6 == obj4;
						obj4 = obj6;
						if (!flag2)
						{
							continue;
						}
						Action b3 = delegate
						{
							if (OnTeamCreated != null)
							{
								OnTeamCreated();
							}
						};
						Delegate obj7 = TeamService.OnTeamCreated;
						while (true)
						{
							Delegate obj8 = Delegate.Combine(obj7, b3);
							if ((object)obj8 == null || (object)obj8.GetType() == typeof(Action))
							{
								Delegate obj9 = Interlocked.CompareExchange(ref TeamService.OnTeamCreated, (Action)obj8, (Action)obj7);
								bool flag3 = (object)obj9 == obj7;
								obj7 = obj9;
								if (!flag3)
								{
									continue;
								}
								return;
							}
							break;
						}
						break;
					}
				}
				throw new InvalidCastException();
			}
		}

		[AsyncStateMachine(typeof(_003CSuggestedTeams_003Ed__10))]
		[Token(Token = "0x600248D")]
		[Address(RVA = "0x3DF1518", Offset = "0x3DF1518", Length = "0xCC")]
		public static UniTask<List<Team>> SuggestedTeams()
		{
			_003CSuggestedTeams_003Ed__10 _003CSuggestedTeams_003Ed__11 = default(_003CSuggestedTeams_003Ed__10);
			_003CSuggestedTeams_003Ed__11._003C_003E1__state = -1;
			_003CSuggestedTeams_003Ed__11.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<Team>> result = default(UniTask<List<Team>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CSearch_003Ed__11))]
		[Token(Token = "0x600248E")]
		[Address(RVA = "0x3DF15E4", Offset = "0x3DF15E4", Length = "0xE4")]
		public static UniTask<List<Team>> Search(string term)
		{
			_003CSearch_003Ed__11 _003CSearch_003Ed__12 = default(_003CSearch_003Ed__11);
			_003CSearch_003Ed__12.term = term;
			_003CSearch_003Ed__12._003C_003E1__state = -1;
			_003CSearch_003Ed__12.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<Team>> result = default(UniTask<List<Team>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CCreateTeam_003Ed__12))]
		[Token(Token = "0x600248F")]
		[Address(RVA = "0x3DF16C8", Offset = "0x3DF16C8", Length = "0x124")]
		public static UniTask<Team> CreateTeam(string name, int badge, string description, TeamType type, int requiredLevel)
		{
			_003CCreateTeam_003Ed__12 _003CCreateTeam_003Ed__13 = default(_003CCreateTeam_003Ed__12);
			_003CCreateTeam_003Ed__13.name = name;
			_003CCreateTeam_003Ed__13.badge = badge;
			_003CCreateTeam_003Ed__13.description = description;
			_003CCreateTeam_003Ed__13.requiredLevel = requiredLevel;
			_003CCreateTeam_003Ed__13.type = type;
			_003CCreateTeam_003Ed__13._003C_003E1__state = -1;
			_003CCreateTeam_003Ed__13.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<Team> result = default(UniTask<Team>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetTeam_003Ed__13))]
		[Token(Token = "0x6002490")]
		[Address(RVA = "0x3DF17EC", Offset = "0x3DF17EC", Length = "0xE4")]
		public static UniTask<Team> GetTeam(string teamId)
		{
			_003CGetTeam_003Ed__13 _003CGetTeam_003Ed__14 = default(_003CGetTeam_003Ed__13);
			_003CGetTeam_003Ed__14.teamId = teamId;
			_003CGetTeam_003Ed__14._003C_003E1__state = -1;
			_003CGetTeam_003Ed__14.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<Team> result = default(UniTask<Team>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetMyTeamId_003Ed__14))]
		[Token(Token = "0x6002491")]
		[Address(RVA = "0x3DF18D0", Offset = "0x3DF18D0", Length = "0xCC")]
		public static UniTask<string> GetMyTeamId()
		{
			_003CGetMyTeamId_003Ed__14 _003CGetMyTeamId_003Ed__15 = default(_003CGetMyTeamId_003Ed__14);
			_003CGetMyTeamId_003Ed__15._003C_003E1__state = -1;
			_003CGetMyTeamId_003Ed__15.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<string> result = default(UniTask<string>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetMyJoinRequests_003Ed__15))]
		[Token(Token = "0x6002492")]
		[Address(RVA = "0x3DF199C", Offset = "0x3DF199C", Length = "0xCC")]
		public static UniTask<List<string>> GetMyJoinRequests()
		{
			_003CGetMyJoinRequests_003Ed__15 _003CGetMyJoinRequests_003Ed__16 = default(_003CGetMyJoinRequests_003Ed__15);
			_003CGetMyJoinRequests_003Ed__16._003C_003E1__state = -1;
			_003CGetMyJoinRequests_003Ed__16.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<string>> result = default(UniTask<List<string>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CIsUserOnline_003Ed__16))]
		[Token(Token = "0x6002493")]
		[Address(RVA = "0x3DF1A68", Offset = "0x3DF1A68", Length = "0xC0")]
		public static UniTask<bool> IsUserOnline()
		{
			_003CIsUserOnline_003Ed__16 _003CIsUserOnline_003Ed__17 = default(_003CIsUserOnline_003Ed__16);
			_003CIsUserOnline_003Ed__17._003C_003E1__state = -1;
			_003CIsUserOnline_003Ed__17.MoveNext();
			return _003CIsUserOnline_003Ed__17._003C_003Et__builder.Task;
		}
	}
}
