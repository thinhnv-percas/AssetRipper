using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000021")]
	public class Vector3ArrayPlugin : ABSTweenPlugin<Vector3, Vector3[], Vector3ArrayOptions>
	{
		[Token(Token = "0x60001A3")]
		[Address(RVA = "0x10DE9C4", Offset = "0x10DE9C4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.endValue = 0;\n\tt.changeValue = 0;\n\tt.startValue = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			t.endValue = null;
			t.changeValue = null;
			t.startValue = null;
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0x10DE9E4", Offset = "0x10DE9E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool isRelative)
		{
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0x10DE9E8", Offset = "0x10DE9E8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, Vector3[] fromValue, bool setImmediately)
		{
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x10DE9EC", Offset = "0x10DE9EC", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EDB388]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, t, methodInfo, v34, v35, v36, v37, v38, value, v0, v2, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20274E3]) = v47;\nL_001D:\n\tv49 = t.endValue;\n\t// 37 NewArr returnVal2 @ X0_v7 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v49.Length\n\tv183 = v49.Length < 1;\n\tif (v183) goto L_007B;\n\tv69 = returnVal2 + 0x20;\nL_0036:\n\tv262 = v122 == 0;\n\tif (v262) goto L_005F;\n\tv67 = t.endValue;\n\tv138 = v75 - 1;\n\tv263 = v138 < v67.Length;\n\tv162 = ~v263;\n\tif (v162) goto L_007C;\n\tv294 = v75 < returnVal2.Length;\n\tv277 = ~v294;\n\tif (v277) goto L_007C;\n\tv281 = v67 + v122;\n\tv187 = *([v281 @ X12_v10+14]);\n\tv223 = *([v281 @ X12_v10+18]);\n\tv221 = *([v281 @ X12_v10+1C]);\n\tgoto L_0061;\nL_005F:\n\tv268 = returnVal2.Length == 0;\n\tif (v268) goto L_007C;\nL_0061:\n\tv75 = v75 + 1;\n\tv193 = v69 + v122;\n\tv122 = v122 + 0xC;\n\t*([v193 @ X12_v7]) = v187;\n\t*([v193 @ X12_v7+4]) = v223;\n\t*([v193 @ X12_v7+8]) = v221;\n\tv199 = v75 < v49.Length;\n\tif (v199) goto L_0036;\nL_007B:\n\treturn returnVal2;\nL_007C:\n\tv278 = new System.IndexOutOfRangeException();\n\tthrow v278;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector3[] ConvertToStartValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, Vector3 value)
		{
			//IL_0054: Expected O, but got I
			//IL_017d: Expected O, but got I
			//IL_00eb: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_010b: Expected F4, but got I
			//IL_011b: Expected F4, but got I
			Vector3[] endValue = t.endValue;
			Vector3[] array = new Vector3[endValue.Length];
			if (endValue.Length >= 1)
			{
				object obj = (long)(IntPtr)array + 32L;
				int num = 0;
				int num2 = 0;
				do
				{
					Vector3 vector;
					if (num2 != 0)
					{
						Vector3[] endValue2 = t.endValue;
						int num3 = num - 1;
						if (num3 < endValue2.Length && num < array.Length)
						{
							object obj2 = (long)(IntPtr)endValue2 + (long)num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X12_v10+14]");
							vector = (Vector3)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X12_v10+18]");
							float num4 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X12_v10+1C]");
							float num5 = 0f;
							goto IL_0161;
						}
					}
					else
					{
						bool flag = array.Length == 0;
						vector = value;
						float num5 = value.z;
						float num4 = value.y;
						if (!flag)
						{
							goto IL_0161;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_0161:
					num++;
					object obj3 = (long)(IntPtr)obj + (long)num2;
					num2 += 12;
					obj3 = vector;
				}
				while (num < endValue.Length);
			}
			return array;
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x10DEB0C", Offset = "0x10DEB0C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv40 = *([1EC1678]);\n\tv41 = *([v40 @ X8_v21]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, t, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 0 | 1;\n\t*([20274E4]) = v60;\nL_0020:\n\tv62 = t.endValue;\n\tv230 = v62.Length < 1;\n\tif (v230) goto L_00CC;\nL_003F:\n\tv144 = v216 < 1;\n\tif (v144) goto L_0066;\n\tv213 = t.endValue;\n\tv128 = v216 - 1;\n\tv382 = v128 < v213.Length;\n\tv199 = ~v382;\n\tif (v199) goto L_00CD;\n\tv134 = t.startValue;\n\tv403 = v216 < v134.Length;\n\tv377 = ~v403;\n\tif (v377) goto L_00CD;\n\tv405 = v213 + v138;\n\tv369 = v134 + v138;\n\t*([v369 @ X9_v10-8]) = *([v405 @ X8_v17-14]);\n\t*([v369 @ X9_v10-4]) = *([v405 @ X8_v17-10]);\n\t*([v369 @ X9_v10]) = *([v405 @ X8_v17-C]);\nL_0066:\n\tv214 = t.startValue;\n\tv383 = v216 < v214.Length;\n\tv200 = ~v383;\n\tif (v200) goto L_00CD;\n\tv118 = t.endValue;\n\tv404 = v216 < v118.Length;\n\tv399 = ~v404;\n\tif (v399) goto L_00CD;\n\tv407 = v214 + v138;\n\tv263 = v118 + v138;\n\tgoto L_009B;\n\tv411 = *([v406 @ X0_v7+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tif (v413) goto L_009B;\n\tv415 = \"il2cpp_codegen_runtime_class_init\"(v406, t, methodInfo, v44, v45, v46, v47, v48, v93, v90, v87, v84, v81, v78, v55, v56);\nL_009B:\n\t// 155 MakeStruct v237 @ AGG10DEC44_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v407 @ X8_v10-8], [v407 @ X8_v10-4], [v407 @ X8_v10]\n\t// 156 MakeStruct v235 @ AGG10DEC44_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v263 @ X25_v5-8], [v263 @ X25_v5-4], [v263 @ X25_v5]\n\tv249 = UnityEngine.Vector3::op_Addition(v237, v235);\n\tv420 = v216 < v118.Length;\n\tv400 = ~v420;\n\tif (v400) goto L_00CD;\n\tv216 = v216 + 1;\n\t*([v263 @ X25_v5-8]) = v249;\n\t*([v263 @ X25_v5-4]) = v249.y;\n\t*([v118 @ X24_v5 (UnityEngine.Vector3[])+v138 @ X22_v5 (System.Int32)]) = v249.z;\n\tv138 = v138 + 0xC;\n\tv274 = v216 < v62.Length;\n\tif (v274) goto L_003F;\nL_00CC:\n\treturn;\nL_00CD:\n\tv402 = new System.IndexOutOfRangeException();\n\tthrow v402;\n\tthrow System.NullReferenceException;\n// 154 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_018e: Expected O, but got I
			//IL_019c: Expected O, but got I
			//IL_01b6: Expected F4, but got I
			//IL_01cb: Expected F4, but got I
			//IL_01d8: Expected F4, but got O
			//IL_01ed: Expected F4, but got I
			//IL_0202: Expected F4, but got I
			//IL_020f: Expected F4, but got O
			//IL_00df: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_0117: Expected O, but got I
			Vector3[] endValue = t.endValue;
			if (endValue.Length < 1)
			{
				return;
			}
			int num = 40;
			int num2 = 0;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			while (true)
			{
				if (num2 >= 1)
				{
					Vector3[] endValue2 = t.endValue;
					int num3 = num2 - 1;
					if (num3 >= endValue2.Length)
					{
						break;
					}
					Vector3[] startValue = t.startValue;
					if (num2 >= startValue.Length)
					{
						break;
					}
					object obj = (long)(IntPtr)endValue2 + (long)num;
					object obj2 = (long)(IntPtr)startValue + (long)num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v17-14]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v17-10]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v17-C]");
					obj2 = 0;
				}
				Vector3[] startValue2 = t.startValue;
				if (num2 >= startValue2.Length)
				{
					break;
				}
				Vector3[] endValue3 = t.endValue;
				if (num2 >= endValue3.Length)
				{
					break;
				}
				object obj3 = (long)(IntPtr)startValue2 + (long)num;
				object obj4 = (long)(IntPtr)endValue3 + (long)num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v10-8]");
				vector.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ X8_v10-4]");
				vector.y = 0f;
				vector.z = (float)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X25_v5-8]");
				vector2.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X25_v5-4]");
				vector2.y = 0f;
				vector2.z = (float)obj4;
				Vector3 vector3 = vector + vector2;
				if (num2 >= endValue3.Length)
				{
					break;
				}
				num2++;
				_ = vector3.y;
				_ = vector3.z;
				num += 12;
				if (num2 >= endValue.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x10DECA8", Offset = "0x10DECA8", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv38 = *([1ED5D60]);\n\tv39 = *([v38 @ X8_v20]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 0 | 1;\n\t*([20274E5]) = v58;\nL_001F:\n\tv60 = t.endValue;\n\t// 39 NewArr v182 @ X0_v7 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v60.Length\n\tt.changeValue = v182;\n\tv125 = v60.Length < 1;\n\tif (v125) goto L_00A9;\n\tv192 = t.endValue;\nL_003F:\n\tv335 = v116 < v192.Length;\n\tv173 = ~v335;\n\tif (v173) goto L_00AA;\n\tv113 = t.startValue;\n\tv347 = v116 < v113.Length;\n\tv174 = ~v347;\n\tif (v174) goto L_00AA;\n\tv349 = v192 + v119;\n\tv350 = v113 + v119;\n\tgoto L_0070;\n\tv353 = *([v348 @ X0_v12+E0]);\n\tv354 = v353 == 0;\n\tv355 = ~v354;\n\tif (v355) goto L_0070;\n\tv357 = \"il2cpp_codegen_runtime_class_init\"(v348, v176, methodInfo, v42, v43, v44, v45, v46, v87, v84, v81, v78, v75, v72, v53, v54);\nL_0070:\n\t// 112 MakeStruct v67 @ AGG10DEDAC_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v349 @ X8_v11+20], [v349 @ X8_v11+24], [v349 @ X8_v11+28]\n\t// 113 MakeStruct v63 @ AGG10DEDAC_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v350 @ X8_v12+20], [v350 @ X8_v12+24], [v350 @ X8_v12+28]\n\tv86 = UnityEngine.Vector3::op_Subtraction(v67, v63);\n\tv362 = v116 < v197.Length;\n\tv343 = ~v362;\n\tif (v343) goto L_00AA;\n\tv116 = v116 + 1;\n\tv236 = v197 + v119;\n\t*([v236 @ X8_v15+20]) = v86;\n\t*([v236 @ X8_v15+24]) = v86.y;\n\t*([v236 @ X8_v15+28]) = v86.z;\n\tv123 = v116 >= v60.Length;\n\tif (v123) goto L_00A9;\n\tv192 = t.endValue;\n\tv197 = t.changeValue;\n\tv119 = v119 + 0xC;\n\tv364 = t.endValue == 0;\n\tv185 = ~v364;\n\tif (v185) goto L_003F;\n\tthrow System.NullReferenceException;\nL_00A9:\n\treturn;\nL_00AA:\n\tv346 = new System.IndexOutOfRangeException();\n\tthrow v346;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_00cc: Expected O, but got I
			//IL_00da: Expected O, but got I
			//IL_00f4: Expected F4, but got I
			//IL_0109: Expected F4, but got I
			//IL_011e: Expected F4, but got I
			//IL_0133: Expected F4, but got I
			//IL_0148: Expected F4, but got I
			//IL_015d: Expected F4, but got I
			//IL_01b8: Expected O, but got I
			Vector3[] endValue = t.endValue;
			Vector3[] array = (t.changeValue = new Vector3[endValue.Length]);
			if (endValue.Length < 1)
			{
				return;
			}
			Vector3[] endValue2 = t.endValue;
			int num = 0;
			int num2 = 0;
			Vector3[] array2 = array;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			while (num < endValue2.Length)
			{
				Vector3[] startValue = t.startValue;
				if (num >= startValue.Length)
				{
					break;
				}
				object obj = (long)(IntPtr)endValue2 + (long)num2;
				object obj2 = (long)(IntPtr)startValue + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ X8_v11+20]");
				vector.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ X8_v11+24]");
				vector.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ X8_v11+28]");
				vector.z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ X8_v12+20]");
				vector2.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ X8_v12+24]");
				vector2.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ X8_v12+28]");
				vector2.z = 0f;
				Vector3 vector3 = vector - vector2;
				if (num >= array2.Length)
				{
					break;
				}
				num++;
				object obj3 = (long)(IntPtr)array2 + (long)num2;
				_ = vector3.y;
				_ = vector3.z;
				if (num < endValue.Length)
				{
					endValue2 = t.endValue;
					array2 = t.changeValue;
					num2 += 12;
					if (t.endValue == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x10DEE1C", Offset = "0x10DEE1C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = Il2CppClass<DG.Tweening.Plugins.Vector3ArrayPlugin> < 1;\n\tif (v36) goto L_FFFFFFFF;\n\tv103 = Il2CppClass<DG.Tweening.Plugins.Vector3ArrayPlugin> & 0xFFFFFFFF;\n\tv104 = v103 == 0;\n\tif (v104) goto L_0051;\n\tv54 = changeValue + 0x20;\n\tv52 = methodInfo + 0x20;\nL_0026:\n\tv42 = 0x158AD58(v52, 0, changeValue, methodInfo, v93, v94, v95, v96, v45, *([v54 @ X24_v6+v58 @ X22_v7 (System.Int32)*4]), v97, v98, v99, v100, v101, v102);\n\tv247 = v58 < changeValue.Length;\n\tv174 = ~v247;\n\tif (v174) goto L_0051;\n\tv45 = v45 / *([v54 @ X24_v6+v58 @ X22_v7 (System.Int32)*4]);\n\t*([v54 @ X24_v6+v58 @ X22_v7 (System.Int32)*4]) = v45;\n\tv58 = v58 + 1;\n\tv50 = v50 + v45;\n\tv189 = v58 >= v103;\n\tif (v189) goto L_0061;\n\tv52 = v52 + 0xC;\n\tv249 = v58 < Il2CppClass<DG.Tweening.Plugins.Vector3ArrayPlugin>;\n\tv173 = ~v249;\n\tv158 = ~v173;\n\tif (v158) goto L_0026;\nL_0051:\n\tv177 = new System.IndexOutOfRangeException();\n\tthrow v177;\nL_0061:\n\treturn v50;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(Vector3ArrayOptions options, float unitsXSecond, Vector3[] changeValue)
		{
			//IL_002b: Expected I4, but got I8
			//IL_0057: Expected O, but got I
			//IL_0066: Expected O, but got I
			//IL_010d: Expected O, but got I
			float num2;
			if (0L >= 1L)
			{
				int num = 0;
				if (num != 0)
				{
					object obj = (long)(IntPtr)changeValue + 32L;
					IntPtr intPtr = default(IntPtr);
					object obj2 = (long)intPtr + 32L;
					num2 = 0f;
					int num3 = 0;
					float num5 = default(float);
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
						if (num3 >= changeValue.Length)
						{
							break;
						}
						float num4 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v6+v58 @ X22_v7 (System.Int32)*4]");
						num5 = num4 / 0f;
						num3++;
						num2 += num5;
						if (num3 < num)
						{
							obj2 = (long)(IntPtr)obj2 + 12L;
							if ((long)num3 >= 0L)
							{
								break;
							}
							continue;
						}
						goto IL_0159;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			num2 = 0f;
			goto IL_0159;
			IL_0159:
			return num2;
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x10DEEE8", Offset = "0x10DEEE8", Length = "0x8E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = &v39 @ stack_-10_v2;\n\tv42 = *([v38 @ X29_v1+10]);\n\tgoto L_002F;\n\tv61 = *([1EE2B70]);\n\tv62 = *([v61 @ X8_v113]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v66, v67, v68, v69, v70, v71);\n\tv75 = 0 | 1;\n\t*([20274E6]) = v75;\nL_002F:\n\tgoto L_0036;\n\tv82 = *([v78 @ X0_v2+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_0036;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v78, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v66, v67, v68, v69, v70, v71);\nL_0036:\n\tv90 = UnityEngine.Vector3::get_zero();\n\tv107 = *([isRelative @ X3 (System.Boolean)+A8]) != 2;\n\tif (v107) goto L_00A6;\n\tv500 = *([isRelative @ X3 (System.Boolean)+109]) & 1;\n\tv226 = *([isRelative @ X3 (System.Boolean)+104]) - v500;\n\tv245 = v226 < 1;\n\tif (v245) goto L_00A6;\n\tv708 = changeValue.Length == 0;\n\tif (v708) goto L_0459;\n\tv819 = changeValue.Length - 1;\n\tv820 = v819 < *([v42 @ X25_v1+18]);\n\tv546 = ~v820;\n\tif (v546) goto L_0459;\n\tv868 = v819 * 0xC;\n\tv869 = changeValue + v868;\n\tv870 = v819 * 0xC;\n\tv871 = v42 + v870;\n\tgoto L_008B;\n\tv880 = *([v866 @ X0_v58+E0]);\n\tv881 = v880 == 0;\n\tv882 = ~v881;\n\tif (v882) goto L_008B;\n\tv884 = \"il2cpp_codegen_runtime_class_init\"(v866, options, t, isRelative, getter, setter, startValue, changeValue, v90, v91, v92, v67, v68, v69, v70, v71);\nL_008B:\n\t// 139 MakeStruct v530 @ AGG10DF030_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v869 @ X9_v30+20], changeValue[v819 @ X8_v104].y (System.Single), changeValue[v819 @ X8_v104].z (System.Single)\n\t// 140 MakeStruct v529 @ AGG10DF030_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v871 @ X8_v106+20], [v871 @ X8_v106+24], [v871 @ X8_v106+28]\n\tv786 = UnityEngine.Vector3::op_Addition(v530, v529);\n\tv555 = changeValue.Length == 0;\n\tif (v555) goto L_0459;\n\t// 152 MakeStruct v527 @ AGG10DF048_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [changeValue @ X7 (UnityEngine.Vector3[])+20], [changeValue @ X7 (UnityEngine.Vector3[])+24], [changeValue @ X7 (UnityEngine.Vector3[])+28]\n\tv897 = UnityEngine.Vector3::op_Subtraction(v786, v527);\n\tv552 = UnityEngine.Vector3::op_Multiply(v897, v226);\nL_00A6:\n\tv559 = *([isRelative @ X3 (System.Boolean)+E1]) == 0;\n\tif (v559) goto L_013D;\n\tv502 = *([isRelative @ X3 (System.Boolean)+E8]);\n\tv579 = *([v502 @ X8_v90+A8]) != 2;\n\tif (v579) goto L_013D;\n\tv812 = *([isRelative @ X3 (System.Boolean)+A8]) != 2;\n\tif (v812) goto L_FFFFFFFF;\n\tv235 = *([isRelative @ X3 (System.Boolean)+A4]);\n\tgoto L_00C8;\nL_00C8:\n\tv218 = *([v502 @ X8_v90+109]) & 1;\n\tv503 = *([v502 @ X8_v90+104]) - v218;\n\tv228 = v503 * v235;\n\tv247 = v228 < 1;\n\tif (v247) goto L_013D;\n\tv792 = changeValue.Length == 0;\n\tif (v792) goto L_0459;\n\tv901 = changeValue.Length - 1;\n\tv902 = v901 < *([v42 @ X25_v1+18]);\n\tv594 = ~v902;\n\tif (v594) goto L_0459;\n\tv908 = v901 * 0xC;\n\tv909 = changeValue + v908;\n\tv910 = v901 * 0xC;\n\tv911 = v42 + v910;\n\tgoto L_010A;\n\tv915 = *([v906 @ X0_v48+E0]);\n\tv916 = v915 == 0;\n\tv917 = ~v916;\n\tif (v917) goto L_010A;\n\tv919 = \"il2cpp_codegen_runtime_class_init\"(v906, options, t, isRelative, getter, setter, startValue, changeValue, v446, v434, v425, v197, v192, v187, v70, v71);\nL_010A:\n\t// 266 MakeStruct v566 @ AGG10DF130_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v909 @ X9_v22+20], changeValue[v901 @ X8_v94].y (System.Single), changeValue[v901 @ X8_v94].z (System.Single)\n\t// 267 MakeStruct v565 @ AGG10DF130_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v911 @ X8_v96+20], [v911 @ X8_v96+24], [v911 @ X8_v96+28]\n\tv787 = UnityEngine.Vector3::op_Addition(v566, v565);\n\tv604 = changeValue.Length == 0;\n\tif (v604) goto L_0459;\n\t// 279 MakeStruct v563 @ AGG10DF148_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [changeValue @ X7 (UnityEngine.Vector3[])+20], [changeValue @ X7 (UnityEngine.Vector3[])+24], [changeValue @ X7 (UnityEngine.Vector3[])+28]\n\tv968 = UnityEngine.Vector3::op_Subtraction(v787, v563);\n\tv1038 = UnityEngine.Vector3::op_Multiply(v968, v228);\n\t// 296 MakeStruct v561 @ AGG10DF170_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v418 @ V9_v4 (UnityEngine.Vector3), v410 @ V10_v4 (System.Single), v402 @ V11_v4 (System.Single)\n\tv601 = UnityEngine.Vector3::op_Addition(v561, v1038);\nL_013D:\n\tv721 = t.sequencedEndPosition < 1;\n\tif (v721) goto L_FFFFFFFF;\n\tv795 = t.sequencedEndPosition & 0xFFFFFFFF;\n\tv733 = t + 0x20;\nL_0145:\n\tv844 = v520 < v795;\n\tv770 = ~v844;\n\tif (v770) goto L_0459;\n\tv435 = t.onStart;\n\tv782 = v782 + *([v733 @ X9_v16+v520 @ X26_v5 (System.Int32)*4]);\n\tv845 = v782 >= elapsed;\n\tif (v845) goto L_0170;\n\tv520 = v520 + 1;\n\tv863 = v863 + *([v733 @ X9_v16+v520 @ X26_v5 (System.Int32)*4]);\n\tv823 = v520 < v795;\n\tif (v823) goto L_0145;\n\tgoto L_0176;\n\tgoto L_0176;\nL_0170:\n\tv863 = elapsed - v863;\nL_0176:\n\tv447 = DG.Tweening.Core.Easing.EaseManager::Evaluate(*([isRelative @ X3 (System.Boolean)+B4]), *([isRelative @ X3 (System.Boolean)+B8]), v863, v435, *([isRelative @ X3 (System.Boolean)+C0]), *([isRelative @ X3 (System.Boolean)+C4]));\n\tv335 = options == 8;\n\tif (v335) goto L_01FC;\n\tv337 = options == 4;\n\tif (v337) goto L_025B;\n\tv248 = options != 2;\n\tif (v248) goto L_02B7;\n\tv448 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(setter);\n\tv679 = v448.y;\n\tv677 = v448.z;\n\tv925 = v520 < changeValue.Length;\n\tv388 = ~v925;\n\tif (v388) goto L_0459;\n\tv969 = v520 < *([v42 @ X25_v1+18]);\n\tv771 = ~v969;\n\tif (v771) goto L_0459;\n\tv1041 = v520 * 0xC;\n\tv238 = changeValue + v1041;\n\tv1042 = v520 * 0xC;\n\tv1043 = v42 + v1042;\n\tv1046 = options >> 0x20;\n\tv1047 = v1046 & 0xFF;\n\tv1048 = v418 + *([v238 @ X9_v15+20]);\n\tv1049 = v447 * *([v1043 @ X8_v76+20]);\n\tv494 = v1048 + v1049;\n\tv1051 = v1047 == 0;\n\tif (v1051) goto L_FFFFFFFF;\n\tgoto L_01D9;\n\tv1201 = *([v1113 @ X0_v43+E0]);\n\tv1202 = v1201 == 0;\n\tv1203 = ~v1202;\n\tif (v1203) goto L_01D9;\n\tv1205 = \"il2cpp_codegen_runtime_class_init\"(v1113, v123, v116, isRelative, getter, setter, startValue, changeValue, v1048, v1049, v427, v198, v193, v188, v70, v71);\nL_01D9:\n\tv1208 = &v39 @ stack_-10_v2 - 0x48;\n\tv1130 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(v1208);\n\tv1285 = v494 >= 0;\n\tif (v1285) goto L_031F;\n\tv1334 = v494 != -0.5d;\n\tif (v1334) goto L_0385;\n\tv1129 = *([v38 @ X29_v1-48]);\n\tgoto L_0324;\nL_01FC:\n\tv450 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(setter);\n\tv679 = v450.y;\n\tv905 = v520 < changeValue.Length;\n\tv390 = ~v905;\n\tif (v390) goto L_0459;\n\tv927 = v520 < *([v42 @ X25_v1+18]);\n\tv772 = ~v927;\n\tif (v772) goto L_0459;\n\tv954 = v520 * 0xC;\n\tv955 = v42 + v954;\n\tv958 = options >> 0x20;\n\tv959 = v958 & 0xFF;\n\tv960 = v402 + changeValue[v520 @ X26_v5 (System.Int32)].z;\n\tv961 = v447 * *([v955 @ X8_v19+28]);\n\tv1171 = v960 + v961;\n\tv963 = v959 == 0;\n\tif (v963) goto L_FFFFFFFF;\n\tgoto L_0238;\n\tv1092 = *([v1012 @ X0_v16+E0]);\n\tv1093 = v1092 == 0;\n\tv1094 = ~v1093;\n\tif (v1094) goto L_0238;\n\tv1096 = \"il2cpp_codegen_runtime_class_init\"(v1012, v124, v116, isRelative, getter, setter, startValue, changeValue, v960, v961, v428, v198, v193, v188, v70, v71);\nL_0238:\n\tv1099 = &v39 @ stack_-10_v2 - 0x48;\n\tv1029 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(v1099);\n\tv1200 = v1171 >= 0;\n\tif (v1200) goto L_033B;\n\tv1264 = v1171 != -0.5d;\n\tif (v1264) goto L_0388;\n\tv1028 = *([v38 @ X29_v1-48]);\n\tgoto L_0340;\nL_025B:\n\tv450 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(setter);\n\tv677 = v450.z;\n\tv914 = v520 < changeValue.Length;\n\tv392 = ~v914;\n\tif (v392) goto L_0459;\n\tv950 = v520 < *([v42 @ X25_v1+18]);\n\tv773 = ~v950;\n\tif (v773) goto L_0459;\n\tv1000 = v520 * 0xC;\n\tv1001 = v42 + v1000;\n\tv1004 = options >> 0x20;\n\tv1005 = v1004 & 0xFF;\n\tv1006 = v410 + changeValue[v520 @ X26_v5 (System.Int32)].y;\n\tv1007 = v447 * *([v1001 @ X8_v37+24]);\n\tv496 = v1006 + v1007;\n\tv1009 = v1005 == 0;\n\tif (v1009) goto L_FFFFFFFF;\n\tgoto L_0297;\n\tv1175 = *([v1070 @ X0_v24+E0]);\n\tv1176 = v1175 == 0;\n\tv1177 = ~v1176;\n\tif (v1177) goto L_0297;\n\tv1179 = \"il2cpp_codegen_runtime_class_init\"(v1070, v125, v116, isRelative, getter, setter, startValue, changeValue, v1006, v1007, v429, v198, v193, v188, v70, v71);\nL_0297:\n\tv1182 = &v39 @ st\n// ... truncated")]
		public override void EvaluateAndApply(Vector3ArrayOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3[] startValue, Vector3[] changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_0018: Expected O, but got I
			//IL_02da: Expected O, but got I
			//IL_14e5: Expected F4, but got I
			//IL_14e5: Expected F4, but got I
			//IL_14e5: Expected O, but got I
			//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b0: Expected I4, but got Unknown
			//IL_05bf: Expected O, but got I
			//IL_0113: Expected O, but got I4
			//IL_05ef: Expected F4, but got I
			//IL_1452: Expected O, but got I
			//IL_0151: Expected O, but got I
			//IL_0160: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_017e: Expected O, but got I
			//IL_0198: Expected F4, but got I
			//IL_01e3: Expected F4, but got I
			//IL_01f8: Expected F4, but got I
			//IL_020d: Expected F4, but got I
			//IL_093e: Expected O, but got I
			//IL_094c: Expected I4, but got O
			//IL_0252: Expected F4, but got I
			//IL_0267: Expected F4, but got I
			//IL_027c: Expected F4, but got I
			//IL_0ada: Expected O, but got I
			//IL_0ae8: Expected I4, but got O
			//IL_0381: Expected O, but got I4
			//IL_09ce: Expected O, but got I
			//IL_0c55: Expected O, but got I
			//IL_0c8c: Expected O, but got I
			//IL_0ca8: Expected O, but got I
			//IL_0d45: Expected I4, but got O
			//IL_13e1: Expected O, but got F4
			//IL_03bf: Expected O, but got I
			//IL_03ce: Expected O, but got I
			//IL_03dd: Expected O, but got I
			//IL_03ec: Expected O, but got I
			//IL_0b6a: Expected O, but got I
			//IL_0787: Expected O, but got I
			//IL_07a3: Expected O, but got I
			//IL_07b1: Expected I4, but got O
			//IL_0406: Expected F4, but got I
			//IL_0451: Expected F4, but got I
			//IL_0466: Expected F4, but got I
			//IL_047b: Expected F4, but got I
			//IL_0eb5: Expected F8, but got I
			//IL_0db1: Expected O, but got I
			//IL_1076: Expected O, but got F4
			//IL_1563: Unknown result type (might be due to invalid IL or missing references)
			//IL_1568: Expected I4, but got Unknown
			//IL_0a33: Expected F8, but got I
			//IL_04c0: Expected F4, but got I
			//IL_04d5: Expected F4, but got I
			//IL_04ea: Expected F4, but got I
			//IL_0f0f: Expected F8, but got I
			//IL_0832: Expected O, but got I
			//IL_15a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_15ad: Expected I4, but got Unknown
			//IL_0bcf: Expected F8, but got I
			//IL_114f: Expected O, but got I
			//IL_0f69: Expected F8, but got I
			//IL_15ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_15f2: Expected I4, but got Unknown
			//IL_0e13: Expected F8, but got I
			//IL_0e5b: Expected F8, but got I
			//IL_129a: Expected O, but got I
			//IL_11f9: Expected F8, but got I
			//IL_151e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1523: Expected I4, but got Unknown
			//IL_0897: Expected F8, but got I
			//IL_1696: Unknown result type (might be due to invalid IL or missing references)
			//IL_169b: Expected I4, but got Unknown
			//IL_11b1: Expected F8, but got I
			//IL_1344: Expected F8, but got I
			//IL_16e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_16e5: Expected I4, but got Unknown
			//IL_12fc: Expected F8, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1+10]");
			object obj3 = 0;
			Vector3 zero = Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+A8]");
			bool flag = (IntPtr)0 != (IntPtr)2;
			float z = zero.z;
			float y = zero.y;
			Vector3 vector = zero;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+109]");
				int num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+104]");
				float num2 = 0f - (float)num;
				bool flag2 = num2 < float.Epsilon;
				z = zero.z;
				y = zero.y;
				vector = zero;
				if (!flag2)
				{
					if (changeValue.Length != 0)
					{
						object obj4 = changeValue.Length - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X25_v1+18]");
						if ((long)(IntPtr)obj4 < 0L)
						{
							object obj5 = (long)(IntPtr)obj4 * 12L;
							object obj6 = (long)(IntPtr)changeValue + (long)(IntPtr)obj5;
							object obj7 = (long)(IntPtr)obj4 * 12L;
							object obj8 = (long)(IntPtr)obj3 + (long)(IntPtr)obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ X9_v30+20]");
							Vector3 vector2 = default(Vector3);
							vector2.x = 0f;
							vector2.y = changeValue[obj4].y;
							vector2.z = changeValue[obj4].z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ X8_v106+20]");
							Vector3 vector3 = default(Vector3);
							vector3.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ X8_v106+24]");
							vector3.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ X8_v106+28]");
							vector3.z = 0f;
							Vector3 vector4 = vector2 + vector3;
							if (changeValue.Length != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+20]");
								Vector3 vector5 = default(Vector3);
								vector5.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+24]");
								vector5.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+28]");
								vector5.z = 0f;
								Vector3 vector6 = vector4 - vector5;
								Vector3 vector7 = vector6 * num2;
								z = vector7.z;
								y = vector7.y;
								vector = vector7;
								goto IL_1402;
							}
						}
					}
					goto IL_13ef;
				}
			}
			goto IL_1402;
			IL_13ef:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_162e:
			Vector3 pNewValue = default(Vector3);
			Vector3 vector8;
			pNewValue.x = vector8.x;
			float y2;
			pNewValue.y = y2;
			float z2;
			pNewValue.z = z2;
			DOSetter<Vector3> dOSetter;
			dOSetter(pNewValue);
			return;
			IL_0696:
			float num3 = elapsed - num3;
			goto IL_14a8;
			IL_106d:
			float num4;
			vector8 = (Vector3)num4;
			dOSetter = (DOSetter<Vector3>)(object)startValue;
			goto IL_162e;
			IL_0668:
			int num5 = 0;
			goto IL_14a8;
			IL_1402:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+E1]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+E8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X8_v90+A8]");
				if ((IntPtr)0 == (IntPtr)2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+A8]");
					int num6;
					if ((IntPtr)0 == (IntPtr)2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+A4]");
						num6 = 0;
					}
					else
					{
						num6 = 1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X8_v90+109]");
					int num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X8_v90+104]");
					object obj10 = -num7;
					float num8 = (float)obj10 * (float)num6;
					if (!(num8 < float.Epsilon))
					{
						if (changeValue.Length != 0)
						{
							object obj11 = changeValue.Length - 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X25_v1+18]");
							if ((long)(IntPtr)obj11 < 0L)
							{
								object obj12 = (long)(IntPtr)obj11 * 12L;
								object obj13 = (long)(IntPtr)changeValue + (long)(IntPtr)obj12;
								object obj14 = (long)(IntPtr)obj11 * 12L;
								object obj15 = (long)(IntPtr)obj3 + (long)(IntPtr)obj14;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ X9_v22+20]");
								Vector3 vector9 = default(Vector3);
								vector9.x = 0f;
								vector9.y = changeValue[obj11].y;
								vector9.z = changeValue[obj11].z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ X8_v96+20]");
								Vector3 vector10 = default(Vector3);
								vector10.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ X8_v96+24]");
								vector10.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ X8_v96+28]");
								vector10.z = 0f;
								Vector3 vector11 = vector9 + vector10;
								if (changeValue.Length != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+20]");
									Vector3 vector12 = default(Vector3);
									vector12.x = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+24]");
									vector12.y = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+28]");
									vector12.z = 0f;
									Vector3 vector13 = vector11 - vector12;
									Vector3 vector14 = vector13 * num8;
									Vector3 vector15 = default(Vector3);
									vector15.x = vector.x;
									vector15.y = y;
									vector15.z = z;
									Vector3 vector16 = vector15 + vector14;
									z = vector16.z;
									y = vector16.y;
									vector = vector16;
									goto IL_0575;
								}
							}
						}
						goto IL_13ef;
					}
				}
			}
			goto IL_0575;
			IL_14a8:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+B4]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+B8]");
			IntPtr intPtr2 = (IntPtr)0;
			float time = num3;
			float num9;
			float duration2 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+C0]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+C4]");
			float num10 = EaseManager.Evaluate((Ease)(long)intPtr, (EaseFunction)(long)intPtr2, time, duration2, (long)intPtr3, 0f);
			double num20;
			float num43;
			float num44;
			float num45;
			double num46;
			float num57;
			double num58;
			double num68;
			if ((IntPtr)options != (IntPtr)8)
			{
				if ((IntPtr)options != (IntPtr)4)
				{
					if ((IntPtr)options == (IntPtr)2)
					{
						Vector3 vector17 = setter();
						y2 = vector17.y;
						z2 = vector17.z;
						if (num5 < changeValue.Length)
						{
							int num11 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X25_v1+18]");
							if ((long)num11 < 0L)
							{
								int num12 = num5 * 12;
								object obj16 = (long)(IntPtr)changeValue + (long)num12;
								int num13 = num5 * 12;
								object obj17 = (long)(IntPtr)obj3 + (long)num13;
								int num14 = (object)options >> 32;
								int num15 = num14 & 0xFF;
								float num16 = vector.x;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X9_v15+20]");
								float num17 = num16 + 0f;
								float num18 = num10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1043 @ X8_v76+20]");
								float num19 = num18 * 0f;
								num4 = num17 + num19;
								if (num15 != 0)
								{
									DOGetter<Vector3> dOGetter = (DOGetter<Vector3>)((long)(IntPtr)obj2 - 72L);
									Vector3 vector18 = dOGetter();
									double num21;
									if (num4 < 0f)
									{
										if ((double)num4 != -0.5)
										{
											double a = (double)num4 + -0.5;
											num20 = Math.Ceiling(a);
											goto IL_1060;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
										num20 = 0.0;
										num21 = -1.0;
									}
									else
									{
										if ((double)num4 != 0.5)
										{
											double d = (double)num4 + 0.5;
											num20 = Math.Floor(d);
											goto IL_1060;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
										num20 = 0.0;
										num21 = 1.0;
									}
									double num22 = num20 + num21;
									if ((num20 & 1) != 0)
									{
										num20 = num22;
									}
									goto IL_1060;
								}
								goto IL_106d;
							}
						}
					}
					else if (num5 < changeValue.Length)
					{
						int num23 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X25_v1+18]");
						if ((long)num23 < 0L)
						{
							int num24 = num5 * 12;
							object obj18 = (long)(IntPtr)changeValue + (long)num24;
							int num25 = num5 << 1;
							int num26 = num5 + num25;
							int num27 = num26 << 2;
							object obj19 = (long)(IntPtr)obj3 + (long)num27;
							int num28 = num26 << 2;
							object obj20 = (long)(IntPtr)changeValue + (long)num28;
							float num29 = vector.x;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v931 @ X9_v12+20]");
							float num30 = num29 + 0f;
							float num31 = y;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ X8_v54+24]");
							float num32 = num31 + 0f;
							float num33 = z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ X8_v54+28]");
							float num34 = num33 + 0f;
							float num35 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X9_v13+20]");
							float num36 = num35 * 0f;
							float num37 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X9_v13+24]");
							float num38 = num37 * 0f;
							float num39 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X9_v13+28]");
							float num40 = num39 * 0f;
							int num41 = (object)options >> 32;
							int num42 = num41 & 0xFF;
							num43 = num30 + num36;
							num44 = num32 + num38;
							num45 = num34 + num40;
							if (num42 != 0)
							{
								object obj21 = (long)(IntPtr)obj2 - 72L;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
								double num48;
								double num49;
								double num47;
								if (num43 < 0f)
								{
									if ((double)num43 != -0.5)
									{
										double a2 = (double)num43 + -0.5;
										num46 = Math.Ceiling(a2);
										num47 = -0.5;
										goto IL_1140;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
									num48 = 0.0;
									num49 = -1.0;
								}
								else
								{
									if ((double)num43 != 0.5)
									{
										double d2 = (double)num43 + 0.5;
										num46 = Math.Floor(d2);
										num47 = 0.5;
										goto IL_1140;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
									num48 = 0.0;
									num49 = 1.0;
								}
								num47 = num48 + num49;
								num46 = (((num48 & 1) != 0) ? num47 : num48);
								goto IL_1140;
							}
							goto IL_13d1;
						}
					}
				}
				else
				{
					vector8 = setter();
					z2 = vector8.z;
					if (num5 < changeValue.Length)
					{
						int num50 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X25_v1+18]");
						if ((long)num50 < 0L)
						{
							int num51 = num5 * 12;
							object obj22 = (long)(IntPtr)obj3 + (long)num51;
							int num52 = (object)options >> 32;
							int num53 = num52 & 0xFF;
							float num54 = y + changeValue[num5].y;
							float num55 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1001 @ X8_v37+24]");
							float num56 = num55 * 0f;
							num57 = num54 + num56;
							if (num53 != 0)
							{
								DOGetter<Vector3> dOGetter2 = (DOGetter<Vector3>)((long)(IntPtr)obj2 - 72L);
								Vector3 vector19 = dOGetter2();
								double num59;
								if (num57 < 0f)
								{
									if ((double)num57 != -0.5)
									{
										double a3 = (double)num57 + -0.5;
										num58 = Math.Ceiling(a3);
										goto IL_10ea;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
									num58 = 0.0;
									num59 = -1.0;
								}
								else
								{
									if ((double)num57 != 0.5)
									{
										double d3 = (double)num57 + 0.5;
										num58 = Math.Floor(d3);
										goto IL_10ea;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
									num58 = 0.0;
									num59 = 1.0;
								}
								double num60 = num58 + num59;
								if ((num58 & 1) != 0)
								{
									num58 = num60;
								}
								goto IL_10ea;
							}
							goto IL_10f7;
						}
					}
				}
			}
			else
			{
				vector8 = setter();
				y2 = vector8.y;
				if (num5 < changeValue.Length)
				{
					int num61 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X25_v1+18]");
					if ((long)num61 < 0L)
					{
						int num62 = num5 * 12;
						object obj23 = (long)(IntPtr)obj3 + (long)num62;
						int num63 = (object)options >> 32;
						int num64 = num63 & 0xFF;
						float num65 = z + changeValue[num5].z;
						float num66 = num10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ X8_v19+28]");
						float num67 = num66 * 0f;
						num45 = num65 + num67;
						if (num64 != 0)
						{
							DOGetter<Vector3> dOGetter3 = (DOGetter<Vector3>)((long)(IntPtr)obj2 - 72L);
							Vector3 vector20 = dOGetter3();
							double num69;
							if (num45 < 0f)
							{
								if ((double)num45 != -0.5)
								{
									double a4 = (double)num45 + -0.5;
									num68 = Math.Ceiling(a4);
									goto IL_10a9;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
								num68 = 0.0;
								num69 = -1.0;
							}
							else
							{
								if ((double)num45 != 0.5)
								{
									double d4 = (double)num45 + 0.5;
									num68 = Math.Floor(d4);
									goto IL_10a9;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
								num68 = 0.0;
								num69 = 1.0;
							}
							double num70 = num68 + num69;
							if ((num68 & 1) != 0)
							{
								num68 = num70;
							}
							goto IL_10a9;
						}
						goto IL_10b6;
					}
				}
			}
			goto IL_13ef;
			IL_10a9:
			num45 = (float)num68;
			goto IL_10b6;
			IL_10b6:
			Vector3[] array = startValue;
			goto IL_1668;
			IL_13b4:
			num43 = (float)num46;
			double num71;
			num44 = (float)num71;
			double num72;
			num45 = (float)num72;
			goto IL_13d1;
			IL_10f7:
			y2 = num57;
			dOSetter = (DOSetter<Vector3>)(object)startValue;
			goto IL_162e;
			IL_1060:
			num4 = (float)num20;
			goto IL_106d;
			IL_10ea:
			num57 = (float)num58;
			goto IL_10f7;
			IL_128b:
			object obj24 = (long)(IntPtr)obj2 - 72L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num73;
			if (num45 < 0f)
			{
				if ((double)num45 != -0.5)
				{
					double a5 = (double)num45 + -0.5;
					num72 = Math.Ceiling(a5);
					goto IL_13b4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
				num72 = 0.0;
				num73 = -1.0;
			}
			else
			{
				if ((double)num45 != 0.5)
				{
					double d5 = (double)num45 + 0.5;
					num72 = Math.Floor(d5);
					goto IL_13b4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
				num72 = 0.0;
				num73 = 1.0;
			}
			double num74 = num72 + num73;
			if ((num72 & 1) != 0)
			{
				num72 = num74;
			}
			goto IL_13b4;
			IL_1140:
			object obj25 = (long)(IntPtr)obj2 - 72L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num76;
			double num77;
			double num75;
			if (num44 < 0f)
			{
				if ((double)num44 != -0.5)
				{
					double a6 = (double)num44 + -0.5;
					num71 = Math.Ceiling(a6);
					num75 = -0.5;
					goto IL_128b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
				num76 = 0.0;
				num77 = -1.0;
			}
			else
			{
				if ((double)num44 != 0.5)
				{
					double d6 = (double)num44 + 0.5;
					num71 = Math.Floor(d6);
					num75 = 0.5;
					goto IL_128b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-48]");
				num76 = 0.0;
				num77 = 1.0;
			}
			num75 = num76 + num77;
			num71 = (((num76 & 1) != 0) ? num75 : num76);
			goto IL_128b;
			IL_0575:
			if (!(t.sequencedEndPosition < float.Epsilon))
			{
				int num78 = t.sequencedEndPosition & 0xFFFFFFFFL;
				object obj26 = (long)(IntPtr)t + 32L;
				float num79 = 0f;
				num3 = 0f;
				num5 = 0;
				while (num5 < num78)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ X9_v16+v520 @ X26_v5 (System.Int32)*4]");
					num9 = 0f;
					float num80 = num79;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ X9_v16+v520 @ X26_v5 (System.Int32)*4]");
					num79 = num80 + 0f;
					if (num79 < elapsed)
					{
						num5++;
						float num81 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ X9_v16+v520 @ X26_v5 (System.Int32)*4]");
						num3 = num81 + 0f;
						if (num5 < num78)
						{
							continue;
						}
						goto IL_0668;
					}
					goto IL_0696;
				}
				goto IL_13ef;
			}
			num9 = 0f;
			num3 = 0f;
			num5 = 0;
			goto IL_14a8;
			IL_13d1:
			y2 = num44;
			vector8 = (Vector3)num43;
			array = startValue;
			goto IL_1668;
			IL_1668:
			z2 = num45;
			dOSetter = (DOSetter<Vector3>)(object)array;
			goto IL_162e;
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x10DF7CC", Offset = "0x10DF7CC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA5518]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274E7]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3ArrayPlugin()
		{
		}
	}
}
