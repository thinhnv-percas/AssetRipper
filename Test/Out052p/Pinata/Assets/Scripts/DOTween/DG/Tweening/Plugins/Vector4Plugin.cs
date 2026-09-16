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
	[Token(Token = "0x200002A")]
	public class Vector4Plugin : ABSTweenPlugin<Vector4, Vector4, VectorOptions>
	{
		[Token(Token = "0x60001F7")]
		[Address(RVA = "0x10E0734", Offset = "0x10E0734", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector4, Vector4, VectorOptions> t)
		{
		}

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0x10E0738", Offset = "0x10E0738", Length = "0x3A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_0023;\n\tv38 = *([1ED91B8]);\n\tv39 = *([v38 @ X8_v32]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, isRelative, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 0 | 1;\n\t*([20274EE]) = v57;\nL_0023:\n\tv138 = t.endValue;\n\tv357 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]);\n\tv134 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]);\n\tv337 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]);\n\tv69 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tv176 = v69.y;\n\tv125 = v69.z;\n\tv123 = v69.w;\n\tt.endValue = v69;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]) = v69.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]) = v69.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]) = v69.w;\n\tv154 = isRelative == 0;\n\tif (v154) goto L_005C;\n\tgoto L_004F;\n\tv266 = *([v157 @ X0_v20+E0]);\n\tv267 = v266 == 0;\n\tv268 = ~v267;\n\tif (v268) goto L_004F;\n\tv270 = \"il2cpp_codegen_runtime_class_init\"(v157, v68, isRelative, methodInfo, v42, v43, v44, v45, v69, v146, v147, v148, v50, v51, v52, v53);\nL_004F:\n\tv179 = UnityEngine.Vector4::op_Addition(v69, t.endValue);\n\tv176 = v179.y;\n\tv125 = v179.z;\n\tv123 = v179.w;\n\tv172 = t.endValue;\n\tv119 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]);\n\tv169 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]);\n\tv167 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]);\nL_005C:\n\tt.startValue = v138;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+120]) = v357;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+124]) = v134;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+128]) = v337;\n\tv206 = t.plugOptions <= 4;\n\tif (v206) goto L_008A;\n\tv279 = t.plugOptions == 8;\n\tif (v279) goto L_FFFFFFFF;\n\tv302 = t.plugOptions != 0x10;\n\tif (v302) goto L_00A4;\n\tgoto L_00A4;\nL_008A:\n\tv288 = t.plugOptions == 2;\n\tif (v288) goto L_FFFFFFFF;\n\tv314 = t.plugOptions != 4;\n\tif (v314) goto L_00A4;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_00A4:\n\tv346 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+150]) == 0;\n\tif (v346) goto L_01CA;\n\tgoto L_00B3;\n\tv390 = *([v362 @ X0_v9+E0]);\n\tv391 = v390 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_00B3;\n\tv394 = \"il2cpp_codegen_runtime_class_init\"(v362, v68, isRelative, methodInfo, v42, v43, v44, v45, v178, v176, v125, v123, v113, v111, v109, v107);\nL_00B3:\n\tv398 = &v27 @ stack_-10_v2 - 0x18;\n\tv400 = 0x6D1ED0(v398, Il2CppMethodInfo, isRelative, methodInfo, v42, v43, v44, v45, v138, v176, v125, v123, v138, v357, v134, v337);\n\tv411 = v138 >= 0;\n\tif (v411) goto L_00DA;\n\tv422 = v138 != -0.5d;\n\tif (v422) goto L_00EC;\n\tv452 = *([v26 @ X29_v1-18]);\n\tgoto L_00DF;\nL_00DA:\n\tv433 = v138 != 0.5d;\n\tif (v433) goto L_00EF;\n\tv452 = *([v26 @ X29_v1-18]);\nL_00DF:\n\tv472 = v452 + v451;\n\tv455 = v452 & 1;\n\tv457 = v455 == 0;\n\tv460 = ~v457;\n\tif (v460) goto L_FFFFFFFF;\n\tgoto L_00EB;\nL_00EB:\n\tgoto L_00F2;\nL_00EC:\n\tv436 = v138 + -0.5d;\n\tv377 = System.Math::Ceiling(v436);\n\tgoto L_00F2;\nL_00EF:\n\tv440 = v138 + 0.5d;\n\tv377 = System.Math::Floor(v440);\nL_00F2:\n\tv477 = &v27 @ stack_-10_v2 - 0x18;\n\tv479 = 0x6D1ED0(v477, Il2CppMethodInfo, isRelative, methodInfo, v42, v43, v44, v45, v357, v472, v125, v123, v138, v357, v134, v337);\n\tv491 = v357 >= 0;\n\tif (v491) goto L_0119;\n\tv502 = v357 != -0.5d;\n\tif (v502) goto L_012B;\n\tv532 = *([v26 @ X29_v1-18]);\n\tgoto L_011E;\nL_0119:\n\tv513 = v357 != 0.5d;\n\tif (v513) goto L_012E;\n\tv532 = *([v26 @ X29_v1-18]);\nL_011E:\n\tv552 = v532 + v531;\n\tv535 = v532 & 1;\n\tv537 = v535 == 0;\n\tv540 = ~v537;\n\tif (v540) goto L_FFFFFFFF;\n\tgoto L_012A;\nL_012A:\n\tgoto L_0131;\nL_012B:\n\tv516 = v357 + -0.5d;\n\tv376 = System.Math::Ceiling(v516);\n\tgoto L_0131;\nL_012E:\n\tv520 = v357 + 0.5d;\n\tv376 = System.Math::Floor(v520);\nL_0131:\n\tv557 = &v27 @ stack_-10_v2 - 0x18;\n\tv559 = 0x6D1ED0(v557, Il2CppMethodInfo, isRelative, methodInfo, v42, v43, v44, v45, v134, v552, v125, v123, v138, v357, v134, v337);\n\tv571 = v134 >= 0;\n\tif (v571) goto L_0158;\n\tv582 = v134 != -0.5d;\n\tif (v582) goto L_016A;\n\tv612 = *([v26 @ X29_v1-18]);\n\tgoto L_015D;\nL_0158:\n\tv593 = v134 != 0.5d;\n\tif (v593) goto L_016D;\n\tv612 = *([v26 @ X29_v1-18]);\nL_015D:\n\tv632 = v612 + v611;\n\tv615 = v612 & 1;\n\tv617 = v615 == 0;\n\tv620 = ~v617;\n\tif (v620) goto L_FFFFFFFF;\n\tgoto L_0169;\nL_0169:\n\tgoto L_0170;\nL_016A:\n\tv596 = v134 + -0.5d;\n\tv378 = System.Math::Ceiling(v596);\n\tgoto L_0170;\nL_016D:\n\tv600 = v134 + 0.5d;\n\tv378 = System.Math::Floor(v600);\nL_0170:\n\tv637 = &v27 @ stack_-10_v2 - 0x18;\n\tv386 = 0x6D1ED0(v637, Il2CppMethodInfo, isRelative, methodInfo, v42, v43, v44, v45, v337, v632, v125, v123, v138, v357, v134, v337);\n\tv650 = v337 >= 0;\n\tif (v650) goto L_0197;\n\tv661 = v337 != -0.5d;\n\tif (v661) goto L_01A9;\n\tv380 = *([v26 @ X29_v1-18]);\n\tgoto L_019C;\nL_0197:\n\tv672 = v337 != 0.5d;\n\tif (v672) goto L_01AC;\n\tv380 = *([v26 @ X29_v1-18]);\nL_019C:\n\tv693 = v380 + v690;\n\tv694 = v380 & 1;\n\tv696 = v694 == 0;\n\tv699 = ~v696;\n\tif (v699) goto L_FFFFFFFF;\n\tgoto L_01A8;\nL_01A8:\n\tgoto L_FFFFFFFF;\nL_01A9:\n\tv675 = v337 + -0.5d;\n\tv380 = System.Math::Ceiling(v675);\n\tgoto L_FFFFFFFF;\nL_01AC:\n\tv679 = v337 + 0.5d;\n\tv380 = System.Math::Floor(v679);\nL_01CA:\n\t// 458 MakeStruct v209 @ AGG10E0AD0_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v138 @ V11_v6 (UnityEngine.Vector4), v357 @ V10_v10 (System.Single), v134 @ V9_v6 (System.Single), v337 @ V8_v5 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::Invoke(t.setter, v209);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 307 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, bool isRelative)
		{
			//IL_002a: Expected F4, but got I
			//IL_003a: Expected F4, but got I
			//IL_004a: Expected F4, but got I
			//IL_0159: Expected F4, but got I
			//IL_0169: Expected F4, but got I
			//IL_0179: Expected F4, but got I
			//IL_029b: Expected O, but got I
			//IL_03ff: Expected O, but got I
			//IL_0354: Expected F8, but got I
			//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_08bd: Expected I4, but got Unknown
			//IL_0307: Expected F8, but got I
			//IL_054a: Expected O, but got I
			//IL_04a9: Expected F8, but got I
			//IL_0902: Unknown result type (might be due to invalid IL or missing references)
			//IL_0907: Expected I4, but got Unknown
			//IL_0461: Expected F8, but got I
			//IL_0695: Expected O, but got I
			//IL_05f4: Expected F8, but got I
			//IL_094c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0951: Expected I4, but got Unknown
			//IL_05ac: Expected F8, but got I
			//IL_07cf: Expected O, but got F8
			//IL_073f: Expected F8, but got I
			//IL_0996: Unknown result type (might be due to invalid IL or missing references)
			//IL_099b: Expected I4, but got Unknown
			//IL_06f7: Expected F8, but got I
			object obj2 = default(object);
			object obj = obj2;
			Vector4 startValue = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]");
			float num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]");
			float num3 = 0f;
			Vector4 vector = t.getter();
			float y = vector.y;
			float z = vector.z;
			float w = vector.w;
			t.endValue = vector;
			_ = vector.y;
			_ = vector.z;
			_ = vector.w;
			bool flag = !isRelative;
			float num4 = vector.w;
			float num5 = vector.z;
			float num6 = vector.y;
			Vector4 vector2 = vector;
			if (!flag)
			{
				Vector4 vector3 = vector + t.endValue;
				y = vector3.y;
				z = vector3.z;
				w = vector3.w;
				vector2 = t.endValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]");
				num6 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]");
				num5 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]");
				num4 = 0f;
				num3 = vector3.w;
				num2 = vector3.z;
				num = vector3.y;
				startValue = vector3;
			}
			t.startValue = startValue;
			if ((long)(IntPtr)t.plugOptions > 4L)
			{
				if ((IntPtr)t.plugOptions != (IntPtr)8)
				{
					if ((IntPtr)t.plugOptions == (IntPtr)16)
					{
						num2 = num5;
						num = num6;
						startValue = vector2;
					}
					goto IL_0861;
				}
				num = num6;
				startValue = vector2;
			}
			else
			{
				if ((IntPtr)t.plugOptions != (IntPtr)2)
				{
					if ((IntPtr)t.plugOptions != (IntPtr)4)
					{
						goto IL_0861;
					}
					startValue = vector2;
				}
				else
				{
					num = num6;
				}
				num2 = num5;
			}
			num3 = num4;
			goto IL_0861;
			IL_0861:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+150]");
			double num7;
			if ((IntPtr)0 != (IntPtr)0)
			{
				object obj3 = (long)(IntPtr)obj2 - 24L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num9;
				double num10;
				double num8;
				if (startValue.x < 0f)
				{
					if ((double)startValue.x != -0.5)
					{
						double a = (double)startValue.x + -0.5;
						num7 = Math.Ceiling(a);
						num8 = -0.5;
						goto IL_03f0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
					num9 = 0.0;
					num10 = -1.0;
				}
				else
				{
					if ((double)startValue.x != 0.5)
					{
						double d = (double)startValue.x + 0.5;
						num7 = Math.Floor(d);
						num8 = 0.5;
						goto IL_03f0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
					num9 = 0.0;
					num10 = 1.0;
				}
				num8 = num9 + num10;
				num7 = (((num9 & 1) != 0) ? num8 : num9);
				goto IL_03f0;
			}
			goto IL_07d4;
			IL_07d4:
			Vector4 pNewValue = default(Vector4);
			pNewValue.x = startValue.x;
			pNewValue.y = num;
			pNewValue.z = num2;
			pNewValue.w = num3;
			t.setter(pNewValue);
			return;
			IL_03f0:
			object obj4 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num11;
			double num13;
			double num14;
			double num12;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a2 = (double)num + -0.5;
					num11 = Math.Ceiling(a2);
					num12 = -0.5;
					goto IL_053b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				num13 = 0.0;
				num14 = -1.0;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d2 = (double)num + 0.5;
					num11 = Math.Floor(d2);
					num12 = 0.5;
					goto IL_053b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				num13 = 0.0;
				num14 = 1.0;
			}
			num12 = num13 + num14;
			num11 = (((num13 & 1) != 0) ? num12 : num13);
			goto IL_053b;
			IL_0686:
			object obj5 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num15;
			double num16;
			if (num3 < 0f)
			{
				if ((double)num3 != -0.5)
				{
					double a3 = (double)num3 + -0.5;
					num15 = Math.Ceiling(a3);
					goto IL_07af;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				num15 = 0.0;
				num16 = -1.0;
			}
			else
			{
				if ((double)num3 != 0.5)
				{
					double d3 = (double)num3 + 0.5;
					num15 = Math.Floor(d3);
					goto IL_07af;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				num15 = 0.0;
				num16 = 1.0;
			}
			double num17 = num15 + num16;
			if ((num15 & 1) != 0)
			{
				num15 = num17;
			}
			goto IL_07af;
			IL_07af:
			num3 = (float)num15;
			double num18;
			num2 = (float)num18;
			num = (float)num11;
			startValue = (Vector4)num7;
			goto IL_07d4;
			IL_053b:
			object obj6 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num20;
			double num21;
			double num19;
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a4 = (double)num2 + -0.5;
					num18 = Math.Ceiling(a4);
					num19 = -0.5;
					goto IL_0686;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				num20 = 0.0;
				num21 = -1.0;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d4 = (double)num2 + 0.5;
					num18 = Math.Floor(d4);
					num19 = 0.5;
					goto IL_0686;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				num20 = 0.0;
				num21 = 1.0;
			}
			num19 = num20 + num21;
			num18 = (((num20 & 1) != 0) ? num19 : num20);
			goto IL_0686;
		}

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0x10E0ADC", Offset = "0x10E0ADC", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv296 = fromValue.y;\n\tv191 = fromValue.z;\n\tv189 = fromValue.w;\n\tgoto L_0025;\n\tv44 = *([1EE11F8]);\n\tv45 = *([v44 @ X8_v35]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, t, setImmediately, methodInfo, v48, v49, v50, v51, fromValue, v0, v2, v3, v52, v53, v54, v55);\n\tv59 = 0 | 1;\n\t*([20274EF]) = v59;\nL_0025:\n\tt.startValue = fromValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+120]) = fromValue.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+124]) = fromValue.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+128]) = fromValue.w;\n\tv62 = setImmediately == 0;\n\tif (v62) goto L_006A;\n\tv76 = t.plugOptions <= 4;\n\tif (v76) goto L_006F;\n\tv142 = t.plugOptions == 8;\n\tif (v142) goto L_0092;\n\tv107 = t.plugOptions != 0x10;\n\tif (v107) goto L_00A7;\n\tv253 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tv296 = v253.y;\n\tv191 = v253.z;\n\tgoto L_00A7;\nL_006A:\n\treturn;\nL_006F:\n\tv143 = t.plugOptions == 2;\n\tif (v143) goto L_009F;\n\tv108 = t.plugOptions != 4;\n\tif (v108) goto L_00A7;\n\tv349 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tv386 = v349.y;\n\tv294 = v349.z;\n\tv189 = v349.w;\n\tgoto L_FFFFFFFF;\nL_0092:\n\tv304 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tv296 = v304.y;\n\tv294 = v304.z;\n\tv189 = v304.w;\n\tgoto L_FFFFFFFF;\nL_009F:\n\tv308 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tv386 = v308.y;\n\tv294 = v308.z;\n\tv189 = v308.w;\nL_00A7:\n\tv300 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+150]) == 0;\n\tif (v300) goto L_01CC;\n\tgoto L_00B8;\n\tv354 = *([v312 @ X0_v9+E0]);\n\tv355 = v354 == 0;\n\tv356 = ~v355;\n\tif (v356) goto L_00B8;\n\tv358 = \"il2cpp_codegen_runtime_class_init\"(v312, v104, setImmediately, methodInfo, v48, v49, v50, v51, v251, v296, v191, v189, v52, v53, v54, v55);\nL_00B8:\n\tv365 = 0x6D1ED0(&v363 @ stack_-68_v3 (System.Double), v254, setImmediately, methodInfo, v48, v49, v50, v51, v179, v296, v191, v189, v52, v53, v54, v55);\n\tv400 = v179 >= 0;\n\tif (v400) goto L_00DD;\n\tv411 = v179 != -0.5d;\n\tif (v411) goto L_00EF;\n\tgoto L_00E2;\nL_00DD:\n\tv422 = v179 != 0.5d;\n\tif (v422) goto L_00F2;\nL_00E2:\n\tv464 = v431 + v441;\n\tv444 = v431 & 1;\n\tv446 = v444 == 0;\n\tv449 = ~v446;\n\tif (v449) goto L_FFFFFFFF;\n\tgoto L_00EE;\nL_00EE:\n\tgoto L_00F7;\nL_00EF:\n\tv425 = v179 + -0.5d;\n\tv319 = System.Math::Ceiling(v425);\n\tgoto L_00F7;\nL_00F2:\n\tv429 = v179 + 0.5d;\n\tv319 = System.Math::Floor(v429);\nL_00F7:\n\tv469 = 0x6D1ED0(&v363 @ stack_-68_v3 (System.Double), v254, setImmediately, methodInfo, v48, v49, v50, v51, v181, v464, v191, v189, v52, v53, v54, v55);\n\tv481 = v181 >= 0;\n\tif (v481) goto L_011C;\n\tv492 = v181 != -0.5d;\n\tif (v492) goto L_012E;\n\tgoto L_0121;\nL_011C:\n\tv503 = v181 != 0.5d;\n\tif (v503) goto L_0131;\nL_0121:\n\tv545 = v512 + v522;\n\tv525 = v512 & 1;\n\tv527 = v525 == 0;\n\tv530 = ~v527;\n\tif (v530) goto L_FFFFFFFF;\n\tgoto L_012D;\nL_012D:\n\tgoto L_0136;\nL_012E:\n\tv506 = v181 + -0.5d;\n\tv320 = System.Math::Ceiling(v506);\n\tgoto L_0136;\nL_0131:\n\tv510 = v181 + 0.5d;\n\tv320 = System.Math::Floor(v510);\nL_0136:\n\tv550 = 0x6D1ED0(&v363 @ stack_-68_v3 (System.Double), v254, setImmediately, methodInfo, v48, v49, v50, v51, v183, v545, v191, v189, v52, v53, v54, v55);\n\tv562 = v183 >= 0;\n\tif (v562) goto L_015B;\n\tv573 = v183 != -0.5d;\n\tif (v573) goto L_016D;\n\tgoto L_0160;\nL_015B:\n\tv584 = v183 != 0.5d;\n\tif (v584) goto L_0170;\nL_0160:\n\tv626 = v593 + v603;\n\tv606 = v593 & 1;\n\tv608 = v606 == 0;\n\tv611 = ~v608;\n\tif (v611) goto L_FFFFFFFF;\n\tgoto L_016C;\nL_016C:\n\tgoto L_0175;\nL_016D:\n\tv587 = v183 + -0.5d;\n\tv318 = System.Math::Ceiling(v587);\n\tgoto L_0175;\nL_0170:\n\tv591 = v183 + 0.5d;\n\tv318 = System.Math::Floor(v591);\nL_0175:\n\tv332 = 0x6D1ED0(&v363 @ stack_-68_v3 (System.Double), v254, setImmediately, methodInfo, v48, v49, v50, v51, v185, v626, v191, v189, v52, v53, v54, v55);\n\tv641 = v185 >= 0;\n\tif (v641) goto L_019A;\n\tv652 = v185 != -0.5d;\n\tif (v652) goto L_01AC;\n\tgoto L_019F;\nL_019A:\n\tv663 = v185 != 0.5d;\n\tif (v663) goto L_01AF;\nL_019F:\n\tv684 = v321 + v682;\n\tv685 = v321 & 1;\n\tv687 = v685 == 0;\n\tv690 = ~v687;\n\tif (v690) goto L_FFFFFFFF;\n\tgoto L_01AB;\nL_01AB:\n\tgoto L_FFFFFFFF;\nL_01AC:\n\tv666 = v185 + -0.5d;\n\tv321 = System.Math::Ceiling(v666);\n\tgoto L_FFFFFFFF;\nL_01AF:\n\tv670 = v185 + 0.5d;\n\tv321 = System.Math::Floor(v670);\nL_01CC:\n\t// 460 MakeStruct v200 @ AGG10E0E60_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v179 @ V11_v6 (UnityEngine.Vector4), v181 @ V10_v6 (System.Single), v183 @ V9_v6 (System.Single), v185 @ V8_v6 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::Invoke(t.setter, v200);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 329 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 fromValue, bool setImmediately)
		{
			//IL_01bd: Expected I, but got O
			//IL_00da: Expected I, but got O
			//IL_0891: Unknown result type (might be due to invalid IL or missing references)
			//IL_0896: Expected I4, but got Unknown
			//IL_08db: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e0: Expected I4, but got Unknown
			//IL_0925: Unknown result type (might be due to invalid IL or missing references)
			//IL_092a: Expected I4, but got Unknown
			//IL_07c1: Expected O, but got F8
			//IL_096f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0974: Expected I4, but got Unknown
			float y = fromValue.y;
			float z = fromValue.z;
			float w = fromValue.w;
			t.startValue = fromValue;
			_ = fromValue.y;
			_ = fromValue.z;
			_ = fromValue.w;
			if (!setImmediately)
			{
				return;
			}
			Vector4 vector;
			float num;
			float num2;
			float num3;
			float z2;
			if ((long)(IntPtr)t.plugOptions > 4L)
			{
				IntPtr intPtr;
				if ((IntPtr)t.plugOptions != (IntPtr)8)
				{
					bool flag = (IntPtr)t.plugOptions != (IntPtr)16;
					intPtr = (IntPtr)t;
					vector = fromValue;
					num = y;
					num2 = fromValue.z;
					num3 = w;
					if (!flag)
					{
						Vector4 vector2 = t.getter();
						y = vector2.y;
						z = vector2.z;
						intPtr = (IntPtr)0;
						vector = vector2;
						num = vector2.y;
						num2 = vector2.z;
						num3 = w;
						w = vector2.w;
					}
					goto IL_082a;
				}
				Vector4 vector3 = t.getter();
				y = vector3.y;
				z2 = vector3.z;
				w = vector3.w;
				intPtr = (IntPtr)0;
				vector = vector3;
				num = vector3.y;
				num2 = fromValue.z;
			}
			else
			{
				float y2;
				if ((IntPtr)t.plugOptions != (IntPtr)2)
				{
					bool flag2 = (IntPtr)t.plugOptions != (IntPtr)4;
					IntPtr intPtr = (IntPtr)t;
					vector = fromValue;
					num = fromValue.y;
					num2 = fromValue.z;
					num3 = w;
					if (flag2)
					{
						goto IL_082a;
					}
					Vector4 vector4 = t.getter();
					y2 = vector4.y;
					z2 = vector4.z;
					w = vector4.w;
					intPtr = (IntPtr)0;
					vector = vector4;
					num = fromValue.y;
				}
				else
				{
					Vector4 vector5 = t.getter();
					y2 = vector5.y;
					z2 = vector5.z;
					w = vector5.w;
					IntPtr intPtr = (IntPtr)0;
					vector = fromValue;
					num = vector5.y;
				}
				num2 = z2;
				y = y2;
			}
			num3 = w;
			z = z2;
			goto IL_082a;
			IL_082a:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+150]");
			double num4;
			double num7 = default(double);
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num6;
				double num8;
				double num5;
				if (vector.x < 0f)
				{
					if ((double)vector.x != -0.5)
					{
						double a = (double)vector.x + -0.5;
						num4 = Math.Ceiling(a);
						num5 = -0.5;
						goto IL_0457;
					}
					num6 = num7;
					num8 = -1.0;
				}
				else
				{
					if ((double)vector.x != 0.5)
					{
						double d = (double)vector.x + 0.5;
						num4 = Math.Floor(d);
						num5 = 0.5;
						goto IL_0457;
					}
					num6 = num7;
					num8 = 1.0;
				}
				num5 = num6 + num8;
				num4 = (((num6 & 1) != 0) ? num5 : num6);
				goto IL_0457;
			}
			goto IL_07de;
			IL_0457:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num9;
			double num11;
			double num12;
			double num10;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a2 = (double)num + -0.5;
					num9 = Math.Ceiling(a2);
					num10 = -0.5;
					goto IL_0583;
				}
				num11 = num7;
				num12 = -1.0;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d2 = (double)num + 0.5;
					num9 = Math.Floor(d2);
					num10 = 0.5;
					goto IL_0583;
				}
				num11 = num7;
				num12 = 1.0;
			}
			num10 = num11 + num12;
			num9 = (((num11 & 1) != 0) ? num10 : num11);
			goto IL_0583;
			IL_06af:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num13;
			double num14;
			if (num3 < 0f)
			{
				if ((double)num3 != -0.5)
				{
					double a3 = (double)num3 + -0.5;
					num13 = Math.Ceiling(a3);
					goto IL_07b9;
				}
				num13 = num7;
				num14 = -1.0;
			}
			else
			{
				if ((double)num3 != 0.5)
				{
					double d3 = (double)num3 + 0.5;
					num13 = Math.Floor(d3);
					goto IL_07b9;
				}
				num13 = num7;
				num14 = 1.0;
			}
			double num15 = num13 + num14;
			if ((num13 & 1) != 0)
			{
				num13 = num15;
			}
			goto IL_07b9;
			IL_07b9:
			vector = (Vector4)num4;
			num = (float)num9;
			double num16;
			num2 = (float)num16;
			num3 = (float)num13;
			goto IL_07de;
			IL_0583:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num18;
			double num19;
			double num17;
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a4 = (double)num2 + -0.5;
					num16 = Math.Ceiling(a4);
					num17 = -0.5;
					goto IL_06af;
				}
				num18 = num7;
				num19 = -1.0;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d4 = (double)num2 + 0.5;
					num16 = Math.Floor(d4);
					num17 = 0.5;
					goto IL_06af;
				}
				num18 = num7;
				num19 = 1.0;
			}
			num17 = num18 + num19;
			num16 = (((num18 & 1) != 0) ? num17 : num18);
			goto IL_06af;
			IL_07de:
			Vector4 pNewValue = default(Vector4);
			pNewValue.x = vector.x;
			pNewValue.y = num;
			pNewValue.z = num2;
			pNewValue.w = num3;
			t.setter(pNewValue);
		}

		[Token(Token = "0x60001FA")]
		[Address(RVA = "0x10E0E6C", Offset = "0x10E0E6C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector4 ConvertToStartValue(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 value)
		{
			return value;
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0x10E0E70", Offset = "0x10E0E70", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv34 = *([1ECCA98]);\n\tv35 = *([v34 @ X8_v10]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, t, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([20274F0]) = v54;\nL_002B:\n\tgoto L_003C;\n\tv72 = *([v65 @ X0_v4+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_003C;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v65, t, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_003C:\n\tv90 = UnityEngine.Vector4::op_Addition(t.endValue, t.startValue);\n\tt.endValue = v90;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]) = v90.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]) = v90.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]) = v90.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector4, Vector4, VectorOptions> t)
		{
			Vector4 vector = (t.endValue += t.startValue);
			_ = vector.y;
			_ = vector.z;
			_ = vector.w;
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0x10E0F54", Offset = "0x10E0F54", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv34 = *([1EA5E88]);\n\tv35 = *([v34 @ X8_v13]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, t, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([20274F1]) = v54;\nL_0029:\n\tv68 = t.plugOptions <= 4;\n\tif (v68) goto L_004E;\n\tv75 = t.plugOptions == 8;\n\tif (v75) goto L_0094;\n\tv98 = t.plugOptions != 0x10;\n\tif (v98) goto L_0075;\n\tv290 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]) - *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+128]);\n\tgoto L_00A2;\nL_004E:\n\tv84 = t.plugOptions == 2;\n\tif (v84) goto L_009B;\n\tv117 = t.plugOptions != 4;\n\tif (v117) goto L_0075;\n\tv294 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]) - *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+120]);\n\tgoto L_FFFFFFFF;\nL_0075:\n\tgoto L_0086;\n\tv308 = *([v246 @ X0_v8+E0]);\n\tv309 = v308 == 0;\n\tv310 = ~v309;\n\tif (v310) goto L_0086;\n\tv312 = \"il2cpp_codegen_runtime_class_init\"(v246, t, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0086:\n\tv326 = UnityEngine.Vector4::op_Subtraction(t.endValue, t.startValue);\n\tt.changeValue = v326;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+140]) = v326.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+144]) = v326.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+148]) = v326.w;\n\tgoto L_00B6;\nL_0094:\n\tv291 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]) - *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+124]);\n\tgoto L_FFFFFFFF;\nL_009B:\n\tv104 = 0;\n\tv295 = t.endValue - t.startValue;\nL_00A2:\n\tv307 = 0x158BA74(v305, 0, methodInfo, v38, v39, v40, v41, v42, v295, v294, v291, v290, v47, v48, v49, v50);\n\tt.changeValue = v104;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+140]) = v329;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+148]) = v331;\nL_00B6:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector4, Vector4, VectorOptions> t)
		{
			Vector4 vector = default(Vector4);
			int num;
			if ((long)(IntPtr)t.plugOptions > 4L)
			{
				int num2;
				int num3;
				float num4;
				object obj;
				if ((IntPtr)t.plugOptions != (IntPtr)8)
				{
					if ((IntPtr)t.plugOptions == (IntPtr)16)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+138]");
						IntPtr intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+128]");
						num = (int)((long)intPtr - 0L);
						num2 = 0;
						num3 = 0;
						num4 = 0f;
						obj = vector;
						goto IL_0209;
					}
					goto IL_0135;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+134]");
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+124]");
				num2 = (int)((long)intPtr2 - 0L);
				num3 = 0;
				num4 = 0f;
				obj = vector;
			}
			else
			{
				if ((IntPtr)t.plugOptions != (IntPtr)2)
				{
					if ((IntPtr)t.plugOptions != (IntPtr)4)
					{
						goto IL_0135;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+130]");
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>)+120]");
					int num3 = (int)((long)intPtr3 - 0L);
					float num4 = 0f;
					object obj = vector;
				}
				else
				{
					vector = default(Vector4);
					float num4 = t.endValue.x - t.startValue.x;
					vector = default(Vector4);
					int num3 = 0;
					object obj = vector;
				}
				int num2 = 0;
			}
			num = 0;
			goto IL_0209;
			IL_0209:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
			t.changeValue = vector;
			return;
			IL_0135:
			Vector4 vector2 = (t.changeValue = t.endValue - t.startValue);
			_ = vector2.y;
			_ = vector2.z;
			_ = vector2.w;
		}

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0x10E1110", Offset = "0x10E1110", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0x158BF38(&changeValue @ V1 (System.Single), 0, methodInfo, v22, v23, v24, v25, v26, unitsXSecond, changeValue, *([changeValue @ V1 (System.Single)+4]), *([changeValue @ V1 (System.Single)+8]), *([changeValue @ V1 (System.Single)+C]), v27, v28, v29);\n\treturnVal1 = unitsXSecond / unitsXSecond;\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector4 changeValue)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BF38 (inside UnityEngine.Vector4::Magnitude +0xDC)");
			return unitsXSecond / unitsXSecond;
		}

		[Token(Token = "0x60001FE")]
		[Address(RVA = "0x10E114C", Offset = "0x10E114C", Length = "0x880")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv381 = startValue.w;\n\tv36 = &v37 @ stack_-10_v2;\n\tgoto L_003C;\n\tv64 = *([1EF8310]);\n\tv65 = *([v64 @ X8_v102]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v46, startValue, v0, v2, v3, duration, v71, v72);\n\tv76 = 0 | 1;\n\t*([20274F2]) = v76;\nL_003C:\n\tv88 = t.loopType != 2;\n\tif (v88) goto L_006E;\n\tv409 = t.completedLoops - t.isComplete;\n\tgoto L_0054;\n\tv434 = *([v405 @ X0_v64+E0]);\n\tv435 = v434 == 0;\n\tv436 = ~v435;\n\tif (v436) goto L_0054;\n\tv438 = \"il2cpp_codegen_runtime_class_init\"(v405, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v46, startValue, v0, v2, v3, duration, v71, v72);\nL_0054:\n\t// 84 MakeStruct v417 @ AGG10E1224_0_v3 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v36 @ X29_v1+10], [v36 @ X29_v1+14], [v36 @ X29_v1+18], [v36 @ X29_v1+1C]\n\tv445 = UnityEngine.Vector4::op_Multiply(v417, v409);\n\tv426 = UnityEngine.Vector4::op_Addition(startValue, v445);\nL_006E:\n\tv433 = ~t.isSequenced;\n\tif (v433) goto L_00E5;\n\tv337 = t.sequenceParent;\n\tv457 = v337.loopType != 2;\n\tif (v457) goto L_00E5;\n\tv178 = t.loopType != 2;\n\tif (v178) goto L_FFFFFFFF;\n\tv140 = t.loops;\n\tgoto L_0094;\nL_0094:\n\tgoto L_00A3;\n\tv647 = *([v616 @ X0_v55+E0]);\n\tv648 = v647 == 0;\n\tv649 = ~v648;\n\tgoto L_00A3;\n\tv651 = \"il2cpp_codegen_runtime_class_init\"(v616, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v328, v161, v392, v383, v379, v155, v152, v149);\nL_00A3:\n\t// 163 MakeStruct v125 @ AGG10E12D8_0_v3 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v36 @ X29_v1+10], [v36 @ X29_v1+14], [v36 @ X29_v1+18], [v36 @ X29_v1+1C]\n\tv329 = UnityEngine.Vector4::op_Multiply(v125, v140);\n\tv338 = t.sequenceParent;\n\tv490 = v338.completedLoops - v338.isComplete;\n\tgoto L_00C4;\n\tv922 = *([v790 @ X0_v58+E0]);\n\tv923 = v922 == 0;\n\tv924 = ~v923;\n\tif (v924) goto L_00C4;\n\tv926 = \"il2cpp_codegen_runtime_class_init\"(v790, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, v329, v162, v393, v384, v380, v155, v152, v149);\nL_00C4:\n\tv933 = UnityEngine.Vector4::op_Multiply(v329, v490);\n\t// 209 MakeStruct v447 @ AGG10E135C_0_v3 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v307 @ V15_v4 (UnityEngine.Vector4), v310 @ V14_v4 (System.Single), v314 @ V12_v4 (System.Single), v321 @ V11_v4 (System.Single)\n\tv483 = UnityEngine.Vector4::op_Addition(v447, v933);\nL_00E5:\n\tv330 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, *([v36 @ X29_v1+20]), t.easeOvershootOrAmplitude, t.easePeriod);\n\tv181 = options <= 4;\n\tif (v181) goto L_014A;\n\tv240 = options == 8;\n\tif (v240) goto L_01D5;\n\tv179 = options != 0x10;\n\tif (v179) goto L_0199;\n\tv642 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv526 = v642.y;\n\tv587 = v642.z;\n\tv710 = *([v36 @ X29_v1+1C]) * v330;\n\tv711 = options >> 0x20;\n\tv712 = v711 & 0xFF;\n\tv856 = v321 + v710;\n\tv714 = v712 == 0;\n\tif (v714) goto L_FFFFFFFF;\n\tgoto L_012B;\n\tv934 = *([v797 @ X0_v50+E0]);\n\tv935 = v934 == 0;\n\tv936 = ~v935;\n\tif (v936) goto L_012B;\n\tv938 = \"il2cpp_codegen_runtime_class_init\"(v797, v110, v97, isRelative, getter, setter, usingInversePosition, updateNotice, v710, v709, v395, v386, v381, v156, v153, v150);\nL_012B:\n\tv813 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(&v741 @ stack_-88_v14 (System.Double));\n\tv1026 = v856 >= 0;\n\tif (v1026) goto L_0270;\n\tv1099 = v856 != -0.5d;\n\tif (v1099) goto L_03A6;\n\tgoto L_0275;\nL_014A:\n\tv241 = options == 2;\n\tif (v241) goto L_0212;\n\tv180 = options != 4;\n\tif (v180) goto L_0199;\n\tv642 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv587 = v642.z;\n\tv585 = v642.w;\n\tv760 = *([v36 @ X29_v1+14]) * v330;\n\tv761 = options >> 0x20;\n\tv762 = v761 & 0xFF;\n\tv357 = v310 + v760;\n\tv764 = v762 == 0;\n\tif (v764) goto L_FFFFFFFF;\n\tgoto L_017D;\n\tv990 = *([v882 @ X0_v34+E0]);\n\tv991 = v990 == 0;\n\tv992 = ~v991;\n\tif (v992) goto L_017D;\n\tv994 = \"il2cpp_codegen_runtime_class_init\"(v882, v111, v97, isRelative, getter, setter, usingInversePosition, updateNotice, v760, v759, v396, v387, v381, v156, v153, v150);\nL_017D:\n\tv898 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(&v741 @ stack_-88_v14 (System.Double));\n\tv1066 = v357 >= 0;\n\tif (v1066) goto L_028C;\n\tv1168 = v357 != -0.5d;\n\tif (v1168) goto L_03A9;\n\tgoto L_0291;\nL_0199:\n\tv630 = *([v36 @ X29_v1+14]) * v330;\n\tv397 = *([v36 @ X29_v1+18]) * v330;\n\tv388 = *([v36 @ X29_v1+1C]) * v330;\n\tv631 = *([v36 @ X29_v1+10]) * v330;\n\tv632 = options >> 0x20;\n\tv633 = v632 & 0xFF;\n\tv364 = v307 + v631;\n\tv350 = v310 + v630;\n\tv371 = v314 + v397;\n\tv856 = v321 + v388;\n\tv638 = v633 == 0;\n\tif (v638) goto L_FFFFFFFF;\n\tgoto L_01B4;\n\tv715 = *([v664 @ X0_v12+E0]);\n\tv716 = v715 == 0;\n\tv717 = ~v716;\n\tif (v717) goto L_01B4;\n\tv719 = \"il2cpp_codegen_runtime_class_init\"(v664, v109, v97, isRelative, getter, setter, usingInversePosition, updateNotice, v631, v630, v397, v388, v381, v156, v153, v150);\nL_01B4:\n\tv726 = 0x6D1ED0(&v741 @ stack_-88_v14 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, updateNotice, v364, v630, v397, v388, v381, v156, v153, v150);\n\tv829 = v364 >= 0;\n\tif (v829) goto L_0254;\n\tv954 = v364 != -0.5d;\n\tif (v954) goto L_02D6;\n\tgoto L_0259;\nL_01D5:\n\tv642 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv526 = v642.y;\n\tv585 = v642.w;\n\tv693 = *([v36 @ X29_v1+18]) * v330;\n\tv694 = options >> 0x20;\n\tv695 = v694 & 0xFF;\n\tv359 = v314 + v693;\n\tv697 = v695 == 0;\n\tif (v697) goto L_FFFFFFFF;\n\tgoto L_01F1;\n\tv863 = *([v736 @ X0_v42+E0]);\n\tv864 = v863 == 0;\n\tv865 = ~v864;\n\tif (v865) goto L_01F1;\n\tv867 = \"il2cpp_codegen_runtime_class_init\"(v736, v112, v97, isRelative, getter, setter, usingInversePosition, updateNotice, v693, v692, v398, v389, v381, v156, v153, v150);\nL_01F1:\n\tv752 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(&v741 @ stack_-88_v14 (System.Double));\n\tv989 = v359 >= 0;\n\tif (v989) goto L_02A8;\n\tv1045 = v359 != -0.5d;\n\tif (v1045) goto L_03AC;\n\tgoto L_02AD;\nL_0212:\n\tv646 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv526 = v646.y;\n\tv587 = v646.z;\n\tv585 = v646.w;\n\tv704 = *([v36 @ X29_v1+10]) * v330;\n\tv705 = options >> 0x20;\n\tv706 = v705 & 0xFF;\n\tv360 = v307 + v704;\n\tv708 = v706 == 0;\n\tif (v708) goto L_FFFFFFFF;\n\tgoto L_022F;\n\tv905 = *([v767 @ X0_v26+E0]);\n\tv906 = v905 == 0;\n\tv907 = ~v906;\n\tif (v907) goto L_022F;\n\tv909 = \"il2cpp_codegen_runtime_class_init\"(v767, v113, v97, isRelative, getter, setter, usingInversePosition, updateNotice, v704, v702, v399, v390, v381, v156, v153, v150);\nL_022F:\n\tv783 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(&v741 @ stack_-88_v14 (System.Double));\n\tv1009 = v360 >= 0;\n\tif (v1009) goto L_02C4;\n\tv1077 = v360 != -0.5d;\n\tif (v1077) goto L_03AF;\n\tgoto L_02C9;\nL_0254:\n\tv965 = v364 != 0.5d;\n\tif (v965) goto L_02D9;\nL_0259:\n\tv1131 = v1121 + v1111;\n\tv1124 = v1121 & 1;\n\tv1126 = v1124 == 0;\n\tv1129 = ~v1126;\n\tif (v1129) goto L_FFFFFFFF;\n\tgoto L_0265;\nL_0265:\n\tgoto L_02DE;\nL_0270:\n\tv1110 = v856 != 0.5d;\n\tif (v1110) goto L_03B2;\nL_0275:\n\tv1268 = v817 + v1256;\n\tv1269 = v817 & 1;\n\tv1271 = v1269 == 0;\n\tv1274 = ~v1271;\n\tif (v1274) goto L_FFFFFFFF;\n\tgoto L_0281;\nL_0281:\n\tgoto L_FFFFFFFF;\nL_028C:\n\tv1179 = v357 != 0.5d;\n\tif (v1179) goto L_03C0;\nL_0291:\n\tv1312 = v901 + v1300;\n\tv1313 = v901 & 1;\n\tv1315 = v1313 == 0;\n\tv1318 = ~v1315;\n\tif (v1318) goto L_FFFFFFFF;\n\tgoto L_029D;\nL_029D:\n\tgoto L_FFFFFFFF;\nL_02A8:\n\tv1056 = v359 != 0.5d;\n\tif (v1056) goto L_03CE;\nL_02AD:\n\tv1220 = v755 + v1208;\n\tv1221 = v755 & 1;\n\tv1223 = v1221 == 0;\n\tv1226 = ~v1223;\n\tif (v1226) goto L_FFFFFFFF;\n\tgoto L_02B9;\nL_02B9:\n\tgoto L_FFFFFFFF;\nL_02C4:\n\tv1088 = v360 != 0.5d;\n\tif (v1088) goto L_03DC;\nL_02C9:\n\tv1248 = v787 + v1236;\n\tv1249 = v787 & 1;\n\tv1251 = v1249 == 0;\n\tv1254 = ~v1251;\n\tif (v1254) goto L_FFFFFFFF;\n\tgoto L_02D5;\nL_02D5:\n\tgoto L_FFFFFFFF;\nL_02D6:\n\tv1029 = v364 + -0.5d;\n\tv684 = System.Math::Ceiling(v1029);\n\tgoto L_02DE;\nL_02D9:\n\tv1033 = v364 + 0.5d;\n\tv684 = System.Math::Floor(v1033);\nL_02DE:\n\tv1149 = 0x6D1ED0(&v741 @ stack_-88_v14 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, updateNotice\n// ... truncated")]
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector4> getter, DOSetter<Vector4> setter, float elapsed, Vector4 startValue, Vector4 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_10c4: Expected F4, but got I
			//IL_00a1: Expected F4, but got I
			//IL_00b6: Expected F4, but got I
			//IL_00cb: Expected F4, but got I
			//IL_00e0: Expected F4, but got I
			//IL_0851: Expected I4, but got O
			//IL_012e: Expected O, but got F4
			//IL_1068: Expected O, but got F4
			//IL_074a: Expected I4, but got O
			//IL_0621: Expected I4, but got O
			//IL_089e: Expected O, but got F8
			//IL_0eac: Expected O, but got F4
			//IL_0509: Expected I4, but got O
			//IL_0792: Expected O, but got F8
			//IL_03d2: Expected I4, but got O
			//IL_0200: Expected F4, but got I
			//IL_0215: Expected F4, but got I
			//IL_022a: Expected F4, but got I
			//IL_023f: Expected F4, but got I
			//IL_0551: Expected O, but got F8
			//IL_1219: Unknown result type (might be due to invalid IL or missing references)
			//IL_121e: Expected I4, but got Unknown
			//IL_041a: Expected O, but got F8
			//IL_11d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_11d9: Expected I4, but got Unknown
			//IL_0308: Expected O, but got F4
			//IL_118f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1194: Expected I4, but got Unknown
			//IL_114a: Unknown result type (might be due to invalid IL or missing references)
			//IL_114f: Expected I4, but got Unknown
			//IL_1105: Unknown result type (might be due to invalid IL or missing references)
			//IL_110a: Expected I4, but got Unknown
			//IL_1277: Unknown result type (might be due to invalid IL or missing references)
			//IL_127c: Expected I4, but got Unknown
			//IL_12c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_12c6: Expected I4, but got Unknown
			//IL_130b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1310: Expected I4, but got Unknown
			float w = startValue.w;
			object obj2 = default(object);
			object obj = obj2;
			bool flag = t.loopType != LoopType.Incremental;
			Vector4 vector = startValue;
			float y = startValue.y;
			float z = startValue.z;
			float w2 = startValue.w;
			if (!flag)
			{
				float num = (float)t.completedLoops - (float)(t.isComplete ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
				Vector4 vector2 = default(Vector4);
				vector2.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+14]");
				vector2.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
				vector2.z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+1C]");
				vector2.w = 0f;
				Vector4 vector3 = vector2 * num;
				Vector4 vector4 = startValue + vector3;
				float w3 = vector3.w;
				float z2 = vector3.z;
				Vector4 vector5 = (Vector4)vector3.y;
				vector = vector4;
				y = vector4.y;
				z = vector4.z;
				w2 = vector4.w;
				w = vector3.x;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num2 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
					Vector4 vector6 = default(Vector4);
					vector6.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+14]");
					vector6.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
					vector6.z = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+1C]");
					vector6.w = 0f;
					Vector4 vector7 = vector6 * num2;
					Sequence sequenceParent2 = t.sequenceParent;
					float num3 = (float)sequenceParent2.completedLoops - (float)(sequenceParent2.isComplete ? 1 : 0);
					Vector4 vector8 = vector7 * num3;
					Vector4 vector9 = default(Vector4);
					vector9.x = vector.x;
					vector9.y = y;
					vector9.z = z;
					vector9.w = w2;
					Vector4 vector10 = vector9 + vector8;
					float w3 = vector8.w;
					float z2 = vector8.z;
					Vector4 vector5 = (Vector4)vector8.y;
					vector = vector10;
					y = vector10.y;
					z = vector10.z;
					w2 = vector10.w;
					w = vector8.x;
				}
			}
			Ease easeType = t.easeType;
			EaseFunction customEase = t.customEase;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+20]");
			float num4 = EaseManager.Evaluate(easeType, customEase, elapsed, 0f, t.easeOvershootOrAmplitude, t.easePeriod);
			Vector4 vector11;
			float y2;
			float w4;
			float num8;
			double num9 = default(double);
			double num10;
			float z3;
			float num16;
			double num17;
			float num23;
			double num24;
			float num30;
			double num31;
			if ((long)(IntPtr)options > 4L)
			{
				if ((IntPtr)options == (IntPtr)8)
				{
					vector11 = getter();
					y2 = vector11.y;
					w4 = vector11.w;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
					float num5 = 0f * num4;
					int num6 = (object)options >> 32;
					int num7 = num6 & 0xFF;
					num8 = z + num5;
					if (num7 != 0)
					{
						Vector4 vector12 = ((DOGetter<Vector4>)num9)();
						double num11;
						if (num8 < 0f)
						{
							if ((double)num8 != -0.5)
							{
								double a = (double)num8 + -0.5;
								num10 = Math.Ceiling(a);
								goto IL_1001;
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
								goto IL_1001;
							}
							num11 = 1.0;
							num10 = num9;
						}
						double num12 = num10 + num11;
						if ((num10 & 1) != 0)
						{
							num10 = num12;
						}
						goto IL_1001;
					}
					goto IL_100e;
				}
				if ((IntPtr)options == (IntPtr)16)
				{
					vector11 = getter();
					y2 = vector11.y;
					z3 = vector11.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+1C]");
					float num13 = 0f * num4;
					int num14 = (object)options >> 32;
					int num15 = num14 & 0xFF;
					num16 = w2 + num13;
					if (num15 != 0)
					{
						Vector4 vector13 = ((DOGetter<Vector4>)num9)();
						double num18;
						if (num16 < 0f)
						{
							if ((double)num16 != -0.5)
							{
								double a2 = (double)num16 + -0.5;
								num17 = Math.Ceiling(a2);
								goto IL_0f77;
							}
							num18 = -1.0;
							num17 = num9;
						}
						else
						{
							if ((double)num16 != 0.5)
							{
								double d2 = (double)num16 + 0.5;
								num17 = Math.Floor(d2);
								goto IL_0f77;
							}
							num18 = 1.0;
							num17 = num9;
						}
						double num19 = num17 + num18;
						if ((num17 & 1) != 0)
						{
							num17 = num19;
						}
						goto IL_0f77;
					}
					goto IL_0f84;
				}
			}
			else
			{
				if ((IntPtr)options == (IntPtr)2)
				{
					Vector4 vector14 = getter();
					y2 = vector14.y;
					z3 = vector14.z;
					w4 = vector14.w;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
					float num20 = 0f * num4;
					int num21 = (object)options >> 32;
					int num22 = num21 & 0xFF;
					num23 = vector.x + num20;
					if (num22 != 0)
					{
						Vector4 vector15 = ((DOGetter<Vector4>)num9)();
						double num25;
						if (num23 < 0f)
						{
							if ((double)num23 != -0.5)
							{
								double a3 = (double)num23 + -0.5;
								num24 = Math.Ceiling(a3);
								goto IL_104a;
							}
							num25 = -1.0;
							num24 = num9;
						}
						else
						{
							if ((double)num23 != 0.5)
							{
								double d3 = (double)num23 + 0.5;
								num24 = Math.Floor(d3);
								goto IL_104a;
							}
							num25 = 1.0;
							num24 = num9;
						}
						double num26 = num24 + num25;
						if ((num24 & 1) != 0)
						{
							num24 = num26;
						}
						goto IL_104a;
					}
					goto IL_1057;
				}
				if ((IntPtr)options == (IntPtr)4)
				{
					vector11 = getter();
					z3 = vector11.z;
					w4 = vector11.w;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+14]");
					float num27 = 0f * num4;
					int num28 = (object)options >> 32;
					int num29 = num28 & 0xFF;
					num30 = y + num27;
					if (num29 != 0)
					{
						Vector4 vector16 = ((DOGetter<Vector4>)num9)();
						double num32;
						if (num30 < 0f)
						{
							if ((double)num30 != -0.5)
							{
								double a4 = (double)num30 + -0.5;
								num31 = Math.Ceiling(a4);
								goto IL_0fb8;
							}
							num32 = -1.0;
							num31 = num9;
						}
						else
						{
							if ((double)num30 != 0.5)
							{
								double d4 = (double)num30 + 0.5;
								num31 = Math.Floor(d4);
								goto IL_0fb8;
							}
							num32 = 1.0;
							num31 = num9;
						}
						double num33 = num31 + num32;
						if ((num31 & 1) != 0)
						{
							num31 = num33;
						}
						goto IL_0fb8;
					}
					goto IL_0fc5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+14]");
			float num34 = 0f * num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
			float num35 = 0f * num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+1C]");
			float num36 = 0f * num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
			float num37 = 0f * num4;
			int num38 = (object)options >> 32;
			int num39 = num38 & 0xFF;
			float num40 = vector.x + num37;
			float num41 = y + num34;
			float num42 = z + num35;
			num16 = w2 + num36;
			double num43;
			if (num39 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num45;
				double num46;
				double num44;
				if (num40 < 0f)
				{
					if ((double)num40 != -0.5)
					{
						double a5 = (double)num40 + -0.5;
						num43 = Math.Ceiling(a5);
						num44 = -0.5;
						goto IL_0b0c;
					}
					num45 = -1.0;
					num46 = num9;
				}
				else
				{
					if ((double)num40 != 0.5)
					{
						double d5 = (double)num40 + 0.5;
						num43 = Math.Floor(d5);
						num44 = 0.5;
						goto IL_0b0c;
					}
					num45 = 1.0;
					num46 = num9;
				}
				num44 = num46 + num45;
				num43 = (((num46 & 1) != 0) ? num44 : num46);
				goto IL_0b0c;
			}
			goto IL_0e93;
			IL_0d64:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num47;
			double num48;
			if (num16 < 0f)
			{
				if ((double)num16 != -0.5)
				{
					double a6 = (double)num16 + -0.5;
					num47 = Math.Ceiling(a6);
					goto IL_0e6e;
				}
				num48 = -1.0;
				num47 = num9;
			}
			else
			{
				if ((double)num16 != 0.5)
				{
					double d6 = (double)num16 + 0.5;
					num47 = Math.Floor(d6);
					goto IL_0e6e;
				}
				num48 = 1.0;
				num47 = num9;
			}
			double num49 = num47 + num48;
			if ((num47 & 1) != 0)
			{
				num47 = num49;
			}
			goto IL_0e6e;
			IL_0f84:
			DOSetter<Vector4> dOSetter = setter;
			goto IL_133d;
			IL_0e93:
			y2 = num41;
			dOSetter = setter;
			vector11 = (Vector4)num40;
			z3 = num42;
			goto IL_133d;
			IL_104a:
			num23 = (float)num24;
			goto IL_1057;
			IL_100e:
			dOSetter = setter;
			z3 = num8;
			goto IL_134a;
			IL_0c38:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num50;
			double num52;
			double num53;
			double num51;
			if (num42 < 0f)
			{
				if ((double)num42 != -0.5)
				{
					double a7 = (double)num42 + -0.5;
					num50 = Math.Ceiling(a7);
					num51 = -0.5;
					goto IL_0d64;
				}
				num52 = -1.0;
				num53 = num9;
			}
			else
			{
				if ((double)num42 != 0.5)
				{
					double d7 = (double)num42 + 0.5;
					num50 = Math.Floor(d7);
					num51 = 0.5;
					goto IL_0d64;
				}
				num52 = 1.0;
				num53 = num9;
			}
			num51 = num53 + num52;
			num50 = (((num53 & 1) != 0) ? num51 : num53);
			goto IL_0d64;
			IL_1057:
			dOSetter = setter;
			vector11 = (Vector4)num23;
			goto IL_134a;
			IL_0fb8:
			num30 = (float)num31;
			goto IL_0fc5;
			IL_134a:
			Vector4 pNewValue = default(Vector4);
			pNewValue.x = vector11.x;
			pNewValue.y = y2;
			pNewValue.z = z3;
			pNewValue.w = w4;
			dOSetter(pNewValue);
			return;
			IL_1001:
			num8 = (float)num10;
			goto IL_100e;
			IL_0b0c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num54;
			double num56;
			double num57;
			double num55;
			if (num41 < 0f)
			{
				if ((double)num41 != -0.5)
				{
					double a8 = (double)num41 + -0.5;
					num54 = Math.Ceiling(a8);
					num55 = -0.5;
					goto IL_0c38;
				}
				num56 = -1.0;
				num57 = num9;
			}
			else
			{
				if ((double)num41 != 0.5)
				{
					double d8 = (double)num41 + 0.5;
					num54 = Math.Floor(d8);
					num55 = 0.5;
					goto IL_0c38;
				}
				num56 = 1.0;
				num57 = num9;
			}
			num55 = num57 + num56;
			num54 = (((num57 & 1) != 0) ? num55 : num57);
			goto IL_0c38;
			IL_0fc5:
			y2 = num30;
			dOSetter = setter;
			goto IL_134a;
			IL_0e6e:
			num41 = (float)num54;
			num16 = (float)num47;
			num40 = (float)num43;
			num42 = (float)num50;
			goto IL_0e93;
			IL_133d:
			w4 = num16;
			goto IL_134a;
			IL_0f77:
			num16 = (float)num17;
			goto IL_0f84;
		}

		[Token(Token = "0x60001FF")]
		[Address(RVA = "0x10E19CC", Offset = "0x10E19CC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC3330]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274F3]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector4Plugin()
		{
		}
	}
}
