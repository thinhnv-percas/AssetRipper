using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cpp2ILInjected;
using Firebase;
using Firebase.Analytics;
using Firebase.Crashlytics;
using Firebase.Extensions;

namespace ElephantSDK
{
	[Token(Token = "0x200094A")]
	public class ElephantFirebaseManager : IFirebaseElephantAdapter, IElephantAdapter
	{
		[Token(Token = "0x4001F54")]
		[FieldOffset(Offset = "0x10")]
		private bool _isAvailable;

		[Token(Token = "0x1700045E")]
		public bool IsAvailable
		{
			[Token(Token = "0x60027A4")]
			[Address(RVA = "0x3E43B2C", Offset = "0x3E43B2C", Length = "0x8")]
			get
			{
				return _isAvailable;
			}
		}

		[Token(Token = "0x60027A5")]
		[Address(RVA = "0x3E43B34", Offset = "0x3E43B34", Length = "0x130")]
		public void InitializeFirebase(Action onInitialized)
		{
			Task<DependencyStatus> task = FirebaseApp.CheckAndFixDependenciesAsync();
			Action<Task<DependencyStatus>> continuation = delegate(Task<DependencyStatus> task3)
			{
				DependencyStatus result = task3.Result;
				ElephantFirebaseManager elephantFirebaseManager = this;
				Action action;
				if (result != DependencyStatus.Available)
				{
					elephantFirebaseManager._isAvailable = false;
					DependencyStatus dependencyStatus = result;
					object arg = dependencyStatus;
					string message = $"Could not resolve Firebase dependencies: {arg}";
					ElephantLog.LogError("FIREBASE-ADAPTER", message);
					action = onInitialized;
					if (onInitialized == null)
					{
						return;
					}
				}
				else
				{
					elephantFirebaseManager._isAvailable = true;
					ElephantLog.Log("FIREBASE-ADAPTER", "Firebase initialized successfully");
					action = onInitialized;
					if (onInitialized == null)
					{
						return;
					}
				}
				action();
			};
			Task task2 = task.ContinueWithOnMainThread(continuation);
		}

		[Token(Token = "0x60027A6")]
		[Address(RVA = "0x3E43C6C", Offset = "0x3E43C6C", Length = "0x9C")]
		public void SetAnalyticsCollectionEnabled(bool enabled)
		{
			if (IsAvailable)
			{
				FirebaseAnalytics.SetAnalyticsCollectionEnabled(enabled);
			}
		}

		[Token(Token = "0x60027A7")]
		[Address(RVA = "0x3E43D08", Offset = "0x3E43D08", Length = "0x154")]
		public void GetAnalyticsInstanceId(Action<string> callback)
		{
			if (IsAvailable)
			{
				Task<string> analyticsInstanceIdAsync = FirebaseAnalytics.GetAnalyticsInstanceIdAsync();
				Action<Task<string>> continuation = delegate(Task<string> task2)
				{
					Action<string> action;
					string obj;
					if (task2.IsFaulted)
					{
						AggregateException exception = task2.Exception;
						string message = $"Failed to get analytics instance ID: {exception}";
						ElephantLog.LogError("FIREBASE-ADAPTER", message);
						action = callback;
						if (callback == null)
						{
							return;
						}
						obj = null;
					}
					else
					{
						action = callback;
						if (callback == null)
						{
							return;
						}
						string result = task2.Result;
						obj = result;
					}
					action(obj);
				};
				Task task = ((Task<object>)(object)analyticsInstanceIdAsync).ContinueWithOnMainThread((Action<Task<object>>)continuation);
			}
			else if (callback != null)
			{
				callback(null);
			}
		}

		[Token(Token = "0x60027A8")]
		[Address(RVA = "0x3E43E64", Offset = "0x3E43E64", Length = "0x91C")]
		public void LogEvent(string name, IDictionary<string, object> parameters)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantFirebaseManager::LogEvent");
		}

		[Token(Token = "0x60027A9")]
		[Address(RVA = "0x3E44780", Offset = "0x3E44780", Length = "0x144")]
		public void SetAnalyticsConsent(bool granted)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantFirebaseManager::SetAnalyticsConsent");
		}

		[Token(Token = "0x60027AA")]
		[Address(RVA = "0x3E448C4", Offset = "0x3E448C4", Length = "0x4")]
		public void SetConsentForCcpa(bool accepted)
		{
			SetAnalyticsConsent(accepted);
		}

		[Token(Token = "0x60027AB")]
		[Address(RVA = "0x3E448C8", Offset = "0x3E448C8", Length = "0x4C")]
		public void SetCrashlyticsUserId(string userId)
		{
			if (IsAvailable && !string.IsNullOrEmpty(userId))
			{
				Crashlytics.SetUserId(userId);
			}
		}

		[Token(Token = "0x60027AC")]
		[Address(RVA = "0x3E44914", Offset = "0x3E44914", Length = "0x1C")]
		public void SetCrashlyticsCollectionEnabled(bool enabled)
		{
			if (IsAvailable)
			{
				Crashlytics.IsCrashlyticsCollectionEnabled = enabled;
			}
		}

		[Token(Token = "0x60027AD")]
		[Address(RVA = "0x3E44930", Offset = "0x3E44930", Length = "0x84")]
		public void SetCustomKey(string key, string value)
		{
			//IL_0093: Expected O, but got I
			//IL_00a3: Expected O, but got I
			if (IsAvailable && !string.IsNullOrEmpty(key))
			{
				if (value != null)
				{
					Crashlytics.SetCustomKey(key, value);
					return;
				}
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v3 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v4+B8]");
				object value2 = 0;
				Crashlytics.SetCustomKey(key, (string)value2);
			}
		}

		[Token(Token = "0x60027AE")]
		[Address(RVA = "0x3E449B4", Offset = "0x3E449B4", Length = "0x4C")]
		public void LogMessage(string message)
		{
			if (IsAvailable && !string.IsNullOrEmpty(message))
			{
				Crashlytics.Log(message);
			}
		}

		[Token(Token = "0x60027AF")]
		[Address(RVA = "0x3E44A00", Offset = "0x3E44A00", Length = "0x1C")]
		public void LogException(Exception exception)
		{
			if (exception != null && IsAvailable)
			{
				Crashlytics.LogException(exception);
			}
		}

		[Token(Token = "0x60027B0")]
		[Address(RVA = "0x3E43B1C", Offset = "0x3E43B1C", Length = "0x8")]
		public ElephantFirebaseManager()
		{
		}
	}
}
