using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using ElephantSocial.Model;
using ElephantSocial.Team.Model;
using ElephantSocial.Team.Model.Enum;
using ElephantSocial.Team.Model.Response;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Team
{
	[Token(Token = "0x200087D")]
	public class Team
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200087E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001C74")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001C75")]
			public static Predicate<TeamMember> _003C_003E9__15_0;

			[Token(Token = "0x4001C76")]
			public static Predicate<TeamMember> _003C_003E9__17_0;

			[Token(Token = "0x600245F")]
			[Address(RVA = "0x3DEA198", Offset = "0x3DEA198", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6002460")]
			[Address(RVA = "0x3DEA1FC", Offset = "0x3DEA1FC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGetTeamMembers_003Eb__15_0(TeamMember member)
			{
				int num = (int)(member.role - 1);
				bool flag = (uint)num < 3u;
				bool flag2 = !flag;
				return !flag2;
			}

			internal bool _003CIsMember_003Eb__17_0(TeamMember m)
			{
				Social instance = Social.Instance;
				Player player = instance.GetPlayer();
				bool flag = m.id == player.socialId;
				if (flag)
				{
					int num = (int)(m.role - 1);
					bool flag2 = (uint)num < 3u;
					bool flag3 = !flag2;
					bool flag4 = !flag3;
					flag = flag4;
				}
				return flag;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200087F")]
		private struct _003CAcceptJoinRequestAsync_003Ed__22 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C77")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C78")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001C79")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string requestingSocialId;

			[Token(Token = "0x4001C7A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002463")]
			[Address(RVA = "0x3DEA2C4", Offset = "0x3DEA2C4", Length = "0x524")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CAcceptJoinRequestAsync_003Ed__22::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002464")]
			[Address(RVA = "0x3DEA894", Offset = "0x3DEA894", Length = "0x5C")]
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
		[Token(Token = "0x2000880")]
		private struct _003CGetJoinRequestsAsync_003Ed__21 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C7B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C7C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<TeamMember>> _003C_003Et__builder;

			[Token(Token = "0x4001C7D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<List<TeamMember>>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002465")]
			[Address(RVA = "0x3DEA8F0", Offset = "0x3DEA8F0", Length = "0x5C4")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CGetJoinRequestsAsync_003Ed__21::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002466")]
			[Address(RVA = "0x3DEAF80", Offset = "0x3DEAF80", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CGetJoinRequestsAsync_003Ed__21::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000881")]
		private struct _003CIncrementStatAsync_003Ed__24 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C7E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C7F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001C80")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public int incrementValue;

			[Token(Token = "0x4001C81")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public string statId;

			[Token(Token = "0x4001C82")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002467")]
			[Address(RVA = "0x3DEAFDC", Offset = "0x3DEAFDC", Length = "0x528")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CIncrementStatAsync_003Ed__24::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002468")]
			[Address(RVA = "0x3DEB5BC", Offset = "0x3DEB5BC", Length = "0x5C")]
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
		[Token(Token = "0x2000882")]
		private struct _003CJoinAsync_003Ed__16 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C83")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C84")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001C85")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public Team _003C_003E4__this;

			[Token(Token = "0x4001C86")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002469")]
			[Address(RVA = "0x3DEB618", Offset = "0x3DEB618", Length = "0x5B0")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CJoinAsync_003Ed__16::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600246A")]
			[Address(RVA = "0x3DEBE3C", Offset = "0x3DEBE3C", Length = "0x5C")]
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
		[Token(Token = "0x2000883")]
		private struct _003CKickMemberAsync_003Ed__20 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C87")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C88")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001C89")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamMember member;

			[Token(Token = "0x4001C8A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public Team _003C_003E4__this;

			[Token(Token = "0x4001C8B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600246B")]
			[Address(RVA = "0x3DEBE98", Offset = "0x3DEBE98", Length = "0x5B4")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CKickMemberAsync_003Ed__20::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600246C")]
			[Address(RVA = "0x3DEC530", Offset = "0x3DEC530", Length = "0x5C")]
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
		[Token(Token = "0x2000884")]
		private struct _003CLeaveAsync_003Ed__18 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C8C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C8D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001C8E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600246D")]
			[Address(RVA = "0x3DEC58C", Offset = "0x3DEC58C", Length = "0x584")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CLeaveAsync_003Ed__18::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600246E")]
			[Address(RVA = "0x3DECBDC", Offset = "0x3DECBDC", Length = "0x5C")]
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
		[Token(Token = "0x2000885")]
		private struct _003CRejectJoinRequestAsync_003Ed__23 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C8F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C90")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001C91")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string requestingSocialId;

			[Token(Token = "0x4001C92")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600246F")]
			[Address(RVA = "0x3DECC38", Offset = "0x3DECC38", Length = "0x524")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CRejectJoinRequestAsync_003Ed__23::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002470")]
			[Address(RVA = "0x3DED208", Offset = "0x3DED208", Length = "0x5C")]
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
		[Token(Token = "0x2000886")]
		private struct _003CUpdateTeamInfoAsync_003Ed__19 : IAsyncStateMachine
		{
			[Token(Token = "0x4001C93")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001C94")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001C95")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string name;

			[Token(Token = "0x4001C96")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public int capacity;

			[Token(Token = "0x4001C97")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public int requiredLevel;

			[Token(Token = "0x4001C98")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public TeamType teamType;

			[Token(Token = "0x4001C99")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public string description;

			[Token(Token = "0x4001C9A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public int badgeId;

			[Token(Token = "0x4001C9B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			public Team _003C_003E4__this;

			[Token(Token = "0x4001C9C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002471")]
			[Address(RVA = "0x3DED264", Offset = "0x3DED264", Length = "0x5B0")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Team._003CUpdateTeamInfoAsync_003Ed__19::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002472")]
			[Address(RVA = "0x3DED93C", Offset = "0x3DED93C", Length = "0x5C")]
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

		[Token(Token = "0x4001C65")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x4001C66")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public string name;

		[Token(Token = "0x4001C67")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public int stars;

		[Token(Token = "0x4001C68")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public int capacity;

		[Token(Token = "0x4001C69")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public int size;

		[Token(Token = "0x4001C6A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public string description;

		[Token(Token = "0x4001C6B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		public int teamScore;

		[Token(Token = "0x4001C6C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3C")]
		public int requiredLevel;

		[Token(Token = "0x4001C6D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public int weeklyHelps;

		[Token(Token = "0x4001C6E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
		public TeamType type;

		[Token(Token = "0x4001C6F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		public int badgeId;

		[Token(Token = "0x4001C70")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		public List<TeamMember> members;

		[Token(Token = "0x4001C71")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		public int count;

		[Token(Token = "0x4001C72")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		public string country;

		[Token(Token = "0x4001C73")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		public TeamStat TeamStat;

		[Token(Token = "0x6002454")]
		[Address(RVA = "0x3DE9814", Offset = "0x3DE9814", Length = "0x128")]
		public List<TeamMember> GetTeamMembers()
		{
			List<TeamMember> list = members;
			Predicate<object> match;
			if (_003C_003Ec._003C_003E9__15_0 != null)
			{
				match = (Predicate<object>)_003C_003Ec._003C_003E9__15_0;
			}
			else
			{
				Predicate<TeamMember> predicate = (_003C_003Ec._003C_003E9__15_0 = delegate(TeamMember member)
				{
					int num = (int)(member.role - 1);
					bool flag3 = (uint)num < 3u;
					bool flag4 = !flag3;
					return !flag4;
				});
				bool flag = members == null;
				bool flag2 = !flag;
				match = (Predicate<object>)predicate;
				list = list;
				if (!flag2)
				{
					return (List<TeamMember>)(object)new NullReferenceException();
				}
			}
			return list.FindAll(match);
		}

		[AsyncStateMachine(typeof(_003CJoinAsync_003Ed__16))]
		[Token(Token = "0x6002455")]
		[Address(RVA = "0x3DE993C", Offset = "0x3DE993C", Length = "0xD4")]
		public UniTask<bool> JoinAsync()
		{
			_003CJoinAsync_003Ed__16 _003CJoinAsync_003Ed__17 = default(_003CJoinAsync_003Ed__16);
			_003CJoinAsync_003Ed__17._003C_003E4__this = this;
			_003CJoinAsync_003Ed__17._003C_003E1__state = -1;
			_003CJoinAsync_003Ed__17.MoveNext();
			return _003CJoinAsync_003Ed__17._003C_003Et__builder.Task;
		}

		[Token(Token = "0x6002456")]
		[Address(RVA = "0x3DE9A10", Offset = "0x3DE9A10", Length = "0x128")]
		public bool IsMember()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Team::IsMember");
			return default;
		}

		[AsyncStateMachine(typeof(_003CLeaveAsync_003Ed__18))]
		[Token(Token = "0x6002457")]
		[Address(RVA = "0x3DE9B38", Offset = "0x3DE9B38", Length = "0xC4")]
		public UniTask<bool> LeaveAsync()
		{
			_003CLeaveAsync_003Ed__18 _003CLeaveAsync_003Ed__19 = default(_003CLeaveAsync_003Ed__18);
			_003CLeaveAsync_003Ed__19._003C_003E1__state = -1;
			_003CLeaveAsync_003Ed__19.MoveNext();
			return _003CLeaveAsync_003Ed__19._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CUpdateTeamInfoAsync_003Ed__19))]
		[Token(Token = "0x6002458")]
		[Address(RVA = "0x3DE9BFC", Offset = "0x3DE9BFC", Length = "0x138")]
		public UniTask<bool> UpdateTeamInfoAsync(string name, int capacity, int requiredLevel, TeamType teamType, string description, int badgeId)
		{
			_003CUpdateTeamInfoAsync_003Ed__19 _003CUpdateTeamInfoAsync_003Ed__20 = default(_003CUpdateTeamInfoAsync_003Ed__19);
			_003CUpdateTeamInfoAsync_003Ed__20._003C_003E4__this = this;
			_003CUpdateTeamInfoAsync_003Ed__20.name = name;
			_003CUpdateTeamInfoAsync_003Ed__20.capacity = capacity;
			_003CUpdateTeamInfoAsync_003Ed__20.requiredLevel = requiredLevel;
			_003CUpdateTeamInfoAsync_003Ed__20.teamType = teamType;
			_003CUpdateTeamInfoAsync_003Ed__20.description = description;
			_003CUpdateTeamInfoAsync_003Ed__20.badgeId = badgeId;
			_003CUpdateTeamInfoAsync_003Ed__20._003C_003E1__state = -1;
			_003CUpdateTeamInfoAsync_003Ed__20.MoveNext();
			return _003CUpdateTeamInfoAsync_003Ed__20._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CKickMemberAsync_003Ed__20))]
		[Token(Token = "0x6002459")]
		[Address(RVA = "0x3DE9D34", Offset = "0x3DE9D34", Length = "0xF4")]
		public UniTask<bool> KickMemberAsync(TeamMember member)
		{
			_003CKickMemberAsync_003Ed__20 _003CKickMemberAsync_003Ed__21 = default(_003CKickMemberAsync_003Ed__20);
			_003CKickMemberAsync_003Ed__21._003C_003E4__this = this;
			_003CKickMemberAsync_003Ed__21.member = member;
			_003CKickMemberAsync_003Ed__21._003C_003E1__state = -1;
			_003CKickMemberAsync_003Ed__21.MoveNext();
			return _003CKickMemberAsync_003Ed__21._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CGetJoinRequestsAsync_003Ed__21))]
		[Token(Token = "0x600245A")]
		[Address(RVA = "0x3DE9E28", Offset = "0x3DE9E28", Length = "0xCC")]
		public UniTask<List<TeamMember>> GetJoinRequestsAsync()
		{
			_003CGetJoinRequestsAsync_003Ed__21 _003CGetJoinRequestsAsync_003Ed__22 = default(_003CGetJoinRequestsAsync_003Ed__21);
			_003CGetJoinRequestsAsync_003Ed__22._003C_003E1__state = -1;
			_003CGetJoinRequestsAsync_003Ed__22.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<TeamMember>> result = default(UniTask<List<TeamMember>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CAcceptJoinRequestAsync_003Ed__22))]
		[Token(Token = "0x600245B")]
		[Address(RVA = "0x3DE9EF4", Offset = "0x3DE9EF4", Length = "0xD8")]
		public UniTask<bool> AcceptJoinRequestAsync(string requestingSocialId)
		{
			_003CAcceptJoinRequestAsync_003Ed__22 _003CAcceptJoinRequestAsync_003Ed__23 = default(_003CAcceptJoinRequestAsync_003Ed__22);
			_003CAcceptJoinRequestAsync_003Ed__23.requestingSocialId = requestingSocialId;
			_003CAcceptJoinRequestAsync_003Ed__23._003C_003E1__state = -1;
			_003CAcceptJoinRequestAsync_003Ed__23.MoveNext();
			return _003CAcceptJoinRequestAsync_003Ed__23._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CRejectJoinRequestAsync_003Ed__23))]
		[Token(Token = "0x600245C")]
		[Address(RVA = "0x3DE9FCC", Offset = "0x3DE9FCC", Length = "0xD8")]
		public UniTask<bool> RejectJoinRequestAsync(string requestingSocialId)
		{
			_003CRejectJoinRequestAsync_003Ed__23 _003CRejectJoinRequestAsync_003Ed__24 = default(_003CRejectJoinRequestAsync_003Ed__23);
			_003CRejectJoinRequestAsync_003Ed__24.requestingSocialId = requestingSocialId;
			_003CRejectJoinRequestAsync_003Ed__24._003C_003E1__state = -1;
			_003CRejectJoinRequestAsync_003Ed__24.MoveNext();
			return _003CRejectJoinRequestAsync_003Ed__24._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CIncrementStatAsync_003Ed__24))]
		[Token(Token = "0x600245D")]
		[Address(RVA = "0x3DEA0A4", Offset = "0x3DEA0A4", Length = "0xE4")]
		public UniTask<bool> IncrementStatAsync(int incrementValue, string statId)
		{
			_003CIncrementStatAsync_003Ed__24 _003CIncrementStatAsync_003Ed__25 = default(_003CIncrementStatAsync_003Ed__24);
			_003CIncrementStatAsync_003Ed__25.incrementValue = incrementValue;
			_003CIncrementStatAsync_003Ed__25.statId = statId;
			_003CIncrementStatAsync_003Ed__25._003C_003E1__state = -1;
			_003CIncrementStatAsync_003Ed__25.MoveNext();
			return _003CIncrementStatAsync_003Ed__25._003C_003Et__builder.Task;
		}

		[Token(Token = "0x600245E")]
		[Address(RVA = "0x3DEA188", Offset = "0x3DEA188", Length = "0x10")]
		public Team()
		{
			capacity = 50;
		}
	}
}
