using System;
using Cpp2ILInjected;
using ElephantSDK;
using Firebase.Analytics;
using Reflex.Attributes;
using RollicGames.Advertisements;
using UnityEngine;
using _game.CoreGameKit.Tracking.Tools;

namespace _game.Systems.Firebase
{
	[Token(Token = "0x2000775")]
	public class FirebaseCrashlyticsService
	{
		[Token(Token = "0x2000776")]
		private sealed class UnityLogException : Exception
		{
			[Token(Token = "0x40018F2")]
			[FieldOffset(Offset = "0x90")]
			private readonly string _stackTrace;

			[Token(Token = "0x170002FE")]
			public override string StackTrace
			{
				[Token(Token = "0x6001F81")]
				[Address(RVA = "0x3D9187C", Offset = "0x3D9187C", Length = "0x8")]
				get
				{
					return _stackTrace;
				}
			}

			[Token(Token = "0x6001F80")]
			[Address(RVA = "0x3D915F4", Offset = "0x3D915F4", Length = "0xEC")]
			public UnityLogException(string message, string stackTrace)
			{
				string stackTrace2;
				if (stackTrace != null)
				{
					stackTrace2 = stackTrace;
				}
				else
				{
					int num = 192761856 + 1336;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v7 (System.Int32)+90]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v8+B8]");
					object obj2 = 0;
					stackTrace2 = (string)obj2;
					if (this == null)
					{
						throw new NullReferenceException();
					}
				}
				_stackTrace = stackTrace2;
			}
		}

		[Token(Token = "0x40018F0")]
		[FieldOffset(Offset = "0x11")]
		private bool _userContextSet;

		[Token(Token = "0x40018F1")]
		[FieldOffset(Offset = "0x12")]
		private bool _errorBridgeConnected;

		[Token(Token = "0x170002FD")]
		[field: Token(Token = "0x40018EF")]
		[field: FieldOffset(Offset = "0x10")]
		public bool IsInitialized
		{
			[Token(Token = "0x6001F71")]
			[Address(RVA = "0x3D90004", Offset = "0x3D90004", Length = "0x8")]
			get;
			[Token(Token = "0x6001F72")]
			[Address(RVA = "0x3D9000C", Offset = "0x3D9000C", Length = "0x8")]
			private set;
		}

		[Inject(false)]
		[Token(Token = "0x6001F73")]
		[Address(RVA = "0x3D90014", Offset = "0x3D90014", Length = "0x4")]
		private void Construct()
		{
			Initialize();
		}

		[Token(Token = "0x6001F74")]
		[Address(RVA = "0x3D90018", Offset = "0x3D90018", Length = "0x1E4")]
		private void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseCrashlyticsService::Initialize");
		}

		[Token(Token = "0x6001F75")]
		[Address(RVA = "0x3D901FC", Offset = "0x3D901FC", Length = "0x278")]
		private void OnFirebaseReady()
		{
			Action value = OnFirebaseReady;
			RLAdvertisementManager.remove_OnFirebaseInitialized(value);
			IsInitialized = true;
			Debug.Log("[FirebaseCrashlytics] Initialized via Elephant adapter");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E01A]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if (_errorBridgeConnected)
				{
					goto IL_007b;
				}
			}
			else
			{
				_ = 1;
				if (_errorBridgeConnected)
				{
					goto IL_007b;
				}
			}
			_errorBridgeConnected = true;
			Action<ErrorLogEntry> value2 = OnUnityErrorLogged;
			ErrorLogger.OnErrorLogged += value2;
			if (TrySetUserContext())
			{
				return;
			}
			goto IL_01a2;
			IL_01a2:
			ElephantCore instance = ElephantCore.Instance;
			if (instance.sdkIsReady)
			{
				OnElephantInitialized();
				return;
			}
			OnRemoteConfigLoaded value3 = OnElephantInitialized;
			ElephantCore.add_onRemoteConfigLoaded(value3);
			return;
			IL_007b:
			if (TrySetUserContext())
			{
				return;
			}
			goto IL_01a2;
		}

		[Token(Token = "0x6001F76")]
		[Address(RVA = "0x3D90C60", Offset = "0x3D90C60", Length = "0xB8")]
		private void OnElephantInitialized()
		{
			OnRemoteConfigLoaded value = OnElephantInitialized;
			ElephantCore.remove_onRemoteConfigLoaded(value);
			bool flag = TrySetUserContext();
		}

		[Token(Token = "0x6001F77")]
		[Address(RVA = "0x3D90D18", Offset = "0x3D90D18", Length = "0x420")]
		public void RefreshSessionContext()
		{
			if (IsInitialized)
			{
				ElephantCore instance = ElephantCore.Instance;
				if ((object)ElephantCore.Instance != null && instance.FirebaseElephantAdapter != null)
				{
					MetaDataUtils instance2 = MetaDataUtils.GetInstance();
					int currentLevel = instance2.GetCurrentLevel();
					int num = currentLevel;
					string text = num.ToString();
					instance.FirebaseElephantAdapter.SetCustomKey("current_level", text);
					float realtimeSinceStartup = Time.realtimeSinceStartup;
					float num2 = realtimeSinceStartup;
					string value = num2.ToString("F0");
					instance.FirebaseElephantAdapter.SetCustomKey("app_time", value);
					int sessionLevelStartCount = instance2.GetSessionLevelStartCount();
					num = sessionLevelStartCount;
					string value2 = num.ToString();
					instance.FirebaseElephantAdapter.SetCustomKey("session_level_starts", value2);
					int sessionLevelCompleteCount = instance2.GetSessionLevelCompleteCount();
					num = sessionLevelCompleteCount;
					string value3 = num.ToString();
					instance.FirebaseElephantAdapter.SetCustomKey("session_level_completes", value3);
					int sessionLevelFailCount = instance2.GetSessionLevelFailCount();
					num = sessionLevelFailCount;
					string value4 = num.ToString();
					instance.FirebaseElephantAdapter.SetCustomKey("session_level_fails", value4);
					FirebaseAnalytics.SetUserProperty("current_level", text);
				}
			}
		}

		[Token(Token = "0x6001F78")]
		[Address(RVA = "0x3D91138", Offset = "0x3D91138", Length = "0x114")]
		public void LogMessage(string message)
		{
			if (IsInitialized)
			{
				ElephantCore instance = ElephantCore.Instance;
				if ((object)ElephantCore.Instance != null && instance.FirebaseElephantAdapter != null)
				{
					instance.FirebaseElephantAdapter.LogMessage(message);
				}
			}
		}

		[Token(Token = "0x6001F79")]
		[Address(RVA = "0x3D9124C", Offset = "0x3D9124C", Length = "0x114")]
		public void LogException(Exception exception)
		{
			if (IsInitialized)
			{
				ElephantCore instance = ElephantCore.Instance;
				if ((object)ElephantCore.Instance != null && instance.FirebaseElephantAdapter != null)
				{
					instance.FirebaseElephantAdapter.LogException(exception);
				}
			}
		}

		[Token(Token = "0x6001F7A")]
		[Address(RVA = "0x3D90474", Offset = "0x3D90474", Length = "0xA4")]
		private void ConnectErrorBridge()
		{
			if (!_errorBridgeConnected)
			{
				_errorBridgeConnected = true;
				Action<ErrorLogEntry> value = OnUnityErrorLogged;
				ErrorLogger.OnErrorLogged += value;
			}
		}

		[Token(Token = "0x6001F7B")]
		[Address(RVA = "0x3D91360", Offset = "0x3D91360", Length = "0x294")]
		private void OnUnityErrorLogged(ErrorLogEntry entry)
		{
			if (entry != null && IsInitialized)
			{
				ElephantCore instance = ElephantCore.Instance;
				if ((object)ElephantCore.Instance != null && instance.FirebaseElephantAdapter != null)
				{
					string value = ((entry.LogType != null) ? entry.LogType : "");
					instance.FirebaseElephantAdapter.SetCustomKey("last_log_type", value);
					string message = "[" + entry.LogType + "] " + entry.Message;
					instance.FirebaseElephantAdapter.LogMessage(message);
					UnityLogException exception = new UnityLogException(entry.Message, entry.StackTrace);
					instance.FirebaseElephantAdapter.LogException(exception);
				}
			}
		}

		[Token(Token = "0x6001F7C")]
		[Address(RVA = "0x3D916E0", Offset = "0x3D916E0", Length = "0x11C")]
		public void SetCustomKey(string key, string value)
		{
			if (IsInitialized)
			{
				ElephantCore instance = ElephantCore.Instance;
				if ((object)ElephantCore.Instance != null && instance.FirebaseElephantAdapter != null)
				{
					instance.FirebaseElephantAdapter.SetCustomKey(key, value);
				}
			}
		}

		[Token(Token = "0x6001F7D")]
		[Address(RVA = "0x3D917FC", Offset = "0x3D917FC", Length = "0x78")]
		public void ThrowTestCrash()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseCrashlyticsService::ThrowTestCrash");
		}

		[Token(Token = "0x6001F7E")]
		[Address(RVA = "0x3D90518", Offset = "0x3D90518", Length = "0x748")]
		private unsafe bool TrySetUserContext()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseCrashlyticsService::TrySetUserContext");
			return default;
		}

		[Token(Token = "0x6001F7F")]
		[Address(RVA = "0x3D91874", Offset = "0x3D91874", Length = "0x8")]
		public FirebaseCrashlyticsService()
		{
		}
	}
}
