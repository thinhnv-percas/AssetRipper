using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using ElephantSocial.Inbox.Model;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Inbox
{
	[Token(Token = "0x20008DE")]
	public static class InboxManager
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008DF")]
		private struct _003CGetInbox_003Ed__0 : IAsyncStateMachine
		{
			[Token(Token = "0x4001DBA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001DBB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<InboxItem>> _003C_003Et__builder;

			[Token(Token = "0x4001DBC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<List<InboxItem>>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002572")]
			[Address(RVA = "0x3E05B1C", Offset = "0x3E05B1C", Length = "0x5C4")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxManager._003CGetInbox_003Ed__0::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002573")]
			[Address(RVA = "0x3E061AC", Offset = "0x3E061AC", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxManager._003CGetInbox_003Ed__0::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20008E0")]
		private struct _003CMarkAsRead_003Ed__1 : IAsyncStateMachine
		{
			[Token(Token = "0x4001DBD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001DBE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001DBF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public int inboxItemId;

			[Token(Token = "0x4001DC0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002574")]
			[Address(RVA = "0x3E06208", Offset = "0x3E06208", Length = "0x594")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InboxManager._003CMarkAsRead_003Ed__1::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002575")]
			[Address(RVA = "0x3E0683C", Offset = "0x3E0683C", Length = "0x5C")]
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

		[AsyncStateMachine(typeof(_003CGetInbox_003Ed__0))]
		[Token(Token = "0x6002570")]
		[Address(RVA = "0x3E05984", Offset = "0x3E05984", Length = "0xCC")]
		public static UniTask<List<InboxItem>> GetInbox()
		{
			_003CGetInbox_003Ed__0 _003CGetInbox_003Ed__1 = default(_003CGetInbox_003Ed__0);
			_003CGetInbox_003Ed__1._003C_003E1__state = -1;
			_003CGetInbox_003Ed__1.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<InboxItem>> result = default(UniTask<List<InboxItem>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CMarkAsRead_003Ed__1))]
		[Token(Token = "0x6002571")]
		[Address(RVA = "0x3E05A50", Offset = "0x3E05A50", Length = "0xCC")]
		public static UniTask<bool> MarkAsRead(int inboxItemId)
		{
			_003CMarkAsRead_003Ed__1 _003CMarkAsRead_003Ed__2 = default(_003CMarkAsRead_003Ed__1);
			_003CMarkAsRead_003Ed__2.inboxItemId = inboxItemId;
			_003CMarkAsRead_003Ed__2._003C_003E1__state = -1;
			_003CMarkAsRead_003Ed__2.MoveNext();
			return _003CMarkAsRead_003Ed__2._003C_003Et__builder.Task;
		}
	}
}
