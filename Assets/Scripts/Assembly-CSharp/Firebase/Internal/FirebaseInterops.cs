using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;

namespace Firebase.Internal
{
	[Token(Token = "0x200080C")]
	internal static class FirebaseInterops
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200080E")]
		private struct _003CAddFirebaseTokensAsync_003Ed__26 : IAsyncStateMachine
		{
			[Token(Token = "0x4001B0D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001B0E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001B0F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public FirebaseApp firebaseApp;

			[Token(Token = "0x4001B10")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public HttpRequestMessage request;

			[Token(Token = "0x4001B11")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private TaskAwaiter<string> _003C_003Eu__1;

			[Token(Token = "0x6002267")]
			[Address(RVA = "0x3DD2A30", Offset = "0x3DD2A30", Length = "0x44C")]
			private void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops._003CAddFirebaseTokensAsync_003Ed__26::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002268")]
			[Address(RVA = "0x3DD2E7C", Offset = "0x3DD2E7C", Length = "0x6C")]
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
		[Token(Token = "0x200080F")]
		private struct _003CAddFirebaseTokensAsync_003Ed__27 : IAsyncStateMachine
		{
			[Token(Token = "0x4001B12")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001B13")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001B14")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public FirebaseApp firebaseApp;

			[Token(Token = "0x4001B15")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public ClientWebSocket socket;

			[Token(Token = "0x4001B16")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private TaskAwaiter<string> _003C_003Eu__1;

			[Token(Token = "0x6002269")]
			[Address(RVA = "0x3DD2EE8", Offset = "0x3DD2EE8", Length = "0x438")]
			private void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops._003CAddFirebaseTokensAsync_003Ed__27::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600226A")]
			[Address(RVA = "0x3DD3320", Offset = "0x3DD3320", Length = "0x6C")]
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
		[Token(Token = "0x2000810")]
		private struct _003CGetAppCheckTokenAsync_003Ed__23 : IAsyncStateMachine
		{
			[Token(Token = "0x4001B17")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001B18")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			[Token(Token = "0x4001B19")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public FirebaseApp firebaseApp;

			[Token(Token = "0x4001B1A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private Task _003CappCheckTokenTask_003E5__2;

			[Token(Token = "0x4001B1B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x600226B")]
			[Address(RVA = "0x3DD338C", Offset = "0x3DD338C", Length = "0x6A8")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops._003CGetAppCheckTokenAsync_003Ed__23::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600226C")]
			[Address(RVA = "0x3DD3A34", Offset = "0x3DD3A34", Length = "0x80")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops._003CGetAppCheckTokenAsync_003Ed__23::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000811")]
		private struct _003CGetAuthTokenAsync_003Ed__25 : IAsyncStateMachine
		{
			[Token(Token = "0x4001B1C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001B1D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			[Token(Token = "0x4001B1E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public FirebaseApp firebaseApp;

			[Token(Token = "0x4001B1F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private Task _003CtokenTask_003E5__2;

			[Token(Token = "0x4001B20")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x600226D")]
			[Address(RVA = "0x3DD3AB4", Offset = "0x3DD3AB4", Length = "0x69C")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops._003CGetAuthTokenAsync_003Ed__25::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600226E")]
			[Address(RVA = "0x3DD4150", Offset = "0x3DD4150", Length = "0x80")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops._003CGetAuthTokenAsync_003Ed__25::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Token(Token = "0x4001AFB")]
		private static PropertyInfo _dataCollectionProperty;

		[Token(Token = "0x4001AFC")]
		private static Type _appCheckType;

		[Token(Token = "0x4001AFD")]
		private static MethodInfo _appCheckGetInstanceMethod;

		[Token(Token = "0x4001AFE")]
		private static MethodInfo _appCheckGetTokenMethod;

		[Token(Token = "0x4001AFF")]
		private static PropertyInfo _appCheckTokenResultProperty;

		[Token(Token = "0x4001B00")]
		private static PropertyInfo _appCheckTokenTokenProperty;

		[Token(Token = "0x4001B01")]
		private static bool _appCheckReflectionInitialized;

		[Token(Token = "0x4001B02")]
		private const string appCheckHeader = "X-Firebase-AppCheck";

		[Token(Token = "0x4001B03")]
		private static Type _authType;

		[Token(Token = "0x4001B04")]
		private static MethodInfo _authGetAuthMethod;

		[Token(Token = "0x4001B05")]
		private static PropertyInfo _authCurrentUserProperty;

		[Token(Token = "0x4001B06")]
		private static MethodInfo _userTokenAsyncMethod;

		[Token(Token = "0x4001B07")]
		private static PropertyInfo _userTokenTaskResultProperty;

		[Token(Token = "0x4001B08")]
		private static bool _authReflectionInitialized;

		[Token(Token = "0x4001B09")]
		private const string authHeader = "Authorization";

		[Token(Token = "0x4001B0A")]
		private const string _unknownSdkVersion = "unknown";

		[Token(Token = "0x4001B0B")]
		internal static readonly Lazy<string> _sdkVersionFetcher;

		[Token(Token = "0x6002259")]
		[Address(RVA = "0x3DD0F50", Offset = "0x3DD0F50", Length = "0x144")]
		static FirebaseInterops()
		{
			_dataCollectionProperty = null;
			_appCheckReflectionInitialized = false;
			_authReflectionInitialized = false;
			Func<string> valueFactory = delegate
			{
				int num = 192761856 + 1336;
				Type typeFromHandle = typeof(FirebaseApp);
				if ((object)typeFromHandle != null)
				{
					Assembly assembly = typeFromHandle.Assembly;
					if ((object)assembly != null)
					{
						Type type = assembly.GetType("Firebase.VersionInfo");
						if (type == null)
						{
							goto IL_00f9;
						}
						if ((object)type != null)
						{
							PropertyInfo property = type.GetProperty("SdkVersion", BindingFlags.Static | BindingFlags.NonPublic);
							if (property == null)
							{
								goto IL_00f9;
							}
							if ((object)property != null)
							{
								object value = property.GetValue(null);
								object obj;
								if (value != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X20_v4 (System.Int32)+90]");
									obj = ((value != null) ? null : value);
								}
								else
								{
									obj = null;
								}
								if (obj == null)
								{
									return "unknown";
								}
								return (string)obj;
							}
							NullReferenceException ex = new NullReferenceException();
						}
						else
						{
							NullReferenceException ex = new NullReferenceException();
						}
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
					}
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
				string result = default(string);
				return result;
				IL_00f9:
				return "unknown";
			};
			Lazy<string> sdkVersionFetcher = new Lazy<string>(valueFactory);
			_sdkVersionFetcher = sdkVersionFetcher;
			InitializeAppReflection();
			InitializeAppCheckReflection();
			InitializeAuthReflection();
		}

		[Token(Token = "0x600225A")]
		[Address(RVA = "0x3DD2070", Offset = "0x3DD2070", Length = "0x4")]
		private static void LogError(string message)
		{
		}

		[Token(Token = "0x600225B")]
		[Address(RVA = "0x3DD1094", Offset = "0x3DD1094", Length = "0x2E8")]
		private static void InitializeAppReflection()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops::InitializeAppReflection");
		}

		[Token(Token = "0x600225C")]
		[Address(RVA = "0x3DD2074", Offset = "0x3DD2074", Length = "0x1D8")]
		public static bool GetIsDataCollectionDefaultEnabled(FirebaseApp firebaseApp)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops::GetIsDataCollectionDefaultEnabled");
			return default;
		}

		[Token(Token = "0x600225D")]
		[Address(RVA = "0x3DD224C", Offset = "0x3DD224C", Length = "0x94")]
		internal static string GetVersionInfoSdkVersion()
		{
			return _sdkVersionFetcher.Value;
		}

		[Token(Token = "0x600225E")]
		[Address(RVA = "0x3DD137C", Offset = "0x3DD137C", Length = "0x5E8")]
		private static void InitializeAppCheckReflection()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops::InitializeAppCheckReflection");
		}

		[AsyncStateMachine(typeof(_003CGetAppCheckTokenAsync_003Ed__23))]
		[Token(Token = "0x600225F")]
		[Address(RVA = "0x3DD22E0", Offset = "0x3DD22E0", Length = "0x118")]
		internal unsafe static Task<string> GetAppCheckTokenAsync(FirebaseApp firebaseApp)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops::GetAppCheckTokenAsync");
			return default;
		}

		[Token(Token = "0x6002260")]
		[Address(RVA = "0x3DD1964", Offset = "0x3DD1964", Length = "0x70C")]
		private static void InitializeAuthReflection()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops::InitializeAuthReflection");
		}

		[AsyncStateMachine(typeof(_003CGetAuthTokenAsync_003Ed__25))]
		[Token(Token = "0x6002261")]
		[Address(RVA = "0x3DD23F8", Offset = "0x3DD23F8", Length = "0x118")]
		internal unsafe static Task<string> GetAuthTokenAsync(FirebaseApp firebaseApp)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseInterops::GetAuthTokenAsync");
			return default;
		}

		[AsyncStateMachine(typeof(_003CAddFirebaseTokensAsync_003Ed__26))]
		[Token(Token = "0x6002262")]
		[Address(RVA = "0x3DD2510", Offset = "0x3DD2510", Length = "0xFC")]
		internal static Task AddFirebaseTokensAsync(HttpRequestMessage request, FirebaseApp firebaseApp)
		{
			AsyncTaskMethodBuilder _003C_003Et__builder = AsyncTaskMethodBuilder.Create();
			_003CAddFirebaseTokensAsync_003Ed__26 stateMachine = default(_003CAddFirebaseTokensAsync_003Ed__26);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine.request = request;
			stateMachine.firebaseApp = firebaseApp;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CAddFirebaseTokensAsync_003Ed__27))]
		[Token(Token = "0x6002263")]
		[Address(RVA = "0x3DD260C", Offset = "0x3DD260C", Length = "0xFC")]
		internal static Task AddFirebaseTokensAsync(ClientWebSocket socket, FirebaseApp firebaseApp)
		{
			AsyncTaskMethodBuilder _003C_003Et__builder = AsyncTaskMethodBuilder.Create();
			_003CAddFirebaseTokensAsync_003Ed__27 stateMachine = default(_003CAddFirebaseTokensAsync_003Ed__27);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine.socket = socket;
			stateMachine.firebaseApp = firebaseApp;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}
	}
}
