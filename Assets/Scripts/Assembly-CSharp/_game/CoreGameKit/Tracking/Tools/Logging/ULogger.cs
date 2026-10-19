using System;
using System.IO;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;
using UnityEngine;

namespace _game.CoreGameKit.Tracking.Tools.Logging
{
	[Token(Token = "0x2000593")]
	public class ULogger
	{
		[Token(Token = "0x4001338")]
		[FieldOffset(Offset = "0x10")]
		private bool _isEnabled;

		[Token(Token = "0x4001339")]
		[FieldOffset(Offset = "0x11")]
		private bool _isEnabledChecked;

		[Token(Token = "0x400133A")]
		[FieldOffset(Offset = "0x18")]
		private RemoteConfigManager _remoteConfigManager;

		[Token(Token = "0x400133B")]
		private static readonly string AiLogDirectory;

		[Token(Token = "0x400133C")]
		private static readonly object FileLock;

		[Token(Token = "0x17000217")]
		internal static string AiLogDirectoryPath
		{
			[Token(Token = "0x60017A3")]
			[Address(RVA = "0x3D2F064", Offset = "0x3D2F064", Length = "0x7C")]
			get
			{
				return AiLogDirectory;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60017A4")]
		[Address(RVA = "0x3D2F0E0", Offset = "0x3D2F0E0", Length = "0x8")]
		private void Construct(RemoteConfigManager remoteConfigManager)
		{
			_remoteConfigManager = remoteConfigManager;
		}

		[Token(Token = "0x60017A5")]
		[Address(RVA = "0x3D2F0E8", Offset = "0x3D2F0E8", Length = "0x1D0")]
		private bool CheckEnabled(string sourceFilePath)
		{
			if (!_isEnabledChecked)
			{
				_isEnabledChecked = true;
				if (_remoteConfigManager != null)
				{
					DisabledLogsData json = _remoteConfigManager.GetJson<DisabledLogsData>(RemoteKey.disabled_logs);
					if (json == null)
					{
						goto IL_009d;
					}
					string path = default(string);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
					if (json.disableAll)
					{
						_isEnabled = false;
						return false;
					}
					if (json.disabledTypes != null)
					{
						bool flag = json.disabledTypes.Contains(fileNameWithoutExtension);
						return (byte)(((_isEnabled = (byte)((flag ? 1u : 0u) ^ 1u) != 0) ? 1u : 0u) & 1u) != 0;
					}
					NullReferenceException ex = new NullReferenceException();
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
				bool result = default(bool);
				return result;
			}
			goto IL_009d;
			IL_009d:
			return _isEnabled;
		}

		[Token(Token = "0x60017A6")]
		[Address(RVA = "0x3D2F2B8", Offset = "0x3D2F2B8", Length = "0xFC")]
		public void Log(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if (CheckEnabled(sourceFilePath))
			{
				string message2 = FormatMessage(message, memberName, sourceFilePath, sourceLineNumber);
				Debug.Log(message2);
			}
		}

		[Token(Token = "0x60017A7")]
		[Address(RVA = "0x3D2F584", Offset = "0x3D2F584", Length = "0xFC")]
		public void LogWarning(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if (CheckEnabled(sourceFilePath))
			{
				string message2 = FormatMessage(message, memberName, sourceFilePath, sourceLineNumber);
				Debug.LogWarning(message2);
			}
		}

		[Token(Token = "0x60017A8")]
		[Address(RVA = "0x3D2F680", Offset = "0x3D2F680", Length = "0xFC")]
		public void LogError(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if (CheckEnabled(sourceFilePath))
			{
				string message2 = FormatMessage(message, memberName, sourceFilePath, sourceLineNumber);
				Debug.LogError(message2);
			}
		}

		[Token(Token = "0x60017A9")]
		[Address(RVA = "0x3D2F3B4", Offset = "0x3D2F3B4", Length = "0x1D0")]
		private static string FormatMessage(string message, string memberName, string sourceFilePath, int sourceLineNumber)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFilePath);
			object[] array = new object[4];
			if (fileNameWithoutExtension != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_01cc;
				}
			}
			array[0] = fileNameWithoutExtension;
			if (memberName != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_01cc;
				}
			}
			array[1] = memberName;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_01cc;
				}
			}
			array[2] = obj3;
			if (message != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj5 = default(object);
				if (obj5 == null)
				{
					goto IL_01cc;
				}
			}
			array[3] = message;
			return string.Format("[{0}.{1}:{2}] {3}", array);
			IL_01cc:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60017AA")]
		[Address(RVA = "0x3D2F77C", Offset = "0x3D2F77C", Length = "0x10")]
		public ULogger()
		{
			_isEnabled = true;
		}

		[Token(Token = "0x60017AB")]
		[Address(RVA = "0x3D2F78C", Offset = "0x3D2F78C", Length = "0xE0")]
		static ULogger()
		{
			string tempPath = Path.GetTempPath();
			string aiLogDirectory = Path.Combine(tempPath, "UncoGameAILogs");
			AiLogDirectory = aiLogDirectory;
			object fileLock = new object();
			FileLock = fileLock;
		}
	}
}
