using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x2000017")]
	internal class InitLoginForwardCallback : AndroidJavaProxy
	{
		[CompilerGenerated]
		[Token(Token = "0x2000018")]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			[Token(Token = "0x400004C")]
			[FieldOffset(Offset = "0x10")]
			public InitLoginForwardCallback _003C_003E4__this;

			[Token(Token = "0x400004D")]
			[FieldOffset(Offset = "0x18")]
			public string message;

			[Token(Token = "0x6000076")]
			[Address(RVA = "0x15C8DC0", Offset = "0x15C8DC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass2_0()
			{
			}

			internal void _003ConInitFinished_003Eb__0()
			{
				//IL_001f: Expected I, but got O
				//IL_0168: Expected O, but got I
				//IL_0064: Expected O, but got I
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Expected O, but got Unknown
				//IL_0103: Expected O, but got I
				//IL_0112: Expected O, but got I
				//IL_00b0: Expected O, but got I
				InitLoginForwardCallback initLoginForwardCallback = _003C_003E4__this;
				IInitListener initListener = initLoginForwardCallback._initListener;
				IntPtr intPtr = (IntPtr)initListener;
				string text = message;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.UDP.IInitListener>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.UDP.IInitListener>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IInitListener))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (Il2CppClass<UnityEngine.UDP.IInitListener>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c9;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0150;
				IL_00c9:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v98 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x20")]
		private IInitListener _initListener;

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x15C8AAC", Offset = "0x15C8AAC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF6C18]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, initListener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299C1]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, initListener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.InitCallback\");\n\tthis._initListener = initListener;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InitLoginForwardCallback(IInitListener initListener)
			: base("com.unity.udp.sdk.InitCallback")
		{
			_initListener = initListener;
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15C8B34", Offset = "0x15C8B34", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1F099E8]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, resultCode, message, jo, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20299C2]) = v49;\nL_001D:\n\tv53 = new UnityEngine.UDP.InitLoginForwardCallback+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v53);\n\tv53.<>4__this = this;\n\tv53.message = message;\n\tv58 = this._initListener == 0;\n\tif (v58) goto L_0039;\n\tv99 = resultCode == 0;\n\tif (v99) goto L_004A;\nL_002D:\n\tv172 = new System.Action();\n\tgoto L_00B0;\nL_0039:\n\tgoto L_0043;\n\tv124 = *([v102 @ X0_v39+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0043;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v102, v54, message, jo, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0043:\n\tUnityEngine.Debug::LogError(\"LoginCallback cannot be null\");\n\tv164 = resultCode == 0;\n\tv111 = ~v164;\n\tif (v111) goto L_002D;\nL_004A:\n\tv73 = new UnityEngine.UDP.InitLoginForwardCallback+<>c__DisplayClass2_1();\n\tSystem.Object::.ctor(v73);\n\tv73.userInfo = 0;\n\tv73.CS$<>8__locals1 = v53;\n\tv193 = jo == 0;\n\tif (v193) goto L_009B;\n\tv74 = new UnityEngine.UDP.UserInfo();\n\tSystem.Object::.ctor(v74);\n\tv73.userInfo = v74;\n\t// 99 NewArr v239 @ X0_v26 (System.Object[]), typeof(System.Object[]), 0\n\tv248 = UnityEngine.AndroidJavaObject::Call(jo, \"getUserId\", v239);\n\tv255 = System.String::Concat(v74.<Channel>k__BackingField, \"_\", v248);\n\tv74.<UserId>k__BackingField = v255;\n\tv95 = v73.userInfo;\n\t// 120 NewArr v258 @ X0_v32 (System.Object[]), typeof(System.Object[]), 0\n\tv75 = UnityEngine.AndroidJavaObject::Call(jo, \"getLoginReceipt\", v258);\n\tv95.<UserLoginToken>k__BackingField = v75;\n\tv96 = v73.userInfo;\n\t// 134 NewArr v263 @ X0_v36 (System.Object[]), typeof(System.Object[]), 0\n\tv76 = UnityEngine.AndroidJavaObject::Call(jo, \"getChannel\", v263);\n\tv96.<Channel>k__BackingField = v76;\n\tv266 = v73.userInfo == 0;\n\tv207 = ~v266;\n\tif (v207) goto L_00A9;\nL_009B:\n\tgoto L_00A5;\n\tv219 = *([v215 @ X0_v19+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_00A5;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v215, v204, v202, v201, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00A5:\n\tUnityEngine.Debug::Log(\"No UserInfo is returned.\");\nL_00A9:\n\tv172 = new System.Action();\nL_00B0:\n\tSystem.Action::.ctor(v172, v141, *([v183 @ X8_v7 (Il2CppMethodInfo)]));\n\tgoto L_00C7;\n\tv194 = *([v189 @ X0_v8+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tgoto L_00C7;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v189, v141, v137, v135, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00C7:\n\tUnityEngine.UDP.MainThreadDispatcher::RunOnMainThread(v181);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onInitFinished(int resultCode, string message, AndroidJavaObject jo)
		{
			if (_initListener != null)
			{
				if (resultCode != 0)
				{
					goto IL_0058;
				}
			}
			else
			{
				Debug.LogError("LoginCallback cannot be null");
				if (resultCode != 0)
				{
					goto IL_0058;
				}
			}
			UserInfo userInfo = null;
			if (jo != null)
			{
				UserInfo userInfo2 = (userInfo = new UserInfo());
				object[] args = new object[0];
				string text = jo.Call<string>("getUserId", args);
				string userId = userInfo2.Channel + "_" + text;
				userInfo2.UserId = userId;
				UserInfo userInfo3 = userInfo;
				object[] args2 = new object[0];
				string userLoginToken = jo.Call<string>("getLoginReceipt", args2);
				userInfo3.UserLoginToken = userLoginToken;
				UserInfo userInfo4 = userInfo;
				object[] args3 = new object[0];
				string channel = jo.Call<string>("getChannel", args3);
				userInfo4.Channel = channel;
				if (userInfo != null)
				{
					goto IL_023a;
				}
			}
			Debug.Log("No UserInfo is returned.");
			goto IL_023a;
			IL_023a:
			Action action = null;
			_003C_003Ec__DisplayClass2_1 _003C_003Ec__DisplayClass2_3;
			_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_2 = (_003C_003Ec__DisplayClass2_0)(object)_003C_003Ec__DisplayClass2_3;
			Action runnable = action;
			IntPtr intPtr = (IntPtr)0;
			goto IL_025a;
			IL_0058:
			Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: Action");
			action = null;
			_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_4;
			_003C_003Ec__DisplayClass2_2 = _003C_003Ec__DisplayClass2_4;
			runnable = action;
			intPtr = (IntPtr)0;
			goto IL_025a;
			IL_025a:
			MainThreadDispatcher.RunOnMainThread(runnable);
		}
	}
}
