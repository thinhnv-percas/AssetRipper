using System;
using System.Diagnostics;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x200002A")]
	internal static class Log
	{
		[Token(Token = "0x400007D")]
		private static readonly string TAG;

		[AttributeAttribute(Type = typeof(ConditionalAttribute), RVA = "0x73CE20", Offset = "0x73CE20")]
		[Token(Token = "0x6000116")]
		[Address(RVA = "0x13E006C", Offset = "0x13E006C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F07B10]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028ABF]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.Log>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v44, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = LunarConsolePluginInternal.Log;\nL_002A:\n\tgoto L_0033;\n\tv64 = *([v58 @ X8_v7+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0033;\n\tv74 = v58;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v74, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0033:\n\tv73 = LunarConsolePluginInternal.StringUtils::TryFormat(format, args);\n\tv81 = System.String::Concat(v57.TAG, \" \", v73);\n\tgoto L_0051;\n\tv89 = *([v85 @ X8_v12+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0051;\n\tv103 = v85;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v103, v80, v77, v79, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0051:\n\tUnityEngine.Debug::Log(v81);\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void dev(string format, params object[] args)
		{
			string text = StringUtils.TryFormat(format, args);
			string message = TAG + " " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x13E02B0", Offset = "0x13E02B0", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECD0B0]);\n\tv21 = *([v20 @ X8_v42]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028AC0]) = v40;\nL_0014:\n\tv41 = exception == 0;\n\tif (v41) goto L_00AE;\n\t// 26 NewArr v46 @ X0_v14 (System.String[]), typeof(System.String[]), 5\n\tgoto L_002E;\n\tv74 = *([v56 @ X8_v13 (Il2CppClass<LunarConsolePluginInternal.Log>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\t// 38 ConditionalJump @b48, v76 @ TEMP_v41\n\tv135 = v56;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v135, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv82 = LunarConsolePluginInternal.Log;\nL_002E:\n\tv138 = v136.TAG == 0;\n\tif (v138) goto L_0036;\n\t// 51 IsInst v192 @ X0_v45, typeof(System.String), v136.TAG (System.String)\nL_0036:\n\tv262 = v46.Length;\n\tv199 = v46.Length == 0;\n\tif (v199) goto L_00D4;\n\tv46[0] = v136.TAG;\n\tv204 = \" \" == 0;\n\tif (v204) goto L_0045;\n\t// 65 IsInst v302 @ X0_v43, typeof(System.String), \" \"\n\tv262 = v46.Length;\nL_0045:\n\tv319 = v262 < 1;\n\tv239 = ~v319;\n\tv235 = v262 - 1;\n\tv227 = v235 == 0;\n\tv320 = ~v239;\n\tv207 = v320 | v227;\n\tif (v207) goto L_00D4;\n\tv46[1] = \" \";\n\tv327 = System.Exception::get_Message(exception);\n\tv328 = v327 == 0;\n\tif (v328) goto L_0061;\n\t// 94 IsInst v303 @ X0_v42, typeof(System.String), v327 @ X0_v29 (System.String)\nL_0061:\n\tv263 = v46.Length;\n\tv331 = v46.Length < 2;\n\tv238 = ~v331;\n\tv234 = v46.Length - 2;\n\tv226 = v234 == 0;\n\tv332 = ~v238;\n\tv206 = v332 | v226;\n\tif (v206) goto L_00D4;\n\tv46[2] = v327;\n\tv335 = \"\\n\" == 0;\n\tif (v335) goto L_007A;\n\t// 118 IsInst v304 @ X0_v40, typeof(System.String), \"\n\"\n\tv263 = v46.Length;\nL_007A:\n\tv337 = v263 < 3;\n\tv240 = ~v337;\n\tv236 = v263 - 3;\n\tv228 = v236 == 0;\n\tv338 = ~v240;\n\tv208 = v338 | v228;\n\tif (v208) goto L_00D4;\n\tv46[3] = \"\\n\";\n\tv343 = System.Exception::get_StackTrace(exception);\n\tv344 = v343 == 0;\n\tif (v344) goto L_0097;\n\t// 147 IsInst v305 @ X0_v39, typeof(System.String), v343 @ X0_v34 (System.String)\nL_0097:\n\tv347 = v46.Length < 4;\n\tv112 = ~v347;\n\tv109 = v46.Length - 4;\n\tv103 = v109 == 0;\n\tv348 = ~v112;\n\tv88 = v348 | v103;\n\tif (v88) goto L_00D4;\n\tv46[4] = v343;\n\tv119 = System.String::Concat(v46);\n\tgoto L_00C3;\nL_00AE:\n\tgoto L_00BB;\n\tv60 = *([v49 @ X0_v7 (Il2CppClass<LunarConsolePluginInternal.Log>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_00BB;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = LunarConsolePluginInternal.Log;\nL_00BB:\n\tv119 = System.String::Concat(v68.TAG, \" Exception\");\nL_00C3:\n\tgoto L_00D2;\n\tv175 = *([v131 @ X8_v6+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_00D2;\n\tv200 = v131;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v200, v117, v85, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D2:\n\tUnityEngine.Debug::LogError(v119);\n\treturn;\nL_00D4:\n\tv264 = new System.IndexOutOfRangeException();\n\tgoto L_00D9;\n\tv317 = new System.ArrayTypeMismatchException();\nL_00D9:\n\tthrow v322;\n\tthrow System.NullReferenceException;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void e(Exception exception)
		{
			//IL_0053: Expected O, but got I4
			//IL_0312: Expected O, but got I
			//IL_00c0: Expected O, but got I4
			//IL_011e: Expected O, but got I4
			//IL_014a: Expected O, but got I4
			//IL_0370: Expected O, but got I
			//IL_01cc: Expected O, but got I4
			//IL_024c: Expected O, but got I4
			string message2;
			if (exception != null)
			{
				string[] array = new string[5];
				if (TAG != null)
				{
					object obj = TAG as string;
				}
				object obj2 = array.Length;
				if (array.Length != 0)
				{
					array[0] = TAG;
					if (" " != null)
					{
						object obj3 = " " as string;
						obj2 = array.Length;
					}
					bool flag = (long)(IntPtr)obj2 < 1L;
					bool flag2 = !flag;
					object obj4 = (long)(IntPtr)obj2 - 1L;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = " ";
						string message = exception.Message;
						if (message != null)
						{
							object obj5 = message as string;
						}
						object obj6 = array.Length;
						bool flag5 = array.Length < 2;
						bool flag6 = !flag5;
						object obj7 = array.Length - 2;
						bool flag7 = obj7 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							array[2] = message;
							if ("\n" != null)
							{
								object obj8 = "\n" as string;
								obj6 = array.Length;
							}
							bool flag9 = (long)(IntPtr)obj6 < 3L;
							bool flag10 = !flag9;
							object obj9 = (long)(IntPtr)obj6 - 3L;
							bool flag11 = obj9 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								array[3] = "\n";
								string stackTrace = exception.StackTrace;
								if (stackTrace != null)
								{
									object obj10 = stackTrace as string;
								}
								bool flag13 = array.Length < 4;
								bool flag14 = !flag13;
								object obj11 = array.Length - 4;
								bool flag15 = obj11 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									array[4] = stackTrace;
									message2 = string.Concat(array);
									goto IL_02af;
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			message2 = TAG + " Exception";
			goto IL_02af;
			IL_02af:
			Debug.LogError(message2);
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x13D5224", Offset = "0x13D5224", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EAA038]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, format, args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2028AC1]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, format, args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0025:\n\tv60 = LunarConsolePluginInternal.StringUtils::TryFormat(format, args);\n\tgoto L_003D;\n\tv68 = *([v64 @ X8_v9+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_003D;\n\tv83 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v83, v59, args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003D:\n\tLunarConsolePluginInternal.Log::e(exception, v60);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void e(Exception exception, string format, params object[] args)
		{
			string message = StringUtils.TryFormat(format, args);
			e(exception, message);
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x13D770C", Offset = "0x13D770C", Length = "0x31C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F09510]);\n\tv25 = *([v24 @ X8_v51]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, message, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028AC2]) = v43;\nL_0016:\n\tv44 = exception == 0;\n\tif (v44) goto L_010A;\n\t// 28 NewArr v49 @ X0_v13 (System.String[]), typeof(System.String[]), 7\n\tgoto L_0030;\n\tv78 = *([v59 @ X8_v12 (Il2CppClass<LunarConsolePluginInternal.Log>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\t// 40 ConditionalJump @b63, v80 @ TEMP_v54\n\tv96 = v59;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v96, v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv86 = LunarConsolePluginInternal.Log;\nL_0030:\n\tv99 = v97.TAG == 0;\n\tif (v99) goto L_0038;\n\t// 53 IsInst v163 @ X0_v61, typeof(System.String), v97.TAG (System.String)\nL_0038:\n\tv274 = v49.Length;\n\tv170 = v49.Length == 0;\n\tif (v170) goto L_0132;\n\tv49[0] = v97.TAG;\n\tv175 = \" \" == 0;\n\tif (v175) goto L_0047;\n\t// 67 IsInst v331 @ X0_v59, typeof(System.String), \" \"\n\tv274 = v49.Length;\nL_0047:\n\tv354 = v274 < 1;\n\tv235 = ~v354;\n\tv228 = v274 - 1;\n\tv214 = v228 == 0;\n\tv355 = ~v235;\n\tv179 = v355 | v214;\n\tif (v179) goto L_0132;\n\tv49[1] = \" \";\n\tv358 = message == 0;\n\tif (v358) goto L_005E;\n\t// 90 IsInst v332 @ X0_v58, typeof(System.String), message @ X1 (System.String)\n\tv274 = v49.Length;\nL_005E:\n\tv361 = v274 < 2;\n\tv236 = ~v361;\n\tv229 = v274 - 2;\n\tv215 = v229 == 0;\n\tv362 = ~v236;\n\tv180 = v362 | v215;\n\tif (v180) goto L_0132;\n\tv49[2] = message;\n\tv365 = \"\\n\" == 0;\n\tif (v365) goto L_0076;\n\t// 114 IsInst v333 @ X0_v56, typeof(System.String), \"\n\"\n\tv274 = v49.Length;\nL_0076:\n\tv367 = v274 < 3;\n\tv237 = ~v367;\n\tv230 = v274 - 3;\n\tv216 = v230 == 0;\n\tv368 = ~v237;\n\tv181 = v368 | v216;\n\tif (v181) goto L_0132;\n\tv49[3] = \"\\n\";\n\tv373 = System.Exception::get_Message(exception);\n\tv374 = v373 == 0;\n\tif (v374) goto L_0092;\n\t// 143 IsInst v334 @ X0_v55, typeof(System.String), v373 @ X0_v31 (System.String)\nL_0092:\n\tv275 = v49.Length;\n\tv377 = v49.Length < 4;\n\tv233 = ~v377;\n\tv226 = v49.Length - 4;\n\tv212 = v226 == 0;\n\tv378 = ~v233;\n\tv177 = v378 | v212;\n\tif (v177) goto L_0132;\n\tv49[4] = v373;\n\tv380 = \"\\n\" == 0;\n\tif (v380) goto L_00A9;\n\t// 165 IsInst v335 @ X0_v53, typeof(System.String), \"\n\"\n\tv275 = v49.Length;\nL_00A9:\n\tv382 = v275 < 5;\n\tv238 = ~v382;\n\tv231 = v275 - 5;\n\tv217 = v231 == 0;\n\tv383 = ~v238;\n\tv182 = v383 | v217;\n\tif (v182) goto L_0132;\n\tv49[5] = \"\\n\";\n\tv388 = System.Exception::get_StackTrace(exception);\n\tv389 = v388 == 0;\n\tif (v389) goto L_00C6;\n\t// 194 IsInst v336 @ X0_v52, typeof(System.String), v388 @ X0_v36 (System.String)\nL_00C6:\n\tv392 = v49.Length < 6;\n\tv234 = ~v392;\n\tv227 = v49.Length - 6;\n\tv213 = v227 == 0;\n\tv393 = ~v234;\n\tv178 = v393 | v213;\n\tif (v178) goto L_0132;\n\tv49[6] = v388;\n\tv405 = System.String::Concat(v49);\n\tgoto L_00EE;\nL_00DD:\n\tv430 = System.Exception::get_Message(v408._innerException);\n\tv433 = System.Exception::get_StackTrace(v408._innerException);\n\tv405 = System.String::Concat(v430, \"\\n\", v433);\nL_00EE:\n\tgoto L_00F7;\n\tv418 = *([v307 @ X8_v34+E0]);\n\tv419 = v418 == 0;\n\tv420 = ~v419;\n\tif (v420) goto L_00F7;\n\tv424 = v307;\n\tv422 = \"il2cpp_codegen_runtime_class_init\"(v424, v403, v282, v280, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00F7:\n\tUnityEngine.Debug::LogError(v405);\n\tv408 = v408._innerException;\n\tv425 = v408._innerException == 0;\n\tv301 = ~v425;\n\tif (v301) goto L_00DD;\n\treturn;\nL_010A:\n\tgoto L_0118;\n\tv63 = *([v52 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.Log>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0118;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v52, message, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = LunarConsolePluginInternal.Log;\nL_0118:\n\tv77 = System.String::Concat(v71.TAG, \" \", message);\n\tgoto L_0130;\n\tv145 = *([v92 @ X8_v8+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tgoto L_0130;\n\tv171 = v92;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v171, v76, v73, v74, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0130:\n\tUnityEngine.Debug::LogError(v77);\n\treturn;\nL_0132:\n\tv276 = new System.IndexOutOfRangeException();\n\tgoto L_0137;\n\tv352 = new System.ArrayTypeMismatchException();\nL_0137:\n\tthrow v357;\n\tthrow System.NullReferenceException;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void e(Exception exception, string message)
		{
			//IL_0053: Expected O, but got I4
			//IL_0440: Expected O, but got I
			//IL_00c0: Expected O, but got I4
			//IL_049e: Expected O, but got I
			//IL_0111: Expected O, but got I4
			//IL_04fc: Expected O, but got I
			//IL_0163: Expected O, but got I4
			//IL_01c1: Expected O, but got I4
			//IL_01ed: Expected O, but got I4
			//IL_055a: Expected O, but got I
			//IL_026f: Expected O, but got I4
			//IL_02ef: Expected O, but got I4
			if (exception != null)
			{
				string[] array = new string[7];
				if (TAG != null)
				{
					object obj = TAG as string;
				}
				object obj2 = array.Length;
				if (array.Length != 0)
				{
					array[0] = TAG;
					if (" " != null)
					{
						object obj3 = " " as string;
						obj2 = array.Length;
					}
					bool flag = (long)(IntPtr)obj2 < 1L;
					bool flag2 = !flag;
					object obj4 = (long)(IntPtr)obj2 - 1L;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = " ";
						if (message != null)
						{
							object obj5 = message as string;
							obj2 = array.Length;
						}
						bool flag5 = (long)(IntPtr)obj2 < 2L;
						bool flag6 = !flag5;
						object obj6 = (long)(IntPtr)obj2 - 2L;
						bool flag7 = obj6 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							array[2] = message;
							if ("\n" != null)
							{
								object obj7 = "\n" as string;
								obj2 = array.Length;
							}
							bool flag9 = (long)(IntPtr)obj2 < 3L;
							bool flag10 = !flag9;
							object obj8 = (long)(IntPtr)obj2 - 3L;
							bool flag11 = obj8 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								array[3] = "\n";
								string message2 = exception.Message;
								if (message2 != null)
								{
									object obj9 = message2 as string;
								}
								object obj10 = array.Length;
								bool flag13 = array.Length < 4;
								bool flag14 = !flag13;
								object obj11 = array.Length - 4;
								bool flag15 = obj11 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									array[4] = message2;
									if ("\n" != null)
									{
										object obj12 = "\n" as string;
										obj10 = array.Length;
									}
									bool flag17 = (long)(IntPtr)obj10 < 5L;
									bool flag18 = !flag17;
									object obj13 = (long)(IntPtr)obj10 - 5L;
									bool flag19 = obj13 == null;
									bool flag20 = !flag18;
									if (!(flag20 || flag19))
									{
										array[5] = "\n";
										string stackTrace = exception.StackTrace;
										if (stackTrace != null)
										{
											object obj14 = stackTrace as string;
										}
										bool flag21 = array.Length < 6;
										bool flag22 = !flag21;
										object obj15 = array.Length - 6;
										bool flag23 = obj15 == null;
										bool flag24 = !flag22;
										if (!(flag24 || flag23))
										{
											array[6] = stackTrace;
											string message3 = string.Concat(array);
											Exception ex = exception;
											while (true)
											{
												Debug.LogError(message3);
												ex = ex.InnerException;
												if (ex.InnerException != null)
												{
													string message4 = ex.InnerException.Message;
													string stackTrace2 = ex.InnerException.StackTrace;
													message3 = message4 + "\n" + stackTrace2;
													continue;
												}
												break;
											}
											return;
										}
									}
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
				throw ex3;
			}
			string message5 = TAG + " " + message;
			Debug.LogError(message5);
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x13DAA68", Offset = "0x13DAA68", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED92D8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AC3]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::TryFormat(format, args);\n\tgoto L_0039;\n\tv65 = *([v61 @ X8_v9+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0039;\n\tv78 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v78, v56, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tLunarConsolePluginInternal.Log::e(v57);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void e(string format, params object[] args)
		{
			string message = StringUtils.TryFormat(format, args);
			e(message);
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x13E04EC", Offset = "0x13E04EC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECA838]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AC4]) = v38;\nL_0019:\n\tgoto L_0027;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.Log>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0027;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = LunarConsolePluginInternal.Log;\nL_0027:\n\tv59 = System.String::Concat(v53.TAG, \" \", message);\n\tgoto L_003D;\n\tv68 = *([v64 @ X8_v8+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_003D;\n\tv81 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v81, v58, v55, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tUnityEngine.Debug::LogError(v59);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void e(string message)
		{
			string message2 = TAG + " " + message;
			Debug.LogError(message2);
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x13D8698", Offset = "0x13D8698", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EACC40]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AC5]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::TryFormat(format, args);\n\tgoto L_0039;\n\tv65 = *([v61 @ X8_v9+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0039;\n\tv78 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v78, v56, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tLunarConsolePluginInternal.Log::w(v57);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void w(string format, params object[] args)
		{
			string message = StringUtils.TryFormat(format, args);
			w(message);
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x13D9444", Offset = "0x13D9444", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA3880]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AC6]) = v38;\nL_0019:\n\tgoto L_0027;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.Log>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0027;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = LunarConsolePluginInternal.Log;\nL_0027:\n\tv59 = System.String::Concat(v53.TAG, \" \", message);\n\tgoto L_003D;\n\tv68 = *([v64 @ X8_v8+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_003D;\n\tv81 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v81, v58, v55, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tUnityEngine.Debug::LogWarning(v59);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void w(string message)
		{
			string message2 = TAG + " " + message;
			Debug.LogWarning(message2);
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x13E05A0", Offset = "0x13E05A0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDA838]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AC7]) = v35;\nL_0017:\n\tgoto L_0027;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.Constants>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = LunarConsolePluginInternal.Constants;\nL_0027:\n\tv58 = System.String::Concat(\"[\", v51.PluginDisplayName, \"]\");\n\tv63.TAG = v58;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Log()
		{
			string tAG = "[" + Constants.PluginDisplayName + "]";
			TAG = tAG;
		}
	}
}
