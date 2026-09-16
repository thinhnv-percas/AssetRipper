using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.CustomPlugins
{
	[Token(Token = "0x2000047")]
	public class PureQuaternionPlugin : ABSTweenPlugin<Quaternion, Quaternion, NoOptions>
	{
		[Token(Token = "0x4000130")]
		private static PureQuaternionPlugin _plug;

		[Token(Token = "0x6000265")]
		[Address(RVA = "0x107A5C0", Offset = "0x107A5C0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EB8048]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20269E1]) = v37;\nL_0016:\n\tv47 = v41._plug;\n\tv43 = v41._plug == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0029;\n\tv45 = new DG.Tweening.CustomPlugins.PureQuaternionPlugin();\n\tDG.Tweening.CustomPlugins.PureQuaternionPlugin::.ctor(v45);\n\tv57._plug = v45;\n\tv47 = v59._plug;\nL_0029:\n\treturn v47;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PureQuaternionPlugin Plug()
		{
			PureQuaternionPlugin plug = _plug;
			if (_plug == null)
			{
				PureQuaternionPlugin plug2 = new PureQuaternionPlugin();
				_plug = plug2;
				plug = _plug;
			}
			return plug;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0x107A68C", Offset = "0x107A68C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0x107A690", Offset = "0x107A690", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EB6B38]);\n\tv39 = *([v38 @ X8_v16]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, isRelative, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 0 | 1;\n\t*([20269E2]) = v57;\nL_0023:\n\tv108 = t.endValue;\n\tv106 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]);\n\tv104 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+134]);\n\tv102 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\tv69 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+150]));\n\tt.endValue = v69;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]) = v69.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+134]) = v69.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) = v69.w;\n\tv120 = isRelative == 0;\n\tif (v120) goto L_0058;\n\tgoto L_004F;\n\tv195 = *([v123 @ X0_v8+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_004F;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v123, v68, isRelative, methodInfo, v42, v43, v44, v45, v69, v116, v117, v118, v50, v51, v52, v53);\nL_004F:\n\tv136 = UnityEngine.Quaternion::op_Multiply(v69, t.endValue);\nL_0058:\n\tt.startValue = v108;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+120]) = v106;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+124]) = v104;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]) = v102;\n\t// 115 MakeStruct v147 @ AGG107A7D4_1_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v108 @ V8_v3 (UnityEngine.Quaternion), v106 @ V9_v3 (System.Single), v104 @ V10_v3 (System.Single), v102 @ V11_v3 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]), v147);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, bool isRelative)
		{
			//IL_0022: Expected F4, but got I
			//IL_0032: Expected F4, but got I
			//IL_0042: Expected F4, but got I
			//IL_0053: Expected O, but got I
			//IL_013c: Expected O, but got I
			Quaternion startValue = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]");
			float y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+134]");
			float z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			float w = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+150]");
			Quaternion quaternion = (t.endValue = ((DOGetter<Quaternion>)0)());
			_ = quaternion.y;
			_ = quaternion.z;
			_ = quaternion.w;
			if (isRelative)
			{
				Quaternion quaternion2 = quaternion * t.endValue;
				w = quaternion2.w;
				z = quaternion2.z;
				y = quaternion2.y;
				startValue = quaternion2;
			}
			t.startValue = startValue;
			Quaternion pNewValue = default(Quaternion);
			pNewValue.x = startValue.x;
			pNewValue.y = y;
			pNewValue.z = z;
			pNewValue.w = w;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]");
			((DOSetter<Quaternion>)0)(pNewValue);
		}

		[Token(Token = "0x6000268")]
		[Address(RVA = "0x107A7E0", Offset = "0x107A7E0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv38 = *([1EF5178]);\n\tv39 = *([v38 @ X8_v7]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, setImmediately, methodInfo, v42, v43, v44, v45, fromValue, v0, v2, v3, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([20269E3]) = v53;\nL_0022:\n\tt.startValue = fromValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+120]) = fromValue.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+124]) = fromValue.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+128]) = fromValue.w;\n\tv56 = setImmediately == 0;\n\tif (v56) goto L_004A;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]), fromValue);\n\treturn;\nL_004A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion fromValue, bool setImmediately)
		{
			//IL_0062: Expected O, but got I
			t.startValue = fromValue;
			_ = fromValue.y;
			_ = fromValue.z;
			_ = fromValue.w;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+158]");
				((DOSetter<Quaternion>)0)(fromValue);
			}
		}

		[Token(Token = "0x6000269")]
		[Address(RVA = "0x107A8A8", Offset = "0x107A8A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Quaternion ConvertToStartValue(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion value)
		{
			return value;
		}

		[Token(Token = "0x600026A")]
		[Address(RVA = "0x107A8AC", Offset = "0x107A8AC", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv34 = *([1EE8A80]);\n\tv35 = *([v34 @ X8_v10]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, t, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([20269E4]) = v54;\nL_002B:\n\tgoto L_003C;\n\tv72 = *([v65 @ X0_v4+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_003C;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v65, t, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_003C:\n\tv90 = UnityEngine.Quaternion::op_Multiply(t.endValue, t.startValue);\n\tt.endValue = v90;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]) = v90.y;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+134]) = v90.z;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]) = v90.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
			Quaternion quaternion = (t.endValue *= t.startValue);
			_ = quaternion.y;
			_ = quaternion.z;
			_ = quaternion.w;
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0x107A990", Offset = "0x107A990", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.changeValue = t.endValue;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+140]) = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]);\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+148]) = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Quaternion, Quaternion, NoOptions> t)
		{
			t.changeValue = t.endValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+130]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			_ = 0;
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0x107A9C0", Offset = "0x107A9C0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0x10CC508(&changeValue @ V1 (System.Single), 0, methodInfo, v22, v23, v24, v25, v26, unitsXSecond, changeValue, *([changeValue @ V1 (System.Single)+4]), *([changeValue @ V1 (System.Single)+8]), *([changeValue @ V1 (System.Single)+C]), v27, v28, v29);\n\tv35 = 0x158AD58(&unitsXSecond @ V0 (DG.Tweening.Plugins.Options.NoOptions), 0, methodInfo, v22, v23, v24, v25, v26, unitsXSecond, changeValue, *([changeValue @ V1 (System.Single)+4]), *([changeValue @ V1 (System.Single)+8]), *([changeValue @ V1 (System.Single)+C]), v27, v28, v29);\n\treturnVal1 = unitsXSecond / unitsXSecond;\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, Quaternion changeValue)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			return unitsXSecond / unitsXSecond;
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0x107AA10", Offset = "0x107AA10", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\t*([v30 @ X29_v1-18]) = startValue.z;\n\t*([v30 @ X29_v1-14]) = startValue.w;\n\tgoto L_0032;\n\tv51 = *([1EABC78]);\n\tv52 = *([v51 @ X8_v13]);\n\tv53 = \"il2cpp_codegen_initialize_method\"(v52, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, v0, v2, v3, duration, v60, v61);\n\tv65 = 0 | 1;\n\t*([20269E5]) = v65;\nL_0032:\n\tv73 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, *([v30 @ X29_v1+20]), t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_004A;\n\tv116 = *([v112 @ X0_v6+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_004A;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v112, v68, t, isRelative, getter, setter, usingInversePosition, updateNotice, v73, v72, v69, v70, v3, duration, v60, v61);\nL_004A:\n\t// 74 MakeStruct v78 @ AGG107AAE0_0_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), startValue @ V1 (UnityEngine.Quaternion), startValue.y (System.Single), [v30 @ X29_v1-18], [v30 @ X29_v1-14]\n\t// 75 MakeStruct v75 @ AGG107AAE0_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v30 @ X29_v1+10], [v30 @ X29_v1+14], [v30 @ X29_v1+18], [v30 @ X29_v1+1C]\n\tv92 = UnityEngine.Quaternion::Slerp(v78, v75, v73);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::Invoke(setter, v92);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Quaternion startValue, Quaternion changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_005a: Expected F4, but got I
			//IL_009c: Expected F4, but got I
			//IL_00b1: Expected F4, but got I
			//IL_00c6: Expected F4, but got I
			//IL_00db: Expected F4, but got I
			//IL_00f0: Expected F4, but got I
			//IL_0105: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = startValue.z;
			_ = startValue.w;
			Ease easeType = t.easeType;
			EaseFunction customEase = t.customEase;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+20]");
			float t2 = EaseManager.Evaluate(easeType, customEase, elapsed, 0f, t.easeOvershootOrAmplitude, t.easePeriod);
			Quaternion a = default(Quaternion);
			Quaternion quaternion = default(Quaternion);
			a.x = quaternion.x;
			a.y = startValue.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-18]");
			a.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-14]");
			a.w = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+10]");
			Quaternion b = default(Quaternion);
			b.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+14]");
			b.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+18]");
			b.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1+1C]");
			b.w = 0f;
			Quaternion pNewValue = Quaternion.Slerp(a, b, t2);
			setter(pNewValue);
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0x107A63C", Offset = "0x107A63C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBD4B0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269E6]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Quaternion, UnityEngine.Quaternion, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PureQuaternionPlugin()
		{
		}
	}
}
