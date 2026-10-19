using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using ElephantSocial.Inbox.Model;
using ElephantSocial.Inbox.Model.Response;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Inbox
{
	[Token(Token = "0x20008E6")]
	public static class InboxService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008E7")]
		private struct _003CGetInboxAsync_003Ed__0 : IAsyncStateMachine
		{
			[Token(Token = "0x4001DCF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001DD0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<InboxItem>> _003C_003Et__builder;

			[Token(Token = "0x4001DD1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<InboxResponse>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002589")]
			[Address(RVA = "0x3E07214", Offset = "0x3E07214", Length = "0x6F8")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxService._003CGetInboxAsync_003Ed__0::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600258A")]
			[Address(RVA = "0x3E07988", Offset = "0x3E07988", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxService._003CGetInboxAsync_003Ed__0::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008E8")]
		private struct _003CMarkAsReadAsync_003Ed__1 : IAsyncStateMachine
		{
			[Token(Token = "0x4001DD2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001DD3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001DD4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public int inboxItemId;

			[Token(Token = "0x4001DD5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600258B")]
			[Address(RVA = "0x3E079E4", Offset = "0x3E079E4", Length = "0x5A4")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxService._003CMarkAsReadAsync_003Ed__1::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600258C")]
			[Address(RVA = "0x3E07F88", Offset = "0x3E07F88", Length = "0xC")]
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

		[AsyncStateMachine(typeof(_003CGetInboxAsync_003Ed__0))]
		[Token(Token = "0x6002587")]
		[Address(RVA = "0x3E060E0", Offset = "0x3E060E0", Length = "0xCC")]
		public static UniTask<List<InboxItem>> GetInboxAsync()
		{
			_003CGetInboxAsync_003Ed__0 _003CGetInboxAsync_003Ed__1 = default(_003CGetInboxAsync_003Ed__0);
			_003CGetInboxAsync_003Ed__1._003C_003E1__state = -1;
			_003CGetInboxAsync_003Ed__1.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<InboxItem>> result = default(UniTask<List<InboxItem>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CMarkAsReadAsync_003Ed__1))]
		[Token(Token = "0x6002588")]
		[Address(RVA = "0x3E0679C", Offset = "0x3E0679C", Length = "0xA0")]
		public static UniTask MarkAsReadAsync(int inboxItemId)
		{
			_003CMarkAsReadAsync_003Ed__1 _003CMarkAsReadAsync_003Ed__2 = default(_003CMarkAsReadAsync_003Ed__1);
			_003CMarkAsReadAsync_003Ed__2.inboxItemId = inboxItemId;
			_003CMarkAsReadAsync_003Ed__2._003C_003E1__state = -1;
			_003CMarkAsReadAsync_003Ed__2.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}
	}
}
