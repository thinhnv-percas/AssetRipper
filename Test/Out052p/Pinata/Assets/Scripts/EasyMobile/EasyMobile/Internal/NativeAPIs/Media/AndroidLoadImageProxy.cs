using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Media
{
	[Token(Token = "0x20000F5")]
	internal class AndroidLoadImageProxy : AndroidJavaProxy
	{
		[Token(Token = "0x400045D")]
		private const string NativeListenerName = "com.sglib.easymobile.androidnative.media.listeners.ILoadImageListener";

		[Token(Token = "0x400045E")]
		[FieldOffset(Offset = "0x20")]
		private Action<string, Texture2D> callback;

		[Token(Token = "0x60008C6")]
		[Address(RVA = "0xC01B88", Offset = "0xC01B88", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB2BB0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FA2]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.sglib.easymobile.androidnative.media.listeners.ILoadImageListener\");\n\tthis.callback = callback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidLoadImageProxy(Action<string, Texture2D> callback)
			: base("com.sglib.easymobile.androidnative.media.listeners.ILoadImageListener")
		{
			this.callback = callback;
		}

		[Token(Token = "0x60008C7")]
		[Address(RVA = "0xC01D20", Offset = "0xC01D20", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1ED1490]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, error, data, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022FA3]) = v44;\nL_001A:\n\tv48 = new EasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v48);\n\tv48.error = error;\n\tv48.<>4__this = this;\n\tv48.data = data;\n\tv53 = this.callback == 0;\n\tif (v53) goto L_004F;\n\tv59 = new System.Action();\n\tSystem.Action::.ctor(v59, v48, Il2CppMethodInfo);\n\tgoto L_0046;\n\tv100 = *([v96 @ X0_v8+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0046;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v96, v68, v71, v69, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0046:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v59);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnNativeCallback(string error, byte[] data)
		{
			if (callback == null)
			{
				return;
			}
			Action action = delegate
			{
				//IL_0179: Expected O, but got I4
				string arg = error;
				Action<string, Texture2D> action2;
				if (error == null)
				{
					Texture2D texture2D = TextureUtilities.Decode(data);
					AndroidLoadImageProxy androidLoadImageProxy = this;
					if (androidLoadImageProxy.callback != null)
					{
						androidLoadImageProxy.callback(null, texture2D);
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
						bool flag = (IntPtr)error != (IntPtr)1;
						Texture2D texture2D2 = texture2D;
						NullReferenceException ex2 = ex;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
							object obj2 = default(object);
							object obj = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj3 = default(object);
							if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
								AndroidLoadImageProxy androidLoadImageProxy2 = this;
								object obj4 = obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v51 @ X9_v6+180] (should have been resolved before IL gen)");
								string text = default(string);
								arg = text;
								action2 = androidLoadImageProxy2.callback;
								goto IL_01e7;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
							object obj6 = default(object);
							object obj5 = obj6;
							arg = (string)(32022528 + 2160);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							texture2D2 = null;
							NullReferenceException ex3 = default(NullReferenceException);
							ex2 = ex3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					}
					return;
				}
				AndroidLoadImageProxy androidLoadImageProxy3 = this;
				action2 = androidLoadImageProxy3.callback;
				goto IL_01e7;
				IL_01e7:
				action2(arg, null);
			};
			RuntimeHelper.RunOnMainThread(action);
		}

		[Token(Token = "0x60008C8")]
		[Address(RVA = "0xC01E14", Offset = "0xC01E14", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB7DA8]);\n\tv27 = *([v26 @ X8_v28]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodName, javaArgs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2022FA4]) = v45;\nL_0019:\n\tv125 = javaArgs.Length;\n\tv48 = javaArgs.Length == 0;\n\tif (v48) goto L_0081;\n\tv126 = javaArgs[0];\n\tv103 = javaArgs[0] == 0;\n\tif (v103) goto L_005C;\n\tv132 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002C;\n\tv185 = v132;\n\tv186 = 0x8907BC(v185, methodName, javaArgs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv189 = *([v132 @ X22_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002C:\n\tv190 = *([v132 @ X22_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv191 = v190 == 0;\n\tif (v191) goto L_004D;\n\tv194 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0039;\n\tv217 = v194;\n\tv218 = 0x8907BC(v217, methodName, javaArgs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0039:\n\tv219 = *([v194 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv206 = ~v219;\n\tif (v206) goto L_004D;\n\tgoto L_004D;\n\tv238 = v200;\n\tv239 = 0x8907BC(v238, methodName, javaArgs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_004D:\n\tgoto L_0059;\n\tv220 = v142;\n\tv221 = 0x8907BC(v220, methodName, javaArgs, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0059:\n\tv143 = UnityEngine.AndroidJavaObject::Call(v126, \"toString\", v225.Value);\n\tv125 = javaArgs.Length;\nL_005C:\n\tv147 = v125 < 1;\n\tv112 = ~v147;\n\tv111 = v125 - 1;\n\tv109 = v111 == 0;\n\tv148 = ~v112;\n\tv104 = v148 | v109;\n\tif (v104) goto L_0081;\n\tv174 = javaArgs[1] == 0;\n\tif (v174) goto L_FFFFFFFF;\n\tv215 = UnityEngine.AndroidJavaObject::GetRawObject(javaArgs[1]);\n\tv230 = UnityEngine.AndroidJNIHelper::ConvertFromJNIArray(v215);\n\tgoto L_0076;\nL_0076:\n\tEasyMobile.Internal.NativeAPIs.Media.AndroidLoadImageProxy::OnNativeCallback(this, v126, v164);\n\treturn 0;\nL_0081:\n\tv127 = new System.IndexOutOfRangeException();\n\tthrow v127;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override AndroidJavaObject Invoke(string methodName, AndroidJavaObject[] javaArgs)
		{
			//IL_000f: Expected O, but got I4
			//IL_0183: Expected O, but got I
			//IL_00d8: Expected O, but got I4
			object obj = javaArgs.Length;
			if (javaArgs.Length != 0)
			{
				AndroidJavaObject androidJavaObject = javaArgs[0];
				if (javaArgs[0] != null)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X22_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					string text = androidJavaObject.Call<string>("toString", Array.Empty<object>());
					obj = javaArgs.Length;
					androidJavaObject = (AndroidJavaObject)(object)text;
				}
				bool flag = (long)(IntPtr)obj < 1L;
				bool flag2 = !flag;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					byte[] data;
					if (javaArgs[1] != null)
					{
						IntPtr rawObject = javaArgs[1].GetRawObject();
						byte[] array = AndroidJNIHelper.ConvertFromJNIArray<byte[]>(rawObject);
						data = array;
					}
					else
					{
						data = null;
					}
					OnNativeCallback((string)(object)androidJavaObject, data);
					return null;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
