using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Inbox.Model.Request;
using ElephantSocial.Inbox.Model.Response;
using ElephantSocial.Tournament.Model;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

namespace ElephantSocial.Inbox
{
	[Token(Token = "0x20008E1")]
	public class InboxOps : GenericResponseOps
	{
		[CompilerGenerated]
		[Token(Token = "0x20008E2")]
		private sealed class _003C_003Ec__DisplayClass0_0<T> where T : new()
		{
			[Token(Token = "0x4001DC1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public UniTaskCompletionSource<T> utcs;

			[Token(Token = "0x600257B")]
			[Address(RVA = "0x4FFCF98", Offset = "0x4FFCF98", Length = "0x8")]
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

		[CompilerGenerated]
		[Token(Token = "0x20008E3")]
		private sealed class _003C_003Ec__DisplayClass1_0
		{
			[Token(Token = "0x4001DC2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public UniTaskCompletionSource utcs;

			[Token(Token = "0x600257F")]
			[Address(RVA = "0x3E06974", Offset = "0x3E06974", Length = "0x8")]
			public _003C_003Ec__DisplayClass1_0()
			{
			}

			internal void _003CMakeVoidRequestAsync_003Eb__0(GenericResponse<object> response)
			{
				//IL_0018: Expected I4, but got I8
				int num = (int)(response.responseCode & -2);
				if (num == 200)
				{
					bool flag = utcs.TrySetResult();
					return;
				}
				Exception exception = new Exception(response.errorMessage);
				bool flag2 = utcs.TrySetException(exception);
			}

			internal void _003CMakeVoidRequestAsync_003Eb__1(string error)
			{
				Exception exception = new Exception(error);
				bool flag = utcs.TrySetException(exception);
			}

			internal void _003CMakeVoidRequestAsync_003Eb__2(UnityWebRequest request)
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
		[Token(Token = "0x20008E4")]
		private struct _003CMakeRequestAsync_003Ed__0<T> : IAsyncStateMachine where T : new()
		{
			[Token(Token = "0x4001DC3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001DC4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			[Token(Token = "0x4001DC5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public InboxOps _003C_003E4__this;

			[Token(Token = "0x4001DC6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public object data;

			[Token(Token = "0x4001DC7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string url;

			[Token(Token = "0x4001DC8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			private UniTask<T>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002583")]
			[Address(RVA = "0x7373E50", Offset = "0x7373E50", Length = "0x8A0")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxOps._003CMakeRequestAsync_003Ed__0::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002584")]
			[Address(RVA = "0x73746F0", Offset = "0x73746F0", Length = "0x44")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxOps._003CMakeRequestAsync_003Ed__0::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008E5")]
		private struct _003CMakeVoidRequestAsync_003Ed__1 : IAsyncStateMachine
		{
			[Token(Token = "0x4001DC9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001DCA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001DCB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public InboxOps _003C_003E4__this;

			[Token(Token = "0x4001DCC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public object data;

			[Token(Token = "0x4001DCD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public string url;

			[Token(Token = "0x4001DCE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002585")]
			[Address(RVA = "0x3E06B98", Offset = "0x3E06B98", Length = "0x670")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxOps._003CMakeVoidRequestAsync_003Ed__1::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002586")]
			[Address(RVA = "0x3E07208", Offset = "0x3E07208", Length = "0xC")]
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

		[AsyncStateMachine(typeof(_003CMakeRequestAsync_003Ed__0<>))]
		[Token(Token = "0x6002576")]
		[Address(RVA = "0x499E89C", Offset = "0x499E89C", Length = "0xF0")]
		private unsafe UniTask<T> MakeRequestAsync<T>(string url, object data) where T : new()
		{
			int num = 0;
			num = -1;
			nint num2 = 0;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @7373E50 (ElephantSocial.Inbox.InboxOps+<MakeRequestAsync>d__0`1::MoveNext, and 1 more at this address)");
			int num3 = (int)((nint)num | (nint)8);
			return ((AsyncUniTaskMethodBuilder<T>*)num3)->Task;
		}

		[AsyncStateMachine(typeof(_003CMakeVoidRequestAsync_003Ed__1))]
		[Token(Token = "0x6002577")]
		[Address(RVA = "0x3E06898", Offset = "0x3E06898", Length = "0xDC")]
		private UniTask MakeVoidRequestAsync(string url, object data)
		{
			_003CMakeVoidRequestAsync_003Ed__1 _003CMakeVoidRequestAsync_003Ed__2 = default(_003CMakeVoidRequestAsync_003Ed__1);
			_003CMakeVoidRequestAsync_003Ed__2._003C_003E4__this = this;
			_003CMakeVoidRequestAsync_003Ed__2.url = url;
			_003CMakeVoidRequestAsync_003Ed__2.data = data;
			_003CMakeVoidRequestAsync_003Ed__2._003C_003E1__state = -1;
			_003CMakeVoidRequestAsync_003Ed__2.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[Token(Token = "0x6002578")]
		[Address(RVA = "0x3E05520", Offset = "0x3E05520", Length = "0x144")]
		public UniTask<InboxResponse> GetInboxAsync(GetInboxRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InboxOps::GetInboxAsync");
			return default;
		}

		[Token(Token = "0x6002579")]
		[Address(RVA = "0x3E057D4", Offset = "0x3E057D4", Length = "0x11C")]
		public UniTask MarkAsReadAsync(MarkAsReadRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InboxOps::MarkAsReadAsync");
			return default;
		}

		[Token(Token = "0x600257A")]
		[Address(RVA = "0x3E05398", Offset = "0x3E05398", Length = "0x8")]
		public InboxOps()
		{
		}
	}
}
