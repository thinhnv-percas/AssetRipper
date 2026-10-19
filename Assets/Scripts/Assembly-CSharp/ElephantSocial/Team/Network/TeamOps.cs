using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using ElephantSocial.Team.Model;
using ElephantSocial.Team.Model.Request;
using ElephantSocial.Team.Model.Response;
using ElephantSocial.Tournament.Model;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

namespace ElephantSocial.Team.Network
{
	[Token(Token = "0x20008A6")]
	public class TeamOps : GenericResponseOps
	{
		[CompilerGenerated]
		[Token(Token = "0x20008A7")]
		private sealed class _003C_003Ec__DisplayClass0_0<T> where T : new()
		{
			[Token(Token = "0x4001D1A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public UniTaskCompletionSource<T> utcs;

			[Token(Token = "0x6002500")]
			[Address(RVA = "0x4FFD1FC", Offset = "0x4FFD1FC", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_0()
			{
			}

			internal void _003CMakeRequestAsync_003Eb__0(GenericResponse<T> response)
			{
				//IL_0018: Expected I4, but got I8
				int num = (int)(response.responseCode & -2);
				if (num == 200)
				{
					bool flag = utcs.TrySetResult(response.data);
					return;
				}
				Exception exception = new Exception(response.errorMessage);
				bool flag2 = utcs.TrySetException(exception);
			}

			internal void _003CMakeRequestAsync_003Eb__1(string error)
			{
				Exception exception = new Exception(error);
				bool flag = utcs.TrySetException(exception);
			}

			internal void _003CMakeRequestAsync_003Eb__2(UnityWebRequest request)
			{
				TournamentErrorResponse tournamentErrorResponse = SocialUtils.GetTournamentErrorResponse(request);
				long errorCode = tournamentErrorResponse.ErrorCode;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				string message = $"Error {arg}: {tournamentErrorResponse.Message}";
				Exception exception = new Exception(message);
				bool flag = utcs.TrySetException(exception);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008A8")]
		private struct _003CIsServerHealthyAsync_003Ed__17 : IAsyncStateMachine
		{
			[Token(Token = "0x4001D1B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001D1C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001D1D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamOps _003C_003E4__this;

			[Token(Token = "0x4001D1E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UnityWebRequest _003Crequest_003E5__2;

			[Token(Token = "0x4001D1F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask<UnityWebRequest>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002504")]
			[Address(RVA = "0x3DFE2CC", Offset = "0x3DFE2CC", Length = "0x9D8")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamOps._003CIsServerHealthyAsync_003Ed__17::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002505")]
			[Address(RVA = "0x3DFECA4", Offset = "0x3DFECA4", Length = "0x5C")]
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
		[Token(Token = "0x20008A9")]
		private struct _003CMakeRequestAsync_003Ed__0<T> : IAsyncStateMachine where T : new()
		{
			[Token(Token = "0x4001D20")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001D21")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			[Token(Token = "0x4001D22")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public TeamOps _003C_003E4__this;

			[Token(Token = "0x4001D23")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public object data;

			[Token(Token = "0x4001D24")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string url;

			[Token(Token = "0x4001D25")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			private UniTask<T>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002506")]
			[Address(RVA = "0x7374734", Offset = "0x7374734", Length = "0x8A0")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamOps._003CMakeRequestAsync_003Ed__0::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002507")]
			[Address(RVA = "0x7374FD4", Offset = "0x7374FD4", Length = "0x44")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamOps._003CMakeRequestAsync_003Ed__0::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[AsyncStateMachine(typeof(_003CMakeRequestAsync_003Ed__0<>))]
		[Token(Token = "0x60024ED")]
		[Address(RVA = "0x4D0D41C", Offset = "0x4D0D41C", Length = "0xF0")]
		private unsafe UniTask<T> MakeRequestAsync<T>(string url, object data) where T : new()
		{
			int num = 0;
			num = -1;
			nint num2 = 0;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @7374734 (ElephantSocial.Team.Network.TeamOps+<MakeRequestAsync>d__0`1::MoveNext, and 1 more at this address)");
			int num3 = (int)((nint)num | (nint)8);
			return ((AsyncUniTaskMethodBuilder<T>*)num3)->Task;
		}

		[Token(Token = "0x60024EE")]
		[Address(RVA = "0x3DEE054", Offset = "0x3DEE054", Length = "0x164")]
		public UniTask<Player> GetPlayerAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::GetPlayerAsync");
			return default;
		}

		[Token(Token = "0x60024EF")]
		[Address(RVA = "0x3DEDDA4", Offset = "0x3DEDDA4", Length = "0x188")]
		public UniTask<TeamsListResponse> SuggestTeamsAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::SuggestTeamsAsync");
			return default;
		}

		[Token(Token = "0x60024F0")]
		[Address(RVA = "0x3DEDC24", Offset = "0x3DEDC24", Length = "0x180")]
		public UniTask<TeamsListResponse> SearchTeamsAsync(string searchTerm)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::SearchTeamsAsync");
			return default;
		}

		[Token(Token = "0x60024F1")]
		[Address(RVA = "0x3DEE30C", Offset = "0x3DEE30C", Length = "0x180")]
		public UniTask<TeamResponse> GetTeamAsync(string teamId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::GetTeamAsync");
			return default;
		}

		[Token(Token = "0x60024F2")]
		[Address(RVA = "0x3DEE678", Offset = "0x3DEE678", Length = "0x144")]
		public UniTask<TeamResponse> CreateTeamAsync(CreateTeamRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::CreateTeamAsync");
			return default;
		}

		[Token(Token = "0x60024F3")]
		[Address(RVA = "0x3DEE97C", Offset = "0x3DEE97C", Length = "0x144")]
		public UniTask<TeamResponse> JoinTeamAsync(JoinTeamRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::JoinTeamAsync");
			return default;
		}

		[Token(Token = "0x60024F4")]
		[Address(RVA = "0x3DEEC38", Offset = "0x3DEEC38", Length = "0x144")]
		public UniTask<TeamResponse> LeaveTeamAsync(LeaveTeamRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::LeaveTeamAsync");
			return default;
		}

		[Token(Token = "0x60024F5")]
		[Address(RVA = "0x3DEEF68", Offset = "0x3DEEF68", Length = "0x144")]
		public UniTask<TeamResponse> UpdateTeamAsync(UpdateTeamRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::UpdateTeamAsync");
			return default;
		}

		[Token(Token = "0x60024F6")]
		[Address(RVA = "0x3DEF250", Offset = "0x3DEF250", Length = "0x144")]
		public UniTask<TeamResponse> PromoteMemberAsync(PromoteMemberRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::PromoteMemberAsync");
			return default;
		}

		[Token(Token = "0x60024F7")]
		[Address(RVA = "0x3DEF538", Offset = "0x3DEF538", Length = "0x144")]
		public UniTask<TeamResponse> DemoteMemberAsync(DemoteMemberRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::DemoteMemberAsync");
			return default;
		}

		[Token(Token = "0x60024F8")]
		[Address(RVA = "0x3DEF820", Offset = "0x3DEF820", Length = "0x144")]
		public UniTask<TeamResponse> KickMemberAsync(KickMemberRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::KickMemberAsync");
			return default;
		}

		[Token(Token = "0x60024F9")]
		[Address(RVA = "0x3DEFADC", Offset = "0x3DEFADC", Length = "0x144")]
		public UniTask<JoinRequestsResponse> GetJoinRequestsAsync(JoinRequestsRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::GetJoinRequestsAsync");
			return default;
		}

		[Token(Token = "0x60024FA")]
		[Address(RVA = "0x3DEFD98", Offset = "0x3DEFD98", Length = "0x144")]
		public UniTask<PlayerJoinRequestsResponse> GetPlayerJoinRequestsAsync(PlayerJoinRequestsRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::GetPlayerJoinRequestsAsync");
			return default;
		}

		[Token(Token = "0x60024FB")]
		[Address(RVA = "0x3DF0050", Offset = "0x3DF0050", Length = "0x17C")]
		public unsafe UniTask AcceptJoinRequestAsync(AcceptJoinRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::AcceptJoinRequestAsync");
			return default;
		}

		[Token(Token = "0x60024FC")]
		[Address(RVA = "0x3DF0340", Offset = "0x3DF0340", Length = "0x17C")]
		public unsafe UniTask RejectJoinRequestAsync(RejectJoinRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::RejectJoinRequestAsync");
			return default;
		}

		[Token(Token = "0x60024FD")]
		[Address(RVA = "0x3DF0644", Offset = "0x3DF0644", Length = "0x17C")]
		public unsafe UniTask IncrementStat(IncrementStatRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamOps::IncrementStat");
			return default;
		}

		[AsyncStateMachine(typeof(_003CIsServerHealthyAsync_003Ed__17))]
		[Token(Token = "0x60024FE")]
		[Address(RVA = "0x3DF08F0", Offset = "0x3DF08F0", Length = "0xD8")]
		public UniTask<bool> IsServerHealthyAsync()
		{
			_003CIsServerHealthyAsync_003Ed__17 _003CIsServerHealthyAsync_003Ed__18 = default(_003CIsServerHealthyAsync_003Ed__17);
			_003CIsServerHealthyAsync_003Ed__18._003C_003E4__this = this;
			_003CIsServerHealthyAsync_003Ed__18._003C_003E1__state = -1;
			_003CIsServerHealthyAsync_003Ed__18.MoveNext();
			return _003CIsServerHealthyAsync_003Ed__18._003C_003Et__builder.Task;
		}

		[Token(Token = "0x60024FF")]
		[Address(RVA = "0x3DEDAA4", Offset = "0x3DEDAA4", Length = "0x8")]
		public TeamOps()
		{
		}
	}
}
