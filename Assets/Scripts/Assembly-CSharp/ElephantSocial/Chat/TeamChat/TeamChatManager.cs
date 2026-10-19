using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Chat.Core;
using ElephantSocial.Chat.Interface;
using ElephantSocial.Chat.Model;
using ElephantSocial.Model;
using ElephantSocial.Team;
using ElephantSocial.Team.Model.Enum;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Chat.TeamChat
{
	[Token(Token = "0x20008FD")]
	public class TeamChatManager
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20008FE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001E0C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001E0D")]
			public static Func<bool> _003C_003E9__48_0;

			[Token(Token = "0x4001E0E")]
			public static Comparison<ChatMessage> _003C_003E9__49_1;

			[Token(Token = "0x4001E0F")]
			public static Func<TeamMember, JoinRequestMessage> _003C_003E9__50_1;

			[Token(Token = "0x4001E10")]
			public static Comparison<ChatMessage> _003C_003E9__62_1;

			[Token(Token = "0x4001E11")]
			public static Comparison<ChatMessage> _003C_003E9__63_1;

			[Token(Token = "0x4001E12")]
			public static Predicate<ChatMessage> _003C_003E9__67_1;

			[Token(Token = "0x4001E13")]
			public static Comparison<ChatMessage> _003C_003E9__67_2;

			[Token(Token = "0x60025F9")]
			[Address(RVA = "0x3E0F4F4", Offset = "0x3E0F4F4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60025FA")]
			[Address(RVA = "0x3E0F558", Offset = "0x3E0F558", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGetCurrentTeamChatAsync_003Eb__48_0()
			{
				return !_isInitializing;
			}

			internal int _003CGetHistoryAsync_003Eb__49_1(ChatMessage a, ChatMessage b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003C_003Ec::_003CGetHistoryAsync_003Eb__49_1");
				return default;
			}

			internal JoinRequestMessage _003CGetJoinRequestsInParallel_003Eb__50_1(TeamMember request)
			{
				JoinRequestMessage joinRequestMessage = new JoinRequestMessage
				{
					Type = ChatMessageType.JOIN_REQUEST
				};
				DateTime utcNow = DateTime.UtcNow;
				DateTime dateTime = utcNow;
				long ticks = dateTime.Ticks;
				long num = ticks;
				int num2 = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				string _003CID_003Ek__BackingField = $"join_request_{request.id}_{arg}";
				joinRequestMessage.ID = _003CID_003Ek__BackingField;
				joinRequestMessage.RequestingSocialId = request.id;
				joinRequestMessage.RequestingPlayerName = request.name;
				joinRequestMessage.RequestingProfilePicture = request.profilePicture;
				DateTime utcNow2 = DateTime.UtcNow;
				dateTime = utcNow2;
				long ticks2 = dateTime.Ticks;
				joinRequestMessage.CreatedAt = ticks2;
				DateTime utcNow3 = DateTime.UtcNow;
				dateTime = utcNow3;
				long ticks3 = dateTime.Ticks;
				joinRequestMessage.UpdatedAt = ticks3;
				joinRequestMessage.Sender = new TeamMember
				{
					id = request.id,
					name = request.name
				};
				return joinRequestMessage;
			}

			internal int _003CHandleMessageCreated_003Eb__62_1(ChatMessage a, ChatMessage b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003C_003Ec::_003CHandleMessageCreated_003Eb__62_1");
				return default;
			}

			internal int _003CHandleMessageUpdated_003Eb__63_1(ChatMessage a, ChatMessage b)
			{
				return string.Compare(a.ID, b.ID, StringComparison.Ordinal);
			}

			internal bool _003CRefreshJoinRequestsAsync_003Eb__67_1(ChatMessage m)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003C_003Ec::_003CRefreshJoinRequestsAsync_003Eb__67_1");
				return default;
			}

			internal int _003CRefreshJoinRequestsAsync_003Eb__67_2(ChatMessage a, ChatMessage b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003C_003Ec::_003CRefreshJoinRequestsAsync_003Eb__67_2");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20008FF")]
		private sealed class _003C_003Ec__DisplayClass49_0
		{
			[Token(Token = "0x4001E14")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public List<ChatMessage> messages;

			[Token(Token = "0x4001E15")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public UniTaskCompletionSource<List<ChatMessage>> historyTask;

			[Token(Token = "0x4001E16")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x6002602")]
			[Address(RVA = "0x3E0FB88", Offset = "0x3E0FB88", Length = "0x8")]
			public _003C_003Ec__DisplayClass49_0()
			{
			}

			internal unsafe void _003CGetHistoryAsync_003Eb__0(object _, HistoryReceivedEventArgs args)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003C_003Ec__DisplayClass49_0::_003CGetHistoryAsync_003Eb__0");
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000901")]
		private sealed class _003C_003Ec__DisplayClass53_0
		{
			[Token(Token = "0x4001E18")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string targetMessageId;

			[Token(Token = "0x6002606")]
			[Address(RVA = "0x3E0FF1C", Offset = "0x3E0FF1C", Length = "0x8")]
			public _003C_003Ec__DisplayClass53_0()
			{
			}

			internal bool _003CSendHelpAsync_003Eb__0(ChatMessage m)
			{
				return m.ID == targetMessageId;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000902")]
		private sealed class _003C_003Ec__DisplayClass62_0
		{
			[Token(Token = "0x4001E19")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public ChatMessage message;

			[Token(Token = "0x6002608")]
			[Address(RVA = "0x3E0DDD4", Offset = "0x3E0DDD4", Length = "0x8")]
			public _003C_003Ec__DisplayClass62_0()
			{
			}

			internal bool _003CHandleMessageCreated_003Eb__0(ChatMessage m)
			{
				ChatMessage chatMessage = message;
				return m.ID == chatMessage.ID;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000903")]
		private sealed class _003C_003Ec__DisplayClass63_0
		{
			[Token(Token = "0x4001E1A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public ChatMessage message;

			[Token(Token = "0x600260A")]
			[Address(RVA = "0x3E0EDE4", Offset = "0x3E0EDE4", Length = "0x8")]
			public _003C_003Ec__DisplayClass63_0()
			{
			}

			internal bool _003CHandleMessageUpdated_003Eb__0(ChatMessage m)
			{
				ChatMessage chatMessage = message;
				return m.ID == chatMessage.ID;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000904")]
		private sealed class _003C_003Ec__DisplayClass64_0
		{
			[Token(Token = "0x4001E1B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public MessageDeletedEventArgs args;

			[Token(Token = "0x600260C")]
			[Address(RVA = "0x3E0F0EC", Offset = "0x3E0F0EC", Length = "0x8")]
			public _003C_003Ec__DisplayClass64_0()
			{
			}

			internal bool _003CHandleMessageDeleted_003Eb__0(ChatMessage m)
			{
				MessageDeletedEventArgs e = args;
				DeletedMessagePayload deletionInfo = e.DeletionInfo;
				return m.ID == deletionInfo.Id;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000905")]
		private struct _003CGetCurrentTeamChatAsync_003Ed__48 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E1C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E1D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamChatManager> _003C_003Et__builder;

			[Token(Token = "0x4001E1E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001E1F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask<bool>.Awaiter _003C_003Eu__2;

			[Token(Token = "0x4001E20")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private UniTask<string>.Awaiter _003C_003Eu__3;

			[Token(Token = "0x4001E21")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private UniTask<TeamChatManager>.Awaiter _003C_003Eu__4;

			[Token(Token = "0x600260E")]
			[Address(RVA = "0x3E0FFD4", Offset = "0x3E0FFD4", Length = "0x1088")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetCurrentTeamChatAsync_003Ed__48::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600260F")]
			[Address(RVA = "0x3E1111C", Offset = "0x3E1111C", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetCurrentTeamChatAsync_003Ed__48::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000906")]
		private struct _003CGetHistoryAsync_003Ed__49 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E22")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E23")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<ChatMessage>> _003C_003Et__builder;

			[Token(Token = "0x4001E24")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x4001E25")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public string fromMessageId;

			[Token(Token = "0x4001E26")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public int limit;

			[Token(Token = "0x4001E27")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public CancellationToken cancellationToken;

			[Token(Token = "0x4001E28")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private _003C_003Ec__DisplayClass49_0 _003C_003E8__1;

			[Token(Token = "0x4001E29")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			private EventHandler<HistoryReceivedEventArgs> _003ChistoryHandler_003E5__2;

			[Token(Token = "0x4001E2A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			private UniTask<List<ChatMessage>> _003CjoinRequestsTask_003E5__3;

			[Token(Token = "0x4001E2B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
			private UniTask<AckPayloadWrapper>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001E2C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
			private List<ChatMessage> _003ChistoryResult_003E5__4;

			[Token(Token = "0x4001E2D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
			private UniTask<List<ChatMessage>>.Awaiter _003C_003Eu__2;

			[Token(Token = "0x6002610")]
			[Address(RVA = "0x3E11178", Offset = "0x3E11178", Length = "0x1B08")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetHistoryAsync_003Ed__49::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002611")]
			[Address(RVA = "0x3E12F88", Offset = "0x3E12F88", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetHistoryAsync_003Ed__49::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000907")]
		private struct _003CGetJoinRequestsInParallel_003Ed__50 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E2E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E2F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<List<ChatMessage>> _003C_003Et__builder;

			[Token(Token = "0x4001E30")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x4001E31")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<ElephantSocial.Team.Team>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001E32")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private UniTask<List<TeamMember>>.Awaiter _003C_003Eu__2;

			[Token(Token = "0x6002612")]
			[Address(RVA = "0x3E12FE4", Offset = "0x3E12FE4", Length = "0xADC")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetJoinRequestsInParallel_003Ed__50::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002613")]
			[Address(RVA = "0x3E13AC0", Offset = "0x3E13AC0", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetJoinRequestsInParallel_003Ed__50::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000908")]
		private struct _003CGetTeamChatAsync_003Ed__56 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E33")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E34")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<TeamChatManager> _003C_003Et__builder;

			[Token(Token = "0x4001E35")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private TeamChatManager _003CchatManager_003E5__2;

			[Token(Token = "0x4001E36")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002614")]
			[Address(RVA = "0x3E13B1C", Offset = "0x3E13B1C", Length = "0x574")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetTeamChatAsync_003Ed__56::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002615")]
			[Address(RVA = "0x3E14090", Offset = "0x3E14090", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CGetTeamChatAsync_003Ed__56::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000909")]
		private struct _003CInitializeChannelAsync_003Ed__57 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E37")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E38")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001E39")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x4001E3A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<AckPayloadWrapper>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002616")]
			[Address(RVA = "0x3E140EC", Offset = "0x3E140EC", Length = "0xC48")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CInitializeChannelAsync_003Ed__57::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002617")]
			[Address(RVA = "0x3E14D34", Offset = "0x3E14D34", Length = "0xC")]
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
		[Token(Token = "0x200090A")]
		private struct _003CRefreshJoinRequestsAsync_003Ed__67 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E3B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E3C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001E3D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x4001E3E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private HashSet<string> _003CexistingRequestIds_003E5__2;

			[Token(Token = "0x4001E3F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask<ElephantSocial.Team.Team>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001E40")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			private UniTask<List<TeamMember>>.Awaiter _003C_003Eu__2;

			[Token(Token = "0x6002618")]
			[Address(RVA = "0x3E14D40", Offset = "0x3E14D40", Length = "0x14E4")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CRefreshJoinRequestsAsync_003Ed__67::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002619")]
			[Address(RVA = "0x3E16224", Offset = "0x3E16224", Length = "0xC")]
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
		[Token(Token = "0x200090B")]
		private struct _003CRequestHelpAsync_003Ed__52 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E41")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E42")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001E43")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public int requested;

			[Token(Token = "0x4001E44")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x4001E45")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public CancellationToken cancellationToken;

			[Token(Token = "0x4001E46")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask<AckPayloadWrapper>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600261A")]
			[Address(RVA = "0x3E16230", Offset = "0x3E16230", Length = "0x7AC")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CRequestHelpAsync_003Ed__52::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600261B")]
			[Address(RVA = "0x3E169DC", Offset = "0x3E169DC", Length = "0xC")]
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
		[Token(Token = "0x200090C")]
		private struct _003CSendHelpAsync_003Ed__53 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E47")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E48")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001E49")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string targetMessageId;

			[Token(Token = "0x4001E4A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x4001E4B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public CancellationToken cancellationToken;

			[Token(Token = "0x4001E4C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private _003C_003Ec__DisplayClass53_0 _003C_003E8__1;

			[Token(Token = "0x4001E4D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			private UniTask<AckPayloadWrapper>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600261C")]
			[Address(RVA = "0x3E169E8", Offset = "0x3E169E8", Length = "0x9D0")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CSendHelpAsync_003Ed__53::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600261D")]
			[Address(RVA = "0x3E173B8", Offset = "0x3E173B8", Length = "0xC")]
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
		[Token(Token = "0x200090D")]
		private struct _003CSendTextMessageAsync_003Ed__51 : IAsyncStateMachine
		{
			[Token(Token = "0x4001E4E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001E4F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001E50")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string text;

			[Token(Token = "0x4001E51")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TeamChatManager _003C_003E4__this;

			[Token(Token = "0x4001E52")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public CancellationToken cancellationToken;

			[Token(Token = "0x4001E53")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask<AckPayloadWrapper>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x600261E")]
			[Address(RVA = "0x3E173C4", Offset = "0x3E173C4", Length = "0x7B4")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager._003CSendTextMessageAsync_003Ed__51::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600261F")]
			[Address(RVA = "0x3E17B78", Offset = "0x3E17B78", Length = "0xC")]
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

		[Token(Token = "0x4001DF4")]
		private static string _teamId;

		[Token(Token = "0x4001DF5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private readonly string _socialId;

		[Token(Token = "0x4001DF6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private readonly string _channelId;

		[Token(Token = "0x4001DF7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private readonly string _chatContextKey;

		[Token(Token = "0x4001DF8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private readonly List<ChatMessage> _messages;

		[Token(Token = "0x4001DF9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private readonly HashSet<string> _helpedMessageIds;

		[Token(Token = "0x4001DFA")]
		private static bool _isInitializing;

		[Token(Token = "0x4001DFB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		private bool _isInitialized;

		[Token(Token = "0x4001DFC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x39")]
		private bool _isLoadingHistory;

		[Token(Token = "0x4001DFD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3A")]
		private bool _disposed;

		[Token(Token = "0x4001DFE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3B")]
		private bool _isInitializingChannel;

		[Token(Token = "0x4001DFF")]
		private static TeamChatManager _instance;

		[CompilerGenerated]
		[Token(Token = "0x4001E00")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		private Action<ChatMessage> OnNewMessage;

		[CompilerGenerated]
		[Token(Token = "0x4001E01")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		private Action<ChatMessage> OnMessageUpdate;

		[CompilerGenerated]
		[Token(Token = "0x4001E02")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		private Action<ChatMessage> OnMessageDelete;

		[CompilerGenerated]
		[Token(Token = "0x4001E03")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		private Action<bool> OnChatAvailableStatusChanged;

		[CompilerGenerated]
		[Token(Token = "0x4001E04")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		private Action<string, string> OnError;

		[CompilerGenerated]
		[Token(Token = "0x4001E05")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		private Action<TextMessage> OnTextMessageReceived;

		[CompilerGenerated]
		[Token(Token = "0x4001E06")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		private Action<HelpMessage> OnHelpMessageReceived;

		[CompilerGenerated]
		[Token(Token = "0x4001E07")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
		private Action<RewardMessage> OnRewardMessageReceived;

		[CompilerGenerated]
		[Token(Token = "0x4001E08")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
		private Action<JoinRequestMessage> OnJoinRequestMessageReceived;

		[CompilerGenerated]
		[Token(Token = "0x4001E09")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
		private Action<JoinAcceptMessage> OnJoinAcceptMessageReceived;

		[CompilerGenerated]
		[Token(Token = "0x4001E0A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x90")]
		private Action<JoinRejectMessage> OnJoinRejectMessageReceived;

		[CompilerGenerated]
		[Token(Token = "0x4001E0B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x98")]
		private Action OnPlayerKicked;

		[CompilerGenerated]
		[Token(Token = "0x60025CA")]
		[Address(RVA = "0x3E0A2DC", Offset = "0x3E0A2DC", Length = "0xB4")]
		public void add_OnNewMessage(Action<ChatMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnNewMessage");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025CB")]
		[Address(RVA = "0x3E0A390", Offset = "0x3E0A390", Length = "0xB4")]
		public void remove_OnNewMessage(Action<ChatMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnNewMessage");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025CC")]
		[Address(RVA = "0x3E0A444", Offset = "0x3E0A444", Length = "0xB4")]
		public void add_OnMessageUpdate(Action<ChatMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnMessageUpdate");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025CD")]
		[Address(RVA = "0x3E0A4F8", Offset = "0x3E0A4F8", Length = "0xB4")]
		public void remove_OnMessageUpdate(Action<ChatMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnMessageUpdate");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025CE")]
		[Address(RVA = "0x3E0A5AC", Offset = "0x3E0A5AC", Length = "0xB4")]
		public void add_OnMessageDelete(Action<ChatMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnMessageDelete");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025CF")]
		[Address(RVA = "0x3E0A660", Offset = "0x3E0A660", Length = "0xB4")]
		public void remove_OnMessageDelete(Action<ChatMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnMessageDelete");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D0")]
		[Address(RVA = "0x3E0A714", Offset = "0x3E0A714", Length = "0xB4")]
		public void add_OnChatAvailableStatusChanged(Action<bool> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnChatAvailableStatusChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D1")]
		[Address(RVA = "0x3E0A7C8", Offset = "0x3E0A7C8", Length = "0xB4")]
		public void remove_OnChatAvailableStatusChanged(Action<bool> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnChatAvailableStatusChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D2")]
		[Address(RVA = "0x3E0A87C", Offset = "0x3E0A87C", Length = "0xB4")]
		public void add_OnError(Action<string, string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnError");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D3")]
		[Address(RVA = "0x3E0A930", Offset = "0x3E0A930", Length = "0xB4")]
		public void remove_OnError(Action<string, string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnError");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D4")]
		[Address(RVA = "0x3E0A9E4", Offset = "0x3E0A9E4", Length = "0xB4")]
		public void add_OnTextMessageReceived(Action<TextMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnTextMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D5")]
		[Address(RVA = "0x3E0AA98", Offset = "0x3E0AA98", Length = "0xB4")]
		public void remove_OnTextMessageReceived(Action<TextMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnTextMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D6")]
		[Address(RVA = "0x3E0AB4C", Offset = "0x3E0AB4C", Length = "0xB4")]
		public void add_OnHelpMessageReceived(Action<HelpMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnHelpMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D7")]
		[Address(RVA = "0x3E0AC00", Offset = "0x3E0AC00", Length = "0xB4")]
		public void remove_OnHelpMessageReceived(Action<HelpMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnHelpMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D8")]
		[Address(RVA = "0x3E0ACB4", Offset = "0x3E0ACB4", Length = "0xB4")]
		public void add_OnRewardMessageReceived(Action<RewardMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnRewardMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025D9")]
		[Address(RVA = "0x3E0AD68", Offset = "0x3E0AD68", Length = "0xB4")]
		public void remove_OnRewardMessageReceived(Action<RewardMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnRewardMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025DA")]
		[Address(RVA = "0x3E0AE1C", Offset = "0x3E0AE1C", Length = "0xB4")]
		public void add_OnJoinRequestMessageReceived(Action<JoinRequestMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnJoinRequestMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025DB")]
		[Address(RVA = "0x3E0AED0", Offset = "0x3E0AED0", Length = "0xB4")]
		public void remove_OnJoinRequestMessageReceived(Action<JoinRequestMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnJoinRequestMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025DC")]
		[Address(RVA = "0x3E0AF84", Offset = "0x3E0AF84", Length = "0xB4")]
		public void add_OnJoinAcceptMessageReceived(Action<JoinAcceptMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnJoinAcceptMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025DD")]
		[Address(RVA = "0x3E0B038", Offset = "0x3E0B038", Length = "0xB4")]
		public void remove_OnJoinAcceptMessageReceived(Action<JoinAcceptMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnJoinAcceptMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025DE")]
		[Address(RVA = "0x3E0B0EC", Offset = "0x3E0B0EC", Length = "0xB4")]
		public void add_OnJoinRejectMessageReceived(Action<JoinRejectMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::add_OnJoinRejectMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025DF")]
		[Address(RVA = "0x3E0B1A0", Offset = "0x3E0B1A0", Length = "0xB4")]
		public void remove_OnJoinRejectMessageReceived(Action<JoinRejectMessage> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::remove_OnJoinRejectMessageReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x60025E0")]
		[Address(RVA = "0x3E0B254", Offset = "0x3E0B254", Length = "0xA4")]
		public void add_OnPlayerKicked(Action value)
		{
			Action action = OnPlayerKicked;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnPlayerKicked, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60025E1")]
		[Address(RVA = "0x3E0B2F8", Offset = "0x3E0B2F8", Length = "0xA4")]
		public void remove_OnPlayerKicked(Action value)
		{
			Action action = OnPlayerKicked;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnPlayerKicked, value2, action2);
			}
			while ((object)action != action2);
		}

		[AsyncStateMachine(typeof(_003CGetCurrentTeamChatAsync_003Ed__48))]
		[Token(Token = "0x60025E2")]
		[Address(RVA = "0x3E0B39C", Offset = "0x3E0B39C", Length = "0xD0")]
		public static UniTask<TeamChatManager> GetCurrentTeamChatAsync()
		{
			_003CGetCurrentTeamChatAsync_003Ed__48 _003CGetCurrentTeamChatAsync_003Ed__49 = default(_003CGetCurrentTeamChatAsync_003Ed__48);
			_003CGetCurrentTeamChatAsync_003Ed__49._003C_003E1__state = -1;
			_003CGetCurrentTeamChatAsync_003Ed__49.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamChatManager> result = default(UniTask<TeamChatManager>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetHistoryAsync_003Ed__49))]
		[Token(Token = "0x60025E3")]
		[Address(RVA = "0x3E0B46C", Offset = "0x3E0B46C", Length = "0x128")]
		public UniTask<List<ChatMessage>> GetHistoryAsync(int limit = 100, string fromMessageId = "", CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CGetHistoryAsync_003Ed__49 _003CGetHistoryAsync_003Ed__50 = default(_003CGetHistoryAsync_003Ed__49);
			_003CGetHistoryAsync_003Ed__50._003C_003E4__this = this;
			_003CGetHistoryAsync_003Ed__50.limit = limit;
			_003CGetHistoryAsync_003Ed__50.fromMessageId = fromMessageId;
			_003CGetHistoryAsync_003Ed__50.cancellationToken = cancellationToken;
			_003CGetHistoryAsync_003Ed__50._003C_003E1__state = -1;
			_003CGetHistoryAsync_003Ed__50.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<ChatMessage>> result = default(UniTask<List<ChatMessage>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CGetJoinRequestsInParallel_003Ed__50))]
		[Token(Token = "0x60025E4")]
		[Address(RVA = "0x3E0B594", Offset = "0x3E0B594", Length = "0xEC")]
		private UniTask<List<ChatMessage>> GetJoinRequestsInParallel()
		{
			_003CGetJoinRequestsInParallel_003Ed__50 _003CGetJoinRequestsInParallel_003Ed__51 = default(_003CGetJoinRequestsInParallel_003Ed__50);
			_003CGetJoinRequestsInParallel_003Ed__51._003C_003E4__this = this;
			_003CGetJoinRequestsInParallel_003Ed__51._003C_003E1__state = -1;
			_003CGetJoinRequestsInParallel_003Ed__51.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<List<ChatMessage>> result = default(UniTask<List<ChatMessage>>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CSendTextMessageAsync_003Ed__51))]
		[Token(Token = "0x60025E5")]
		[Address(RVA = "0x3E0B680", Offset = "0x3E0B680", Length = "0xE0")]
		public UniTask SendTextMessageAsync(string text, CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CSendTextMessageAsync_003Ed__51 _003CSendTextMessageAsync_003Ed__52 = default(_003CSendTextMessageAsync_003Ed__51);
			_003CSendTextMessageAsync_003Ed__52._003C_003E4__this = this;
			_003CSendTextMessageAsync_003Ed__52.text = text;
			_003CSendTextMessageAsync_003Ed__52.cancellationToken = cancellationToken;
			_003CSendTextMessageAsync_003Ed__52._003C_003E1__state = -1;
			_003CSendTextMessageAsync_003Ed__52.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CRequestHelpAsync_003Ed__52))]
		[Token(Token = "0x60025E6")]
		[Address(RVA = "0x3E0B760", Offset = "0x3E0B760", Length = "0xD4")]
		public UniTask RequestHelpAsync(int requested, CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CRequestHelpAsync_003Ed__52 _003CRequestHelpAsync_003Ed__53 = default(_003CRequestHelpAsync_003Ed__52);
			_003CRequestHelpAsync_003Ed__53._003C_003E4__this = this;
			_003CRequestHelpAsync_003Ed__53.requested = requested;
			_003CRequestHelpAsync_003Ed__53.cancellationToken = cancellationToken;
			_003CRequestHelpAsync_003Ed__53._003C_003E1__state = -1;
			_003CRequestHelpAsync_003Ed__53.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CSendHelpAsync_003Ed__53))]
		[Token(Token = "0x60025E7")]
		[Address(RVA = "0x3E0B834", Offset = "0x3E0B834", Length = "0xE0")]
		public UniTask SendHelpAsync(string targetMessageId, CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CSendHelpAsync_003Ed__53 _003CSendHelpAsync_003Ed__54 = default(_003CSendHelpAsync_003Ed__53);
			_003CSendHelpAsync_003Ed__54._003C_003E4__this = this;
			_003CSendHelpAsync_003Ed__54.targetMessageId = targetMessageId;
			_003CSendHelpAsync_003Ed__54.cancellationToken = cancellationToken;
			_003CSendHelpAsync_003Ed__54._003C_003E1__state = -1;
			_003CSendHelpAsync_003Ed__54.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[Token(Token = "0x60025E8")]
		[Address(RVA = "0x3E0B914", Offset = "0x3E0B914", Length = "0x810")]
		private TeamChatManager()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::.ctor");
		}

		[Token(Token = "0x60025E9")]
		[Address(RVA = "0x3E0C630", Offset = "0x3E0C630", Length = "0x794")]
		~TeamChatManager()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::Finalize");
		}

		[AsyncStateMachine(typeof(_003CGetTeamChatAsync_003Ed__56))]
		[Token(Token = "0x60025EA")]
		[Address(RVA = "0x3E0D2D0", Offset = "0x3E0D2D0", Length = "0xCC")]
		private static UniTask<TeamChatManager> GetTeamChatAsync()
		{
			_003CGetTeamChatAsync_003Ed__56 _003CGetTeamChatAsync_003Ed__57 = default(_003CGetTeamChatAsync_003Ed__56);
			_003CGetTeamChatAsync_003Ed__57._003C_003E1__state = -1;
			_003CGetTeamChatAsync_003Ed__57.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<TeamChatManager> result = default(UniTask<TeamChatManager>);
			return result;
		}

		[AsyncStateMachine(typeof(_003CInitializeChannelAsync_003Ed__57))]
		[Token(Token = "0x60025EB")]
		[Address(RVA = "0x3E0D39C", Offset = "0x3E0D39C", Length = "0xB0")]
		private UniTask InitializeChannelAsync()
		{
			_003CInitializeChannelAsync_003Ed__57 _003CInitializeChannelAsync_003Ed__58 = default(_003CInitializeChannelAsync_003Ed__57);
			_003CInitializeChannelAsync_003Ed__58._003C_003E4__this = this;
			_003CInitializeChannelAsync_003Ed__58._003C_003E1__state = -1;
			_003CInitializeChannelAsync_003Ed__58.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[Token(Token = "0x60025EC")]
		[Address(RVA = "0x3E0D44C", Offset = "0x3E0D44C", Length = "0x1BC")]
		private void HandleElephantChatConnectionStatus(bool isConnected)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::HandleElephantChatConnectionStatus");
		}

		[Token(Token = "0x60025ED")]
		[Address(RVA = "0x3E0D608", Offset = "0x3E0D608", Length = "0x64")]
		private void HandleConnectionStatusChanged(object sender, ConnectionStatusEventArgs args)
		{
			if (_disposed)
			{
				return;
			}
			if (args.IsConnected)
			{
				if (OnChatAvailableStatusChanged != null)
				{
					OnChatAvailableStatusChanged(_isInitialized);
				}
				return;
			}
			_isInitialized = false;
			if (OnChatAvailableStatusChanged != null)
			{
				OnChatAvailableStatusChanged(obj: false);
			}
		}

		[Token(Token = "0x60025EE")]
		[Address(RVA = "0x3E0D66C", Offset = "0x3E0D66C", Length = "0x3C")]
		private void HandleChatClientError(object sender, ErrorEventArgs args)
		{
			if (!_disposed && OnError != null)
			{
				OnError(args.Title, args.Message);
			}
		}

		[Token(Token = "0x60025EF")]
		[Address(RVA = "0x3E0D6A8", Offset = "0x3E0D6A8", Length = "0xA8")]
		private void HandleRequestDenied(object sender, RequestDeniedEventArgs args)
		{
			if (!_disposed && !(args.ChannelId != _channelId) && OnError != null)
			{
				DeniedPayload denialInfo = args.DenialInfo;
				OnError("Request Denied", denialInfo.Reason);
			}
		}

		[Token(Token = "0x60025F0")]
		[Address(RVA = "0x3E0D750", Offset = "0x3E0D750", Length = "0x684")]
		private unsafe void HandleMessageCreated(object sender, MessageCreatedEventArgs args)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::HandleMessageCreated");
		}

		[Token(Token = "0x60025F1")]
		[Address(RVA = "0x3E0E7A8", Offset = "0x3E0E7A8", Length = "0x63C")]
		private void HandleMessageUpdated(object sender, MessageUpdatedEventArgs args)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::HandleMessageUpdated");
		}

		[Token(Token = "0x60025F2")]
		[Address(RVA = "0x3E0EDEC", Offset = "0x3E0EDEC", Length = "0x300")]
		private void HandleMessageDeleted(object sender, MessageDeletedEventArgs args)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::HandleMessageDeleted");
		}

		[Token(Token = "0x60025F3")]
		[Address(RVA = "0x3E0DE88", Offset = "0x3E0DE88", Length = "0x920")]
		private ChatMessage ConvertPayloadToChatMessage(MessageContentPayload payload)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::ConvertPayloadToChatMessage");
			return default;
		}

		[Token(Token = "0x60025F4")]
		[Address(RVA = "0x3E0DDDC", Offset = "0x3E0DDDC", Length = "0xAC")]
		private unsafe void RefreshJoinRequests()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamChatManager::RefreshJoinRequests");
		}

		[AsyncStateMachine(typeof(_003CRefreshJoinRequestsAsync_003Ed__67))]
		[Token(Token = "0x60025F5")]
		[Address(RVA = "0x3E0F318", Offset = "0x3E0F318", Length = "0xA0")]
		private UniTaskVoid RefreshJoinRequestsAsync()
		{
			_003CRefreshJoinRequestsAsync_003Ed__67 stateMachine = default(_003CRefreshJoinRequestsAsync_003Ed__67);
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return default(UniTaskVoid);
		}
	}
}
