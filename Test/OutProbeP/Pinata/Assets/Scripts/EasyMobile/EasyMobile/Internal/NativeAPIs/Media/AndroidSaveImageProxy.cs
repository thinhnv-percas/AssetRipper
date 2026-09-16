using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Media
{
	[Token(Token = "0x20000F8")]
	internal class AndroidSaveImageProxy : AndroidJavaProxy
	{
		[Token(Token = "0x4000463")]
		private const string NativeListenerName = "com.sglib.easymobile.androidnative.media.listeners.ISaveImageListener";

		[Token(Token = "0x4000464")]
		[FieldOffset(Offset = "0x20")]
		private Action<string> callback;

		[Token(Token = "0x60008CF")]
		[Address(RVA = "0xC014C0", Offset = "0xC014C0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEE2F8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FB2]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.sglib.easymobile.androidnative.media.listeners.ISaveImageListener\");\n\tthis.callback = callback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidSaveImageProxy(Action<string> callback)
			: base("com.sglib.easymobile.androidnative.media.listeners.ISaveImageListener")
		{
			this.callback = callback;
		}

		[Token(Token = "0x60008D0")]
		[Address(RVA = "0xC02B80", Offset = "0xC02B80", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA6D20]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, error, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FB3]) = v41;\nL_0018:\n\tv45 = new EasyMobile.Internal.NativeAPIs.Media.AndroidSaveImageProxy+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.error = error;\n\tv50 = this.callback == 0;\n\tif (v50) goto L_004A;\n\tv56 = new System.Action();\n\tSystem.Action::.ctor(v56, v45, Il2CppMethodInfo);\n\tgoto L_0042;\n\tv94 = *([v90 @ X0_v8+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0042;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v90, v64, v67, v65, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0042:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v56);\n\treturn;\nL_004A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnNativeCallback(string error)
		{
			if (callback != null)
			{
				Action action = delegate
				{
					AndroidSaveImageProxy androidSaveImageProxy = this;
					androidSaveImageProxy.callback(error);
				};
				RuntimeHelper.RunOnMainThread(action);
			}
		}

		[Token(Token = "0x60008D1")]
		[Address(RVA = "0xC02C6C", Offset = "0xC02C6C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB6458]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodName, args, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FB4]) = v41;\nL_0018:\n\tv44 = args.Length == 0;\n\tif (v44) goto L_0038;\n\tv47 = args[0];\n\tv48 = args[0] == 0;\n\tif (v48) goto L_002D;\n\tv66 = *([v47 @ X1_v4 (System.String)]) != System.String;\n\tif (v66) goto L_003E;\nL_002D:\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidSaveImageProxy::OnNativeCallback(this, args[0]);\n\treturn 0;\n\tv46 = new System.NullReferenceException();\nL_0038:\n\tv52 = new System.IndexOutOfRangeException();\n\tthrow v52;\nL_003E:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override AndroidJavaObject Invoke(string methodName, object[] args)
		{
			if (args.Length != 0)
			{
				string text = (string)args[0];
				if (args[0] == null || (object)text.GetType() == typeof(string))
				{
					OnNativeCallback((string)args[0]);
					return null;
				}
				return (AndroidJavaObject)(object)new InvalidCastException();
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
