using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;

namespace Facebook.Unity
{
	[Token(Token = "0x2000006")]
	public class AccessToken
	{
		[CompilerGenerated]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x10")]
		private string _003CTokenString_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x18")]
		private DateTime _003CExpirationTime_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x20")]
		private IEnumerable<string> _003CPermissions_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x28")]
		private string _003CUserId_003Ek__BackingField;

		[Token(Token = "0x17000005")]
		[field: Token(Token = "0x4000011")]
		public static AccessToken CurrentAccessToken
		{
			[Token(Token = "0x600001A")]
			[Address(RVA = "0xD1B1D8", Offset = "0xD1B1D8", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EAA3C8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023B50]) = v35;\nL_001A:\n\treturn v41.<CurrentAccessToken>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600001B")]
			[Address(RVA = "0xD1B228", Offset = "0xD1B228", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F09360]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B51]) = v38;\nL_0017:\n\tv42.<CurrentAccessToken>k__BackingField = value;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set;
		}

		[Token(Token = "0x17000006")]
		public string TokenString
		{
			[CompilerGenerated]
			[Token(Token = "0x600001C")]
			[Address(RVA = "0xD1B27C", Offset = "0xD1B27C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TokenString>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TokenString;
			}
			[CompilerGenerated]
			[Token(Token = "0x600001D")]
			[Address(RVA = "0xD1B284", Offset = "0xD1B284", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TokenString>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTokenString_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000007")]
		public DateTime ExpirationTime
		{
			[CompilerGenerated]
			[Token(Token = "0x600001E")]
			[Address(RVA = "0xD1B28C", Offset = "0xD1B28C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ExpirationTime>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ExpirationTime;
			}
			[CompilerGenerated]
			[Token(Token = "0x600001F")]
			[Address(RVA = "0xD1B294", Offset = "0xD1B294", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ExpirationTime>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CExpirationTime_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000008")]
		public IEnumerable<string> Permissions
		{
			[CompilerGenerated]
			[Token(Token = "0x6000020")]
			[Address(RVA = "0xD1B29C", Offset = "0xD1B29C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Permissions>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Permissions;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000021")]
			[Address(RVA = "0xD1B2A4", Offset = "0xD1B2A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Permissions>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CPermissions_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000009")]
		public string UserId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000022")]
			[Address(RVA = "0xD1B2AC", Offset = "0xD1B2AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UserId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UserId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000023")]
			[Address(RVA = "0xD1B2B4", Offset = "0xD1B2B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UserId>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CUserId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000A")]
		[field: Token(Token = "0x4000016")]
		[field: FieldOffset(Offset = "0x30")]
		public DateTime? LastRefresh
		{
			[Token(Token = "0x6000024")]
			[Address(RVA = "0xD1B2BC", Offset = "0xD1B2BC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LastRefresh>k__BackingField;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000025")]
			[Address(RVA = "0xD1B2C8", Offset = "0xD1B2C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LastRefresh>k__BackingField = value;\n\t*([this @ X0 (Facebook.Unity.AccessToken)+38]) = methodInfo;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0xD1B04C", Offset = "0xD1B04C", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv42 = *([1EF4350]);\n\tv43 = *([v42 @ X8_v29]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, tokenString, userId, expirationTime, permissions, lastRefresh, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2023B4F]) = v56;\nL_0021:\n\tSystem.Object::.ctor(this);\n\tv61 = System.String::IsNullOrEmpty(tokenString);\n\tv63 = v61 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_005D;\n\tv67 = System.String::IsNullOrEmpty(userId);\n\tv73 = v67 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0064;\n\tgoto L_0041;\n\tv102 = *([v79 @ X0_v15 (Il2CppClass<System.DateTime>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0041;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v79, v66, userId, expirationTime, permissions, lastRefresh, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv106 = System.DateTime;\nL_0041:\n\tv111 = System.DateTime::op_Equality(expirationTime, v109.MinValue);\n\tv134 = v111 == 0;\n\tv120 = ~v134;\n\tif (v120) goto L_006B;\n\tv94 = permissions == 0;\n\tif (v94) goto L_0076;\n\tthis.<TokenString>k__BackingField = tokenString;\n\tthis.<ExpirationTime>k__BackingField = expirationTime;\n\tthis.<Permissions>k__BackingField = permissions;\n\tthis.<UserId>k__BackingField = userId;\n\tthis.<LastRefresh>k__BackingField = lastRefresh;\n\t*([this @ X0 (Facebook.Unity.AccessToken)+38]) = methodInfo;\n\treturn;\nL_005D:\n\tv91 = new System.ArgumentNullException();\n\tgoto L_007C;\nL_0064:\n\tv91 = new System.ArgumentNullException();\n\tgoto L_007C;\nL_006B:\n\tv118 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v118, \"Expiration time is unassigned\");\n\tgoto L_0082;\nL_0076:\n\tv91 = new System.ArgumentNullException();\nL_007C:\n\tSystem.ArgumentNullException::.ctor(v91, *([v95 @ X8_v3 (System.String)]));\nL_0082:\n\tthrow v121;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AccessToken(string tokenString, string userId, DateTime expirationTime, IEnumerable<string> permissions, DateTime? lastRefresh)
		{
			if (!string.IsNullOrEmpty(tokenString))
			{
				if (string.IsNullOrEmpty(userId))
				{
					ArgumentNullException ex = new ArgumentNullException();
					string text = "userId";
				}
				else if (!(expirationTime == DateTime.MinValue))
				{
					if (permissions != null)
					{
						TokenString = tokenString;
						ExpirationTime = expirationTime;
						Permissions = permissions;
						UserId = userId;
						LastRefresh = lastRefresh;
						return;
					}
					ArgumentNullException ex = new ArgumentNullException();
					string text = "permissions";
				}
				else
				{
					ArgumentException ex2 = new ArgumentException("Expiration time is unassigned");
				}
			}
			else
			{
				string text = default(string);
				ArgumentNullException ex = new ArgumentNullException(text);
				text = "tokenString";
			}
			ArgumentNullException ex3 = default(ArgumentNullException);
			throw ex3;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0xD1B2D0", Offset = "0xD1B2D0", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB5708]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023B52]) = v42;\nL_0018:\n\tv46 = System.Object::GetType(this);\n\tv51 = System.Reflection.MemberInfo::get_Name(v46);\n\tv57 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v57);\n\tv81 = Facebook.Unity.Utilities::TotalSeconds(this.<ExpirationTime>k__BackingField);\n\tv73 = 0xDC4024(&v81 @ X0_v12 (System.Int64), 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v57, \"ExpirationTime\", v73);\n\tv126 = Facebook.Unity.Utilities::ToCommaSeparateList(this.<Permissions>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v57, \"Permissions\", v126);\n\tv134 = Facebook.Unity.Utilities::ToStringNullOk(this.<UserId>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v57, \"UserId\", v134);\n\tv142 = this.<LastRefresh>k__BackingField;\n\t// 85 Box v145 @ X0_v23 (System.Object), typeof(System.Nullable`1<System.DateTime>), &v142 @ X8_v16 (System.Nullable`1<System.DateTime>)\n\tv146 = Facebook.Unity.Utilities::ToStringNullOk(v145);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v57, \"LastRefresh\", v146);\n\treturnVal2 = Facebook.Unity.Utilities::FormatToString(0, v51, v57);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			Type type = GetType();
			string name = type.Name;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			long num = ExpirationTime.TotalSeconds();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC4024 (inside System.Int32::TryParse +0x8C8)");
			string value = default(string);
			dictionary.Add("ExpirationTime", value);
			string value2 = Permissions.ToCommaSeparateList();
			dictionary.Add("Permissions", value2);
			string value3 = UserId.ToStringNullOk();
			dictionary.Add("UserId", value3);
			DateTime? dateTime = LastRefresh;
			object obj = dateTime;
			string value4 = obj.ToStringNullOk();
			dictionary.Add("LastRefresh", value4);
			return Utilities.FormatToString(null, name, dictionary);
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0xD1B908", Offset = "0xD1B908", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EDAA50]);\n\tv25 = *([v24 @ X8_v31]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023B53]) = v44;\nL_001C:\n\tv51 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v51);\n\tgoto L_0035;\n\tv62 = *([v58 @ X0_v4 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0035;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v58, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv66 = Facebook.Unity.LoginResult;\nL_0035:\n\tv75 = System.Linq.Enumerable::ToArray(this.<Permissions>k__BackingField);\n\tv83 = System.String::Join(\",\", v75);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v51, v70.PermissionsKey, v83);\n\tv97 = Facebook.Unity.Utilities::TotalSeconds(this.<ExpirationTime>k__BackingField);\n\tv101 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(&v97 @ X0_v14 (System.Int64), 0, v83);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v51, v70.ExpirationTimestampKey, v101);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v51, v70.AccessTokenKey, this.<TokenString>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v51, v70.UserIdKey, this.<UserId>k__BackingField);\n\tv155 = this.<LastRefresh>k__BackingField;\n\tv156 = *([this @ X0 (Facebook.Unity.AccessToken)+38]) & 0xFF;\n\tv159 = v156 == 0;\n\tif (v159) goto L_0082;\n\tv166 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(&v155 @ X8_v19 (System.Nullable`1<System.DateTime>), Il2CppMethodInfo, this.<UserId>k__BackingField);\n\tv181 = Facebook.Unity.Utilities::TotalSeconds(v166);\n\tv190 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(&v181 @ X0_v28 (System.Int64), 0, this.<UserId>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v51, \"last_refresh\", v190);\nL_0082:\n\tgoto L_0089;\n\tv182 = *([v177 @ X0_v21+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0089;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v177, v126, v122, v118, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0089:\n\treturnVal2 = Facebook.MiniJSON.Json+Serializer::Serialize(v51);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal string ToJson()
		{
			//IL_0039: Expected O, but got I8
			//IL_00cc: Expected O, but got I
			//IL_00ee: Expected O, but got I8
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string[] value = Permissions.ToArray();
			string value2 = string.Join(",", value);
			dictionary.set_Item(LoginResult.PermissionsKey, value2);
			long num = ExpirationTime.TotalSeconds();
			((Dictionary<string, string>)num).set_Item((string)null, value2);
			string value3 = default(string);
			dictionary.set_Item(LoginResult.ExpirationTimestampKey, value3);
			dictionary.set_Item(LoginResult.AccessTokenKey, TokenString);
			dictionary.set_Item(LoginResult.UserIdKey, UserId);
			DateTime? dateTime = LastRefresh;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Facebook.Unity.AccessToken)+38]");
			if (0u != 0)
			{
				((Dictionary<string, string>)dateTime).set_Item((string)0, UserId);
				DateTime dateTime2 = default(DateTime);
				long num2 = dateTime2.TotalSeconds();
				((Dictionary<string, string>)num2).set_Item((string)null, UserId);
				string value4 = default(string);
				dictionary.set_Item("last_refresh", value4);
			}
			return Json.Serializer.Serialize(dictionary);
		}
	}
}
