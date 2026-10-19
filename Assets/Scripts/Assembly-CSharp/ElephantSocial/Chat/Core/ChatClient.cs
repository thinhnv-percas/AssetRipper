using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Chat.Interface;
using ElephantSocial.Chat.Model;
using ElephantUniTask.Threading.Tasks;
using ElephantUniTask.Threading.Tasks.CompilerServices;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Core
{
	[Token(Token = "0x200092E")]
	public sealed class ChatClient : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200092F")]
		private struct _003C_003CDispose_003Eb__46_0_003Ed : IAsyncStateMachine
		{
			[Token(Token = "0x4001ED9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001EDA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001EDB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public ChatClient _003C_003E4__this;

			[Token(Token = "0x4001EDC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002741")]
			[Address(RVA = "0x3E1ABDC", Offset = "0x3E1ABDC", Length = "0x424")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChatClient._003C_003CDispose_003Eb__46_0_003Ed::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002742")]
			[Address(RVA = "0x3E1B000", Offset = "0x3E1B000", Length = "0xC")]
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

		[CompilerGenerated]
		[Token(Token = "0x2000930")]
		private sealed class _003C_003Ec__DisplayClass34_0
		{
			[Token(Token = "0x4001EDD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string sourceEventId;

			[Token(Token = "0x4001EDE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string channelId;

			[Token(Token = "0x4001EDF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public UniTaskCompletionSource<AckPayloadWrapper> ackTcs;

			[Token(Token = "0x6002743")]
			[Address(RVA = "0x3E1B00C", Offset = "0x3E1B00C", Length = "0x8")]
			public _003C_003Ec__DisplayClass34_0()
			{
			}

			internal void _003CSendMessageAsync_003Eb__0(object sender, MessageAcknowledgedEventArgs args)
			{
				//IL_00c0: Expected O, but got I4
				//IL_01ab: Expected O, but got I4
				//IL_021f: Expected O, but got I4
				string[] array = new string[6];
				string text;
				NullReferenceException ex4 = default(NullReferenceException);
				if (array != null)
				{
					if (array.Length != 0)
					{
						array[0] = "Received ack for channel ";
						if (args != null)
						{
							if ((array.Length & -2) != 0)
							{
								array[1] = args.ChannelId;
								bool flag = (uint)array.Length < 2u;
								bool flag2 = !flag;
								object obj = array.Length - 2;
								bool flag3 = obj == null;
								bool flag4 = !flag2;
								if (!(flag4 || flag3))
								{
									array[2] = ", client message ID: ";
									AckPayloadWrapper ackInfo = args.AckInfo;
									if (args.AckInfo != null)
									{
										text = ackInfo.SourceEventId;
										if ((array.Length & -4) != 0)
										{
											goto IL_016d;
										}
									}
									else
									{
										int num = array.Length & -4;
										bool flag5 = num == 0;
										bool flag6 = !flag5;
										text = null;
										if (flag6)
										{
											goto IL_016d;
										}
									}
									IndexOutOfRangeException ex = new IndexOutOfRangeException();
								}
								else
								{
									IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
								}
							}
							else
							{
								IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
							}
						}
						else
						{
							ex4 = new NullReferenceException();
						}
					}
					else
					{
						IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
					}
				}
				else
				{
					ex4 = new NullReferenceException();
				}
				goto IL_0443;
				IL_016d:
				array[3] = text;
				bool flag7 = (uint)array.Length < 4u;
				bool flag8 = !flag7;
				object obj2 = array.Length - 4;
				bool flag9 = obj2 == null;
				bool flag10 = !flag8;
				if (!(flag10 || flag9))
				{
					array[4] = ", message ID: ";
					bool flag11 = (uint)array.Length < 5u;
					bool flag12 = !flag11;
					object obj3 = array.Length - 5;
					bool flag13 = obj3 == null;
					bool flag14 = !flag12;
					if (!(flag14 || flag13))
					{
						array[5] = sourceEventId;
						string message = string.Concat(array);
						ElephantLog.Log("ChatClient", message);
						if (!(args.ChannelId == channelId))
						{
							return;
						}
						AckPayloadWrapper ackInfo2 = args.AckInfo;
						if (args.AckInfo == null || !(ackInfo2.SourceEventId == sourceEventId))
						{
							return;
						}
						if (ackTcs != null)
						{
							bool flag15 = ackTcs.TrySetResult(args.AckInfo);
							return;
						}
						ex4 = new NullReferenceException();
					}
					else
					{
						IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
					}
				}
				else
				{
					IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
				}
				goto IL_0443;
				IL_0443:
				throw ex4;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000931")]
		private struct _003CConnectAsync_003Ed__32 : IAsyncStateMachine
		{
			[Token(Token = "0x4001EE0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001EE1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001EE2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string url;

			[Token(Token = "0x4001EE3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string authToken;

			[Token(Token = "0x4001EE4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public ChatClient _003C_003E4__this;

			[Token(Token = "0x4001EE5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002745")]
			[Address(RVA = "0x3E1B34C", Offset = "0x3E1B34C", Length = "0x810")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChatClient._003CConnectAsync_003Ed__32::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002746")]
			[Address(RVA = "0x3E1BB5C", Offset = "0x3E1BB5C", Length = "0xC")]
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
		[Token(Token = "0x2000932")]
		private struct _003CDisconnectAsync_003Ed__33 : IAsyncStateMachine
		{
			[Token(Token = "0x4001EE6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001EE7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001EE8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public ChatClient _003C_003E4__this;

			[Token(Token = "0x4001EE9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x6002747")]
			[Address(RVA = "0x3E1BB68", Offset = "0x3E1BB68", Length = "0x680")]
			internal void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChatClient._003CDisconnectAsync_003Ed__33::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002748")]
			[Address(RVA = "0x3E1C1E8", Offset = "0x3E1C1E8", Length = "0xC")]
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
		[Token(Token = "0x2000933")]
		private struct _003CProcessPendingMessagesAsync_003Ed__36 : IAsyncStateMachine
		{
			[Token(Token = "0x4001EEA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001EEB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001EEC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public ChatClient _003C_003E4__this;

			[Token(Token = "0x4001EED")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public CancellationToken cancellationToken;

			[Token(Token = "0x4001EEE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private Tuple<string, string, object, string> _003CpendingMessage_003E5__2;

			[Token(Token = "0x4001EEF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private UniTask<AckPayloadWrapper>.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001EF0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private UniTask.Awaiter _003C_003Eu__2;

			[Token(Token = "0x6002749")]
			[Address(RVA = "0x3E1C1F4", Offset = "0x3E1C1F4", Length = "0xB94")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChatClient._003CProcessPendingMessagesAsync_003Ed__36::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600274A")]
			[Address(RVA = "0x3E1CD88", Offset = "0x3E1CD88", Length = "0xC")]
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
		[Token(Token = "0x2000934")]
		private struct _003CSendMessageAsync_003Ed__34 : IAsyncStateMachine
		{
			[Token(Token = "0x4001EF1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001EF2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncUniTaskMethodBuilder<AckPayloadWrapper> _003C_003Et__builder;

			[Token(Token = "0x4001EF3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string channelId;

			[Token(Token = "0x4001EF4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public string messageType;

			[Token(Token = "0x4001EF5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public object payload;

			[Token(Token = "0x4001EF6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public ChatClient _003C_003E4__this;

			[Token(Token = "0x4001EF7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public bool waitForAck;

			[Token(Token = "0x4001EF8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			public CancellationToken cancellationToken;

			[Token(Token = "0x4001EF9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			private _003C_003Ec__DisplayClass34_0 _003C_003E8__1;

			[Token(Token = "0x4001EFA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private EventHandler<MessageAcknowledgedEventArgs> _003CackHandler_003E5__2;

			[Token(Token = "0x4001EFB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			private UniTask.Awaiter _003C_003Eu__1;

			[Token(Token = "0x4001EFC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			private CancellationTokenSource _003CtimeoutCts_003E5__3;

			[Token(Token = "0x4001EFD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
			private UniTask<AckPayloadWrapper>.Awaiter _003C_003Eu__2;

			[Token(Token = "0x600274B")]
			[Address(RVA = "0x3E1CD94", Offset = "0x3E1CD94", Length = "0x1AF4")]
			internal unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChatClient._003CSendMessageAsync_003Ed__34::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600274C")]
			[Address(RVA = "0x3E1E888", Offset = "0x3E1E888", Length = "0x5C")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChatClient._003CSendMessageAsync_003Ed__34::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Token(Token = "0x4001ECC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		internal readonly IWebSocketClient _webSocketClient;

		[Token(Token = "0x4001ECD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private readonly JsonSerializerSettings _jsonSettings;

		[Token(Token = "0x4001ECE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private bool _disposed;

		[Token(Token = "0x4001ECF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private readonly Queue<Tuple<string, string, object, string>> _pendingMessages;

		[Token(Token = "0x4001ED0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private bool _processingPendingMessages;

		[CompilerGenerated]
		[Token(Token = "0x4001ED1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		internal EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

		[CompilerGenerated]
		[Token(Token = "0x4001ED2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		internal EventHandler<ErrorEventArgs> ErrorOccurred;

		[CompilerGenerated]
		[Token(Token = "0x4001ED3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		internal EventHandler<MessageCreatedEventArgs> MessageCreated;

		[CompilerGenerated]
		[Token(Token = "0x4001ED4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		internal EventHandler<MessageUpdatedEventArgs> MessageUpdated;

		[CompilerGenerated]
		[Token(Token = "0x4001ED5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		internal EventHandler<MessageDeletedEventArgs> MessageDeleted;

		[CompilerGenerated]
		[Token(Token = "0x4001ED6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		internal EventHandler<HistoryReceivedEventArgs> HistoryReceived;

		[CompilerGenerated]
		[Token(Token = "0x4001ED7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		private EventHandler<MessageAcknowledgedEventArgs> MessageAcknowledged;

		[CompilerGenerated]
		[Token(Token = "0x4001ED8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		internal EventHandler<RequestDeniedEventArgs> RequestDenied;

		[Token(Token = "0x17000456")]
		public WebSocketState ConnectionState
		{
			[Token(Token = "0x600272F")]
			[Address(RVA = "0x3E18D98", Offset = "0x3E18D98", Length = "0xB8")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::get_ConnectionState");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x600271E")]
		[Address(RVA = "0x3E0C124", Offset = "0x3E0C124", Length = "0xB4")]
		public void add_ConnectionStatusChanged(EventHandler<ConnectionStatusEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_ConnectionStatusChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x600271F")]
		[Address(RVA = "0x3E0CDC4", Offset = "0x3E0CDC4", Length = "0xB4")]
		public void remove_ConnectionStatusChanged(EventHandler<ConnectionStatusEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_ConnectionStatusChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002720")]
		[Address(RVA = "0x3E0C1D8", Offset = "0x3E0C1D8", Length = "0xB4")]
		public void add_ErrorOccurred(EventHandler<ErrorEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_ErrorOccurred");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002721")]
		[Address(RVA = "0x3E0CE78", Offset = "0x3E0CE78", Length = "0xB4")]
		public void remove_ErrorOccurred(EventHandler<ErrorEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_ErrorOccurred");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002722")]
		[Address(RVA = "0x3E0C340", Offset = "0x3E0C340", Length = "0xB4")]
		public void add_MessageCreated(EventHandler<MessageCreatedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_MessageCreated");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002723")]
		[Address(RVA = "0x3E0CFE0", Offset = "0x3E0CFE0", Length = "0xB4")]
		public void remove_MessageCreated(EventHandler<MessageCreatedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_MessageCreated");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002724")]
		[Address(RVA = "0x3E0C3F4", Offset = "0x3E0C3F4", Length = "0xB4")]
		public void add_MessageUpdated(EventHandler<MessageUpdatedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_MessageUpdated");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002725")]
		[Address(RVA = "0x3E0D094", Offset = "0x3E0D094", Length = "0xB4")]
		public void remove_MessageUpdated(EventHandler<MessageUpdatedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_MessageUpdated");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002726")]
		[Address(RVA = "0x3E0C4A8", Offset = "0x3E0C4A8", Length = "0xB4")]
		public void add_MessageDeleted(EventHandler<MessageDeletedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_MessageDeleted");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002727")]
		[Address(RVA = "0x3E0D148", Offset = "0x3E0D148", Length = "0xB4")]
		public void remove_MessageDeleted(EventHandler<MessageDeletedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_MessageDeleted");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002728")]
		[Address(RVA = "0x3E12D7C", Offset = "0x3E12D7C", Length = "0xB4")]
		public void add_HistoryReceived(EventHandler<HistoryReceivedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_HistoryReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002729")]
		[Address(RVA = "0x3E1875C", Offset = "0x3E1875C", Length = "0xB4")]
		public void remove_HistoryReceived(EventHandler<HistoryReceivedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_HistoryReceived");
		}

		[CompilerGenerated]
		[Token(Token = "0x600272A")]
		[Address(RVA = "0x3E18810", Offset = "0x3E18810", Length = "0xB4")]
		public void add_MessageAcknowledged(EventHandler<MessageAcknowledgedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_MessageAcknowledged");
		}

		[CompilerGenerated]
		[Token(Token = "0x600272B")]
		[Address(RVA = "0x3E188C4", Offset = "0x3E188C4", Length = "0xB4")]
		public void remove_MessageAcknowledged(EventHandler<MessageAcknowledgedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_MessageAcknowledged");
		}

		[CompilerGenerated]
		[Token(Token = "0x600272C")]
		[Address(RVA = "0x3E0C28C", Offset = "0x3E0C28C", Length = "0xB4")]
		public void add_RequestDenied(EventHandler<RequestDeniedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::add_RequestDenied");
		}

		[CompilerGenerated]
		[Token(Token = "0x600272D")]
		[Address(RVA = "0x3E0CF2C", Offset = "0x3E0CF2C", Length = "0xB4")]
		public void remove_RequestDenied(EventHandler<RequestDeniedEventArgs> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::remove_RequestDenied");
		}

		[Token(Token = "0x600272E")]
		[Address(RVA = "0x3E18978", Offset = "0x3E18978", Length = "0x420")]
		public ChatClient(IWebSocketClient webSocketClient)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::.ctor");
		}

		[AsyncStateMachine(typeof(_003CConnectAsync_003Ed__32))]
		[Token(Token = "0x6002730")]
		[Address(RVA = "0x3E18E50", Offset = "0x3E18E50", Length = "0xDC")]
		public UniTask ConnectAsync(string url, string authToken)
		{
			_003CConnectAsync_003Ed__32 _003CConnectAsync_003Ed__33 = default(_003CConnectAsync_003Ed__32);
			_003CConnectAsync_003Ed__33._003C_003E4__this = this;
			_003CConnectAsync_003Ed__33.url = url;
			_003CConnectAsync_003Ed__33.authToken = authToken;
			_003CConnectAsync_003Ed__33._003C_003E1__state = -1;
			_003CConnectAsync_003Ed__33.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CDisconnectAsync_003Ed__33))]
		[Token(Token = "0x6002731")]
		[Address(RVA = "0x3E18F2C", Offset = "0x3E18F2C", Length = "0xAC")]
		public UniTask DisconnectAsync()
		{
			_003CDisconnectAsync_003Ed__33 _003CDisconnectAsync_003Ed__34 = default(_003CDisconnectAsync_003Ed__33);
			_003CDisconnectAsync_003Ed__34._003C_003E4__this = this;
			_003CDisconnectAsync_003Ed__34._003C_003E1__state = -1;
			_003CDisconnectAsync_003Ed__34.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DF686C (inside ElephantSocial.Team.TeamService::TriggerTeamLeft +0x68)");
			UniTask result = default(UniTask);
			return result;
		}

		[AsyncStateMachine(typeof(_003CSendMessageAsync_003Ed__34))]
		[Token(Token = "0x6002732")]
		[Address(RVA = "0x3E12E30", Offset = "0x3E12E30", Length = "0x158")]
		public UniTask<AckPayloadWrapper> SendMessageAsync(string channelId, string messageType, object payload, bool waitForAck = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CSendMessageAsync_003Ed__34 _003CSendMessageAsync_003Ed__35 = default(_003CSendMessageAsync_003Ed__34);
			_003CSendMessageAsync_003Ed__35._003C_003E4__this = this;
			_003CSendMessageAsync_003Ed__35.channelId = channelId;
			_003CSendMessageAsync_003Ed__35.messageType = messageType;
			_003CSendMessageAsync_003Ed__35.payload = payload;
			_003CSendMessageAsync_003Ed__35.waitForAck = waitForAck;
			_003CSendMessageAsync_003Ed__35.cancellationToken = cancellationToken;
			_003CSendMessageAsync_003Ed__35._003C_003E1__state = -1;
			_003CSendMessageAsync_003Ed__35.MoveNext();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3E00940 (inside ElephantSocial.Leaderboard.Leaderboard::InitLeaderboardCache +0x3C4)");
			UniTask<AckPayloadWrapper> result = default(UniTask<AckPayloadWrapper>);
			return result;
		}

		[Token(Token = "0x6002733")]
		[Address(RVA = "0x3E18FD8", Offset = "0x3E18FD8", Length = "0xBC")]
		private unsafe void ProcessPendingMessages()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::ProcessPendingMessages");
		}

		[AsyncStateMachine(typeof(_003CProcessPendingMessagesAsync_003Ed__36))]
		[Token(Token = "0x6002734")]
		[Address(RVA = "0x3E19094", Offset = "0x3E19094", Length = "0xB4")]
		private UniTaskVoid ProcessPendingMessagesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			_003CProcessPendingMessagesAsync_003Ed__36 stateMachine = default(_003CProcessPendingMessagesAsync_003Ed__36);
			stateMachine._003C_003E4__this = this;
			stateMachine.cancellationToken = cancellationToken;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return default(UniTaskVoid);
		}

		[Token(Token = "0x6002735")]
		[Address(RVA = "0x3E19148", Offset = "0x3E19148", Length = "0x60")]
		private void HandleWebSocketOpen()
		{
			NotifyConnectionStatusChanged(isConnected: true);
			ProcessPendingMessages();
		}

		[Token(Token = "0x6002736")]
		[Address(RVA = "0x3E19374", Offset = "0x3E19374", Length = "0xC")]
		private void HandleWebSocketClose(string reason)
		{
			NotifyConnectionStatusChanged(isConnected: false, reason);
		}

		[Token(Token = "0x6002737")]
		[Address(RVA = "0x3E19380", Offset = "0x3E19380", Length = "0x1A4")]
		private void HandleWebSocketError(string errorMessage)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::HandleWebSocketError");
		}

		[Token(Token = "0x6002738")]
		[Address(RVA = "0x3E196FC", Offset = "0x3E196FC", Length = "0x660")]
		private void HandleWebSocketMessage(byte[] messageBytes)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::HandleWebSocketMessage");
		}

		[Token(Token = "0x6002739")]
		[Address(RVA = "0x3E19D5C", Offset = "0x3E19D5C", Length = "0x440")]
		private void ProcessMessageByType(IncomingMessageWrapper incomingWrapper, JsonSerializer serializer)
		{
			EventHandler<RequestDeniedEventArgs> eventHandler;
			MessageCreatedEventArgs e2;
			MessageContentPayload _003CMessage_003Ek__BackingField;
			switch (incomingWrapper.Type.ToLowerInvariant())
			{
			case "message_created":
				if (incomingWrapper.Payload != null)
				{
					MessageContentPayload messageContentPayload = incomingWrapper.Payload.ToObject<MessageContentPayload>(serializer);
					if (messageContentPayload != null && MessageCreated != null)
					{
						MessageCreatedEventArgs e3 = new MessageCreatedEventArgs();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E431]");
						int num = (int)((nint)0 & (nint)1);
						bool flag3 = num == 0;
						bool flag4 = !flag3;
						eventHandler = (EventHandler<RequestDeniedEventArgs>)(object)MessageCreated;
						e2 = e3;
						_003CMessage_003Ek__BackingField = messageContentPayload;
						if (!flag4)
						{
							_ = 1;
							eventHandler = (EventHandler<RequestDeniedEventArgs>)(object)MessageCreated;
							e2 = e3;
							_003CMessage_003Ek__BackingField = messageContentPayload;
						}
						goto IL_01fd;
					}
					break;
				}
				break;
			case "message_updated":
				if (incomingWrapper.Payload != null)
				{
					MessageContentPayload messageContentPayload2 = incomingWrapper.Payload.ToObject<MessageContentPayload>(serializer);
					if (messageContentPayload2 != null && MessageUpdated != null)
					{
						MessageUpdatedEventArgs e5 = new MessageUpdatedEventArgs();
						eventHandler = (EventHandler<RequestDeniedEventArgs>)(object)MessageUpdated;
						e2 = (MessageCreatedEventArgs)(object)e5;
						_003CMessage_003Ek__BackingField = messageContentPayload2;
						goto IL_01fd;
					}
					break;
				}
				break;
			case "message_deleted":
				if (incomingWrapper.Payload != null)
				{
					DeletedMessagePayload deletedMessagePayload = incomingWrapper.Payload.ToObject<DeletedMessagePayload>(serializer);
					if (deletedMessagePayload != null && MessageDeleted != null)
					{
						MessageDeletedEventArgs e4 = new MessageDeletedEventArgs();
						eventHandler = (EventHandler<RequestDeniedEventArgs>)(object)MessageDeleted;
						e2 = (MessageCreatedEventArgs)(object)e4;
						_003CMessage_003Ek__BackingField = (MessageContentPayload)(object)deletedMessagePayload;
						goto IL_01fd;
					}
					break;
				}
				break;
			case "acked":
				if (incomingWrapper.Payload != null)
				{
					AckPayloadWrapper ackPayloadWrapper = incomingWrapper.Payload.ToObject<AckPayloadWrapper>(serializer);
					if (ackPayloadWrapper != null)
					{
						HandleAckMessage(incomingWrapper.Channel, ackPayloadWrapper, serializer);
					}
				}
				break;
			case "denied":
				if (incomingWrapper.Payload != null)
				{
					DeniedPayload deniedPayload = incomingWrapper.Payload.ToObject<DeniedPayload>(serializer);
					if (deniedPayload != null)
					{
						eventHandler = RequestDenied;
						if (RequestDenied != null)
						{
							RequestDeniedEventArgs e = new RequestDeniedEventArgs();
							bool flag = e == null;
							bool flag2 = !flag;
							e2 = (MessageCreatedEventArgs)(object)e;
							_003CMessage_003Ek__BackingField = (MessageContentPayload)(object)deniedPayload;
							if (!flag2)
							{
								throw new NullReferenceException();
							}
							goto IL_01fd;
						}
						break;
					}
					break;
				}
				break;
			default:
				{
					string message = "Received unhandled message type: " + incomingWrapper.Type;
					ElephantLog.Log("ChatClient", message);
					break;
				}
				IL_01fd:
				e2.ChannelId = incomingWrapper.Channel;
				e2.Message = _003CMessage_003Ek__BackingField;
				eventHandler(this, (RequestDeniedEventArgs)(object)e2);
				break;
			}
		}

		[Token(Token = "0x600273A")]
		[Address(RVA = "0x3E1A19C", Offset = "0x3E1A19C", Length = "0x324")]
		private void HandleAckMessage(string channelId, AckPayloadWrapper ackWrapper, JsonSerializer serializer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::HandleAckMessage");
		}

		[Token(Token = "0x600273B")]
		[Address(RVA = "0x3E191A8", Offset = "0x3E191A8", Length = "0x1CC")]
		private void NotifyConnectionStatusChanged(bool isConnected, string reason = "")
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::NotifyConnectionStatusChanged");
		}

		[Token(Token = "0x600273C")]
		[Address(RVA = "0x3E19524", Offset = "0x3E19524", Length = "0x1D8")]
		private void NotifyError(string title, string message)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::NotifyError");
		}

		[Token(Token = "0x600273D")]
		[Address(RVA = "0x3E1A4C0", Offset = "0x3E1A4C0", Length = "0xA0")]
		public void Dispose()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E447]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Dispose(disposing: true);
			}
			else
			{
				_ = 1;
				Dispose(disposing: true);
			}
			GC.SuppressFinalize(this);
		}

		[Token(Token = "0x600273E")]
		[Address(RVA = "0x3E1A560", Offset = "0x3E1A560", Length = "0x53C")]
		internal void Dispose(bool disposing)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::Dispose");
		}

		[Token(Token = "0x600273F")]
		[Address(RVA = "0x3E1AA9C", Offset = "0x3E1AA9C", Length = "0x94")]
		~ChatClient()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChatClient::Finalize");
		}
	}
}
