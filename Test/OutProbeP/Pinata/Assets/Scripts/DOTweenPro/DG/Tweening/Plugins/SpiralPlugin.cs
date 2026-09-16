using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000009")]
	public class SpiralPlugin : ABSTweenPlugin<Vector3, Vector3, SpiralOptions>
	{
		[Token(Token = "0x4000044")]
		public static readonly Vector3 DefaultDirection;

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x163D168", Offset = "0x163D168", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector3, Vector3, SpiralOptions> t)
		{
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x163D16C", Offset = "0x163D16C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3, SpiralOptions> t, bool isRelative)
		{
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x163D170", Offset = "0x163D170", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3, SpiralOptions> t, Vector3 fromValue, bool setImmediately)
		{
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x163D174", Offset = "0x163D174", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB7FB8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A896]) = v35;\nL_0018:\n\treturnVal1 = DG.Tweening.Plugins.Core.PluginsManager::GetCustomPlugin();\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ABSTweenPlugin<Vector3, Vector3, SpiralOptions> Get()
		{
			return PluginsManager.GetCustomPlugin<SpiralPlugin, Vector3, Vector3, SpiralOptions>();
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x163D1BC", Offset = "0x163D1BC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector3 ConvertToStartValue(TweenerCore<Vector3, Vector3, SpiralOptions> t, Vector3 value)
		{
			return value;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x163D1C0", Offset = "0x163D1C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3, SpiralOptions> t)
		{
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x163D1C4", Offset = "0x163D1C4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1F076B8]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, t, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([202A897]) = v50;\nL_001F:\n\tv56 = 10f / t.plugOptions.frequency;\n\tv57 = t.plugOptions.speed * v56;\n\tt.plugOptions.speed = v57;\n\tgoto L_0031;\n\tv68 = *([v62 @ X0_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0031;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v62, t, methodInfo, v34, v35, v36, v37, v38, v57, v53, v54, v42, v43, v44, v45, v46);\nL_0031:\n\tv76 = UnityEngine.Vector3::get_up();\n\tgoto L_004A;\n\tv132 = *([v84 @ X0_v7+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_004A;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v84, t, methodInfo, v34, v35, v36, v37, v38, v76, v77, v78, v42, v43, v44, v45, v46);\nL_004A:\n\t// 74 MakeStruct v94 @ AGG163D29C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), t.endValue (UnityEngine.Vector3), t.endValue.y (System.Single), t.endValue.z (System.Single)\n\tv119 = UnityEngine.Quaternion::LookRotation(v94, v76);\n\tt.plugOptions.axisQ.x = v119;\n\tt.plugOptions.axisQ.y = v119.y;\n\tt.plugOptions.axisQ.z = v119.z;\n\tt.plugOptions.axisQ.w = v119.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector3, Vector3, SpiralOptions> t)
		{
			float num = 10f / t.plugOptions.frequency;
			float speed = t.plugOptions.speed * num;
			t.plugOptions.speed = speed;
			Vector3 up = Vector3.up;
			Vector3 forward = default(Vector3);
			forward.x = t.endValue.x;
			forward.y = t.endValue.y;
			forward.z = t.endValue.z;
			Quaternion quaternion = Quaternion.LookRotation(forward, up);
			t.plugOptions.axisQ.x = quaternion.x;
			t.plugOptions.axisQ.y = quaternion.y;
			t.plugOptions.axisQ.z = quaternion.z;
			t.plugOptions.axisQ.w = quaternion.w;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x163D2D0", Offset = "0x163D2D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn unitsXSecond;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(SpiralOptions options, float unitsXSecond, Vector3 changeValue)
		{
			return unitsXSecond;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x163D2D4", Offset = "0x163D2D4", Length = "0x404")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv55 = *([1EF84F8]);\n\tv56 = *([v55 @ X8_v45]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, v2, changeValue, v3, v5, duration);\n\tv65 = 0 | 1;\n\t*([202A898]) = v65;\nL_002C:\n\tv368 = t.easeOvershootOrAmplitude;\n\tv366 = t.easePeriod;\n\tv359 = options.depth;\n\tv357 = options.frequency;\n\tv355 = options.speed;\n\tv78 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv189 = v78 + -0.5f;\n\tv199 = 0.5f - v189;\n\tv200 = options.mode != 1;\n\tif (v200) goto L_FFFFFFFF;\n\tv203 = v78 - 0.5f;\n\tv289 = v203 < 0;\n\tv288 = v203 == 0;\n\tv206 = v78 ^ 0.5f;\n\tv207 = v78 ^ v203;\n\tv208 = v206 & v207;\n\tv284 = v208 < 0;\n\tgoto L_0057;\nL_0057:\n\tv292 = v289 == v284;\n\tv87 = ~v288;\n\tv293 = v292 & v87;\n\tv294 = ~v293;\n\tif (v294) goto L_FFFFFFFF;\n\tgoto L_0069;\nL_0069:\n\tv307 = t.loopType != 2;\n\tif (v307) goto L_00A6;\n\tv364 = t.completedLoops - 1;\n\tv320 = options.mode != 1;\n\tif (v320) goto L_0097;\n\tv341 = t.isComplete == 0;\n\tv323 = ~v341;\n\tv326 = ~v323;\n\tif (v326) goto L_0088;\n\tgoto L_008C;\nL_0088:\n\tv364 = t.completedLoops + 1;\nL_008C:\n\tv357 = v357 / v364;\n\tv401 = 10f / options.frequency;\n\tv352 = v355 / v401;\n\tv368 = 10f / v357;\n\tv359 = v359 * v364;\n\tv355 = v368 * v352;\n\tgoto L_00A6;\nL_0097:\n\tv340 = t.isComplete == 0;\n\tv322 = ~v340;\n\tv325 = ~v322;\n\tif (v325) goto L_FFFFFFFF;\n\tgoto L_00A4;\nL_00A4:\n\tv353 = v78 + v364;\nL_00A6:\n\tv370 = v355 * duration;\n\tv371 = v353 * v370;\n\toptions.unit = v371;\n\tv374 = v361 * v370;\n\tgoto L_00B8;\n\tv382 = *([v375 @ X0_v6 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv383 = v382 == 0;\n\tv384 = ~v383;\n\tgoto L_00B8;\n\tv386 = \"il2cpp_codegen_runtime_class_init\"(v375, v77, t, isRelative, getter, setter, usingInversePosition, updateNotice, v353, v370, v368, v366, changeValue, v3, v5, duration);\nL_00B8:\n\tv389 = v374 * v357;\n\tv391 = 0x6D3020(UnityEngine.Mathf, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v389, v370, v368, v366, changeValue, changeValue.y, changeValue.z, duration);\n\tv399 = 0x6D2D20(v391, 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v389, v370, v368, v366, changeValue, changeValue.y, changeValue.z, duration);\n\tv403 = v371 * v389;\n\tv404 = options.unit * v389;\n\tv405 = v361 * v359;\n\tv409 = 0x1586898(&v111 @ stack_-88_v5 (UnityEngine.Vector3), 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v403, v404, v405, v403, changeValue, changeValue.y, changeValue.z, duration);\n\tgoto L_00E2;\n\tv420 = *([v416 @ X0_v12+E0]);\n\tv421 = v420 == 0;\n\tv422 = ~v421;\n\tif (v422) goto L_00E2;\n\tv424 = \"il2cpp_codegen_runtime_class_init\"(v416, v149, t, isRelative, getter, setter, usingInversePosition, updateNotice, v408, v404, v405, v403, changeValue, v3, v5, duration);\nL_00E2:\n\t// 226 MakeStruct v104 @ AGG163D4AC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v111 @ stack_-88_v5 (UnityEngine.Vector3), v94 @ stack_-84, 0\n\tv434 = UnityEngine.Quaternion::op_Multiply(options.axisQ, v104);\n\tgoto L_00FE;\n\tv444 = *([v440 @ X0_v15+E0]);\n\tv445 = v444 == 0;\n\tv446 = ~v445;\n\tif (v446) goto L_00FE;\n\tv448 = \"il2cpp_codegen_runtime_class_init\"(v440, v149, t, isRelative, getter, setter, usingInversePosition, updateNotice, v434, v435, v436, v430, v431, v432, v175, duration);\nL_00FE:\n\tv455 = UnityEngine.Vector3::op_Addition(v434, startValue);\n\tv181 = v455.z;\n\tv463 = ~options.snapping;\n\tif (v463) goto L_01E1;\n\tgoto L_0117;\n\tv493 = *([v466 @ X0_v20+E0]);\n\tv494 = v493 == 0;\n\tv495 = ~v494;\n\tif (v495) goto L_0117;\n\tv497 = \"il2cpp_codegen_runtime_class_init\"(v466, v149, t, isRelative, getter, setter, usingInversePosition, updateNotice, v455, v456, v457, v179, v109, v177, v175, duration);\nL_0117:\n\tv504 = 0x6D1ED0(&v502 @ stack_-78_v3 (System.Double), 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v455, v455.y, v455.z, startValue, startValue.y, startValue.z, 0, duration);\n\tv515 = v455 >= 0;\n\tif (v515) goto L_013C;\n\tv526 = v455 != -0.5d;\n\tif (v526) goto L_014E;\n\tgoto L_0141;\nL_013C:\n\tv537 = v455 != 0.5d;\n\tif (v537) goto L_0151;\nL_0141:\n\tv575 = v576 + v555;\n\tv559 = v576 & 1;\n\tv561 = v559 == 0;\n\tv564 = ~v561;\n\tif (v564) goto L_FFFFFFFF;\n\tgoto L_014D;\nL_014D:\n\tgoto L_0159;\nL_014E:\n\tv540 = v455 + -0.5d;\n\tv576 = System.Math::Ceiling(v540);\n\tgoto L_0159;\nL_0151:\n\tv544 = v455 + 0.5d;\n\tv576 = System.Math::Floor(v544);\nL_0159:\n\tv586 = 0x6D1ED0(&v502 @ stack_-78_v3 (System.Double), 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v455.y, v575, v181, startValue, startValue.y, startValue.z, 0, duration);\n\tv598 = v455.y >= 0;\n\tif (v598) goto L_017E;\n\tv609 = v455.y != -0.5d;\n\tif (v609) goto L_0190;\n\tgoto L_0183;\nL_017E:\n\tv620 = v455.y != 0.5d;\n\tif (v620) goto L_0193;\nL_0183:\n\tv658 = v659 + v638;\n\tv642 = v659 & 1;\n\tv644 = v642 == 0;\n\tv647 = ~v644;\n\tif (v647) goto L_FFFFFFFF;\n\tgoto L_018F;\nL_018F:\n\tgoto L_019B;\nL_0190:\n\tv623 = v455.y + -0.5d;\n\tv659 = System.Math::Ceiling(v623);\n\tgoto L_019B;\nL_0193:\n\tv627 = v455.y + 0.5d;\n\tv659 = System.Math::Floor(v627);\nL_019B:\n\tv488 = 0x6D1ED0(&v502 @ stack_-78_v3 (System.Double), 0, t, isRelative, getter, setter, usingInversePosition, updateNotice, v181, v658, v181, startValue, startValue.y, startValue.z, 0, duration);\n\tv677 = v181 >= 0;\n\tif (v677) goto L_01C0;\n\tv688 = v181 != -0.5d;\n\tif (v688) goto L_01D2;\n\tgoto L_01C5;\nL_01C0:\n\tv699 = v181 != 0.5d;\n\tif (v699) goto L_01D5;\nL_01C5:\n\tv720 = v485 + v717;\n\tv721 = v485 & 1;\n\tv723 = v721 == 0;\n\tv726 = ~v723;\n\tif (v726) goto L_FFFFFFFF;\n\tgoto L_01D1;\nL_01D1:\n\tgoto L_FFFFFFFF;\nL_01D2:\n\tv702 = v181 + -0.5d;\n\tv485 = System.Math::Ceiling(v702);\n\tgoto L_FFFFFFFF;\nL_01D5:\n\tv706 = v181 + 0.5d;\n\tv485 = System.Math::Floor(v706);\nL_01E1:\n\t// 481 MakeStruct v220 @ AGG163D6A8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v111 @ stack_-88_v5 (UnityEngine.Vector3), v95 @ stack_-84_v3 (System.Single), v181 @ V2_v10 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(setter, v220);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 342 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(SpiralOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_00f2: Expected O, but got F4
			//IL_00ff: Expected O, but got F4
			//IL_093e: Expected native int or pointer, but got O
			//IL_02cf: Expected F4, but got O
			//IL_0852: Unknown result type (might be due to invalid IL or missing references)
			//IL_0857: Expected I4, but got Unknown
			//IL_089c: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a1: Expected I4, but got Unknown
			//IL_06f1: Expected O, but got F8
			//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_08eb: Expected I4, but got Unknown
			float easeOvershootOrAmplitude = t.easeOvershootOrAmplitude;
			float easePeriod = t.easePeriod;
			float num = options.depth;
			float num2 = options.frequency;
			float num3 = options.speed;
			float num4 = EaseManager.Evaluate(t, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num5 = num4 + -0.5f;
			float num6 = 0.5f - num5;
			bool flag;
			bool flag2;
			bool flag3;
			if (options.mode == SpiralMode.ExpandThenContract)
			{
				float num7 = num4 - 0.5f;
				flag = num7 < 0f;
				flag2 = num7 == 0f;
				object obj = num4 ^ 0.5f;
				object obj2 = num4 ^ num7;
				int num8 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
				flag3 = num8 < 0;
			}
			else
			{
				flag3 = false;
				flag2 = true;
				flag = false;
			}
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			float num9 = ((!(flag4 && flag5)) ? num4 : num6);
			bool flag6 = t.loopType != LoopType.Incremental;
			float num10 = num4;
			if (!flag6)
			{
				int num11 = t.completedLoops - 1;
				if (options.mode == SpiralMode.ExpandThenContract)
				{
					if (!t.isComplete)
					{
						num11 = t.completedLoops + 1;
					}
					num2 /= (float)num11;
					float num12 = 10f / options.frequency;
					float num13 = num3 / num12;
					easeOvershootOrAmplitude = 10f / num2;
					num *= (float)num11;
					num3 = easeOvershootOrAmplitude * num13;
					num10 = num4;
					easePeriod = num11;
				}
				else
				{
					if (!t.isComplete)
					{
						num11 = t.completedLoops;
					}
					num9 = num4 + (float)num11;
					num10 = num9;
				}
			}
			float num14 = num3 * duration;
			float num15 = (((SpiralOptions*)(IntPtr)options)->unit = num9 * num14);
			float num16 = num10 * num14;
			float num17 = num16 * num2;
			Il2CppRuntime.Boundary("SYSTEM_API:cosf", "Method not found @6D3020 (native cosf)");
			Il2CppRuntime.Boundary("SYSTEM_API:sinf", "Method not found @6D2D20 (native sinf)");
			float num18 = num15 * num17;
			float num19 = options.unit * num17;
			float num20 = num10 * num;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			vector.x = vector2.x;
			object obj3 = default(object);
			vector.y = (float)obj3;
			vector.z = 0f;
			Vector3 vector3 = options.axisQ * vector;
			Vector3 vector4 = vector3 + startValue;
			float num21 = vector4.z;
			bool flag7 = !options.snapping;
			float y = vector4.y;
			vector2 = vector4;
			double num22;
			double num25 = default(double);
			if (!flag7)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
				double num24;
				double num23;
				if (vector4.x < 0f)
				{
					if ((double)vector4.x != -0.5)
					{
						double a = (double)vector4.x + -0.5;
						num22 = Math.Ceiling(a);
						num23 = -0.5;
						goto IL_0490;
					}
					num24 = -1.0;
					num22 = num25;
				}
				else
				{
					if ((double)vector4.x != 0.5)
					{
						double d = (double)vector4.x + 0.5;
						num22 = Math.Floor(d);
						num23 = 0.5;
						goto IL_0490;
					}
					num24 = 1.0;
					num22 = num25;
				}
				num23 = num22 + num24;
				if ((num22 & 1) != 0)
				{
					num22 = num23;
				}
				goto IL_0490;
			}
			goto IL_06fe;
			IL_0490:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			double num26;
			double num28;
			double num27;
			if (vector4.y < 0f)
			{
				if ((double)vector4.y != -0.5)
				{
					double a2 = (double)vector4.y + -0.5;
					num26 = Math.Ceiling(a2);
					num27 = -0.5;
					goto IL_05d2;
				}
				num28 = -1.0;
				num26 = num25;
			}
			else
			{
				if ((double)vector4.y != 0.5)
				{
					double d2 = (double)vector4.y + 0.5;
					num26 = Math.Floor(d2);
					num27 = 0.5;
					goto IL_05d2;
				}
				num28 = 1.0;
				num26 = num25;
			}
			num27 = num26 + num28;
			if ((num26 & 1) != 0)
			{
				num26 = num27;
			}
			goto IL_05d2;
			IL_05d2:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			double num29;
			double num30;
			if (num21 < 0f)
			{
				if ((double)num21 != -0.5)
				{
					double a3 = (double)num21 + -0.5;
					num29 = Math.Ceiling(a3);
					goto IL_06e1;
				}
				num30 = -1.0;
				num29 = num25;
			}
			else
			{
				if ((double)num21 != 0.5)
				{
					double d3 = (double)num21 + 0.5;
					num29 = Math.Floor(d3);
					goto IL_06e1;
				}
				num30 = 1.0;
				num29 = num25;
			}
			double num31 = num29 + num30;
			if ((num29 & 1) != 0)
			{
				num29 = num31;
			}
			goto IL_06e1;
			IL_06e1:
			y = (float)num26;
			vector2 = (Vector3)num22;
			num21 = (float)num29;
			goto IL_06fe;
			IL_06fe:
			Vector3 pNewValue = default(Vector3);
			pNewValue.x = vector2.x;
			pNewValue.y = y;
			pNewValue.z = num21;
			setter(pNewValue);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x163D6D8", Offset = "0x163D6D8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA5AC0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A899]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.SpiralOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpiralPlugin()
		{
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x163D728", Offset = "0x163D728", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F066E8]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A89A]) = v35;\nL_0017:\n\tgoto L_001E;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001E;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001E:\n\tv50 = UnityEngine.Vector3::get_forward();\n\tv55 = DG.Tweening.Plugins.SpiralPlugin;\n\tv56 = *([v55 @ X8_v9 (Il2CppClass<DG.Tweening.Plugins.SpiralPlugin>)+B8]);\n\tv56.DefaultDirection = v50;\n\t*([v56 @ X8_v10 (Il2CppStaticFields<DG.Tweening.Plugins.SpiralPlugin>)+4]) = v50.y;\n\t*([v56 @ X8_v10 (Il2CppStaticFields<DG.Tweening.Plugins.SpiralPlugin>)+8]) = v50.z;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static SpiralPlugin()
		{
			//IL_001c: Expected I, but got O
			//IL_0025: Expected I, but got O
			Vector3 forward = Vector3.forward;
			IntPtr intPtr = (IntPtr)typeof(SpiralPlugin);
			IntPtr intPtr2 = (IntPtr)DefaultDirection;
			DefaultDirection = forward;
			_ = forward.y;
			_ = forward.z;
		}
	}
}
