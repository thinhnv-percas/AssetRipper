using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSocial.Model;
using ElephantSocial.Team.Model;
using ElephantSocial.Team.Model.Enum;
using ElephantSocial.Team.Model.Response;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Team
{
	[Token(Token = "0x2000894")]
	public static class TeamService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000895")]
		private struct _003CAcceptJoinRequestAsync_003Ed__23 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CD1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CD2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001CD3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string targetSocialId;

			[Token(Token = "0x4001CD4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024CB")]
			[Address(RVA = "0x3DF6A08", Offset = "0x3DF6A08", Length = "0x67C")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CAcceptJoinRequestAsync_003Ed__23::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024CC")]
			[Address(RVA = "0x3DF7084", Offset = "0x3DF7084", Length = "0xC")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000896")]
		private struct _003CCreateTeamAsync_003Ed__13 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CD5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CD6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001CD7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string name;

			[Token(Token = "0x4001CD8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public string description;

			[Token(Token = "0x4001CD9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public int capacity;

			[Token(Token = "0x4001CDA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
			public int requiredLevel;

			[Token(Token = "0x4001CDB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public TeamType teamType;

			[Token(Token = "0x4001CDC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x3C")]
			public int badge;

			[Token(Token = "0x4001CDD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024CD")]
			[Address(RVA = "0x3DF7090", Offset = "0x3DF7090", Length = "0x728")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CCreateTeamAsync_003Ed__13::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024CE")]
			[Address(RVA = "0x3DF77B8", Offset = "0x3DF77B8", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CCreateTeamAsync_003Ed__13::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000897")]
		private struct _003CDemoteMemberAsync_003Ed__19 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CDE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CDF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001CE0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string targetSocialId;

			[Token(Token = "0x4001CE1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024CF")]
			[Address(RVA = "0x3DF7814", Offset = "0x3DF7814", Length = "0x68C")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CDemoteMemberAsync_003Ed__19::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024D0")]
			[Address(RVA = "0x3DF7EA0", Offset = "0x3DF7EA0", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CDemoteMemberAsync_003Ed__19::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000898")]
		private struct _003CGetJoinRequestsAsync_003Ed__21 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CE2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CE3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<TeamMember>> _003C_003Et__builder;

			[Token(Token = "0x4001CE4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<JoinRequestsResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024D1")]
			[Address(RVA = "0x3DF7EFC", Offset = "0x3DF7EFC", Length = "0x8DC")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetJoinRequestsAsync_003Ed__21::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024D2")]
			[Address(RVA = "0x3DF87D8", Offset = "0x3DF87D8", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetJoinRequestsAsync_003Ed__21::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000899")]
		private struct _003CGetMyTeamIdAsync_003Ed__10 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CE5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CE6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<string> _003C_003Et__builder;

			[Token(Token = "0x4001CE7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<Player>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024D3")]
			[Address(RVA = "0x3DF8834", Offset = "0x3DF8834", Length = "0x670")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetMyTeamIdAsync_003Ed__10::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024D4")]
			[Address(RVA = "0x3DF8EA4", Offset = "0x3DF8EA4", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetMyTeamIdAsync_003Ed__10::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200089A")]
		private struct _003CGetPlayerAsync_003Ed__9 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CE8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CE9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<Player> _003C_003Et__builder;

			[Token(Token = "0x4001CEA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<Player>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024D5")]
			[Address(RVA = "0x3DF8F00", Offset = "0x3DF8F00", Length = "0x67C")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetPlayerAsync_003Ed__9::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024D6")]
			[Address(RVA = "0x3DF957C", Offset = "0x3DF957C", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetPlayerAsync_003Ed__9::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200089B")]
		private struct _003CGetPlayerJoinRequestsAsync_003Ed__22 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CEB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CEC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<string>> _003C_003Et__builder;

			[Token(Token = "0x4001CED")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<PlayerJoinRequestsResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024D7")]
			[Address(RVA = "0x3DF95D8", Offset = "0x3DF95D8", Length = "0x8E4")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetPlayerJoinRequestsAsync_003Ed__22::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024D8")]
			[Address(RVA = "0x3DF9EBC", Offset = "0x3DF9EBC", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetPlayerJoinRequestsAsync_003Ed__22::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200089C")]
		private struct _003CGetTeamAsync_003Ed__12 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CEE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CEF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001CF0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string teamId;

			[Token(Token = "0x4001CF1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024D9")]
			[Address(RVA = "0x3DF9F18", Offset = "0x3DF9F18", Length = "0x6D0")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetTeamAsync_003Ed__12::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024DA")]
			[Address(RVA = "0x3DFA5E8", Offset = "0x3DFA5E8", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetTeamAsync_003Ed__12::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200089D")]
		private struct _003CGetTeamsAsync_003Ed__11 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CF2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CF3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<TeamResponse>> _003C_003Et__builder;

			[Token(Token = "0x4001CF4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string searchTerm;

			[Token(Token = "0x4001CF5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamsListResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024DB")]
			[Address(RVA = "0x3DFA644", Offset = "0x3DFA644", Length = "0x6D8")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetTeamsAsync_003Ed__11::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024DC")]
			[Address(RVA = "0x3DFAD1C", Offset = "0x3DFAD1C", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CGetTeamsAsync_003Ed__11::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200089E")]
		private struct _003CIncrementStatAsync_003Ed__25 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CF6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CF7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001CF8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public int incrementValue;

			[Token(Token = "0x4001CF9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string statId;

			[Token(Token = "0x4001CFA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024DD")]
			[Address(RVA = "0x3DFAD78", Offset = "0x3DFAD78", Length = "0x5AC")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CIncrementStatAsync_003Ed__25::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024DE")]
			[Address(RVA = "0x3DFB324", Offset = "0x3DFB324", Length = "0xC")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200089F")]
		private struct _003CIsServerHealthyAsync_003Ed__26 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CFB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CFC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001CFD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<bool>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024DF")]
			[Address(RVA = "0x3DFB330", Offset = "0x3DFB330", Length = "0x5EC")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CIsServerHealthyAsync_003Ed__26::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024E0")]
			[Address(RVA = "0x3DFB91C", Offset = "0x3DFB91C", Length = "0x5C")]
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
		[Token(Token = "0x20008A0")]
		private struct _003CJoinTeamAsync_003Ed__14 : IAsyncStateMachine
		{
			[Token(Token = "0x4001CFE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001CFF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001D00")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string teamId;

			[Token(Token = "0x4001D01")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024E1")]
			[Address(RVA = "0x3DFB978", Offset = "0x3DFB978", Length = "0x724")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CJoinTeamAsync_003Ed__14::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024E2")]
			[Address(RVA = "0x3DFC09C", Offset = "0x3DFC09C", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CJoinTeamAsync_003Ed__14::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008A1")]
		private struct _003CKickMemberAsync_003Ed__20 : IAsyncStateMachine
		{
			[Token(Token = "0x4001D02")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001D03")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001D04")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string targetSocialId;

			[Token(Token = "0x4001D05")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024E3")]
			[Address(RVA = "0x3DFC0F8", Offset = "0x3DFC0F8", Length = "0x68C")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CKickMemberAsync_003Ed__20::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024E4")]
			[Address(RVA = "0x3DFC784", Offset = "0x3DFC784", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CKickMemberAsync_003Ed__20::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008A2")]
		private struct _003CLeaveTeamAsync_003Ed__15 : IAsyncStateMachine
		{
			[Token(Token = "0x4001D06")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001D07")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001D08")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024E5")]
			[Address(RVA = "0x3DFC7E0", Offset = "0x3DFC7E0", Length = "0x6EC")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CLeaveTeamAsync_003Ed__15::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024E6")]
			[Address(RVA = "0x3DFCECC", Offset = "0x3DFCECC", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CLeaveTeamAsync_003Ed__15::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008A3")]
		private struct _003CPromoteMemberAsync_003Ed__18 : IAsyncStateMachine
		{
			[Token(Token = "0x4001D09")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001D0A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001D0B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string targetSocialId;

			[Token(Token = "0x4001D0C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024E7")]
			[Address(RVA = "0x3DFCF28", Offset = "0x3DFCF28", Length = "0x68C")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CPromoteMemberAsync_003Ed__18::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024E8")]
			[Address(RVA = "0x3DFD5B4", Offset = "0x3DFD5B4", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CPromoteMemberAsync_003Ed__18::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008A4")]
		private struct _003CRejectJoinRequestAsync_003Ed__24 : IAsyncStateMachine
		{
			[Token(Token = "0x4001D0D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001D0E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001D0F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string targetSocialId;

			[Token(Token = "0x4001D10")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024E9")]
			[Address(RVA = "0x3DFD610", Offset = "0x3DFD610", Length = "0x5A8")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CRejectJoinRequestAsync_003Ed__24::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024EA")]
			[Address(RVA = "0x3DFDBB8", Offset = "0x3DFDBB8", Length = "0xC")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008A5")]
		private struct _003CUpdateTeamAsync_003Ed__17 : IAsyncStateMachine
		{
			[Token(Token = "0x4001D11")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001D12")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamResponse> _003C_003Et__builder;

			[Token(Token = "0x4001D13")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string name;

			[Token(Token = "0x4001D14")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public int capacity;

			[Token(Token = "0x4001D15")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public int requiredLevel;

			[Token(Token = "0x4001D16")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public int teamType;

			[Token(Token = "0x4001D17")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public string description;

			[Token(Token = "0x4001D18")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public int badge;

			[Token(Token = "0x4001D19")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			private UniTask<TeamResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x60024EB")]
			[Address(RVA = "0x3DFDBC4", Offset = "0x3DFDBC4", Length = "0x69C")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CUpdateTeamAsync_003Ed__17::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60024EC")]
			[Address(RVA = "0x3DFE260", Offset = "0x3DFE260", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamService._003CUpdateTeamAsync_003Ed__17::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x4001CCE")]
		internal static Action OnTeamJoined;

		[CompilerGenerated]
		[Token(Token = "0x4001CCF")]
		internal static Action OnTeamLeft;

		[CompilerGenerated]
		[Token(Token = "0x4001CD0")]
		internal static Action OnTeamCreated;

		[CompilerGenerated]
		[Token(Token = "0x60024B0")]
		[Address(RVA = "0x3DF12D0", Offset = "0x3DF12D0", Length = "0xC0")]
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
		[Token(Token = "0x60024B1")]
		[Address(RVA = "0x3DF64F0", Offset = "0x3DF64F0", Length = "0xC0")]
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
		[Token(Token = "0x60024B2")]
		[Address(RVA = "0x3DF1390", Offset = "0x3DF1390", Length = "0xC4")]
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
		[Token(Token = "0x60024B3")]
		[Address(RVA = "0x3DF65B0", Offset = "0x3DF65B0", Length = "0xC4")]
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
		[Token(Token = "0x60024B4")]
		[Address(RVA = "0x3DF1454", Offset = "0x3DF1454", Length = "0xC4")]
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
		[Token(Token = "0x60024B5")]
		[Address(RVA = "0x3DF6674", Offset = "0x3DF6674", Length = "0xC4")]
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

		[AsyncStateMachine(typeof(_003CGetPlayerAsync_003Ed__9))]
		[Token(Token = "0x60024B6")]
		[Address(RVA = "0x3DF6738", Offset = "0x3DF6738", Length = "0xCC")]
		public static UniTask<Player> GetPlayerAsync()
		{
			_003CGetPlayerAsync_003Ed__9 _003CGetPlayerAsync_003Ed__10 = default(_003CGetPlayerAsync_003Ed__9);
			_003CGetPlayerAsync_003Ed__10._003C_003E1__state = -1;
			_003CGetPlayerAsync_003Ed__10.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<Player> result = default(UniTask<Player>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetMyTeamIdAsync_003Ed__10))]
		[Token(Token = "0x60024B7")]
		[Address(RVA = "0x3DF3344", Offset = "0x3DF3344", Length = "0xCC")]
		public static UniTask<string> GetMyTeamIdAsync()
		{
			_003CGetMyTeamIdAsync_003Ed__10 _003CGetMyTeamIdAsync_003Ed__11 = default(_003CGetMyTeamIdAsync_003Ed__10);
			_003CGetMyTeamIdAsync_003Ed__11._003C_003E1__state = -1;
			_003CGetMyTeamIdAsync_003Ed__11.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<string> result = default(UniTask<string>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetTeamsAsync_003Ed__11))]
		[Token(Token = "0x60024B8")]
		[Address(RVA = "0x3DF4A20", Offset = "0x3DF4A20", Length = "0xE4")]
		public static UniTask<List<TeamResponse>> GetTeamsAsync(string searchTerm = "")
		{
			_003CGetTeamsAsync_003Ed__11 _003CGetTeamsAsync_003Ed__12 = default(_003CGetTeamsAsync_003Ed__11);
			_003CGetTeamsAsync_003Ed__12.searchTerm = searchTerm;
			_003CGetTeamsAsync_003Ed__12._003C_003E1__state = -1;
			_003CGetTeamsAsync_003Ed__12.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<TeamResponse>> result = default(UniTask<List<TeamResponse>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetTeamAsync_003Ed__12))]
		[Token(Token = "0x60024B9")]
		[Address(RVA = "0x3DF3A34", Offset = "0x3DF3A34", Length = "0xE4")]
		public static UniTask<TeamResponse> GetTeamAsync(string teamId)
		{
			_003CGetTeamAsync_003Ed__12 _003CGetTeamAsync_003Ed__13 = default(_003CGetTeamAsync_003Ed__12);
			_003CGetTeamAsync_003Ed__13.teamId = teamId;
			_003CGetTeamAsync_003Ed__13._003C_003E1__state = -1;
			_003CGetTeamAsync_003Ed__13.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CCreateTeamAsync_003Ed__13))]
		[Token(Token = "0x60024BA")]
		[Address(RVA = "0x3DF2304", Offset = "0x3DF2304", Length = "0x128")]
		public static UniTask<TeamResponse> CreateTeamAsync(string name, int capacity, int requiredLevel, TeamType teamType, int badge, string description)
		{
			_003CCreateTeamAsync_003Ed__13 _003CCreateTeamAsync_003Ed__14 = default(_003CCreateTeamAsync_003Ed__13);
			_003CCreateTeamAsync_003Ed__14.name = name;
			_003CCreateTeamAsync_003Ed__14.capacity = capacity;
			_003CCreateTeamAsync_003Ed__14.requiredLevel = requiredLevel;
			_003CCreateTeamAsync_003Ed__14.teamType = teamType;
			_003CCreateTeamAsync_003Ed__14.badge = badge;
			_003CCreateTeamAsync_003Ed__14.description = description;
			_003CCreateTeamAsync_003Ed__14._003C_003E1__state = -1;
			_003CCreateTeamAsync_003Ed__14.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CJoinTeamAsync_003Ed__14))]
		[Token(Token = "0x60024BB")]
		[Address(RVA = "0x3DEBBC8", Offset = "0x3DEBBC8", Length = "0xE4")]
		public static UniTask<TeamResponse> JoinTeamAsync(string teamId)
		{
			_003CJoinTeamAsync_003Ed__14 _003CJoinTeamAsync_003Ed__15 = default(_003CJoinTeamAsync_003Ed__14);
			_003CJoinTeamAsync_003Ed__15.teamId = teamId;
			_003CJoinTeamAsync_003Ed__15._003C_003E1__state = -1;
			_003CJoinTeamAsync_003Ed__15.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CLeaveTeamAsync_003Ed__15))]
		[Token(Token = "0x60024BC")]
		[Address(RVA = "0x3DECB10", Offset = "0x3DECB10", Length = "0xCC")]
		public static UniTask<TeamResponse> LeaveTeamAsync()
		{
			_003CLeaveTeamAsync_003Ed__15 _003CLeaveTeamAsync_003Ed__16 = default(_003CLeaveTeamAsync_003Ed__15);
			_003CLeaveTeamAsync_003Ed__16._003C_003E1__state = -1;
			_003CLeaveTeamAsync_003Ed__16.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[Token(Token = "0x60024BD")]
		[Address(RVA = "0x3DF6804", Offset = "0x3DF6804", Length = "0x19C")]
		public static void TriggerTeamLeft()
		{
			if (OnTeamLeft != null)
			{
				OnTeamLeft();
			}
		}

		[AsyncStateMachine(typeof(_003CUpdateTeamAsync_003Ed__17))]
		[Token(Token = "0x60024BE")]
		[Address(RVA = "0x3DED814", Offset = "0x3DED814", Length = "0x128")]
		public static UniTask<TeamResponse> UpdateTeamAsync(string name, int capacity, int requiredLevel, int teamType, string description, int badge)
		{
			_003CUpdateTeamAsync_003Ed__17 _003CUpdateTeamAsync_003Ed__18 = default(_003CUpdateTeamAsync_003Ed__17);
			_003CUpdateTeamAsync_003Ed__18.name = name;
			_003CUpdateTeamAsync_003Ed__18.capacity = capacity;
			_003CUpdateTeamAsync_003Ed__18.requiredLevel = requiredLevel;
			_003CUpdateTeamAsync_003Ed__18.teamType = teamType;
			_003CUpdateTeamAsync_003Ed__18.description = description;
			_003CUpdateTeamAsync_003Ed__18.badge = badge;
			_003CUpdateTeamAsync_003Ed__18._003C_003E1__state = -1;
			_003CUpdateTeamAsync_003Ed__18.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CPromoteMemberAsync_003Ed__18))]
		[Token(Token = "0x60024BF")]
		[Address(RVA = "0x3DF63B0", Offset = "0x3DF63B0", Length = "0xE4")]
		public static UniTask<TeamResponse> PromoteMemberAsync(string targetSocialId)
		{
			_003CPromoteMemberAsync_003Ed__18 _003CPromoteMemberAsync_003Ed__19 = default(_003CPromoteMemberAsync_003Ed__18);
			_003CPromoteMemberAsync_003Ed__19.targetSocialId = targetSocialId;
			_003CPromoteMemberAsync_003Ed__19._003C_003E1__state = -1;
			_003CPromoteMemberAsync_003Ed__19.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CDemoteMemberAsync_003Ed__19))]
		[Token(Token = "0x60024C0")]
		[Address(RVA = "0x3DF5CD4", Offset = "0x3DF5CD4", Length = "0xE4")]
		public static UniTask<TeamResponse> DemoteMemberAsync(string targetSocialId)
		{
			_003CDemoteMemberAsync_003Ed__19 _003CDemoteMemberAsync_003Ed__20 = default(_003CDemoteMemberAsync_003Ed__19);
			_003CDemoteMemberAsync_003Ed__20.targetSocialId = targetSocialId;
			_003CDemoteMemberAsync_003Ed__20._003C_003E1__state = -1;
			_003CDemoteMemberAsync_003Ed__20.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CKickMemberAsync_003Ed__20))]
		[Token(Token = "0x60024C1")]
		[Address(RVA = "0x3DEC44C", Offset = "0x3DEC44C", Length = "0xE4")]
		public static UniTask<TeamResponse> KickMemberAsync(string targetSocialId)
		{
			_003CKickMemberAsync_003Ed__20 _003CKickMemberAsync_003Ed__21 = default(_003CKickMemberAsync_003Ed__20);
			_003CKickMemberAsync_003Ed__21.targetSocialId = targetSocialId;
			_003CKickMemberAsync_003Ed__21._003C_003E1__state = -1;
			_003CKickMemberAsync_003Ed__21.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamResponse> result = default(UniTask<TeamResponse>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetJoinRequestsAsync_003Ed__21))]
		[Token(Token = "0x60024C2")]
		[Address(RVA = "0x3DEAEB4", Offset = "0x3DEAEB4", Length = "0xCC")]
		public static UniTask<List<TeamMember>> GetJoinRequestsAsync()
		{
			_003CGetJoinRequestsAsync_003Ed__21 _003CGetJoinRequestsAsync_003Ed__22 = default(_003CGetJoinRequestsAsync_003Ed__21);
			_003CGetJoinRequestsAsync_003Ed__22._003C_003E1__state = -1;
			_003CGetJoinRequestsAsync_003Ed__22.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<TeamMember>> result = default(UniTask<List<TeamMember>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetPlayerJoinRequestsAsync_003Ed__22))]
		[Token(Token = "0x60024C3")]
		[Address(RVA = "0x3DF2C5C", Offset = "0x3DF2C5C", Length = "0xCC")]
		public static UniTask<List<string>> GetPlayerJoinRequestsAsync()
		{
			_003CGetPlayerJoinRequestsAsync_003Ed__22 _003CGetPlayerJoinRequestsAsync_003Ed__23 = default(_003CGetPlayerJoinRequestsAsync_003Ed__22);
			_003CGetPlayerJoinRequestsAsync_003Ed__23._003C_003E1__state = -1;
			_003CGetPlayerJoinRequestsAsync_003Ed__23.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<string>> result = default(UniTask<List<string>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CAcceptJoinRequestAsync_003Ed__23))]
		[Token(Token = "0x60024C4")]
		[Address(RVA = "0x3DEA7E8", Offset = "0x3DEA7E8", Length = "0xAC")]
		public static UniTask AcceptJoinRequestAsync(string targetSocialId)
		{
			_003CAcceptJoinRequestAsync_003Ed__23 _003CAcceptJoinRequestAsync_003Ed__24 = default(_003CAcceptJoinRequestAsync_003Ed__23);
			_003CAcceptJoinRequestAsync_003Ed__24.targetSocialId = targetSocialId;
			_003CAcceptJoinRequestAsync_003Ed__24._003C_003E1__state = -1;
			_003CAcceptJoinRequestAsync_003Ed__24.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CRejectJoinRequestAsync_003Ed__24))]
		[Token(Token = "0x60024C5")]
		[Address(RVA = "0x3DED15C", Offset = "0x3DED15C", Length = "0xAC")]
		public static UniTask RejectJoinRequestAsync(string targetSocialId)
		{
			_003CRejectJoinRequestAsync_003Ed__24 _003CRejectJoinRequestAsync_003Ed__25 = default(_003CRejectJoinRequestAsync_003Ed__24);
			_003CRejectJoinRequestAsync_003Ed__25.targetSocialId = targetSocialId;
			_003CRejectJoinRequestAsync_003Ed__25._003C_003E1__state = -1;
			_003CRejectJoinRequestAsync_003Ed__25.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CIncrementStatAsync_003Ed__25))]
		[Token(Token = "0x60024C6")]
		[Address(RVA = "0x3DEB504", Offset = "0x3DEB504", Length = "0xB8")]
		public static UniTask IncrementStatAsync(int incrementValue, string statId)
		{
			_003CIncrementStatAsync_003Ed__25 _003CIncrementStatAsync_003Ed__26 = default(_003CIncrementStatAsync_003Ed__25);
			_003CIncrementStatAsync_003Ed__26.incrementValue = incrementValue;
			_003CIncrementStatAsync_003Ed__26.statId = statId;
			_003CIncrementStatAsync_003Ed__26._003C_003E1__state = -1;
			_003CIncrementStatAsync_003Ed__26.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CIsServerHealthyAsync_003Ed__26))]
		[Token(Token = "0x60024C7")]
		[Address(RVA = "0x3DF40CC", Offset = "0x3DF40CC", Length = "0xC0")]
		public static UniTask<bool> IsServerHealthyAsync()
		{
			_003CIsServerHealthyAsync_003Ed__26 _003CIsServerHealthyAsync_003Ed__27 = default(_003CIsServerHealthyAsync_003Ed__26);
			_003CIsServerHealthyAsync_003Ed__27._003C_003E1__state = -1;
			_003CIsServerHealthyAsync_003Ed__27.MoveNext();
			return _003CIsServerHealthyAsync_003Ed__27._003C_003Et__builder.Task;
		}

		[Token(Token = "0x60024C8")]
		[Address(RVA = "0x3DF242C", Offset = "0x3DF242C", Length = "0x210")]
		public static Team FromTeamResponse(TeamResponse response)
		{
			Team team = new Team();
			team.capacity = 50;
			team.id = response.TeamId;
			team.name = response.Name;
			team.stars = response.Stars;
			team.capacity = response.Capacity;
			team.size = response.Size;
			team.description = response.Description;
			team.requiredLevel = response.RequiredLevel;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			team.weeklyHelps = response.TeamType;
			team.badgeId = response.Badge;
			List<TeamMember> members = new List<TeamMember>();
			team.members = members;
			team.count = response.OnlineCount;
			team.country = response.Country;
			team.TeamStat = response.TeamStat;
			TeamMemberResponse[] teamMembers = response.TeamMembers;
			if (response.TeamMembers != null && teamMembers.Length >= 1)
			{
				int num = 0;
				do
				{
					List<TeamMember> members2 = team.members;
					TeamMember item = TeamMember.FromServerModel(teamMembers[num]);
					members2.Add(item);
					num++;
				}
				while (num < teamMembers.Length);
			}
			return team;
		}

		[Token(Token = "0x60024C9")]
		[Address(RVA = "0x3DEBCAC", Offset = "0x3DEBCAC", Length = "0x190")]
		public static void UpdateFromResponse(TeamResponse response, Team elephantTeam)
		{
			elephantTeam.name = response.Name;
			elephantTeam.description = response.Description;
			elephantTeam.stars = response.Stars;
			elephantTeam.capacity = response.Capacity;
			elephantTeam.size = response.Size;
			elephantTeam.requiredLevel = response.RequiredLevel;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			elephantTeam.weeklyHelps = response.TeamType;
			elephantTeam.badgeId = response.Badge;
			List<TeamMember> members = elephantTeam.members;
			members.Clear();
			if (members.Count >= 1)
			{
			}
			TeamMemberResponse[] teamMembers = response.TeamMembers;
			if (response.TeamMembers != null && teamMembers.Length >= 1)
			{
				int num = 0;
				do
				{
					List<TeamMember> members2 = elephantTeam.members;
					TeamMember item = TeamMember.FromServerModel(teamMembers[num]);
					members2.Add(item);
					num++;
				}
				while (num < teamMembers.Length);
			}
		}

		[Token(Token = "0x60024CA")]
		[Address(RVA = "0x3DF69A0", Offset = "0x3DF69A0", Length = "0x68")]
		public static void TriggerTeamJoined()
		{
			if (OnTeamJoined != null)
			{
				OnTeamJoined();
			}
		}
	}
}
