using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Chat.Interface;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;

namespace ElephantSocial.Chat.Core
{
	[Token(Token = "0x200093B")]
	public class UnityWebSocketClient : IWebSocketClient, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200093C")]
		private struct _003CCloseAsync_003Ed__25 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F2A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F2B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001F2C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public UnityWebSocketClient _003C_003E4__this;

			[Token(Token = "0x4001F2D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x6002777")]
			[Address(RVA = "0x3E3ED04", Offset = "0x3E3ED04", Length = "0x874")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient._003CCloseAsync_003Ed__25::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002778")]
			[Address(RVA = "0x3E3F578", Offset = "0x3E3F578", Length = "0xC")]
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
		[Token(Token = "0x200093D")]
		private struct _003CConnectAsync_003Ed__21 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F2E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F2F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001F30")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string url;

			[Token(Token = "0x4001F31")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public UnityWebSocketClient _003C_003E4__this;

			[Token(Token = "0x4001F32")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public Dictionary<string, string> headers;

			[Token(Token = "0x4001F33")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x6002779")]
			[Address(RVA = "0x3E3F584", Offset = "0x3E3F584", Length = "0xAE8")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient._003CConnectAsync_003Ed__21::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600277A")]
			[Address(RVA = "0x3E4006C", Offset = "0x3E4006C", Length = "0xC")]
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
		[Token(Token = "0x200093E")]
		private struct _003CHandleCloseAsync_003Ed__23 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F34")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F35")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001F36")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public UnityWebSocketClient _003C_003E4__this;

			[Token(Token = "0x4001F37")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string reason;

			[Token(Token = "0x4001F38")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x600277B")]
			[Address(RVA = "0x3E40078", Offset = "0x3E40078", Length = "0x668")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient._003CHandleCloseAsync_003Ed__23::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600277C")]
			[Address(RVA = "0x3E406E0", Offset = "0x3E406E0", Length = "0xC")]
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
		[Token(Token = "0x200093F")]
		private struct _003CReceiveLoopAsync_003Ed__22 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F39")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F3A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001F3B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public UnityWebSocketClient _003C_003E4__this;

			[Token(Token = "0x4001F3C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public CancellationToken cancellationToken;

			[Token(Token = "0x4001F3D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private byte[] _003Cbuffer_003E5__2;

			[Token(Token = "0x4001F3E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private object _003C_003E7__wrap2;

			[Token(Token = "0x4001F3F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			private int _003C_003E7__wrap3;

			[Token(Token = "0x4001F40")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private WebSocketReceiveResult _003Cresult_003E5__5;

			[Token(Token = "0x4001F41")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			private object _003C_003E7__wrap5;

			[Token(Token = "0x4001F42")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			private int _003C_003E7__wrap6;

			[Token(Token = "0x4001F43")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private TaskAwaiter<WebSocketReceiveResult> _003C_003Eu__1;

			[Token(Token = "0x4001F44")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			private UniTask.Awaiter _003C_003Eu__2;

			[Token(Token = "0x600277D")]
			[Address(RVA = "0x3E406EC", Offset = "0x3E406EC", Length = "0x15D4")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient._003CReceiveLoopAsync_003Ed__22::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600277E")]
			[Address(RVA = "0x3E41CC0", Offset = "0x3E41CC0", Length = "0xC")]
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
		[Token(Token = "0x2000940")]
		private struct _003CSendTextAsync_003Ed__24 : IAsyncStateMachine
		{
			[Token(Token = "0x4001F45")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001F46")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001F47")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public UnityWebSocketClient _003C_003E4__this;

			[Token(Token = "0x4001F48")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string data;

			[Token(Token = "0x4001F49")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x600277F")]
			[Address(RVA = "0x3E41CCC", Offset = "0x3E41CCC", Length = "0x5C4")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient._003CSendTextAsync_003Ed__24::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002780")]
			[Address(RVA = "0x3E42290", Offset = "0x3E42290", Length = "0xC")]
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

		[Token(Token = "0x4001F20")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private ClientWebSocket _webSocket;

		[Token(Token = "0x4001F21")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private ElephantSocial.Chat.Interface.WebSocketState _state;

		[Token(Token = "0x4001F22")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private readonly object _stateLock;

		[Token(Token = "0x4001F23")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private CancellationTokenSource _receiveCts;

		[Token(Token = "0x4001F24")]
		private const int ReceiveBufferSize = 8192;

		[Token(Token = "0x4001F25")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private List<byte> _messageBuffer;

		[CompilerGenerated]
		[Token(Token = "0x4001F26")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		private Action _003COnOpen_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4001F27")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		private Action<string> _003COnClose_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4001F28")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		private Action<string> m_OnError;

		[CompilerGenerated]
		[Token(Token = "0x4001F29")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		private Action<byte[]> _003COnMessage_003Ek__BackingField;

		[Token(Token = "0x1700045B")]
		public unsafe ElephantSocial.Chat.Interface.WebSocketState State
		{
			[Token(Token = "0x600276F")]
			[Address(RVA = "0x3E3E454", Offset = "0x3E3E454", Length = "0xDC")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient::get_State");
				return default;
			}
		}

		[Token(Token = "0x14000057")]
		public event Action OnOpen
		{
			[CompilerGenerated]
			[Token(Token = "0x6002767")]
			[Address(RVA = "0x3E3DED4", Offset = "0x3E3DED4", Length = "0xA4")]
			add
			{
				Action action = _003COnOpen_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnOpen_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x6002768")]
			[Address(RVA = "0x3E3DF78", Offset = "0x3E3DF78", Length = "0xA4")]
			remove
			{
				Action action = _003COnOpen_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnOpen_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x14000058")]
		public event Action<string> OnClose
		{
			[CompilerGenerated]
			[Token(Token = "0x6002769")]
			[Address(RVA = "0x3E3E01C", Offset = "0x3E3E01C", Length = "0xB4")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient::add_OnClose");
			}
			[CompilerGenerated]
			[Token(Token = "0x600276A")]
			[Address(RVA = "0x3E3E0D0", Offset = "0x3E3E0D0", Length = "0xB4")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient::remove_OnClose");
			}
		}

		[Token(Token = "0x14000059")]
		public event Action<string> OnError
		{
			[CompilerGenerated]
			[Token(Token = "0x600276B")]
			[Address(RVA = "0x3E3E184", Offset = "0x3E3E184", Length = "0xB4")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient::add_OnError");
			}
			[CompilerGenerated]
			[Token(Token = "0x600276C")]
			[Address(RVA = "0x3E3E238", Offset = "0x3E3E238", Length = "0xB4")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient::remove_OnError");
			}
		}

		[Token(Token = "0x1400005A")]
		public event Action<byte[]> OnMessage
		{
			[CompilerGenerated]
			[Token(Token = "0x600276D")]
			[Address(RVA = "0x3E3E2EC", Offset = "0x3E3E2EC", Length = "0xB4")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient::add_OnMessage");
			}
			[CompilerGenerated]
			[Token(Token = "0x600276E")]
			[Address(RVA = "0x3E3E3A0", Offset = "0x3E3E3A0", Length = "0xB4")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UnityWebSocketClient::remove_OnMessage");
			}
		}

		[Token(Token = "0x6002770")]
		[Address(RVA = "0x3E3E530", Offset = "0x3E3E530", Length = "0x1A4")]
		public UnityWebSocketClient()
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicExchange", "Method not found @21C10E0");
			_state = ElephantSocial.Chat.Interface.WebSocketState.Closed;
			object stateLock = new object();
			_stateLock = stateLock;
			_messageBuffer = new List<byte>();
			ClientWebSocket webSocket = new ClientWebSocket();
			_webSocket = webSocket;
			CancellationTokenSource receiveCts = new CancellationTokenSource();
			_receiveCts = receiveCts;
			ClientWebSocket webSocket2 = _webSocket;
			webSocket2.Options.KeepAliveInterval = TimeSpan.Zero;
		}

		[AsyncStateMachine(typeof(_003CConnectAsync_003Ed__21))]
		[Token(Token = "0x6002771")]
		[Address(RVA = "0x3E3E6D4", Offset = "0x3E3E6D4", Length = "0xE0")]
		public UniTask ConnectAsync(string url, Dictionary<string, string> headers = null)
		{
			_003CConnectAsync_003Ed__21 _003CConnectAsync_003Ed__22 = default(_003CConnectAsync_003Ed__21);
			_003CConnectAsync_003Ed__22._003C_003E4__this = this;
			_003CConnectAsync_003Ed__22.url = url;
			_003CConnectAsync_003Ed__22.headers = headers;
			_003CConnectAsync_003Ed__22._003C_003E1__state = -1;
			_003CConnectAsync_003Ed__22.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CReceiveLoopAsync_003Ed__22))]
		[Token(Token = "0x6002772")]
		[Address(RVA = "0x3E3E7B4", Offset = "0x3E3E7B4", Length = "0xC8")]
		private UniTask ReceiveLoopAsync(CancellationToken cancellationToken)
		{
			_003CReceiveLoopAsync_003Ed__22 _003CReceiveLoopAsync_003Ed__23 = default(_003CReceiveLoopAsync_003Ed__22);
			_003CReceiveLoopAsync_003Ed__23._003C_003E4__this = this;
			_003CReceiveLoopAsync_003Ed__23.cancellationToken = cancellationToken;
			_003CReceiveLoopAsync_003Ed__23._003C_003E1__state = -1;
			_003CReceiveLoopAsync_003Ed__23.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CHandleCloseAsync_003Ed__23))]
		[Token(Token = "0x6002773")]
		[Address(RVA = "0x3E3E87C", Offset = "0x3E3E87C", Length = "0xC0")]
		private UniTask HandleCloseAsync(string reason)
		{
			_003CHandleCloseAsync_003Ed__23 _003CHandleCloseAsync_003Ed__24 = default(_003CHandleCloseAsync_003Ed__23);
			_003CHandleCloseAsync_003Ed__24._003C_003E4__this = this;
			_003CHandleCloseAsync_003Ed__24.reason = reason;
			_003CHandleCloseAsync_003Ed__24._003C_003E1__state = -1;
			_003CHandleCloseAsync_003Ed__24.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CSendTextAsync_003Ed__24))]
		[Token(Token = "0x6002774")]
		[Address(RVA = "0x3E3E93C", Offset = "0x3E3E93C", Length = "0xC0")]
		public UniTask SendTextAsync(string data)
		{
			_003CSendTextAsync_003Ed__24 _003CSendTextAsync_003Ed__25 = default(_003CSendTextAsync_003Ed__24);
			_003CSendTextAsync_003Ed__25._003C_003E4__this = this;
			_003CSendTextAsync_003Ed__25.data = data;
			_003CSendTextAsync_003Ed__25._003C_003E1__state = -1;
			_003CSendTextAsync_003Ed__25.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CCloseAsync_003Ed__25))]
		[Token(Token = "0x6002775")]
		[Address(RVA = "0x3E3E9FC", Offset = "0x3E3E9FC", Length = "0xAC")]
		public UniTask CloseAsync()
		{
			_003CCloseAsync_003Ed__25 _003CCloseAsync_003Ed__26 = default(_003CCloseAsync_003Ed__25);
			_003CCloseAsync_003Ed__26._003C_003E4__this = this;
			_003CCloseAsync_003Ed__26._003C_003E1__state = -1;
			_003CCloseAsync_003Ed__26.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[Token(Token = "0x6002776")]
		[Address(RVA = "0x3E3EAA8", Offset = "0x3E3EAA8", Length = "0x25C")]
		public void Dispose()
		{
			ElephantLog.Log("UnityWebSocketClient", "Dispose called");
			if (_receiveCts != null)
			{
				_receiveCts.Cancel();
				if (_receiveCts == null)
				{
					NullReferenceException ex = new NullReferenceException();
					throw ex;
				}
				_receiveCts.Dispose();
				_receiveCts = null;
			}
			if (_webSocket != null)
			{
				((IDisposable)_webSocket).Dispose();
				_webSocket = null;
			}
			GC.SuppressFinalize(this);
		}
	}
}
