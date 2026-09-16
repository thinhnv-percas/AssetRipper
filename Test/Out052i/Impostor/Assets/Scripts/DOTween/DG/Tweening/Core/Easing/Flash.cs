using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x20000C6")]
	public static class Flash
	{
		[Token(Token = "0x60004A0")]
		[Address(RVA = "0xC3396C", Offset = "0xC3396C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv25 = System.Math;\n\tv26 = \"il2cpp_codegen_initialize_runtime_metadata\"(v25, v27, v28, v29, v30, v31, v32, v33, time, duration, overshootOrAmplitude, period, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35825]) = v41;\nL_001B:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, v27, v28, v29, v30, v31, v32, v33, time, duration, overshootOrAmplitude, period, v34, v35, v36, v37);\nL_001D:\n\tv50 = time / duration;\n\tv52 = v50 * overshootOrAmplitude;\n\tv54 = UnityEngine.Mathf::Ceil(v52);\n\tv66 = v54 != 0x7F800000;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0033;\nL_0033:\n\tv70 = v69 - 1;\n\tv71 = duration / overshootOrAmplitude;\n\tv73 = v71 * v70;\n\tv90 = time - v73;\n\tv77 = v69 & 1;\n\tv79 = v77 == 0;\n\tv82 = ~v79;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tv86 = v90 - v71;\n\tv87 = ~v79;\n\tif (v87) goto L_004C;\n\tgoto L_004C;\nL_004C:\n\tv91 = v85 * v90;\n\tv92 = v91 / v71;\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v69, v86, v85, v92);\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Ease(float time, float duration, float overshootOrAmplitude, float period)
		{
			//IL_0068: Expected I4, but got F4
			float num = time / duration;
			float num2 = num * overshootOrAmplitude;
			float num3 = Mathf.Ceil(num2);
			int num4 = ((num3 != float.PositiveInfinity) ? ((int)num2) : int.MinValue);
			int num5 = num4 - 1;
			float num6 = duration / overshootOrAmplitude;
			float num7 = num6 * (float)num5;
			float num8 = time - num7;
			int num9 = num4 & 1;
			bool flag = num9 == 0;
			float num10 = ((!flag) ? 1f : (-1f));
			float num11 = num8 - num6;
			if (flag)
			{
				num8 = num11;
			}
			float num12 = num10 * num8;
			float res = num12 / num6;
			return WeightedEase(overshootOrAmplitude, period, num4, num11, num10, res);
		}

		[Token(Token = "0x60004A1")]
		[Address(RVA = "0xC33A30", Offset = "0xC33A30", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv25 = System.Math;\n\tv26 = \"il2cpp_codegen_initialize_runtime_metadata\"(v25, v27, v28, v29, v30, v31, v32, v33, time, duration, overshootOrAmplitude, period, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35825]) = v41;\nL_001B:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, v27, v28, v29, v30, v31, v32, v33, time, duration, overshootOrAmplitude, period, v34, v35, v36, v37);\nL_001D:\n\tv50 = time / duration;\n\tv52 = v50 * overshootOrAmplitude;\n\tv54 = UnityEngine.Mathf::Ceil(v52);\n\tv66 = v54 != 0x7F800000;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0033;\nL_0033:\n\tv70 = v69 - 1;\n\tv71 = duration / overshootOrAmplitude;\n\tv73 = v71 * v70;\n\tv90 = time - v73;\n\tv77 = v69 & 1;\n\tv79 = v77 == 0;\n\tv82 = ~v79;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tv86 = v90 - v71;\n\tv87 = ~v79;\n\tif (v87) goto L_004C;\n\tgoto L_004C;\nL_004C:\n\tv91 = v85 * v90;\n\tv92 = v91 / v71;\n\tv93 = v92 * v92;\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v69, v86, v85, v93);\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseIn(float time, float duration, float overshootOrAmplitude, float period)
		{
			//IL_0068: Expected I4, but got F4
			float num = time / duration;
			float num2 = num * overshootOrAmplitude;
			float num3 = Mathf.Ceil(num2);
			int num4 = ((num3 != float.PositiveInfinity) ? ((int)num2) : int.MinValue);
			int num5 = num4 - 1;
			float num6 = duration / overshootOrAmplitude;
			float num7 = num6 * (float)num5;
			float num8 = time - num7;
			int num9 = num4 & 1;
			bool flag = num9 == 0;
			float num10 = ((!flag) ? 1f : (-1f));
			float num11 = num8 - num6;
			if (flag)
			{
				num8 = num11;
			}
			float num12 = num10 * num8;
			float num13 = num12 / num6;
			float res = num13 * num13;
			return WeightedEase(overshootOrAmplitude, period, num4, num11, num10, res);
		}

		[Token(Token = "0x60004A2")]
		[Address(RVA = "0xC33AF8", Offset = "0xC33AF8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv25 = System.Math;\n\tv26 = \"il2cpp_codegen_initialize_runtime_metadata\"(v25, v27, v28, v29, v30, v31, v32, v33, time, duration, overshootOrAmplitude, period, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35825]) = v41;\nL_001B:\n\tgoto L_001D;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, v27, v28, v29, v30, v31, v32, v33, time, duration, overshootOrAmplitude, period, v34, v35, v36, v37);\nL_001D:\n\tv50 = time / duration;\n\tv52 = v50 * overshootOrAmplitude;\n\tv54 = UnityEngine.Mathf::Ceil(v52);\n\tv66 = v54 != 0x7F800000;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tv72 = v69 - 1;\n\tv73 = v69 & 1;\n\tv75 = v73 == 0;\n\tv78 = duration / overshootOrAmplitude;\n\tv79 = ~v75;\n\tif (v79) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tv84 = v78 * v72;\n\tv90 = time - v84;\n\tv86 = v90 - v78;\n\tv87 = ~v75;\n\tif (v87) goto L_004C;\n\tgoto L_004C;\nL_004C:\n\tv91 = v82 * v90;\n\tv93 = v91 / v78;\n\tv94 = -v93;\n\tv95 = v93 + -2f;\n\tv96 = v95 * v94;\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v69, -2f, v82, v96);\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOut(float time, float duration, float overshootOrAmplitude, float period)
		{
			//IL_0068: Expected I4, but got F4
			//IL_015c: Expected O, but got F4
			float num = time / duration;
			float num2 = num * overshootOrAmplitude;
			float num3 = Mathf.Ceil(num2);
			int num4 = ((num3 != float.PositiveInfinity) ? ((int)num2) : int.MinValue);
			int num5 = num4 - 1;
			int num6 = num4 & 1;
			bool flag = num6 == 0;
			float num7 = duration / overshootOrAmplitude;
			float num8 = ((!flag) ? 1f : (-1f));
			float num9 = num7 * (float)num5;
			float num10 = time - num9;
			float num11 = num10 - num7;
			if (flag)
			{
				num10 = num11;
			}
			float num12 = num8 * num10;
			float num13 = num12 / num7;
			object obj = 0f - num13;
			float num14 = num13 + -2f;
			float res = num14 * (float)obj;
			return WeightedEase(overshootOrAmplitude, period, num4, -2f, num8, res);
		}

		[Token(Token = "0x60004A3")]
		[Address(RVA = "0xC33BCC", Offset = "0xC33BCC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = time / duration;\n\tgoto L_0019;\n\tv28 = System.Math;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, v30, v31, v32, v33, v34, v35, v36, time, duration, overshootOrAmplitude, period, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35825]) = v44;\nL_0019:\n\tv47 = v24 * overshootOrAmplitude;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v48, v30, v31, v32, v33, v34, v35, v36, time, duration, overshootOrAmplitude, period, v37, v38, v39, v40);\nL_0021:\n\tv55 = UnityEngine.Mathf::Ceil(v47);\n\tv68 = v55 != 0x7F800000;\n\tif (v68) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv72 = v71 - 1;\n\tv73 = duration / overshootOrAmplitude;\n\tv75 = v73 * v72;\n\tv89 = time - v75;\n\tv79 = v71 & 1;\n\tv81 = v79 == 0;\n\tv84 = v89 - v73;\n\tv86 = ~v81;\n\tif (v86) goto L_0048;\n\tgoto L_0048;\nL_0048:\n\tv90 = ~v81;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_004E;\nL_004E:\n\tv94 = v93 * v89;\n\tv95 = v73 * 0.5f;\n\tv118 = v94 / v95;\n\tv106 = v118 >= 1f;\n\tif (v106) goto L_005F;\n\tv107 = v118 * 0.5f;\n\tv116 = v118 * v107;\n\tgoto L_0070;\nL_005F:\n\tv109 = v118 + -1f;\n\tv118 = v109 + -2f;\n\tv112 = v109 * v118;\n\tv113 = v112 + -1f;\n\tv116 = v113 * -0.5f;\nL_0070:\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v71, v118, v93, v116);\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOut(float time, float duration, float overshootOrAmplitude, float period)
		{
			//IL_0059: Expected I4, but got F4
			float num = time / duration;
			float num2 = num * overshootOrAmplitude;
			float num3 = Mathf.Ceil(num2);
			int num4 = ((num3 != float.PositiveInfinity) ? ((int)num2) : int.MinValue);
			int num5 = num4 - 1;
			float num6 = duration / overshootOrAmplitude;
			float num7 = num6 * (float)num5;
			float num8 = time - num7;
			int num9 = num4 & 1;
			bool flag = num9 == 0;
			float num10 = num8 - num6;
			if (flag)
			{
				num8 = num10;
			}
			float num11 = ((!flag) ? 1f : (-1f));
			float num12 = num11 * num8;
			float num13 = num6 * 0.5f;
			float num14 = num12 / num13;
			float res;
			if (num14 < 1f)
			{
				float num15 = num14 * 0.5f;
				res = num14 * num15;
			}
			else
			{
				float num16 = num14 + -1f;
				num14 = num16 + -2f;
				float num17 = num16 * num14;
				float num18 = num17 + -1f;
				res = num18 * -0.5f;
			}
			return WeightedEase(overshootOrAmplitude, period, num4, num14, num11, res);
		}

		[Token(Token = "0x60004A4")]
		[Address(RVA = "0xC35E24", Offset = "0xC35E24", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = System.Math;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, overshootOrAmplitude, period, stepDuration, dir, res, v40, v41, v42);\n\tv45 = 1;\n\t*([1A35821]) = v45;\nL_0023:\n\tv57 = dir <= 0;\n\tif (v57) goto L_003E;\n\tv64 = overshootOrAmplitude == 0x7F800000;\n\tif (v64) goto L_0051;\n\tv92 = overshootOrAmplitude & 1;\n\tv79 = v92 == 0;\n\tif (v79) goto L_0051;\nL_003E:\n\tv91 = dir >= 0;\n\tif (v91) goto L_005D;\n\tv100 = overshootOrAmplitude - 0x7F800000;\n\tv102 = v100 == 0;\n\tv107 = ~v102;\n\tv110 = overshootOrAmplitude & v107;\n\tv125 = v110 + stepIndex;\n\tgoto L_005D;\nL_0051:\n\tv125 = stepIndex + 1;\nL_005D:\n\tv138 = period <= 0;\n\tif (v138) goto L_008A;\n\tgoto L_0069;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v141, methodInfo, v33, v34, v35, v36, v37, v38, v123, period, stepDuration, dir, res, v40, v41, v42);\nL_0069:\n\tv151 = System.Math::Truncate(overshootOrAmplitude);\n\tv159 = overshootOrAmplitude - v151;\n\tv160 = 0x1854EF0(0, methodInfo, v33, v34, v35, v36, v37, v38, v151, 2f, stepDuration, dir, res, v40, v41, v42);\n\tv184 = v151 < 0;\n\tv182 = v151 == 0;\n\tv178 = v151 ^ v151;\n\tv176 = v151 & v178;\n\tv174 = v176 < 0;\n\tv217 = 1f - v159;\n\tv211 = overshootOrAmplitude - v125;\n\tv212 = v184 == v174;\n\tv166 = ~v182;\n\tv172 = v212 & v166;\n\tv163 = ~v172;\n\tif (v163) goto L_FFFFFFFF;\n\tgoto L_0084;\nL_0084:\n\tv168 = v211 * res;\n\tv218 = v217 * v125;\n\tv189 = v218 / overshootOrAmplitude;\n\tv169 = v168 / overshootOrAmplitude;\n\tgoto L_0092;\nL_008A:\n\tv146 = period >= 0;\n\tif (v146) goto L_FFFFFFFF;\n\tv153 = v125 * res;\n\tv193 = -period;\n\tv169 = v153 / overshootOrAmplitude;\n\tgoto L_0092;\nL_0092:\n\tv196 = v169 - res;\n\tv197 = v196 * v193;\n\tv198 = v189 + v197;\n\tv199 = v198 + res;\n\treturnVal1 = UnityEngine.Mathf::Min(v199, 1f);\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float WeightedEase(float overshootOrAmplitude, float period, int stepIndex, float stepDuration, float dir, float res)
		{
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0107: Expected O, but got F8
			//IL_0143: Expected O, but got F8
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Expected I4, but got Unknown
			if (!(dir > 0f))
			{
				goto IL_004f;
			}
			if (overshootOrAmplitude != float.PositiveInfinity)
			{
				object obj = overshootOrAmplitude & 1;
				if (obj != null)
				{
					goto IL_004f;
				}
			}
			int num = stepIndex + 1;
			goto IL_026a;
			IL_004f:
			bool flag = !(dir < 0f);
			num = stepIndex;
			if (!flag)
			{
				float num2 = overshootOrAmplitude - float.PositiveInfinity;
				bool flag2 = num2 == 0f;
				bool flag3 = !flag2;
				object obj2 = overshootOrAmplitude & flag3;
				num = (int)((nint)obj2 + stepIndex);
			}
			goto IL_026a;
			IL_026a:
			float num10;
			float num11;
			float num12;
			if (period > 0f)
			{
				double num3 = Math.Truncate(overshootOrAmplitude);
				float num4 = overshootOrAmplitude - (float)num3;
				object obj3 = num3 % 2.0;
				bool flag4 = num3 < 0.0;
				bool flag5 = num3 == 0.0;
				object obj4 = num3 ^ num3;
				int num5 = num3 & (nint)obj4;
				bool flag6 = num5 < 0;
				float num6 = 1f - num4;
				float num7 = overshootOrAmplitude - (float)num;
				bool flag7 = flag4 == flag6;
				bool flag8 = !flag5;
				if (!(flag7 && flag8))
				{
					num6 = num4;
				}
				float num8 = num7 * res;
				float num9 = num6 * (float)num;
				num10 = num9 / overshootOrAmplitude;
				num11 = num8 / overshootOrAmplitude;
				num12 = period;
			}
			else if (period < 0f)
			{
				float num13 = (float)num * res;
				num12 = 0f - period;
				num11 = num13 / overshootOrAmplitude;
				num10 = 0f;
			}
			else
			{
				num11 = 0f;
				num10 = 0f;
				num12 = period;
			}
			float num14 = num11 - res;
			float num15 = num14 * num12;
			float num16 = num10 + num15;
			float a = num16 + res;
			return Mathf.Min(a, 1f);
		}
	}
}
