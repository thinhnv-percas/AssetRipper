using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;

namespace Unco.SaveSystem.Core
{
	[Token(Token = "0x200000D")]
	public class LocalDataHandler : IDataHandler, IDataLoader, IDataSaver
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private struct _003CLoadUserDataAsync_003Ed__8 : IAsyncStateMachine
		{
			[Token(Token = "0x400000E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x400000F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<Dictionary<string, object>> _003C_003Et__builder;

			[Token(Token = "0x4000010")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x600003C")]
			[Address(RVA = "0x3F3E4B0", Offset = "0x3F3E4B0", Length = "0x2C0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tgoto L_0036;\nL_0036:\n\tgoto L_0040;\n\tv116 = System.Threading.Tasks.Task::GetAwaiter(v80.<CompletedTask>k__BackingField);\n\tv76 = System.Runtime.CompilerServices.TaskAwaiter::get_IsCompleted(&v70 @ stack_-38_v2 (System.Runtime.CompilerServices.TaskAwaiter));\n\tv134 = v76 == 0;\n\tv78 = ~v134;\n\tif (v78) goto L_0074;\n\tthis.<>1__state = 0;\n\tthis.<>u__1 = v70;\n\tgoto L_0061;\nL_0061:\n\tv164 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>::AwaitUnsafeOnCompleted(v164, &v70 @ stack_-38_v2 (System.Runtime.CompilerServices.TaskAwaiter), this);\n\treturn;\nL_006F:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = -1;\n\tv70 = this.<>u__1;\n\tthis.<>1__state = -2;\n\tv121 = this + 8;\n\tgoto L_008C;\nL_008C:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>::SetResult(v121, v100);\n\treturn;\nL_0095:\n\tv117 = new System.NullReferenceException();\n\tgoto L_00D8;\nL_00D8:\n\t// 216 Interrupt\n\tv136 = 0x8BF5BF4(v117, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv149 = 0x8BF0368(v117, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv165 = 0xA1B8(v149, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0027:\n\tv47 = this.<>1__state == 0;\n\tif (v47) goto L_006F;\nL_0040:\n\tgoto L_0045;\nL_0074:\n\tSystem.Runtime.CompilerServices.TaskAwaiter::GetResult(&v70 @ stack_-38_v2 (System.Runtime.CompilerServices.TaskAwaiter));\n\tv100 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v100);\nL_0045:\n\tv108 = v80.<CompletedTask>k__BackingField == 0;\n\tif (v108) goto L_0095;\n")]
			private unsafe void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LocalDataHandler._003CLoadUserDataAsync_003Ed__8::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x3F3E770", Offset = "0x3F3E770", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0023:\n\tv57 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>::SetStateMachine(v57, stateMachine);\n\treturn;\nL_0020:\n\tgoto L_0023;\n")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LocalDataHandler._003CLoadUserDataAsync_003Ed__8::SetStateMachine");
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Token(Token = "0x17000003")]
		[field: Token(Token = "0x400000D")]
		public static bool PREF_SAVE_ENABLED
		{
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x3F3D9EC", Offset = "0x3F3D9EC", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0018;\nL_0018:\n\treturn v43.<PREF_SAVE_ENABLED>k__BackingField;\n")]
			get;
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x3F3DA68", Offset = "0x3F3DA68", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv49.<PREF_SAVE_ENABLED>k__BackingField = value;\n\treturn;\n")]
			set;
		} = true;

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x3F3DAF4", Offset = "0x3F3DAF4", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv70 = UnityEngine.PlayerPrefs::GetFloat(key, defaultValue);\n\tv64 = onComplete == 0;\n\tif (v64) goto L_0046;\n\tSystem.Action`1<System.Single>::Invoke(onComplete, onComplete.method);\n\treturn;\nL_0046:\n\treturn;\n")]
		public void LoadFloat(string key, Action<float> onComplete, float defaultValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LocalDataHandler::LoadFloat");
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x3F3DBB8", Offset = "0x3F3DBB8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv71 = UnityEngine.PlayerPrefs::GetInt(key, defaultValue);\n\tv64 = onComplete == 0;\n\tif (v64) goto L_0047;\n\tSystem.Action`1<System.Int32>::Invoke(onComplete, v71);\n\treturn;\nL_0047:\n\treturn;\n")]
		public void LoadInt(string key, Action<int> onComplete, int defaultValue)
		{
			int obj = PlayerPrefs.GetInt(key, defaultValue);
			onComplete?.Invoke(obj);
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x3F3DC7C", Offset = "0x3F3DC7C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv71 = UnityEngine.PlayerPrefs::GetString(key, defaultValue);\n\tv64 = onComplete == 0;\n\tif (v64) goto L_0047;\n\tSystem.Action`1<System.String>::Invoke(onComplete, v71);\n\treturn;\nL_0047:\n\treturn;\n")]
		public void LoadString(string key, Action<string> onComplete, string defaultValue)
		{
			string obj = PlayerPrefs.GetString(key, defaultValue);
			onComplete?.Invoke(obj);
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x4A1172C", Offset = "0x4A1172C", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv70 = Unco.SaveSystem.Core.LocalDataHandler::GetKey(key);\n\tgoto L_0031;\nL_0031:\n\tv84 = Newtonsoft.Json.JsonConvert::SerializeObject(defaultValue);\n\tv91 = UnityEngine.PlayerPrefs::GetString(v70, v84);\n\tv92 = onComplete == 0;\n\tif (v92) goto L_0067;\n\tgoto L_0044;\nL_0044:\n\tgoto L_0052;\n\tgoto L_0052;\n\tv129 = 0x220C2B8(Il2CppMethodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0052:\n\tgoto L_0058;\nL_0058:\n\tv144 = Newtonsoft.Json.JsonConvert::DeserializeObject(v91, 0);\n\tSystem.Action`1<T>::Invoke(onComplete, v144);\n\tv79 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0025;\nL_0067:\n\treturn;\n")]
		public void LoadJson<T>(string key, Action<T> onComplete, T defaultValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LocalDataHandler::LoadJson");
		}

		[AsyncStateMachine(typeof(_003CLoadUserDataAsync_003Ed__8))]
		[Token(Token = "0x6000032")]
		[Address(RVA = "0x3F3DD40", Offset = "0x3F3DD40", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0030:\n\tv66 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>::Create();\n\tv87 = -1;\n\tv89 = &v52 @ stack_-60_v1 (System.Int32) | 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>::Start(v89, &v87 @ stack_-60_v2 (Unco.SaveSystem.Core.LocalDataHandler+<LoadUserDataAsync>d__8));\n\tv92 = &v52 @ stack_-60_v1 (System.Int32) | 8;\n\treturnVal1 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>::get_Task(v92);\n\treturn returnVal1;\nL_0026:\n\tv52 = 0;\n\tgoto L_0030;\n")]
		public unsafe Task<Dictionary<string, object>> LoadUserDataAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LocalDataHandler::LoadUserDataAsync");
			return default;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x3F3DE38", Offset = "0x3F3DE38", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0023:\n\tUnityEngine.PlayerPrefs::SetFloat(key, value);\n\tgoto L_002C;\nL_002C:\n\tgoto L_0031;\nL_0031:\n\tgoto L_0035;\nL_0035:\n\tgoto L_003C;\nL_003C:\n\tv117 = v111.<PREF_SAVE_ENABLED>k__BackingField == 1;\n\tif (v117) goto L_007D;\n\tv154 = onSaveComplete == 0;\n\tif (v154) goto L_008A;\nL_0051:\n\tSystem.Action`1<System.Single>::Invoke(onSaveComplete, onSaveComplete.method);\nL_0051:\n\treturn;\nL_007D:\n\tUnityEngine.PlayerPrefs::Save();\n\tv218 = onSaveComplete == 0;\n\tv182 = ~v218;\n\tif (v182) goto L_0051;\nL_008A:\n\treturn;\nL_001E:\n\tgoto L_0023;\n")]
		public void SaveFloat(string key, float value, Action<float> onSaveComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LocalDataHandler::SaveFloat");
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x3F3E068", Offset = "0x3F3E068", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0023:\n\tUnityEngine.PlayerPrefs::SetInt(key, value);\n\tgoto L_002C;\nL_002C:\n\tgoto L_0031;\nL_0031:\n\tgoto L_0035;\nL_0035:\n\tgoto L_003C;\nL_003C:\n\tv117 = v111.<PREF_SAVE_ENABLED>k__BackingField == 1;\n\tif (v117) goto L_007D;\n\tv154 = onSaveComplete == 0;\n\tif (v154) goto L_008A;\nL_0051:\n\tSystem.Action`1<System.Int32>::Invoke(onSaveComplete, value);\nL_0051:\n\treturn;\nL_007D:\n\tUnityEngine.PlayerPrefs::Save();\n\tv218 = onSaveComplete == 0;\n\tv182 = ~v218;\n\tif (v182) goto L_0051;\nL_008A:\n\treturn;\nL_001E:\n\tgoto L_0023;\n")]
		public void SaveInt(string key, int value, Action<int> onSaveComplete = null)
		{
			PlayerPrefs.SetInt(key, value);
			if (!PREF_SAVE_ENABLED)
			{
				if (onSaveComplete == null)
				{
					return;
				}
			}
			else
			{
				PlayerPrefs.Save();
				if (onSaveComplete == null)
				{
					return;
				}
			}
			onSaveComplete(value);
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x3F3E1C0", Offset = "0x3F3E1C0", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0023:\n\tUnityEngine.PlayerPrefs::SetString(key, value);\n\tgoto L_002C;\nL_002C:\n\tgoto L_0031;\nL_0031:\n\tgoto L_0035;\nL_0035:\n\tgoto L_003C;\nL_003C:\n\tv117 = v111.<PREF_SAVE_ENABLED>k__BackingField == 1;\n\tif (v117) goto L_007D;\n\tv154 = onSaveComplete == 0;\n\tif (v154) goto L_008A;\nL_0051:\n\tSystem.Action`1<System.String>::Invoke(onSaveComplete, value);\nL_0051:\n\treturn;\nL_007D:\n\tUnityEngine.PlayerPrefs::Save();\n\tv218 = onSaveComplete == 0;\n\tv182 = ~v218;\n\tif (v182) goto L_0051;\nL_008A:\n\treturn;\nL_001E:\n\tgoto L_0023;\n")]
		public void SaveString(string key, string value, Action<string> onSaveComplete = null)
		{
			PlayerPrefs.SetString(key, value);
			if (!PREF_SAVE_ENABLED)
			{
				if (onSaveComplete == null)
				{
					return;
				}
			}
			else
			{
				PlayerPrefs.Save();
				if (onSaveComplete == null)
				{
					return;
				}
			}
			onSaveComplete(value);
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x4A11BF4", Offset = "0x4A11BF4", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_0022;\nL_0022:\n\tgoto L_0026;\nL_0026:\n\tv74 = Unco.SaveSystem.Core.LocalDataHandler::GetKey(key);\n\tgoto L_0032;\nL_0032:\n\tv88 = Newtonsoft.Json.JsonConvert::SerializeObject(value);\n\tUnityEngine.PlayerPrefs::SetString(v74, v88);\n\tUnco.SaveSystem.Core.LocalDataHandler::Save(this);\n\tv97 = onSaveComplete == 0;\n\tif (v97) goto L_0053;\n\tSystem.Action`1<T>::Invoke(onSaveComplete, value);\n\treturn;\nL_0053:\n\treturn;\n\tv83 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0026;\n")]
		public void SaveJson<T>(string key, T value, Action<T> onSaveComplete = null)
		{
			string key2 = GetKey(key);
			string value2 = JsonConvert.SerializeObject(value);
			PlayerPrefs.SetString(key2, value2);
			Save();
			onSaveComplete?.Invoke(value);
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x3F3DF90", Offset = "0x3F3DF90", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tgoto L_0025;\nL_0025:\n\tv90 = v79.<PREF_SAVE_ENABLED>k__BackingField != 1;\n\tif (v90) goto L_005D;\n\tUnityEngine.PlayerPrefs::Save();\n\treturn;\nL_005D:\n\treturn;\n")]
		private void Save()
		{
			if (PREF_SAVE_ENABLED)
			{
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x3F3DBB4", Offset = "0x3F3DBB4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn key;\n")]
		private static string GetKey(string key)
		{
			return key;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x3F3E318", Offset = "0x3F3E318", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.PlayerPrefs::DeleteKey(key);\n\tv58 = *([B78EBCB]) & 1;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0058;\n\tgoto L_0024;\nL_0024:\n\tgoto L_0028;\nL_0028:\n\tgoto L_0034;\nL_0034:\n\tv143 = v132.<PREF_SAVE_ENABLED>k__BackingField != 1;\n\tif (v143) goto L_0084;\n\tUnityEngine.PlayerPrefs::Save();\n\treturn;\nL_0058:\n\t*([B78EBCB]) = 1;\n\tgoto L_0024;\nL_0084:\n\treturn;\n")]
		public void DeleteData(string key)
		{
			PlayerPrefs.DeleteKey(key);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBCB]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			if (PREF_SAVE_ENABLED)
			{
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x3F3D9CC", Offset = "0x3F3D9CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LocalDataHandler()
		{
		}
	}
}
