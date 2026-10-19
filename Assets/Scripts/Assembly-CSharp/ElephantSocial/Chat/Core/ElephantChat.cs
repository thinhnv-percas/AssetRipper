using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Chat.Interface;
using ElephantSocial.Chat.Model;
using ElephantSocial.Chat.Util;
using ElephantSocial.Core;
using ElephantSocial.Model;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Chat.Core
{
	[Token(Token = "0x2000935")]
	public static class ElephantChat
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000936")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001F0B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001F0C")]
			public static Action<string> _003C_003E9__24_0;

			[Token(Token = "0x600275C")]
			[Address(RVA = "0x3E1FBA4", Offset = "0x3E1FBA4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600275D")]
			[Address(RVA = "0x3E1FC08", Offset = "0x3E1FC08", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CInitializeWebSocket_003Eb__24_0(string errorMsg)
			{
				string text = default(string);
				string message = "Native WebSocket error: " + text;
				ElephantLog.LogError("ElephantChat", message);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000937")]
		private sealed class _003C_003Ec__DisplayClass25_0
		{
			[Token(Token = "0x4001F0D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public EventHandler<ConnectionStatusEventArgs> connectionHandler;

			[Token(Token = "0x4001F0E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public UniTaskCompletionSource<bool> connectionTcs;

			[Token(Token = "0x600275F")]
			[Address(RVA = "0x3E1FC90", Offset = "0x3E1FC90", Length = "0x8")]
			public _003C_003Ec__DisplayClass25_0()
			{
			}

			internal void _003CConnectInternalAsync_003Eb__0(object sender, ConnectionStatusEventArgs args)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat._003C_003Ec__DisplayClass25_0::_003CConnectInternalAsync_003Eb__0");
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000938")]
		private struct _003CConnectAsync_003Ed__23 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F0F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F10")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x4001F11")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private bool _003CconnectedSuccessfully_003E5__2;

			[Token(Token = "0x4001F12")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private CancellationTokenSource _003CconnectTimeoutCts_003E5__3;

			[Token(Token = "0x4001F13")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002761")]
			[Address(RVA = "0x3E1FDDC", Offset = "0x3E1FDDC", Length = "0xFAC")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat._003CConnectAsync_003Ed__23::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002762")]
			[Address(RVA = "0x3E20D88", Offset = "0x3E20D88", Length = "0x5C")]
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
		[Token(Token = "0x2000939")]
		private struct _003CConnectInternalAsync_003Ed__25 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F14")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F15")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001F16")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string url;

			[Token(Token = "0x4001F17")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string authToken;

			[Token(Token = "0x4001F18")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private _003C_003Ec__DisplayClass25_0 _003C_003E8__1;

			[Token(Token = "0x4001F19")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001F1A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private UniTask<bool>.Awaiter _003C_003Eu__2;

			[Token(Token = "0x6002763")]
			[Address(RVA = "0x3E20DE4", Offset = "0x3E20DE4", Length = "0xB0C")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat._003CConnectInternalAsync_003Ed__25::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002764")]
			[Address(RVA = "0x3E218F0", Offset = "0x3E218F0", Length = "0xC")]
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
		[Token(Token = "0x200093A")]
		private struct _003CStartReconnectionLoopAsync_003Ed__29 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F1B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F1C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001F1D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			private CancellationToken _003Ctoken_003E5__2;

			[Token(Token = "0x4001F1E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001F1F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<bool>.Awaiter _003C_003Eu__2;

			[Token(Token = "0x6002765")]
			[Address(RVA = "0x3E218FC", Offset = "0x3E218FC", Length = "0xEF8")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat._003CStartReconnectionLoopAsync_003Ed__29::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002766")]
			[Address(RVA = "0x3E227F4", Offset = "0x3E227F4", Length = "0x229C")]
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

		[Token(Token = "0x4001EFE")]
		internal static ChatClient _chatClientInstance;

		[Token(Token = "0x4001EFF")]
		private static IWebSocketClient _nativeClientInstance;

		[Token(Token = "0x4001F00")]
		internal static bool _isInitialized;

		[Token(Token = "0x4001F01")]
		private static bool _isConnecting;

		[Token(Token = "0x4001F02")]
		private static CancellationTokenSource _connectionCts;

		[CompilerGenerated]
		[Token(Token = "0x4001F03")]
		private static Action<bool> OnConnectionStatusChanged;

		[Token(Token = "0x4001F04")]
		private static bool _isAttemptingReconnection;

		[Token(Token = "0x4001F05")]
		private static int _reconnectionAttempts;

		[Token(Token = "0x4001F06")]
		private const int MaxReconnectionAttempts = 5;

		[Token(Token = "0x4001F07")]
		private const int ReconnectionBaseDelayMs = 2000;

		[Token(Token = "0x4001F08")]
		private const int ReconnectionMaxDelayMs = 30000;

		[Token(Token = "0x4001F09")]
		private static CancellationTokenSource _reconnectionCts;

		[Token(Token = "0x4001F0A")]
		private static bool _explicitDisconnect;

		[Token(Token = "0x17000457")]
		public static ChatClient Client
		{
			[Token(Token = "0x600274D")]
			[Address(RVA = "0x3E1E8E4", Offset = "0x3E1E8E4", Length = "0x4C")]
			get
			{
				return _chatClientInstance;
			}
		}

		[Token(Token = "0x17000458")]
		public static WebSocketState ConnectionState
		{
			[Token(Token = "0x600274E")]
			[Address(RVA = "0x3E12C80", Offset = "0x3E12C80", Length = "0xFC")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::get_ConnectionState");
				return default;
			}
		}

		[Token(Token = "0x17000459")]
		public static bool IsInitialized
		{
			[Token(Token = "0x600274F")]
			[Address(RVA = "0x3E1E930", Offset = "0x3E1E930", Length = "0x4C")]
			get
			{
				return _isInitialized;
			}
		}

		[Token(Token = "0x1700045A")]
		public static bool IsAttemptingReconnection
		{
			[Token(Token = "0x6002752")]
			[Address(RVA = "0x3E1E97C", Offset = "0x3E1E97C", Length = "0x4C")]
			get
			{
				return _isAttemptingReconnection;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6002750")]
		[Address(RVA = "0x3E0C55C", Offset = "0x3E0C55C", Length = "0xD4")]
		public static void add_OnConnectionStatusChanged(Action<bool> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::add_OnConnectionStatusChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002751")]
		[Address(RVA = "0x3E0D1FC", Offset = "0x3E0D1FC", Length = "0xD4")]
		public static void remove_OnConnectionStatusChanged(Action<bool> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::remove_OnConnectionStatusChanged");
		}

		[AsyncStateMachine(typeof(_003CConnectAsync_003Ed__23))]
		[Token(Token = "0x6002753")]
		[Address(RVA = "0x3E1105C", Offset = "0x3E1105C", Length = "0xC0")]
		public static UniTask<bool> ConnectAsync()
		{
			_003CConnectAsync_003Ed__23 _003CConnectAsync_003Ed__24 = default(_003CConnectAsync_003Ed__23);
			_003CConnectAsync_003Ed__24._003C_003E1__state = -1;
			_003CConnectAsync_003Ed__24.MoveNext();
			return _003CConnectAsync_003Ed__24._003C_003Et__builder.Task;
		}

		[Token(Token = "0x6002754")]
		[Address(RVA = "0x3E1E9C8", Offset = "0x3E1E9C8", Length = "0x604")]
		private static void InitializeWebSocket()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::InitializeWebSocket");
		}

		[AsyncStateMachine(typeof(_003CConnectInternalAsync_003Ed__25))]
		[Token(Token = "0x6002755")]
		[Address(RVA = "0x3E1F294", Offset = "0x3E1F294", Length = "0xC4")]
		private static UniTask ConnectInternalAsync(string url, string authToken)
		{
			_003CConnectInternalAsync_003Ed__25 _003CConnectInternalAsync_003Ed__26 = default(_003CConnectInternalAsync_003Ed__25);
			_003CConnectInternalAsync_003Ed__26.url = url;
			_003CConnectInternalAsync_003Ed__26.authToken = authToken;
			_003CConnectInternalAsync_003Ed__26._003C_003E1__state = -1;
			_003CConnectInternalAsync_003Ed__26.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[Token(Token = "0x6002756")]
		[Address(RVA = "0x3E1F358", Offset = "0x3E1F358", Length = "0xD0")]
		private static void HandleChatClientError(object sender, ErrorEventArgs args)
		{
			WebSocketState connectionState = ConnectionState;
			WebSocketState webSocketState = connectionState;
			object arg = webSocketState;
			string message = $"ChatClient Error: {args.Title} - {args.Message}. Current State: {arg}";
			ElephantLog.LogError("ElephantChat", message);
		}

		[Token(Token = "0x6002757")]
		[Address(RVA = "0x3E1F428", Offset = "0x3E1F428", Length = "0x4F8")]
		private unsafe static void HandleChatClientConnectionStatusChanged(object sender, ConnectionStatusEventArgs args)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::HandleChatClientConnectionStatusChanged");
		}

		[Token(Token = "0x6002758")]
		[Address(RVA = "0x3E1F920", Offset = "0x3E1F920", Length = "0x90")]
		private unsafe static void StartReconnectionLoop()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::StartReconnectionLoop");
		}

		[AsyncStateMachine(typeof(_003CStartReconnectionLoopAsync_003Ed__29))]
		[Token(Token = "0x6002759")]
		[Address(RVA = "0x3E1F9B0", Offset = "0x3E1F9B0", Length = "0x84")]
		private static UniTaskVoid StartReconnectionLoopAsync()
		{
			_003CStartReconnectionLoopAsync_003Ed__29 stateMachine = default(_003CStartReconnectionLoopAsync_003Ed__29);
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return default(UniTaskVoid);
		}

		[Token(Token = "0x600275A")]
		[Address(RVA = "0x3E1EFCC", Offset = "0x3E1EFCC", Length = "0x2C8")]
		private static void CleanupResources()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::CleanupResources");
		}

		[Token(Token = "0x600275B")]
		[Address(RVA = "0x3E1FA34", Offset = "0x3E1FA34", Length = "0x170")]
		private static string GetChatUrl()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantChat::GetChatUrl");
			return default;
		}
	}
}
