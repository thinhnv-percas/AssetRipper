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
	[Token(Token = "0x200002E")]
	public class Vector3Plugin : ABSTweenPlugin<Vector3, Vector3, VectorOptions>
	{
		[Token(Token = "0x6000218")]
		[Address(RVA = "0x10DF81C", Offset = "0x10DF81C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0x10DF820", Offset = "0x10DF820", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_0021;\n\tv34 = *([1EC7760]);\n\tv35 = *([v34 @ X8_v30]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, t, isRelative, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([20274E8]) = v53;\nL_0021:\n\tv125 = t.endValue;\n\tv123 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]);\n\tv121 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]);\n\tv64 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv157 = v64.y;\n\tv114 = v64.z;\n\tt.endValue = v64;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]) = v64.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]) = v64.z;\n\tv139 = isRelative == 0;\n\tif (v139) goto L_0051;\n\tgoto L_0047;\n\tv235 = *([v142 @ X0_v18+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0047;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v142, v63, isRelative, methodInfo, v38, v39, v40, v41, v64, v133, v134, v45, v46, v47, v48, v49);\nL_0047:\n\tv160 = UnityEngine.Vector3::op_Addition(v64, t.endValue);\n\tv157 = v160.y;\n\tv114 = v160.z;\n\tv154 = t.endValue;\n\tv110 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]);\n\tv151 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]);\nL_0051:\n\tt.startValue = v125;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+120]) = v123;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+124]) = v121;\n\tv178 = t.plugOptions == 2;\n\tif (v178) goto L_FFFFFFFF;\n\tv247 = t.plugOptions == 8;\n\tif (v247) goto L_FFFFFFFF;\n\tv262 = t.plugOptions != 4;\n\tif (v262) goto L_007B;\n\tgoto L_FFFFFFFF;\n\tgoto L_007B;\nL_007B:\n\tv291 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+144]) == 0;\n\tif (v291) goto L_015E;\n\tgoto L_008A;\n\tv320 = *([v294 @ X0_v9+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_008A;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v294, v63, isRelative, methodInfo, v38, v39, v40, v41, v159, v157, v114, v106, v104, v102, v48, v49);\nL_008A:\n\tv328 = &v23 @ stack_-10_v2 - 0x18;\n\tv330 = 0x6D1ED0(v328, Il2CppMethodInfo, isRelative, methodInfo, v38, v39, v40, v41, v125, v157, v114, v125, v123, v121, v48, v49);\n\tv341 = v125 >= 0;\n\tif (v341) goto L_00B1;\n\tv352 = v125 != -0.5d;\n\tif (v352) goto L_00C3;\n\tv382 = *([v22 @ X29_v1-18]);\n\tgoto L_00B6;\nL_00B1:\n\tv363 = v125 != 0.5d;\n\tif (v363) goto L_00C6;\n\tv382 = *([v22 @ X29_v1-18]);\nL_00B6:\n\tv402 = v382 + v381;\n\tv385 = v382 & 1;\n\tv387 = v385 == 0;\n\tv390 = ~v387;\n\tif (v390) goto L_FFFFFFFF;\n\tgoto L_00C2;\nL_00C2:\n\tgoto L_00C9;\nL_00C3:\n\tv366 = v125 + -0.5d;\n\tv308 = System.Math::Ceiling(v366);\n\tgoto L_00C9;\nL_00C6:\n\tv370 = v125 + 0.5d;\n\tv308 = System.Math::Floor(v370);\nL_00C9:\n\tv407 = &v23 @ stack_-10_v2 - 0x18;\n\tv409 = 0x6D1ED0(v407, Il2CppMethodInfo, isRelative, methodInfo, v38, v39, v40, v41, v123, v402, v114, v125, v123, v121, v48, v49);\n\tv421 = v123 >= 0;\n\tif (v421) goto L_00F0;\n\tv432 = v123 != -0.5d;\n\tif (v432) goto L_0102;\n\tv462 = *([v22 @ X29_v1-18]);\n\tgoto L_00F5;\nL_00F0:\n\tv443 = v123 != 0.5d;\n\tif (v443) goto L_0105;\n\tv462 = *([v22 @ X29_v1-18]);\nL_00F5:\n\tv482 = v462 + v461;\n\tv465 = v462 & 1;\n\tv467 = v465 == 0;\n\tv470 = ~v467;\n\tif (v470) goto L_FFFFFFFF;\n\tgoto L_0101;\nL_0101:\n\tgoto L_0108;\nL_0102:\n\tv446 = v123 + -0.5d;\n\tv309 = System.Math::Ceiling(v446);\n\tgoto L_0108;\nL_0105:\n\tv450 = v123 + 0.5d;\n\tv309 = System.Math::Floor(v450);\nL_0108:\n\tv487 = &v23 @ stack_-10_v2 - 0x18;\n\tv316 = 0x6D1ED0(v487, Il2CppMethodInfo, isRelative, methodInfo, v38, v39, v40, v41, v121, v482, v114, v125, v123, v121, v48, v49);\n\tv500 = v121 >= 0;\n\tif (v500) goto L_012F;\n\tv511 = v121 != -0.5d;\n\tif (v511) goto L_0141;\n\tv311 = *([v22 @ X29_v1-18]);\n\tgoto L_0134;\nL_012F:\n\tv522 = v121 != 0.5d;\n\tif (v522) goto L_0144;\n\tv311 = *([v22 @ X29_v1-18]);\nL_0134:\n\tv543 = v311 + v540;\n\tv544 = v311 & 1;\n\tv546 = v544 == 0;\n\tv549 = ~v546;\n\tif (v549) goto L_FFFFFFFF;\n\tgoto L_0140;\nL_0140:\n\tgoto L_FFFFFFFF;\nL_0141:\n\tv525 = v121 + -0.5d;\n\tv311 = System.Math::Ceiling(v525);\n\tgoto L_FFFFFFFF;\nL_0144:\n\tv529 = v121 + 0.5d;\n\tv311 = System.Math::Floor(v529);\nL_015E:\n\t// 350 MakeStruct v185 @ AGG10DFAF8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v125 @ V10_v6 (UnityEngine.Vector3), v123 @ V9_v6 (System.Single), v121 @ V8_v6 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(t.setter, v185);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, bool isRelative)
		{
			//IL_002a: Expected F4, but got I
			//IL_003a: Expected F4, but got I
			//IL_0118: Expected F4, but got I
			//IL_0128: Expected F4, but got I
			//IL_01d9: Expected O, but got I
			//IL_033d: Expected O, but got I
			//IL_0292: Expected F8, but got I
			//IL_0681: Unknown result type (might be due to invalid IL or missing references)
			//IL_0686: Expected I4, but got Unknown
			//IL_0245: Expected F8, but got I
			//IL_0488: Expected O, but got I
			//IL_03e7: Expected F8, but got I
			//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d0: Expected I4, but got Unknown
			//IL_039f: Expected F8, but got I
			//IL_05ba: Expected O, but got F8
			//IL_0532: Expected F8, but got I
			//IL_0715: Unknown result type (might be due to invalid IL or missing references)
			//IL_071a: Expected I4, but got Unknown
			//IL_04ea: Expected F8, but got I
			object obj2 = default(object);
			object obj = obj2;
			Vector3 startValue = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]");
			float num2 = 0f;
			Vector3 vector = t.getter();
			float y = vector.y;
			float z = vector.z;
			t.endValue = vector;
			_ = vector.y;
			_ = vector.z;
			bool flag = !isRelative;
			float num3 = vector.z;
			float num4 = vector.y;
			Vector3 vector2 = vector;
			if (!flag)
			{
				Vector3 vector3 = vector + t.endValue;
				y = vector3.y;
				z = vector3.z;
				vector2 = t.endValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]");
				num4 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]");
				num3 = 0f;
				num2 = vector3.z;
				num = vector3.y;
				startValue = vector3;
			}
			t.startValue = startValue;
			if ((IntPtr)t.plugOptions != (IntPtr)2)
			{
				if ((IntPtr)t.plugOptions != (IntPtr)8)
				{
					if ((IntPtr)t.plugOptions == (IntPtr)4)
					{
						startValue = vector2;
						goto IL_065c;
					}
				}
				else
				{
					num = num4;
					startValue = vector2;
				}
				goto IL_0637;
			}
			num = num4;
			goto IL_065c;
			IL_065c:
			num2 = num3;
			goto IL_0637;
			IL_032e:
			object obj3 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num5;
			double num7;
			double num8;
			double num6;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a = (double)num + -0.5;
					num5 = Math.Ceiling(a);
					num6 = -0.5;
					goto IL_0479;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num7 = 0.0;
				num8 = -1.0;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d = (double)num + 0.5;
					num5 = Math.Floor(d);
					num6 = 0.5;
					goto IL_0479;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num7 = 0.0;
				num8 = 1.0;
			}
			num6 = num7 + num8;
			num5 = (((num7 & 1) != 0) ? num6 : num7);
			goto IL_0479;
			IL_05bf:
			Vector3 pNewValue = default(Vector3);
			pNewValue.x = startValue.x;
			pNewValue.y = num;
			pNewValue.z = num2;
			t.setter(pNewValue);
			return;
			IL_0637:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+144]");
			double num9;
			if ((IntPtr)0 != (IntPtr)0)
			{
				object obj4 = (long)(IntPtr)obj2 - 24L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num11;
				double num12;
				double num10;
				if (startValue.x < 0f)
				{
					if ((double)startValue.x != -0.5)
					{
						double a2 = (double)startValue.x + -0.5;
						num9 = Math.Ceiling(a2);
						num10 = -0.5;
						goto IL_032e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
					num11 = 0.0;
					num12 = -1.0;
				}
				else
				{
					if ((double)startValue.x != 0.5)
					{
						double d2 = (double)startValue.x + 0.5;
						num9 = Math.Floor(d2);
						num10 = 0.5;
						goto IL_032e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
					num11 = 0.0;
					num12 = 1.0;
				}
				num10 = num11 + num12;
				num9 = (((num11 & 1) != 0) ? num10 : num11);
				goto IL_032e;
			}
			goto IL_05bf;
			IL_05a2:
			double num13;
			num2 = (float)num13;
			num = (float)num5;
			startValue = (Vector3)num9;
			goto IL_05bf;
			IL_0479:
			object obj5 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num14;
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a3 = (double)num2 + -0.5;
					num13 = Math.Ceiling(a3);
					goto IL_05a2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num13 = 0.0;
				num14 = -1.0;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d3 = (double)num2 + 0.5;
					num13 = Math.Floor(d3);
					goto IL_05a2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num13 = 0.0;
				num14 = 1.0;
			}
			double num15 = num13 + num14;
			if ((num13 & 1) != 0)
			{
				num13 = num15;
			}
			goto IL_05a2;
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0x10DFB04", Offset = "0x10DFB04", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv243 = fromValue.y;\n\tv156 = fromValue.z;\n\tgoto L_0021;\n\tv38 = *([1EE7B38]);\n\tv39 = *([v38 @ X8_v29]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, setImmediately, methodInfo, v42, v43, v44, v45, fromValue, v0, v2, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([20274E9]) = v54;\nL_0021:\n\tt.startValue = fromValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+120]) = fromValue.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+124]) = fromValue.z;\n\tv57 = setImmediately == 0;\n\tif (v57) goto L_005E;\n\tv64 = t.plugOptions == 8;\n\tif (v64) goto L_0071;\n\tv120 = t.plugOptions == 4;\n\tif (v120) goto L_0065;\n\tv95 = t.plugOptions != 2;\n\tif (v95) goto L_0077;\n\tv213 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv243 = v213.y;\n\tv156 = v213.z;\n\tgoto L_0077;\nL_005E:\n\treturn;\nL_0065:\n\tv214 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv156 = v214.z;\n\tgoto L_0077;\nL_0071:\n\tv211 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv243 = v211.y;\nL_0077:\n\tv248 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+144]) == 0;\n\tif (v248) goto L_0159;\n\tgoto L_0088;\n\tv280 = *([v253 @ X0_v8+E0]);\n\tv281 = v280 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_0088;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v253, v92, setImmediately, methodInfo, v42, v43, v44, v45, v212, v243, v156, v46, v47, v48, v49, v50);\nL_0088:\n\tv291 = 0x6D1ED0(&v289 @ stack_-58_v3 (System.Double), v92, setImmediately, methodInfo, v42, v43, v44, v45, v148, v243, v156, v46, v47, v48, v49, v50);\n\tv302 = v148 >= 0;\n\tif (v302) goto L_00AD;\n\tv313 = v148 != -0.5d;\n\tif (v313) goto L_00BF;\n\tgoto L_00B2;\nL_00AD:\n\tv324 = v148 != 0.5d;\n\tif (v324) goto L_00C2;\nL_00B2:\n\tv366 = v333 + v343;\n\tv346 = v333 & 1;\n\tv348 = v346 == 0;\n\tv351 = ~v348;\n\tif (v351) goto L_FFFFFFFF;\n\tgoto L_00BE;\nL_00BE:\n\tgoto L_00C7;\nL_00BF:\n\tv327 = v148 + -0.5d;\n\tv260 = System.Math::Ceiling(v327);\n\tgoto L_00C7;\nL_00C2:\n\tv331 = v148 + 0.5d;\n\tv260 = System.Math::Floor(v331);\nL_00C7:\n\tv371 = 0x6D1ED0(&v289 @ stack_-58_v3 (System.Double), v92, setImmediately, methodInfo, v42, v43, v44, v45, v150, v366, v156, v46, v47, v48, v49, v50);\n\tv383 = v150 >= 0;\n\tif (v383) goto L_00EC;\n\tv394 = v150 != -0.5d;\n\tif (v394) goto L_00FE;\n\tgoto L_00F1;\nL_00EC:\n\tv405 = v150 != 0.5d;\n\tif (v405) goto L_0101;\nL_00F1:\n\tv447 = v414 + v424;\n\tv427 = v414 & 1;\n\tv429 = v427 == 0;\n\tv432 = ~v429;\n\tif (v432) goto L_FFFFFFFF;\n\tgoto L_00FD;\nL_00FD:\n\tgoto L_0106;\nL_00FE:\n\tv408 = v150 + -0.5d;\n\tv259 = System.Math::Ceiling(v408);\n\tgoto L_0106;\nL_0101:\n\tv412 = v150 + 0.5d;\n\tv259 = System.Math::Floor(v412);\nL_0106:\n\tv272 = 0x6D1ED0(&v289 @ stack_-58_v3 (System.Double), v92, setImmediately, methodInfo, v42, v43, v44, v45, v152, v447, v156, v46, v47, v48, v49, v50);\n\tv462 = v152 >= 0;\n\tif (v462) goto L_012B;\n\tv473 = v152 != -0.5d;\n\tif (v473) goto L_013D;\n\tgoto L_0130;\nL_012B:\n\tv484 = v152 != 0.5d;\n\tif (v484) goto L_0140;\nL_0130:\n\tv505 = v261 + v503;\n\tv506 = v261 & 1;\n\tv508 = v506 == 0;\n\tv511 = ~v508;\n\tif (v511) goto L_FFFFFFFF;\n\tgoto L_013C;\nL_013C:\n\tgoto L_FFFFFFFF;\nL_013D:\n\tv487 = v152 + -0.5d;\n\tv261 = System.Math::Ceiling(v487);\n\tgoto L_FFFFFFFF;\nL_0140:\n\tv491 = v152 + 0.5d;\n\tv261 = System.Math::Floor(v491);\nL_0159:\n\t// 345 MakeStruct v164 @ AGG10DFDC8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v148 @ V10_v5 (UnityEngine.Vector3), v150 @ V9_v5 (System.Single), v152 @ V8_v5 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(t.setter, v164);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 249 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 fromValue, bool setImmediately)
		{
			//IL_01b9: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_0118: Expected O, but got I
			//IL_0606: Unknown result type (might be due to invalid IL or missing references)
			//IL_060b: Expected I4, but got Unknown
			//IL_0650: Unknown result type (might be due to invalid IL or missing references)
			//IL_0655: Expected I4, but got Unknown
			//IL_0575: Expected O, but got F8
			//IL_069a: Unknown result type (might be due to invalid IL or missing references)
			//IL_069f: Expected I4, but got Unknown
			float y = fromValue.y;
			float z = fromValue.z;
			t.startValue = fromValue;
			_ = fromValue.y;
			_ = fromValue.z;
			if (!setImmediately)
			{
				return;
			}
			Vector3 vector;
			float num;
			float num2;
			if ((IntPtr)t.plugOptions != (IntPtr)8)
			{
				if ((IntPtr)t.plugOptions != (IntPtr)4)
				{
					bool flag = (IntPtr)t.plugOptions != (IntPtr)2;
					object obj = t;
					vector = fromValue;
					num = y;
					num2 = z;
					if (!flag)
					{
						Vector3 vector2 = t.getter();
						y = vector2.y;
						z = vector2.z;
						obj = 0;
						vector = fromValue;
						num = vector2.y;
						num2 = vector2.z;
					}
				}
				else
				{
					Vector3 vector3 = t.getter();
					z = vector3.z;
					object obj = 0;
					vector = vector3;
					num = y;
					num2 = vector3.z;
					y = vector3.y;
				}
			}
			else
			{
				Vector3 vector4 = t.getter();
				y = vector4.y;
				object obj = 0;
				vector = vector4;
				num = vector4.y;
				num2 = fromValue.z;
				z = vector4.z;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+144]");
			double num3;
			double num6 = default(double);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num5;
				double num7;
				double num4;
				if (vector.x < 0f)
				{
					if ((double)vector.x != -0.5)
					{
						double a = (double)vector.x + -0.5;
						num3 = Math.Ceiling(a);
						num4 = -0.5;
						goto IL_0337;
					}
					num5 = num6;
					num7 = -1.0;
				}
				else
				{
					if ((double)vector.x != 0.5)
					{
						double d = (double)vector.x + 0.5;
						num3 = Math.Floor(d);
						num4 = 0.5;
						goto IL_0337;
					}
					num5 = num6;
					num7 = 1.0;
				}
				num4 = num5 + num7;
				num3 = (((num5 & 1) != 0) ? num4 : num5);
				goto IL_0337;
			}
			goto IL_058a;
			IL_0463:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num8;
			double num9;
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a2 = (double)num2 + -0.5;
					num8 = Math.Ceiling(a2);
					goto IL_056d;
				}
				num8 = num6;
				num9 = -1.0;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d2 = (double)num2 + 0.5;
					num8 = Math.Floor(d2);
					goto IL_056d;
				}
				num8 = num6;
				num9 = 1.0;
			}
			double num10 = num8 + num9;
			if ((num8 & 1) != 0)
			{
				num8 = num10;
			}
			goto IL_056d;
			IL_058a:
			Vector3 pNewValue = default(Vector3);
			pNewValue.x = vector.x;
			pNewValue.y = num;
			pNewValue.z = num2;
			t.setter(pNewValue);
			return;
			IL_0337:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num11;
			double num13;
			double num14;
			double num12;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a3 = (double)num + -0.5;
					num11 = Math.Ceiling(a3);
					num12 = -0.5;
					goto IL_0463;
				}
				num13 = num6;
				num14 = -1.0;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d3 = (double)num + 0.5;
					num11 = Math.Floor(d3);
					num12 = 0.5;
					goto IL_0463;
				}
				num13 = num6;
				num14 = 1.0;
			}
			num12 = num13 + num14;
			num11 = (((num13 & 1) != 0) ? num12 : num13);
			goto IL_0463;
			IL_056d:
			vector = (Vector3)num3;
			num = (float)num11;
			num2 = (float)num8;
			goto IL_058a;
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0x10DFDD4", Offset = "0x10DFDD4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector3 ConvertToStartValue(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 value)
		{
			return value;
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0x10DFDD8", Offset = "0x10DFDD8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv30 = *([1EAA558]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, t, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([20274EA]) = v50;\nL_0027:\n\tgoto L_0036;\n\tv66 = *([v59 @ X0_v4+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0036;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v59, t, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0036:\n\tv82 = UnityEngine.Vector3::op_Addition(t.endValue, t.startValue);\n\tt.endValue = v82;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]) = v82.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]) = v82.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
			Vector3 vector = (t.endValue += t.startValue);
			_ = vector.y;
			_ = vector.z;
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0x10DFEA0", Offset = "0x10DFEA0", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1ED3B08]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, t, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([20274EB]) = v50;\nL_0020:\n\tv57 = t.plugOptions == 8;\n\tif (v57) goto L_0051;\n\tv68 = t.plugOptions == 4;\n\tif (v68) goto L_0048;\n\tv91 = t.plugOptions != 2;\n\tif (v91) goto L_0068;\n\tv78 = 0;\n\tv108 = t.endValue - t.startValue;\n\tgoto L_FFFFFFFF;\nL_0048:\n\tv106 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]) - *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+120]);\n\tgoto L_0055;\nL_0051:\n\tv100 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]) - *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+124]);\nL_0055:\n\tv132 = 0x1586898(v129, 0, methodInfo, v34, v35, v36, v37, v38, v108, v106, v100, v42, v43, v44, v45, v46);\n\tt.changeValue = v78;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+13C]) = v104;\n\tgoto L_0088;\nL_0068:\n\tgoto L_0077;\n\tv239 = *([v231 @ X0_v10+E0]);\n\tv240 = v239 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_0077;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v231, t, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0077:\n\tv255 = UnityEngine.Vector3::op_Subtraction(t.endValue, t.startValue);\n\tt.changeValue = v255;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+138]) = v255.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+13C]) = v255.z;\nL_0088:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
			Vector3 vector2 = default(Vector3);
			if ((IntPtr)t.plugOptions != (IntPtr)8)
			{
				if ((IntPtr)t.plugOptions != (IntPtr)4)
				{
					if ((IntPtr)t.plugOptions != (IntPtr)2)
					{
						Vector3 vector = (t.changeValue = t.endValue - t.startValue);
						_ = vector.y;
						_ = vector.z;
						return;
					}
					vector2 = default(Vector3);
					float num = t.endValue.x - t.startValue.x;
					vector2 = default(Vector3);
					int num2 = 0;
					int num3 = 0;
					object obj = vector2;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+12C]");
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+120]");
					int num3 = (int)((long)intPtr - 0L);
					int num2 = 0;
					float num = 0f;
					object obj = vector2;
				}
				int num4 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+130]");
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+124]");
				int num4 = (int)((long)intPtr2 - 0L);
				int num2 = 0;
				int num3 = 0;
				float num = 0f;
				object obj = vector2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			t.changeValue = vector2;
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0x10E0010", Offset = "0x10E0010", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0x158AD58(&changeValue @ V1 (System.Single), 0, methodInfo, v20, v21, v22, v23, v24, unitsXSecond, changeValue, *([changeValue @ V1 (System.Single)+4]), *([changeValue @ V1 (System.Single)+8]), v25, v26, v27, v28);\n\treturnVal1 = unitsXSecond / unitsXSecond;\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector3 changeValue)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			return unitsXSecond / unitsXSecond;
		}

		[Token(Token = "0x600021F")]
		[Address(RVA = "0x10E004C", Offset = "0x10E004C", Length = "0x698")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv64 = *([1EFEC10]);\n\tv65 = *([v64 @ X8_v85]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, v2, changeValue, v3, v5, duration);\n\tv73 = 0 | 1;\n\t*([20274EC]) = v73;\nL_003A:\n\tv85 = t.loopType != 2;\n\tif (v85) goto L_0065;\n\tv369 = t.completedLoops - t.isComplete;\n\tgoto L_0052;\n\tv456 = *([v365 @ X0_v56+E0]);\n\tv457 = v456 == 0;\n\tv458 = ~v457;\n\tif (v458) goto L_0052;\n\tv460 = \"il2cpp_codegen_runtime_class_init\"(v365, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, v2, changeValue, v3, v5, duration);\nL_0052:\n\tv466 = UnityEngine.Vector3::op_Multiply(changeValue, v369);\n\tv377 = UnityEngine.Vector3::op_Addition(startValue, v466);\nL_0065:\n\tv390 = ~t.isSequenced;\n\tif (v390) goto L_00CD;\n\tv332 = t.sequenceParent;\n\tv477 = v332.loopType != 2;\n\tif (v477) goto L_00CD;\n\tv187 = t.loopType != 2;\n\tif (v187) goto L_FFFFFFFF;\n\tv141 = t.loops;\n\tgoto L_008C;\nL_008C:\n\tgoto L_009A;\n\tv706 = *([v647 @ X0_v47+E0]);\n\tv707 = v706 == 0;\n\tv708 = ~v707;\n\tgoto L_009A;\n\tv710 = \"il2cpp_codegen_runtime_class_init\"(v647, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v169, v161, v354, v349, v153, v345, v5, duration);\nL_009A:\n\tv170 = UnityEngine.Vector3::op_Multiply(changeValue, v141);\n\tv333 = t.sequenceParent;\n\tv507 = v333.completedLoops - v333.isComplete;\n\tgoto L_00B7;\n\tv1021 = *([v909 @ X0_v50+E0]);\n\tv1022 = v1021 == 0;\n\tv1023 = ~v1022;\n\tif (v1023) goto L_00B7;\n\tv1025 = \"il2cpp_codegen_runtime_class_init\"(v909, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v170, v162, v355, v350, v153, v345, v5, duration);\nL_00B7:\n\tv1031 = UnityEngine.Vector3::op_Multiply(v170, v507);\n\t// 193 MakeStruct v468 @ AGG10E0230_0_v9 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v293 @ V13_v11 (UnityEngine.Vector3), v297 @ V12_v17 (System.Single), v438 @ V11_v8 (System.Single)\n\tv474 = UnityEngine.Vector3::op_Addition(v468, v1031);\nL_00CD:\n\tv519 = t.customEase;\n\tv171 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, v503, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv238 = options == 8;\n\tif (v238) goto L_0135;\n\tv239 = options == 4;\n\tif (v239) goto L_0170;\n\tv188 = options != 2;\n\tif (v188) goto L_01A5;\n\tv719 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(getter);\n\tv1066 = v719.y;\n\tv1092 = v719.z;\n\tv788 = changeValue * v171;\n\tv789 = options >> 0x20;\n\tv790 = v789 & 0xFF;\n\tv309 = v293 + v788;\n\tv792 = v790 == 0;\n\tif (v792) goto L_FFFFFFFF;\n\tgoto L_0114;\n\tv1032 = *([v916 @ X0_v42+E0]);\n\tv1033 = v1032 == 0;\n\tv1034 = ~v1033;\n\tif (v1034) goto L_0114;\n\tv1036 = \"il2cpp_codegen_runtime_class_init\"(v916, v109, v98, isRelative, getter, setter, usingInversePosition, updateNotice, v788, v787, v357, v348, v152, v344, v5, duration);\nL_0114:\n\tv933 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(&v757 @ stack_-88_v11 (System.Double));\n\tv1176 = v309 >= 0;\n\tif (v1176) goto L_01E3;\n\tv1223 = v309 != -0.5d;\n\tif (v1223) goto L_0249;\n\tgoto L_01E8;\nL_0135:\n\tv966 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(getter);\n\tv1066 = v966.y;\n\tv661 = v322 * v171;\n\tv662 = options >> 0x20;\n\tv663 = v662 & 0xFF;\n\tv576 = v438 + v661;\n\tv665 = v663 == 0;\n\tif (v665) goto L_FFFFFFFF;\n\tgoto L_014F;\n\tv873 = *([v752 @ X0_v22+E0]);\n\tv874 = v873 == 0;\n\tv875 = ~v874;\n\tif (v875) goto L_014F;\n\tv877 = \"il2cpp_codegen_runtime_class_init\"(v752, v110, v98, isRelative, getter, setter, usingInversePosition, updateNotice, v661, v660, v358, v348, v152, v344, v5, duration);\nL_014F:\n\tv769 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(&v757 @ stack_-88_v11 (System.Double));\n\tv1012 = v576 >= 0;\n\tif (v1012) goto L_01FF;\n\tv1130 = v576 != -0.5d;\n\tif (v1130) goto L_024C;\n\tgoto L_0204;\nL_0170:\n\tv659 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(getter);\n\tv583 = v659.z;\n\tv745 = v315 * v171;\n\tv746 = options >> 0x20;\n\tv747 = v746 & 0xFF;\n\tv442 = v297 + v745;\n\tv749 = v747 == 0;\n\tif (v749) goto L_0270;\n\tgoto L_018A;\n\tv994 = *([v849 @ X0_v29+E0]);\n\tv995 = v994 == 0;\n\tv996 = ~v995;\n\tif (v996) goto L_018A;\n\tv998 = \"il2cpp_codegen_runtime_class_init\"(v849, v107, v98, isRelative, getter, setter, usingInversePosition, updateNotice, v745, v744, v353, v348, v152, v344, v5, duration);\nL_018A:\n\tv866 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(&v757 @ stack_-88_v11 (System.Double));\n\tv1119 = v442 >= 0;\n\tif (v1119) goto L_021B;\n\tv1191 = v442 != -0.5d;\n\tif (v1191) goto L_024F;\n\tgoto L_0220;\nL_01A5:\n\tv651 = changeValue * v171;\n\tv652 = v315 * v171;\n\tv583 = v322 * v171;\n\tv653 = options >> 0x20;\n\tv654 = v653 & 0xFF;\n\tv311 = v293 + v651;\n\tv575 = v297 + v652;\n\tv576 = v438 + v583;\n\tv655 = v654 == 0;\n\tif (v655) goto L_FFFFFFFF;\n\tgoto L_01BE;\n\tv793 = *([v722 @ X0_v34+E0]);\n\tv794 = v793 == 0;\n\tv795 = ~v794;\n\tif (v795) goto L_01BE;\n\tv797 = \"il2cpp_codegen_runtime_class_init\"(v722, v108, v98, isRelative, getter, setter, usingInversePosition, updateNotice, v651, v652, v453, v348, v152, v344, v5, duration);\nL_01BE:\n\tv433 = 0x6D1ED0(&v757 @ stack_-88_v11 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, updateNotice, v311, v652, v583, t.easePeriod, v529, v581, changeValue.z, duration);\n\tv948 = v311 >= 0;\n\tif (v948) goto L_0237;\n\tv540 = v311 != -0.5d;\n\tif (v540) goto L_0252;\n\tgoto L_023C;\nL_01E3:\n\tv1234 = v309 != 0.5d;\n\tif (v1234) goto L_0255;\nL_01E8:\n\tv1312 = v923 + v1300;\n\tv1313 = v923 & 1;\n\tv1315 = v1313 == 0;\n\tv1318 = ~v1315;\n\tif (v1318) goto L_FFFFFFFF;\n\tgoto L_01F4;\nL_01F4:\n\tgoto L_FFFFFFFF;\nL_01FF:\n\tv1141 = v576 != 0.5d;\n\tif (v1141) goto L_0262;\nL_0204:\n\tv1260 = v759 + v1248;\n\tv1261 = v759 & 1;\n\tv1263 = v1261 == 0;\n\tv1266 = ~v1263;\n\tif (v1266) goto L_FFFFFFFF;\n\tgoto L_0210;\nL_0210:\n\tgoto L_FFFFFFFF;\nL_021B:\n\tv1202 = v442 != 0.5d;\n\tif (v1202) goto L_026D;\nL_0220:\n\tv855 = v856 + v1278;\n\tv1291 = v856 & 1;\n\tv1293 = v1291 == 0;\n\tv1296 = ~v1293;\n\tif (v1296) goto L_FFFFFFFF;\n\tgoto L_022C;\nL_022C:\n\tgoto L_FFFFFFFF;\nL_0237:\n\tv415 = v311 != 0.5d;\n\tif (v415) goto L_0275;\nL_023C:\n\tv531 = v536 + v1235;\n\tv568 = v536 & 1;\n\tv556 = v568 == 0;\n\tv515 = ~v556;\n\tif (v515) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_027A;\nL_0249:\n\tv1270 = v309 + -0.5d;\n\tv923 = System.Math::Ceiling(v1270);\n\tgoto L_FFFFFFFF;\nL_024C:\n\tv1205 = v576 + -0.5d;\n\tv759 = System.Math::Ceiling(v1205);\n\tgoto L_FFFFFFFF;\nL_024F:\n\tv1242 = v442 + -0.5d;\n\tv856 = System.Math::Ceiling(v1242);\n\tgoto L_FFFFFFFF;\nL_0252:\n\tv535 = v311 + -0.5d;\n\tv571 = System.Math::Ceiling(v535);\n\tgoto L_027A;\nL_0255:\n\tv1274 = v309 + 0.5d;\n\tv923 = System.Math::Floor(v1274);\n\tgoto L_0312;\nL_0262:\n\tv1209 = v576 + 0.5d;\n\tv759 = System.Math::Floor(v1209);\n\tgoto L_02FF;\nL_026D:\n\tv1246 = v442 + 0.5d;\n\tv856 = System.Math::Floor(v1246);\nL_0270:\n\tv872 = setter == 0;\n\tv283 = ~v872;\n\tif (v283) goto L_FFFFFFFF;\n\tthrow System.NullReferenceException;\nL_0275:\n\tv454 = v311 + 0.5d;\n\tv571 = System.Math::Floor(v454);\nL_027A:\n\tv588 = 0x6D1ED0(&v757 @ stack_-88_v11 (System.Double), v519, v517, isRelative, getter, setter, usingInversePosition, updateNotice, v575, v531, v583, t.easePeriod, v529, v581, changeValue.z, duration);\n\tv605 = v575 >= 0;\n\tif (v605) goto L_029F;\n\tv619 = v575 != -0.5d;\n\tif (v619) goto L_02B1;\n\tgoto L_02A4;\nL_029F:\n\tv630 = v575 != 0.5d;\n\tif (v630) goto L_02B4;\nL_02A4:\n\tv686 = v667 + v666;\n\tv679 = v667 & 1;\n\tv681 = v679 == 0;\n\tv684 = ~v681;\n\tif (v684) goto L_FFFFFFFF;\n\tgoto L_02B0;\nL_02B0:\n\tgoto L_02B9;\nL_02B1:\n\tv640 = v575 + -0.5d;\n\tv698 = System.Math::Ceiling(v640);\n\tgoto L_02B9;\nL_02B4:\n\tv644 = v575 + 0.5d;\n\tv698 = System.Math::Floor(v644);\nL_02B9:\n\tv705 = 0x6D1ED0(&v757 @ stack_-88_v11 (System.Double), v519, v517, isRelative, getter, setter, usingInversePosition, updateNotice, v576, v686, v583, t.easePeriod, v529, v581, changeValue.z, duration);\n\tv786 = v576 >= 0;\n\tif (v786) goto L_02DE;\n\tv897 = v576 != -0.5d;\n\tif (v897) goto L_02F0;\n\tgoto L_02E3;\nL_02DE:\n\tv908 = v576 != 0.5d;\n\tif (v908) goto L_02F3;\nL_02E3:\n\tv1154 = v728 + v1142;\n\tv1155 = v728 & 1;\n\tv1157 = v1155 == 0;\n\tv1160 = ~v1157;\n\tif (v1160) goto L_FFFFFFFF;\n\tgoto L_02EF;\n\n// ... truncated")]
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_03ed: Expected I4, but got O
			//IL_00b3: Expected O, but got F4
			//IL_04d3: Expected I4, but got O
			//IL_0435: Expected O, but got F8
			//IL_0d72: Expected O, but got I
			//IL_05c1: Expected I4, but got O
			//IL_051b: Expected O, but got F8
			//IL_0de5: Expected O, but got F4
			//IL_0303: Expected I4, but got O
			//IL_08e4: Expected O, but got F4
			//IL_0d20: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d25: Expected I4, but got Unknown
			//IL_0350: Expected O, but got F8
			//IL_0db0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0db5: Expected I4, but got Unknown
			//IL_0227: Expected O, but got F4
			//IL_0e02: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e07: Expected I4, but got Unknown
			//IL_0cdb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ce0: Expected I4, but got Unknown
			//IL_0ea8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ead: Expected I4, but got Unknown
			//IL_0ef2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef7: Expected I4, but got Unknown
			bool flag = t.loopType != LoopType.Incremental;
			Vector3 vector = changeValue;
			Vector3 vector2 = startValue;
			float y = startValue.y;
			float z = startValue.z;
			float y2 = changeValue.y;
			if (!flag)
			{
				float num = (float)t.completedLoops - (float)(t.isComplete ? 1 : 0);
				Vector3 vector3 = changeValue * num;
				Vector3 vector4 = startValue + vector3;
				vector = (Vector3)vector3.y;
				vector2 = vector4;
				y = vector4.y;
				z = vector4.z;
				y2 = vector3.z;
			}
			bool flag2 = !t.isSequenced;
			float y3 = changeValue.y;
			float z2 = changeValue.z;
			float duration2 = duration;
			if (!flag2)
			{
				Sequence sequenceParent = t.sequenceParent;
				bool flag3 = sequenceParent.loopType != LoopType.Incremental;
				y3 = changeValue.y;
				z2 = changeValue.z;
				duration2 = duration;
				if (!flag3)
				{
					int num2 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					Vector3 vector5 = changeValue * num2;
					Sequence sequenceParent2 = t.sequenceParent;
					float num3 = (float)sequenceParent2.completedLoops - (float)(sequenceParent2.isComplete ? 1 : 0);
					Vector3 vector6 = vector5 * num3;
					Vector3 vector7 = default(Vector3);
					vector7.x = vector2.x;
					vector7.y = y;
					vector7.z = z;
					Vector3 vector8 = vector7 + vector6;
					vector = (Vector3)vector6.y;
					vector2 = vector8;
					y = vector8.y;
					z = vector8.z;
					y3 = changeValue.y;
					z2 = changeValue.z;
					duration2 = duration;
					y2 = vector6.z;
				}
			}
			EaseFunction customEase = t.customEase;
			float num4 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration2, t.easeOvershootOrAmplitude, t.easePeriod);
			float y4;
			float z3;
			float num8;
			double num9 = default(double);
			double num10;
			float num18;
			float num19;
			float num20;
			double num21;
			Vector3 vector12;
			float num15;
			float num28;
			double num29;
			Tween tween;
			if ((IntPtr)options != (IntPtr)8)
			{
				if ((IntPtr)options != (IntPtr)4)
				{
					Vector3 vector10 = default(Vector3);
					if ((IntPtr)options == (IntPtr)2)
					{
						Vector3 vector9 = getter();
						y4 = vector9.y;
						z3 = vector9.z;
						float num5 = vector10.x * num4;
						int num6 = (object)options >> 32;
						int num7 = num6 & 0xFF;
						num8 = vector2.x + num5;
						if (num7 != 0)
						{
							Vector3 vector11 = ((DOGetter<Vector3>)num9)();
							double num11;
							if (num8 < 0f)
							{
								if ((double)num8 != -0.5)
								{
									double a = (double)num8 + -0.5;
									num10 = Math.Ceiling(a);
									goto IL_08ce;
								}
								num11 = -1.0;
								num10 = num9;
							}
							else
							{
								if ((double)num8 != 0.5)
								{
									double d = (double)num8 + 0.5;
									num10 = Math.Floor(d);
									goto IL_08ce;
								}
								num11 = 1.0;
								num10 = num9;
							}
							double num12 = num10 + num11;
							if ((num10 & 1) != 0)
							{
								num10 = num12;
							}
							goto IL_08ce;
						}
						goto IL_08db;
					}
					float num13 = vector10.x * num4;
					float num14 = y3 * num4;
					num15 = z2 * num4;
					int num16 = (object)options >> 32;
					int num17 = num16 & 0xFF;
					num18 = vector2.x + num13;
					num19 = y + num14;
					num20 = z + num15;
					if (num17 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
						double num23;
						double num24;
						double num22;
						if (num18 < 0f)
						{
							if ((double)num18 != -0.5)
							{
								double a2 = (double)num18 + -0.5;
								num21 = Math.Ceiling(a2);
								tween = null;
								num22 = -0.5;
								goto IL_09ae;
							}
							num23 = -1.0;
							num24 = num9;
						}
						else
						{
							bool flag4 = (double)num18 != 0.5;
							tween = null;
							num22 = 0.5;
							if (flag4)
							{
								double d2 = (double)num18 + 0.5;
								num21 = Math.Floor(d2);
								num19 = num19;
								num20 = num20;
								goto IL_09ae;
							}
							num23 = 1.0;
							num24 = num9;
						}
						num22 = num24 + num23;
						num21 = (((num24 & 1) != 0) ? num22 : num24);
						tween = null;
						goto IL_09ae;
					}
					goto IL_0ddd;
				}
				vector12 = getter();
				num15 = vector12.z;
				float num25 = y3 * num4;
				int num26 = (object)options >> 32;
				int num27 = num26 & 0xFF;
				num28 = y + num25;
				if (num27 != 0)
				{
					Vector3 vector13 = ((DOGetter<Vector3>)num9)();
					double num31;
					double num30;
					if (num28 < 0f)
					{
						if ((double)num28 != -0.5)
						{
							double a3 = (double)num28 + -0.5;
							num29 = Math.Ceiling(a3);
							num30 = -0.5;
							goto IL_0965;
						}
						num31 = -1.0;
						num29 = num9;
					}
					else
					{
						if ((double)num28 != 0.5)
						{
							double d3 = (double)num28 + 0.5;
							num29 = Math.Floor(d3);
							num30 = 0.5;
							goto IL_0965;
						}
						num31 = 1.0;
						num29 = num9;
					}
					num30 = num29 + num31;
					if ((num29 & 1) != 0)
					{
						num29 = num30;
					}
					goto IL_0965;
				}
				goto IL_0d4d;
			}
			Vector3 vector14 = getter();
			y4 = vector14.y;
			float num32 = z2 * num4;
			int num33 = (object)options >> 32;
			int num34 = num33 & 0xFF;
			num20 = z + num32;
			double num35;
			if (num34 != 0)
			{
				Vector3 vector15 = ((DOGetter<Vector3>)num9)();
				double num36;
				if (num20 < 0f)
				{
					if ((double)num20 != -0.5)
					{
						double a4 = (double)num20 + -0.5;
						num35 = Math.Ceiling(a4);
						goto IL_0917;
					}
					num36 = -1.0;
					num35 = num9;
				}
				else
				{
					if ((double)num20 != 0.5)
					{
						double d4 = (double)num20 + 0.5;
						num35 = Math.Floor(d4);
						goto IL_0917;
					}
					num36 = 1.0;
					num35 = num9;
				}
				double num37 = num35 + num36;
				if ((num35 & 1) != 0)
				{
					num35 = num37;
				}
				goto IL_0917;
			}
			goto IL_0924;
			IL_0be4:
			num18 = (float)num21;
			double num38;
			num19 = (float)num38;
			double num39;
			num20 = (float)num39;
			goto IL_0ddd;
			IL_0d4d:
			bool flag5 = setter == null;
			bool flag6 = !flag5;
			tween = null;
			customEase = (EaseFunction)0;
			Vector3 vector16 = vector12;
			num19 = num28;
			num20 = num15;
			if (!flag6)
			{
				throw new NullReferenceException();
			}
			goto IL_0c01;
			IL_0ada:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num40;
			if (num20 < 0f)
			{
				if ((double)num20 != -0.5)
				{
					double a5 = (double)num20 + -0.5;
					num39 = Math.Ceiling(a5);
					goto IL_0be4;
				}
				num40 = -1.0;
				num39 = num9;
			}
			else
			{
				if ((double)num20 != 0.5)
				{
					double d5 = (double)num20 + 0.5;
					num39 = Math.Floor(d5);
					goto IL_0be4;
				}
				num40 = 1.0;
				num39 = num9;
			}
			double num41 = num39 + num40;
			if ((num39 & 1) != 0)
			{
				num39 = num41;
			}
			goto IL_0be4;
			IL_0e48:
			Vector3 pNewValue = default(Vector3);
			pNewValue.x = vector14.x;
			pNewValue.y = y4;
			pNewValue.z = z3;
			DOSetter<Vector3> dOSetter;
			dOSetter(pNewValue);
			return;
			IL_0e82:
			z3 = num20;
			goto IL_0e48;
			IL_0924:
			dOSetter = setter;
			goto IL_0e82;
			IL_0917:
			num20 = (float)num35;
			goto IL_0924;
			IL_0c01:
			y4 = num19;
			vector14 = vector16;
			dOSetter = setter;
			goto IL_0e82;
			IL_09ae:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num43;
			double num44;
			double num42;
			if (num19 < 0f)
			{
				if ((double)num19 != -0.5)
				{
					double a6 = (double)num19 + -0.5;
					num38 = Math.Ceiling(a6);
					num42 = -0.5;
					goto IL_0ada;
				}
				num43 = -1.0;
				num44 = num9;
			}
			else
			{
				if ((double)num19 != 0.5)
				{
					double d6 = (double)num19 + 0.5;
					num38 = Math.Floor(d6);
					num42 = 0.5;
					goto IL_0ada;
				}
				num43 = 1.0;
				num44 = num9;
			}
			num42 = num44 + num43;
			num38 = (((num44 & 1) != 0) ? num42 : num44);
			goto IL_0ada;
			IL_0ddd:
			vector16 = (Vector3)num18;
			goto IL_0c01;
			IL_0965:
			num28 = (float)num29;
			goto IL_0d4d;
			IL_08db:
			vector14 = (Vector3)num8;
			dOSetter = setter;
			goto IL_0e48;
			IL_08ce:
			num8 = (float)num10;
			goto IL_08db;
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0x10E06E4", Offset = "0x10E06E4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB7650]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274ED]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3Plugin()
		{
		}
	}
}
