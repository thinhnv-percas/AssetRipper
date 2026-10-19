using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tracking.Tools
{
	[Token(Token = "0x200058E")]
	public static class ErrorLogger
	{
		[Token(Token = "0x400132D")]
		private static bool _isInitialized;

		[CompilerGenerated]
		[Token(Token = "0x400132E")]
		internal static Action<ErrorLogEntry> _onErrorLogged;

		[Token(Token = "0x17000215")]
		[field: Token(Token = "0x400132F")]
		public static bool HasSubscriber
		{
			[Token(Token = "0x600178E")]
			[Address(RVA = "0x3D2E088", Offset = "0x3D2E088", Length = "0x4C")]
			get;
			[Token(Token = "0x600178F")]
			[Address(RVA = "0x3D2E0D4", Offset = "0x3D2E0D4", Length = "0x58")]
			private set;
		}

		[Token(Token = "0x17000216")]
		public static int CachedErrorCount
		{
			[Token(Token = "0x6001790")]
			[Address(RVA = "0x3D2E12C", Offset = "0x3D2E12C", Length = "0x48")]
			get
			{
				List<ErrorLogEntry> allErrors = ErrorLogCache.GetAllErrors();
				return allErrors.Count;
			}
		}

		[Token(Token = "0x1400001E")]
		public static event Action<ErrorLogEntry> OnErrorLogged
		{
			[Token(Token = "0x600178C")]
			[Address(RVA = "0x3D2DF60", Offset = "0x3D2DF60", Length = "0x94")]
			add
			{
				Action<ErrorLogEntry> value2 = default(Action<ErrorLogEntry>);
				add__onErrorLogged(value2);
				bool flag = _onErrorLogged == null;
				bool flag2 = !flag;
				HasSubscriber = flag2;
			}
			[Token(Token = "0x600178D")]
			[Address(RVA = "0x3D2DFF4", Offset = "0x3D2DFF4", Length = "0x94")]
			remove
			{
				Action<ErrorLogEntry> value2 = default(Action<ErrorLogEntry>);
				remove__onErrorLogged(value2);
				bool flag = _onErrorLogged == null;
				bool flag2 = !flag;
				HasSubscriber = flag2;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x600178A")]
		[Address(RVA = "0x3D2DDB8", Offset = "0x3D2DDB8", Length = "0xD4")]
		internal static void add__onErrorLogged(Action<ErrorLogEntry> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLogger::add__onErrorLogged");
		}

		[CompilerGenerated]
		[Token(Token = "0x600178B")]
		[Address(RVA = "0x3D2DE8C", Offset = "0x3D2DE8C", Length = "0xD4")]
		internal static void remove__onErrorLogged(Action<ErrorLogEntry> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLogger::remove__onErrorLogged");
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		[Token(Token = "0x6001791")]
		[Address(RVA = "0x3D2E174", Offset = "0x3D2E174", Length = "0x4")]
		private static void AutoInitialize()
		{
			Initialize();
		}

		[Token(Token = "0x6001792")]
		[Address(RVA = "0x3D2E178", Offset = "0x3D2E178", Length = "0x1D4")]
		public static void Initialize()
		{
			if (_isInitialized)
			{
				Debug.LogWarning("[ErrorLogger] Already initialized. Skipping duplicate initialization.");
				return;
			}
			Application.LogCallback value = OnLogMessageReceived;
			Application.logMessageReceived += value;
			_isInitialized = true;
			List<ErrorLogEntry> allErrors = ErrorLogCache.GetAllErrors();
			int count = allErrors.Count;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string message = $"[ErrorLogger] Initialized. Cached errors: {arg}";
			Debug.Log(message);
		}

		[Token(Token = "0x6001793")]
		[Address(RVA = "0x3D2E34C", Offset = "0x3D2E34C", Length = "0x138")]
		public static void Shutdown()
		{
			if (_isInitialized)
			{
				Application.LogCallback value = OnLogMessageReceived;
				Application.logMessageReceived -= value;
				_isInitialized = false;
				Debug.Log("[ErrorLogger] Shutdown complete.");
			}
		}

		[Token(Token = "0x6001794")]
		[Address(RVA = "0x3D2E484", Offset = "0x3D2E484", Length = "0x9C")]
		public static void ClearCache()
		{
			//IL_0009: Expected O, but got I4
			//IL_005e: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBC8]");
			int num;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				num = 187707392 + 2008;
				ErrorLogCache.Clear();
			}
			else
			{
				_ = 1;
				num = 187707392 + 2008;
				ErrorLogCache.Clear();
			}
			Debug.Log(num);
		}

		[Token(Token = "0x6001795")]
		[Address(RVA = "0x3D2E520", Offset = "0x3D2E520", Length = "0x24")]
		private static void OnLogMessageReceived(string condition, string stackTrace, LogType type)
		{
			bool flag = (uint)type < 4u;
			bool flag2 = !flag;
			int num = (int)(type - 4);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 1 << (int)type;
				if ((num2 & 0x13) != 0)
				{
					ProcessError(condition, stackTrace, type);
				}
			}
		}

		[Token(Token = "0x6001796")]
		[Address(RVA = "0x3D2E544", Offset = "0x3D2E544", Length = "0x1D8")]
		private static void ProcessError(string condition, string stackTrace, LogType type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLogger::ProcessError");
		}
	}
}
