using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000016")]
	public class AdjustUtils
	{
		[Token(Token = "0x400006F")]
		public static string KeyAdid = "adid";

		[Token(Token = "0x4000070")]
		public static string KeyMessage = "message";

		[Token(Token = "0x4000071")]
		public static string KeyNetwork = "network";

		[Token(Token = "0x4000072")]
		public static string KeyAdgroup = "adgroup";

		[Token(Token = "0x4000073")]
		public static string KeyCampaign = "campaign";

		[Token(Token = "0x4000074")]
		public static string KeyCreative = "creative";

		[Token(Token = "0x4000075")]
		public static string KeyWillRetry = "willRetry";

		[Token(Token = "0x4000076")]
		public static string KeyTimestamp = "timestamp";

		[Token(Token = "0x4000077")]
		public static string KeyCallbackId = "callbackId";

		[Token(Token = "0x4000078")]
		public static string KeyEventToken = "eventToken";

		[Token(Token = "0x4000079")]
		public static string KeyClickLabel = "clickLabel";

		[Token(Token = "0x400007A")]
		public static string KeyTrackerName = "trackerName";

		[Token(Token = "0x400007B")]
		public static string KeyTrackerToken = "trackerToken";

		[Token(Token = "0x400007C")]
		public static string KeyJsonResponse = "jsonResponse";

		[Token(Token = "0x400007D")]
		public static string KeyTestOptionsBaseUrl = "baseUrl";

		[Token(Token = "0x400007E")]
		public static string KeyTestOptionsGdprUrl = "gdprUrl";

		[Token(Token = "0x400007F")]
		public static string KeyTestOptionsBasePath = "basePath";

		[Token(Token = "0x4000080")]
		public static string KeyTestOptionsGdprPath = "gdprPath";

		[Token(Token = "0x4000081")]
		public static string KeyTestOptionsDeleteState = "deleteState";

		[Token(Token = "0x4000082")]
		public static string KeyTestOptionsUseTestConnectionOptions = "useTestConnectionOptions";

		[Token(Token = "0x4000083")]
		public static string KeyTestOptionsTimerIntervalInMilliseconds = "timerIntervalInMilliseconds";

		[Token(Token = "0x4000084")]
		public static string KeyTestOptionsTimerStartInMilliseconds = "timerStartInMilliseconds";

		[Token(Token = "0x4000085")]
		public static string KeyTestOptionsSessionIntervalInMilliseconds = "sessionIntervalInMilliseconds";

		[Token(Token = "0x4000086")]
		public static string KeyTestOptionsSubsessionIntervalInMilliseconds = "subsessionIntervalInMilliseconds";

		[Token(Token = "0x4000087")]
		public static string KeyTestOptionsTeardown = "teardown";

		[Token(Token = "0x4000088")]
		public static string KeyTestOptionsNoBackoffWait = "noBackoffWait";

		[Token(Token = "0x4000089")]
		public static string KeyTestOptionsiAdFrameworkEnabled = "iAdFrameworkEnabled";

		[Token(Token = "0x6000122")]
		[Address(RVA = "0x156F6F8", Offset = "0x156F6F8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv19 = *([1EE0DF8]);\n\tv20 = *([v19 @ X8_v8]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([20290D2]) = v39;\nL_0014:\n\tv40 = logLevel & 0xFF00000000;\n\tv41 = v40 == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tv46 = System.Nullable`1<com.adjust.sdk.AdjustLogLevel>::get_Value(&logLevel @ X0 (System.Nullable`1<com.adjust.sdk.AdjustLogLevel>));\n\tgoto L_0023;\nL_0023:\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ConvertLogLevel(AdjustLogLevel? logLevel)
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected I4, but got Unknown
			AdjustLogLevel? adjustLogLevel = default(AdjustLogLevel?);
			if ((int)((_003F?)logLevel & 0xFF00000000L) != 0)
			{
				return (int)adjustLogLevel.Value;
			}
			return -1;
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0x156F768", Offset = "0x156F768", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv19 = *([1ED6808]);\n\tv20 = *([v19 @ X8_v8]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([20290D3]) = v39;\nL_0014:\n\tv40 = value & 0xFFFF;\n\tv41 = v40 < 0x100;\n\tv42 = ~v41;\n\tif (v42) goto L_0025;\n\tgoto L_002C;\nL_0025:\n\tv55 = System.Nullable`1<System.Boolean>::get_Value(&value @ X0 (System.Nullable`1<System.Boolean>));\nL_002C:\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ConvertBool(bool? value)
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected I4, but got Unknown
			int num = (_003F?)value & 0xFFFF;
			if (num < 256)
			{
				return -1;
			}
			bool? flag = default(bool?);
			return flag.Value ? 1 : 0;
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0x156F7E0", Offset = "0x156F7E0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv21 = *([1F05A20]);\n\tv22 = *([v21 @ X8_v8]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20290D4]) = v40;\nL_0015:\n\tv41 = methodInfo & 0xFF;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0024;\n\tv47 = System.Nullable`1<System.Double>::get_Value(&value @ X0 (System.Nullable`1<System.Double>));\n\tgoto L_0024;\nL_0024:\n\treturn -1d;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static double ConvertDouble(double? value)
		{
			IntPtr intPtr = default(IntPtr);
			if ((uint)((ulong)(long)intPtr & 0xFFuL) != 0)
			{
				double? num = default(double?);
				double value2 = num.Value;
			}
			return -1.0;
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0x156F850", Offset = "0x156F850", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv21 = *([1EFA988]);\n\tv22 = *([v21 @ X8_v8]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20290D5]) = v40;\nL_0015:\n\tv41 = methodInfo & 0xFF;\n\tv42 = v41 == 0;\n\tif (v42) goto L_FFFFFFFF;\n\treturnVal1 = System.Nullable`1<System.Int64>::get_Value(&value @ X0 (System.Nullable`1<System.Int64>));\n\tgoto L_0024;\nL_0024:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long ConvertLong(long? value)
		{
			//IL_0020: Expected I8, but got I4
			IntPtr intPtr = default(IntPtr);
			long? num = default(long?);
			if ((uint)((ulong)(long)intPtr & 0xFFuL) != 0)
			{
				return num.Value;
			}
			return -1L;
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0x156F8C0", Offset = "0x156F8C0", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EFA910]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290D6]) = v44;\nL_0018:\n\tv47 = 0;\n\tv48 = list == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv52 = new com.adjust.sdk.JSONArray();\n\tcom.adjust.sdk.JSONArray::.ctor(v52);\n\tv116 = System.Collections.Generic.List`1<System.String>::GetEnumerator(list);\nL_002D:\n\tv174 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::MoveNext(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv176 = v174 == 0;\n\tif (v176) goto L_0048;\n\tv178 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v178);\n\tv178.m_Data = 0;\n\tv167 = v52 == 0;\n\tif (v167) goto L_004E;\n\tv165 = com.adjust.sdk.JSONNode::Add(v52, v178);\n\tgoto L_002D;\n\tgoto L_0077;\nL_0048:\n\tv183 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv186 = v52 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_006E;\n\tgoto L_0079;\nL_004E:\n\tv237 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_007A;\n\tv247 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(v237);\n\tv248 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(v247);\n\tv200 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v47 @ stack_-58_v1 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv251 = *([v247 @ X0_v29 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>)]) == 0;\n\tv245 = ~v251;\n\tif (v245) goto L_007E;\nL_006E:\n\treturnVal1 = com.adjust.sdk.JSONArray::ToString(v52);\nL_0077:\n\treturn returnVal1;\nL_0079:\n\tv237 = new System.NullReferenceException();\nL_007A:\n\tv241 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(v237);\nL_007E:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static string ConvertListToJson(List<string> list)
		{
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			if (list != null)
			{
				JSONArray jSONArray = new JSONArray();
				List<string>.Enumerator enumerator2 = list.GetEnumerator();
				NullReferenceException ex;
				while (true)
				{
					if (enumerator.MoveNext())
					{
						JSONData jSONData = null;
						jSONData.Value = null;
						if ((object)jSONArray != null)
						{
							jSONArray.Add(jSONData);
							continue;
						}
						ex = new NullReferenceException();
						break;
					}
					enumerator.Dispose();
					if ((object)jSONArray != null)
					{
						return jSONArray.ToString();
					}
					ex = new NullReferenceException();
					break;
				}
				((List<string>.Enumerator*)ex)->Dispose();
				return (string)(object)new TypeLoadException();
			}
			return null;
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0x156E2C4", Offset = "0x156E2C4", Length = "0x6CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EAD1E0]);\n\tv35 = *([v34 @ X8_v105]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20290D7]) = v54;\nL_0022:\n\tv62 = dictionary == 0;\n\tif (v62) goto L_0278;\n\tv67 = System.String::Concat(\"\", \"{\");\n\tv173 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::GetEnumerator(dictionary);\nL_0041:\n\tv325 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::MoveNext(&v137 @ stack_-B8_v2 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tv327 = v325 == 0;\n\tif (v327) goto L_01D2;\n\tv329 = v328 == 0;\n\tif (v329) goto L_0089;\n\tv343 = *([v328 @ stack_-78 (System.String)]) == System.String;\n\tif (v343) goto L_0068;\n\tgoto L_FFFFFFFF;\n\tgoto L_0089;\nL_0068:\n\tv292 = v292 + 1;\n\tv397 = v292 >= 2;\n\tif (v397) goto L_00BB;\n\tgoto L_00C2;\n\tv348 = v348_asT == 0;\n\tif (v348) goto L_FFFFFFFF;\n\tgoto L_0089;\nL_0089:\n\tv292 = v292 + 1;\n\tv250 = v292 < 2;\n\tif (v250) goto L_00A2;\n\tv403 = System.String::Concat(v404, \",\");\nL_00A2:\n\tv413 = System.String::Concat(v404, \"\\\"\", v236, \"\\\":\");\n\tgoto L_00AF;\n\tv451 = *([v436 @ X0_v18+E0]);\n\tv452 = v451 == 0;\n\tv453 = ~v452;\n\tgoto L_00AF;\n\tv455 = \"il2cpp_codegen_runtime_class_init\"(v436, v410, v412, v243, v242, v41, v42, v43, v135, v45, v46, v47, v48, v49, v50, v51);\nL_00AF:\n\tv457 = com.adjust.sdk.AdjustUtils::GetJsonResponseCompact(v321);\n\tv307 = System.String::Concat(v413, v457);\n\tgoto L_0041;\nL_00BB:\n\tv435 = System.String::Concat(v404, \",\");\nL_00C2:\n\tv450 = System.String::StartsWith(v328, \"{\");\n\tv459 = v450 == 0;\n\tif (v459) goto L_0146;\n\tv465 = System.String::EndsWith(v328, \"}\");\n\tv469 = v465 == 0;\n\tif (v469) goto L_0146;\n\t// 212 NewArr v484 @ X0_v134 (System.String[]), typeof(System.String[]), 5\n\tv505 = v227 == 0;\n\tif (v505) goto L_00E0;\n\t// 221 IsInst v548 @ X0_v150, typeof(System.String), v227 @ X19_v8 (System.String)\n\tv552 = v548 == 0;\n\tif (v552) goto L_0221;\nL_00E0:\n\tv951 = v484.Length;\n\tv555 = v484.Length == 0;\n\tif (v555) goto L_0209;\n\tv484[0] = v227;\n\tv641 = \"\\\"\" == 0;\n\tif (v641) goto L_00ED;\n\t// 233 IsInst v690 @ X0_v148, typeof(System.String), \"\"\"\n\tv694 = v690 == 0;\n\tif (v694) goto L_0225;\n\tv951 = v484.Length;\nL_00ED:\n\tv697 = v951 < 1;\n\tv698 = ~v697;\n\tv699 = v951 - 1;\n\tv701 = v699 == 0;\n\tv706 = ~v698;\n\tv707 = v706 | v701;\n\tif (v707) goto L_020D;\n\tv484[1] = \"\\\"\";\n\tv783 = v236 == 0;\n\tif (v783) goto L_0104;\n\t// 256 IsInst v818 @ X0_v147, typeof(System.String), v236 @ stack_-A8 (System.String)\n\tv822 = v818 == 0;\n\tif (v822) goto L_0229;\n\tv951 = v484.Length;\nL_0104:\n\tv825 = v951 < 2;\n\tv826 = ~v825;\n\tv827 = v951 - 2;\n\tv829 = v827 == 0;\n\tv834 = ~v826;\n\tv835 = v834 | v829;\n\tif (v835) goto L_0211;\n\tv484[2] = v236;\n\tv910 = \"\\\":\" == 0;\n\tif (v910) goto L_011A;\n\t// 278 IsInst v946 @ X0_v145, typeof(System.String), \"\":\"\n\tv950 = v946 == 0;\n\tif (v950) goto L_022D;\n\tv951 = v484.Length;\nL_011A:\n\tv953 = v951 < 3;\n\tv954 = ~v953;\n\tv955 = v951 - 3;\n\tv957 = v955 == 0;\n\tv962 = ~v954;\n\tv963 = v962 | v957;\n\tif (v963) goto L_0215;\n\tv484[3] = \"\\\":\";\n\t// 299 IsInst v1031 @ X0_v142, typeof(System.String), v328 @ stack_-78 (System.String)\n\tv312 = v1031 == 0;\n\tif (v312) goto L_0219;\n\tv1107 = v484.Length < 4;\n\tv285 = ~v1107;\n\tv281 = v484.Length - 4;\n\tv273 = v281 == 0;\n\tv1108 = ~v285;\n\tv251 = v1108 | v273;\n\tif (v251) goto L_021D;\n\tv484[4] = v328;\n\tv308 = System.String::Concat(v484);\n\tgoto L_0041;\nL_0146:\n\t// 326 NewArr v476 @ X0_v73 (System.String[]), typeof(System.String[]), 6\n\tv485 = v227 == 0;\n\tif (v485) goto L_0152;\n\t// 335 IsInst v492 @ X0_v130, typeof(System.String), v227 @ X19_v8 (System.String)\n\tv496 = v492 == 0;\n\tif (v496) goto L_01F3;\nL_0152:\n\tv877 = v476.Length;\n\tv499 = v476.Length == 0;\n\tif (v499) goto L_01D7;\n\tv476[0] = v227;\n\tv541 = \"\\\"\" == 0;\n\tif (v541) goto L_015F;\n\t// 347 IsInst v607 @ X0_v128, typeof(System.String), \"\"\"\n\tv611 = v607 == 0;\n\tif (v611) goto L_01F7;\n\tv877 = v476.Length;\nL_015F:\n\tv614 = v877 < 1;\n\tv615 = ~v614;\n\tv616 = v877 - 1;\n\tv618 = v616 == 0;\n\tv623 = ~v615;\n\tv624 = v623 | v618;\n\tif (v624) goto L_01DB;\n\tv476[1] = \"\\\"\";\n\tv649 = v236 == 0;\n\tif (v649) goto L_0176;\n\t// 370 IsInst v745 @ X0_v127, typeof(System.String), v236 @ stack_-A8 (System.String)\n\tv749 = v745 == 0;\n\tif (v749) goto L_01FB;\n\tv877 = v476.Length;\nL_0176:\n\tv752 = v877 < 2;\n\tv753 = ~v752;\n\tv754 = v877 - 2;\n\tv756 = v754 == 0;\n\tv761 = ~v753;\n\tv762 = v761 | v756;\n\tif (v762) goto L_01DF;\n\tv476[2] = v236;\n\tv793 = \"\\\":\\\"\" == 0;\n\tif (v793) goto L_018E;\n\t// 394 IsInst v872 @ X0_v125, typeof(System.String), \"\":\"\"\n\tv876 = v872 == 0;\n\tif (v876) goto L_01FF;\n\tv877 = v476.Length;\nL_018E:\n\tv879 = v877 < 3;\n\tv880 = ~v879;\n\tv881 = v877 - 3;\n\tv883 = v881 == 0;\n\tv888 = ~v880;\n\tv889 = v888 | v883;\n\tif (v889) goto L_01E3;\n\tv476[3] = \"\\\":\\\"\";\n\t// 417 IsInst v922 @ X0_v119, typeof(System.String), v328 @ stack_-78 (System.String)\n\tv998 = v922 == 0;\n\tif (v998) goto L_01EB;\n\tv1114 = v476.Length;\n\tv1038 = v476.Length < 4;\n\tv1016 = ~v1038;\n\tv1014 = v476.Length - 4;\n\tv1010 = v1014 == 0;\n\tv1039 = ~v1016;\n\tv1000 = v1039 | v1010;\n\tif (v1000) goto L_01E7;\n\tv476[4] = v328;\n\tv1101 = \"\\\"\" == 0;\n\tif (v1101) goto L_01BB;\n\t// 439 IsInst v1096 @ X0_v124, typeof(System.String), \"\"\"\n\tv1097 = v1096 == 0;\n\tif (v1097) goto L_0203;\n\tv1114 = v476.Length;\nL_01BB:\n\tv1116 = v1114 < 5;\n\tv286 = ~v1116;\n\tv282 = v1114 - 5;\n\tv274 = v282 == 0;\n\tv1117 = ~v286;\n\tv252 = v1117 | v274;\n\tif (v252) goto L_01EF;\n\tv476[5] = \"\\\"\";\n\tv309 = System.String::Concat(v476);\n\tgoto L_0041;\nL_01D2:\n\tv334 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::Dispose(&v137 @ stack_-B8_v2 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tgoto L_026A;\n\tv487 = new System.NullReferenceException();\nL_01D7:\n\tv504 = new System.IndexOutOfRangeException();\n\tthrow v504;\nL_01DB:\n\tv639 = new System.IndexOutOfRangeException();\n\tthrow v639;\nL_01DF:\n\tv778 = new System.IndexOutOfRangeException();\n\tthrow v778;\nL_01E3:\n\tv905 = new System.IndexOutOfRangeException();\n\tthrow v905;\nL_01E7:\n\tv1024 = new System.IndexOutOfRangeException();\n\tthrow v1024;\nL_01EB:\n\tv1058 = new System.ArrayTypeMismatchException();\n\tthrow v1058;\nL_01EF:\n\tv1121 = new System.IndexOutOfRangeException();\n\tthrow v1121;\nL_01F3:\n\tv604 = new System.ArrayTypeMismatchException();\n\tthrow v604;\nL_01F7:\n\tv741 = new System.ArrayTypeMismatchException();\n\tthrow v741;\nL_01FB:\n\tv869 = new System.ArrayTypeMismatchException();\n\tthrow v869;\nL_01FF:\n\tv997 = new System.ArrayTypeMismatchException();\n\tthrow v997;\nL_0203:\n\tv1099 = new System.ArrayTypeMismatchException();\n\tthrow v1099;\n\tv539 = new System.NullReferenceException();\nL_0209:\n\tv573 = new System.IndexOutOfRangeException();\n\tthrow v573;\nL_020D:\n\tv725 = new System.IndexOutOfRangeException();\n\tthrow v725;\nL_0211:\n\tv853 = new System.IndexOutOfRangeException();\n\tthrow v853;\nL_0215:\n\tv981 = new System.IndexOutOfRangeException();\n\tthrow v981;\nL_0219:\n\tv1091 = new System.ArrayTypeMismatchException();\n\tthrow v1091;\nL_021D:\n\tv1126 = new System.IndexOutOfRangeException();\n\tthrow v1126;\nL_0221:\n\tv687 = new System.ArrayTypeMismatchException();\n\tthrow v687;\nL_0225:\n\tv814 = new System.ArrayTypeMismatchException();\n\tthrow v814;\nL_0229:\n\tv943 = new System.ArrayTypeMismatchException();\n\tthrow v943;\nL_022D:\n\tv1073 = new System.ArrayTypeMismatchException();\n\tthrow v1073;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_024E;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_0259;\n\tgoto L_024E;\n\tgoto L_0259;\n\tgoto L_024E;\n\tgoto L_0259;\nL_024E:\n\tX19 = X22;\nL_0259:\n\tif (1) goto L_0279;\n\tv1129 = 0x6D2BC0(v1106, 0, 0, v71, v69, v41, v42, v43, v137, v45, v46, v47, v48, v49, v50, v51);\n\tv423 = *([v1129 @ X0_v37]);\n\tv1131 = 0x6D2490(v1129, 0, 0, v71, v69, v41, v42, v43, v137, v45, v4\n// ... truncated")]
		public static string GetJsonResponseCompact(Dictionary<string, object> dictionary)
		{
			//IL_04a4: Expected O, but got I4
			//IL_0a8b: Expected O, but got I
			//IL_021a: Expected O, but got I4
			//IL_0ae9: Expected O, but got I
			//IL_0528: Expected O, but got I4
			//IL_0971: Expected O, but got I
			//IL_0b47: Expected O, but got I
			//IL_0591: Expected O, but got I4
			//IL_09cf: Expected O, but got I
			//IL_029e: Expected O, but got I4
			//IL_05fb: Expected O, but got I4
			//IL_0a2d: Expected O, but got I
			//IL_0307: Expected O, but got I4
			//IL_0647: Expected O, but got I4
			//IL_0673: Expected O, but got I4
			//IL_0371: Expected O, but got I4
			//IL_0ba5: Expected O, but got I
			//IL_03df: Expected O, but got I4
			//IL_070d: Expected O, but got I4
			bool flag = dictionary == null;
			string result = "";
			if (!flag)
			{
				string text = "" + "{";
				object enumerator = dictionary.GetEnumerator();
				int num = 0;
				string text2 = text;
				Dictionary<string, object>.Enumerator enumerator2 = default(Dictionary<string, object>.Enumerator);
				string text3 = default(string);
				string text6 = default(string);
				while (enumerator2.MoveNext())
				{
					bool flag2 = text3 == null;
					Dictionary<string, object> dictionary2 = (Dictionary<string, object>)(object)text3;
					if (!flag2)
					{
						if ((object)text3.GetType() == typeof(string))
						{
							num++;
							string text4;
							if (num < 2)
							{
								text4 = text2;
							}
							else
							{
								string text5 = text2 + ",";
								text4 = text5;
							}
							if (text3.StartsWith("{") && text3.EndsWith("}"))
							{
								string[] array = new string[5];
								if (text4 != null)
								{
									object obj = text4 as string;
									if (obj == null)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								object obj2 = array.Length;
								if (array.Length != 0)
								{
									array[0] = text4;
									if ("\"" != null)
									{
										object obj3 = "\"" as string;
										if (obj3 == null)
										{
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										}
										obj2 = array.Length;
									}
									bool flag3 = (long)(IntPtr)obj2 < 1L;
									bool flag4 = !flag3;
									object obj4 = (long)(IntPtr)obj2 - 1L;
									bool flag5 = obj4 == null;
									bool flag6 = !flag4;
									if (!(flag6 || flag5))
									{
										array[1] = "\"";
										if (text6 != null)
										{
											object obj5 = text6 as string;
											if (obj5 == null)
											{
												ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
												throw ex3;
											}
											obj2 = array.Length;
										}
										bool flag7 = (long)(IntPtr)obj2 < 2L;
										bool flag8 = !flag7;
										object obj6 = (long)(IntPtr)obj2 - 2L;
										bool flag9 = obj6 == null;
										bool flag10 = !flag8;
										if (!(flag10 || flag9))
										{
											array[2] = text6;
											if ("\":" != null)
											{
												object obj7 = "\":" as string;
												if (obj7 == null)
												{
													ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
													throw ex4;
												}
												obj2 = array.Length;
											}
											bool flag11 = (long)(IntPtr)obj2 < 3L;
											bool flag12 = !flag11;
											object obj8 = (long)(IntPtr)obj2 - 3L;
											bool flag13 = obj8 == null;
											bool flag14 = !flag12;
											if (!(flag14 || flag13))
											{
												array[3] = "\":";
												object obj9 = text3 as string;
												if (obj9 != null)
												{
													bool flag15 = array.Length < 4;
													bool flag16 = !flag15;
													object obj10 = array.Length - 4;
													bool flag17 = obj10 == null;
													bool flag18 = !flag16;
													if (!(flag18 || flag17))
													{
														array[4] = text3;
														string text7 = string.Concat(array);
														text2 = text7;
														continue;
													}
													IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
													throw ex5;
												}
												ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
												throw ex6;
											}
											IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
											throw ex7;
										}
										IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
										throw ex8;
									}
									IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
									throw ex9;
								}
								IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
								throw ex10;
							}
							string[] array2 = new string[6];
							if (text4 != null)
							{
								object obj11 = text4 as string;
								if (obj11 == null)
								{
									ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
									throw ex11;
								}
							}
							object obj12 = array2.Length;
							if (array2.Length != 0)
							{
								array2[0] = text4;
								if ("\"" != null)
								{
									object obj13 = "\"" as string;
									if (obj13 == null)
									{
										ArrayTypeMismatchException ex12 = new ArrayTypeMismatchException();
										throw ex12;
									}
									obj12 = array2.Length;
								}
								bool flag19 = (long)(IntPtr)obj12 < 1L;
								bool flag20 = !flag19;
								object obj14 = (long)(IntPtr)obj12 - 1L;
								bool flag21 = obj14 == null;
								bool flag22 = !flag20;
								if (!(flag22 || flag21))
								{
									array2[1] = "\"";
									if (text6 != null)
									{
										object obj15 = text6 as string;
										if (obj15 == null)
										{
											ArrayTypeMismatchException ex13 = new ArrayTypeMismatchException();
											throw ex13;
										}
										obj12 = array2.Length;
									}
									bool flag23 = (long)(IntPtr)obj12 < 2L;
									bool flag24 = !flag23;
									object obj16 = (long)(IntPtr)obj12 - 2L;
									bool flag25 = obj16 == null;
									bool flag26 = !flag24;
									if (!(flag26 || flag25))
									{
										array2[2] = text6;
										if ("\":\"" != null)
										{
											object obj17 = "\":\"" as string;
											if (obj17 == null)
											{
												ArrayTypeMismatchException ex14 = new ArrayTypeMismatchException();
												throw ex14;
											}
											obj12 = array2.Length;
										}
										bool flag27 = (long)(IntPtr)obj12 < 3L;
										bool flag28 = !flag27;
										object obj18 = (long)(IntPtr)obj12 - 3L;
										bool flag29 = obj18 == null;
										bool flag30 = !flag28;
										if (!(flag30 || flag29))
										{
											array2[3] = "\":\"";
											object obj19 = text3 as string;
											if (obj19 != null)
											{
												object obj20 = array2.Length;
												bool flag31 = array2.Length < 4;
												bool flag32 = !flag31;
												object obj21 = array2.Length - 4;
												bool flag33 = obj21 == null;
												bool flag34 = !flag32;
												if (!(flag34 || flag33))
												{
													array2[4] = text3;
													if ("\"" != null)
													{
														object obj22 = "\"" as string;
														if (obj22 == null)
														{
															ArrayTypeMismatchException ex15 = new ArrayTypeMismatchException();
															throw ex15;
														}
														obj20 = array2.Length;
													}
													bool flag35 = (long)(IntPtr)obj20 < 5L;
													bool flag36 = !flag35;
													object obj23 = (long)(IntPtr)obj20 - 5L;
													bool flag37 = obj23 == null;
													bool flag38 = !flag36;
													if (!(flag38 || flag37))
													{
														array2[5] = "\"";
														string text8 = string.Concat(array2);
														text2 = text8;
														continue;
													}
													IndexOutOfRangeException ex16 = new IndexOutOfRangeException();
													throw ex16;
												}
												IndexOutOfRangeException ex17 = new IndexOutOfRangeException();
												throw ex17;
											}
											ArrayTypeMismatchException ex18 = new ArrayTypeMismatchException();
											throw ex18;
										}
										IndexOutOfRangeException ex19 = new IndexOutOfRangeException();
										throw ex19;
									}
									IndexOutOfRangeException ex20 = new IndexOutOfRangeException();
									throw ex20;
								}
								IndexOutOfRangeException ex21 = new IndexOutOfRangeException();
								throw ex21;
							}
							IndexOutOfRangeException ex22 = new IndexOutOfRangeException();
							throw ex22;
						}
						Dictionary<string, object> dictionary3 = text3 as Dictionary<string, object>;
						dictionary2 = (Dictionary<string, object>)(object)((dictionary3 == null) ? null : text3);
					}
					num++;
					if (num >= 2)
					{
						string text9 = text2 + ",";
						text2 = text9;
					}
					string text10 = text2 + "\"" + text6 + "\":";
					string jsonResponseCompact = GetJsonResponseCompact(dictionary2);
					string text11 = text10 + jsonResponseCompact;
					text2 = text11;
				}
				enumerator2.Dispose();
				result = text2 + "}";
			}
			return result;
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x156D148", Offset = "0x156D148", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F091F8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, key, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290D8]) = v41;\nL_0017:\n\tv44 = com.adjust.sdk.JSONNode::op_Equality(node, 0);\n\tv46 = v44 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0061;\n\tv114 = com.adjust.sdk.JSONNode::get_Item(node, key);\n\tv115 = v114 == 0;\n\tif (v115) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_004D;\n\tv211 = v211_asT == 0;\n\tif (v211) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tv95 = com.adjust.sdk.JSONNode::op_Equality(v100, 0);\n\tv216 = v95 == 0;\n\tv98 = ~v216;\n\tif (v98) goto L_0061;\n\tv94 = com.adjust.sdk.JSONNode::op_Equality(v100, \"\");\n\tv97 = v94 == 0;\n\tif (v97) goto L_0064;\nL_0061:\n\treturn 0;\nL_0064:\n\tv165 = *([v100 @ X19_v5 (com.adjust.sdk.JSONNode)]);\n\tv153 = *([v165 @ X8_v9 (Il2CppClass<com.adjust.sdk.JSONNode>)+1C0]);\n\tv156 = *([v165 @ X8_v9 (Il2CppClass<com.adjust.sdk.JSONNode>)+1C8]);\n\t// 110 IndirectJump v153 @ X2_v4, v100 @ X19_v5 (com.adjust.sdk.JSONNode), v100 @ X19_v5 (com.adjust.sdk.JSONNode), v156 @ X1_v7, v153 @ X2_v4, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetJsonString(JSONNode node, string key)
		{
			//IL_00bd: Expected I, but got O
			//IL_00cd: Expected O, but got I
			//IL_00dd: Expected O, but got I
			while (!(node == null))
			{
				JSONNode jSONNode = node.get_Item(key);
				JSONNode jSONNode2;
				if ((object)jSONNode == null)
				{
					jSONNode2 = null;
				}
				else
				{
					JSONData jSONData = jSONNode as JSONData;
					jSONNode2 = (((object)jSONData == null) ? null : jSONNode);
				}
				if (jSONNode2 == null || jSONNode2 == (object)"")
				{
					break;
				}
				IntPtr intPtr = (IntPtr)jSONNode2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v9 (Il2CppClass<com.adjust.sdk.JSONNode>)+1C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v9 (Il2CppClass<com.adjust.sdk.JSONNode>)+1C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v153 @ X2_v4 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0x156DCC0", Offset = "0x156DCC0", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EBC3C0]);\n\tv37 = *([v36 @ X8_v36]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, output, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20290D9]) = v55;\nL_001F:\n\tv58 = com.adjust.sdk.JSONClass::GetEnumerator(jsonObject);\n\tv133 = v58 == 0;\n\tif (v133) goto L_00E2;\nL_0031:\n\tgoto L_0058;\n\tv232 = *([v218 @ X8_v13+B0]);\n\tv233 = 0;\n\tv234 = v232 + 8;\n\tv236 = *([v335 @ X11_v23-8]);\n\tv340 = v236 == v219;\n\tif (v340) goto L_0051;\n\tv256 = v334 + 1;\n\tv347 = v256 < v220;\n\tv254 = ~v347;\n\tv258 = v335 + 0x10;\n\tv238 = ~v254;\n\tif (v238) goto L_FFFFFFFF;\n\tv259 = v126;\n\tv260 = 0;\n\tv261 = 0x8909C4(v259, v219, v260, v63, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0058;\nL_0051:\n\tv348 = *([v335 @ X11_v23]);\n\tv349 = v348 << 4;\n\tv350 = v218 + v349;\n\tv351 = v350 + 0x130;\nL_0058:\n\tv372 = System.Collections.IEnumerator::MoveNext(v58);\n\tv374 = v372 == 0;\n\tif (v374) goto L_FFFFFFFF;\n\tv424 = *([v58 @ X0_v24 (System.Collections.IEnumerator)]);\n\tv427 = *([v424 @ X8_v16 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v427) goto L_007E;\n\tv497 = *([v424 @ X8_v16 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0069:\n\tv502 = *([v497 @ X11_v18-8]) == System.Collections.IEnumerator;\n\tif (v502) goto L_0081;\n\tv496 = v496 + 1;\n\tv536 = v496 < *([v424 @ X8_v16 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv477 = ~v536;\n\tv497 = v497 + 0x10;\n\tv461 = ~v477;\n\tif (v461) goto L_0069;\nL_007E:\n\tv553 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v58, System.Collections.IEnumerator, 1);\n\tgoto L_0088;\nL_0081:\n\tv538 = *([v497 @ X11_v18]) + 1;\n\tv539 = v538 << 4;\n\tv540 = v424 + v539;\n\tv553 = v540 + 0x130;\nL_0088:\n\t*([v553 @ X0_v29])(v558, v58, *([v553 @ X0_v29+8]), v543, v266, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv188 = v188_asT == 0;\n\tif (v188) goto L_00D9;\n\tv619 = \"il2cpp_vm_object_unbox\"(v558, System.Collections.Generic.KeyValuePair`2<System.String, com.adjust.sdk.JSONNode>, v543, v266, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv175 = *([v619 @ X0_v44+8]);\n\tv660 = *([v175 @ X23_v10]);\n\t*([v660 @ X8_v25+2E0])(v663, v175, *([v660 @ X8_v25+2E8]), v543, v266, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv666 = com.adjust.sdk.JSONNode::op_Equality(v663, 0);\n\tv690 = v666 == 0;\n\tif (v690) goto L_00B9;\n\tv214 = *([v175 @ X23_v10]);\n\t*([v214 @ X8_v31+1C0])(v683, v175, *([v214 @ X8_v31+1C8]), v543, v266, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v271, *([v619 @ X0_v44]), v683);\n\tgoto L_0031;\nL_00B9:\n\tv698 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v698);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v271, *([v619 @ X0_v44]), v698);\n\tgoto L_00D3;\n\tv707 = *([v703 @ X0_v53+E0]);\n\tv708 = v707 == 0;\n\tv709 = ~v708;\n\tif (v709) goto L_00D3;\n\tv711 = \"il2cpp_codegen_runtime_class_init\"(v703, v700, v186, v171, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00D3:\n\tcom.adjust.sdk.AdjustUtils::WriteJsonResponseDictionary(v663, v698);\n\tgoto L_0031;\n\tgoto L_0105;\n\tv596 = new System.NullReferenceException();\nL_00D9:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv132 = new System.NullReferenceException();\nL_00E2:\n\tv163 = new System.NullReferenceException();\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\nL_00FB:\n\tv231 = v271 != 1;\n\tif (v231) goto L_0151;\n\tv262 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v163, v271, v277);\n\tv318 = *([v262 @ X0_v18]);\n\tv346 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v262, v271, v277);\nL_0105:\n\t// 261 IsInst v454 @ X0_v4 (System.IDisposable), typeof(System.IDisposable), v449 @ X19_v2 (System.Collections.IEnumerator)\n\tv485 = v454 == 0;\n\tif (v485) goto L_0135;\n\tgoto L_0134;\n\tv560 = *([v507 @ X8_v5+B0]);\n\tv561 = 0;\n\tv562 = v560 + 8;\n\tv564 = *([v608 @ X11_v7-8]);\n\tv613 = v564 == v508;\n\tif (v613) goto L_012D;\n\tv584 = v607 + 1;\n\tv634 = v584 < v509;\n\tv582 = ~v634;\n\tv586 = v608 + 0x10;\n\tv566 = ~v582;\n\tif (v566) goto L_FFFFFFFF;\n\tv587 = v316;\n\tv588 = 0;\n\tv589 = 0x8909C4(v587, v508, v588, v266, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0134;\nL_012D:\n\tv635 = *([v608 @ X11_v7]);\n\tv636 = v635 << 4;\n\tv637 = v507 + v636;\n\tv638 = v637 + 0x130;\nL_0134:\n\tSystem.IDisposable::Dispose(v454);\nL_0135:\n\tv535 = v322 + 1;\n\tv290 = v535 == 0;\n\tv280 = ~v290;\n\tif (v280) goto L_014C;\n\tv590 = v318 == 0;\n\tv314 = ~v590;\n\tif (v314) goto L_0150;\nL_014C:\n\treturn;\nL_0150:\n\tv312 = new System.TypeLoadException();\nL_0151:\n\tv323 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v163, 0, 0);\n\treturn;\n// 199 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void WriteJsonResponseDictionary(JSONClass jsonObject, Dictionary<string, object> output)
		{
			//IL_02ac: Expected O, but got I
			//IL_02b4: Expected I4, but got O
			//IL_02c5: Expected O, but got I
			//IL_003f: Expected I, but got O
			//IL_00f7: Expected O, but got I4
			//IL_007a: Expected O, but got I
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_0130: Expected O, but got I
			//IL_013f: Expected O, but got I
			//IL_0196: Expected O, but got I
			//IL_00c6: Expected O, but got I
			IEnumerator enumerator = jsonObject.GetEnumerator();
			bool flag = enumerator == null;
			IEnumerator enumerator2 = enumerator;
			NullReferenceException ex;
			Dictionary<string, object> dictionary = default(Dictionary<string, object>);
			int num;
			int num2;
			if (flag)
			{
				ex = new NullReferenceException();
				if ((IntPtr)dictionary != (IntPtr)1)
				{
					goto IL_031c;
				}
				IntPtr intPtr = default(IntPtr);
				((Dictionary<string, object>)(object)ex).Add((string)(object)dictionary, (object)(long)intPtr);
				object obj = default(object);
				num = (int)obj;
				((Dictionary<string, object>)obj).Add((string)(object)dictionary, (object)(long)intPtr);
				num2 = -1;
			}
			else
			{
				object obj6 = default(object);
				JSONNode jSONNode = default(JSONNode);
				object key = default(object);
				object value = default(object);
				while (enumerator.MoveNext())
				{
					IntPtr intPtr2 = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ X8_v16 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00df;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ X8_v16 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj2 = 0L + 8L;
					int num3 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ X11_v18-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ X8_v16 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag2 = (long)num4 < 0L;
						bool flag3 = !flag2;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_00df;
					}
					object obj3 = obj2 + 1;
					int num5 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr2 + (long)num5;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					int num6 = 0;
					goto IL_037c;
					IL_00df:
					((Dictionary<string, object>)enumerator).Add((string)(object)typeof(IEnumerator), (object)1);
					num6 = 1;
					goto IL_037c;
					IL_037c:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v553 @ X0_v29] (should have been resolved before IL gen)");
					KeyValuePair<string, JSONNode> keyValuePair = (KeyValuePair<string, JSONNode>)((obj6 is KeyValuePair<string, JSONNode>) ? obj6 : null);
					if ((object)keyValuePair != null)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ X0_v44+8]");
						object obj7 = 0;
						object obj8 = obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v660 @ X8_v25+2E0] (should have been resolved before IL gen)");
						if (jSONNode == null)
						{
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v214 @ X8_v31+1C0] (should have been resolved before IL gen)");
							dictionary.Add((string)key, value);
							IntPtr intPtr3 = (IntPtr)0;
						}
						else
						{
							Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
							dictionary.Add((string)key, dictionary2);
							WriteJsonResponseDictionary((JSONClass)jSONNode, dictionary2);
							IntPtr intPtr3 = (IntPtr)0;
						}
						continue;
					}
					throw new InvalidCastException();
				}
				enumerator2 = enumerator;
				num = 0;
				num2 = 0;
			}
			(enumerator2 as IDisposable)?.Dispose();
			if (num2 + 1 != 0 || num == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_031c;
			IL_031c:
			((Dictionary<string, object>)(object)ex).Add((string)null, (object)null);
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0x156D38C", Offset = "0x156D38C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EFF618]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, key, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290DA]) = v41;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.String, System.String>::TryGetValue(dictionary, key, &v47 @ stack_-28_v2 (System.String));\n\tv55 = v51 == 0;\n\tif (v55) goto L_FFFFFFFF;\n\tv61 = System.String::op_Equality(v47, \"\");\n\tv106 = v61 == 0;\n\tv109 = ~v106;\n\tv110 = ~v109;\n\tif (v110) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tgoto L_003D;\nL_003D:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string TryGetValue(Dictionary<string, string> dictionary, string key)
		{
			if (dictionary.TryGetValue(key, out var value))
			{
				if (value == "")
				{
					return null;
				}
				return value;
			}
			return null;
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0x156A598", Offset = "0x156A598", Length = "0xB94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EFE818]);\n\tv33 = *([v32 @ X8_v226]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, ajoCurrentActivity, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20290DB]) = v51;\nL_001E:\n\tv56 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0027;\n\tv61 = v56;\n\tv62 = 0x8907BC(v61, ajoCurrentActivity, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv65 = *([v56 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0027:\n\tv66 = *([v56 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv67 = v66 == 0;\n\tif (v67) goto L_0048;\n\tv69 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0034;\n\tv91 = v69;\n\tv92 = 0x8907BC(v91, ajoCurrentActivity, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0034:\n\tv93 = *([v69 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv79 = ~v93;\n\tif (v79) goto L_0048;\n\tgoto L_0048;\n\tv112 = v84;\n\tv113 = 0x8907BC(v112, ajoCurrentActivity, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0048:\n\tgoto L_0050;\n\tv94 = v86;\n\tv95 = 0x8907BC(v94, ajoCurrentActivity, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0050:\n\tv102 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v102, \"com.adjust.sdk.AdjustTestOptions\", v98.Value);\n\tgoto L_006D;\n\tv122 = *([v118 @ X0_v7+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\t// 98 ConditionalJump @b20, v124 @ TEMP_v200\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v111, v108, v109, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_006D:\n\tv137 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(testOptionsMap, v133.KeyTestOptionsBaseUrl);\n\tUnityEngine.AndroidJavaObject::Set(v102, \"baseUrl\", v137);\n\tv316 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(testOptionsMap, v314.KeyTestOptionsGdprUrl);\n\tUnityEngine.AndroidJavaObject::Set(v102, \"gdprUrl\", v316);\n\tv356 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(testOptionsMap, v353.KeyTestOptionsBasePath);\n\tv358 = v356 == 0;\n\tif (v358) goto L_00C2;\n\tgoto L_00A0;\n\tv420 = *([v395 @ X0_v229 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv421 = v420 == 0;\n\tv422 = ~v421;\n\tif (v422) goto L_00A0;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v395, v354, v355, v319, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv424 = com.adjust.sdk.AdjustUtils;\nL_00A0:\n\tv429 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(testOptionsMap, v415.KeyTestOptionsBasePath);\n\tv409 = System.String::IsNullOrEmpty(v429);\n\tv447 = v409 == 0;\n\tv412 = ~v447;\n\tif (v412) goto L_00C2;\n\tgoto L_00B6;\n\tv499 = *([v473 @ X0_v234 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv500 = v499 == 0;\n\tv501 = ~v500;\n\tif (v501) goto L_00B6;\n\tv513 = \"il2cpp_codegen_runtime_class_init\"(v473, v401, v406, v319, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv503 = com.adjust.sdk.AdjustUtils;\nL_00B6:\n\tv509 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(testOptionsMap, v505.KeyTestOptionsBasePath);\n\tUnityEngine.AndroidJavaObject::Set(v102, \"basePath\", v509);\nL_00C2:\n\tgoto L_00CD;\n\tv430 = *([v416 @ X0_v26 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv431 = v430 == 0;\n\tv432 = ~v431;\n\tif (v432) goto L_00CD;\n\tv443 = \"il2cpp_codegen_runtime_class_init\"(v416, v399, v404, v402, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv434 = com.adjust.sdk.AdjustUtils;\nL_00CD:\n\tv441 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(testOptionsMap, v437.KeyTestOptionsGdprPath);\n\tv445 = v441 == 0;\n\tif (v445) goto L_0102;\n\tgoto L_00E0;\n\tv477 = *([v448 @ X0_v213 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv478 = v477 == 0;\n\tv479 = ~v478;\n\tif (v479) goto L_00E0;\n\tv510 = \"il2cpp_codegen_runtime_class_init\"(v448, v440, v438, v402, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv481 = com.adjust.sdk.AdjustUtils;\nL_00E0:\n\tv486 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(testOptionsMap, v468.KeyTestOptionsGdprPath);\n\tv462 = System.String::IsNullOrEmpty(v486);\n\tv516 = v462 == 0;\n\tv465 = ~v516;\n\tif (v465) goto L_0102;\n\tgoto L_00F6;\n\tv552 = *([v534 @ X0_v218 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv553 = v552 == 0;\n\tv554 = ~v553;\n\tif (v554) goto L_00F6;\n\tv566 = \"il2cpp_codegen_runtime_class_init\"(v534, v454, v459, v402, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv556 = com.adjust.sdk.AdjustUtils;\nL_00F6:\n\tv562 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(testOptionsMap, v558.KeyTestOptionsGdprPath);\n\tUnityEngine.AndroidJavaObject::Set(v102, \"gdprPath\", v562);\nL_0102:\n\tgoto L_010D;\n\tv487 = *([v469 @ X0_v31 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv488 = v487 == 0;\n\tv489 = ~v488;\n\tif (v489) goto L_010D;\n\tv511 = \"il2cpp_codegen_runtime_class_init\"(v469, v452, v457, v455, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv491 = com.adjust.sdk.AdjustUtils;\nL_010D:\n\tv498 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(testOptionsMap, v494.KeyTestOptionsDeleteState);\n\tv512 = ajoCurrentActivity == 0;\n\tif (v512) goto L_0120;\n\tv518 = v498 == 0;\n\tif (v518) goto L_0120;\n\tUnityEngine.AndroidJavaObject::Set(v102, \"context\", ajoCurrentActivity);\nL_0120:\n\tgoto L_012B;\n\tv540 = *([v530 @ X0_v36 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv541 = v540 == 0;\n\tv542 = ~v541;\n\tif (v542) goto L_012B;\n\tv563 = \"il2cpp_codegen_runtime_class_init\"(v530, v520, v523, v168, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv544 = com.adjust.sdk.AdjustUtils;\nL_012B:\n\tv551 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(testOptionsMap, v547.KeyTestOptionsUseTestConnectionOptions);\n\tv565 = v551 == 0;\n\tif (v565) goto L_017B;\n\tgoto L_013E;\n\tv591 = *([v568 @ X0_v190 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv592 = v591 == 0;\n\tv593 = ~v592;\n\tif (v593) goto L_013E;\n\tv611 = \"il2cpp_codegen_runtime_class_init\"(v568, v550, v548, v168, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv595 = com.adjust.sdk.AdjustUtils;\nL_013E:\n\tv247 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(testOptionsMap, v259.KeyTestOptionsUseTestConnectionOptions);\n\tv616 = System.String::ToLower(v247);\n\tv643 = System.String::op_Equality(v616, \"true\");\n\t// 334 NewArr v673 @ X0_v197 (System.Object[]), typeof(System.Object[]), 1\n\t// 341 Box v102 @ X0_v6 (UnityEngine.AndroidJavaObject), typeof(System.Boolean), &v643 @ X0_v195 (System.Boolean)\n\tv737 = v102 == 0;\n\tif (v737) goto L_0162;\n\t// 350 IsInst v102 @ X0_v6 (UnityEngine.AndroidJavaObject), typeof(System.Object), v102 @ X0_v6 (UnityEngine.AndroidJavaObject)\nL_0162:\n\tv293 = v673.Length == 0;\n\tif (v293) goto L_038C;\n\tv673[0] = v102;\n\tv102 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v102, \"java.lang.Boolean\", v673);\n\tUnityEngine.AndroidJavaObject::Set(v102, \"useTestConnectionOptions\", v102);\nL_017B:\n\tgoto L_0186;\n\tv599 = *([v587 @ X0_v43 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv600 = v599 == 0;\n\tv601 = ~v600;\n\tif (v601) goto L_0186;\n\tv612 = \"il2cpp_codegen_runtime_class_init\"(v587, v574, v577, v169, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv603 = com.adjust.sdk.AdjustUtils;\nL_0186:\n\tv610 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(testOptionsMap, v606.KeyTestOptionsTimerIntervalInMilliseconds);\n\tv614 = v610 == 0;\n\tif (v614) goto L_01CF;\n\tgoto L_0199;\n\tv644 = *([v617 @ X0_v171 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv645 = v644 == 0;\n\tv646 = ~v645;\n\tif (v646) goto L_0199;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v617, v609, v607, v169, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv648 = com.adjust.sdk.AdjustUtils;\nL_0199:\n\tv654\n// ... truncated")]
		public static AndroidJavaObject TestOptionsMap2AndroidJavaObject(Dictionary<string, string> testOptionsMap, AndroidJavaObject ajoCurrentActivity)
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X19_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.adjust.sdk.AdjustTestOptions");
			string val = testOptionsMap.get_Item(KeyTestOptionsBaseUrl);
			androidJavaObject.Set("baseUrl", val);
			string val2 = testOptionsMap.get_Item(KeyTestOptionsGdprUrl);
			androidJavaObject.Set("gdprUrl", val2);
			if (testOptionsMap.ContainsKey(KeyTestOptionsBasePath))
			{
				string value = testOptionsMap.get_Item(KeyTestOptionsBasePath);
				if (!string.IsNullOrEmpty(value))
				{
					string val3 = testOptionsMap.get_Item(KeyTestOptionsBasePath);
					androidJavaObject.Set("basePath", val3);
				}
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsGdprPath))
			{
				string value2 = testOptionsMap.get_Item(KeyTestOptionsGdprPath);
				if (!string.IsNullOrEmpty(value2))
				{
					string val4 = testOptionsMap.get_Item(KeyTestOptionsGdprPath);
					androidJavaObject.Set("gdprPath", val4);
				}
			}
			bool flag = testOptionsMap.ContainsKey(KeyTestOptionsDeleteState);
			if (ajoCurrentActivity != null && flag)
			{
				androidJavaObject.Set("context", ajoCurrentActivity);
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsUseTestConnectionOptions))
			{
				string text = testOptionsMap.get_Item(KeyTestOptionsUseTestConnectionOptions);
				string text2 = text.ToLower();
				bool flag2 = text2 == "true";
				object[] array = new object[1];
				androidJavaObject = (AndroidJavaObject)(object)flag2;
				if (androidJavaObject != null)
				{
					androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
				}
				if (array.Length == 0)
				{
					goto IL_0690;
				}
				array[0] = androidJavaObject;
				androidJavaObject = new AndroidJavaObject("java.lang.Boolean", array);
				androidJavaObject.Set("useTestConnectionOptions", androidJavaObject);
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsTimerIntervalInMilliseconds))
			{
				string s = testOptionsMap.get_Item(KeyTestOptionsTimerIntervalInMilliseconds);
				long num = long.Parse(s);
				object[] array2 = new object[1];
				androidJavaObject = (AndroidJavaObject)(object)num;
				if (androidJavaObject != null)
				{
					androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
				}
				if (array2.Length == 0)
				{
					goto IL_0690;
				}
				array2[0] = androidJavaObject;
				androidJavaObject = new AndroidJavaObject("java.lang.Long", array2);
				androidJavaObject.Set("timerIntervalInMilliseconds", androidJavaObject);
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsTimerStartInMilliseconds))
			{
				string s2 = testOptionsMap.get_Item(KeyTestOptionsTimerStartInMilliseconds);
				long num2 = long.Parse(s2);
				object[] array3 = new object[1];
				androidJavaObject = (AndroidJavaObject)(object)num2;
				if (androidJavaObject != null)
				{
					androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
				}
				if (array3.Length == 0)
				{
					goto IL_0690;
				}
				array3[0] = androidJavaObject;
				androidJavaObject = new AndroidJavaObject("java.lang.Long", array3);
				androidJavaObject.Set("timerStartInMilliseconds", androidJavaObject);
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsSessionIntervalInMilliseconds))
			{
				string s3 = testOptionsMap.get_Item(KeyTestOptionsSessionIntervalInMilliseconds);
				long num3 = long.Parse(s3);
				object[] array4 = new object[1];
				androidJavaObject = (AndroidJavaObject)(object)num3;
				if (androidJavaObject != null)
				{
					androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
				}
				if (array4.Length == 0)
				{
					goto IL_0690;
				}
				array4[0] = androidJavaObject;
				androidJavaObject = new AndroidJavaObject("java.lang.Long", array4);
				androidJavaObject.Set("sessionIntervalInMilliseconds", androidJavaObject);
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsSubsessionIntervalInMilliseconds))
			{
				string s4 = testOptionsMap.get_Item(KeyTestOptionsSubsessionIntervalInMilliseconds);
				long num4 = long.Parse(s4);
				object[] array5 = new object[1];
				androidJavaObject = (AndroidJavaObject)(object)num4;
				if (androidJavaObject != null)
				{
					androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
				}
				if (array5.Length == 0)
				{
					goto IL_0690;
				}
				array5[0] = androidJavaObject;
				androidJavaObject = new AndroidJavaObject("java.lang.Long", array5);
				androidJavaObject.Set("subsessionIntervalInMilliseconds", androidJavaObject);
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsTeardown))
			{
				string text3 = testOptionsMap.get_Item(KeyTestOptionsTeardown);
				string text4 = text3.ToLower();
				bool flag3 = text4 == "true";
				object[] array6 = new object[1];
				androidJavaObject = (AndroidJavaObject)(object)flag3;
				if (androidJavaObject != null)
				{
					androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
				}
				if (array6.Length == 0)
				{
					goto IL_0690;
				}
				array6[0] = androidJavaObject;
				androidJavaObject = new AndroidJavaObject("java.lang.Boolean", array6);
				androidJavaObject.Set("teardown", androidJavaObject);
			}
			if (testOptionsMap.ContainsKey(KeyTestOptionsNoBackoffWait))
			{
				string text5 = testOptionsMap.get_Item(KeyTestOptionsNoBackoffWait);
				string text6 = text5.ToLower();
				bool flag4 = text6 == "true";
				object[] array7 = new object[1];
				androidJavaObject = (AndroidJavaObject)(object)flag4;
				if (androidJavaObject != null)
				{
					androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
				}
				if (array7.Length == 0)
				{
					goto IL_0690;
				}
				array7[0] = androidJavaObject;
				androidJavaObject = new AndroidJavaObject("java.lang.Boolean", array7);
				androidJavaObject.Set("noBackoffWait", androidJavaObject);
			}
			return androidJavaObject;
			IL_0690:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x156FB54", Offset = "0x156FB54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustUtils()
		{
		}
	}
}
