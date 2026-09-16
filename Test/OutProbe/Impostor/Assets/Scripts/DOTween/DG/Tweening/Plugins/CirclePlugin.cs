using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000074")]
	public class CirclePlugin : ABSTweenPlugin<Vector2, Vector2, CircleOptions>
	{
		[Token(Token = "0x60002B9")]
		[Address(RVA = "0xC1CD7C", Offset = "0xC1CD7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Vector2, Vector2, CircleOptions> t)
		{
		}

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0xC1CD80", Offset = "0xC1CD80", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = t + 0x13C;\n\tv15 = ~t.plugOptions.initialized;\n\tv16 = ~v15;\n\tif (v16) goto L_0021;\n\tv103 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\n\tt.startValue.x = v45;\n\tt.startValue.y = v42;\n\t// 26 MakeStruct v88 @ AGGC20DD0_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v45 @ V0 (System.Single), v42 @ V1 (System.Single)\n\t// 27 MakeStruct v87 @ AGGC20DD0_2_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.endValue (UnityEngine.Vector2), t.endValue.y (System.Single)\n\tDG.Tweening.Plugins.CircleOptions::Initialize(v14, v88, v87);\nL_0021:\n\tv37 = isRelative == 0;\n\tt.plugOptions.endValueDegrees = t.plugOptions.startValueDegrees;\n\tv137 = t.plugOptions + t.plugOptions.startValueDegrees;\n\tv28 = ~v37;\n\tv25 = ~v28;\n\tif (v25) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\tt.plugOptions.startValueDegrees = v137;\n\tv46 = DG.Tweening.Plugins.CirclePlugin::GetPositionOnCircle(v14, &v18 @ stack_-40, v137);\n\tv73 = t.setter;\n\tt.startValue.x = v46;\n\tt.startValue.y = v46.y;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(t.setter, v73.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetFrom(TweenerCore<Vector2, Vector2, CircleOptions> t, bool isRelative)
		{
			//IL_000f: Expected O, but got I
			//IL_0156: Expected F4, but got O
			//IL_0196: Expected O, but got Ref
			//IL_0172: Expected O, but got I
			CircleOptions circleOptions = (CircleOptions)((nint)t + 316);
			if (!t.plugOptions.initialized)
			{
				object obj = t.getter();
				float x = default(float);
				t.startValue.x = x;
				float y = default(float);
				t.startValue.y = y;
				Vector2 startValue = default(Vector2);
				startValue.x = x;
				startValue.y = y;
				Vector2 endValue = default(Vector2);
				endValue.x = t.endValue.x;
				endValue.y = t.endValue.y;
				((CircleOptions*)circleOptions)->Initialize(startValue, endValue);
			}
			bool flag = !isRelative;
			t.plugOptions.endValueDegrees = t.plugOptions.startValueDegrees;
			float num = (float)t.plugOptions + t.plugOptions.startValueDegrees;
			if (flag)
			{
				num = (float)t.plugOptions;
			}
			t.plugOptions.startValueDegrees = num;
			object obj2 = default(object);
			Vector2 positionOnCircle = ((CirclePlugin)circleOptions).GetPositionOnCircle((CircleOptions)(&obj2), num);
			DOSetter<Vector2> setter = t.setter;
			t.startValue.x = positionOnCircle.x;
			t.startValue.y = positionOnCircle.y;
			t.setter((Vector2)(nint)setter.method);
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0xC1CFC4", Offset = "0xC1CFC4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = fromValue.y;\n\tv23 = t + 0x13C;\n\tv24 = ~t.plugOptions.initialized;\n\tif (v24) goto L_003E;\n\tv78 = isRelative == 0;\n\tif (v78) goto L_001A;\nL_0017:\n\tv56 = fromValue + t.plugOptions.startValueDegrees;\n\tv0 = t.plugOptions.startValueDegrees + t.plugOptions;\n\tt.plugOptions.endValueDegrees = v0;\nL_001A:\n\tt.plugOptions.startValueDegrees = v56;\n\tv106 = t.plugOptions;\n\tv52 = DG.Tweening.Plugins.CirclePlugin::GetPositionOnCircle(v50, &v106 @ V1_v4 (DG.Tweening.Plugins.CircleOptions), v56);\n\tt.startValue.x = v52;\n\tt.startValue.y = v52.y;\n\tv144 = setImmediately == 0;\n\tif (v144) goto L_003D;\n\tv61 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(t.setter, v61.method);\nL_003D:\n\treturn;\nL_003E:\n\t;\n\tv109 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::Invoke(t.getter);\n\tt.startValue.x = fromValue;\n\tt.startValue.y = fromValue.y;\n\t// 75 MakeStruct v80 @ AGGC210AC_2_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.endValue (UnityEngine.Vector2), t.endValue.y (System.Single)\n\tDG.Tweening.Plugins.CircleOptions::Initialize(v23, fromValue, v80);\n\tv148 = isRelative == 0;\n\tv95 = ~v148;\n\tif (v95) goto L_0017;\n\tgoto L_001A;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetFrom(TweenerCore<Vector2, Vector2, CircleOptions> t, Vector2 fromValue, bool setImmediately, bool isRelative)
		{
			//IL_0021: Expected O, but got I
			//IL_01f6: Expected O, but got Ref
			//IL_00fb: Expected O, but got I
			float y = fromValue.y;
			CircleOptions circleOptions = (CircleOptions)((nint)t + 316);
			CirclePlugin circlePlugin;
			float num;
			Vector2 vector = default(Vector2);
			if (t.plugOptions.initialized)
			{
				bool flag = !isRelative;
				circlePlugin = this;
				num = vector.x;
				if (!flag)
				{
					goto IL_0075;
				}
			}
			else
			{
				object obj = t.getter();
				t.startValue.x = vector.x;
				t.startValue.y = fromValue.y;
				Vector2 endValue = default(Vector2);
				endValue.x = t.endValue.x;
				endValue.y = t.endValue.y;
				((CircleOptions*)circleOptions)->Initialize(fromValue, endValue);
				if (isRelative)
				{
					goto IL_0075;
				}
				circlePlugin = (CirclePlugin)circleOptions;
				num = vector.x;
			}
			goto IL_01c6;
			IL_0075:
			num = vector.x + t.plugOptions.startValueDegrees;
			y = t.plugOptions.startValueDegrees + (float)t.plugOptions;
			t.plugOptions.endValueDegrees = y;
			circlePlugin = (CirclePlugin)circleOptions;
			goto IL_01c6;
			IL_01c6:
			t.plugOptions.startValueDegrees = num;
			CircleOptions plugOptions = t.plugOptions;
			Vector2 positionOnCircle = circlePlugin.GetPositionOnCircle((CircleOptions)(&plugOptions), num);
			t.startValue.x = positionOnCircle.x;
			t.startValue.y = positionOnCircle.y;
			if (setImmediately)
			{
				DOSetter<Vector2> setter = t.setter;
				t.setter((Vector2)(nint)setter.method);
			}
		}

		[Token(Token = "0x60002BC")]
		[Address(RVA = "0xC1D0BC", Offset = "0xC1D0BC", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35753]) = v34;\nL_0016:\n\treturnVal1 = DG.Tweening.Plugins.Core.PluginsManager::GetCustomPlugin();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ABSTweenPlugin<Vector2, Vector2, CircleOptions> Get()
		{
			return PluginsManager.GetCustomPlugin<CirclePlugin, Vector2, Vector2, CircleOptions>();
		}

		[Token(Token = "0x60002BD")]
		[Address(RVA = "0xC1D0FC", Offset = "0xC1D0FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, CircleOptions> t, Vector2 value)
		{
			return value;
		}

		[Token(Token = "0x60002BE")]
		[Address(RVA = "0xC1D100", Offset = "0xC1D100", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~t.plugOptions.initialized;\n\tv9 = ~v8;\n\tif (v9) goto L_0014;\n\tv30 = t + 0x13C;\n\t// 15 MakeStruct v31 @ AGGC21128_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.startValue (UnityEngine.Vector2), t.startValue.y (System.Single)\n\t// 16 MakeStruct v32 @ AGGC21128_2_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.endValue (UnityEngine.Vector2), t.endValue.y (System.Single)\n\tDG.Tweening.Plugins.CircleOptions::Initialize(v30, v31, v32);\nL_0014:\n\tv44 = t.plugOptions + t.plugOptions.startValueDegrees;\n\tt.plugOptions.endValueDegrees = v44;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetRelativeEndValue(TweenerCore<Vector2, Vector2, CircleOptions> t)
		{
			//IL_003d: Expected O, but got I
			if (!t.plugOptions.initialized)
			{
				CircleOptions circleOptions = (CircleOptions)((nint)t + 316);
				Vector2 startValue = default(Vector2);
				startValue.x = t.startValue.x;
				startValue.y = t.startValue.y;
				Vector2 endValue = default(Vector2);
				endValue.x = t.endValue.x;
				endValue.y = t.endValue.y;
				((CircleOptions*)circleOptions)->Initialize(startValue, endValue);
			}
			float endValueDegrees = (float)t.plugOptions + t.plugOptions.startValueDegrees;
			t.plugOptions.endValueDegrees = endValueDegrees;
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0xC1D148", Offset = "0xC1D148", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~t.plugOptions.initialized;\n\tv9 = ~v8;\n\tif (v9) goto L_0014;\n\tv30 = t + 0x13C;\n\t// 15 MakeStruct v31 @ AGGC21170_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.startValue (UnityEngine.Vector2), t.startValue.y (System.Single)\n\t// 16 MakeStruct v32 @ AGGC21170_2_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), t.endValue (UnityEngine.Vector2), t.endValue.y (System.Single)\n\tDG.Tweening.Plugins.CircleOptions::Initialize(v30, v31, v32);\nL_0014:\n\tt.changeValue.y = 0f;\n\tv44 = t.plugOptions - t.plugOptions.startValueDegrees;\n\tt.changeValue.x = v44;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void SetChangeValue(TweenerCore<Vector2, Vector2, CircleOptions> t)
		{
			//IL_003d: Expected O, but got I
			if (!t.plugOptions.initialized)
			{
				CircleOptions circleOptions = (CircleOptions)((nint)t + 316);
				Vector2 startValue = default(Vector2);
				startValue.x = t.startValue.x;
				startValue.y = t.startValue.y;
				Vector2 endValue = default(Vector2);
				endValue.x = t.endValue.x;
				endValue.y = t.endValue.y;
				((CircleOptions*)circleOptions)->Initialize(startValue, endValue);
			}
			t.changeValue.y = 0f;
			float x = (float)t.plugOptions - t.plugOptions.startValueDegrees;
			t.changeValue.x = x;
		}

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0xC1D194", Offset = "0xC1D194", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(CircleOptions options, float unitsXSecond, Vector2 changeValue)
		{
			return (float)changeValue / unitsXSecond;
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0xC1D19C", Offset = "0xC1D19C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv94 = options.startValueDegrees;\n\tv32 = t.loopType != 2;\n\tif (v32) goto L_0022;\n\tv114 = t.completedLoops - t.isComplete;\n\tv116 = changeValue * v114;\n\tv94 = v94 + v116;\nL_0022:\n\tv120 = ~t.isSequenced;\n\tif (v120) goto L_004F;\n\tv60 = t.sequenceParent;\n\tv126 = v60.loopType != 2;\n\tif (v126) goto L_004F;\n\tv125 = t.loopType != 2;\n\tif (v125) goto L_0043;\nL_0043:\n\tv116 = changeValue * v116;\n\tv144 = v60.completedLoops - v60.isComplete;\n\tv116 = v116 * v144;\n\tv94 = v94 + v116;\nL_004F:\n\tv151 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv116 = options.endValueDegrees;\n\tv189 = changeValue * v151;\n\tv190 = v94 + v189;\n\tv50 = DG.Tweening.Plugins.CirclePlugin::GetPositionOnCircle(t.easeType, &v116 @ V1_v14 (System.Single), v190);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::Invoke(setter, setter.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(CircleOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, DOSetter<Vector2> setter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0195: Expected O, but got Ref
			//IL_0195: Expected O, but got I4
			//IL_00fb: Expected O, but got I
			//IL_00e4: Expected F4, but got I4
			float num = options.startValueDegrees;
			float num3;
			Vector2 vector = default(Vector2);
			if (t.loopType == LoopType.Incremental)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				num3 = vector.x * (float)num2;
				num += num3;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					bool flag = t.loopType != LoopType.Incremental;
					num3 = 1f;
					if (!flag)
					{
						num3 = t.loops;
					}
					num3 = vector.x * num3;
					int num4 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					num3 *= (float)num4;
					num += num3;
				}
			}
			float num5 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			num3 = options.endValueDegrees;
			float num6 = vector.x * num5;
			float degrees = num + num6;
			Vector2 positionOnCircle = ((CirclePlugin)t.easeType).GetPositionOnCircle((CircleOptions)(&num3), degrees);
			setter((Vector2)(nint)setter.method);
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0xC1CE38", Offset = "0xC1CE38", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = DG.Tweening.Core.DOTweenUtils;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, options, methodInfo, v31, v32, v33, v34, v35, degrees, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35754]) = v46;\nL_001F:\n\tgoto L_0027;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v47, options, methodInfo, v31, v32, v33, v34, v35, degrees, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tv62 = DG.Tweening.Core.DOTweenUtils::GetPointOnCircle(options.center, options.radius, degrees);\n\tv68 = options.snapping == 0;\n\tif (v68) goto L_00BC;\n\tv72 = 0x1854ED0(&v71 @ stack_-48_v2 (System.Single), options, methodInfo, v31, v32, v33, v34, v35, v62, v62.y, options.radius, degrees, v39, v40, v41, v42);\n\tv166 = v62 >= 0;\n\tif (v166) goto L_0056;\n\tv177 = v62 != -0.5d;\n\tif (v177) goto L_006A;\n\tgoto L_005C;\nL_0056:\n\tv188 = v62 != 0.5d;\n\tif (v188) goto L_006E;\nL_005C:\n\tv212 = v209 + v208;\n\tv213 = v209 & 1;\n\tv215 = v213 == 0;\n\tv218 = ~v215;\n\tif (v218) goto L_FFFFFFFF;\n\tgoto L_0068;\nL_0068:\n\tgoto L_0072;\nL_006A:\n\tv192 = v62 + -0.5f;\n\tv143 = UnityEngine.Mathf::Ceil(v192);\n\tgoto L_0072;\nL_006E:\n\tv197 = v62 + 0.5f;\n\tv143 = UnityEngine.Mathf::Floor(v197);\nL_0072:\n\tv138 = 0x1854ED0(&v71 @ stack_-48_v2 (System.Single), options, methodInfo, v31, v32, v33, v34, v35, v62.y, v212, options.radius, degrees, v39, v40, v41, v42);\n\tv244 = v62.y >= 0;\n\tif (v244) goto L_0097;\n\tv80 = v62.y != -0.5d;\n\tif (v80) goto L_00AB;\n\tgoto L_009E;\nL_0097:\n\tv78 = v62.y != 0.5d;\n\tif (v78) goto L_00AF;\nL_009E:\n\tv141 = v258 & 1;\n\tv106 = v141 == 0;\n\tv76 = ~v106;\n\tif (v76) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00BC;\nL_00AB:\n\tv135 = v62.y + -0.5f;\n\tv127 = UnityEngine.Mathf::Ceil(v135);\n\tgoto L_00BC;\nL_00AF:\n\tv134 = v62.y + 0.5f;\n\tv126 = UnityEngine.Mathf::Floor(v134);\nL_00BC:\n\treturn v142;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector2 GetPositionOnCircle(CircleOptions options, float degrees)
		{
			//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Expected I4, but got Unknown
			//IL_028c: Expected O, but got F4
			//IL_0229: Expected O, but got F4
			//IL_025d: Expected O, but got F4
			//IL_01f1: Expected O, but got F4
			//IL_0324: Expected O, but got F4
			Vector2 pointOnCircle = DOTweenUtils.GetPointOnCircle(options.center, options.radius, degrees);
			bool flag = !options.snapping;
			Vector2 result = pointOnCircle;
			float num;
			float num5 = default(float);
			if (!flag)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
				float num3;
				float num4;
				float num2;
				if (pointOnCircle.x < 0f)
				{
					if ((double)pointOnCircle.x != -0.5)
					{
						float f = pointOnCircle.x + -0.5f;
						num = Mathf.Ceil(f);
						num2 = -0.5f;
						goto IL_0188;
					}
					num3 = -1f;
					num4 = num5;
				}
				else
				{
					if ((double)pointOnCircle.x != 0.5)
					{
						float f2 = pointOnCircle.x + 0.5f;
						num = Mathf.Floor(f2);
						num2 = 0.5f;
						goto IL_0188;
					}
					num3 = 1f;
					num4 = num5;
				}
				num2 = num4 + num3;
				num = (((num4 & 1) != 0) ? num2 : num4);
				goto IL_0188;
			}
			goto IL_0291;
			IL_0188:
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			object obj;
			if (pointOnCircle.y < 0f)
			{
				if ((double)pointOnCircle.y != -0.5)
				{
					float f3 = pointOnCircle.y + -0.5f;
					float num6 = Mathf.Ceil(f3);
					result = (Vector2)num;
					goto IL_0291;
				}
				obj = num5;
			}
			else
			{
				if ((double)pointOnCircle.y != 0.5)
				{
					float f4 = pointOnCircle.y + 0.5f;
					float num7 = Mathf.Floor(f4);
					result = (Vector2)num;
					goto IL_0291;
				}
				obj = num5;
			}
			if ((int)((nint)obj & 1) == 0)
			{
			}
			result = (Vector2)num;
			goto IL_0291;
			IL_0291:
			return result;
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0xC1D298", Offset = "0xC1D298", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35755]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.CircleOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CirclePlugin()
		{
		}
	}
}
