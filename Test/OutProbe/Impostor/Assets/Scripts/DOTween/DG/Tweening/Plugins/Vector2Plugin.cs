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
	[Token(Token = "0x2000081")]
	public class Vector2Plugin : ABSTweenPlugin<Vector2, Vector2, VectorOptions>
	{
		[Token(Token = "0x6000337")]
		[Address(RVA = "0xC24174", Offset = "0xC24174", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector2, Vector2, VectorOptions> t)
		{
		}

		[Token(Token = "0x6000338")]
		[Address(RVA = "0xC24178", Offset = "0xC24178", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = System.Math;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, t, isRelative, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3577F]) = v42;\nL_0017:\n\tv44 = t.getter;\n\tv195 = t.endValue.y;\n\tv108 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\n\tv88 = t.endValue + v31;\n\tv86 = t.endValue.y + v32;\n\tv112 = isRelative == 0;\n\tv115 = ~v112;\n\tv116 = ~v115;\n\tif (v116) goto L_002F;\n\tgoto L_002F;\nL_002F:\n\tv160 = ~v112;\n\tv161 = ~v160;\n\tif (v161) goto L_FFFFFFFF;\n\tgoto L_003A;\nL_003A:\n\tv169 = t.plugOptions == 2;\n\tt.endValue.x = v31;\n\tt.endValue.y = v32;\n\tt.startValue.x = v196;\n\tt.startValue.y = v195;\n\tif (v169) goto L_FFFFFFFF;\n\tv183 = t.plugOptions != 4;\n\tif (v183) goto L_0053;\n\tgoto L_0053;\nL_0053:\n\tv198 = ~t.plugOptions.snapping;\n\tif (v198) goto L_00DD;\n\tgoto L_0060;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v201, v94, isRelative, methodInfo, v27, v28, v29, v30, v31, v32, v88, v86, v35, v36, v37, v38);\nL_0060:\n\tv232 = 0x1854ED0(&v230 @ stack_-38_v3 (System.Double), v44.method, isRelative, methodInfo, v27, v28, v29, v30, v196, v32, v88, v86, v35, v36, v37, v38);\n\tv242 = v196 >= 0;\n\tif (v242) goto L_0085;\n\tv253 = v196 != -0.5d;\n\tif (v253) goto L_0097;\n\tgoto L_008A;\nL_0085:\n\tv264 = v196 != 0.5d;\n\tif (v264) goto L_009A;\nL_008A:\n\tv292 = v274 + v273;\n\tv286 = v274 & 1;\n\tv288 = v286 == 0;\n\tv291 = ~v288;\n\tif (v291) goto L_FFFFFFFF;\n\tgoto L_0096;\nL_0096:\n\tgoto L_009F;\nL_0097:\n\tv267 = v196 + -0.5d;\n\tv208 = System.Math::Ceiling(v267);\n\tgoto L_009F;\nL_009A:\n\tv271 = v196 + 0.5d;\n\tv208 = System.Math::Floor(v271);\nL_009F:\n\tv221 = 0x1854ED0(&v230 @ stack_-38_v3 (System.Double), v44.method, isRelative, methodInfo, v27, v28, v29, v30, v195, v292, v88, v86, v35, v36, v37, v38);\n\tv321 = v195 >= 0;\n\tif (v321) goto L_00C4;\n\tv332 = v195 != -0.5d;\n\tif (v332) goto L_00D6;\n\tgoto L_00C9;\nL_00C4:\n\tv343 = v195 != 0.5d;\n\tif (v343) goto L_00D9;\nL_00C9:\n\tv364 = v206 + v352;\n\tv365 = v206 & 1;\n\tv367 = v365 == 0;\n\tv370 = ~v367;\n\tif (v370) goto L_FFFFFFFF;\n\tgoto L_00D5;\nL_00D5:\n\tgoto L_FFFFFFFF;\nL_00D6:\n\tv346 = v195 + -0.5d;\n\tv206 = System.Math::Ceiling(v346);\n\tgoto L_FFFFFFFF;\nL_00D9:\n\tv350 = v195 + 0.5d;\n\tv206 = System.Math::Floor(v350);\nL_00DD:\n\tv103 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(t.setter, v103.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 164 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, bool isRelative)
		{
			//IL_0381: Expected O, but got I
			//IL_044b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0450: Expected I4, but got Unknown
			//IL_0495: Unknown result type (might be due to invalid IL or missing references)
			//IL_049a: Expected I4, but got Unknown
			DOGetter<Vector2> getter = t.getter;
			float num = t.endValue.y;
			object obj = t.getter();
			float num3 = default(float);
			float num2 = t.endValue.x + num3;
			float num5 = default(float);
			float num4 = t.endValue.y + num5;
			bool flag = !isRelative;
			if (!flag)
			{
				num = num4;
			}
			float num6 = (flag ? t.endValue.x : num2);
			bool flag2 = (nint)t.plugOptions == 2;
			t.endValue.x = num3;
			t.endValue.y = num5;
			t.startValue.x = num6;
			t.startValue.y = num;
			if (!flag2)
			{
				if ((nint)t.plugOptions == 4)
				{
					num6 = num3;
				}
			}
			else
			{
				num = num5;
			}
			double num7;
			double num11 = default(double);
			if (t.plugOptions.snapping)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num9;
				double num10;
				double num8;
				if (num6 < 0f)
				{
					if ((double)num6 != -0.5)
					{
						double a = (double)num6 + -0.5;
						num7 = Math.Ceiling(a);
						num8 = -0.5;
						goto IL_0246;
					}
					num9 = -1.0;
					num10 = num11;
				}
				else
				{
					if ((double)num6 != 0.5)
					{
						double d = (double)num6 + 0.5;
						num7 = Math.Floor(d);
						num8 = 0.5;
						goto IL_0246;
					}
					num9 = 1.0;
					num10 = num11;
				}
				num8 = num10 + num9;
				num7 = (((num10 & 1) != 0) ? num8 : num10);
				goto IL_0246;
			}
			goto IL_04c7;
			IL_0355:
			double num12;
			num = (float)num12;
			num6 = (float)num7;
			goto IL_04c7;
			IL_04c7:
			DOSetter<Vector2> setter = t.setter;
			t.setter((Vector2)(nint)setter.method);
			return;
			IL_0246:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num13;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					double a2 = (double)num + -0.5;
					num12 = Math.Ceiling(a2);
					goto IL_0355;
				}
				num13 = -1.0;
				num12 = num11;
			}
			else
			{
				if ((double)num != 0.5)
				{
					double d2 = (double)num + 0.5;
					num12 = Math.Floor(d2);
					goto IL_0355;
				}
				num13 = 1.0;
				num12 = num11;
			}
			double num14 = num12 + num13;
			if ((num12 & 1) != 0)
			{
				num12 = num14;
			}
			goto IL_0355;
		}

		[Token(Token = "0x6000339")]
		[Address(RVA = "0xC2434C", Offset = "0xC2434C", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = System.Math;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, t, setImmediately, isRelative, methodInfo, v35, v36, v37, fromValue, v0, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35780]) = v47;\nL_001B:\n\tv49 = isRelative == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tv52 = t.getter;\n\tv146 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\n\tv148 = v107 + v107;\n\tv133 = v107.y + v107.y;\n\tv141 = t.endValue + v107;\n\tt.endValue = v141;\n\tgoto L_0030;\nL_0030:\n\tt.startValue.x = v130;\n\tt.startValue.y = v133;\n\tv153 = setImmediately == 0;\n\tif (v153) goto L_005D;\n\tv89 = t.plugOptions == 4;\n\tif (v89) goto L_005E;\n\tv64 = t.plugOptions != 2;\n\tif (v64) goto L_0067;\n\tv135 = t.getter;\n\tv224 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\n\tgoto L_0067;\nL_005D:\n\treturn;\nL_005E:\n\tv136 = t.getter;\n\tv223 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\nL_0067:\n\tv232 = ~t.plugOptions.snapping;\n\tif (v232) goto L_00F1;\n\tgoto L_0074;\n\tv262 = \"il2cpp_codegen_runtime_class_init\"(v237, v116, setImmediately, isRelative, methodInfo, v35, v36, v37, v107, v0, v113, v39, v40, v41, v42, v43);\nL_0074:\n\tv268 = 0x1854ED0(&v266 @ stack_-48_v3 (System.Double), v116, setImmediately, isRelative, methodInfo, v35, v36, v37, v130, v107.y, t.endValue, v39, v40, v41, v42, v43);\n\tv278 = v130 >= 0;\n\tif (v278) goto L_0099;\n\tv289 = v130 != -0.5d;\n\tif (v289) goto L_00AB;\n\tgoto L_009E;\nL_0099:\n\tv300 = v130 != 0.5d;\n\tif (v300) goto L_00AE;\nL_009E:\n\tv342 = v318 + v319;\n\tv322 = v318 & 1;\n\tv324 = v322 == 0;\n\tv327 = ~v324;\n\tif (v327) goto L_FFFFFFFF;\n\tgoto L_00AA;\nL_00AA:\n\tgoto L_00B3;\nL_00AB:\n\tv303 = v130 + -0.5d;\n\tv243 = System.Math::Ceiling(v303);\n\tgoto L_00B3;\nL_00AE:\n\tv307 = v130 + 0.5d;\n\tv243 = System.Math::Floor(v307);\nL_00B3:\n\tv254 = 0x1854ED0(&v266 @ stack_-48_v3 (System.Double), v116, setImmediately, isRelative, methodInfo, v35, v36, v37, v133, v342, t.endValue, v39, v40, v41, v42, v43);\n\tv357 = v133 >= 0;\n\tif (v357) goto L_00D8;\n\tv368 = v133 != -0.5d;\n\tif (v368) goto L_00EA;\n\tgoto L_00DD;\nL_00D8:\n\tv379 = v133 != 0.5d;\n\tif (v379) goto L_00ED;\nL_00DD:\n\tv400 = v253 + v398;\n\tv401 = v253 & 1;\n\tv403 = v401 == 0;\n\tv406 = ~v403;\n\tif (v406) goto L_FFFFFFFF;\n\tgoto L_00E9;\nL_00E9:\n\tgoto L_FFFFFFFF;\nL_00EA:\n\tv382 = v133 + -0.5d;\n\tv253 = System.Math::Ceiling(v382);\n\tgoto L_FFFFFFFF;\nL_00ED:\n\tv386 = v133 + 0.5d;\n\tv253 = System.Math::Floor(v386);\nL_00F1:\n\tv137 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(t.setter, v137.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 185 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 fromValue, bool setImmediately, bool isRelative)
		{
			//IL_0086: Expected O, but got F4
			//IL_0093: Expected O, but got I
			//IL_009b: Expected O, but got F4
			//IL_01c4: Expected O, but got I
			//IL_01cc: Expected O, but got F4
			//IL_045b: Expected O, but got I
			//IL_0180: Expected O, but got I
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Expected I4, but got Unknown
			//IL_0437: Expected O, but got F8
			//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0503: Expected I4, but got Unknown
			Vector2 vector = default(Vector2);
			float num3 = default(float);
			Vector2 vector2;
			float num2;
			if (isRelative)
			{
				DOGetter<Vector2> getter = t.getter;
				object obj = t.getter();
				float num = vector.x + vector.x;
				num2 = vector.y + vector.y;
				num3 = t.endValue.x + vector.x;
				t.endValue = (Vector2)num3;
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = (TweenerCore<Vector2, Vector2, VectorOptions>)(nint)getter.method;
				vector2 = (Vector2)num;
			}
			else
			{
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = t;
				vector2 = vector;
				num2 = vector.y;
			}
			t.startValue.x = vector2.x;
			t.startValue.y = num2;
			if (!setImmediately)
			{
				return;
			}
			if ((nint)t.plugOptions != 4)
			{
				if ((nint)t.plugOptions == 2)
				{
					DOGetter<Vector2> getter2 = t.getter;
					object obj2 = t.getter();
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = (TweenerCore<Vector2, Vector2, VectorOptions>)(nint)getter2.method;
					num2 = vector.y;
				}
			}
			else
			{
				DOGetter<Vector2> getter3 = t.getter;
				object obj3 = t.getter();
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = (TweenerCore<Vector2, Vector2, VectorOptions>)(nint)getter3.method;
				vector2 = (Vector2)num3;
			}
			double num4;
			double num7 = default(double);
			if (t.plugOptions.snapping)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num6;
				double num8;
				double num5;
				if (vector2.x < 0f)
				{
					if ((double)vector2.x != -0.5)
					{
						double a = (double)vector2.x + -0.5;
						num4 = Math.Ceiling(a);
						num5 = -0.5;
						goto IL_0320;
					}
					num6 = num7;
					num8 = -1.0;
				}
				else
				{
					if ((double)vector2.x != 0.5)
					{
						double d = (double)vector2.x + 0.5;
						num4 = Math.Floor(d);
						num5 = 0.5;
						goto IL_0320;
					}
					num6 = num7;
					num8 = 1.0;
				}
				num5 = num6 + num8;
				num4 = (((num6 & 1) != 0) ? num5 : num6);
				goto IL_0320;
			}
			goto IL_0530;
			IL_0530:
			DOSetter<Vector2> setter = t.setter;
			t.setter((Vector2)(nint)setter.method);
			return;
			IL_042f:
			vector2 = (Vector2)num4;
			double num9;
			num2 = (float)num9;
			goto IL_0530;
			IL_0320:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num10;
			if (num2 < 0f)
			{
				if ((double)num2 != -0.5)
				{
					double a2 = (double)num2 + -0.5;
					num9 = Math.Ceiling(a2);
					goto IL_042f;
				}
				num9 = num7;
				num10 = -1.0;
			}
			else
			{
				if ((double)num2 != 0.5)
				{
					double d2 = (double)num2 + 0.5;
					num9 = Math.Floor(d2);
					goto IL_042f;
				}
				num9 = num7;
				num10 = 1.0;
			}
			double num11 = num9 + num10;
			if ((num9 & 1) != 0)
			{
				num9 = num11;
			}
			goto IL_042f;
		}

		[Token(Token = "0x600033A")]
		[Address(RVA = "0xC24590", Offset = "0xC24590", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 value)
		{
			return value;
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0xC24594", Offset = "0xC24594", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue + t.startValue;\n\tt.endValue = v7;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector2, Vector2, VectorOptions> t)
		{
			//IL_0030: Expected O, but got F4
			float num = t.endValue.x + t.startValue.x;
			t.endValue = (Vector2)num;
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0xC245B8", Offset = "0xC245B8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = t.plugOptions == 4;\n\tif (v9) goto L_0022;\n\tv39 = t.plugOptions != 2;\n\tif (v39) goto L_0029;\n\tt.changeValue.y = 0f;\n\tv45 = t.endValue - t.startValue;\n\tt.changeValue.x = v45;\n\tgoto L_002D;\nL_0022:\n\tt.changeValue.x = 0f;\n\tv42 = t.endValue.y - t.startValue.y;\n\tt.changeValue.y = v42;\n\tgoto L_002D;\nL_0029:\n\tv49 = t.endValue - t.startValue;\n\tt.changeValue = v49;\nL_002D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector2, Vector2, VectorOptions> t)
		{
			//IL_0111: Expected O, but got F4
			if ((nint)t.plugOptions != 4)
			{
				if ((nint)t.plugOptions == 2)
				{
					t.changeValue.y = 0f;
					float x = t.endValue.x - t.startValue.x;
					t.changeValue.x = x;
				}
				else
				{
					float num = t.endValue.x - t.startValue.x;
					t.changeValue = (Vector2)num;
				}
			}
			else
			{
				t.changeValue.x = 0f;
				float y = t.endValue.y - t.startValue.y;
				t.changeValue.y = y;
			}
		}

		[Token(Token = "0x600033D")]
		[Address(RVA = "0xC24620", Offset = "0xC24620", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv21 = System.Math;\n\tv22 = \"il2cpp_codegen_initialize_runtime_metadata\"(v21, options, methodInfo, v25, v26, v27, v28, v29, unitsXSecond, changeValue, v0, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A357E2]) = v38;\nL_001A:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, options, methodInfo, v25, v26, v27, v28, v29, unitsXSecond, changeValue, v0, v30, v31, v32, v33, v34);\nL_001C:\n\tv47 = changeValue * changeValue;\n\tv48 = changeValue.y * changeValue.y;\n\tv49 = v47 + v48;\n\tv50 = UnityEngine.Mathf::Sqrt(v49);\n\treturnVal1 = v50 / unitsXSecond;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector2 changeValue)
		{
			Vector2 vector = default(Vector2);
			float num = vector.x * vector.x;
			float num2 = changeValue.y * changeValue.y;
			float f = num + num2;
			float num3 = Mathf.Sqrt(f);
			return num3 / unitsXSecond;
		}

		[Token(Token = "0x600033E")]
		[Address(RVA = "0xC24694", Offset = "0xC24694", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv50 = System.Math;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, options, t, isRelative, getter, setter, usingInversePosition, newCompletedSteps, elapsed, startValue, v0, changeValue, v2, duration, v55, v56);\n\tv60 = 1;\n\t*([1A35781]) = v60;\nL_0030:\n\tv72 = t.loopType != 2;\n\tif (v72) goto L_003C;\n\tv196 = t.completedLoops - t.isComplete;\n\tv198 = changeValue * v196;\n\tv199 = changeValue.y * v196;\n\tv173 = startValue + v198;\n\tv178 = startValue.y + v199;\nL_003C:\n\tv204 = ~t.isSequenced;\n\tif (v204) goto L_006E;\n\tv104 = t.sequenceParent;\n\tv212 = v104.loopType != 2;\n\tif (v212) goto L_006E;\n\tv211 = t.loopType != 2;\n\tif (v211) goto L_FFFFFFFF;\n\tv327 = t.loops;\n\tgoto L_005E;\nL_005E:\n\tv330 = changeValue * v327;\n\tv331 = changeValue.y * v327;\n\tv240 = v104.completedLoops - v104.isComplete;\n\tv206 = v330 * v240;\n\tv208 = v331 * v240;\n\tv173 = v173 + v206;\n\tv178 = v178 + v208;\nL_006E:\n\tv258 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv139 = options == 4;\n\tif (v139) goto L_00BC;\n\tv108 = options != 2;\n\tif (v108) goto L_00E9;\n\tv336 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(getter);\n\tv337 = changeValue * v258;\n\tv182 = v173 + v337;\n\tv340 = options & 0x100000000;\n\tv341 = v340 == 0;\n\tif (v341) goto L_01C6;\n\tgoto L_009C;\n\tv436 = \"il2cpp_codegen_runtime_class_init\"(v413, v335, v80, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v337, v91, v191, v78, v2, duration, v55, v56);\nL_009C:\n\tv375 = 0x1854ED0(&v393 @ stack_-68_v4 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v182, duration, t.easeOvershootOrAmplitude, t.easePeriod, changeValue.y, duration, v55, v56);\n\tv473 = v182 >= 0;\n\tif (v473) goto L_0120;\n\tv528 = v182 != -0.5d;\n\tif (v528) goto L_016A;\n\tgoto L_0125;\nL_00BC:\n\tv322 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(getter);\n\tv323 = changeValue.y * v258;\n\tv452 = v178 + v323;\n\tv325 = options & 0x100000000;\n\tv326 = v325 == 0;\n\tif (v326) goto L_017C;\n\tgoto L_00CE;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v388, v88, v80, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v323, v91, v191, v78, v2, duration, v55, v56);\nL_00CE:\n\tv405 = 0x1854ED0(&v393 @ stack_-68_v4 (System.Double), getter.method, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v452, duration, t.easeOvershootOrAmplitude, t.easePeriod, changeValue.y, duration, v55, v56);\n\tv463 = v452 >= 0;\n\tif (v463) goto L_013C;\n\tv506 = v452 != -0.5d;\n\tif (v506) goto L_016D;\n\tgoto L_0141;\nL_00E9:\n\tv314 = changeValue * v258;\n\tv315 = changeValue.y * v258;\n\tv182 = v173 + v314;\n\tv452 = v178 + v315;\n\tv318 = options & 0x100000000;\n\tv319 = v318 == 0;\n\tif (v319) goto L_01C6;\n\tgoto L_00FB;\n\tv417 = \"il2cpp_codegen_runtime_class_init\"(v344, v86, v80, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v314, v315, v191, v78, v2, duration, v55, v56);\nL_00FB:\n\tv423 = 0x1854ED0(&v393 @ stack_-68_v4 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v182, v315, t.easeOvershootOrAmplitude, t.easePeriod, changeValue.y, duration, v55, v56);\n\tv449 = v182 >= 0;\n\tif (v449) goto L_0158;\n\tv484 = v182 != -0.5d;\n\tif (v484) goto L_0170;\n\tgoto L_015D;\nL_0120:\n\tv539 = v182 != 0.5d;\n\tif (v539) goto L_0173;\nL_0125:\n\t;\n\tv634 = v355 & 1;\n\tv636 = v634 == 0;\n\tv639 = ~v636;\n\tif (v639) goto L_0131;\n\tgoto L_0131;\nL_0131:\n\tgoto L_0176;\nL_013C:\n\tv517 = v452 != 0.5d;\n\tif (v517) goto L_0177;\nL_0141:\n\t;\n\tv614 = v395 & 1;\n\tv616 = v614 == 0;\n\tv619 = ~v616;\n\tif (v619) goto L_014D;\n\tgoto L_014D;\nL_014D:\n\tgoto L_017C;\nL_0158:\n\tv495 = v182 != 0.5d;\n\tif (v495) goto L_0181;\nL_015D:\n\tv584 = v565 + v564;\n\tv577 = v565 & 1;\n\tv579 = v577 == 0;\n\tv582 = ~v579;\n\tif (v582) goto L_0169;\n\tgoto L_0169;\nL_0169:\n\tgoto L_0186;\nL_016A:\n\tv558 = v182 + -0.5d;\n\tv355 = System.Math::Ceiling(v558);\n\tgoto L_0176;\nL_016D:\n\tv550 = v452 + -0.5d;\n\tv395 = System.Math::Ceiling(v550);\n\tgoto L_017C;\nL_0170:\n\tv542 = v182 + -0.5d;\n\tv379 = System.Math::Ceiling(v542);\n\tgoto L_0186;\nL_0173:\n\tv562 = v182 + 0.5d;\n\tv355 = System.Math::Floor(v562);\nL_0176:\n\tgoto L_01C6;\nL_0177:\n\tv554 = v452 + 0.5d;\n\tv395 = System.Math::Floor(v554);\nL_017C:\n\tv250 = setter.invoke_impl;\n\tv280 = setter.method_code;\n\tv254 = setter.method;\n\tgoto L_01D8;\nL_0181:\n\tv546 = v182 + 0.5d;\n\tv379 = System.Math::Floor(v546);\nL_0186:\n\tv374 = 0x1854ED0(&v393 @ stack_-68_v4 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v452, v584, t.easeOvershootOrAmplitude, t.easePeriod, changeValue.y, duration, v55, v56);\n\tv652 = v452 >= 0;\n\tif (v652) goto L_01AB;\n\tv667 = v452 != -0.5d;\n\tif (v667) goto L_01BD;\n\tgoto L_01B0;\nL_01AB:\n\tv678 = v452 != 0.5d;\n\tif (v678) goto L_01C0;\nL_01B0:\n\t;\n\tv700 = v354 & 1;\n\tv702 = v700 == 0;\n\tv705 = ~v702;\n\tif (v705) goto L_01BC;\n\tgoto L_01BC;\nL_01BC:\n\tgoto L_01C6;\nL_01BD:\n\tv681 = v452 + -0.5d;\n\tv354 = System.Math::Ceiling(v681);\n\tgoto L_01C6;\nL_01C0:\n\tv685 = v452 + 0.5d;\n\tv354 = System.Math::Floor(v685);\nL_01C6:\n\tv250 = setter.invoke_impl;\n\tv280 = setter.method_code;\n\tv254 = setter.method;\nL_01D8:\n\t// 472 IndirectJump v250 @ X2_v3 (System.IntPtr), v280 @ X0_v5 (System.IntPtr), v280 @ X0_v5 (System.IntPtr), v254 @ X1_v3 (System.IntPtr), v250 @ X2_v3 (System.IntPtr), isRelative @ X3 (System.Boolean), getter @ X4 (DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>), setter @ X5 (DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>), usingInversePosition @ X6 (System.Boolean), newCompletedSteps @ X7 (System.Int32), v258 @ V0_v6 (System.Single), v452 @ V8_v5 (System.Single), t.easeOvershootOrAmplitude (System.Single), t.easePeriod (System.Single), changeValue.y (System.Single), duration @ V5 (System.Single), v55 @ V6, v56 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 326 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, DOSetter<Vector2> setter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Expected I4, but got Unknown
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Expected I4, but got Unknown
			//IL_0891: Unknown result type (might be due to invalid IL or missing references)
			//IL_0896: Expected I4, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Expected I4, but got Unknown
			//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0801: Expected I4, but got Unknown
			//IL_0841: Unknown result type (might be due to invalid IL or missing references)
			//IL_0846: Expected I4, but got Unknown
			//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ca: Expected I4, but got Unknown
			bool flag = t.loopType != LoopType.Incremental;
			Vector2 vector = default(Vector2);
			float num = vector.x;
			float num2 = startValue.y;
			Vector2 vector2 = default(Vector2);
			if (!flag)
			{
				int num3 = t.completedLoops - (t.isComplete ? 1 : 0);
				float num4 = vector2.x * (float)num3;
				float num5 = changeValue.y * (float)num3;
				num = vector.x + num4;
				num2 = startValue.y + num5;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num6 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					float num7 = vector2.x * (float)num6;
					float num8 = changeValue.y * (float)num6;
					int num9 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					float num10 = num7 * (float)num9;
					float num11 = num8 * (float)num9;
					num += num10;
					num2 += num11;
				}
			}
			float num12 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			double num16 = default(double);
			float num19;
			if ((nint)options != 4)
			{
				if ((nint)options == 2)
				{
					object obj = getter();
					float num13 = vector2.x * num12;
					float num14 = num + num13;
					if ((int)(options & 0x100000000L) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
						double num15;
						if (num14 < 0f)
						{
							if ((double)num14 != -0.5)
							{
								double a = (double)num14 + -0.5;
								num15 = Math.Ceiling(a);
								goto IL_069b;
							}
							num15 = num16;
						}
						else
						{
							if ((double)num14 != 0.5)
							{
								double d = (double)num14 + 0.5;
								num15 = Math.Floor(d);
								goto IL_069b;
							}
							num15 = num16;
						}
						if ((num15 & 1) != 0)
						{
						}
					}
				}
				else
				{
					float num17 = vector2.x * num12;
					float num18 = changeValue.y * num12;
					float num14 = num + num17;
					num19 = num2 + num18;
					if ((int)(options & 0x100000000L) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
						double num22;
						double num23;
						double num21;
						if (num14 < 0f)
						{
							if ((double)num14 != -0.5)
							{
								double a2 = (double)num14 + -0.5;
								double num20 = Math.Ceiling(a2);
								num21 = -0.5;
								goto IL_05b1;
							}
							num22 = -1.0;
							num23 = num16;
						}
						else
						{
							if ((double)num14 != 0.5)
							{
								double d2 = (double)num14 + 0.5;
								double num20 = Math.Floor(d2);
								num21 = 0.5;
								goto IL_05b1;
							}
							num22 = 1.0;
							num23 = num16;
						}
						num21 = num23 + num22;
						if ((num23 & 1) != 0)
						{
						}
						goto IL_05b1;
					}
				}
				goto IL_069b;
			}
			object obj2 = getter();
			float num24 = changeValue.y * num12;
			num19 = num2 + num24;
			if ((int)(options & 0x100000000L) != 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				double num25;
				if (num19 < 0f)
				{
					if ((double)num19 != -0.5)
					{
						double a3 = (double)num19 + -0.5;
						num25 = Math.Ceiling(a3);
						goto IL_0552;
					}
					num25 = num16;
				}
				else
				{
					if ((double)num19 != 0.5)
					{
						double d3 = (double)num19 + 0.5;
						num25 = Math.Floor(d3);
						goto IL_0552;
					}
					num25 = num16;
				}
				if ((num25 & 1) != 0)
				{
				}
			}
			goto IL_0552;
			IL_05b1:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num26 = default(double);
			if (num19 < 0f)
			{
				if ((double)num19 != -0.5)
				{
					double a4 = (double)num19 + -0.5;
					num26 = Math.Ceiling(a4);
					goto IL_069b;
				}
				num26 = num16;
			}
			else
			{
				if ((double)num19 != 0.5)
				{
					double d4 = (double)num19 + 0.5;
					num26 = Math.Floor(d4);
					goto IL_069b;
				}
				num26 = num16;
			}
			goto IL_0887;
			IL_0887:
			if ((num26 & 1) != 0)
			{
			}
			goto IL_069b;
			IL_069b:
			IntPtr invoke_impl = setter.invoke_impl;
			IntPtr method_code = setter.method_code;
			IntPtr method = setter.method;
			goto IL_087d;
			IL_0552:
			invoke_impl = setter.invoke_impl;
			method_code = setter.method_code;
			method = setter.method;
			goto IL_087d;
			IL_087d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v250 @ X2_v3 (System.IntPtr) (should have been resolved before IL gen)");
			goto IL_0887;
		}

		[Token(Token = "0x600033F")]
		[Address(RVA = "0xC24A78", Offset = "0xC24A78", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35782]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector2Plugin()
		{
		}
	}
}
