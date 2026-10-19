using System;
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
	[Token(Token = "0x2000891")]
	public class TeamMember
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000892")]
		private struct _003CDemoteMemberAsync_003Ed__10 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CC6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CC7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001CC8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamMember _003C_003E4__this;

			[Token(Token = "0x4001CC9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024AC")]
			[Address(RVA = "0x3DF5738", Offset = "0x3DF5738", Length = "0x59C")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamMember._003CDemoteMemberAsync_003Ed__10::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024AD")]
			[Address(RVA = "0x3DF5DB8", Offset = "0x3DF5DB8", Length = "0x5C")]
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
		[Token(Token = "0x2000893")]
		private struct _003CPromoteMemberAsync_003Ed__9 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CCA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CCB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001CCC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamMember _003C_003E4__this;

			[Token(Token = "0x4001CCD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024AE")]
			[Address(RVA = "0x3DF5E14", Offset = "0x3DF5E14", Length = "0x59C")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamMember._003CPromoteMemberAsync_003Ed__9::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024AF")]
			[Address(RVA = "0x3DF6494", Offset = "0x3DF6494", Length = "0x5C")]
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

		[Token(Token = "0x4001CBF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x4001CC0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public string name;

		[Token(Token = "0x4001CC1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public int score;

		[Token(Token = "0x4001CC2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public int helps;

		[Token(Token = "0x4001CC3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public TeamMemberRole role;

		[Token(Token = "0x4001CC4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
		public int badge;

		[Token(Token = "0x4001CC5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public string profilePicture;

		[Token(Token = "0x60024A7")]
		[Address(RVA = "0x3DF5408", Offset = "0x3DF5408", Length = "0xCC")]
		public static TeamMember FromServerModel(TeamMemberResponse serverModel)
		{
			TeamMember teamMember = new TeamMember();
			teamMember.id = serverModel.SocialId;
			PlayerInfo playerInfo = serverModel.PlayerInfo;
			teamMember.name = playerInfo.PlayerName;
			teamMember.score = serverModel.Score;
			teamMember.helps = serverModel.Helps;
			teamMember.role = (TeamMemberRole)serverModel.Role;
			PlayerInfo playerInfo2 = serverModel.PlayerInfo;
			teamMember.badge = playerInfo2.Badge;
			teamMember.profilePicture = playerInfo2.ProfilePicture;
			return teamMember;
		}

		[Token(Token = "0x60024A8")]
		[Address(RVA = "0x3DF54DC", Offset = "0x3DF54DC", Length = "0xAC")]
		public Player GetProfile()
		{
			Player player = new Player();
			player.playerName = name;
			player.socialId = id;
			player.badge = badge;
			player.profilePicture = profilePicture;
			player.status = 1;
			return player;
		}

		[AsyncStateMachine(typeof(_003CPromoteMemberAsync_003Ed__9))]
		[Token(Token = "0x60024A9")]
		[Address(RVA = "0x3DF5590", Offset = "0x3DF5590", Length = "0xD4")]
		public UniTask<bool> PromoteMemberAsync()
		{
			_003CPromoteMemberAsync_003Ed__9 _003CPromoteMemberAsync_003Ed__10 = default(_003CPromoteMemberAsync_003Ed__9);
			_003CPromoteMemberAsync_003Ed__10._003C_003E4__this = this;
			_003CPromoteMemberAsync_003Ed__10._003C_003E1__state = -1;
			_003CPromoteMemberAsync_003Ed__10.MoveNext();
			return _003CPromoteMemberAsync_003Ed__10._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CDemoteMemberAsync_003Ed__10))]
		[Token(Token = "0x60024AA")]
		[Address(RVA = "0x3DF5664", Offset = "0x3DF5664", Length = "0xD4")]
		public UniTask<bool> DemoteMemberAsync()
		{
			_003CDemoteMemberAsync_003Ed__10 _003CDemoteMemberAsync_003Ed__11 = default(_003CDemoteMemberAsync_003Ed__10);
			_003CDemoteMemberAsync_003Ed__11._003C_003E4__this = this;
			_003CDemoteMemberAsync_003Ed__11._003C_003E1__state = -1;
			_003CDemoteMemberAsync_003Ed__11.MoveNext();
			return _003CDemoteMemberAsync_003Ed__11._003C_003Et__builder.Task;
		}

		[Token(Token = "0x60024AB")]
		[Address(RVA = "0x3DF54D4", Offset = "0x3DF54D4", Length = "0x8")]
		public TeamMember()
		{
		}
	}
}
