using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Media
{
	[Token(Token = "0x20000F6")]
	internal class AndroidMediaCollectedProxy : AndroidJavaProxy
	{
		[Token(Token = "0x400045F")]
		private const string NativeListenerName = "com.sglib.easymobile.androidnative.media.listeners.IMediaCollectedListener";

		[Token(Token = "0x4000460")]
		[FieldOffset(Offset = "0x20")]
		private Action<string, MediaResult> callback;

		[Token(Token = "0x60008C9")]
		[Address(RVA = "0xC00C58", Offset = "0xC00C58", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EECA70]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FA6]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.sglib.easymobile.androidnative.media.listeners.IMediaCollectedListener\");\n\tthis.callback = callback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidMediaCollectedProxy(Action<string, MediaResult> callback)
			: base("com.sglib.easymobile.androidnative.media.listeners.IMediaCollectedListener")
		{
			this.callback = callback;
		}

		[Token(Token = "0x60008CA")]
		[Address(RVA = "0xC020FC", Offset = "0xC020FC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EA5840]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, error, result, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022FA7]) = v44;\nL_001A:\n\tv48 = new EasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v48);\n\tv48.<>4__this = this;\n\tv48.error = error;\n\tv48.result = result;\n\tv53 = this.callback == 0;\n\tif (v53) goto L_004F;\n\tv59 = new System.Action();\n\tSystem.Action::.ctor(v59, v48, Il2CppMethodInfo);\n\tgoto L_0046;\n\tv100 = *([v96 @ X0_v8+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0046;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v96, v68, v71, v69, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0046:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v59);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnNativeCallback(string error, AndroidJavaObject result)
		{
			if (callback != null)
			{
				Action action = delegate
				{
					AndroidMediaCollectedProxy androidMediaCollectedProxy = this;
					AndroidMediaResultBridge androidMediaResultBridge = new AndroidMediaResultBridge(result);
					MediaResult arg = (MediaResult)androidMediaResultBridge;
					androidMediaCollectedProxy.callback(error, arg);
				};
				RuntimeHelper.RunOnMainThread(action);
			}
		}

		[Token(Token = "0x60008CB")]
		[Address(RVA = "0xC021F0", Offset = "0xC021F0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA7100]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodName, args, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FA8]) = v41;\nL_0018:\n\tv44 = args.Length == 0;\n\tif (v44) goto L_0065;\n\tv96 = args[0];\n\tv97 = args[0] == 0;\n\tif (v97) goto L_002C;\n\tv127 = *([v96 @ X1_v8 (System.String)]) != System.String;\n\tif (v127) goto L_0070;\nL_002C:\n\tv167 = args.Length < 1;\n\tv115 = ~v167;\n\tv113 = args.Length - 1;\n\tv109 = v113 == 0;\n\tv168 = ~v115;\n\tv99 = v168 | v109;\n\tif (v99) goto L_0065;\n\tv173 = args[1] == 0;\n\tif (v173) goto L_005C;\n\tgoto L_FFFFFFFF;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_006B;\nL_005C:\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidMediaCollectedProxy::OnNativeCallback(this, args[0], args[1]);\n\treturn 0;\nL_0065:\n\tv122 = new System.IndexOutOfRangeException();\n\tthrow v122;\nL_006B:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_0070:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override AndroidJavaObject Invoke(string methodName, object[] args)
		{
			//IL_00b3: Expected O, but got I4
			if (args.Length != 0)
			{
				string text = (string)args[0];
				if (args[0] != null && (object)text.GetType() != typeof(string))
				{
					return (AndroidJavaObject)(object)new InvalidCastException();
				}
				bool flag = args.Length < 1;
				bool flag2 = !flag;
				object obj = args.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					if (args[1] != null)
					{
						AndroidJavaObject androidJavaObject = args[1] as AndroidJavaObject;
						if (androidJavaObject == null)
						{
							throw new InvalidCastException();
						}
					}
					OnNativeCallback((string)args[0], (AndroidJavaObject)args[1]);
					return null;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
