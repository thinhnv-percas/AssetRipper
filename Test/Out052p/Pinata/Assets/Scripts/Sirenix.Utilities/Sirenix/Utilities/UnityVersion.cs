using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Sirenix.Utilities
{
	[Token(Token = "0x2000009")]
	public static class UnityVersion
	{
		[Token(Token = "0x4000015")]
		public static readonly int Major;

		[Token(Token = "0x4000016")]
		public static readonly int Minor;

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x165B1E4", Offset = "0x165B1E4", Length = "0x410")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ECFEF0]);\n\tv21 = *([v20 @ X8_v68]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202AF35]) = v41;\nL_0015:\n\tv43 = UnityEngine.Application::get_unityVersion();\n\t// 28 NewArr v50 @ X0_v5 (System.Char[]), typeof(System.Char[]), 1\n\tv54 = v50.Length == 0;\n\tif (v54) goto L_01A4;\n\tv50[0] = 0x2E;\n\tv111 = System.String::Split(v43, v50);\n\tv64 = v111.Length <= 1;\n\tif (v64) goto L_00F6;\n\tv450 = System.Int32::TryParse(v111[0], v448.Major);\n\tv454 = v450 == 0;\n\tv455 = ~v454;\n\tif (v455) goto L_00D8;\n\t// 75 NewArr v112 @ X0_v55 (System.String[]), typeof(System.String[]), 5\n\tv508 = \"Could not parse major part '\" == 0;\n\tif (v508) goto L_0059;\n\t// 86 IsInst v310 @ X0_v78, typeof(System.String), \"Could not parse major part '\"\nL_0059:\n\tv273 = v112.Length;\n\tv254 = v112.Length == 0;\n\tif (v254) goto L_01A4;\n\tv112[0] = \"Could not parse major part '\";\n\tv255 = v111.Length == 0;\n\tif (v255) goto L_01A4;\n\tv521 = v111[0] == 0;\n\tif (v521) goto L_006B;\n\t// 103 IsInst v311 @ X0_v77, typeof(System.String), v111[0]\n\tv273 = v112.Length;\nL_006B:\n\tv527 = v273 < 1;\n\tv219 = ~v527;\n\tv209 = v273 - 1;\n\tv189 = v209 == 0;\n\tv528 = ~v219;\n\tv139 = v528 | v189;\n\tif (v139) goto L_01A4;\n\tv112[1] = v111[0];\n\tv533 = \"' of Unity version '\" == 0;\n\tif (v533) goto L_0083;\n\t// 127 IsInst v312 @ X0_v75, typeof(System.String), \"' of Unity version '\"\n\tv273 = v112.Length;\nL_0083:\n\tv538 = v273 < 2;\n\tv220 = ~v538;\n\tv210 = v273 - 2;\n\tv190 = v210 == 0;\n\tv539 = ~v220;\n\tv140 = v539 | v190;\n\tif (v140) goto L_01A4;\n\tv112[2] = \"' of Unity version '\";\n\tv543 = UnityEngine.Application::get_unityVersion();\n\tv548 = v543 == 0;\n\tif (v548) goto L_009C;\n\t// 153 IsInst v313 @ X0_v74, typeof(System.String), v543 @ X0_v62 (System.String)\nL_009C:\n\tv274 = v112.Length;\n\tv554 = v112.Length < 3;\n\tv216 = ~v554;\n\tv206 = v112.Length - 3;\n\tv186 = v206 == 0;\n\tv555 = ~v216;\n\tv136 = v555 | v186;\n\tif (v136) goto L_01A4;\n\tv112[3] = v543;\n\tv561 = \"'.\" == 0;\n\tif (v561) goto L_00B5;\n\t// 177 IsInst v314 @ X0_v72, typeof(System.String), \"'.\"\n\tv274 = v112.Length;\nL_00B5:\n\tv566 = v274 < 4;\n\tv221 = ~v566;\n\tv211 = v274 - 4;\n\tv191 = v211 == 0;\n\tv567 = ~v221;\n\tv141 = v567 | v191;\n\tif (v141) goto L_01A4;\n\tv112[4] = \"'.\";\n\tv572 = System.String::Concat(v112);\n\tgoto L_00D6;\n\tv585 = *([v483 @ X8_v57+E0]);\n\tv586 = v585 == 0;\n\tv587 = ~v586;\n\tif (v587) goto L_00D6;\n\tv593 = v483;\n\tv589 = \"il2cpp_codegen_runtime_class_init\"(v593, v571, v100, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D6:\n\tUnityEngine.Debug::LogError(v572);\nL_00D8:\n\tv484 = v111.Length < 1;\n\tv97 = ~v484;\n\tv93 = v111.Length - 1;\n\tv85 = v93 == 0;\n\tv485 = ~v97;\n\tv65 = v485 | v85;\n\tif (v65) goto L_01A4;\n\tv429 = v486.Major + 4;\n\tv432 = System.Int32::TryParse(v111[1], v429);\n\tv435 = v432 == 0;\n\tif (v435) goto L_0106;\n\treturn;\nL_00F6:\n\tv452 = UnityEngine.Application::get_unityVersion();\n\tv494 = System.String::Concat(\"Could not parse current Unity version '\", v452, \"'; not enough version elements.\");\n\tgoto L_0192;\nL_0106:\n\t// 262 NewArr v113 @ X0_v34 (System.String[]), typeof(System.String[]), 5\n\tv524 = \"Could not parse minor part '\" == 0;\n\tif (v524) goto L_0114;\n\t// 273 IsInst v315 @ X0_v53, typeof(System.String), \"Could not parse minor part '\"\nL_0114:\n\tv276 = v113.Length;\n\tv258 = v113.Length == 0;\n\tif (v258) goto L_01A4;\n\tv113[0] = \"Could not parse minor part '\";\n\tv535 = v111.Length < 1;\n\tv217 = ~v535;\n\tv207 = v111.Length - 1;\n\tv187 = v207 == 0;\n\tv536 = ~v217;\n\tv137 = v536 | v187;\n\tif (v137) goto L_01A4;\n\tv540 = v111[1] == 0;\n\tif (v540) goto L_0130;\n\t// 300 IsInst v316 @ X0_v52, typeof(System.String), v111[1]\n\tv276 = v113.Length;\nL_0130:\n\tv546 = v276 < 1;\n\tv222 = ~v546;\n\tv212 = v276 - 1;\n\tv192 = v212 == 0;\n\tv547 = ~v222;\n\tv142 = v547 | v192;\n\tif (v142) goto L_01A4;\n\tv113[1] = v111[1];\n\tv551 = \"' of Unity version '\" == 0;\n\tif (v551) goto L_0148;\n\t// 324 IsInst v317 @ X0_v50, typeof(System.String), \"' of Unity version '\"\n\tv276 = v113.Length;\nL_0148:\n\tv557 = v276 < 2;\n\tv223 = ~v557;\n\tv213 = v276 - 2;\n\tv193 = v213 == 0;\n\tv558 = ~v223;\n\tv143 = v558 | v193;\n\tif (v143) goto L_01A4;\n\tv113[2] = \"' of Unity version '\";\n\tv564 = UnityEngine.Application::get_unityVersion();\n\tv568 = v564 == 0;\n\tif (v568) goto L_0161;\n\t// 350 IsInst v318 @ X0_v49, typeof(System.String), v564 @ X0_v41 (System.String)\nL_0161:\n\tv277 = v113.Length;\n\tv575 = v113.Length < 3;\n\tv218 = ~v575;\n\tv208 = v113.Length - 3;\n\tv188 = v208 == 0;\n\tv576 = ~v218;\n\tv138 = v576 | v188;\n\tif (v138) goto L_01A4;\n\tv113[3] = v564;\n\tv584 = \"'.\" == 0;\n\tif (v584) goto L_017A;\n\t// 374 IsInst v319 @ X0_v47, typeof(System.String), \"'.\"\n\tv277 = v113.Length;\nL_017A:\n\tv591 = v277 < 4;\n\tv224 = ~v591;\n\tv214 = v277 - 4;\n\tv194 = v214 == 0;\n\tv592 = ~v224;\n\tv144 = v592 | v194;\n\tif (v144) goto L_01A4;\n\tv113[4] = \"'.\";\n\tv494 = System.String::Concat(v113);\nL_0192:\n\tgoto L_01A2;\n\tv510 = *([v439 @ X8_v16+E0]);\n\tv511 = v510 == 0;\n\tv512 = ~v511;\n\tif (v512) goto L_01A2;\n\tv519 = v439;\n\tv514 = \"il2cpp_codegen_runtime_class_init\"(v519, v492, v425, v393, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_01A2:\n\tUnityEngine.Debug::LogError(v494);\n\treturn;\nL_01A4:\n\tv283 = new System.IndexOutOfRangeException();\n\tgoto L_01AA;\n\tv123 = new System.NullReferenceException();\n\tv343 = new System.ArrayTypeMismatchException();\nL_01AA:\n\tthrow v387;\n\tthrow System.NullReferenceException;\n// 249 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		unsafe static UnityVersion()
		{
			//IL_036c: Expected O, but got I4
			//IL_0106: Expected O, but got I4
			//IL_0461: Expected O, but got I4
			//IL_04bf: Expected O, but got I4
			//IL_0736: Expected O, but got I
			//IL_0850: Expected O, but got I
			//IL_01a4: Expected O, but got I4
			//IL_0794: Expected O, but got I
			//IL_0541: Expected O, but got I4
			//IL_08ae: Expected O, but got I
			//IL_0200: Expected O, but got I4
			//IL_025a: Expected O, but got I4
			//IL_0286: Expected O, but got I4
			//IL_059d: Expected O, but got I4
			//IL_05f7: Expected O, but got I4
			//IL_0623: Expected O, but got I4
			//IL_07f2: Expected O, but got I
			//IL_090c: Expected O, but got I
			//IL_0308: Expected O, but got I4
			//IL_06a5: Expected O, but got I4
			string unityVersion = Application.unityVersion;
			char[] array = new char[1];
			string[] array2;
			string message;
			if (array.Length != 0)
			{
				array[0] = '.';
				array2 = unityVersion.Split(array);
				if (array2.Length <= 1)
				{
					string unityVersion2 = Application.unityVersion;
					message = "Could not parse current Unity version '" + unityVersion2 + "'; not enough version elements.";
					goto IL_06d4;
				}
				if (int.TryParse(array2[0], out Major))
				{
					goto IL_0340;
				}
				string[] array3 = new string[5];
				if ("Could not parse major part '" != null)
				{
					object obj = "Could not parse major part '" as string;
				}
				object obj2 = array3.Length;
				if (array3.Length != 0)
				{
					array3[0] = "Could not parse major part '";
					if (array2.Length != 0)
					{
						if (array2[0] != null)
						{
							object obj3 = array2[0] as string;
							obj2 = array3.Length;
						}
						bool flag = (long)(IntPtr)obj2 < 1L;
						bool flag2 = !flag;
						object obj4 = (long)(IntPtr)obj2 - 1L;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							array3[1] = array2[0];
							if ("' of Unity version '" != null)
							{
								object obj5 = "' of Unity version '" as string;
								obj2 = array3.Length;
							}
							bool flag5 = (long)(IntPtr)obj2 < 2L;
							bool flag6 = !flag5;
							object obj6 = (long)(IntPtr)obj2 - 2L;
							bool flag7 = obj6 == null;
							bool flag8 = !flag6;
							if (!(flag8 || flag7))
							{
								array3[2] = "' of Unity version '";
								string unityVersion3 = Application.unityVersion;
								if (unityVersion3 != null)
								{
									object obj7 = unityVersion3 as string;
								}
								object obj8 = array3.Length;
								bool flag9 = array3.Length < 3;
								bool flag10 = !flag9;
								object obj9 = array3.Length - 3;
								bool flag11 = obj9 == null;
								bool flag12 = !flag10;
								if (!(flag12 || flag11))
								{
									array3[3] = unityVersion3;
									if ("'." != null)
									{
										object obj10 = "'." as string;
										obj8 = array3.Length;
									}
									bool flag13 = (long)(IntPtr)obj8 < 4L;
									bool flag14 = !flag13;
									object obj11 = (long)(IntPtr)obj8 - 4L;
									bool flag15 = obj11 == null;
									bool flag16 = !flag14;
									if (!(flag16 || flag15))
									{
										array3[4] = "'.";
										string message2 = string.Concat(array3);
										Debug.LogError(message2);
										goto IL_0340;
									}
								}
							}
						}
					}
				}
			}
			goto IL_06de;
			IL_06de:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_06d4:
			Debug.LogError(message);
			return;
			IL_0340:
			bool flag17 = array2.Length < 1;
			bool flag18 = !flag17;
			object obj12 = array2.Length - 1;
			bool flag19 = obj12 == null;
			bool flag20 = !flag18;
			if (!(flag20 || flag19))
			{
				ref int result = ref *(int*)(Major + 4);
				if (int.TryParse(array2[1], out result))
				{
					return;
				}
				string[] array4 = new string[5];
				if ("Could not parse minor part '" != null)
				{
					object obj13 = "Could not parse minor part '" as string;
				}
				object obj14 = array4.Length;
				if (array4.Length != 0)
				{
					array4[0] = "Could not parse minor part '";
					bool flag21 = array2.Length < 1;
					bool flag22 = !flag21;
					object obj15 = array2.Length - 1;
					bool flag23 = obj15 == null;
					bool flag24 = !flag22;
					if (!(flag24 || flag23))
					{
						if (array2[1] != null)
						{
							object obj16 = array2[1] as string;
							obj14 = array4.Length;
						}
						bool flag25 = (long)(IntPtr)obj14 < 1L;
						bool flag26 = !flag25;
						object obj17 = (long)(IntPtr)obj14 - 1L;
						bool flag27 = obj17 == null;
						bool flag28 = !flag26;
						if (!(flag28 || flag27))
						{
							array4[1] = array2[1];
							if ("' of Unity version '" != null)
							{
								object obj18 = "' of Unity version '" as string;
								obj14 = array4.Length;
							}
							bool flag29 = (long)(IntPtr)obj14 < 2L;
							bool flag30 = !flag29;
							object obj19 = (long)(IntPtr)obj14 - 2L;
							bool flag31 = obj19 == null;
							bool flag32 = !flag30;
							if (!(flag32 || flag31))
							{
								array4[2] = "' of Unity version '";
								string unityVersion4 = Application.unityVersion;
								if (unityVersion4 != null)
								{
									object obj20 = unityVersion4 as string;
								}
								object obj21 = array4.Length;
								bool flag33 = array4.Length < 3;
								bool flag34 = !flag33;
								object obj22 = array4.Length - 3;
								bool flag35 = obj22 == null;
								bool flag36 = !flag34;
								if (!(flag36 || flag35))
								{
									array4[3] = unityVersion4;
									if ("'." != null)
									{
										object obj23 = "'." as string;
										obj21 = array4.Length;
									}
									bool flag37 = (long)(IntPtr)obj21 < 4L;
									bool flag38 = !flag37;
									object obj24 = (long)(IntPtr)obj21 - 4L;
									bool flag39 = obj24 == null;
									bool flag40 = !flag38;
									if (!(flag40 || flag39))
									{
										array4[4] = "'.";
										message = string.Concat(array4);
										goto IL_06d4;
									}
								}
							}
						}
					}
				}
			}
			goto IL_06de;
		}

		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x600001C")]
		[Address(RVA = "0x165B5F4", Offset = "0x165B5F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void EnsureLoaded()
		{
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x165B5F8", Offset = "0x165B5F8", Length = "0x10E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE5F98]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, minor, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF36]) = v41;\nL_001B:\n\tgoto L_002F;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Sirenix.Utilities.UnityVersion>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002F;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v44, minor, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Sirenix.Utilities.UnityVersion;\nL_002F:\n\tv68 = v55.Major <= major;\n\tif (v68) goto L_0036;\n\tgoto L_0069;\nL_0036:\n\tgoto L_0048;\n\tv121 = *([v51 @ X0_v3 (Il2CppClass<Sirenix.Utilities.UnityVersion>)+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0048;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v51, minor, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv126 = Sirenix.Utilities.UnityVersion;\n\tv127 = *([v126 @ X0_v11+B8]);\n\tv124 = *([v127 @ X8_v12]);\nL_0048:\n\tv75 = v55.Major != major;\n\tif (v75) goto L_FFFFFFFF;\n\tgoto L_0058;\n\tv133 = *([v125 @ X0_v5+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0058;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v125, minor, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv141 = Sirenix.Utilities.UnityVersion;\n\tv139 = *([v141 @ X8_v10+B8]);\nL_0058:\n\tv97 = v138.Minor - minor;\n\tv94 = v97 < 0;\n\tv88 = v138.Minor ^ minor;\n\tv85 = v138.Minor ^ v97;\n\tv82 = v88 & v85;\n\tv79 = v82 < 0;\n\tv76 = v94 == v79;\n\tgoto L_0069;\nL_0069:\n\treturn returnVal1;\n\tAndroidTenjin::Init(X0, X1, X2);\n\treturn X0;\n\tX9 = *([X9+6B8]);\n\tX0 = 0x165A004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\treturn X0;\n// 1083 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsVersionOrGreater(int major, int minor)
		{
			if (Major > major)
			{
				return true;
			}
			if (Major != major)
			{
				return false;
			}
			int num = Minor - minor;
			bool flag = num < 0;
			int num2 = Minor ^ minor;
			int num3 = Minor ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			return flag == flag2;
		}
	}
}
