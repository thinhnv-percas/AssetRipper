using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000031")]
	internal class LoginResult : ResultBase, ILoginResult, IResult
	{
		[Token(Token = "0x4000053")]
		public static readonly string UserIdKey;

		[Token(Token = "0x4000054")]
		public static readonly string ExpirationTimestampKey;

		[Token(Token = "0x4000055")]
		public static readonly string PermissionsKey;

		[Token(Token = "0x4000056")]
		public static readonly string AccessTokenKey;

		[CompilerGenerated]
		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x48")]
		private AccessToken _003CAccessToken_003Ek__BackingField;

		[Token(Token = "0x17000043")]
		public AccessToken AccessToken
		{
			[CompilerGenerated]
			[Token(Token = "0x6000102")]
			[Address(RVA = "0xD305E8", Offset = "0xD305E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AccessToken>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AccessToken;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000103")]
			[Address(RVA = "0xD305F0", Offset = "0xD305F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AccessToken>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CAccessToken_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0xD20DC8", Offset = "0xD20DC8", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EAB038]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C4E]) = v41;\nL_0017:\n\tFacebook.Unity.ResultBase::.ctor(this, resultContainer);\n\tv48 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv49 = v48 == 0;\n\tif (v49) goto L_0077;\n\tv54 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tgoto L_0037;\n\tv125 = *([v58 @ X8_v6 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\t// 47 ConditionalJump @b22, v127 @ TEMP_v14\n\tv160 = v58;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v160, v53, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv133 = Facebook.Unity.LoginResult;\nL_0037:\n\tv163 = *([v54 @ X0_v7 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv167 = *([v163 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v167) goto L_005B;\n\tv209 = *([v163 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_0046:\n\tv215 = *([v209 @ X11_v6-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v215) goto L_005E;\n\tv210 = v210 + 1;\n\tv220 = v210 < *([v163 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv191 = ~v220;\n\tv209 = v209 + 0x10;\n\tv175 = ~v191;\n\tif (v175) goto L_0046;\nL_005B:\n\tv227 = 0x8909C4(v54, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0066;\nL_005E:\n\tv222 = *([v209 @ X11_v6]) + 3;\n\tv223 = v222 << 4;\n\tv224 = v163 + v223;\n\tv227 = v224 + 0x130;\nL_0066:\n\t*([v227 @ X0_v11])(v111, v54, v162.AccessTokenKey, *([v227 @ X0_v11+8]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv230 = v111 & 1;\n\tv113 = v230 == 0;\n\tif (v113) goto L_0077;\n\tv232 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv110 = Facebook.Unity.Utilities::ParseAccessTokenFromResult(v232);\n\tthis.<AccessToken>k__BackingField = v110;\nL_0077:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal LoginResult(ResultContainer resultContainer)
		{
			//IL_001c: Expected I, but got O
			//IL_0057: Expected O, but got I
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00fb: Expected O, but got I
			//IL_010a: Expected O, but got I
			//IL_00a3: Expected O, but got I
			base._002Ector(resultContainer);
			IDictionary<string, object> resultDictionary = base.ResultDictionary;
			if (resultDictionary == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)base.ResultDictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X8_v8 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bc;
			}
			object obj2 = (long)(IntPtr)(object)((long)intPtr + (long)(int)((long)(IntPtr)(object)(obj + 3) << 4)) + 304L;
			goto IL_0192;
			IL_0192:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v227 @ X0_v11] (should have been resolved before IL gen)");
			object obj3 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
			{
				AccessToken = Utilities.ParseAccessTokenFromResult(base.ResultDictionary);
			}
			return;
			IL_00bc:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0192;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0xD305F8", Offset = "0xD305F8", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDE2B0]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023C4F]) = v42;\nL_0016:\n\tv44 = Facebook.Unity.ResultBase::ToString(this);\n\tv48 = System.Object::GetType(this);\n\tv53 = System.Reflection.MemberInfo::get_Name(v48);\n\tv59 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v59);\n\tv73 = Facebook.Unity.Utilities::ToStringNullOk(this.<AccessToken>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v59, \"AccessToken\", v73);\n\treturnVal2 = Facebook.Unity.Utilities::FormatToString(v44, v53, v59);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string baseString = base.ToString();
			Type type = GetType();
			string name = type.Name;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value = AccessToken.ToStringNullOk();
			dictionary.Add("AccessToken", value);
			return Utilities.FormatToString(baseString, name, dictionary);
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0xD306DC", Offset = "0xD306DC", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EF1198]);\n\tv15 = *([v14 @ X8_v28]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C50]) = v35;\nL_0011:\n\tv36 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv52 = v36 != 3;\n\tif (v52) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tv58.UserIdKey = *([v55 @ X8_v5 (System.String)]);\n\tv59 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv74 = v59 != 3;\n\tif (v74) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tv79.ExpirationTimestampKey = *([v77 @ X8_v9 (System.String)]);\n\tv80 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv95 = v80 != 3;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_005A;\nL_005A:\n\tv100.PermissionsKey = *([v98 @ X8_v13 (System.String)]);\n\tv101 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv116 = v101 != 3;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_0072;\nL_0072:\n\tv121.AccessTokenKey = *([v119 @ X8_v17 (System.String)]);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LoginResult()
		{
			FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
			string userIdKey = ((currentPlatform != FacebookUnityPlatform.WebGL) ? "user_id" : "userID");
			UserIdKey = userIdKey;
			FacebookUnityPlatform currentPlatform2 = Constants.CurrentPlatform;
			string expirationTimestampKey = ((currentPlatform2 != FacebookUnityPlatform.WebGL) ? "expiration_timestamp" : "expiresIn");
			ExpirationTimestampKey = expirationTimestampKey;
			FacebookUnityPlatform currentPlatform3 = Constants.CurrentPlatform;
			string permissionsKey = ((currentPlatform3 != FacebookUnityPlatform.WebGL) ? "permissions" : "grantedScopes");
			PermissionsKey = permissionsKey;
			FacebookUnityPlatform currentPlatform4 = Constants.CurrentPlatform;
			string accessTokenKey = ((currentPlatform4 != FacebookUnityPlatform.WebGL) ? "access_token" : "accessToken");
			AccessTokenKey = accessTokenKey;
		}
	}
}
