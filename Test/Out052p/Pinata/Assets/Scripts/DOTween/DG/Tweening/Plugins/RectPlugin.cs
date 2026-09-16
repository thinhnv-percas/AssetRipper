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
	[Token(Token = "0x2000027")]
	public class RectPlugin : ABSTweenPlugin<Rect, Rect, RectOptions>
	{
		[Token(Token = "0x60001DC")]
		[Address(RVA = "0x10DB344", Offset = "0x10DB344", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Rect, Rect, RectOptions> t)
		{
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0x10DB348", Offset = "0x10DB348", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv32 = *([1EAAA98]);\n\tv33 = *([v32 @ X8_v25]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, t, isRelative, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0 | 1;\n\t*([20274C6]) = v51;\nL_0022:\n\tv138 = t.endValue;\n\tv128 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]);\n\tv126 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+134]);\n\tv124 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+138]);\n\tv149 = DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>::Invoke(t.getter);\n\tt.endValue = v149;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]) = v149.m_YMin;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+134]) = v149.m_Width;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+138]) = v149.m_Height;\n\tt.startValue = t.endValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+120]) = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+124]) = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+134]);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]) = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+138]);\n\tv142 = isRelative == 0;\n\tif (v142) goto L_006E;\n\tv143 = t + 0x11C;\n\tv146 = 0x10CCFB4(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v149, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv214 = t + 0x12C;\n\tv218 = 0x10CCFB4(v214, 0, isRelative, methodInfo, v36, v37, v38, v39, v149, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv245 = v149 + v149;\n\tv248 = 0x10CCFBC(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v245, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv259 = 0x10CCFC4(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v245, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv275 = 0x10CCFC4(v214, 0, isRelative, methodInfo, v36, v37, v38, v39, v245, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv286 = v245 + v245;\n\tv289 = 0x10CCFCC(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v286, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv314 = 0x10CD178(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v286, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv326 = 0x10CD178(v214, 0, isRelative, methodInfo, v36, v37, v38, v39, v286, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv366 = v286 + v286;\n\tv369 = 0x10CD180(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v366, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv378 = 0x10CD188(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v366, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv387 = 0x10CD188(v214, 0, isRelative, methodInfo, v36, v37, v38, v39, v366, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv150 = v366 + v366;\n\tv157 = 0x10CD190(v143, 0, isRelative, methodInfo, v36, v37, v38, v39, v150, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv138 = t.startValue;\n\tv128 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+120]);\n\tv126 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+124]);\n\tv124 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]);\nL_006E:\n\tv161 = t.plugOptions == 0;\n\tif (v161) goto L_01A2;\n\tv222 = 0x10CCFB4(&v110 @ stack_-68_v4 (UnityEngine.Rect), 0, isRelative, methodInfo, v36, v37, v38, v39, v149, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tgoto L_0083;\n\tv260 = *([v252 @ X0_v11+E0]);\n\tv261 = v260 == 0;\n\tv262 = ~v261;\n\tif (v262) goto L_0083;\n\tv264 = \"il2cpp_codegen_runtime_class_init\"(v252, v221, isRelative, methodInfo, v36, v37, v38, v39, v149, v140, v116, v114, v44, v45, v46, v47);\nL_0083:\n\tv271 = 0x6D1ED0(&v269 @ stack_-58_v3 (System.Double), 0, isRelative, methodInfo, v36, v37, v38, v39, v149, v149.m_YMin, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv285 = v149 >= 0;\n\tif (v285) goto L_00A8;\n\tv300 = v149 != -0.5d;\n\tif (v300) goto L_00BA;\n\tgoto L_00AD;\nL_00A8:\n\tv311 = v149 != 0.5d;\n\tif (v311) goto L_00BD;\nL_00AD:\n\tv356 = v357 + v336;\n\tv340 = v357 & 1;\n\tv342 = v340 == 0;\n\tv345 = ~v342;\n\tif (v345) goto L_FFFFFFFF;\n\tgoto L_00B9;\nL_00B9:\n\tgoto L_00C2;\nL_00BA:\n\tv317 = v149 + -0.5d;\n\tv357 = System.Math::Ceiling(v317);\n\tgoto L_00C2;\nL_00BD:\n\tv321 = v149 + 0.5d;\n\tv357 = System.Math::Floor(v321);\nL_00C2:\n\tv365 = 0x10CCFBC(&v110 @ stack_-68_v4 (UnityEngine.Rect), 0, isRelative, methodInfo, v36, v37, v38, v39, v357, v356, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv375 = 0x10CCFC4(&v110 @ stack_-68_v4 (UnityEngine.Rect), 0, isRelative, methodInfo, v36, v37, v38, v39, v357, v356, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv384 = 0x6D1ED0(&v269 @ stack_-58_v3 (System.Double), 0, isRelative, methodInfo, v36, v37, v38, v39, v357, v356, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv397 = v357 >= 0;\n\tif (v397) goto L_00EF;\n\tv409 = v357 != -0.5d;\n\tif (v409) goto L_0101;\n\tgoto L_00F4;\nL_00EF:\n\tv420 = v357 != 0.5d;\n\tif (v420) goto L_0104;\nL_00F4:\n\tv458 = v459 + v438;\n\tv442 = v459 & 1;\n\tv444 = v442 == 0;\n\tv447 = ~v444;\n\tif (v447) goto L_FFFFFFFF;\n\tgoto L_0100;\nL_0100:\n\tgoto L_0109;\nL_0101:\n\tv423 = v357 + -0.5d;\n\tv459 = System.Math::Ceiling(v423);\n\tgoto L_0109;\nL_0104:\n\tv427 = v357 + 0.5d;\n\tv459 = System.Math::Floor(v427);\nL_0109:\n\tv467 = 0x10CCFCC(&v110 @ stack_-68_v4 (UnityEngine.Rect), 0, isRelative, methodInfo, v36, v37, v38, v39, v459, v458, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv473 = 0x10CD178(&v110 @ stack_-68_v4 (UnityEngine.Rect), 0, isRelative, methodInfo, v36, v37, v38, v39, v459, v458, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv479 = 0x6D1ED0(&v269 @ stack_-58_v3 (System.Double), 0, isRelative, methodInfo, v36, v37, v38, v39, v459, v458, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv489 = v459 >= 0;\n\tif (v489) goto L_0136;\n\tv500 = v459 != -0.5d;\n\tif (v500) goto L_0148;\n\tgoto L_013B;\nL_0136:\n\tv511 = v459 != 0.5d;\n\tif (v511) goto L_014B;\nL_013B:\n\tv549 = v550 + v529;\n\tv533 = v550 & 1;\n\tv535 = v533 == 0;\n\tv538 = ~v535;\n\tif (v538) goto L_FFFFFFFF;\n\tgoto L_0147;\nL_0147:\n\tgoto L_0150;\nL_0148:\n\tv514 = v459 + -0.5d;\n\tv550 = System.Math::Ceiling(v514);\n\tgoto L_0150;\nL_014B:\n\tv518 = v459 + 0.5d;\n\tv550 = System.Math::Floor(v518);\nL_0150:\n\tv558 = 0x10CD180(&v110 @ stack_-68_v4 (UnityEngine.Rect), 0, isRelative, methodInfo, v36, v37, v38, v39, v550, v549, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv564 = 0x10CD188(&v110 @ stack_-68_v4 (UnityEngine.Rect), 0, isRelative, methodInfo, v36, v37, v38, v39, v550, v549, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv567 = 0x6D1ED0(&v269 @ stack_-58_v3 (System.Double), 0, isRelative, methodInfo, v36, v37, v38, v39, v550, v549, v149.m_Width, v149.m_Height, v44, v45, v46, v47);\n\tv577 = v550 >= 0;\n\tif (v577) goto L_017D;\n\tv588 = v550 != -0.5d;\n\tif (v588) goto L_018F;\n\tgoto L_0182;\nL_017D:\n\tv599 = v550 != 0.5d;\n\tif (v599) goto L_0192;\nL_0182:\n\tv237 = v627 + v617;\n\tv621 = v627 & 1;\n\tv623 = v621 == 0;\n\tv626 = ~v623;\n\tif (v626) goto L_FFFFFFFF;\n\tgoto L_018E;\nL_018E:\n\tgoto L_0197;\nL_018F:\n\tv602 = v550 + -0.\n// ... truncated")]
		public override void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, bool isRelative)
		{
			//IL_0022: Expected O, but got I
			//IL_0032: Expected O, but got I
			//IL_0042: Expected O, but got I
			//IL_0756: Expected F4, but got O
			//IL_0763: Expected F4, but got O
			//IL_0770: Expected F4, but got O
			//IL_00e4: Expected O, but got I
			//IL_00fd: Expected O, but got I
			//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ca: Expected I4, but got Unknown
			//IL_01ec: Expected O, but got I
			//IL_01fc: Expected O, but got I
			//IL_020c: Expected O, but got I
			//IL_0214: Expected O, but got F4
			//IL_080f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0814: Expected I4, but got Unknown
			//IL_0859: Unknown result type (might be due to invalid IL or missing references)
			//IL_085e: Expected I4, but got Unknown
			//IL_08a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a8: Expected I4, but got Unknown
			Rect rect = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+134]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+138]");
			object obj3 = 0;
			Rect rect2 = (t.endValue = t.getter());
			_ = rect2.y;
			_ = rect2.width;
			_ = rect2.height;
			t.startValue = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+130]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+134]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+138]");
			_ = 0;
			if (isRelative)
			{
				object obj4 = (long)(IntPtr)t + 284L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				object obj5 = (long)(IntPtr)t + 300L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				float num = rect2.x + rect2.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				float num2 = num + num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				float num3 = num2 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				float num4 = num3 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
				rect = t.startValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+120]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+124]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]");
				obj3 = 0;
				rect2 = (Rect)num4;
			}
			bool flag = (object)t.plugOptions == null;
			Rect rect3 = rect;
			double num5;
			double num8 = default(double);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num7;
				double num6;
				if (rect2.x < 0f)
				{
					if ((double)rect2.x != -0.5)
					{
						double a = (double)rect2.x + -0.5;
						num5 = Math.Ceiling(a);
						num6 = -0.5;
						goto IL_0365;
					}
					num7 = -1.0;
					num5 = num8;
				}
				else
				{
					if ((double)rect2.x != 0.5)
					{
						double d = (double)rect2.x + 0.5;
						num5 = Math.Floor(d);
						num6 = 0.5;
						goto IL_0365;
					}
					num7 = 1.0;
					num5 = num8;
				}
				num6 = num5 + num7;
				if ((num5 & 1) != 0)
				{
					num5 = num6;
				}
				goto IL_0365;
			}
			goto IL_0737;
			IL_0365:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num9;
			double num11;
			double num10;
			if (num5 < 0.0)
			{
				if (num5 != -0.5)
				{
					double a2 = num5 + -0.5;
					num9 = Math.Ceiling(a2);
					num10 = -0.5;
					goto IL_04a6;
				}
				num11 = -1.0;
				num9 = num8;
			}
			else
			{
				if (num5 != 0.5)
				{
					double d2 = num5 + 0.5;
					num9 = Math.Floor(d2);
					num10 = 0.5;
					goto IL_04a6;
				}
				num11 = 1.0;
				num9 = num8;
			}
			num10 = num9 + num11;
			if ((num9 & 1) != 0)
			{
				num9 = num10;
			}
			goto IL_04a6;
			IL_0737:
			Rect pNewValue = default(Rect);
			pNewValue.x = rect.x;
			pNewValue.y = (float)obj;
			pNewValue.width = (float)obj2;
			pNewValue.height = (float)obj3;
			t.setter(pNewValue);
			return;
			IL_04a6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num12;
			double num14;
			double num13;
			if (num9 < 0.0)
			{
				if (num9 != -0.5)
				{
					double a3 = num9 + -0.5;
					num12 = Math.Ceiling(a3);
					num13 = -0.5;
					goto IL_05e7;
				}
				num14 = -1.0;
				num12 = num8;
			}
			else
			{
				if (num9 != 0.5)
				{
					double d3 = num9 + 0.5;
					num12 = Math.Floor(d3);
					num13 = 0.5;
					goto IL_05e7;
				}
				num14 = 1.0;
				num12 = num8;
			}
			num13 = num12 + num14;
			if ((num12 & 1) != 0)
			{
				num12 = num13;
			}
			goto IL_05e7;
			IL_05e7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num17;
			double num16;
			double num15;
			if (num12 < 0.0)
			{
				if (num12 != -0.5)
				{
					double a4 = num12 + -0.5;
					num15 = Math.Ceiling(a4);
					num16 = -0.5;
					goto IL_0728;
				}
				num17 = -1.0;
				num15 = num8;
			}
			else
			{
				if (num12 != 0.5)
				{
					double d4 = num12 + 0.5;
					num15 = Math.Floor(d4);
					num16 = 0.5;
					goto IL_0728;
				}
				num17 = 1.0;
				num15 = num8;
			}
			num16 = num15 + num17;
			if ((num15 & 1) != 0)
			{
				num15 = num16;
			}
			goto IL_0728;
			IL_0728:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			goto IL_0737;
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0x10DB750", Offset = "0x10DB750", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_0024;\n\tv38 = *([1F02F68]);\n\tv39 = *([v38 @ X8_v24]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, setImmediately, methodInfo, v42, v43, v44, v45, fromValue, v0, v2, v3, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([20274C7]) = v53;\nL_0024:\n\tt.startValue = fromValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+120]) = fromValue.m_YMin;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+124]) = fromValue.m_Width;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+128]) = fromValue.m_Height;\n\tv58 = setImmediately == 0;\n\tif (v58) goto L_0170;\n\tv65 = t.plugOptions == 0;\n\tif (v65) goto L_0164;\n\tv165 = 0x10CCFB4(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, fromValue, fromValue.m_YMin, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tgoto L_0043;\n\tv227 = *([v222 @ X0_v10+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0043;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v222, v164, setImmediately, methodInfo, v42, v43, v44, v45, fromValue, v0, v2, v3, v46, v47, v48, v49);\nL_0043:\n\tv235 = &v23 @ stack_-10_v2 - 0x18;\n\tv237 = 0x6D1ED0(v235, 0, setImmediately, methodInfo, v42, v43, v44, v45, fromValue, fromValue.m_YMin, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv247 = fromValue >= 0;\n\tif (v247) goto L_006A;\n\tv258 = fromValue != -0.5d;\n\tif (v258) goto L_007C;\n\tv307 = *([v22 @ X29_v1-18]);\n\tgoto L_006F;\nL_006A:\n\tv269 = fromValue != 0.5d;\n\tif (v269) goto L_007F;\n\tv307 = *([v22 @ X29_v1-18]);\nL_006F:\n\tv311 = v307 + v288;\n\tv291 = v307 & 1;\n\tv293 = v291 == 0;\n\tv296 = ~v293;\n\tif (v296) goto L_FFFFFFFF;\n\tgoto L_007B;\nL_007B:\n\tgoto L_0084;\nL_007C:\n\tv272 = fromValue + -0.5d;\n\tv307 = System.Math::Ceiling(v272);\n\tgoto L_0084;\nL_007F:\n\tv276 = fromValue + 0.5d;\n\tv307 = System.Math::Floor(v276);\nL_0084:\n\tv316 = 0x10CCFBC(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, v307, v311, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv322 = 0x10CCFC4(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, v307, v311, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv325 = &v23 @ stack_-10_v2 - 0x18;\n\tv327 = 0x6D1ED0(v325, 0, setImmediately, methodInfo, v42, v43, v44, v45, v307, v311, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv337 = v307 >= 0;\n\tif (v337) goto L_00B1;\n\tv348 = v307 != -0.5d;\n\tif (v348) goto L_00C3;\n\tv397 = *([v22 @ X29_v1-18]);\n\tgoto L_00B6;\nL_00B1:\n\tv359 = v307 != 0.5d;\n\tif (v359) goto L_00C6;\n\tv397 = *([v22 @ X29_v1-18]);\nL_00B6:\n\tv401 = v397 + v378;\n\tv381 = v397 & 1;\n\tv383 = v381 == 0;\n\tv386 = ~v383;\n\tif (v386) goto L_FFFFFFFF;\n\tgoto L_00C2;\nL_00C2:\n\tgoto L_00CB;\nL_00C3:\n\tv362 = v307 + -0.5d;\n\tv397 = System.Math::Ceiling(v362);\n\tgoto L_00CB;\nL_00C6:\n\tv366 = v307 + 0.5d;\n\tv397 = System.Math::Floor(v366);\nL_00CB:\n\tv406 = 0x10CCFCC(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, v397, v401, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv412 = 0x10CD178(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, v397, v401, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv415 = &v23 @ stack_-10_v2 - 0x18;\n\tv417 = 0x6D1ED0(v415, 0, setImmediately, methodInfo, v42, v43, v44, v45, v397, v401, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv427 = v397 >= 0;\n\tif (v427) goto L_00F8;\n\tv438 = v397 != -0.5d;\n\tif (v438) goto L_010A;\n\tv487 = *([v22 @ X29_v1-18]);\n\tgoto L_00FD;\nL_00F8:\n\tv449 = v397 != 0.5d;\n\tif (v449) goto L_010D;\n\tv487 = *([v22 @ X29_v1-18]);\nL_00FD:\n\tv491 = v487 + v468;\n\tv471 = v487 & 1;\n\tv473 = v471 == 0;\n\tv476 = ~v473;\n\tif (v476) goto L_FFFFFFFF;\n\tgoto L_0109;\nL_0109:\n\tgoto L_0112;\nL_010A:\n\tv452 = v397 + -0.5d;\n\tv487 = System.Math::Ceiling(v452);\n\tgoto L_0112;\nL_010D:\n\tv456 = v397 + 0.5d;\n\tv487 = System.Math::Floor(v456);\nL_0112:\n\tv496 = 0x10CD180(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, v487, v491, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv502 = 0x10CD188(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, v487, v491, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv503 = &v23 @ stack_-10_v2 - 0x18;\n\tv505 = 0x6D1ED0(v503, 0, setImmediately, methodInfo, v42, v43, v44, v45, v487, v491, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\n\tv515 = v487 >= 0;\n\tif (v515) goto L_013F;\n\tv526 = v487 != -0.5d;\n\tif (v526) goto L_0151;\n\tv565 = *([v22 @ X29_v1-18]);\n\tgoto L_0144;\nL_013F:\n\tv537 = v487 != 0.5d;\n\tif (v537) goto L_0154;\n\tv565 = *([v22 @ X29_v1-18]);\nL_0144:\n\tv186 = v565 + v556;\n\tv559 = v565 & 1;\n\tv561 = v559 == 0;\n\tv564 = ~v561;\n\tif (v564) goto L_FFFFFFFF;\n\tgoto L_0150;\nL_0150:\n\tgoto L_0159;\nL_0151:\n\tv540 = v487 + -0.5d;\n\tv565 = System.Math::Ceiling(v540);\n\tgoto L_0159;\nL_0154:\n\tv544 = v487 + 0.5d;\n\tv565 = System.Math::Floor(v544);\nL_0159:\n\tv180 = 0x10CD190(&v109 @ stack_-60_v5 (UnityEngine.Rect), 0, setImmediately, methodInfo, v42, v43, v44, v45, v565, v186, fromValue.m_Width, fromValue.m_Height, v46, v47, v48, v49);\nL_0164:\n\t// 356 MakeStruct v70 @ AGG10DBA40_1_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), fromValue @ V0 (UnityEngine.Rect), fromValue.m_YMin (System.Single), fromValue.m_Width (System.Single), fromValue.m_Height (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::Invoke(t.setter, v70);\nL_0170:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 246 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, Rect fromValue, bool setImmediately)
		{
			//IL_009d: Expected O, but got I
			//IL_0156: Expected F8, but got I
			//IL_0212: Expected O, but got I
			//IL_0691: Unknown result type (might be due to invalid IL or missing references)
			//IL_0696: Expected I4, but got Unknown
			//IL_0109: Expected F8, but got I
			//IL_02c0: Expected F8, but got I
			//IL_0372: Expected O, but got I
			//IL_06db: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e0: Expected I4, but got Unknown
			//IL_0278: Expected F8, but got I
			//IL_0420: Expected F8, but got I
			//IL_04d2: Expected O, but got I
			//IL_0725: Unknown result type (might be due to invalid IL or missing references)
			//IL_072a: Expected I4, but got Unknown
			//IL_03d8: Expected F8, but got I
			//IL_0580: Expected F8, but got I
			//IL_076f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0774: Expected I4, but got Unknown
			//IL_0538: Expected F8, but got I
			object obj2 = default(object);
			object obj = obj2;
			t.startValue = fromValue;
			_ = fromValue.y;
			_ = fromValue.width;
			_ = fromValue.height;
			if (!setImmediately)
			{
				return;
			}
			bool flag = (object)t.plugOptions == null;
			Rect rect = fromValue;
			Rect rect2 = default(Rect);
			double num;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				object obj3 = (long)(IntPtr)obj2 - 24L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num3;
				double num2;
				if (rect2.x < 0f)
				{
					if ((double)rect2.x != -0.5)
					{
						double a = (double)rect2.x + -0.5;
						num = Math.Ceiling(a);
						num2 = -0.5;
						goto IL_01ea;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
					num = 0.0;
					num3 = -1.0;
				}
				else
				{
					if ((double)rect2.x != 0.5)
					{
						double d = (double)rect2.x + 0.5;
						num = Math.Floor(d);
						num2 = 0.5;
						goto IL_01ea;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
					num = 0.0;
					num3 = 1.0;
				}
				num2 = num + num3;
				if ((num & 1) != 0)
				{
					num = num2;
				}
				goto IL_01ea;
			}
			goto IL_0619;
			IL_01ea:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			object obj4 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num4;
			double num6;
			double num5;
			if (num < 0.0)
			{
				if (num != -0.5)
				{
					double a2 = num + -0.5;
					num4 = Math.Ceiling(a2);
					num5 = -0.5;
					goto IL_034a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num4 = 0.0;
				num6 = -1.0;
			}
			else
			{
				if (num != 0.5)
				{
					double d2 = num + 0.5;
					num4 = Math.Floor(d2);
					num5 = 0.5;
					goto IL_034a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num4 = 0.0;
				num6 = 1.0;
			}
			num5 = num4 + num6;
			if ((num4 & 1) != 0)
			{
				num4 = num5;
			}
			goto IL_034a;
			IL_034a:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			object obj5 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num7;
			double num9;
			double num8;
			if (num4 < 0.0)
			{
				if (num4 != -0.5)
				{
					double a3 = num4 + -0.5;
					num7 = Math.Ceiling(a3);
					num8 = -0.5;
					goto IL_04aa;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num7 = 0.0;
				num9 = -1.0;
			}
			else
			{
				if (num4 != 0.5)
				{
					double d3 = num4 + 0.5;
					num7 = Math.Floor(d3);
					num8 = 0.5;
					goto IL_04aa;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num7 = 0.0;
				num9 = 1.0;
			}
			num8 = num7 + num9;
			if ((num7 & 1) != 0)
			{
				num7 = num8;
			}
			goto IL_04aa;
			IL_04aa:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			object obj6 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num12;
			double num11;
			double num10;
			if (num7 < 0.0)
			{
				if (num7 != -0.5)
				{
					double a4 = num7 + -0.5;
					num10 = Math.Ceiling(a4);
					num11 = -0.5;
					goto IL_060a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num10 = 0.0;
				num12 = -1.0;
			}
			else
			{
				if (num7 != 0.5)
				{
					double d4 = num7 + 0.5;
					num10 = Math.Floor(d4);
					num11 = 0.5;
					goto IL_060a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-18]");
				num10 = 0.0;
				num12 = 1.0;
			}
			num11 = num10 + num12;
			if ((num10 & 1) != 0)
			{
				num10 = num11;
			}
			goto IL_060a;
			IL_060a:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			goto IL_0619;
			IL_0619:
			Rect pNewValue = default(Rect);
			pNewValue.x = rect2.x;
			pNewValue.y = fromValue.y;
			pNewValue.width = fromValue.width;
			pNewValue.height = fromValue.height;
			t.setter(pNewValue);
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0x10DBA68", Offset = "0x10DBA68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Rect ConvertToStartValue(TweenerCore<Rect, Rect, RectOptions> t, Rect value)
		{
			return value;
		}

		[Token(Token = "0x60001E0")]
		[Address(RVA = "0x10DBA6C", Offset = "0x10DBA6C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = t + 0x12C;\n\tv18 = 0x10CCFB4(v15, 0, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = t + 0x11C;\n\tv39 = 0x10CCFB4(v35, 0, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = v25 + v25;\n\tv43 = 0x10CCFBC(v15, 0, methodInfo, v20, v21, v22, v23, v24, v40, v26, v27, v28, v29, v30, v31, v32);\n\tv62 = 0x10CCFC4(v15, 0, methodInfo, v20, v21, v22, v23, v24, v40, v26, v27, v28, v29, v30, v31, v32);\n\tv66 = 0x10CCFC4(v35, 0, methodInfo, v20, v21, v22, v23, v24, v40, v26, v27, v28, v29, v30, v31, v32);\n\tv67 = v40 + v40;\n\tv70 = 0x10CCFCC(v15, 0, methodInfo, v20, v21, v22, v23, v24, v67, v26, v27, v28, v29, v30, v31, v32);\n\tv73 = 0x10CD178(v15, 0, methodInfo, v20, v21, v22, v23, v24, v67, v26, v27, v28, v29, v30, v31, v32);\n\tv77 = 0x10CD178(v35, 0, methodInfo, v20, v21, v22, v23, v24, v67, v26, v27, v28, v29, v30, v31, v32);\n\tv78 = v67 + v67;\n\tv81 = 0x10CD180(v15, 0, methodInfo, v20, v21, v22, v23, v24, v78, v26, v27, v28, v29, v30, v31, v32);\n\tv84 = 0x10CD188(v15, 0, methodInfo, v20, v21, v22, v23, v24, v78, v26, v27, v28, v29, v30, v31, v32);\n\tv88 = 0x10CD188(v35, 0, methodInfo, v20, v21, v22, v23, v24, v78, v26, v27, v28, v29, v30, v31, v32);\n\tv47 = v78 + v78;\n\tv53 = 0x10CD190(v15, 0, methodInfo, v20, v21, v22, v23, v24, v47, v26, v27, v28, v29, v30, v31, v32);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Rect, Rect, RectOptions> t)
		{
			//IL_000f: Expected O, but got I
			//IL_0028: Expected O, but got I
			//IL_0046: Expected O, but got I
			//IL_0078: Expected O, but got I
			//IL_00af: Expected O, but got I
			//IL_00e1: Expected O, but got I
			object obj = (long)(IntPtr)t + 300L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			object obj2 = (long)(IntPtr)t + 284L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			object obj4 = default(object);
			object obj3 = (long)(IntPtr)obj4 + (long)(IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			object obj5 = (long)(IntPtr)obj3 + (long)(IntPtr)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			object obj6 = (long)(IntPtr)obj5 + (long)(IntPtr)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			object obj7 = (long)(IntPtr)obj6 + (long)(IntPtr)obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
		}

		[Token(Token = "0x60001E1")]
		[Address(RVA = "0x10DBB50", Offset = "0x10DBB50", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = t + 0x12C;\n\tv32 = 0x10CCFB4(v29, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = t + 0x11C;\n\tv53 = 0x10CCFB4(v49, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv57 = 0x10CCFC4(v29, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv114 = 0x10CCFC4(v49, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv118 = 0x10CD178(v29, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv122 = 0x10CD178(v49, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv126 = 0x10CD188(v29, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv130 = 0x10CD188(v49, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv84 = v39 - v39;\n\tv82 = v39 - v39;\n\tv80 = v39 - v39;\n\tv78 = v39 - v39;\n\tv73 = 0;\n\tv104 = 0x10CCF64(&v73 @ stack_-70_v1 (UnityEngine.Rect), 0, methodInfo, v34, v35, v36, v37, v38, v84, v82, v80, v78, v84, v44, v45, v46);\n\tt.changeValue = 0;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+140]) = v132;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>)+148]) = v133;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Rect, Rect, RectOptions> t)
		{
			//IL_000f: Expected O, but got I
			//IL_0028: Expected O, but got I
			//IL_0091: Expected O, but got I
			//IL_00a0: Expected O, but got I
			//IL_00af: Expected O, but got I
			//IL_00be: Expected O, but got I
			object obj = (long)(IntPtr)t + 300L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			object obj2 = (long)(IntPtr)t + 284L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			object obj4 = default(object);
			object obj3 = (long)(IntPtr)obj4 - (long)(IntPtr)obj4;
			object obj5 = (long)(IntPtr)obj4 - (long)(IntPtr)obj4;
			object obj6 = (long)(IntPtr)obj4 - (long)(IntPtr)obj4;
			object obj7 = (long)(IntPtr)obj4 - (long)(IntPtr)obj4;
			Rect rect = default(Rect);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			t.changeValue = default(Rect);
		}

		[Token(Token = "0x60001E2")]
		[Address(RVA = "0x10DBC68", Offset = "0x10DBC68", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EF14D0]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, options, methodInfo, v35, v36, v37, v38, v39, unitsXSecond, changeValue, v0, v2, v3, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([20274C8]) = v46;\nL_001E:\n\tv49 = 0x10CD178(&changeValue @ V1 (UnityEngine.Rect), 0, methodInfo, v35, v36, v37, v38, v39, unitsXSecond, changeValue, changeValue.m_YMin, changeValue.m_Width, changeValue.m_Height, v40, v41, v42);\n\tv53 = 0x10CD188(&changeValue @ V1 (UnityEngine.Rect), 0, methodInfo, v35, v36, v37, v38, v39, unitsXSecond, changeValue, changeValue.m_YMin, changeValue.m_Width, changeValue.m_Height, v40, v41, v42);\n\tgoto L_0030;\n\tv61 = *([v57 @ X0_v6 (Il2CppClass<System.Math>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0030;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, v51, methodInfo, v35, v36, v37, v38, v39, unitsXSecond, changeValue, v0, v2, v3, v40, v41, v42);\nL_0030:\n\tv68 = unitsXSecond * unitsXSecond;\n\tv69 = unitsXSecond * unitsXSecond;\n\tv70 = v68 + v69;\n\tv84 = UnityEngine.Mathf::Sqrt(v70);\n\tv74 = v84 - v84;\n\tv77 = v84 ^ v84;\n\tv78 = v84 ^ v74;\n\tv79 = v77 & v78;\n\tv80 = v79 < 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0041;\n\tv83 = 0x6D2F50(System.Math, 0, methodInfo, v35, v36, v37, v38, v39, v70, v70, changeValue.m_YMin, changeValue.m_Width, changeValue.m_Height, v40, v41, v42);\nL_0041:\n\treturnVal1 = v84 / unitsXSecond;\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(RectOptions options, float unitsXSecond, Rect changeValue)
		{
			//IL_005b: Expected O, but got F4
			//IL_0068: Expected O, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			float num = unitsXSecond * unitsXSecond;
			float num2 = unitsXSecond * unitsXSecond;
			float num3 = num + num2;
			float num4 = Mathf.Sqrt(num3);
			float num5 = num4 - num4;
			object obj = num4 ^ num4;
			object obj2 = num4 ^ num5;
			int num6 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			if (num6 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
				num4 = num3;
			}
			return num4 / unitsXSecond;
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0x10DBD2C", Offset = "0x10DBD2C", Length = "0x5D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tv139 = *([v22 @ X29_v1+1C]);\n\tv29 = *([v22 @ X29_v1+10]);\n\tgoto L_0036;\n\tv50 = *([1EB86C8]);\n\tv51 = *([v50 @ X8_v32]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v28, startValue, v0, v2, v3, v27, v30, v29);\n\tv60 = 0 | 1;\n\t*([20274C9]) = v60;\nL_0036:\n\tv72 = t.loopType != 2;\n\tif (v72) goto L_006E;\n\tv158 = t.completedLoops - t.isComplete;\n\tv159 = 0x10CCFB4(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, *([v22 @ X29_v1+1C]), startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv172 = 0x10CCFB4(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, *([v22 @ X29_v1+1C]), startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv274 = *([v22 @ X29_v1+1C]) * v158;\n\tv275 = *([v22 @ X29_v1+1C]) + v274;\n\tv279 = 0x10CCFBC(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v275, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv289 = 0x10CCFC4(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v275, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv299 = 0x10CCFC4(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v275, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv308 = v275 * v158;\n\tv309 = v275 + v308;\n\tv313 = 0x10CCFCC(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v309, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv327 = 0x10CD178(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v309, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv339 = 0x10CD178(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v309, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv352 = v309 * v158;\n\tv353 = v309 + v352;\n\tv357 = 0x10CD180(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v353, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv369 = 0x10CD188(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v353, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv380 = 0x10CD188(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v353, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv393 = v353 * v158;\n\tv139 = v353 + v393;\n\tv163 = 0x10CD190(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v139, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\nL_006E:\n\tv168 = ~t.isSequenced;\n\tif (v168) goto L_00CB;\n\tv136 = t.sequenceParent;\n\tv183 = v136.loopType != 2;\n\tif (v183) goto L_00CB;\n\tv182 = t.loopType != 2;\n\tif (v182) goto L_FFFFFFFF;\n\tv179 = t.loops;\n\tgoto L_0093;\nL_0093:\n\tv214 = v136.completedLoops - v136.isComplete;\n\tv217 = v214 * v179;\n\tv319 = 0x10CCFB4(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v139, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv331 = 0x10CCFB4(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v139, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv340 = v139 * v217;\n\tv341 = v139 + v340;\n\tv345 = 0x10CCFBC(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v341, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv361 = 0x10CCFC4(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v341, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv373 = 0x10CCFC4(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v341, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv381 = v341 * v217;\n\tv382 = v341 + v381;\n\tv386 = 0x10CCFCC(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v382, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv398 = 0x10CD178(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v382, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv406 = 0x10CD178(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v382, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv411 = v382 * v217;\n\tv412 = v382 + v411;\n\tv416 = 0x10CD180(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v412, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv426 = 0x10CD188(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v412, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv431 = 0x10CD188(&v29 @ V7_v1, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v412, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv457 = v412 * v217;\n\tv216 = v412 + v457;\n\tv209 = 0x10CD190(&v155 @ stack_-60_v30, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v216, startValue, startValue.m_YMin, startValue.m_Width, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\nL_00CB:\n\tv222 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, *([v22 @ X29_v1+20]), t.easeOvershootOrAmplitude, t.easePeriod);\n\tv285 = 0x10CCFB4(&v155 @ stack_-60_v30, 0, 0, isRelative, getter, setter, usingInversePosition, updateNotice, v222, *([v22 @ X29_v1+20]), t.easeOvershootOrAmplitude, t.easePeriod, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv295 = 0x10CCFB4(&v29 @ V7_v1, 0, 0, isRelative, getter, setter, usingInversePosition, updateNotice, v222, *([v22 @ X29_v1+20]), t.easeOvershootOrAmplitude, t.easePeriod, startValue.m_Height, *([v22 @ X29_v1+18]), *([v22 @ X29_v1+14]), *([v22 @ X29_v1+10]));\n\tv302 = v222 * v222;\n\tv303 = v222 + v302;\n\tv307 = 0x10CCFBC(&v155 @ stack_-60_v30, 0, 0, isRelative, getter, setter, usingInversePosition, updateNotice, v303, *([v22 @ X29_v1+20]), t.easeOvershootOrAmplitude, \n// ... truncated")]
		public override void EvaluateAndApply(RectOptions options, Tween t, bool isRelative, DOGetter<Rect> getter, DOSetter<Rect> setter, float elapsed, Rect startValue, Rect changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_0018: Expected O, but got I
			//IL_0028: Expected O, but got I
			//IL_031e: Expected F4, but got I
			//IL_0097: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_0123: Expected O, but got I
			//IL_0132: Expected O, but got I
			//IL_0163: Expected O, but got I
			//IL_0172: Expected O, but got I
			//IL_0439: Unknown result type (might be due to invalid IL or missing references)
			//IL_043e: Expected I4, but got Unknown
			//IL_09f7: Expected O, but got I
			//IL_0a06: Expected O, but got I
			//IL_096d: Expected F4, but got O
			//IL_0242: Expected O, but got I
			//IL_0251: Expected O, but got I
			//IL_0282: Expected O, but got I
			//IL_0291: Expected O, but got I
			//IL_02c7: Expected O, but got I
			//IL_02d6: Expected O, but got I
			//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a32: Expected I4, but got Unknown
			//IL_0a77: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a7c: Expected I4, but got Unknown
			//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ac6: Expected I4, but got Unknown
			//IL_0b0b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b10: Expected I4, but got Unknown
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+1C]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+10]");
			object obj4 = 0;
			if (t.loopType == LoopType.Incremental)
			{
				int num = t.completedLoops - (t.isComplete ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+1C]");
				object obj5 = 0L * (long)num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+1C]");
				object obj6 = 0L + (long)(IntPtr)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				object obj7 = (long)(IntPtr)obj6 * (long)num;
				object obj8 = (long)(IntPtr)obj6 + (long)(IntPtr)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				object obj9 = (long)(IntPtr)obj8 * (long)num;
				object obj10 = (long)(IntPtr)obj8 + (long)(IntPtr)obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				object obj11 = (long)(IntPtr)obj10 * (long)num;
				obj3 = (long)(IntPtr)obj10 + (long)(IntPtr)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num2 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					int num3 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					int num4 = num3 * num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
					object obj12 = (long)(IntPtr)obj3 * (long)num4;
					object obj13 = (long)(IntPtr)obj3 + (long)(IntPtr)obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
					object obj14 = (long)(IntPtr)obj13 * (long)num4;
					object obj15 = (long)(IntPtr)obj13 + (long)(IntPtr)obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
					object obj16 = (long)(IntPtr)obj15 * (long)num4;
					object obj17 = (long)(IntPtr)obj15 + (long)(IntPtr)obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
					object obj18 = (long)(IntPtr)obj17 * (long)num4;
					object obj19 = (long)(IntPtr)obj17 + (long)(IntPtr)obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
				}
			}
			Ease easeType = t.easeType;
			EaseFunction customEase = t.customEase;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+20]");
			float num5 = EaseManager.Evaluate(easeType, customEase, elapsed, 0f, t.easeOvershootOrAmplitude, t.easePeriod);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			float num6 = num5 * num5;
			float num7 = num5 + num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			float num8 = num5 * num7;
			float num9 = num7 + num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			float num10 = num5 * num9;
			float num11 = num9 + num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			float num12 = num5 * num11;
			float num13 = num11 + num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			double num14;
			double num17 = default(double);
			if ((options & 0xFF) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num16;
				double num15;
				if (num13 < 0f)
				{
					if ((double)num13 != -0.5)
					{
						double a = (double)num13 + -0.5;
						num14 = Math.Ceiling(a);
						num15 = -0.5;
						goto IL_058e;
					}
					num16 = -1.0;
					num14 = num17;
				}
				else
				{
					if ((double)num13 != 0.5)
					{
						double d = (double)num13 + 0.5;
						num14 = Math.Floor(d);
						num15 = 0.5;
						goto IL_058e;
					}
					num16 = 1.0;
					num14 = num17;
				}
				num15 = num14 + num16;
				if ((num14 & 1) != 0)
				{
					num14 = num15;
				}
				goto IL_058e;
			}
			goto IL_0960;
			IL_0951:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			goto IL_0960;
			IL_0960:
			Rect pNewValue = default(Rect);
			object obj20 = default(object);
			pNewValue.x = (float)obj20;
			pNewValue.y = startValue.y;
			pNewValue.width = startValue.width;
			pNewValue.height = startValue.height;
			setter(pNewValue);
			return;
			IL_06cf:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num18;
			double num19;
			double num21;
			double num20;
			if (num18 < 0.0)
			{
				if (num18 != -0.5)
				{
					double a2 = num18 + -0.5;
					num19 = Math.Ceiling(a2);
					num20 = -0.5;
					goto IL_0810;
				}
				num21 = -1.0;
				num19 = num17;
			}
			else
			{
				if (num18 != 0.5)
				{
					double d2 = num18 + 0.5;
					num19 = Math.Floor(d2);
					num20 = 0.5;
					goto IL_0810;
				}
				num21 = 1.0;
				num19 = num17;
			}
			num20 = num19 + num21;
			if ((num19 & 1) != 0)
			{
				num19 = num20;
			}
			goto IL_0810;
			IL_0810:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num24;
			double num23;
			double num22;
			if (num19 < 0.0)
			{
				if (num19 != -0.5)
				{
					double a3 = num19 + -0.5;
					num22 = Math.Ceiling(a3);
					num23 = -0.5;
					goto IL_0951;
				}
				num24 = -1.0;
				num22 = num17;
			}
			else
			{
				if (num19 != 0.5)
				{
					double d3 = num19 + 0.5;
					num22 = Math.Floor(d3);
					num23 = 0.5;
					goto IL_0951;
				}
				num24 = 1.0;
				num22 = num17;
			}
			num23 = num22 + num24;
			if ((num22 & 1) != 0)
			{
				num22 = num23;
			}
			goto IL_0951;
			IL_058e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num26;
			double num25;
			if (num14 < 0.0)
			{
				if (num14 != -0.5)
				{
					double a4 = num14 + -0.5;
					num18 = Math.Ceiling(a4);
					num25 = -0.5;
					goto IL_06cf;
				}
				num26 = -1.0;
				num18 = num17;
			}
			else
			{
				if (num14 != 0.5)
				{
					double d4 = num14 + 0.5;
					num18 = Math.Floor(d4);
					num25 = 0.5;
					goto IL_06cf;
				}
				num26 = 1.0;
				num18 = num17;
			}
			num25 = num18 + num26;
			if ((num18 & 1) != 0)
			{
				num18 = num25;
			}
			goto IL_06cf;
		}

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0x10DC300", Offset = "0x10DC300", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB4B38]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274CA]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectPlugin()
		{
		}
	}
}
