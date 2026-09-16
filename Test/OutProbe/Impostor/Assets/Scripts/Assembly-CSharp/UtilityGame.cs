using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.Storage;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200000F")]
public class UtilityGame
{
	[Token(Token = "0x400002E")]
	public const string DataCreatePlayerObscured = "dataCreatePlayerObscured";

	[Token(Token = "0x400002F")]
	public static bool IsGamePause;

	[Token(Token = "0x17000006")]
	public static bool IsNoneConnectInternet
	{
		[Token(Token = "0x600005C")]
		[Address(RVA = "0xBF8F08", Offset = "0xBF8F08", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A355CD]) = v34;\nL_0015:\n\tgoto L_0018;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0018:\n\tv42 = UnityEngine.Application::get_internetReachability();\n\tv49 = v42 == 0;\n\treturn v49;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			NetworkReachability internetReachability = Application.internetReachability;
			return internetReachability == NetworkReachability.NotReachable;
		}
	}

	[Token(Token = "0x600005A")]
	[Address(RVA = "0xBF8E5C", Offset = "0xBF8E5C", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = UtilityGame;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A355CB]) = v34;\nL_0013:\n\tUnityEngine.Time::set_timeScale(0f);\n\tv41.IsGamePause = 1;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void PauseGame()
	{
		Time.timeScale = 0f;
		IsGamePause = true;
	}

	[Token(Token = "0x600005B")]
	[Address(RVA = "0xBF8EB4", Offset = "0xBF8EB4", Length = "0x54")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = UtilityGame;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A355CC]) = v34;\nL_0013:\n\tUnityEngine.Time::set_timeScale(1f);\n\tv40.IsGamePause = 0;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void UnPauseGame()
	{
		Time.timeScale = 1f;
		IsGamePause = false;
	}

	[Token(Token = "0x600005D")]
	[Address(RVA = "0xBF8F64", Offset = "0xBF8F64", Length = "0xFC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv14 = DataCreatePlayer;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv54 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv61 = \"\";\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv66 = \"dataCreatePlayerObscured\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A355CE]) = v35;\nL_0025:\n\tgoto L_002A;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002A:\n\tv52 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetString(\"dataCreatePlayerObscured\", \"\");\n\tv59 = System.String::op_Inequality(v52, \"\");\n\tv64 = v59 == 0;\n\tif (v64) goto L_004E;\n\tv70 = v52._stringLength < 1;\n\tif (v70) goto L_004E;\n\treturnVal3 = UnityEngine.JsonUtility::FromJson(v52);\n\treturn returnVal3;\nL_004E:\n\tv101 = new DataCreatePlayer();\n\tDataCreatePlayer::.ctor(v101);\n\treturn v101;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static DataCreatePlayer LoadDataCreatePlayer()
	{
		string text = ObscuredPrefs.GetString("dataCreatePlayerObscured");
		if (text != "" && text.Length >= 1)
		{
			return JsonUtility.FromJson<DataCreatePlayer>(text);
		}
		return new DataCreatePlayer();
	}

	[Token(Token = "0x600005E")]
	[Address(RVA = "0xBF90BC", Offset = "0xBF90BC", Length = "0x84")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"dataCreatePlayerObscured\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355CF]) = v38;\nL_001A:\n\tv43 = UnityEngine.JsonUtility::ToJson(userData);\n\tgoto L_002B;\n\tv51 = v46;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v51, v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002B:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetString(\"dataCreatePlayerObscured\", v43);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void SaveUserData(DataCreatePlayer userData)
	{
		string value = JsonUtility.ToJson(userData);
		ObscuredPrefs.SetString("dataCreatePlayerObscured", value);
	}

	[Token(Token = "0x600005F")]
	[Address(RVA = "0xBF9140", Offset = "0xBF9140", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::Format(format, args);\n\treturn returnVal1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0033;\n\tX0 = X19;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = *([1936330]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX1 = *([X8]);\n\tX0 = 0xAD9AE8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0029;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([1936338]);\n\tX30 = stack[0];\n\tX19 = stack[8];\n\t// 38 ShiftStack 16\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\nL_0029:\n\tX0 = 8;\n\tX0 = 0x1854E90(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0xF88;\n\tX2 = 0;\n\tX0 = 0x1854EA0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0033:\n\tX0 = X19;\n\tX0 = 0xBD3CD0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x9DACB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static string Format(string format, params object[] args)
	{
		return string.Format(format, args);
	}

	[Token(Token = "0x6000060")]
	[Address(RVA = "0xBF91D0", Offset = "0xBF91D0", Length = "0x114")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = System.String::Substring(time, 0, 4);\n\tv38 = System.Int32::Parse(v20);\n\tv44 = System.String::Substring(time, 4, 2);\n\tv79 = System.Int32::Parse(v44);\n\tv85 = System.String::Substring(time, 6, 2);\n\tv87 = System.Int32::Parse(v85);\n\tv93 = System.String::Substring(time, 8, 2);\n\tv95 = System.Int32::Parse(v93);\n\tv101 = System.String::Substring(time, 0xA, 2);\n\tv103 = System.Int32::Parse(v101);\n\tv109 = System.String::Substring(time, 0xC, 2);\n\tv111 = System.Int32::Parse(v109);\n\tv48 = 0;\n\tSystem.DateTime::.ctor(&v48 @ stack_-38_v1 (System.DateTime), v38, v79, v87, v95, v103, v111);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static DateTime ConvertStringTime(string time)
	{
		string s = time.Substring(0, 4);
		int year = int.Parse(s);
		string s2 = time.Substring(4, 2);
		int month = int.Parse(s2);
		string s3 = time.Substring(6, 2);
		int day = int.Parse(s3);
		string s4 = time.Substring(8, 2);
		int hour = int.Parse(s4);
		string s5 = time.Substring(10, 2);
		int minute = int.Parse(s5);
		string s6 = time.Substring(12, 2);
		int second = int.Parse(s6);
		DateTime dateTime = default(DateTime);
		dateTime = new DateTime(year, month, day, hour, minute, second);
		return default(DateTime);
	}

	[Token(Token = "0x6000061")]
	[Address(RVA = "0xBF92E4", Offset = "0xBF92E4", Length = "0x258")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv15 = \"K\";\n\tv16 = \"il2cpp_codegen_initialize_runtime_metadata\"(v15, v17, v18, v19, v20, v21, v22, v23, num, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = \"T\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, v17, v18, v19, v20, v21, v22, v23, num, v24, v25, v26, v27, v28, v29, v30);\n\tv77 = \"B\";\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, v17, v18, v19, v20, v21, v22, v23, num, v24, v25, v26, v27, v28, v29, v30);\n\tv143 = \"M\";\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, v17, v18, v19, v20, v21, v22, v23, num, v24, v25, v26, v27, v28, v29, v30);\n\tv199 = \"0.#\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, v17, v18, v19, v20, v21, v22, v23, num, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A355D0]) = v35;\nL_0029:\n\tv48 = num >= 1000000f;\n\tif (v48) goto L_0047;\n\tv63 = num >= 10000f;\n\tif (v63) goto L_0072;\n\treturnVal1 = System.Single::ToString(&num @ V0 (System.Single));\n\tgoto L_00F6;\nL_0047:\n\tv75 = num >= 1E+09f;\n\tif (v75) goto L_00A1;\n\tv111 = num / 100000f;\n\tv114 = v111 * 0x186A0;\n\tv129 = v111 != 0x7F800000;\n\tif (v129) goto L_FFFFFFFF;\n\tgoto L_0066;\nL_0066:\n\tnum = v255 / 1000000f;\n\tv286 = System.Single::ToString(&num @ V0 (System.Single), \"0.#\");\n\tgoto L_00F1;\nL_0072:\n\tnum = num / 0x42C80000;\n\tv100 = num * 0x64;\n\tv105 = num != 0x7F800000;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_008E;\nL_008E:\n\tnum = num / 0x447A0000;\n\tv286 = System.Single::ToString(&num @ V0 (System.Single), \"0.#\");\n\tgoto L_00F1;\nL_00A1:\n\tv141 = num >= 1E+12f;\n\tif (v141) goto L_00CE;\n\tnum = num / 100000000f;\n\tv157 = num * 0x5F5E100;\n\tv172 = num != 0x7F800000;\n\tif (v172) goto L_FFFFFFFF;\n\tgoto L_00C1;\nL_00C1:\n\tnum = num / 1E+09f;\n\tv286 = System.Single::ToString(&num @ V0 (System.Single), \"0.#\");\n\tgoto L_00F1;\nL_00CE:\n\tv178 = num / 1E+11f;\n\tv182 = v178 * 0x174876E800;\n\tv197 = v178 != 0x7F800000;\n\tif (v197) goto L_FFFFFFFF;\n\tgoto L_00E7;\nL_00E7:\n\tnum = v277 / 1E+12f;\n\tv286 = System.Single::ToString(&num @ V0 (System.Single), \"0.#\");\nL_00F1:\n\treturnVal1 = System.String::Concat(v286, *([v243 @ X8_v4 (System.String)]));\nL_00F6:\n\treturn returnVal1;\n// 191 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static string ConvertKMT(float num)
	{
		string text;
		string text2;
		if (num < 1000000f)
		{
			float num2 = default(float);
			if (num < 10000f)
			{
				return num2.ToString();
			}
			num2 = num / 100f;
			float num3 = num * 1.4E-43f;
			if (num == float.PositiveInfinity)
			{
				num2 = 0f;
			}
			else
			{
				num2 = num3;
			}
			text = (num / 1000f).ToString("0.#");
			text2 = "K";
		}
		else if (num < 1E+09f)
		{
			float num4 = num / 100000f;
			float num5 = num4 * 1.4013E-40f;
			float num6 = ((num4 != float.PositiveInfinity) ? num5 : 0f);
			text = (num6 / 1000000f).ToString("0.#");
			text2 = "M";
		}
		else if (num < 1E+12f)
		{
			float num2 = num / 100000000f;
			float num7 = num * 2.3122341E-35f;
			if (num == float.PositiveInfinity)
			{
				num2 = 0f;
			}
			else
			{
				num2 = num7;
			}
			text = (num / 1E+09f).ToString("0.#");
			text2 = "B";
		}
		else
		{
			float num8 = num / 1E+11f;
			float num9 = num8 * 1E+11f;
			float num10 = ((num8 != float.PositiveInfinity) ? num9 : 0f);
			text = (num10 / 1E+12f).ToString("0.#");
			text2 = "T";
		}
		return text + text2;
	}

	[Token(Token = "0x6000062")]
	[Address(RVA = "0xBF953C", Offset = "0xBF953C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UtilityGame()
	{
	}
}
