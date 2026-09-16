using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000CD")]
	internal static class Util
	{
		[Token(Token = "0x40003BB")]
		public static readonly DateTime UnixEpoch;

		[Token(Token = "0x6000775")]
		[Address(RVA = "0xB53A24", Offset = "0xB53A24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsUnityDevelopmentBuild()
		{
			return false;
		}

		[Token(Token = "0x6000776")]
		[Address(RVA = "0xB882D0", Offset = "0xB882D0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFADA8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229FD]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0027;\n\treturn value;\nL_0027:\n\tgoto L_002F;\n\tv77 = *([v51 @ X0_v2+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002F;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\tv85 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv88 = 0x846A20(v85, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv92 = System.Type::ToString(v85);\n\tv97 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v97, v92);\n\tthrow v97;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T NullArgumentTest<T>(T value)
		{
			if (value != null)
			{
				return value;
			}
			Type typeFromHandle = typeof(T);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
			string paramName = typeFromHandle.ToString();
			ArgumentNullException ex = new ArgumentNullException(paramName);
			throw ex;
		}

		[Token(Token = "0x6000777")]
		[Address(RVA = "0xB883B4", Offset = "0xB883B4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA39B8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, paramName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229FE]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0022;\n\treturn value;\nL_0022:\n\tv52 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v52, paramName);\n\tthrow v52;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T NullArgumentTest<T>(T value, string paramName)
		{
			if (value != null)
			{
				return value;
			}
			ArgumentNullException ex = new ArgumentNullException(paramName);
			throw ex;
		}

		[Token(Token = "0x6000778")]
		[Address(RVA = "0xB53A2C", Offset = "0xB53A2C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB87C8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227AD]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Util>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = EasyMobile.Internal.Util;\nL_0023:\n\tv55 = v53.UnixEpoch;\n\tgoto L_0032;\n\tv63 = *([v58 @ X0_v4+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0032;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv72 = System.TimeSpan::FromMilliseconds(millisSinceEpoch);\n\treturnVal1 = 0xE9442C(&v55 @ X8_v6 (System.DateTime), v72, 0, v23, v24, v25, v26, v27, millisSinceEpoch, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static DateTime FromMillisSinceUnixEpoch(long millisSinceEpoch)
		{
			DateTime unixEpoch = UnixEpoch;
			TimeSpan timeSpan = TimeSpan.FromMilliseconds(millisSinceEpoch);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E9442C (inside System.DateTime::TimeToTicks +0x9A4)");
			DateTime result = default(DateTime);
			return result;
		}

		[Token(Token = "0x6000779")]
		[Address(RVA = "0xB53AE4", Offset = "0xB53AE4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAAB98]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227AE]) = v38;\nL_0015:\n\tspan = 0x9B7F4C(&span @ X0 (System.TimeSpan), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv56 = v28 <= 9.223372036854776E+18d;\n\tif (v56) goto L_0033;\n\tgoto L_004B;\nL_0033:\n\tv69 = v28 >= -9.223372036854776E+18d;\n\tif (v69) goto L_003D;\n\tgoto L_004B;\nL_003D:\n\tgoto L_0045;\n\tv98 = *([v94 @ X0_v5+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0045;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, v40, v22, v23, v24, v25, v26, v27, v59, v43, v30, v31, v32, v33, v34, v35);\nL_0045:\n\treturnVal1 = System.Convert::ToInt64(v28);\nL_004B:\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long ToMilliseconds(TimeSpan span)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9B7F4C (inside System.Threading.ThreadPool::RegisterWaitForSingleObject +0x134)");
			double num = default(double);
			if (num > 9.223372036854776E+18)
			{
				return long.MaxValue;
			}
			if (num < -9.223372036854776E+18)
			{
				return long.MinValue;
			}
			return Convert.ToInt64(num);
		}

		[Token(Token = "0x600077A")]
		[Address(RVA = "0xB53BA0", Offset = "0xB53BA0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBE308]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227AF]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(id);\n\tv43 = v41 == 0;\n\tif (v43) goto L_002D;\n\treturn v49.Empty;\nL_002D:\n\treturnVal2 = System.String::Trim(id);\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AutoTrimId(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return string.Empty;
			}
			return id.Trim();
		}

		[Token(Token = "0x600077B")]
		[Address(RVA = "0xB53C24", Offset = "0xB53C24", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1ED6350]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20227B0]) = v35;\nL_0016:\n\tv37 = 0;\n\tv42 = 0xE93738(&v37 @ stack_-18_v1 (System.DateTime), 0x7B2, 1, 1, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0027;\n\tv49 = *([v45 @ X0_v4+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0027;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, v38, v39, v40, v41, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0027:\n\tv59 = System.DateTime::SpecifyKind(0, 1);\n\tv63.UnixEpoch = v59;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Util()
		{
			DateTime dateTime = default(DateTime);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93738 (inside System.DBNull::.cctor +0x360)");
			DateTime unixEpoch = DateTime.SpecifyKind(default(DateTime), DateTimeKind.Utc);
			UnixEpoch = unixEpoch;
		}
	}
}
