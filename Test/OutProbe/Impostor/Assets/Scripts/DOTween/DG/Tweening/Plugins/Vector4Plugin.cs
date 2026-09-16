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
	[Token(Token = "0x2000082")]
	public class Vector4Plugin : ABSTweenPlugin<Vector4, Vector4, VectorOptions>
	{
		[Token(Token = "0x6000340")]
		[Address(RVA = "0xC24AC0", Offset = "0xC24AC0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector4, Vector4, VectorOptions> t)
		{
		}

		[Token(Token = "0x6000341")]
		[Address(RVA = "0xC24AC4", Offset = "0xC24AC4", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = System.Math;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, t, isRelative, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35783]) = v50;\nL_001B:\n\tv52 = t.getter;\n\tv262 = t.endValue.y;\n\tv260 = t.endValue.z;\n\tv258 = t.endValue.w;\n\tv122 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tt.endValue.x = v39;\n\tt.endValue.y = v40;\n\tt.endValue.z = v41;\n\tt.endValue.w = v42;\n\tv124 = isRelative == 0;\n\tif (v124) goto L_0032;\n\tv263 = t.endValue + v39;\n\tv262 = v262 + v40;\n\tv260 = v260 + v41;\n\tv258 = v258 + v42;\nL_0032:\n\tt.startValue.x = v263;\n\tt.startValue.y = v262;\n\tt.startValue.z = v260;\n\tt.startValue.w = v258;\n\tv145 = t.plugOptions <= 4;\n\tif (v145) goto L_005E;\n\tv200 = t.plugOptions == 8;\n\tif (v200) goto L_FFFFFFFF;\n\tv223 = t.plugOptions != 0x10;\n\tif (v223) goto L_007A;\n\tgoto L_FFFFFFFF;\nL_005E:\n\tv209 = t.plugOptions == 2;\n\tif (v209) goto L_FFFFFFFF;\n\tv234 = t.plugOptions != 4;\n\tif (v234) goto L_007A;\n\tgoto L_FFFFFFFF;\n\tgoto L_007A;\nL_007A:\n\tv266 = ~t.plugOptions.snapping;\n\tif (v266) goto L_0184;\n\tgoto L_0087;\n\tv312 = \"il2cpp_codegen_runtime_class_init\"(v283, v106, isRelative, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0087:\n\tv318 = 0x1854ED0(&v316 @ stack_-58_v3 (System.Double), v52.method, isRelative, methodInfo, v35, v36, v37, v38, v263, v40, v41, v42, v43, v44, v45, v46);\n\tv328 = v263 >= 0;\n\tif (v328) goto L_00AC;\n\tv339 = v263 != -0.5d;\n\tif (v339) goto L_00BE;\n\tgoto L_00B1;\nL_00AC:\n\tv350 = v263 != 0.5d;\n\tif (v350) goto L_00C1;\nL_00B1:\n\tv379 = v360 + v359;\n\tv372 = v360 & 1;\n\tv374 = v372 == 0;\n\tv377 = ~v374;\n\tif (v377) goto L_FFFFFFFF;\n\tgoto L_00BD;\nL_00BD:\n\tgoto L_00C6;\nL_00BE:\n\tv353 = v263 + -0.5d;\n\tv293 = System.Math::Ceiling(v353);\n\tgoto L_00C6;\nL_00C1:\n\tv357 = v263 + 0.5d;\n\tv293 = System.Math::Floor(v357);\nL_00C6:\n\tv397 = 0x1854ED0(&v316 @ stack_-58_v3 (System.Double), v52.method, isRelative, methodInfo, v35, v36, v37, v38, v262, v379, v41, v42, v43, v44, v45, v46);\n\tv409 = v262 >= 0;\n\tif (v409) goto L_00EB;\n\tv420 = v262 != -0.5d;\n\tif (v420) goto L_00FD;\n\tgoto L_00F0;\nL_00EB:\n\tv431 = v262 != 0.5d;\n\tif (v431) goto L_0100;\nL_00F0:\n\tv461 = v441 + v440;\n\tv453 = v441 & 1;\n\tv455 = v453 == 0;\n\tv458 = ~v455;\n\tif (v458) goto L_FFFFFFFF;\n\tgoto L_00FC;\nL_00FC:\n\tgoto L_0105;\nL_00FD:\n\tv434 = v262 + -0.5d;\n\tv289 = System.Math::Ceiling(v434);\n\tgoto L_0105;\nL_0100:\n\tv438 = v262 + 0.5d;\n\tv289 = System.Math::Floor(v438);\nL_0105:\n\tv478 = 0x1854ED0(&v316 @ stack_-58_v3 (System.Double), v52.method, isRelative, methodInfo, v35, v36, v37, v38, v260, v461, v41, v42, v43, v44, v45, v46);\n\tv490 = v260 >= 0;\n\tif (v490) goto L_012A;\n\tv501 = v260 != -0.5d;\n\tif (v501) goto L_013C;\n\tgoto L_012F;\nL_012A:\n\tv512 = v260 != 0.5d;\n\tif (v512) goto L_013F;\nL_012F:\n\tv542 = v522 + v521;\n\tv534 = v522 & 1;\n\tv536 = v534 == 0;\n\tv539 = ~v536;\n\tif (v539) goto L_FFFFFFFF;\n\tgoto L_013B;\nL_013B:\n\tgoto L_0144;\nL_013C:\n\tv515 = v260 + -0.5d;\n\tv288 = System.Math::Ceiling(v515);\n\tgoto L_0144;\nL_013F:\n\tv519 = v260 + 0.5d;\n\tv288 = System.Math::Floor(v519);\nL_0144:\n\tv307 = 0x1854ED0(&v316 @ stack_-58_v3 (System.Double), v52.method, isRelative, methodInfo, v35, v36, v37, v38, v258, v542, v41, v42, v43, v44, v45, v46);\n\tv569 = v258 >= 0;\n\tif (v569) goto L_0169;\n\tv580 = v258 != -0.5d;\n\tif (v580) goto L_017B;\n\tgoto L_016E;\nL_0169:\n\tv591 = v258 != 0.5d;\n\tif (v591) goto L_017E;\nL_016E:\n\tv612 = v291 + v600;\n\tv613 = v291 & 1;\n\tv615 = v613 == 0;\n\tv618 = ~v615;\n\tif (v618) goto L_FFFFFFFF;\n\tgoto L_017A;\nL_017A:\n\tgoto L_FFFFFFFF;\nL_017B:\n\tv594 = v258 + -0.5d;\n\tv291 = System.Math::Ceiling(v594);\n\tgoto L_FFFFFFFF;\nL_017E:\n\tv598 = v258 + 0.5d;\n\tv291 = System.Math::Floor(v598);\nL_0184:\n\tv115 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::Invoke(t.setter, v115.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 288 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, bool isRelative)
		{
			//IL_06de: Expected O, but got I
			//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a6: Expected I4, but got Unknown
			//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f0: Expected I4, but got Unknown
			//IL_0835: Unknown result type (might be due to invalid IL or missing references)
			//IL_083a: Expected I4, but got Unknown
			//IL_087f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0884: Expected I4, but got Unknown
			DOGetter<Vector4> getter = t.getter;
			float num = t.endValue.y;
			float num2 = t.endValue.z;
			float num3 = t.endValue.w;
			object obj = t.getter();
			float num4 = default(float);
			t.endValue.x = num4;
			float num5 = default(float);
			t.endValue.y = num5;
			float num6 = default(float);
			t.endValue.z = num6;
			float num7 = default(float);
			t.endValue.w = num7;
			bool flag = !isRelative;
			float num8 = t.endValue.x;
			if (!flag)
			{
				num8 = t.endValue.x + num4;
				num += num5;
				num2 += num6;
				num3 += num7;
			}
			t.startValue.x = num8;
			t.startValue.y = num;
			t.startValue.z = num2;
			t.startValue.w = num3;
			if ((nint)t.plugOptions > 4)
			{
				if ((nint)t.plugOptions != 8)
				{
					if ((nint)t.plugOptions != 16)
					{
						goto IL_074c;
					}
					num2 = num6;
				}
				else
				{
					num3 = num7;
				}
				num = num5;
				goto IL_077c;
			}
			if ((nint)t.plugOptions != 2)
			{
				if ((nint)t.plugOptions == 4)
				{
					num3 = num7;
					num2 = num6;
					goto IL_077c;
				}
			}
			else
			{
				num3 = num7;
				num2 = num6;
				num = num5;
			}
			goto IL_074c;
			IL_074c:
			double num9;
			double num13 = default(double);
			if (t.plugOptions.snapping)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num11;
				double num12;
				double num10;
				if (num8 < 0f)
				{
					if ((double)num8 != -0.5)
					{
						double a = (double)num8 + -0.5;
						num9 = Math.Ceiling(a);
						num10 = -0.5;
						goto IL_0331;
					}
					num11 = -1.0;
					num12 = num13;
				}
				else
				{
					if ((double)num8 != 0.5)
					{
						double d = (double)num8 + 0.5;
						num9 = Math.Floor(d);
						num10 = 0.5;
						goto IL_0331;
					}
					num11 = 1.0;
					num12 = num13;
				}
				num10 = num12 + num11;
				num9 = (((num12 & 1) != 0) ? num10 : num12);
				goto IL_0331;
			}
			goto IL_08b1;
			IL_0331:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num14;
			double num16;
			double num17;
			double num15;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a2 = (double)num + -0.5;
					num14 = Math.Ceiling(a2);
					num15 = -0.5;
					goto IL_0462;
				}
				num16 = -1.0;
				num17 = num13;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d2 = (double)num + 0.5;
					num14 = Math.Floor(d2);
					num15 = 0.5;
					goto IL_0462;
				}
				num16 = 1.0;
				num17 = num13;
			}
			num15 = num17 + num16;
			num14 = (((num17 & 1) != 0) ? num15 : num17);
			goto IL_0462;
			IL_077c:
			num8 = num4;
			goto IL_074c;
			IL_0593:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num18;
			double num19;
			if (num3 < 0f)
			{
				if ((double)num3 != -0.5)
				{
					double a3 = (double)num3 + -0.5;
					num18 = Math.Ceiling(a3);
					goto IL_06a2;
				}
				num19 = -1.0;
				num18 = num13;
			}
			else
			{
				if ((double)num3 != 0.5)
				{
					double d3 = (double)num3 + 0.5;
					num18 = Math.Floor(d3);
					goto IL_06a2;
				}
				num19 = 1.0;
				num18 = num13;
			}
			double num20 = num18 + num19;
			if ((num18 & 1) != 0)
			{
				num18 = num20;
			}
			goto IL_06a2;
			IL_06a2:
			num3 = (float)num18;
			double num21;
			num2 = (float)num21;
			num = (float)num14;
			num8 = (float)num9;
			goto IL_08b1;
			IL_0462:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num23;
			double num24;
			double num22;
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a4 = (double)num2 + -0.5;
					num21 = Math.Ceiling(a4);
					num22 = -0.5;
					goto IL_0593;
				}
				num23 = -1.0;
				num24 = num13;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d4 = (double)num2 + 0.5;
					num21 = Math.Floor(d4);
					num22 = 0.5;
					goto IL_0593;
				}
				num23 = 1.0;
				num24 = num13;
			}
			num22 = num24 + num23;
			num21 = (((num24 & 1) != 0) ? num22 : num24);
			goto IL_0593;
			IL_08b1:
			DOSetter<Vector4> setter = t.setter;
			t.setter((Vector4)(nint)setter.method);
		}

		[Token(Token = "0x6000342")]
		[Address(RVA = "0xC24DE4", Offset = "0xC24DE4", Length = "0x3D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv44 = System.Math;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, t, setImmediately, isRelative, methodInfo, v47, v48, v49, fromValue, v0, v2, v3, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A35784]) = v57;\nL_0023:\n\tv59 = isRelative == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv62 = t.getter;\n\tv196 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tv198 = v139 + v139;\n\tv189 = t.endValue + v139;\n\tv393 = v139.y + v139.y;\n\tv328 = v139.z + v139.z;\n\tt.endValue = v189;\n\tv179 = v139.w + v139.w;\n\tgoto L_003C;\nL_003C:\n\tt.startValue.x = v392;\n\tt.startValue.y = v393;\n\tt.startValue.z = v328;\n\tt.startValue.w = v179;\n\tv205 = setImmediately == 0;\n\tif (v205) goto L_007E;\n\tv80 = t.plugOptions <= 4;\n\tif (v80) goto L_0083;\n\tv114 = t.plugOptions == 8;\n\tif (v114) goto L_009D;\n\tv78 = t.plugOptions != 0x10;\n\tif (v78) goto L_00B2;\n\tv181 = t.getter;\n\tv318 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(t.getter);\n\tgoto L_00B2;\nL_007E:\n\treturn;\nL_0083:\n\tv115 = t.plugOptions == 2;\n\tif (v115) goto L_00A7;\n\tv79 = t.plugOptions != 4;\n\tif (v79) goto L_00B2;\n\tv182 = t.getter;\n\tv312 = v182.method;\n\tv399 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(v182);\n\tgoto L_FFFFFFFF;\nL_009D:\n\tv183 = t.getter;\n\tv312 = v183.method;\n\tv339 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(v183);\n\tgoto L_FFFFFFFF;\nL_00A7:\n\tv184 = t.getter;\n\tv312 = v184.method;\n\tv345 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(v184);\nL_00B2:\n\tv335 = ~t.plugOptions.snapping;\n\tif (v335) goto L_01BC;\n\tgoto L_00BF;\n\tv401 = \"il2cpp_codegen_runtime_class_init\"(v350, v154, setImmediately, isRelative, methodInfo, v47, v48, v49, v139, v0, v2, v3, v151, v51, v52, v53);\nL_00BF:\n\tv407 = 0x1854ED0(&v405 @ stack_-68_v3 (System.Double), v154, setImmediately, isRelative, methodInfo, v47, v48, v49, v392, v139.y, v139.z, v139.w, t.endValue, v51, v52, v53);\n\tv417 = v392 >= 0;\n\tif (v417) goto L_00E4;\n\tv428 = v392 != -0.5d;\n\tif (v428) goto L_00F6;\n\tgoto L_00E9;\nL_00E4:\n\tv439 = v392 != 0.5d;\n\tif (v439) goto L_00F9;\nL_00E9:\n\tv481 = v457 + v458;\n\tv461 = v457 & 1;\n\tv463 = v461 == 0;\n\tv466 = ~v463;\n\tif (v466) goto L_FFFFFFFF;\n\tgoto L_00F5;\nL_00F5:\n\tgoto L_00FE;\nL_00F6:\n\tv442 = v392 + -0.5d;\n\tv357 = System.Math::Ceiling(v442);\n\tgoto L_00FE;\nL_00F9:\n\tv446 = v392 + 0.5d;\n\tv357 = System.Math::Floor(v446);\nL_00FE:\n\tv486 = 0x1854ED0(&v405 @ stack_-68_v3 (System.Double), v154, setImmediately, isRelative, methodInfo, v47, v48, v49, v393, v481, v139.z, v139.w, t.endValue, v51, v52, v53);\n\tv498 = v393 >= 0;\n\tif (v498) goto L_0123;\n\tv509 = v393 != -0.5d;\n\tif (v509) goto L_0135;\n\tgoto L_0128;\nL_0123:\n\tv520 = v393 != 0.5d;\n\tif (v520) goto L_0138;\nL_0128:\n\tv562 = v538 + v539;\n\tv542 = v538 & 1;\n\tv544 = v542 == 0;\n\tv547 = ~v544;\n\tif (v547) goto L_FFFFFFFF;\n\tgoto L_0134;\nL_0134:\n\tgoto L_013D;\nL_0135:\n\tv523 = v393 + -0.5d;\n\tv358 = System.Math::Ceiling(v523);\n\tgoto L_013D;\nL_0138:\n\tv527 = v393 + 0.5d;\n\tv358 = System.Math::Floor(v527);\nL_013D:\n\tv567 = 0x1854ED0(&v405 @ stack_-68_v3 (System.Double), v154, setImmediately, isRelative, methodInfo, v47, v48, v49, v328, v562, v139.z, v139.w, t.endValue, v51, v52, v53);\n\tv579 = v328 >= 0;\n\tif (v579) goto L_0162;\n\tv590 = v328 != -0.5d;\n\tif (v590) goto L_0174;\n\tgoto L_0167;\nL_0162:\n\tv601 = v328 != 0.5d;\n\tif (v601) goto L_0177;\nL_0167:\n\tv643 = v619 + v620;\n\tv623 = v619 & 1;\n\tv625 = v623 == 0;\n\tv628 = ~v625;\n\tif (v628) goto L_FFFFFFFF;\n\tgoto L_0173;\nL_0173:\n\tgoto L_017C;\nL_0174:\n\tv604 = v328 + -0.5d;\n\tv356 = System.Math::Ceiling(v604);\n\tgoto L_017C;\nL_0177:\n\tv608 = v328 + 0.5d;\n\tv356 = System.Math::Floor(v608);\nL_017C:\n\tv369 = 0x1854ED0(&v405 @ stack_-68_v3 (System.Double), v154, setImmediately, isRelative, methodInfo, v47, v48, v49, v179, v643, v139.z, v139.w, t.endValue, v51, v52, v53);\n\tv658 = v179 >= 0;\n\tif (v658) goto L_01A1;\n\tv669 = v179 != -0.5d;\n\tif (v669) goto L_01B3;\n\tgoto L_01A6;\nL_01A1:\n\tv680 = v179 != 0.5d;\n\tif (v680) goto L_01B6;\nL_01A6:\n\tv701 = v368 + v699;\n\tv702 = v368 & 1;\n\tv704 = v702 == 0;\n\tv707 = ~v704;\n\tif (v707) goto L_FFFFFFFF;\n\tgoto L_01B2;\nL_01B2:\n\tgoto L_FFFFFFFF;\nL_01B3:\n\tv683 = v179 + -0.5d;\n\tv368 = System.Math::Ceiling(v683);\n\tgoto L_FFFFFFFF;\nL_01B6:\n\tv687 = v179 + 0.5d;\n\tv368 = System.Math::Floor(v687);\nL_01BC:\n\tv185 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::Invoke(t.setter, v185.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 335 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 fromValue, bool setImmediately, bool isRelative)
		{
			//IL_009f: Expected O, but got F4
			//IL_00c5: Expected O, but got I
			//IL_00cd: Expected O, but got F4
			//IL_02f1: Expected O, but got F4
			//IL_0898: Expected O, but got I
			//IL_083d: Expected O, but got I
			//IL_02b8: Expected O, but got F4
			//IL_0215: Expected O, but got I
			//IL_021d: Expected O, but got F4
			//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_08c7: Expected I4, but got Unknown
			//IL_090c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0911: Expected I4, but got Unknown
			//IL_0956: Unknown result type (might be due to invalid IL or missing references)
			//IL_095b: Expected I4, but got Unknown
			//IL_0809: Expected O, but got F8
			//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a5: Expected I4, but got Unknown
			Vector4 vector = default(Vector4);
			float num2 = default(float);
			TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore;
			Vector4 vector2;
			float num3;
			float num4;
			float num5;
			if (isRelative)
			{
				DOGetter<Vector4> getter = t.getter;
				object obj = t.getter();
				float num = vector.x + vector.x;
				num2 = t.endValue.x + vector.x;
				num3 = vector.y + vector.y;
				num4 = vector.z + vector.z;
				t.endValue = (Vector4)num2;
				num5 = vector.w + vector.w;
				tweenerCore = (TweenerCore<Vector4, Vector4, VectorOptions>)(nint)getter.method;
				vector2 = (Vector4)num;
			}
			else
			{
				tweenerCore = t;
				vector2 = vector;
				num3 = vector.y;
				num4 = vector.z;
				num5 = vector.w;
			}
			t.startValue.x = vector2.x;
			t.startValue.y = num3;
			t.startValue.z = num4;
			t.startValue.w = num5;
			if (!setImmediately)
			{
				return;
			}
			IntPtr method;
			if ((nint)t.plugOptions > 4)
			{
				if ((nint)t.plugOptions != 8)
				{
					if ((nint)t.plugOptions == 16)
					{
						DOGetter<Vector4> getter2 = t.getter;
						object obj2 = t.getter();
						tweenerCore = (TweenerCore<Vector4, Vector4, VectorOptions>)(nint)getter2.method;
						vector2 = (Vector4)num2;
						num3 = vector.y;
						num4 = vector.z;
					}
					goto IL_085b;
				}
				DOGetter<Vector4> getter3 = t.getter;
				method = getter3.method;
				object obj3 = getter3();
				vector2 = (Vector4)num2;
				num3 = vector.y;
			}
			else
			{
				if ((nint)t.plugOptions != 2)
				{
					if ((nint)t.plugOptions != 4)
					{
						goto IL_085b;
					}
					DOGetter<Vector4> getter4 = t.getter;
					method = getter4.method;
					object obj4 = getter4();
					vector2 = (Vector4)num2;
				}
				else
				{
					DOGetter<Vector4> getter5 = t.getter;
					method = getter5.method;
					object obj5 = getter5();
					num3 = vector.y;
				}
				num4 = vector.z;
			}
			tweenerCore = (TweenerCore<Vector4, Vector4, VectorOptions>)(nint)method;
			num5 = vector.w;
			goto IL_085b;
			IL_09d2:
			DOSetter<Vector4> setter = t.setter;
			t.setter((Vector4)(nint)setter.method);
			return;
			IL_05c1:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num6;
			double num8;
			double num9 = default(double);
			double num10;
			double num7;
			if (num4 < 0f)
			{
				if ((double)num4 != -0.5)
				{
					double a = (double)num4 + -0.5;
					num6 = Math.Ceiling(a);
					num7 = -0.5;
					goto IL_06f2;
				}
				num8 = num9;
				num10 = -1.0;
			}
			else
			{
				if ((double)num4 != 0.5)
				{
					double d = (double)num4 + 0.5;
					num6 = Math.Floor(d);
					num7 = 0.5;
					goto IL_06f2;
				}
				num8 = num9;
				num10 = 1.0;
			}
			num7 = num8 + num10;
			num6 = (((num8 & 1) != 0) ? num7 : num8);
			goto IL_06f2;
			IL_0801:
			double num11;
			vector2 = (Vector4)num11;
			double num12;
			num3 = (float)num12;
			num4 = (float)num6;
			double num13;
			num5 = (float)num13;
			goto IL_09d2;
			IL_085b:
			if (t.plugOptions.snapping)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num15;
				double num16;
				double num14;
				if (vector2.x < 0f)
				{
					if ((double)vector2.x != -0.5)
					{
						double a2 = (double)vector2.x + -0.5;
						num11 = Math.Ceiling(a2);
						num14 = -0.5;
						goto IL_0490;
					}
					num15 = num9;
					num16 = -1.0;
				}
				else
				{
					if ((double)vector2.x != 0.5)
					{
						double d2 = (double)vector2.x + 0.5;
						num11 = Math.Floor(d2);
						num14 = 0.5;
						goto IL_0490;
					}
					num15 = num9;
					num16 = 1.0;
				}
				num14 = num15 + num16;
				num11 = (((num15 & 1) != 0) ? num14 : num15);
				goto IL_0490;
			}
			goto IL_09d2;
			IL_0490:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num18;
			double num19;
			double num17;
			if (num3 < 0f)
			{
				if ((double)num3 != -0.5)
				{
					double a3 = (double)num3 + -0.5;
					num12 = Math.Ceiling(a3);
					num17 = -0.5;
					goto IL_05c1;
				}
				num18 = num9;
				num19 = -1.0;
			}
			else
			{
				if ((double)num3 != 0.5)
				{
					double d3 = (double)num3 + 0.5;
					num12 = Math.Floor(d3);
					num17 = 0.5;
					goto IL_05c1;
				}
				num18 = num9;
				num19 = 1.0;
			}
			num17 = num18 + num19;
			num12 = (((num18 & 1) != 0) ? num17 : num18);
			goto IL_05c1;
			IL_06f2:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num20;
			if (num5 < 0f)
			{
				if ((double)num5 != -0.5)
				{
					double a4 = (double)num5 + -0.5;
					num13 = Math.Ceiling(a4);
					goto IL_0801;
				}
				num13 = num9;
				num20 = -1.0;
			}
			else
			{
				if ((double)num5 != 0.5)
				{
					double d4 = (double)num5 + 0.5;
					num13 = Math.Floor(d4);
					goto IL_0801;
				}
				num13 = num9;
				num20 = 1.0;
			}
			double num21 = num13 + num20;
			if ((num13 & 1) != 0)
			{
				num13 = num21;
			}
			goto IL_0801;
		}

		[Token(Token = "0x6000343")]
		[Address(RVA = "0xC251B4", Offset = "0xC251B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector4 ConvertToStartValue(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 value)
		{
			return value;
		}

		[Token(Token = "0x6000344")]
		[Address(RVA = "0xC251B8", Offset = "0xC251B8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue + t.startValue;\n\tt.endValue = v7;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector4, Vector4, VectorOptions> t)
		{
			//IL_0030: Expected O, but got F4
			float num = t.endValue.x + t.startValue.x;
			t.endValue = (Vector4)num;
		}

		[Token(Token = "0x6000345")]
		[Address(RVA = "0xC251DC", Offset = "0xC251DC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = t.plugOptions <= 4;\n\tif (v16) goto L_0032;\n\tv37 = t.plugOptions == 8;\n\tif (v37) goto L_005A;\n\tv60 = t.plugOptions != 0x10;\n\tif (v60) goto L_0051;\n\tv97 = t.endValue.w - t.startValue.w;\n\tgoto L_0062;\nL_0032:\n\tv46 = t.plugOptions == 2;\n\tif (v46) goto L_0060;\n\tv75 = t.plugOptions != 4;\n\tif (v75) goto L_0051;\n\tv93 = t.endValue.y - t.startValue.y;\n\tgoto L_FFFFFFFF;\nL_0051:\n\tv95 = t.endValue - t.startValue;\n\tv93 = t.endValue.y - t.startValue.y;\n\tv99 = t.endValue.z - t.startValue.z;\n\tv97 = t.endValue.w - t.startValue.w;\n\tgoto L_0062;\nL_005A:\n\tv99 = t.endValue.z - t.startValue.z;\n\tgoto L_FFFFFFFF;\nL_0060:\n\tv95 = t.endValue - t.startValue;\nL_0062:\n\tt.changeValue.x = v95;\n\tt.changeValue.y = v93;\n\tt.changeValue.z = v99;\n\tt.changeValue.w = v97;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector4, Vector4, VectorOptions> t)
		{
			float w;
			float y;
			float x;
			float z;
			if ((nint)t.plugOptions > 4)
			{
				if ((nint)t.plugOptions != 8)
				{
					if ((nint)t.plugOptions != 16)
					{
						goto IL_0130;
					}
					w = t.endValue.w - t.startValue.w;
					y = 0f;
					x = 0f;
					z = 0f;
					goto IL_0235;
				}
				z = t.endValue.z - t.startValue.z;
				y = 0f;
				x = 0f;
			}
			else if ((nint)t.plugOptions != 2)
			{
				if ((nint)t.plugOptions != 4)
				{
					goto IL_0130;
				}
				y = t.endValue.y - t.startValue.y;
				x = 0f;
				z = 0f;
			}
			else
			{
				x = t.endValue.x - t.startValue.x;
				y = 0f;
				z = 0f;
			}
			w = 0f;
			goto IL_0235;
			IL_0235:
			t.changeValue.x = x;
			t.changeValue.y = y;
			t.changeValue.z = z;
			t.changeValue.w = w;
			return;
			IL_0130:
			x = t.endValue.x - t.startValue.x;
			y = t.endValue.y - t.startValue.y;
			z = t.endValue.z - t.startValue.z;
			w = t.endValue.w - t.startValue.w;
			goto IL_0235;
		}

		[Token(Token = "0x6000346")]
		[Address(RVA = "0xC252C4", Offset = "0xC252C4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv29 = System.Math;\n\tv30 = \"il2cpp_codegen_initialize_runtime_metadata\"(v29, options, methodInfo, v33, v34, v35, v36, v37, unitsXSecond, changeValue, v0, v2, v3, v38, v39, v40);\n\tv44 = 1;\n\t*([1A357E3]) = v44;\nL_0020:\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, options, methodInfo, v33, v34, v35, v36, v37, unitsXSecond, changeValue, v0, v2, v3, v38, v39, v40);\nL_0022:\n\tv53 = changeValue * changeValue;\n\tv54 = changeValue.y * changeValue.y;\n\tv55 = changeValue.z * changeValue.z;\n\tv56 = v53 + v54;\n\tv57 = changeValue.w * changeValue.w;\n\tv58 = v55 + v56;\n\tv59 = v57 + v58;\n\tv60 = UnityEngine.Mathf::Sqrt(v59);\n\treturnVal1 = v60 / unitsXSecond;\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector4 changeValue)
		{
			Vector4 vector = default(Vector4);
			float num = vector.x * vector.x;
			float num2 = changeValue.y * changeValue.y;
			float num3 = changeValue.z * changeValue.z;
			float num4 = num + num2;
			float num5 = changeValue.w * changeValue.w;
			float num6 = num3 + num4;
			float f = num5 + num6;
			float num7 = Mathf.Sqrt(f);
			return num7 / unitsXSecond;
		}

		[Token(Token = "0x6000347")]
		[Address(RVA = "0xC25358", Offset = "0xC25358", Length = "0x724")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv301 = startValue.w;\n\tgoto L_0039;\n\tv64 = System.Math;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, options, t, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v42, startValue, v0, v2, v3, v37, v69, v70);\n\tv74 = 1;\n\t*([1A35785]) = v74;\nL_0039:\n\tv86 = t.loopType != 2;\n\tif (v86) goto L_004B;\n\tv316 = t.completedLoops - t.isComplete;\n\tv318 = changeValue * v316;\n\tv319 = v38 * v316;\n\tv320 = updateNotice * v316;\n\tv321 = v43 * v316;\n\tv243 = startValue + v318;\n\tv251 = startValue.y + v319;\n\tv259 = startValue.z + v320;\n\tv267 = startValue.w + v321;\nL_004B:\n\tv328 = ~t.isSequenced;\n\tif (v328) goto L_0085;\n\tv122 = t.sequenceParent;\n\tv335 = v122.loopType != 2;\n\tif (v335) goto L_0085;\n\tv334 = t.loopType != 2;\n\tif (v334) goto L_FFFFFFFF;\n\tv464 = t.loops;\n\tgoto L_006F;\nL_006F:\n\tv469 = changeValue * v464;\n\tv367 = v122.completedLoops - v122.isComplete;\n\tv471 = v38 * v464;\n\tv472 = updateNotice * v464;\n\tv473 = v43 * v464;\n\tv330 = v469 * v367;\n\tv372 = v471 * v367;\n\tv370 = v472 * v367;\n\tv366 = v473 * v367;\n\tv243 = v243 + v330;\n\tv251 = v251 + v372;\n\tv259 = v259 + v370;\n\tv267 = v267 + v366;\nL_0085:\n\tv429 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv128 = options <= 4;\n\tif (v128) goto L_00E2;\n\tv182 = options == 8;\n\tif (v182) goto L_0160;\n\tv126 = options != 0x10;\n\tif (v126) goto L_012A;\n\tv509 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv511 = v43 * v429;\n\tv787 = v267 + v511;\n\tv513 = options & 0x100000000;\n\tv514 = v513 == 0;\n\tif (v514) goto L_032E;\n\tgoto L_00C3;\n\tv685 = \"il2cpp_codegen_runtime_class_init\"(v605, v105, v95, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v511, v111, v308, v304, v301, v37, v69, v70);\nL_00C3:\n\tv621 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v787, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod, v301, v38, v69, v70);\n\tv807 = v787 >= 0;\n\tif (v807) goto L_01E9;\n\tv895 = v787 != -0.5d;\n\tif (v895) goto L_031D;\n\tgoto L_01EE;\nL_00E2:\n\tv183 = options == 2;\n\tif (v183) goto L_0194;\n\tv127 = options != 4;\n\tif (v127) goto L_012A;\n\tv572 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv574 = v38 * v429;\n\tv253 = v251 + v574;\n\tv576 = options & 0x100000000;\n\tv577 = v576 == 0;\n\tif (v577) goto L_033A;\n\tgoto L_010D;\n\tv743 = \"il2cpp_codegen_runtime_class_init\"(v651, v106, v95, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v574, v111, v308, v304, v301, v37, v69, v70);\nL_010D:\n\tv667 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v253, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod, v301, v38, v69, v70);\n\tv862 = v253 >= 0;\n\tif (v862) goto L_0205;\n\tv933 = v253 != -0.5d;\n\tif (v933) goto L_0320;\n\tgoto L_020A;\nL_012A:\n\tv485 = changeValue * v429;\n\tv309 = updateNotice * v429;\n\tv246 = v243 + v485;\n\tv487 = v38 * v429;\n\tv305 = v43 * v429;\n\tv254 = v251 + v487;\n\tv723 = v259 + v309;\n\tv787 = v267 + v305;\n\tv491 = options & 0x100000000;\n\tv492 = v491 == 0;\n\tif (v492) goto L_0317;\n\tgoto L_0140;\n\tv628 = \"il2cpp_codegen_runtime_class_init\"(v517, v104, v95, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v485, v487, v309, v305, v301, v37, v69, v70);\nL_0140:\n\tv634 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v246, v487, v309, v305, v301, v38, v69, v70);\n\tv704 = v246 >= 0;\n\tif (v704) goto L_01CD;\n\tv819 = v246 != -0.5d;\n\tif (v819) goto L_024F;\n\tgoto L_01D2;\nL_0160:\n\tv495 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv496 = updateNotice * v429;\n\tv723 = v259 + v496;\n\tv498 = options & 0x100000000;\n\tv499 = v498 == 0;\n\tif (v499) goto L_0347;\n\tgoto L_0174;\n\tv640 = \"il2cpp_codegen_runtime_class_init\"(v547, v107, v95, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v496, v111, v308, v304, v301, v37, v69, v70);\nL_0174:\n\tv563 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v723, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod, v301, v38, v69, v70);\n\tv742 = v723 >= 0;\n\tif (v742) goto L_0221;\n\tv841 = v723 != -0.5d;\n\tif (v841) goto L_0323;\n\tgoto L_0226;\nL_0194:\n\tv502 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::Invoke(getter);\n\tv503 = changeValue * v429;\n\tv248 = v243 + v503;\n\tv505 = options & 0x100000000;\n\tv506 = v505 == 0;\n\tif (v506) goto L_0363;\n\tgoto L_01A8;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v580, v108, v95, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v503, v111, v308, v304, v301, v37, v69, v70);\nL_01A8:\n\tv596 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v248, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod, v301, v38, v69, v70);\n\tv763 = v248 >= 0;\n\tif (v763) goto L_023D;\n\tv873 = v248 != -0.5d;\n\tif (v873) goto L_0326;\n\tgoto L_0242;\nL_01CD:\n\tv830 = v246 != 0.5d;\n\tif (v830) goto L_0252;\nL_01D2:\n\tv981 = v971 + v961;\n\tv974 = v971 & 1;\n\tv976 = v974 == 0;\n\tv979 = ~v976;\n\tif (v979) goto L_01DE;\n\tgoto L_01DE;\nL_01DE:\n\tgoto L_0257;\nL_01E9:\n\tv906 = v787 != 0.5d;\n\tif (v906) goto L_0329;\nL_01EE:\n\t;\n\tv1061 = v625 & 1;\n\tv1063 = v1061 == 0;\n\tv1066 = ~v1063;\n\tif (v1066) goto L_01FA;\n\tgoto L_01FA;\nL_01FA:\n\tgoto L_032E;\nL_0205:\n\tv944 = v253 != 0.5d;\n\tif (v944) goto L_0335;\nL_020A:\n\t;\n\tv1095 = v671 & 1;\n\tv1097 = v1095 == 0;\n\tv1100 = ~v1097;\n\tif (v1100) goto L_0216;\n\tgoto L_0216;\nL_0216:\n\tgoto L_033A;\nL_0221:\n\tv852 = v723 != 0.5d;\n\tif (v852) goto L_0342;\nL_0226:\n\t;\n\tv1013 = v567 & 1;\n\tv1015 = v1013 == 0;\n\tv1018 = ~v1015;\n\tif (v1018) goto L_0232;\n\tgoto L_0232;\nL_0232:\n\tgoto L_0347;\nL_023D:\n\tv884 = v248 != 0.5d;\n\tif (v884) goto L_035E;\nL_0242:\n\t;\n\tv1041 = v600 & 1;\n\tv1043 = v1041 == 0;\n\tv1046 = ~v1043;\n\tif (v1046) goto L_024E;\n\tgoto L_024E;\nL_024E:\n\tgoto L_0363;\nL_024F:\n\tv909 = v246 + -0.5d;\n\tv544 = System.Math::Ceiling(v909);\n\tgoto L_0257;\nL_0252:\n\tv913 = v246 + 0.5d;\n\tv544 = System.Math::Floor(v913);\nL_0257:\n\tv999 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v254, v981, v309, v305, v301, v38, v69, v70);\n\tv1079 = v254 >= 0;\n\tif (v1079) goto L_027C;\n\tv1116 = v254 != -0.5d;\n\tif (v1116) goto L_028E;\n\tgoto L_0281;\nL_027C:\n\tv1127 = v254 != 0.5d;\n\tif (v1127) goto L_0291;\nL_0281:\n\tv1158 = v1148 + v1138;\n\tv1151 = v1148 & 1;\n\tv1153 = v1151 == 0;\n\tv1156 = ~v1153;\n\tif (v1156) goto L_028D;\n\tgoto L_028D;\nL_028D:\n\tgoto L_0296;\nL_028E:\n\tv1132 = v254 + -0.5d;\n\tv540 = System.Math::Ceiling(v1132);\n\tgoto L_0296;\nL_0291:\n\tv1136 = v254 + 0.5d;\n\tv540 = System.Math::Floor(v1136);\nL_0296:\n\tv1176 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v723, v1158, v309, v305, v301, v38, v69, v70);\n\tv1188 = v723 >= 0;\n\tif (v1188) goto L_02BB;\n\tv1199 = v723 != -0.5d;\n\tif (v1199) goto L_02CD;\n\tgoto L_02C0;\nL_02BB:\n\tv1210 = v723 != 0.5d;\n\tif (v1210) goto L_02D0;\nL_02C0:\n\tv1239 = v1229 + v1219;\n\tv1232 = v1229 & 1;\n\tv1234 = v1232 == 0;\n\tv1237 = ~v1234;\n\tif (v1237) goto L_02CC;\n\tgoto L_02CC;\nL_02CC:\n\tgoto L_02D5;\nL_02CD:\n\tv1213 = v723 + -0.5d;\n\tv542 = System.Math::Ceiling(v1213);\n\tgoto L_02D5;\nL_02D0:\n\tv1217 = v723 + 0.5d;\n\tv542 = System.Math::Floor(v1217);\nL_02D5:\n\tv533 = 0x1854ED0(&v552 @ stack_-78_v15 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v787, v1239, v309, v305, v301, v38, v69, v70);\n\tv1267 = v787 >= 0;\n\tif (v1267) goto L_02FA;\n\tv1278 = v787 != -0.5d;\n\tif (v1278) goto L_030C;\n\tgoto L_02FF;\nL_02FA:\n\tv1289 = v787 != 0.5d;\n\tif (v1289) goto L_030F;\nL_02FF:\n\t;\n\tv1311 = v541 & 1;\n\tv1313 = v1311 == 0;\n\tv1316 = ~v1313;\n\tif (v1316) goto L_030B;\n\tgoto L_030B;\nL_030B:\n\tgoto L_0317;\nL_030C:\n\tv1292 = v787 + -0.5d;\n\tv541 = System.Math::Ceiling(v1292);\n\t\n// ... truncated")]
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector4> getter, DOSetter<Vector4> setter, float elapsed, Vector4 startValue, Vector4 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0d68: Expected F4, but got I
			//IL_00a5: Expected O, but got I
			//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c8: Expected I4, but got Unknown
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ff: Expected I4, but got Unknown
			//IL_0429: Unknown result type (might be due to invalid IL or missing references)
			//IL_042e: Expected I4, but got Unknown
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Expected I4, but got Unknown
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected I4, but got Unknown
			//IL_0dc6: Expected O, but got I
			//IL_0e01: Expected O, but got I
			//IL_0f5d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f62: Expected I4, but got Unknown
			//IL_0f26: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f2b: Expected I4, but got Unknown
			//IL_0eef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef4: Expected I4, but got Unknown
			//IL_0eaa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0eaf: Expected I4, but got Unknown
			//IL_0e73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e78: Expected I4, but got Unknown
			//IL_0fbb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fc0: Expected I4, but got Unknown
			//IL_1005: Unknown result type (might be due to invalid IL or missing references)
			//IL_100a: Expected I4, but got Unknown
			//IL_1041: Unknown result type (might be due to invalid IL or missing references)
			//IL_1046: Expected I4, but got Unknown
			float w = startValue.w;
			bool flag = t.loopType != LoopType.Incremental;
			Vector4 vector = default(Vector4);
			float num = vector.x;
			float num2 = startValue.y;
			float num3 = startValue.z;
			float num4 = startValue.w;
			Vector4 vector2 = default(Vector4);
			object obj2 = default(object);
			float num9 = default(float);
			if (!flag)
			{
				int num5 = t.completedLoops - (t.isComplete ? 1 : 0);
				float num6 = vector2.x * (float)num5;
				object obj = (nint)obj2 * num5;
				int num7 = (int)updateNotice * num5;
				float num8 = num9 * (float)num5;
				num = vector.x + num6;
				num2 = startValue.y + (float)obj;
				num3 = startValue.z + (float)num7;
				num4 = startValue.w + num8;
				w = num9;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num10 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					float num11 = vector2.x * (float)num10;
					int num12 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					object obj3 = (nint)obj2 * num10;
					int num13 = (int)updateNotice * num10;
					float num14 = num9 * (float)num10;
					float num15 = num11 * (float)num12;
					object obj4 = (nint)obj3 * num12;
					int num16 = num13 * num12;
					float num17 = num14 * (float)num12;
					num += num15;
					num2 += (float)obj4;
					num3 += (float)num16;
					num4 += num17;
					w = num12;
				}
			}
			IntPtr intPtr = default(IntPtr);
			float num18 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, (nint)intPtr, t.easeOvershootOrAmplitude, t.easePeriod);
			double num22 = default(double);
			float num20;
			float num24;
			if ((nint)options > 4)
			{
				if ((nint)options == 8)
				{
					object obj5 = getter();
					float num19 = (float)updateNotice * num18;
					num20 = num3 + num19;
					if ((int)(options & 0x100000000L) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
						double num21;
						if (num20 < 0f)
						{
							if ((double)num20 != -0.5)
							{
								double a = (double)num20 + -0.5;
								num21 = Math.Ceiling(a);
								goto IL_0c8e;
							}
							num21 = num22;
						}
						else
						{
							if ((double)num20 != 0.5)
							{
								double d = (double)num20 + 0.5;
								num21 = Math.Floor(d);
								goto IL_0c8e;
							}
							num21 = num22;
						}
						if ((num21 & 1) != 0)
						{
						}
					}
					goto IL_0c8e;
				}
				if ((nint)options == 16)
				{
					object obj6 = getter();
					float num23 = num9 * num18;
					num24 = num4 + num23;
					if ((int)(options & 0x100000000L) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
						double num25;
						if (num24 < 0f)
						{
							if ((double)num24 != -0.5)
							{
								double a2 = (double)num24 + -0.5;
								num25 = Math.Ceiling(a2);
								goto IL_0bea;
							}
							num25 = num22;
						}
						else
						{
							if ((double)num24 != 0.5)
							{
								double d2 = (double)num24 + 0.5;
								num25 = Math.Floor(d2);
								goto IL_0bea;
							}
							num25 = num22;
						}
						if ((num25 & 1) != 0)
						{
						}
					}
					goto IL_0bea;
				}
			}
			else
			{
				if ((nint)options == 2)
				{
					object obj7 = getter();
					float num26 = vector2.x * num18;
					float num27 = num + num26;
					if ((int)(options & 0x100000000L) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
						double num28;
						if (num27 < 0f)
						{
							if ((double)num27 != -0.5)
							{
								double a3 = (double)num27 + -0.5;
								num28 = Math.Ceiling(a3);
								goto IL_0ced;
							}
							num28 = num22;
						}
						else
						{
							if ((double)num27 != 0.5)
							{
								double d3 = (double)num27 + 0.5;
								num28 = Math.Floor(d3);
								goto IL_0ced;
							}
							num28 = num22;
						}
						if ((num28 & 1) != 0)
						{
						}
					}
					goto IL_0ced;
				}
				if ((nint)options == 4)
				{
					object obj8 = getter();
					float num29 = (float)obj2 * num18;
					float num30 = num2 + num29;
					if ((int)(options & 0x100000000L) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
						double num31;
						if (num30 < 0f)
						{
							if ((double)num30 != -0.5)
							{
								double a4 = (double)num30 + -0.5;
								num31 = Math.Ceiling(a4);
								goto IL_0c3c;
							}
							num31 = num22;
						}
						else
						{
							if ((double)num30 != 0.5)
							{
								double d4 = (double)num30 + 0.5;
								num31 = Math.Floor(d4);
								goto IL_0c3c;
							}
							num31 = num22;
						}
						if ((num31 & 1) != 0)
						{
						}
					}
					goto IL_0c3c;
				}
			}
			float num32 = vector2.x * num18;
			float num33 = (float)updateNotice * num18;
			float num34 = num + num32;
			float num35 = (float)obj2 * num18;
			float num36 = num9 * num18;
			float num37 = num2 + num35;
			num20 = num3 + num33;
			num24 = num4 + num36;
			if ((int)(options & 0x100000000L) != 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num40;
				double num41;
				double num39;
				if (num34 < 0f)
				{
					if ((double)num34 != -0.5)
					{
						double a5 = (double)num34 + -0.5;
						double num38 = Math.Ceiling(a5);
						num39 = -0.5;
						goto IL_07de;
					}
					num40 = -1.0;
					num41 = num22;
				}
				else
				{
					if ((double)num34 != 0.5)
					{
						double d5 = (double)num34 + 0.5;
						double num38 = Math.Floor(d5);
						num39 = 0.5;
						goto IL_07de;
					}
					num40 = 1.0;
					num41 = num22;
				}
				num39 = num41 + num40;
				if ((num41 & 1) != 0)
				{
				}
				goto IL_07de;
			}
			goto IL_0b00;
			IL_08fa:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num44;
			double num45;
			double num43;
			if (num20 < 0f)
			{
				if ((double)num20 != -0.5)
				{
					double a6 = (double)num20 + -0.5;
					double num42 = Math.Ceiling(a6);
					num43 = -0.5;
					goto IL_0a16;
				}
				num44 = -1.0;
				num45 = num22;
			}
			else
			{
				if ((double)num20 != 0.5)
				{
					double d6 = (double)num20 + 0.5;
					double num42 = Math.Floor(d6);
					num43 = 0.5;
					goto IL_0a16;
				}
				num44 = 1.0;
				num45 = num22;
			}
			num43 = num45 + num44;
			if ((num45 & 1) != 0)
			{
			}
			goto IL_0a16;
			IL_0c8e:
			IntPtr invoke_impl = setter.invoke_impl;
			IntPtr method_code = setter.method_code;
			IntPtr method = setter.method;
			num24 = t.easePeriod;
			goto IL_1073;
			IL_1073:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v379 @ X2_v3 (System.IntPtr) (should have been resolved before IL gen)");
			return;
			IL_0bea:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			goto IL_1073;
			IL_0ced:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			goto IL_1073;
			IL_0a16:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num46;
			if (num24 < 0f)
			{
				if ((double)num24 != -0.5)
				{
					double a7 = (double)num24 + -0.5;
					num46 = Math.Ceiling(a7);
					goto IL_0b00;
				}
				num46 = num22;
			}
			else
			{
				if ((double)num24 != 0.5)
				{
					double d7 = (double)num24 + 0.5;
					num46 = Math.Floor(d7);
					goto IL_0b00;
				}
				num46 = num22;
			}
			if ((num46 & 1) != 0)
			{
			}
			goto IL_0b00;
			IL_0b00:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			goto IL_1073;
			IL_0c3c:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			goto IL_1073;
			IL_07de:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num49;
			double num50;
			double num48;
			if (num37 < 0f)
			{
				if ((double)num37 != -0.5)
				{
					double a8 = (double)num37 + -0.5;
					double num47 = Math.Ceiling(a8);
					num48 = -0.5;
					goto IL_08fa;
				}
				num49 = -1.0;
				num50 = num22;
			}
			else
			{
				if ((double)num37 != 0.5)
				{
					double d8 = (double)num37 + 0.5;
					double num47 = Math.Floor(d8);
					num48 = 0.5;
					goto IL_08fa;
				}
				num49 = 1.0;
				num50 = num22;
			}
			num48 = num50 + num49;
			if ((num50 & 1) != 0)
			{
			}
			goto IL_08fa;
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0xC25A7C", Offset = "0xC25A7C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35786]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector4Plugin()
		{
		}
	}
}
