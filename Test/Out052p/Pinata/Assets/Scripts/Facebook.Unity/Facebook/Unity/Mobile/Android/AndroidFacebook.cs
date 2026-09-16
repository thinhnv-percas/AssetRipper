using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Mobile.Android
{
	[Token(Token = "0x2000068")]
	internal sealed class AndroidFacebook : MobileFacebook
	{
		[Token(Token = "0x2000069")]
		private class JavaMethodCall<T> : MethodCall<T> where T : IResult
		{
			[Token(Token = "0x40000AC")]
			[FieldOffset(Offset = "0x0")]
			private AndroidFacebook androidImpl;

			[Token(Token = "0x6000299")]
			[Address(RVA = "0xD935E8", Offset = "0xD935E8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Facebook.Unity.MethodCall`1<T>::.ctor(this, androidImpl, methodName);\n\tthis.androidImpl = androidImpl;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public JavaMethodCall(AndroidFacebook androidImpl, string methodName)
				: base((FacebookBase)androidImpl, methodName)
			{
				this.androidImpl = androidImpl;
			}

			[Token(Token = "0x600029A")]
			[Address(RVA = "0xD93630", Offset = "0xD93630", Length = "0x154")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EAAC88]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, args, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20240BB]) = v44;\nL_001A:\n\tv48 = new Facebook.Unity.MethodArguments();\n\tv50 = args == 0;\n\tif (v50) goto L_0026;\n\tFacebook.Unity.MethodArguments::.ctor(v48, args);\n\tv54 = this == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002E;\n\tgoto L_006A;\nL_0026:\n\tFacebook.Unity.MethodArguments::.ctor(v48);\nL_002E:\n\tv65 = Facebook.Unity.MethodCall`1<T>::get_Callback(this);\n\tv66 = v65 == 0;\n\tif (v66) goto L_0053;\n\tv100 = this.androidImpl;\n\tv82 = Facebook.Unity.MethodCall`1<T>::get_Callback(this);\n\tv83 = Facebook.Unity.CallbackManager::AddFacebookDelegate(v100.<CallbackManager>k__BackingField, v82);\n\tFacebook.Unity.MethodArguments::AddString(v48, \"callback_id\", v83);\nL_0053:\n\tv84 = Facebook.Unity.MethodCall`1<T>::get_MethodName(this);\n\tv85 = Facebook.Unity.MethodArguments::ToJsonString(v48);\n\tFacebook.Unity.Mobile.Android.AndroidFacebook::CallFB(this.androidImpl, v84, v85);\n\treturn;\nL_006A:\n\tthrow System.NullReferenceException;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override void Call(MethodArguments args = null)
			{
				MethodArguments methodArguments = new MethodArguments(args);
				if (args == null || this != null)
				{
					FacebookDelegate<T> callback = base.Callback;
					if (callback != null)
					{
						AndroidFacebook androidFacebook = androidImpl;
						FacebookDelegate<T> callback2 = base.Callback;
						string value = androidFacebook.CallbackManager.AddFacebookDelegate(callback2);
						methodArguments.AddString("callback_id", value);
					}
					string methodName = base.MethodName;
					string args2 = methodArguments.ToJsonString();
					androidImpl.CallFB(methodName, args2);
					return;
				}
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x2C")]
		private bool limitEventUsage;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x30")]
		private IAndroidWrapper androidWrapper;

		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x38")]
		private string userID;

		[CompilerGenerated]
		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x40")]
		private string _003CKeyHash_003Ek__BackingField;

		[Token(Token = "0x17000086")]
		private string KeyHash
		{
			[CompilerGenerated]
			[Token(Token = "0x6000283")]
			[Address(RVA = "0xD30E18", Offset = "0xD30E18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<KeyHash>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CKeyHash_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000087")]
		public override bool LimitEventUsage
		{
			[Token(Token = "0x6000284")]
			[Address(RVA = "0xD30E20", Offset = "0xD30E20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.limitEventUsage;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LimitEventUsage;
			}
			[Token(Token = "0x6000285")]
			[Address(RVA = "0xD30E28", Offset = "0xD30E28", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv23 = *([1F0AD70]);\n\tv24 = *([v23 @ X8_v6]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023C5B]) = v42;\nL_0018:\n\tthis.limitEventUsage = value;\n\tv45 = 0xE8F14C(&value @ X1 (System.Boolean), 0, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tFacebook.Unity.Mobile.Android.AndroidFacebook::CallFB(this, \"SetLimitEventUsage\", v45);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				limitEventUsage = value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
				string args = default(string);
				CallFB("SetLimitEventUsage", args);
			}
		}

		[Token(Token = "0x17000088")]
		public override string SDKName
		{
			[Token(Token = "0x6000286")]
			[Address(RVA = "0xD30FCC", Offset = "0xD30FCC", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EC7AC8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C5C]) = v35;\nL_0015:\n\treturnVal1 = 0xD34EB0(v32, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturn returnVal1;\n\tX19 = stack[0];\n\t// 24 ShiftStack 32\n\treturn X0;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @D34EB0 (inside Facebook.Unity.Utilities+<>c::<ParsePermissionFromResult>b__18_0 +0x4C)");
				string result = default(string);
				return result;
			}
		}

		[Token(Token = "0x17000089")]
		public override string SDKVersion
		{
			[Token(Token = "0x6000287")]
			[Address(RVA = "0xD31014", Offset = "0xD31014", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EA4058]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C5D]) = v40;\nL_0014:\n\tv41 = this.androidWrapper;\n\tv45 = *([v41 @ X19_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper)]);\n\tv46 = Il2CppMethodInfo;\n\tv53 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]) == 0;\n\tif (v53) goto L_003F;\n\tv108 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]) + 8;\nL_002B:\n\tv113 = *([v108 @ X11_v5-8]) == Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>;\n\tif (v113) goto L_0042;\n\tv107 = v107 + 1;\n\tv169 = v107 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]);\n\tv87 = ~v169;\n\tv108 = v108 + 0x10;\n\tv63 = ~v87;\n\tif (v63) goto L_002B;\nL_003F:\n\tv175 = 0x8909C4(v41, Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>, *([v46 @ X21_v1 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0048;\nL_0042:\n\tv171 = *([v108 @ X11_v5]) + *([v46 @ X21_v1 (Il2CppMethodInfo)+48]);\n\tv172 = v171 << 4;\n\tv173 = v45 + v172;\n\tv175 = v173 + 0x130;\nL_0048:\n\tv179 = 0x8D8294(*([v175 @ X0_v4+8]), Il2CppMethodInfo, *([v46 @ X21_v1 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv123 = *([v179 @ X0_v6]);\n\t// 84 IndirectJump v123 @ X3_v1, v41 @ X19_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper), v41 @ X19_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper), \"GetSdkVersion\", v179 @ X0_v6, v123 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_004e: Expected O, but got I
				//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d7: Expected O, but got Unknown
				//IL_00f4: Expected O, but got I
				//IL_0103: Expected O, but got I
				//IL_009a: Expected O, but got I
				IAndroidWrapper androidWrapper = this.androidWrapper;
				IntPtr intPtr = (IntPtr)androidWrapper;
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00b3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00b3;
				}
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X21_v1 (Il2CppMethodInfo)+48]");
				object obj3 = obj2 + 0;
				int num3 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr + (long)num3;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_0139;
				IL_00b3:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				object obj7 = default(object);
				object obj6 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X3_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xD30C4C", Offset = "0xD30C4C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFDAD8]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C59]) = v40;\nL_0014:\n\tv41 = Facebook.Unity.Mobile.Android.AndroidFacebook::GetAndroidWrapper();\n\tv47 = new Facebook.Unity.CallbackManager();\n\tFacebook.Unity.CallbackManager::.ctor(v47);\n\tFacebook.Unity.Mobile.Android.AndroidFacebook::.ctor(v38, v41, v47);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidFacebook()
		{
			IAndroidWrapper androidWrapper = GetAndroidWrapper();
			CallbackManager callbackManager = new CallbackManager();
			this._002Ector(androidWrapper, callbackManager);
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xD30D70", Offset = "0xD30D70", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F02710]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, androidWrapper, callbackManager, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C5A]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tthis.<CallbackManager>k__BackingField = callbackManager;\n\tthis.androidWrapper = androidWrapper;\n\tthis.<KeyHash>k__BackingField = v50.Empty;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidFacebook(IAndroidWrapper androidWrapper, CallbackManager callbackManager)
		{
			CallbackManager = callbackManager;
			this.androidWrapper = androidWrapper;
			_003CKeyHash_003Ek__BackingField = string.Empty;
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xD2B368", Offset = "0xD2B368", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC86D0]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, appId, hideUnityDelegate, onInitComplete, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C5E]) = v44;\nL_0017:\n\tv45 = Facebook.Unity.Constants::get_UnitySDKUserAgentSuffixLegacy();\n\t// 30 NewArr v52 @ X0_v4 (System.Object[]), typeof(System.Object[]), 0\n\tv56 = System.String::Format(v45, v52);\n\tFacebook.Unity.Mobile.Android.AndroidFacebook::CallFB(v42, \"SetUserAgentSuffix\", v56);\n\tv42.onInitCompleteDelegate = onInitComplete;\n\tv65 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v65);\n\tFacebook.Unity.MethodArguments::AddString(v65, \"appId\", appId);\n\tv86 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>::.ctor(v86, v42, \"Init\");\n\tv87 = Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1::Call(v86, v65);\n\tv93 = v42.androidWrapper;\n\tv171 = *([v93 @ X20_v4 (Facebook.Unity.Mobile.Android.IAndroidWrapper)]);\n\tv172 = Il2CppMethodInfo;\n\tv155 = *([v171 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]) == 0;\n\tif (v155) goto L_0078;\n\tv219 = *([v171 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]) + 8;\nL_0064:\n\tv224 = *([v219 @ X11_v5-8]) == Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>;\n\tif (v224) goto L_007B;\n\tv218 = v218 + 1;\n\tv229 = v218 < *([v171 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]);\n\tv201 = ~v229;\n\tv219 = v219 + 0x10;\n\tv185 = ~v201;\n\tif (v185) goto L_0064;\nL_0078:\n\tv236 = 0x8909C4(v93, Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>, *([v172 @ X22_v3 (Il2CppMethodInfo)+48]), Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0081;\nL_007B:\n\tv231 = *([v219 @ X11_v5]) + *([v172 @ X22_v3 (Il2CppMethodInfo)+48]);\n\tv232 = v231 << 4;\n\tv233 = v171 + v232;\n\tv236 = v233 + 0x130;\nL_0081:\n\tv240 = 0x8D8294(*([v236 @ X0_v18+8]), Il2CppMethodInfo, *([v172 @ X22_v3 (Il2CppMethodInfo)+48]), Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\t*([v240 @ X0_v20])(v153, v93, \"GetUserID\", v240, Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv42.userID = v153;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(string appId, HideUnityDelegate hideUnityDelegate, InitDelegate onInitComplete)
		{
			//IL_0082: Expected I, but got O
			//IL_00c3: Expected O, but got I
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected O, but got Unknown
			//IL_0169: Expected O, but got I
			//IL_0178: Expected O, but got I
			//IL_010f: Expected O, but got I
			string unitySDKUserAgentSuffixLegacy = Constants.UnitySDKUserAgentSuffixLegacy;
			object[] args = new object[0];
			string args2 = string.Format(unitySDKUserAgentSuffixLegacy, args);
			CallFB("SetUserAgentSuffix", args2);
			onInitCompleteDelegate = onInitComplete;
			MethodArguments methodArguments = new MethodArguments();
			methodArguments.AddString("appId", appId);
			JavaMethodCall<IResult> javaMethodCall = new JavaMethodCall<IResult>(this, "Init");
			((JavaMethodCall<>)(object)javaMethodCall).Call(methodArguments);
			IAndroidWrapper androidWrapper = this.androidWrapper;
			IntPtr intPtr = (IntPtr)androidWrapper;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0128;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0128;
			}
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X22_v3 (Il2CppMethodInfo)+48]");
			object obj3 = obj2 + 0;
			int num3 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr + (long)num3;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_01cc;
			IL_0128:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01cc;
			IL_01cc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v240 @ X0_v20] (should have been resolved before IL gen)");
			string text = default(string);
			userID = text;
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xD310FC", Offset = "0xD310FC", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F0A480]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, permissions, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C5F]) = v44;\nL_001A:\n\tv48 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v48);\n\tFacebook.Unity.MethodArguments::AddCommaSeparatedList(v48, \"scope\", permissions);\n\tv66 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>::.ctor(v66, this, \"LoginWithReadPermissions\");\n\tv99 = *([v66 @ X0_v9 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>)]);\n\tv66.<Callback>k__BackingField = callback;\n\tv83 = *([v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+170]);\n\tv88 = *([v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+178]);\n\t// 65 IndirectJump v83 @ X3_v3, v66 @ X0_v9 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>), v66 @ X0_v9 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>), v48 @ X0_v3 (Facebook.Unity.MethodArguments), v88 @ X2_v4, v83 @ X3_v3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogInWithReadPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_0039: Expected I, but got O
			//IL_0056: Expected O, but got I
			//IL_0066: Expected O, but got I
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddCommaSeparatedList("scope", permissions);
				JavaMethodCall<ILoginResult> javaMethodCall = new JavaMethodCall<ILoginResult>(this, "LoginWithReadPermissions");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				javaMethodCall.Callback = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v83 @ X3_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xD311D4", Offset = "0xD311D4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EEABC0]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, permissions, callback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C60]) = v44;\nL_001A:\n\tv48 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v48);\n\tFacebook.Unity.MethodArguments::AddCommaSeparatedList(v48, \"scope\", permissions);\n\tv66 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>::.ctor(v66, this, \"LoginWithPublishPermissions\");\n\tv99 = *([v66 @ X0_v9 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>)]);\n\tv66.<Callback>k__BackingField = callback;\n\tv83 = *([v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+170]);\n\tv88 = *([v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+178]);\n\t// 65 IndirectJump v83 @ X3_v3, v66 @ X0_v9 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>), v66 @ X0_v9 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>), v48 @ X0_v3 (Facebook.Unity.MethodArguments), v88 @ X2_v4, v83 @ X3_v3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogInWithPublishPermissions(IEnumerable<string> permissions, FacebookDelegate<ILoginResult> callback)
		{
			//IL_0039: Expected I, but got O
			//IL_0056: Expected O, but got I
			//IL_0066: Expected O, but got I
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddCommaSeparatedList("scope", permissions);
				JavaMethodCall<ILoginResult> javaMethodCall = new JavaMethodCall<ILoginResult>(this, "LoginWithPublishPermissions");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				javaMethodCall.Callback = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v12 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.ILoginResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v83 @ X3_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xD312AC", Offset = "0xD312AC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEC6D8]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C61]) = v38;\nL_0017:\n\tgoto L_0022;\n\tv44 = *([1ED9370]);\n\tv45 = *([v44 @ X8_v16]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = 0 | 1;\n\t*([2023CAB]) = v49;\nL_0022:\n\tv53.<CurrentAccessToken>k__BackingField = 0;\n\tv57 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>::.ctor(v57, this, \"Logout\");\n\tv67 = *([v57 @ X0_v4 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>)]);\n\tv72 = *([v67 @ X8_v13 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>>)+170]);\n\tv73 = *([v67 @ X8_v13 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>>)+178]);\n\t// 60 IndirectJump v72 @ X3_v2, v57 @ X0_v4 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>), v57 @ X0_v4 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>), 0, v73 @ X2_v2, v72 @ X3_v2, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void LogOut()
		{
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_002d: Expected O, but got I
			while (true)
			{
				AccessToken.CurrentAccessToken = null;
				JavaMethodCall<IResult> javaMethodCall = new JavaMethodCall<IResult>(this, "Logout");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v13 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v13 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v72 @ X3_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0xD31374", Offset = "0xD31374", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0029;\n\tv50 = *([1EB3700]);\n\tv51 = *([v50 @ X8_v34]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([2023C62]) = v64;\nL_0029:\n\tFacebook.Unity.FacebookBase::ValidateAppRequestArgs(this, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v69, v70, v71);\n\tv76 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v76);\n\tFacebook.Unity.MethodArguments::AddString(v76, \"message\", message);\n\tFacebook.Unity.MethodArguments::AddNullablePrimitive(v76, \"action_type\", actionType);\n\tFacebook.Unity.MethodArguments::AddString(v76, \"object_id\", objectId);\n\tFacebook.Unity.MethodArguments::AddCommaSeparatedList(v76, \"to\", to);\n\tv198 = filters == 0;\n\tif (v198) goto L_007C;\n\tv203 = System.Linq.Enumerable::Any(filters);\n\tv227 = v203 == 0;\n\tif (v227) goto L_007C;\n\tv224 = System.Linq.Enumerable::First(filters);\n\tv226 = v224 == 0;\n\tif (v226) goto L_007C;\n\tv204 = *([v224 @ X0_v21 (System.Object)]) != System.String;\n\tif (v204) goto L_007C;\n\tFacebook.Unity.MethodArguments::AddString(v76, \"filters\", v224);\nL_007C:\n\tFacebook.Unity.MethodArguments::AddNullablePrimitive(v76, \"max_recipients\", maxRecipients);\n\tFacebook.Unity.MethodArguments::AddString(v76, \"data\", *([v24 @ X29_v1+10]));\n\tFacebook.Unity.MethodArguments::AddString(v76, \"title\", *([v24 @ X29_v1+18]));\n\tv124 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>::.ctor(v124, this, \"AppRequest\");\n\tv190 = *([v124 @ X0_v16 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>)]);\n\tv124.<Callback>k__BackingField = *([v24 @ X29_v1+20]);\n\tv159 = *([v190 @ X8_v26 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>>)+170]);\n\tv165 = *([v190 @ X8_v26 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>>)+178]);\n\t// 172 IndirectJump v159 @ X3_v6, v124 @ X0_v16 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>), v124 @ X0_v16 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>), v76 @ X0_v3 (Facebook.Unity.MethodArguments), v165 @ X2_v12, v159 @ X3_v6, to @ X4 (System.Collections.Generic.IEnumerable`1<System.String>), filters @ X5 (System.Collections.Generic.IEnumerable`1<System.Object>), excludeIds @ X6 (System.Collections.Generic.IEnumerable`1<System.String>), maxRecipients @ X7 (System.Nullable`1<System.Int32>), v54 @ V0, v55 @ V1, v56 @ V2, v57 @ V3, v58 @ V4, v59 @ V5, v60 @ V6, v61 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppRequest(string message, OGActionType? actionType, string objectId, IEnumerable<string> to, IEnumerable<object> filters, IEnumerable<string> excludeIds, int? maxRecipients, string data, string title, FacebookDelegate<IAppRequestResult> callback)
		{
			//IL_013d: Expected O, but got I
			//IL_015c: Expected O, but got I
			//IL_017e: Expected I, but got O
			//IL_0193: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_01b3: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			string data2 = default(string);
			string title2 = default(string);
			FacebookDelegate<IAppRequestResult> callback2 = default(FacebookDelegate<IAppRequestResult>);
			while (true)
			{
				ValidateAppRequestArgs(message, actionType, objectId, to, filters, excludeIds, maxRecipients, data2, title2, callback2);
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddString("message", message);
				methodArguments.AddNullablePrimitive("action_type", actionType);
				methodArguments.AddString("object_id", objectId);
				methodArguments.AddCommaSeparatedList("to", to);
				if (filters != null && filters.Any())
				{
					object obj3 = filters.First();
					if (obj3 != null && (object)obj3.GetType() == typeof(string))
					{
						methodArguments.AddString("filters", (string)obj3);
					}
				}
				methodArguments.AddNullablePrimitive("max_recipients", maxRecipients);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
				methodArguments.AddString("data", (string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
				methodArguments.AddString("title", (string)0);
				JavaMethodCall<IAppRequestResult> javaMethodCall = new JavaMethodCall<IAppRequestResult>(this, "AppRequest");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
				javaMethodCall.Callback = (FacebookDelegate<IAppRequestResult>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X8_v26 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>>)+170]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X8_v26 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppRequestResult>>)+178]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v159 @ X3_v6 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xD315B0", Offset = "0xD315B0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1EA3638]);\n\tv39 = *([v38 @ X8_v21]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, contentURL, contentTitle, contentDescription, photoURL, callback, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2023C63]) = v53;\nL_0020:\n\tv57 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v57);\n\tFacebook.Unity.MethodArguments::AddUri(v57, \"content_url\", contentURL);\n\tFacebook.Unity.MethodArguments::AddString(v57, \"content_title\", contentTitle);\n\tFacebook.Unity.MethodArguments::AddString(v57, \"content_description\", contentDescription);\n\tFacebook.Unity.MethodArguments::AddUri(v57, \"photo_url\", photoURL);\n\tv75 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>::.ctor(v75, this, \"ShareLink\");\n\tv119 = *([v75 @ X0_v12 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>)]);\n\tv75.<Callback>k__BackingField = callback;\n\tv97 = *([v119 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+170]);\n\tv102 = *([v119 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+178]);\n\t// 92 IndirectJump v97 @ X3_v3, v75 @ X0_v12 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>), v75 @ X0_v12 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>), v57 @ X0_v3 (Facebook.Unity.MethodArguments), v102 @ X2_v7, v97 @ X3_v3, photoURL @ X4 (System.Uri), callback @ X5 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>), methodInfo @ X6 (Il2CppMethodInfo), v42 @ X7, v43 @ V0, v44 @ V1, v45 @ V2, v46 @ V3, v47 @ V4, v48 @ V5, v49 @ V6, v50 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ShareLink(Uri contentURL, string contentTitle, string contentDescription, Uri photoURL, FacebookDelegate<IShareResult> callback)
		{
			//IL_0074: Expected I, but got O
			//IL_0091: Expected O, but got I
			//IL_00a1: Expected O, but got I
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddUri("content_url", contentURL);
				methodArguments.AddString("content_title", contentTitle);
				methodArguments.AddString("content_description", contentDescription);
				methodArguments.AddUri("photo_url", photoURL);
				JavaMethodCall<IShareResult> javaMethodCall = new JavaMethodCall<IShareResult>(this, "ShareLink");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				javaMethodCall.Callback = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v18 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v97 @ X3_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xD316EC", Offset = "0xD316EC", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0026;\n\tv49 = *([1EA67D8]);\n\tv50 = *([v49 @ X8_v27]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2023C64]) = v62;\nL_0026:\n\tv66 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v66);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"toId\", toId);\n\tFacebook.Unity.MethodArguments::AddUri(v66, \"link\", link);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"linkName\", linkName);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"linkCaption\", linkCaption);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"linkDescription\", linkDescription);\n\tFacebook.Unity.MethodArguments::AddUri(v66, \"picture\", picture);\n\tFacebook.Unity.MethodArguments::AddString(v66, \"mediaSource\", mediaSource);\n\tv84 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>::.ctor(v84, this, \"FeedShare\");\n\tv134 = *([v84 @ X0_v15 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>)]);\n\tv84.<Callback>k__BackingField = *([v24 @ X29_v1+10]);\n\tv106 = *([v134 @ X8_v24 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+170]);\n\tv111 = *([v134 @ X8_v24 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+178]);\n\t// 119 IndirectJump v106 @ X3_v3, v84 @ X0_v15 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>), v84 @ X0_v15 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>), v66 @ X0_v3 (Facebook.Unity.MethodArguments), v111 @ X2_v10, v106 @ X3_v3, linkCaption @ X4 (System.String), linkDescription @ X5 (System.String), picture @ X6 (System.Uri), mediaSource @ X7 (System.String), v52 @ V0, v53 @ V1, v54 @ V2, v55 @ V3, v56 @ V4, v57 @ V5, v58 @ V6, v59 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FeedShare(string toId, Uri link, string linkName, string linkCaption, string linkDescription, Uri picture, string mediaSource, FacebookDelegate<IShareResult> callback)
		{
			//IL_00bc: Expected I, but got O
			//IL_00d1: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_00f1: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				methodArguments.AddString("toId", toId);
				methodArguments.AddUri("link", link);
				methodArguments.AddString("linkName", linkName);
				methodArguments.AddString("linkCaption", linkCaption);
				methodArguments.AddString("linkDescription", linkDescription);
				methodArguments.AddUri("picture", picture);
				methodArguments.AddString("mediaSource", mediaSource);
				JavaMethodCall<IShareResult> javaMethodCall = new JavaMethodCall<IShareResult>(this, "FeedShare");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
				javaMethodCall.Callback = (FacebookDelegate<IShareResult>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v24 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+170]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v24 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IShareResult>>)+178]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v106 @ X3_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xD31884", Offset = "0xD31884", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED0D80]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C65]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>::.ctor(v45, this, \"GetAppLink\");\n\tv55 = *([v45 @ X0_v3 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>)]);\n\tv45.<Callback>k__BackingField = callback;\n\tv60 = *([v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+170]);\n\tv61 = *([v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+178]);\n\t// 48 IndirectJump v60 @ X3_v2, v45 @ X0_v3 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>), v45 @ X0_v3 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>), 0, v61 @ X2_v2, v60 @ X3_v2, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_002a: Expected O, but got I
			//IL_003a: Expected O, but got I
			while (true)
			{
				JavaMethodCall<IAppLinkResult> javaMethodCall = new JavaMethodCall<IAppLinkResult>(this, "GetAppLink");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				javaMethodCall.Callback = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X3_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0xD31924", Offset = "0xD31924", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EDA8D8]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, logEvent, valueToSum, parameters, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023C66]) = v47;\nL_001D:\n\tv52 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v52);\n\tFacebook.Unity.MethodArguments::AddString(v52, \"logEvent\", logEvent);\n\tv85 = valueToSum & 0xFF00000000;\n\tv86 = v85 == 0;\n\tif (v86) goto L_FFFFFFFF;\n\tgoto L_003C;\n\tv122 = *([v90 @ X0_v15+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_003C;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v90, v59, v58, parameters, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_003C:\n\tv130 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv136 = 0xBCCEFC(&valueToSum @ X2 (System.Nullable`1<System.Single>), v130, 0, parameters, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0046;\nL_0046:\n\tFacebook.Unity.MethodArguments::AddString(v52, \"valueToSum\", v133);\n\tFacebook.Unity.MethodArguments::AddDictionary(v52, \"parameters\", parameters);\n\tv72 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>::.ctor(v72, this, \"LogAppEvent\");\n\tv106 = Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1::Call(v72, v52);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogEvent(string logEvent, float? valueToSum, Dictionary<string, object> parameters)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected I4, but got Unknown
			MethodArguments methodArguments = new MethodArguments();
			methodArguments.AddString("logEvent", logEvent);
			string value;
			if ((int)((_003F?)valueToSum & 0xFF00000000L) != 0)
			{
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEFC (inside System.Single::IsNaN +0x2E4)");
				string text = default(string);
				value = text;
			}
			else
			{
				value = null;
			}
			methodArguments.AddString("valueToSum", value);
			methodArguments.AddDictionary("parameters", parameters);
			JavaMethodCall<IResult> javaMethodCall = new JavaMethodCall<IResult>(this, "LogAppEvent");
			((JavaMethodCall<>)(object)javaMethodCall).Call(methodArguments);
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0xD31A8C", Offset = "0xD31A8C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EB3668]);\n\tv29 = *([v28 @ X8_v24]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, currency, parameters, methodInfo, v32, v33, v34, v35, logPurchase, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023C67]) = v45;\nL_001B:\n\tv49 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v49);\n\tgoto L_002B;\n\tv57 = *([v53 @ X0_v4+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002B;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, currency, parameters, methodInfo, v32, v33, v34, v35, logPurchase, v36, v37, v38, v39, v40, v41, v42);\nL_002B:\n\tv65 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv69 = 0xBCCEFC(&logPurchase @ V0 (System.Single), v65, 0, methodInfo, v32, v33, v34, v35, logPurchase, v36, v37, v38, v39, v40, v41, v42);\n\tFacebook.Unity.MethodArguments::AddString(v49, \"logPurchase\", v69);\n\tFacebook.Unity.MethodArguments::AddString(v49, \"currency\", currency);\n\tFacebook.Unity.MethodArguments::AddDictionary(v49, \"parameters\", parameters);\n\tv86 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IResult>::.ctor(v86, this, \"LogAppEvent\");\n\tv115 = Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1::Call(v86, v49);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogPurchase(float logPurchase, string currency, Dictionary<string, object> parameters)
		{
			MethodArguments methodArguments = new MethodArguments();
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEFC (inside System.Single::IsNaN +0x2E4)");
			string value = default(string);
			methodArguments.AddString("logPurchase", value);
			methodArguments.AddString("currency", currency);
			methodArguments.AddDictionary("parameters", parameters);
			JavaMethodCall<IResult> javaMethodCall = new JavaMethodCall<IResult>(this, "LogAppEvent");
			((JavaMethodCall<>)(object)javaMethodCall).Call(methodArguments);
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0xD31BD8", Offset = "0xD31BD8", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFF148]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C68]) = v40;\nL_0014:\n\tv41 = this.androidWrapper;\n\tv45 = *([v41 @ X19_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper)]);\n\tv46 = Il2CppMethodInfo;\n\tv53 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]) == 0;\n\tif (v53) goto L_003F;\n\tv108 = *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]) + 8;\nL_002B:\n\tv113 = *([v108 @ X11_v5-8]) == Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>;\n\tif (v113) goto L_0042;\n\tv107 = v107 + 1;\n\tv169 = v107 < *([v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]);\n\tv87 = ~v169;\n\tv108 = v108 + 0x10;\n\tv63 = ~v87;\n\tif (v63) goto L_002B;\nL_003F:\n\tv175 = 0x8909C4(v41, Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>, *([v46 @ X21_v1 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0048;\nL_0042:\n\tv171 = *([v108 @ X11_v5]) + *([v46 @ X21_v1 (Il2CppMethodInfo)+48]);\n\tv172 = v171 << 4;\n\tv173 = v45 + v172;\n\tv175 = v173 + 0x130;\nL_0048:\n\tv179 = 0x8D8294(*([v175 @ X0_v4+8]), Il2CppMethodInfo, *([v46 @ X21_v1 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv123 = *([v179 @ X0_v6]);\n\t// 84 IndirectJump v123 @ X3_v1, v41 @ X19_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper), v41 @ X19_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper), \"IsImplicitPurchaseLoggingEnabled\", v179 @ X0_v6, v123 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool IsImplicitPurchaseLoggingEnabled()
		{
			//IL_000d: Expected I, but got O
			//IL_004e: Expected O, but got I
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00f4: Expected O, but got I
			//IL_0103: Expected O, but got I
			//IL_009a: Expected O, but got I
			IAndroidWrapper androidWrapper = this.androidWrapper;
			IntPtr intPtr = (IntPtr)androidWrapper;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b3;
			}
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X21_v1 (Il2CppMethodInfo)+48]");
			object obj3 = obj2 + 0;
			int num3 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr + (long)num3;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_0139;
			IL_00b3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0139;
			IL_0139:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
			object obj7 = default(object);
			object obj6 = obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0xD31CC0", Offset = "0xD31CC0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EBF938]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, appId, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C69]) = v38;\nL_001D:\n\tFacebook.Unity.Mobile.Android.AndroidFacebook::CallFB(this, \"ActivateApp\", 0);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ActivateApp(string appId)
		{
			CallFB("ActivateApp", null);
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0xD31D14", Offset = "0xD31D14", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EE64B0]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023C6A]) = v43;\nL_0019:\n\tv47 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v47);\n\tv52 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>::.ctor(v52, this, \"FetchDeferredAppLinkData\");\n\tv62 = *([v52 @ X0_v5 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>)]);\n\tv52.<Callback>k__BackingField = callback;\n\tv67 = *([v62 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+170]);\n\tv68 = *([v62 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+178]);\n\t// 56 IndirectJump v67 @ X3_v2, v52 @ X0_v5 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>), v52 @ X0_v5 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>), v47 @ X0_v3 (Facebook.Unity.MethodArguments), v68 @ X2_v2, v67 @ X3_v2, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			//IL_0012: Expected I, but got O
			//IL_002f: Expected O, but got I
			//IL_003f: Expected O, but got I
			while (true)
			{
				MethodArguments methodArguments = new MethodArguments();
				JavaMethodCall<IAppLinkResult> javaMethodCall = new JavaMethodCall<IAppLinkResult>(this, "FetchDeferredAppLinkData");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				javaMethodCall.Callback = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v9 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAppLinkResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ X3_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0xD31DCC", Offset = "0xD31DCC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EAE700]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C6B]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>();\n\tFacebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>::.ctor(v45, this, \"RefreshCurrentAccessToken\");\n\tv55 = *([v45 @ X0_v3 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>)]);\n\tv45.<Callback>k__BackingField = callback;\n\tv60 = *([v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>>)+170]);\n\tv61 = *([v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>>)+178]);\n\t// 48 IndirectJump v60 @ X3_v2, v45 @ X0_v3 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>), v45 @ X0_v3 (Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>), 0, v61 @ X2_v2, v60 @ X3_v2, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void RefreshCurrentAccessToken(FacebookDelegate<IAccessTokenRefreshResult> callback)
		{
			//IL_000d: Expected I, but got O
			//IL_002a: Expected O, but got I
			//IL_003a: Expected O, but got I
			while (true)
			{
				JavaMethodCall<IAccessTokenRefreshResult> javaMethodCall = new JavaMethodCall<IAccessTokenRefreshResult>(this, "RefreshCurrentAccessToken");
				IntPtr intPtr = (IntPtr)javaMethodCall;
				javaMethodCall.Callback = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v7 (Il2CppClass<Facebook.Unity.Mobile.Android.AndroidFacebook+JavaMethodCall`1<Facebook.Unity.IAccessTokenRefreshResult>>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X3_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0xD31E6C", Offset = "0xD31E6C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE98B8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, mode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C6C]) = v41;\nL_0019:\n\t// 25 Box v46 @ X0_v3, typeof(Facebook.Unity.ShareDialogMode), &mode @ X1 (Facebook.Unity.ShareDialogMode)\n\tv49 = *([v46 @ X0_v3]);\n\t*([v49 @ X8_v5+160])(v53, v46, *([v49 @ X8_v5+168]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = \"il2cpp_vm_object_unbox\"(v46, *([v49 @ X8_v5+168]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tFacebook.Unity.Mobile.Android.AndroidFacebook::CallFB(this, \"SetShareDialogMode\", v53);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SetShareDialogMode(ShareDialogMode mode)
		{
			object obj = mode;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ X8_v5+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string args = default(string);
			CallFB("SetShareDialogMode", args);
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0xD30CC4", Offset = "0xD30CC4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EACD00]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023C6D]) = v37;\nL_0016:\n\tv42 = System.Reflection.Assembly::Load(\"Facebook.Unity.Android\");\n\tv50 = System.Reflection.Assembly::GetType(v42, \"Facebook.Unity.Android.AndroidWrapper\");\n\tv52 = System.Activator::CreateInstance(v50);\n\tv55 = v52 == 0;\n\tif (v55) goto L_0032;\n\t// 42 IsInst returnVal1 @ X0_v10 (Facebook.Unity.Mobile.Android.IAndroidWrapper), typeof(Facebook.Unity.Mobile.Android.IAndroidWrapper), v52 @ X0_v9 (System.Object)\n\tv66 = returnVal1 == 0;\n\tif (v66) goto L_0036;\nL_0032:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0036:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IAndroidWrapper GetAndroidWrapper()
		{
			Assembly assembly = Assembly.Load("Facebook.Unity.Android");
			Type type = assembly.GetType("Facebook.Unity.Android.AndroidWrapper");
			object obj = Activator.CreateInstance(type);
			bool flag = obj == null;
			IAndroidWrapper androidWrapper = (IAndroidWrapper)obj;
			if (!flag)
			{
				androidWrapper = obj as IAndroidWrapper;
				if (androidWrapper == null)
				{
					return (IAndroidWrapper)new InvalidCastException();
				}
			}
			return androidWrapper;
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0xD30EA0", Offset = "0xD30EA0", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ED83D8]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, method, args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C6E]) = v44;\nL_0018:\n\tv46 = this.androidWrapper;\n\t// 28 NewArr v50 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv53 = args == 0;\n\tif (v53) goto L_0029;\n\tv55 = *([v50 @ X0_v3 (System.Object[])]);\n\tv58 = \"il2cpp_codegen_object_is_inst\"(args, *([v55 @ X8_v13+40]), args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0029:\n\tv65 = v50.Length == 0;\n\tif (v65) goto L_0067;\n\tv50[0] = args;\n\tv79 = *([v46 @ X20_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper)]);\n\tv83 = *([v79 @ X8_v10 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]) == 0;\n\tif (v83) goto L_0052;\n\tv143 = *([v79 @ X8_v10 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]) + 8;\nL_003D:\n\tv149 = *([v143 @ X11_v5-8]) == Facebook.Unity.Mobile.Android.IAndroidWrapper;\n\tif (v149) goto L_0055;\n\tv144 = v144 + 1;\n\tv210 = v144 < *([v79 @ X8_v10 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]);\n\tv123 = ~v210;\n\tv143 = v143 + 0x10;\n\tv99 = ~v123;\n\tif (v99) goto L_003D;\nL_0052:\n\tv217 = 0x8909C4(v46, Facebook.Unity.Mobile.Android.IAndroidWrapper, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0059;\nL_0055:\n\tv212 = *([v143 @ X11_v5]) + 1;\n\tv213 = v212 << 4;\n\tv214 = v79 + v213;\n\tv217 = v214 + 0x130;\nL_0059:\n\tv159 = *([v217 @ X0_v14]);\n\tv157 = *([v217 @ X0_v14+8]);\n\t// 101 IndirectJump v159 @ X4_v1, v46 @ X20_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper), v46 @ X20_v2 (Facebook.Unity.Mobile.Android.IAndroidWrapper), method @ X1 (System.String), v50 @ X0_v3 (System.Object[]), v157 @ X3_v1, v159 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tv54 = new System.NullReferenceException();\nL_0067:\n\tv70 = new System.IndexOutOfRangeException();\n\tgoto L_006E;\n\tv74 = new System.NullReferenceException();\n\tv77 = new System.ArrayTypeMismatchException();\nL_006E:\n\tthrow v86;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CallFB(string method, string args)
		{
			//IL_0077: Expected I, but got O
			//IL_01d7: Expected O, but got I
			//IL_00b2: Expected O, but got I
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Expected O, but got Unknown
			//IL_0151: Expected O, but got I
			//IL_0160: Expected O, but got I
			//IL_00fe: Expected O, but got I
			IAndroidWrapper androidWrapper = this.androidWrapper;
			object[] array = new object[1];
			if (args != null)
			{
				object obj = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
			}
			object obj5 = default(object);
			if (array.Length != 0)
			{
				array[0] = args;
				IntPtr intPtr = (IntPtr)androidWrapper;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v10 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0117;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v10 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+B0]");
				object obj2 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IAndroidWrapper))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X8_v10 (Il2CppClass<Facebook.Unity.Mobile.Android.IAndroidWrapper>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj2 = (long)(IntPtr)obj2 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_0117;
				}
				object obj3 = obj2 + 1;
				int num3 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr + (long)num3;
				obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_01bf;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0117:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01bf;
			IL_01bf:
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X0_v14+8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v159 @ X4_v1 (should have been resolved before IL gen)");
		}
	}
}
