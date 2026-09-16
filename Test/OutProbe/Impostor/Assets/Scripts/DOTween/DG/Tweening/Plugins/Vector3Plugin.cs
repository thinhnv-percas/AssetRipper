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
	[Token(Token = "0x2000086")]
	public class Vector3Plugin : ABSTweenPlugin<Vector3, Vector3, VectorOptions>
	{
		[Token(Token = "0x6000361")]
		[Address(RVA = "0xC274A8", Offset = "0xC274A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
		}

		[Token(Token = "0x6000362")]
		[Address(RVA = "0xC274AC", Offset = "0xC274AC", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = System.Math;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, t, isRelative, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35795]) = v46;\nL_0019:\n\tv48 = t.getter;\n\tv240 = t.endValue.y;\n\tv238 = t.endValue.z;\n\tv119 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv96 = t.endValue + v35;\n\tv94 = t.endValue.y + v36;\n\tv92 = t.endValue.z + v37;\n\tv123 = isRelative == 0;\n\tv126 = ~v123;\n\tv127 = ~v126;\n\tif (v127) goto L_0033;\n\tgoto L_0033;\nL_0033:\n\tv178 = ~v123;\n\tv179 = ~v178;\n\tif (v179) goto L_003A;\n\tgoto L_003A;\nL_003A:\n\tv183 = ~v123;\n\tv184 = ~v183;\n\tif (v184) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tv192 = t.plugOptions == 2;\n\tt.endValue.x = v35;\n\tt.endValue.y = v36;\n\tt.endValue.z = v37;\n\tt.startValue.x = v241;\n\tt.startValue.y = v240;\n\tt.startValue.z = v238;\n\tif (v192) goto L_FFFFFFFF;\n\tv201 = t.plugOptions == 8;\n\tif (v201) goto L_FFFFFFFF;\n\tv217 = t.plugOptions != 4;\n\tif (v217) goto L_006E;\n\tgoto L_FFFFFFFF;\n\tgoto L_006E;\nL_006E:\n\tv244 = ~t.plugOptions.snapping;\n\tif (v244) goto L_0138;\n\tgoto L_007B;\n\tv275 = \"il2cpp_codegen_runtime_class_init\"(v248, v104, isRelative, methodInfo, v31, v32, v33, v34, v35, v36, v37, v96, v94, v92, v41, v42);\nL_007B:\n\tv281 = 0x1854ED0(&v279 @ stack_-48_v3 (System.Double), v48.method, isRelative, methodInfo, v31, v32, v33, v34, v241, v36, v37, v96, v94, v92, v41, v42);\n\tv291 = v241 >= 0;\n\tif (v291) goto L_00A0;\n\tv302 = v241 != -0.5d;\n\tif (v302) goto L_00B2;\n\tgoto L_00A5;\nL_00A0:\n\tv313 = v241 != 0.5d;\n\tif (v313) goto L_00B5;\nL_00A5:\n\tv341 = v323 + v322;\n\tv335 = v323 & 1;\n\tv337 = v335 == 0;\n\tv340 = ~v337;\n\tif (v340) goto L_FFFFFFFF;\n\tgoto L_00B1;\nL_00B1:\n\tgoto L_00BA;\nL_00B2:\n\tv316 = v241 + -0.5d;\n\tv256 = System.Math::Ceiling(v316);\n\tgoto L_00BA;\nL_00B5:\n\tv320 = v241 + 0.5d;\n\tv256 = System.Math::Floor(v320);\nL_00BA:\n\tv360 = 0x1854ED0(&v279 @ stack_-48_v3 (System.Double), v48.method, isRelative, methodInfo, v31, v32, v33, v34, v240, v341, v37, v96, v94, v92, v41, v42);\n\tv372 = v240 >= 0;\n\tif (v372) goto L_00DF;\n\tv383 = v240 != -0.5d;\n\tif (v383) goto L_00F1;\n\tgoto L_00E4;\nL_00DF:\n\tv394 = v240 != 0.5d;\n\tif (v394) goto L_00F4;\nL_00E4:\n\tv423 = v404 + v403;\n\tv416 = v404 & 1;\n\tv418 = v416 == 0;\n\tv421 = ~v418;\n\tif (v421) goto L_FFFFFFFF;\n\tgoto L_00F0;\nL_00F0:\n\tgoto L_00F9;\nL_00F1:\n\tv397 = v240 + -0.5d;\n\tv252 = System.Math::Ceiling(v397);\n\tgoto L_00F9;\nL_00F4:\n\tv401 = v240 + 0.5d;\n\tv252 = System.Math::Floor(v401);\nL_00F9:\n\tv270 = 0x1854ED0(&v279 @ stack_-48_v3 (System.Double), v48.method, isRelative, methodInfo, v31, v32, v33, v34, v238, v423, v37, v96, v94, v92, v41, v42);\n\tv451 = v238 >= 0;\n\tif (v451) goto L_011E;\n\tv462 = v238 != -0.5d;\n\tif (v462) goto L_0130;\n\tgoto L_0123;\nL_011E:\n\tv473 = v238 != 0.5d;\n\tif (v473) goto L_0133;\nL_0123:\n\tv494 = v254 + v482;\n\tv495 = v254 & 1;\n\tv497 = v495 == 0;\n\tv500 = ~v497;\n\tif (v500) goto L_FFFFFFFF;\n\tgoto L_012F;\nL_012F:\n\tgoto L_FFFFFFFF;\nL_0130:\n\tv476 = v238 + -0.5d;\n\tv254 = System.Math::Ceiling(v476);\n\tgoto L_FFFFFFFF;\nL_0133:\n\tv480 = v238 + 0.5d;\n\tv254 = System.Math::Floor(v480);\nL_0138:\n\tv113 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(t.setter, v113.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, bool isRelative)
		{
			//IL_0529: Expected O, but got I
			//IL_0648: Unknown result type (might be due to invalid IL or missing references)
			//IL_064d: Expected I4, but got Unknown
			//IL_0692: Unknown result type (might be due to invalid IL or missing references)
			//IL_0697: Expected I4, but got Unknown
			//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e1: Expected I4, but got Unknown
			DOGetter<Vector3> getter = t.getter;
			float num = t.endValue.y;
			float num2 = t.endValue.z;
			object obj = t.getter();
			float num4 = default(float);
			float num3 = t.endValue.x + num4;
			float num6 = default(float);
			float num5 = t.endValue.y + num6;
			float num8 = default(float);
			float num7 = t.endValue.z + num8;
			bool flag = !isRelative;
			if (!flag)
			{
				num2 = num7;
			}
			if (!flag)
			{
				num = num5;
			}
			float num9 = (flag ? t.endValue.x : num3);
			bool flag2 = (nint)t.plugOptions == 2;
			t.endValue.x = num4;
			t.endValue.y = num6;
			t.endValue.z = num8;
			t.startValue.x = num9;
			t.startValue.y = num;
			t.startValue.z = num2;
			if (!flag2)
			{
				if ((nint)t.plugOptions != 8)
				{
					if ((nint)t.plugOptions != 4)
					{
						goto IL_0600;
					}
					num2 = num8;
				}
				else
				{
					num = num6;
				}
				num9 = num4;
			}
			else
			{
				num2 = num8;
				num = num6;
			}
			goto IL_0600;
			IL_04f5:
			double num10;
			num2 = (float)num10;
			double num11;
			num = (float)num11;
			double num12;
			num9 = (float)num12;
			goto IL_070e;
			IL_03e6:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num13;
			double num14 = default(double);
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a = (double)num2 + -0.5;
					num10 = Math.Ceiling(a);
					goto IL_04f5;
				}
				num13 = -1.0;
				num10 = num14;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d = (double)num2 + 0.5;
					num10 = Math.Floor(d);
					goto IL_04f5;
				}
				num13 = 1.0;
				num10 = num14;
			}
			double num15 = num10 + num13;
			if ((num10 & 1) != 0)
			{
				num10 = num15;
			}
			goto IL_04f5;
			IL_070e:
			DOSetter<Vector3> setter = t.setter;
			t.setter((Vector3)(nint)setter.method);
			return;
			IL_0600:
			if (t.plugOptions.snapping)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num17;
				double num18;
				double num16;
				if (num9 < 0f)
				{
					if ((double)num9 != -0.5)
					{
						double a2 = (double)num9 + -0.5;
						num12 = Math.Ceiling(a2);
						num16 = -0.5;
						goto IL_02b5;
					}
					num17 = -1.0;
					num18 = num14;
				}
				else
				{
					if ((double)num9 != 0.5)
					{
						double d2 = (double)num9 + 0.5;
						num12 = Math.Floor(d2);
						num16 = 0.5;
						goto IL_02b5;
					}
					num17 = 1.0;
					num18 = num14;
				}
				num16 = num18 + num17;
				num12 = (((num18 & 1) != 0) ? num16 : num18);
				goto IL_02b5;
			}
			goto IL_070e;
			IL_02b5:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num20;
			double num21;
			double num19;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a3 = (double)num + -0.5;
					num11 = Math.Ceiling(a3);
					num19 = -0.5;
					goto IL_03e6;
				}
				num20 = -1.0;
				num21 = num14;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d3 = (double)num + 0.5;
					num11 = Math.Floor(d3);
					num19 = 0.5;
					goto IL_03e6;
				}
				num20 = 1.0;
				num21 = num14;
			}
			num19 = num21 + num20;
			num11 = (((num21 & 1) != 0) ? num19 : num21);
			goto IL_03e6;
		}

		[Token(Token = "0x6000363")]
		[Address(RVA = "0xC27728", Offset = "0xC27728", Length = "0x308")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv161 = v122.y;\n\tgoto L_001F;\n\tv38 = System.Math;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, t, setImmediately, isRelative, methodInfo, v41, v42, v43, fromValue, v0, v2, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A35796]) = v52;\nL_001F:\n\tv54 = isRelative == 0;\n\tif (v54) goto L_FFFFFFFF;\n\tv57 = t.getter;\n\tv170 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv172 = v122 + v122;\n\tv277 = v122.y + v122.y;\n\tv164 = t.endValue + v122;\n\tv161 = v122.z + t.endValue.z;\n\tt.endValue = v164;\n\tt.endValue.z = v161;\n\tv154 = v122.z + v122.z;\n\tgoto L_0037;\nL_0037:\n\tt.startValue.x = v275;\n\tt.startValue.y = v277;\n\tt.startValue.z = v154;\n\tv178 = setImmediately == 0;\n\tif (v178) goto L_0071;\n\tv100 = t.plugOptions == 8;\n\tif (v100) goto L_0072;\n\tv101 = t.plugOptions == 4;\n\tif (v101) goto L_007C;\n\tv71 = t.plugOptions != 2;\n\tif (v71) goto L_0086;\n\tv156 = t.getter;\n\tv268 = v156.method;\n\tv292 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(v156);\n\tgoto L_FFFFFFFF;\nL_0071:\n\treturn;\nL_0072:\n\tv157 = t.getter;\n\tv247 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tgoto L_0086;\nL_007C:\n\tv158 = t.getter;\n\tv268 = v158.method;\n\tv287 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(v158);\nL_0086:\n\tv283 = ~t.plugOptions.snapping;\n\tif (v283) goto L_0150;\n\tgoto L_0093;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v296, v133, setImmediately, isRelative, methodInfo, v41, v42, v43, v122, v161, v2, v130, v128, v46, v47, v48);\nL_0093:\n\tv329 = 0x1854ED0(&v327 @ stack_-58_v3 (System.Double), v133, setImmediately, isRelative, methodInfo, v41, v42, v43, v275, v161, v122.z, t.endValue, t.endValue.z, v46, v47, v48);\n\tv339 = v275 >= 0;\n\tif (v339) goto L_00B8;\n\tv350 = v275 != -0.5d;\n\tif (v350) goto L_00CA;\n\tgoto L_00BD;\nL_00B8:\n\tv361 = v275 != 0.5d;\n\tif (v361) goto L_00CD;\nL_00BD:\n\tv403 = v379 + v380;\n\tv383 = v379 & 1;\n\tv385 = v383 == 0;\n\tv388 = ~v385;\n\tif (v388) goto L_FFFFFFFF;\n\tgoto L_00C9;\nL_00C9:\n\tgoto L_00D2;\nL_00CA:\n\tv364 = v275 + -0.5d;\n\tv303 = System.Math::Ceiling(v364);\n\tgoto L_00D2;\nL_00CD:\n\tv368 = v275 + 0.5d;\n\tv303 = System.Math::Floor(v368);\nL_00D2:\n\tv408 = 0x1854ED0(&v327 @ stack_-58_v3 (System.Double), v133, setImmediately, isRelative, methodInfo, v41, v42, v43, v277, v403, v122.z, t.endValue, t.endValue.z, v46, v47, v48);\n\tv420 = v277 >= 0;\n\tif (v420) goto L_00F7;\n\tv431 = v277 != -0.5d;\n\tif (v431) goto L_0109;\n\tgoto L_00FC;\nL_00F7:\n\tv442 = v277 != 0.5d;\n\tif (v442) goto L_010C;\nL_00FC:\n\tv484 = v460 + v461;\n\tv464 = v460 & 1;\n\tv466 = v464 == 0;\n\tv469 = ~v466;\n\tif (v469) goto L_FFFFFFFF;\n\tgoto L_0108;\nL_0108:\n\tgoto L_0111;\nL_0109:\n\tv445 = v277 + -0.5d;\n\tv302 = System.Math::Ceiling(v445);\n\tgoto L_0111;\nL_010C:\n\tv449 = v277 + 0.5d;\n\tv302 = System.Math::Floor(v449);\nL_0111:\n\tv314 = 0x1854ED0(&v327 @ stack_-58_v3 (System.Double), v133, setImmediately, isRelative, methodInfo, v41, v42, v43, v154, v484, v122.z, t.endValue, t.endValue.z, v46, v47, v48);\n\tv499 = v154 >= 0;\n\tif (v499) goto L_0136;\n\tv510 = v154 != -0.5d;\n\tif (v510) goto L_0148;\n\tgoto L_013B;\nL_0136:\n\tv521 = v154 != 0.5d;\n\tif (v521) goto L_014B;\nL_013B:\n\tv542 = v313 + v540;\n\tv543 = v313 & 1;\n\tv545 = v543 == 0;\n\tv548 = ~v545;\n\tif (v548) goto L_FFFFFFFF;\n\tgoto L_0147;\nL_0147:\n\tgoto L_FFFFFFFF;\nL_0148:\n\tv524 = v154 + -0.5d;\n\tv313 = System.Math::Ceiling(v524);\n\tgoto L_FFFFFFFF;\nL_014B:\n\tv528 = v154 + 0.5d;\n\tv313 = System.Math::Floor(v528);\nL_0150:\n\tv159 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(t.setter, v159.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 251 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 fromValue, bool setImmediately, bool isRelative)
		{
			//IL_00b1: Expected O, but got F4
			//IL_00e9: Expected O, but got I
			//IL_00f1: Expected O, but got F4
			//IL_024c: Expected O, but got I
			//IL_0254: Expected O, but got F4
			//IL_0295: Expected O, but got F4
			//IL_065d: Expected O, but got I
			//IL_06a6: Expected O, but got I
			//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d5: Expected I4, but got Unknown
			//IL_071a: Unknown result type (might be due to invalid IL or missing references)
			//IL_071f: Expected I4, but got Unknown
			//IL_0631: Expected O, but got F8
			//IL_0764: Unknown result type (might be due to invalid IL or missing references)
			//IL_0769: Expected I4, but got Unknown
			Vector3 vector = default(Vector3);
			float num = vector.y;
			float num4 = default(float);
			Vector3 vector2;
			float num3;
			float num5;
			if (isRelative)
			{
				DOGetter<Vector3> getter = t.getter;
				object obj = t.getter();
				float num2 = vector.x + vector.x;
				num3 = vector.y + vector.y;
				num4 = t.endValue.x + vector.x;
				num = vector.z + t.endValue.z;
				t.endValue = (Vector3)num4;
				t.endValue.z = num;
				num5 = vector.z + vector.z;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)(nint)getter.method;
				vector2 = (Vector3)num2;
			}
			else
			{
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = t;
				vector2 = vector;
				num3 = num;
				num5 = vector.z;
			}
			t.startValue.x = vector2.x;
			t.startValue.y = num3;
			t.startValue.z = num5;
			if (!setImmediately)
			{
				return;
			}
			if ((nint)t.plugOptions != 8)
			{
				IntPtr method;
				if ((nint)t.plugOptions != 4)
				{
					if ((nint)t.plugOptions != 2)
					{
						goto IL_067b;
					}
					DOGetter<Vector3> getter2 = t.getter;
					method = getter2.method;
					object obj2 = getter2();
					num3 = num;
				}
				else
				{
					DOGetter<Vector3> getter3 = t.getter;
					method = getter3.method;
					object obj3 = getter3();
					vector2 = (Vector3)num4;
				}
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)(nint)method;
				num5 = vector.z;
			}
			else
			{
				DOGetter<Vector3> getter4 = t.getter;
				object obj4 = t.getter();
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = (TweenerCore<Vector3, Vector3, VectorOptions>)(nint)getter4.method;
				vector2 = (Vector3)num4;
				num3 = num;
			}
			goto IL_067b;
			IL_051a:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num6;
			double num7 = default(double);
			double num8;
			if (num5 < 0f)
			{
				if ((double)num5 != -0.5)
				{
					double a = (double)num5 + -0.5;
					num6 = Math.Ceiling(a);
					goto IL_0629;
				}
				num6 = num7;
				num8 = -1.0;
			}
			else
			{
				if ((double)num5 != 0.5)
				{
					double d = (double)num5 + 0.5;
					num6 = Math.Floor(d);
					goto IL_0629;
				}
				num6 = num7;
				num8 = 1.0;
			}
			double num9 = num6 + num8;
			if ((num6 & 1) != 0)
			{
				num6 = num9;
			}
			goto IL_0629;
			IL_0629:
			double num10;
			vector2 = (Vector3)num10;
			double num11;
			num3 = (float)num11;
			num5 = (float)num6;
			goto IL_0796;
			IL_0796:
			DOSetter<Vector3> setter = t.setter;
			t.setter((Vector3)(nint)setter.method);
			return;
			IL_03e9:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num13;
			double num14;
			double num12;
			if (num3 < 0f)
			{
				if ((double)num3 != -0.5)
				{
					double a2 = (double)num3 + -0.5;
					num11 = Math.Ceiling(a2);
					num12 = -0.5;
					goto IL_051a;
				}
				num13 = num7;
				num14 = -1.0;
			}
			else
			{
				if ((double)num3 != 0.5)
				{
					double d2 = (double)num3 + 0.5;
					num11 = Math.Floor(d2);
					num12 = 0.5;
					goto IL_051a;
				}
				num13 = num7;
				num14 = 1.0;
			}
			num12 = num13 + num14;
			num11 = (((num13 & 1) != 0) ? num12 : num13);
			goto IL_051a;
			IL_067b:
			if (t.plugOptions.snapping)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num16;
				double num17;
				double num15;
				if (vector2.x < 0f)
				{
					if ((double)vector2.x != -0.5)
					{
						double a3 = (double)vector2.x + -0.5;
						num10 = Math.Ceiling(a3);
						num15 = -0.5;
						goto IL_03e9;
					}
					num16 = num7;
					num17 = -1.0;
				}
				else
				{
					if ((double)vector2.x != 0.5)
					{
						double d3 = (double)vector2.x + 0.5;
						num10 = Math.Floor(d3);
						num15 = 0.5;
						goto IL_03e9;
					}
					num16 = num7;
					num17 = 1.0;
				}
				num15 = num16 + num17;
				num10 = (((num16 & 1) != 0) ? num15 : num16);
				goto IL_03e9;
			}
			goto IL_0796;
		}

		[Token(Token = "0x6000364")]
		[Address(RVA = "0xC27A30", Offset = "0xC27A30", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector3 ConvertToStartValue(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 value)
		{
			return value;
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0xC27A34", Offset = "0xC27A34", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = t.endValue + t.startValue;\n\tv10 = t.endValue.z + t.startValue.z;\n\tt.endValue = v9;\n\tt.endValue.z = v10;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
			//IL_0053: Expected O, but got F4
			float num = t.endValue.x + t.startValue.x;
			float z = t.endValue.z + t.startValue.z;
			t.endValue = (Vector3)num;
			t.endValue.z = z;
		}

		[Token(Token = "0x6000366")]
		[Address(RVA = "0xC27A6C", Offset = "0xC27A6C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = t.plugOptions == 8;\n\tif (v9) goto L_0032;\n\tv34 = t.plugOptions == 4;\n\tif (v34) goto L_002C;\n\tv53 = t.plugOptions != 2;\n\tif (v53) goto L_003B;\n\tv70 = t.endValue - t.startValue;\n\tgoto L_FFFFFFFF;\nL_002C:\n\tv64 = t.endValue.y - t.startValue.y;\n\tgoto L_003E;\nL_0032:\n\tv67 = t.endValue.z - t.startValue.z;\n\tgoto L_003E;\nL_003B:\n\tv70 = t.endValue - t.startValue;\n\tv64 = t.endValue.y - t.startValue.y;\n\tv67 = t.endValue.z - t.startValue.z;\nL_003E:\n\tt.changeValue.x = v70;\n\tt.changeValue.y = v64;\n\tt.changeValue.z = v67;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector3, Vector3, VectorOptions> t)
		{
			float x;
			float y;
			float z;
			if ((nint)t.plugOptions != 8)
			{
				if ((nint)t.plugOptions != 4)
				{
					if ((nint)t.plugOptions != 2)
					{
						x = t.endValue.x - t.startValue.x;
						y = t.endValue.y - t.startValue.y;
						z = t.endValue.z - t.startValue.z;
						goto IL_0181;
					}
					x = t.endValue.x - t.startValue.x;
					y = 0f;
				}
				else
				{
					y = t.endValue.y - t.startValue.y;
					x = 0f;
				}
				z = 0f;
			}
			else
			{
				z = t.endValue.z - t.startValue.z;
				y = 0f;
				x = 0f;
			}
			goto IL_0181;
			IL_0181:
			t.changeValue.x = x;
			t.changeValue.y = y;
			t.changeValue.z = z;
		}

		[Token(Token = "0x6000367")]
		[Address(RVA = "0xC27B10", Offset = "0xC27B10", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv25 = System.Math;\n\tv26 = \"il2cpp_codegen_initialize_runtime_metadata\"(v25, options, methodInfo, v29, v30, v31, v32, v33, unitsXSecond, changeValue, v0, v2, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35759]) = v41;\nL_001D:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, options, methodInfo, v29, v30, v31, v32, v33, unitsXSecond, changeValue, v0, v2, v34, v35, v36, v37);\nL_001F:\n\tv50 = changeValue * changeValue;\n\tv51 = changeValue.y * changeValue.y;\n\tv52 = v50 + v51;\n\tv53 = changeValue.z * changeValue.z;\n\tv54 = v53 + v52;\n\tv55 = UnityEngine.Mathf::Sqrt(v54);\n\treturnVal1 = v55 / unitsXSecond;\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector3 changeValue)
		{
			Vector3 vector = default(Vector3);
			float num = vector.x * vector.x;
			float num2 = changeValue.y * changeValue.y;
			float num3 = num + num2;
			float num4 = changeValue.z * changeValue.z;
			float f = num4 + num3;
			float num5 = Mathf.Sqrt(f);
			return num5 / unitsXSecond;
		}

		[Token(Token = "0x6000368")]
		[Address(RVA = "0xC27B90", Offset = "0xC27B90", Length = "0x57C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv58 = System.Math;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, options, t, isRelative, getter, setter, usingInversePosition, newCompletedSteps, elapsed, startValue, v0, v2, changeValue, v3, v5, duration);\n\tv66 = 1;\n\t*([1A35797]) = v66;\nL_0036:\n\tv78 = t.loopType != 2;\n\tif (v78) goto L_0044;\n\tv260 = t.completedLoops - t.isComplete;\n\tv262 = changeValue * v260;\n\tv263 = changeValue.y * v260;\n\tv264 = changeValue.z * v260;\n\tv217 = startValue + v262;\n\tv220 = startValue.y + v263;\n\tv227 = startValue.z + v264;\nL_0044:\n\tv270 = ~t.isSequenced;\n\tif (v270) goto L_0079;\n\tv117 = t.sequenceParent;\n\tv278 = v117.loopType != 2;\n\tif (v278) goto L_0079;\n\tv277 = t.loopType != 2;\n\tif (v277) goto L_FFFFFFFF;\n\tv396 = t.loops;\n\tgoto L_0066;\nL_0066:\n\tv399 = changeValue * v396;\n\tv400 = changeValue.y * v396;\n\tv307 = v117.completedLoops - v117.isComplete;\n\tv402 = changeValue.z * v396;\n\tv272 = v399 * v307;\n\tv311 = v400 * v307;\n\tv274 = v402 * v307;\n\tv217 = v217 + v272;\n\tv220 = v220 + v311;\n\tv227 = v227 + v274;\nL_0079:\n\tv326 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv166 = options == 8;\n\tif (v166) goto L_00D2;\n\tv167 = options == 4;\n\tif (v167) goto L_0105;\n\tv121 = options != 2;\n\tif (v121) goto L_0133;\n\tv444 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(getter);\n\tv445 = changeValue * v326;\n\tv221 = v217 + v445;\n\tv447 = options & 0x100000000;\n\tv448 = v447 == 0;\n\tif (v448) goto L_01E3;\n\tgoto L_00B2;\n\tv611 = \"il2cpp_codegen_runtime_class_init\"(v512, v95, v86, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v445, v100, v254, v251, changeValue, v3, v5, duration);\nL_00B2:\n\tv529 = 0x1854ED0(&v424 @ stack_-78_v5 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v221, duration, t.easeOvershootOrAmplitude, t.easePeriod, changeValue, changeValue.y, changeValue.z, duration);\n\tv677 = v221 >= 0;\n\tif (v677) goto L_016C;\n\tv740 = v221 != -0.5d;\n\tif (v740) goto L_01D2;\n\tgoto L_0171;\nL_00D2:\n\tv391 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(getter);\n\tv392 = changeValue.z * v326;\n\tv604 = v227 + v392;\n\tv394 = options & 0x100000000;\n\tv395 = v394 == 0;\n\tif (v395) goto L_01EF;\n\tgoto L_00E5;\n\tv501 = \"il2cpp_codegen_runtime_class_init\"(v419, v96, v86, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v392, v100, v254, v251, changeValue, v3, v5, duration);\nL_00E5:\n\tv436 = 0x1854ED0(&v424 @ stack_-78_v5 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v604, duration, t.easeOvershootOrAmplitude, t.easePeriod, changeValue, changeValue.y, changeValue.z, duration);\n\tv563 = v604 >= 0;\n\tif (v563) goto L_0188;\n\tv652 = v604 != -0.5d;\n\tif (v652) goto L_01D5;\n\tgoto L_018D;\nL_0105:\n\tv412 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(getter);\n\tv413 = changeValue.y * v326;\n\tv599 = v220 + v413;\n\tv415 = options & 0x100000000;\n\tv416 = v415 == 0;\n\tif (v416) goto L_01FA;\n\tgoto L_0118;\n\tv546 = \"il2cpp_codegen_runtime_class_init\"(v478, v97, v86, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v413, v100, v254, v251, changeValue, v3, v5, duration);\nL_0118:\n\tv495 = 0x1854ED0(&v424 @ stack_-78_v5 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v599, duration, t.easeOvershootOrAmplitude, t.easePeriod, changeValue, changeValue.y, changeValue.z, duration);\n\tv641 = v599 >= 0;\n\tif (v641) goto L_01A4;\n\tv710 = v599 != -0.5d;\n\tif (v710) goto L_01D8;\n\tgoto L_01A9;\nL_0133:\n\tv403 = changeValue * v326;\n\tv404 = changeValue.y * v326;\n\tv255 = changeValue.z * v326;\n\tv236 = v217 + v403;\n\tv599 = v220 + v404;\n\tv604 = v227 + v255;\n\tv408 = options & 0x100000000;\n\tv409 = v408 == 0;\n\tif (v409) goto L_0284;\n\tgoto L_0147;\n\tv535 = \"il2cpp_codegen_runtime_class_init\"(v451, v94, v86, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v403, v404, v255, v251, changeValue, v3, v5, duration);\nL_0147:\n\tv541 = 0x1854ED0(&v424 @ stack_-78_v5 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v236, v404, v255, t.easePeriod, changeValue, changeValue.y, changeValue.z, duration);\n\tv630 = v236 >= 0;\n\tif (v630) goto L_01C0;\n\tv688 = v236 != -0.5d;\n\tif (v688) goto L_01DB;\n\tgoto L_01C5;\nL_016C:\n\tv751 = v221 != 0.5d;\n\tif (v751) goto L_01DE;\nL_0171:\n\t;\n\tv871 = v519 & 1;\n\tv873 = v871 == 0;\n\tv876 = ~v873;\n\tif (v876) goto L_017D;\n\tgoto L_017D;\nL_017D:\n\tgoto L_01E3;\nL_0188:\n\tv663 = v604 != 0.5d;\n\tif (v663) goto L_01EA;\nL_018D:\n\t;\n\tv781 = v426 & 1;\n\tv783 = v781 == 0;\n\tv786 = ~v783;\n\tif (v786) goto L_0199;\n\tgoto L_0199;\nL_0199:\n\tgoto L_01EF;\nL_01A4:\n\tv721 = v599 != 0.5d;\n\tif (v721) goto L_01F5;\nL_01A9:\n\t;\n\tv849 = v485 & 1;\n\tv851 = v849 == 0;\n\tv854 = ~v851;\n\tif (v854) goto L_01B5;\n\tgoto L_01B5;\nL_01B5:\n\tgoto L_01FA;\nL_01C0:\n\tv699 = v236 != 0.5d;\n\tif (v699) goto L_01FF;\nL_01C5:\n\tv816 = v797 + v796;\n\tv809 = v797 & 1;\n\tv811 = v809 == 0;\n\tv814 = ~v811;\n\tif (v814) goto L_01D1;\n\tgoto L_01D1;\nL_01D1:\n\tgoto L_0204;\nL_01D2:\n\tv790 = v221 + -0.5d;\n\tv519 = System.Math::Ceiling(v790);\n\tgoto L_01E3;\nL_01D5:\n\tv724 = v604 + -0.5d;\n\tv426 = System.Math::Ceiling(v724);\n\tgoto L_01EF;\nL_01D8:\n\tv762 = v599 + -0.5d;\n\tv485 = System.Math::Ceiling(v762);\n\tgoto L_01FA;\nL_01DB:\n\tv754 = v236 + -0.5d;\n\tv828 = System.Math::Ceiling(v754);\n\tgoto L_0204;\nL_01DE:\n\tv794 = v221 + 0.5d;\n\tv519 = System.Math::Floor(v794);\nL_01E3:\n\tv318 = setter.invoke_impl;\n\tv348 = setter.method_code;\n\tv322 = setter.method;\n\tgoto L_0299;\nL_01EA:\n\tv728 = v604 + 0.5d;\n\tv426 = System.Math::Floor(v728);\nL_01EF:\n\tv318 = setter.invoke_impl;\n\tv348 = setter.method_code;\n\tv322 = setter.method;\n\tgoto L_0299;\nL_01F5:\n\tv766 = v599 + 0.5d;\n\tv485 = System.Math::Floor(v766);\nL_01FA:\n\tv318 = setter.invoke_impl;\n\tv348 = setter.method_code;\n\tv322 = setter.method;\n\tgoto L_0299;\nL_01FF:\n\tv758 = v236 + 0.5d;\n\tv828 = System.Math::Floor(v758);\nL_0204:\n\tv835 = 0x1854ED0(&v424 @ stack_-78_v5 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v599, v816, v255, t.easePeriod, changeValue, changeValue.y, changeValue.z, duration);\n\tv889 = v599 >= 0;\n\tif (v889) goto L_0229;\n\tv904 = v599 != -0.5d;\n\tif (v904) goto L_023B;\n\tgoto L_022E;\nL_0229:\n\tv915 = v599 != 0.5d;\n\tif (v915) goto L_023E;\nL_022E:\n\tv944 = v925 + v924;\n\tv937 = v925 & 1;\n\tv939 = v937 == 0;\n\tv942 = ~v939;\n\tif (v942) goto L_023A;\n\tgoto L_023A;\nL_023A:\n\tgoto L_0243;\nL_023B:\n\tv918 = v599 + -0.5d;\n\tv956 = System.Math::Ceiling(v918);\n\tgoto L_0243;\nL_023E:\n\tv922 = v599 + 0.5d;\n\tv956 = System.Math::Floor(v922);\nL_0243:\n\tv468 = 0x1854ED0(&v424 @ stack_-78_v5 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v604, v944, v255, t.easePeriod, changeValue, changeValue.y, changeValue.z, duration);\n\tv972 = v604 >= 0;\n\tif (v972) goto L_0268;\n\tv983 = v604 != -0.5d;\n\tif (v983) goto L_027A;\n\tgoto L_026D;\nL_0268:\n\tv994 = v604 != 0.5d;\n\tif (v994) goto L_027D;\nL_026D:\n\t;\n\tv1016 = v458 & 1;\n\tv1018 = v1016 == 0;\n\tv1021 = ~v1018;\n\tif (v1021) goto L_0279;\n\tgoto L_0279;\nL_0279:\n\tgoto L_0284;\nL_027A:\n\tv997 = v604 + -0.5d;\n\tv458 = System.Math::Ceiling(v997);\n\tgoto L_0284;\nL_027D:\n\tv1001 = v604 + 0.5d;\n\tv458 = System.Math::Floor(v1001);\nL_0284:\n\tv318 = setter.invoke_impl;\n\tv348 = setter.method_code;\n\tv322 = setter.method;\nL_0299:\n\t// 665 IndirectJump v318 @ X2_v4 (System.IntPtr), v348 @ X0_v6 (System.IntPtr), v348 @ X0_v6 (System.IntPtr), v322 @ X1_v4 (System.IntPtr), v318 @ X2_v4 (System.IntPtr), isRelative @ X3 (System.Boolean), getter @ X4 (DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>), setter @ X5 (DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>), usingInversePosition @ X6 (System.Boolean), newCompletedSteps @ X7 (System.Int32), v326 @ V0_v7 (System.Single), v324 @ V1_v6 (System.Single), t.easeOvershootOrAmplitude (System.Single), t.easePeriod (System.Single), changeValue @ V4 (UnityEngine.Vector3), changeValue.y (System.Single), changeValue.z (System.Single), duration @ V7 (System.Single)\n\n// ... truncated")]
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Expected I4, but got Unknown
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Expected I4, but got Unknown
			//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c54: Expected I4, but got Unknown
			//IL_0472: Unknown result type (might be due to invalid IL or missing references)
			//IL_0477: Expected I4, but got Unknown
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected I4, but got Unknown
			//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b75: Expected I4, but got Unknown
			//IL_0c8b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c90: Expected I4, but got Unknown
			//IL_0ba7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bac: Expected I4, but got Unknown
			//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bf1: Expected I4, but got Unknown
			//IL_0b39: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b3e: Expected I4, but got Unknown
			bool flag = t.loopType != LoopType.Incremental;
			Vector3 vector = default(Vector3);
			float num = vector.x;
			float num2 = startValue.y;
			float num3 = startValue.z;
			Vector3 vector2 = default(Vector3);
			if (!flag)
			{
				int num4 = t.completedLoops - (t.isComplete ? 1 : 0);
				float num5 = vector2.x * (float)num4;
				float num6 = changeValue.y * (float)num4;
				float num7 = changeValue.z * (float)num4;
				num = vector.x + num5;
				num2 = startValue.y + num6;
				num3 = startValue.z + num7;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num8 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					float num9 = vector2.x * (float)num8;
					float num10 = changeValue.y * (float)num8;
					int num11 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					float num12 = changeValue.z * (float)num8;
					float num13 = num9 * (float)num11;
					float num14 = num10 * (float)num11;
					float num15 = num12 * (float)num11;
					num += num13;
					num2 += num14;
					num3 += num15;
				}
			}
			float num16 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			double num20 = default(double);
			float num26 = default(float);
			float num25;
			if ((nint)options != 8)
			{
				if ((nint)options != 4)
				{
					if ((nint)options == 2)
					{
						object obj = getter();
						float num17 = vector2.x * num16;
						float num18 = num + num17;
						if ((int)(options & 0x100000000L) != 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
							double num19;
							if (num18 < 0f)
							{
								if ((double)num18 != -0.5)
								{
									double a = (double)num18 + -0.5;
									num19 = Math.Ceiling(a);
									goto IL_06c5;
								}
								num19 = num20;
							}
							else
							{
								if ((double)num18 != 0.5)
								{
									double d = (double)num18 + 0.5;
									num19 = Math.Floor(d);
									goto IL_06c5;
								}
								num19 = num20;
							}
							if ((num19 & 1) != 0)
							{
							}
						}
						goto IL_06c5;
					}
					float num21 = vector2.x * num16;
					float num22 = changeValue.y * num16;
					float num23 = changeValue.z * num16;
					float num24 = num + num21;
					num25 = num2 + num22;
					num26 = num3 + num23;
					if ((int)(options & 0x100000000L) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
						double num29;
						double num30;
						double num28;
						if (num24 < 0f)
						{
							if ((double)num24 != -0.5)
							{
								double a2 = (double)num24 + -0.5;
								double num27 = Math.Ceiling(a2);
								num28 = -0.5;
								goto IL_07d5;
							}
							num29 = -1.0;
							num30 = num20;
						}
						else
						{
							if ((double)num24 != 0.5)
							{
								double d2 = (double)num24 + 0.5;
								double num27 = Math.Floor(d2);
								num28 = 0.5;
								goto IL_07d5;
							}
							num29 = 1.0;
							num30 = num20;
						}
						num28 = num30 + num29;
						if ((num30 & 1) != 0)
						{
						}
						goto IL_07d5;
					}
					goto IL_09db;
				}
				object obj2 = getter();
				float num31 = changeValue.y * num16;
				num25 = num2 + num31;
				if ((int)(options & 0x100000000L) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
					double num32;
					if (num25 < 0f)
					{
						if ((double)num25 != -0.5)
						{
							double a3 = (double)num25 + -0.5;
							num32 = Math.Ceiling(a3);
							goto IL_0769;
						}
						num32 = num20;
					}
					else
					{
						if ((double)num25 != 0.5)
						{
							double d3 = (double)num25 + 0.5;
							num32 = Math.Floor(d3);
							goto IL_0769;
						}
						num32 = num20;
					}
					if ((num32 & 1) != 0)
					{
					}
				}
				goto IL_0769;
			}
			object obj3 = getter();
			float num33 = changeValue.z * num16;
			num26 = num3 + num33;
			if ((int)(options & 0x100000000L) != 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num34;
				if (num26 < 0f)
				{
					if ((double)num26 != -0.5)
					{
						double a4 = (double)num26 + -0.5;
						num34 = Math.Ceiling(a4);
						goto IL_0717;
					}
					num34 = num20;
				}
				else
				{
					if ((double)num26 != 0.5)
					{
						double d4 = (double)num26 + 0.5;
						num34 = Math.Floor(d4);
						goto IL_0717;
					}
					num34 = num20;
				}
				if ((num34 & 1) != 0)
				{
				}
			}
			goto IL_0717;
			IL_07d5:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num37 = default(double);
			double num38 = default(double);
			double num36;
			if (num25 < 0f)
			{
				if ((double)num25 != -0.5)
				{
					double a5 = (double)num25 + -0.5;
					double num35 = Math.Ceiling(a5);
					num36 = -0.5;
					goto IL_08f1;
				}
				num37 = -1.0;
				num38 = num20;
			}
			else
			{
				if ((double)num25 != 0.5)
				{
					double d5 = (double)num25 + 0.5;
					double num35 = Math.Floor(d5);
					num36 = 0.5;
					goto IL_08f1;
				}
				num37 = 1.0;
				num38 = num20;
			}
			goto IL_0c37;
			IL_0717:
			IntPtr invoke_impl = setter.invoke_impl;
			IntPtr method_code = setter.method_code;
			IntPtr method = setter.method;
			goto IL_0c2d;
			IL_09db:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			goto IL_0c2d;
			IL_08f1:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num39;
			if (num26 < 0f)
			{
				if ((double)num26 != -0.5)
				{
					double a6 = (double)num26 + -0.5;
					num39 = Math.Ceiling(a6);
					goto IL_09db;
				}
				num39 = num20;
			}
			else
			{
				if ((double)num26 != 0.5)
				{
					double d6 = (double)num26 + 0.5;
					num39 = Math.Floor(d6);
					goto IL_09db;
				}
				num39 = num20;
			}
			if ((num39 & 1) != 0)
			{
			}
			goto IL_09db;
			IL_0c2d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v318 @ X2_v4 (System.IntPtr) (should have been resolved before IL gen)");
			goto IL_0c37;
			IL_0c37:
			num36 = num38 + num37;
			if ((num38 & 1) != 0)
			{
			}
			goto IL_08f1;
			IL_0769:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			num26 = t.easeOvershootOrAmplitude;
			goto IL_0c2d;
			IL_06c5:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			goto IL_0c2d;
		}

		[Token(Token = "0x6000369")]
		[Address(RVA = "0xC2810C", Offset = "0xC2810C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35798]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3Plugin()
		{
		}
	}
}
