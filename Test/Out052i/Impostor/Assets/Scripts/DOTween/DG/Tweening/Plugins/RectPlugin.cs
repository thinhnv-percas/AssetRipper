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
	[Token(Token = "0x200007F")]
	public class RectPlugin : ABSTweenPlugin<Rect, Rect, RectOptions>
	{
		[Token(Token = "0x6000325")]
		[Address(RVA = "0xC2330C", Offset = "0xC2330C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Rect, Rect, RectOptions> t)
		{
		}

		[Token(Token = "0x6000326")]
		[Address(RVA = "0xC23310", Offset = "0xC23310", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = System.Math;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, t, isRelative, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35778]) = v50;\nL_001E:\n\tv55 = t.getter;\n\tv131 = DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>::Invoke(t.getter);\n\tt.endValue = t.endValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+138]) = v40;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+13C]) = v41;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+140]) = v42;\n\tt.startValue = t.endValue;\n\tv135 = isRelative == 0;\n\tif (v135) goto L_003D;\n\tv113 = t.startValue;\n\tv140 = t.startValue + t.endValue;\n\tv103 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]) + v40;\n\tv101 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]) + v41;\n\tv99 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]) + v42;\n\tt.startValue = v140;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]) = v103;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]) = v101;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]) = v99;\n\tgoto L_0041;\nL_003D:\n\tv103 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]);\n\tv101 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]);\n\tv99 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]);\nL_0041:\n\tv208 = t.plugOptions == 0;\n\tif (v208) goto L_014B;\n\tgoto L_004E;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v211, v115, isRelative, methodInfo, v35, v36, v37, v38, v53, v40, v41, v42, v113, v111, v109, v107);\nL_004E:\n\tv246 = 0x1854ED0(&v244 @ stack_-58_v3 (System.Double), v55.method, isRelative, methodInfo, v35, v36, v37, v38, v105, v40, v41, v42, v113, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]));\n\tv256 = v105 >= 0;\n\tif (v256) goto L_0073;\n\tv267 = v105 != -0.5d;\n\tif (v267) goto L_0085;\n\tgoto L_0078;\nL_0073:\n\tv278 = v105 != 0.5d;\n\tif (v278) goto L_0088;\nL_0078:\n\tv307 = v297 + v287;\n\tv300 = v297 & 1;\n\tv302 = v300 == 0;\n\tv305 = ~v302;\n\tif (v305) goto L_FFFFFFFF;\n\tgoto L_0084;\nL_0084:\n\tgoto L_008D;\nL_0085:\n\tv281 = v105 + -0.5d;\n\tv229 = System.Math::Ceiling(v281);\n\tgoto L_008D;\nL_0088:\n\tv285 = v105 + 0.5d;\n\tv229 = System.Math::Floor(v285);\nL_008D:\n\tv325 = 0x1854ED0(&v244 @ stack_-58_v3 (System.Double), v55.method, isRelative, methodInfo, v35, v36, v37, v38, v103, v307, v41, v42, v113, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]));\n\tv337 = v103 >= 0;\n\tif (v337) goto L_00B2;\n\tv348 = v103 != -0.5d;\n\tif (v348) goto L_00C4;\n\tgoto L_00B7;\nL_00B2:\n\tv359 = v103 != 0.5d;\n\tif (v359) goto L_00C7;\nL_00B7:\n\tv389 = v378 + v368;\n\tv381 = v378 & 1;\n\tv383 = v381 == 0;\n\tv386 = ~v383;\n\tif (v386) goto L_FFFFFFFF;\n\tgoto L_00C3;\nL_00C3:\n\tgoto L_00CC;\nL_00C4:\n\tv362 = v103 + -0.5d;\n\tv217 = System.Math::Ceiling(v362);\n\tgoto L_00CC;\nL_00C7:\n\tv366 = v103 + 0.5d;\n\tv217 = System.Math::Floor(v366);\nL_00CC:\n\tv406 = 0x1854ED0(&v244 @ stack_-58_v3 (System.Double), v55.method, isRelative, methodInfo, v35, v36, v37, v38, v101, v389, v41, v42, v113, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]));\n\tv418 = v101 >= 0;\n\tif (v418) goto L_00F1;\n\tv429 = v101 != -0.5d;\n\tif (v429) goto L_0103;\n\tgoto L_00F6;\nL_00F1:\n\tv440 = v101 != 0.5d;\n\tif (v440) goto L_0106;\nL_00F6:\n\tv470 = v459 + v449;\n\tv462 = v459 & 1;\n\tv464 = v462 == 0;\n\tv467 = ~v464;\n\tif (v467) goto L_FFFFFFFF;\n\tgoto L_0102;\nL_0102:\n\tgoto L_010B;\nL_0103:\n\tv443 = v101 + -0.5d;\n\tv216 = System.Math::Ceiling(v443);\n\tgoto L_010B;\nL_0106:\n\tv447 = v101 + 0.5d;\n\tv216 = System.Math::Floor(v447);\nL_010B:\n\tv235 = 0x1854ED0(&v244 @ stack_-58_v3 (System.Double), v55.method, isRelative, methodInfo, v35, v36, v37, v38, v99, v470, v41, v42, v113, *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]), *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]));\n\tv497 = v99 >= 0;\n\tif (v497) goto L_0130;\n\tv508 = v99 != -0.5d;\n\tif (v508) goto L_0142;\n\tgoto L_0135;\nL_0130:\n\tv519 = v99 != 0.5d;\n\tif (v519) goto L_0145;\nL_0135:\n\tv540 = v234 + v528;\n\tv541 = v234 & 1;\n\tv543 = v541 == 0;\n\tv546 = ~v543;\n\tif (v546) goto L_FFFFFFFF;\n\tgoto L_0141;\nL_0141:\n\tgoto L_FFFFFFFF;\nL_0142:\n\tv522 = v99 + -0.5d;\n\tv234 = System.Math::Ceiling(v522);\n\tgoto L_FFFFFFFF;\nL_0145:\n\tv526 = v99 + 0.5d;\n\tv234 = System.Math::Floor(v526);\nL_014B:\n\tv128 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::Invoke(t.setter, v128.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, bool isRelative)
		{
			//IL_0127: Expected F8, but got I
			//IL_0137: Expected F8, but got I
			//IL_0147: Expected F8, but got I
			//IL_00fb: Expected O, but got F4
			//IL_064a: Expected O, but got I
			//IL_0685: Unknown result type (might be due to invalid IL or missing references)
			//IL_068a: Expected I4, but got Unknown
			//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d4: Expected I4, but got Unknown
			//IL_0719: Unknown result type (might be due to invalid IL or missing references)
			//IL_071e: Expected I4, but got Unknown
			//IL_0763: Unknown result type (might be due to invalid IL or missing references)
			//IL_0768: Expected I4, but got Unknown
			DOGetter<Rect> getter = t.getter;
			object obj = t.getter();
			t.endValue = t.endValue;
			t.startValue = t.endValue;
			double num4;
			double num3;
			double num2;
			double num5;
			if (isRelative)
			{
				Rect startValue = t.startValue;
				float num = t.startValue.m_XMin + t.endValue.m_XMin;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]");
				object obj2 = default(object);
				num2 = 0.0 + (double)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]");
				object obj3 = default(object);
				num3 = 0.0 + (double)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]");
				object obj4 = default(object);
				num4 = 0.0 + (double)obj4;
				t.startValue = (Rect)num;
				num5 = num;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]");
				num2 = 0.0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]");
				num3 = 0.0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]");
				num4 = 0.0;
				num5 = t.startValue.m_XMin;
				Rect startValue = t.endValue;
			}
			double num6;
			double num10 = default(double);
			if ((object)t.plugOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
				double num8;
				double num9;
				double num7;
				if (num5 < 0.0)
				{
					if (num5 != -0.5)
					{
						double a = num5 + -0.5;
						num6 = Math.Ceiling(a);
						num7 = -0.5;
						goto IL_02a0;
					}
					num8 = -1.0;
					num9 = num10;
				}
				else
				{
					if (num5 != 0.5)
					{
						double d = num5 + 0.5;
						num6 = Math.Floor(d);
						num7 = 0.5;
						goto IL_02a0;
					}
					num8 = 1.0;
					num9 = num10;
				}
				num7 = num9 + num8;
				num6 = (((num9 & 1) != 0) ? num7 : num9);
				goto IL_02a0;
			}
			goto IL_0795;
			IL_03d0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num11;
			double num13;
			double num14;
			double num12;
			if (num3 < 0.0)
			{
				if (num3 != -0.5)
				{
					double a2 = num3 + -0.5;
					num11 = Math.Ceiling(a2);
					num12 = -0.5;
					goto IL_0500;
				}
				num13 = -1.0;
				num14 = num10;
			}
			else
			{
				if (num3 != 0.5)
				{
					double d2 = num3 + 0.5;
					num11 = Math.Floor(d2);
					num12 = 0.5;
					goto IL_0500;
				}
				num13 = 1.0;
				num14 = num10;
			}
			num12 = num14 + num13;
			num11 = (((num14 & 1) != 0) ? num12 : num14);
			goto IL_0500;
			IL_0500:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num15;
			double num16;
			if (num4 < 0.0)
			{
				if (num4 != -0.5)
				{
					double a3 = num4 + -0.5;
					num15 = Math.Ceiling(a3);
					goto IL_060e;
				}
				num16 = -1.0;
				num15 = num10;
			}
			else
			{
				if (num4 != 0.5)
				{
					double d3 = num4 + 0.5;
					num15 = Math.Floor(d3);
					goto IL_060e;
				}
				num16 = 1.0;
				num15 = num10;
			}
			double num17 = num15 + num16;
			if ((num15 & 1) != 0)
			{
				num15 = num17;
			}
			goto IL_060e;
			IL_060e:
			num4 = num15;
			num3 = num11;
			double num18;
			num2 = num18;
			num5 = num6;
			goto IL_0795;
			IL_02a0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num20;
			double num21;
			double num19;
			if (num2 < 0.0)
			{
				if (num2 != -0.5)
				{
					double a4 = num2 + -0.5;
					num18 = Math.Ceiling(a4);
					num19 = -0.5;
					goto IL_03d0;
				}
				num20 = -1.0;
				num21 = num10;
			}
			else
			{
				if (num2 != 0.5)
				{
					double d4 = num2 + 0.5;
					num18 = Math.Floor(d4);
					num19 = 0.5;
					goto IL_03d0;
				}
				num20 = 1.0;
				num21 = num10;
			}
			num19 = num21 + num20;
			num18 = (((num21 & 1) != 0) ? num19 : num21);
			goto IL_03d0;
			IL_0795:
			DOSetter<Rect> setter = t.setter;
			t.setter((Rect)(nint)setter.method);
		}

		[Token(Token = "0x6000327")]
		[Address(RVA = "0xC23608", Offset = "0xC23608", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv44 = System.Math;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, t, setImmediately, isRelative, methodInfo, v47, v48, v49, fromValue, v0, v2, v3, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A35779]) = v57;\nL_0023:\n\tv59 = isRelative == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv62 = t.getter;\n\tv147 = DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>::Invoke(t.getter);\n\tv150 = fromValue + fromValue;\n\tv139 = t.endValue + fromValue;\n\tv128 = fromValue.m_YMin + fromValue.m_YMin;\n\tv130 = fromValue.m_Width + fromValue.m_Width;\n\tt.endValue = v139;\n\tv132 = fromValue.m_Height + fromValue.m_Height;\n\tgoto L_003C;\nL_003C:\n\tt.startValue = v126;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]) = v128;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+12C]) = v130;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]) = v132;\n\tv160 = setImmediately == 0;\n\tif (v160) goto L_0079;\n\tv166 = t.plugOptions == 0;\n\tif (v166) goto L_015C;\n\tgoto L_0051;\n\tv266 = \"il2cpp_codegen_runtime_class_init\"(v237, v117, setImmediately, isRelative, methodInfo, v47, v48, v49, v138, v0, v2, v3, v115, v51, v52, v53);\nL_0051:\n\tv272 = 0x1854ED0(&v270 @ stack_-68_v3 (System.Double), v117, setImmediately, isRelative, methodInfo, v47, v48, v49, v126, fromValue.m_YMin, fromValue.m_Width, fromValue.m_Height, t.endValue, v51, v52, v53);\n\tv282 = v126 >= 0;\n\tif (v282) goto L_0084;\n\tv293 = v126 != -0.5d;\n\tif (v293) goto L_0096;\n\tgoto L_0089;\nL_0079:\n\treturn;\nL_0084:\n\tv304 = v126 != 0.5d;\n\tif (v304) goto L_0099;\nL_0089:\n\tv346 = v322 + v323;\n\tv326 = v322 & 1;\n\tv328 = v326 == 0;\n\tv331 = ~v328;\n\tif (v331) goto L_FFFFFFFF;\n\tgoto L_0095;\nL_0095:\n\tgoto L_009E;\nL_0096:\n\tv307 = v126 + -0.5d;\n\tv254 = System.Math::Ceiling(v307);\n\tgoto L_009E;\nL_0099:\n\tv311 = v126 + 0.5d;\n\tv254 = System.Math::Floor(v311);\nL_009E:\n\tv351 = 0x1854ED0(&v270 @ stack_-68_v3 (System.Double), v117, setImmediately, isRelative, methodInfo, v47, v48, v49, v128, v346, fromValue.m_Width, fromValue.m_Height, t.endValue, v51, v52, v53);\n\tv363 = v128 >= 0;\n\tif (v363) goto L_00C3;\n\tv374 = v128 != -0.5d;\n\tif (v374) goto L_00D5;\n\tgoto L_00C8;\nL_00C3:\n\tv385 = v128 != 0.5d;\n\tif (v385) goto L_00D8;\nL_00C8:\n\tv427 = v403 + v404;\n\tv407 = v403 & 1;\n\tv409 = v407 == 0;\n\tv412 = ~v409;\n\tif (v412) goto L_FFFFFFFF;\n\tgoto L_00D4;\nL_00D4:\n\tgoto L_00DD;\nL_00D5:\n\tv388 = v128 + -0.5d;\n\tv243 = System.Math::Ceiling(v388);\n\tgoto L_00DD;\nL_00D8:\n\tv392 = v128 + 0.5d;\n\tv243 = System.Math::Floor(v392);\nL_00DD:\n\tv432 = 0x1854ED0(&v270 @ stack_-68_v3 (System.Double), v117, setImmediately, isRelative, methodInfo, v47, v48, v49, v130, v427, fromValue.m_Width, fromValue.m_Height, t.endValue, v51, v52, v53);\n\tv444 = v130 >= 0;\n\tif (v444) goto L_0102;\n\tv455 = v130 != -0.5d;\n\tif (v455) goto L_0114;\n\tgoto L_0107;\nL_0102:\n\tv466 = v130 != 0.5d;\n\tif (v466) goto L_0117;\nL_0107:\n\tv508 = v484 + v485;\n\tv488 = v484 & 1;\n\tv490 = v488 == 0;\n\tv493 = ~v490;\n\tif (v493) goto L_FFFFFFFF;\n\tgoto L_0113;\nL_0113:\n\tgoto L_011C;\nL_0114:\n\tv469 = v130 + -0.5d;\n\tv242 = System.Math::Ceiling(v469);\n\tgoto L_011C;\nL_0117:\n\tv473 = v130 + 0.5d;\n\tv242 = System.Math::Floor(v473);\nL_011C:\n\tv256 = 0x1854ED0(&v270 @ stack_-68_v3 (System.Double), v117, setImmediately, isRelative, methodInfo, v47, v48, v49, v132, v508, fromValue.m_Width, fromValue.m_Height, t.endValue, v51, v52, v53);\n\tv523 = v132 >= 0;\n\tif (v523) goto L_0141;\n\tv534 = v132 != -0.5d;\n\tif (v534) goto L_0153;\n\tgoto L_0146;\nL_0141:\n\tv545 = v132 != 0.5d;\n\tif (v545) goto L_0156;\nL_0146:\n\tv566 = v255 + v564;\n\tv567 = v255 & 1;\n\tv569 = v567 == 0;\n\tv572 = ~v569;\n\tif (v572) goto L_FFFFFFFF;\n\tgoto L_0152;\nL_0152:\n\tgoto L_FFFFFFFF;\nL_0153:\n\tv548 = v132 + -0.5d;\n\tv255 = System.Math::Ceiling(v548);\n\tgoto L_FFFFFFFF;\nL_0156:\n\tv552 = v132 + 0.5d;\n\tv255 = System.Math::Floor(v552);\nL_015C:\n\tv134 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::Invoke(t.setter, v134.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 263 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, Rect fromValue, bool setImmediately, bool isRelative)
		{
			//IL_009f: Expected O, but got F4
			//IL_00c5: Expected O, but got I
			//IL_00cd: Expected O, but got F4
			//IL_0652: Expected O, but got I
			//IL_069a: Unknown result type (might be due to invalid IL or missing references)
			//IL_069f: Expected I4, but got Unknown
			//IL_06e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e9: Expected I4, but got Unknown
			//IL_072e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0733: Expected I4, but got Unknown
			//IL_061e: Expected O, but got F8
			//IL_0778: Unknown result type (might be due to invalid IL or missing references)
			//IL_077d: Expected I4, but got Unknown
			Rect startValue;
			float num3;
			float num4;
			float num5;
			if (isRelative)
			{
				DOGetter<Rect> getter = t.getter;
				object obj = t.getter();
				Rect rect = default(Rect);
				float num = rect.m_XMin + rect.m_XMin;
				float num2 = t.endValue.m_XMin + rect.m_XMin;
				num3 = fromValue.m_YMin + fromValue.m_YMin;
				num4 = fromValue.m_Width + fromValue.m_Width;
				t.endValue = (Rect)num2;
				num5 = fromValue.m_Height + fromValue.m_Height;
				TweenerCore<Rect, Rect, RectOptions> tweenerCore = (TweenerCore<Rect, Rect, RectOptions>)(nint)getter.method;
				startValue = (Rect)num;
			}
			else
			{
				TweenerCore<Rect, Rect, RectOptions> tweenerCore = t;
				startValue = fromValue;
				num3 = fromValue.m_YMin;
				num4 = fromValue.m_Width;
				num5 = fromValue.m_Height;
			}
			t.startValue = startValue;
			if (!setImmediately)
			{
				return;
			}
			double num6;
			double num9 = default(double);
			if ((object)t.plugOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
				double num8;
				double num10;
				double num7;
				if (startValue.m_XMin < 0f)
				{
					if ((double)startValue.m_XMin != -0.5)
					{
						double a = (double)startValue.m_XMin + -0.5;
						num6 = Math.Ceiling(a);
						num7 = -0.5;
						goto IL_02b4;
					}
					num8 = num9;
					num10 = -1.0;
				}
				else
				{
					if ((double)startValue.m_XMin != 0.5)
					{
						double d = (double)startValue.m_XMin + 0.5;
						num6 = Math.Floor(d);
						num7 = 0.5;
						goto IL_02b4;
					}
					num8 = num9;
					num10 = 1.0;
				}
				num7 = num8 + num10;
				num6 = (((num8 & 1) != 0) ? num7 : num8);
				goto IL_02b4;
			}
			goto IL_0670;
			IL_050c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num11;
			double num12;
			if (num5 < 0f)
			{
				if ((double)num5 != -0.5)
				{
					double a2 = (double)num5 + -0.5;
					num11 = Math.Ceiling(a2);
					goto IL_0616;
				}
				num11 = num9;
				num12 = -1.0;
			}
			else
			{
				if ((double)num5 != 0.5)
				{
					double d2 = (double)num5 + 0.5;
					num11 = Math.Floor(d2);
					goto IL_0616;
				}
				num11 = num9;
				num12 = 1.0;
			}
			double num13 = num11 + num12;
			if ((num11 & 1) != 0)
			{
				num11 = num13;
			}
			goto IL_0616;
			IL_0616:
			startValue = (Rect)num6;
			double num14;
			num3 = (float)num14;
			double num15;
			num4 = (float)num15;
			num5 = (float)num11;
			goto IL_0670;
			IL_0670:
			DOSetter<Rect> setter = t.setter;
			t.setter((Rect)(nint)setter.method);
			return;
			IL_03e0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num17;
			double num18;
			double num16;
			if (num4 < 0f)
			{
				if ((double)num4 != -0.5)
				{
					double a3 = (double)num4 + -0.5;
					num15 = Math.Ceiling(a3);
					num16 = -0.5;
					goto IL_050c;
				}
				num17 = num9;
				num18 = -1.0;
			}
			else
			{
				if ((double)num4 != 0.5)
				{
					double d3 = (double)num4 + 0.5;
					num15 = Math.Floor(d3);
					num16 = 0.5;
					goto IL_050c;
				}
				num17 = num9;
				num18 = 1.0;
			}
			num16 = num17 + num18;
			num15 = (((num17 & 1) != 0) ? num16 : num17);
			goto IL_050c;
			IL_02b4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num20;
			double num21;
			double num19;
			if (num3 < 0f)
			{
				if ((double)num3 != -0.5)
				{
					double a4 = (double)num3 + -0.5;
					num14 = Math.Ceiling(a4);
					num19 = -0.5;
					goto IL_03e0;
				}
				num20 = num9;
				num21 = -1.0;
			}
			else
			{
				if ((double)num3 != 0.5)
				{
					double d4 = (double)num3 + 0.5;
					num14 = Math.Floor(d4);
					num19 = 0.5;
					goto IL_03e0;
				}
				num20 = num9;
				num21 = 1.0;
			}
			num19 = num20 + num21;
			num14 = (((num20 & 1) != 0) ? num19 : num20);
			goto IL_03e0;
		}

		[Token(Token = "0x6000328")]
		[Address(RVA = "0xC2391C", Offset = "0xC2391C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Rect ConvertToStartValue(TweenerCore<Rect, Rect, RectOptions> t, Rect value)
		{
			return value;
		}

		[Token(Token = "0x6000329")]
		[Address(RVA = "0xC23920", Offset = "0xC23920", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue + t.startValue;\n\tt.endValue = v7;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Rect, Rect, RectOptions> t)
		{
			//IL_0030: Expected O, but got F4
			float num = t.endValue.m_XMin + t.startValue.m_XMin;
			t.endValue = (Rect)num;
		}

		[Token(Token = "0x600032A")]
		[Address(RVA = "0xC23944", Offset = "0xC23944", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue - t.startValue;\n\tt.changeValue = v7;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Rect, Rect, RectOptions> t)
		{
			//IL_0030: Expected O, but got F4
			float num = t.endValue.m_XMin - t.startValue.m_XMin;
			t.changeValue = (Rect)num;
		}

		[Token(Token = "0x600032B")]
		[Address(RVA = "0xC23968", Offset = "0xC23968", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = System.Math;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, options, methodInfo, v32, v33, v34, v35, v36, unitsXSecond, changeValue, v0, v2, v3, v37, v38, v39);\n\tv43 = 1;\n\t*([1A3577A]) = v43;\nL_001E:\n\tgoto L_0020;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, options, methodInfo, v32, v33, v34, v35, v36, unitsXSecond, changeValue, v0, v2, v3, v37, v38, v39);\nL_0020:\n\tv50 = changeValue.m_Width * changeValue.m_Width;\n\tv51 = changeValue.m_Height * changeValue.m_Height;\n\tv52 = v50 + v51;\n\tv53 = UnityEngine.Mathf::Sqrt(v52);\n\treturnVal1 = v53 / unitsXSecond;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(RectOptions options, float unitsXSecond, Rect changeValue)
		{
			float num = changeValue.m_Width * changeValue.m_Width;
			float num2 = changeValue.m_Height * changeValue.m_Height;
			float f = num + num2;
			float num3 = Mathf.Sqrt(f);
			return num3 / unitsXSecond;
		}

		[Token(Token = "0x600032C")]
		[Address(RVA = "0xC239E4", Offset = "0xC239E4", Length = "0x3B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv195 = startValue.m_Height;\n\tgoto L_0048;\n\tv56 = System.Math;\n\tv57 = v45;\n\tv58 = v31;\n\tv59 = v44;\n\tv60 = v43;\n\tv61 = v41;\n\tv62 = v36;\n\tv63 = v32;\n\tv64 = v38;\n\tv65 = elapsed;\n\tv67 = v34;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, options, t, isRelative, getter, setter, usingInversePosition, newCompletedSteps, elapsed, v34, v0, v2, v3, duration, v74, v75);\n\tv99 = v67;\n\tv77 = v65;\n\tv95 = v64;\n\tv101 = v63;\n\tv97 = v62;\n\tv91 = v61;\n\tv89 = v60;\n\tv87 = v59;\n\tv85 = v57;\n\tv103 = v58;\n\tv93 = 1;\n\t*([1A3577B]) = v93;\nL_0048:\n\tv115 = t.loopType != 2;\n\tif (v115) goto L_0058;\n\tv206 = t.completedLoops - t.isComplete;\n\tv128 = changeValue * v206;\n\tv209 = v39 * v206;\n\tv210 = updateNotice * v206;\n\tv195 = v33 * v206;\n\tv259 = startValue + v128;\n\tv251 = v251 + v209;\n\tv253 = v253 + v210;\n\tv255 = v255 + v195;\nL_0058:\n\tv218 = ~t.isSequenced;\n\tif (v218) goto L_008A;\n\tv134 = t.sequenceParent;\n\tv225 = v134.loopType != 2;\n\tif (v225) goto L_008A;\n\tv224 = t.loopType != 2;\n\tif (v224) goto L_FFFFFFFF;\n\tv376 = t.loops;\n\tgoto L_007A;\nL_007A:\n\tv222 = v134.completedLoops - v134.isComplete;\n\tv258 = v222 * v376;\n\tv128 = changeValue * v258;\n\tv265 = v39 * v258;\n\tv263 = updateNotice * v258;\n\tv195 = v33 * v258;\n\tv259 = v259 + v128;\n\tv251 = v251 + v265;\n\tv253 = v253 + v263;\n\tv255 = v255 + v195;\nL_008A:\n\tv269 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, v76, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv328 = changeValue * v269;\n\tv201 = v39 * v269;\n\tv198 = updateNotice * v269;\n\tv329 = v33 * v269;\n\tv192 = v259 + v328;\n\tv173 = v251 + v201;\n\tv176 = v253 + v198;\n\tv179 = v255 + v329;\n\tv334 = options & 1;\n\tv335 = v334 == 0;\n\tif (v335) goto L_01B5;\n\tgoto L_00A1;\n\tv369 = \"il2cpp_codegen_runtime_class_init\"(v339, v120, v122, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v329, v328, v201, v198, v195, v128, v74, v75);\nL_00A1:\n\tv375 = 0x1854ED0(&v373 @ stack_-28_v3 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v192, v328, v201, v198, v195, v128, v74, v75);\n\tv389 = v192 >= 0;\n\tif (v389) goto L_00C6;\n\tv400 = v192 != -0.5d;\n\tif (v400) goto L_00D8;\n\tgoto L_00CB;\nL_00C6:\n\tv411 = v192 != 0.5d;\n\tif (v411) goto L_00DB;\nL_00CB:\n\tv452 = v429 + v430;\n\tv433 = v429 & 1;\n\tv435 = v433 == 0;\n\tv438 = ~v435;\n\tif (v438) goto L_FFFFFFFF;\n\tgoto L_00D7;\nL_00D7:\n\tgoto L_00E0;\nL_00D8:\n\tv414 = v192 + -0.5d;\n\tv365 = System.Math::Ceiling(v414);\n\tgoto L_00E0;\nL_00DB:\n\tv418 = v192 + 0.5d;\n\tv365 = System.Math::Floor(v418);\nL_00E0:\n\tv458 = 0x1854ED0(&v373 @ stack_-28_v3 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v173, v452, v201, v198, v195, v128, v74, v75);\n\tv470 = v173 >= 0;\n\tif (v470) goto L_0105;\n\tv481 = v173 != -0.5d;\n\tif (v481) goto L_0117;\n\tgoto L_010A;\nL_0105:\n\tv492 = v173 != 0.5d;\n\tif (v492) goto L_011A;\nL_010A:\n\tv534 = v510 + v511;\n\tv514 = v510 & 1;\n\tv516 = v514 == 0;\n\tv519 = ~v516;\n\tif (v519) goto L_FFFFFFFF;\n\tgoto L_0116;\nL_0116:\n\tgoto L_011F;\nL_0117:\n\tv495 = v173 + -0.5d;\n\tv361 = System.Math::Ceiling(v495);\n\tgoto L_011F;\nL_011A:\n\tv499 = v173 + 0.5d;\n\tv361 = System.Math::Floor(v499);\nL_011F:\n\tv539 = 0x1854ED0(&v373 @ stack_-28_v3 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v176, v534, v201, v198, v195, v128, v74, v75);\n\tv551 = v176 >= 0;\n\tif (v551) goto L_0144;\n\tv562 = v176 != -0.5d;\n\tif (v562) goto L_0156;\n\tgoto L_0149;\nL_0144:\n\tv573 = v176 != 0.5d;\n\tif (v573) goto L_0159;\nL_0149:\n\tv615 = v591 + v592;\n\tv595 = v591 & 1;\n\tv597 = v595 == 0;\n\tv600 = ~v597;\n\tif (v600) goto L_FFFFFFFF;\n\tgoto L_0155;\nL_0155:\n\tgoto L_015E;\nL_0156:\n\tv576 = v176 + -0.5d;\n\tv363 = System.Math::Ceiling(v576);\n\tgoto L_015E;\nL_0159:\n\tv580 = v176 + 0.5d;\n\tv363 = System.Math::Floor(v580);\nL_015E:\n\tv355 = 0x1854ED0(&v373 @ stack_-28_v3 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v179, v615, v201, v198, v195, v128, v74, v75);\n\tv630 = v179 >= 0;\n\tif (v630) goto L_0183;\n\tv641 = v179 != -0.5d;\n\tif (v641) goto L_0195;\n\tgoto L_0188;\nL_0183:\n\tv652 = v179 != 0.5d;\n\tif (v652) goto L_0198;\nL_0188:\n\tv673 = v354 + v671;\n\tv674 = v354 & 1;\n\tv676 = v674 == 0;\n\tv679 = ~v676;\n\tif (v679) goto L_FFFFFFFF;\n\tgoto L_0194;\nL_0194:\n\tgoto L_FFFFFFFF;\nL_0195:\n\tv655 = v179 + -0.5d;\n\tv354 = System.Math::Ceiling(v655);\n\tgoto L_FFFFFFFF;\nL_0198:\n\tv659 = v179 + 0.5d;\n\tv354 = System.Math::Floor(v659);\nL_01B5:\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::Invoke(setter, setter.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 287 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(RectOptions options, Tween t, bool isRelative, DOGetter<Rect> getter, DOSetter<Rect> setter, float elapsed, Rect startValue, Rect changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_069f: Expected F4, but got I
			//IL_0729: Unknown result type (might be due to invalid IL or missing references)
			//IL_072e: Expected I4, but got Unknown
			//IL_00a5: Expected O, but got I
			//IL_064f: Expected O, but got I
			//IL_0792: Expected O, but got I
			//IL_0809: Unknown result type (might be due to invalid IL or missing references)
			//IL_080e: Expected I4, but got Unknown
			//IL_0853: Unknown result type (might be due to invalid IL or missing references)
			//IL_0858: Expected I4, but got Unknown
			//IL_089d: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a2: Expected I4, but got Unknown
			//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ec: Expected I4, but got Unknown
			float height = startValue.m_Height;
			float num = startValue.m_YMin;
			float num2 = startValue.m_Width;
			float num3 = startValue.m_Height;
			bool flag = t.loopType != LoopType.Incremental;
			Rect rect = default(Rect);
			float num4 = rect.m_XMin;
			Rect rect2 = default(Rect);
			object obj2 = default(object);
			object obj3 = default(object);
			if (!flag)
			{
				int num5 = t.completedLoops - (t.isComplete ? 1 : 0);
				float num6 = rect2.m_XMin * (float)num5;
				object obj = (nint)obj2 * num5;
				int num7 = (int)updateNotice * num5;
				height = (float)obj3 * (float)num5;
				num4 = rect.m_XMin + num6;
				num += (float)obj;
				num2 += (float)num7;
				num3 += height;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num8 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					int num9 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					int num10 = num9 * num8;
					float num6 = rect2.m_XMin * (float)num10;
					object obj4 = (nint)obj2 * num10;
					int num11 = (int)updateNotice * num10;
					height = (float)obj3 * (float)num10;
					num4 += num6;
					num += (float)obj4;
					num2 += (float)num11;
					num3 += height;
				}
			}
			float time = default(float);
			IntPtr intPtr = default(IntPtr);
			float num12 = EaseManager.Evaluate(t.easeType, t.customEase, time, (nint)intPtr, t.easeOvershootOrAmplitude, t.easePeriod);
			float num13 = rect2.m_XMin * num12;
			float num14 = (float)obj2 * num12;
			float num15 = (float)updateNotice * num12;
			float num16 = (float)obj3 * num12;
			float num17 = num4 + num13;
			float num18 = num + num14;
			float num19 = num2 + num15;
			float num20 = num3 + num16;
			double num21;
			double num24 = default(double);
			if ((options & 1) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
				double num23;
				double num25;
				double num22;
				if (num17 < 0f)
				{
					if ((double)num17 != -0.5)
					{
						double a = (double)num17 + -0.5;
						num21 = Math.Ceiling(a);
						num22 = -0.5;
						goto IL_02b6;
					}
					num23 = num24;
					num25 = -1.0;
				}
				else
				{
					if ((double)num17 != 0.5)
					{
						double d = (double)num17 + 0.5;
						num21 = Math.Floor(d);
						num22 = 0.5;
						goto IL_02b6;
					}
					num23 = num24;
					num25 = 1.0;
				}
				num22 = num23 + num25;
				num21 = (((num23 & 1) != 0) ? num22 : num23);
				goto IL_02b6;
			}
			goto IL_063d;
			IL_0618:
			double num26;
			num18 = (float)num26;
			double num27;
			num19 = (float)num27;
			double num28;
			num20 = (float)num28;
			num17 = (float)num21;
			goto IL_063d;
			IL_050e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num29;
			if (num20 < 0f)
			{
				if ((double)num20 != -0.5)
				{
					double a2 = (double)num20 + -0.5;
					num28 = Math.Ceiling(a2);
					goto IL_0618;
				}
				num28 = num24;
				num29 = -1.0;
			}
			else
			{
				if ((double)num20 != 0.5)
				{
					double d2 = (double)num20 + 0.5;
					num28 = Math.Floor(d2);
					goto IL_0618;
				}
				num28 = num24;
				num29 = 1.0;
			}
			double num30 = num28 + num29;
			if ((num28 & 1) != 0)
			{
				num28 = num30;
			}
			goto IL_0618;
			IL_02b6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num32;
			double num33;
			double num31;
			if (num18 < 0f)
			{
				if ((double)num18 != -0.5)
				{
					double a3 = (double)num18 + -0.5;
					num26 = Math.Ceiling(a3);
					num31 = -0.5;
					goto IL_03e2;
				}
				num32 = num24;
				num33 = -1.0;
			}
			else
			{
				if ((double)num18 != 0.5)
				{
					double d3 = (double)num18 + 0.5;
					num26 = Math.Floor(d3);
					num31 = 0.5;
					goto IL_03e2;
				}
				num32 = num24;
				num33 = 1.0;
			}
			num31 = num32 + num33;
			num26 = (((num32 & 1) != 0) ? num31 : num32);
			goto IL_03e2;
			IL_063d:
			setter((Rect)(nint)setter.method);
			return;
			IL_03e2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num35;
			double num36;
			double num34;
			if (num19 < 0f)
			{
				if ((double)num19 != -0.5)
				{
					double a4 = (double)num19 + -0.5;
					num27 = Math.Ceiling(a4);
					num34 = -0.5;
					goto IL_050e;
				}
				num35 = num24;
				num36 = -1.0;
			}
			else
			{
				if ((double)num19 != 0.5)
				{
					double d4 = (double)num19 + 0.5;
					num27 = Math.Floor(d4);
					num34 = 0.5;
					goto IL_050e;
				}
				num35 = num24;
				num36 = 1.0;
			}
			num34 = num35 + num36;
			num27 = (((num35 & 1) != 0) ? num34 : num35);
			goto IL_050e;
		}

		[Token(Token = "0x600032D")]
		[Address(RVA = "0xC23D98", Offset = "0xC23D98", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3577C]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectPlugin()
		{
		}
	}
}
