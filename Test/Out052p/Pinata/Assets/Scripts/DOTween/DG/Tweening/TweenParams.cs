using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Easing;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000016")]
	public class TweenParams
	{
		[Token(Token = "0x4000078")]
		public static readonly TweenParams Params;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x10")]
		internal object id;

		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x18")]
		internal object target;

		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x20")]
		internal UpdateType updateType;

		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x24")]
		internal bool isIndependentUpdate;

		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x28")]
		internal TweenCallback onStart;

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x30")]
		internal TweenCallback onPlay;

		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x38")]
		internal TweenCallback onRewind;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x40")]
		internal TweenCallback onUpdate;

		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x48")]
		internal TweenCallback onStepComplete;

		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x50")]
		internal TweenCallback onComplete;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x58")]
		internal TweenCallback onKill;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x60")]
		internal TweenCallback<int> onWaypointChange;

		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x68")]
		internal bool isRecyclable;

		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x69")]
		internal bool isSpeedBased;

		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x6A")]
		internal bool autoKill;

		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x6C")]
		internal int loops;

		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x70")]
		internal LoopType loopType;

		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x74")]
		internal float delay;

		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x78")]
		internal bool isRelative;

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x7C")]
		internal Ease easeType;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x80")]
		internal EaseFunction customEase;

		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x88")]
		internal float easeOvershootOrAmplitude;

		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x8C")]
		internal float easePeriod;

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x1605290", Offset = "0x1605290", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = DG.Tweening.TweenParams::Clear(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams()
		{
			TweenParams tweenParams = Clear();
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x16052B8", Offset = "0x16052B8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECA188]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1CE]) = v38;\nL_0013:\n\tthis.id = 0;\n\tthis.target = 0;\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = DG.Tweening.DOTween;\nL_0026:\n\tthis.updateType = v52.defaultUpdateType;\n\tthis.onKill = 0;\n\tthis.onStepComplete = 0;\n\tthis.onRewind = 0;\n\tthis.onStart = 0;\n\tthis.isIndependentUpdate = v56.defaultTimeScaleIndependent;\n\tthis.isSpeedBased = 0;\n\tthis.isRecyclable = v58.defaultRecyclable;\n\tthis.loops = 1;\n\tthis.autoKill = v60.defaultAutoKill;\n\tthis.isRelative = 0;\n\tthis.easeType = 0;\n\tthis.customEase = 0;\n\tthis.loopType = v62.defaultLoopType;\n\tthis.delay = 0f;\n\tthis.easeOvershootOrAmplitude = v64.defaultEaseOvershootOrAmplitude;\n\tthis.easePeriod = v66.defaultEasePeriod;\n\treturn this;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams Clear()
		{
			id = null;
			target = null;
			updateType = DOTween.defaultUpdateType;
			onKill = null;
			onStepComplete = null;
			onRewind = null;
			onStart = null;
			isIndependentUpdate = DOTween.defaultTimeScaleIndependent;
			isSpeedBased = false;
			isRecyclable = DOTween.defaultRecyclable;
			loops = 1;
			autoKill = DOTween.defaultAutoKill;
			isRelative = false;
			easeType = default(Ease);
			customEase = null;
			loopType = DOTween.defaultLoopType;
			delay = 0f;
			easeOvershootOrAmplitude = DOTween.defaultEaseOvershootOrAmplitude;
			easePeriod = DOTween.defaultEasePeriod;
			return this;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x16053A4", Offset = "0x16053A4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.autoKill = autoKillOnCompletion;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetAutoKill(bool autoKillOnCompletion = true)
		{
			autoKill = autoKillOnCompletion;
			return this;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x16053B0", Offset = "0x16053B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = id;\n\treturn this;\n")]
		public TweenParams SetId(object id)
		{
			this.id = id;
			return this;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x16053B8", Offset = "0x16053B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = target;\n\treturn this;\n")]
		public TweenParams SetTarget(object target)
		{
			this.target = target;
			return this;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x16053C0", Offset = "0x16053C0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv27 = *([1EE7480]);\n\tv28 = *([v27 @ X8_v13]);\n\tv29 = \"il2cpp_codegen_initialize_method\"(v28, loops, loopType, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202A1CF]) = v45;\nL_001C:\n\tv50 = loops == 0;\n\tv55 = ~v50;\n\tv56 = ~v55;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_0028;\nL_0028:\n\tv60 = loops + 1;\n\tv61 = v60 < 0;\n\tv65 = v61 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv70 = loopType & 0xFF00000000;\n\tthis.loops = v69;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0046;\n\tv76 = 0x115C1C4(&loopType @ X2 (System.Nullable`1<DG.Tweening.LoopType>), Il2CppMethodInfo, loopType, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis.loopType = v76;\nL_0046:\n\treturn this;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetLoops(int loops, LoopType? loopType = null)
		{
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected I4, but got Unknown
			int num = ((loops == 0) ? 1 : loops);
			int num2 = loops + 1;
			if (num2 < 0)
			{
				num = -1;
			}
			int num3 = (int)((_003F?)loopType & 0xFF00000000L);
			this.loops = num;
			if (num3 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C1C4 (inside System.Nullable`1<System.Int32>::Unbox +0xC0)");
				LoopType loopType2 = default(LoopType);
				this.loopType = loopType2;
			}
			return this;
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x1605454", Offset = "0x1605454", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv29 = *([1EDBC50]);\n\tv30 = *([v29 @ X8_v20]);\n\tv31 = \"il2cpp_codegen_initialize_method\"(v30, ease, overshootOrAmplitude, period, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202A1D0]) = v46;\nL_0019:\n\tv47 = overshootOrAmplitude & 0xFF00000000;\n\tthis.easeType = ease;\n\tv48 = v47 == 0;\n\tif (v48) goto L_0029;\n\tv53 = 0x115CAB0(&overshootOrAmplitude @ X2 (System.Nullable`1<System.Single>), Il2CppMethodInfo, overshootOrAmplitude, period, methodInfo, v33, v34, v35, v99, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0032;\nL_0029:\n\tgoto L_0031;\n\tv60 = *([v56 @ X0_v11 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0031;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v56, ease, overshootOrAmplitude, period, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv64 = DG.Tweening.DOTween;\nL_0031:\n\tv99 = v67.defaultEaseOvershootOrAmplitude;\nL_0032:\n\tthis.easeOvershootOrAmplitude = v99;\n\tv77 = v76 == 0;\n\tif (v77) goto L_0042;\n\tv83 = 0x115CAB0(&period @ X3 (System.Nullable`1<System.Single>), Il2CppMethodInfo, overshootOrAmplitude, period, methodInfo, v33, v34, v35, v99, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_004B;\nL_0042:\n\tgoto L_004A;\n\tv90 = *([v86 @ X0_v5 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_004A;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v86, v70, overshootOrAmplitude, period, methodInfo, v33, v34, v35, v69, v37, v38, v39, v40, v41, v42, v43);\n\tv94 = DG.Tweening.DOTween;\nL_004A:\n\tv99 = v97.defaultEasePeriod;\nL_004B:\n\tthis.easePeriod = v99;\n\tthis.customEase = 0;\n\treturn this;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetEase(Ease ease, float? overshootOrAmplitude = null, float? period = null)
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected I4, but got Unknown
			int num = (int)((_003F?)overshootOrAmplitude & 0xFF00000000L);
			easeType = ease;
			float num2 = default(float);
			if (num != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115CAB0 (inside System.Nullable`1<System.Int64>::Unbox +0xC0)");
			}
			else
			{
				num2 = DOTween.defaultEaseOvershootOrAmplitude;
			}
			easeOvershootOrAmplitude = num2;
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115CAB0 (inside System.Nullable`1<System.Int64>::Unbox +0xC0)");
			}
			else
			{
				num2 = DOTween.defaultEasePeriod;
			}
			easePeriod = num2;
			customEase = null;
			return this;
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x160555C", Offset = "0x160555C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EFB138]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, animCurve, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1D1]) = v41;\nL_0016:\n\tthis.easeType = 0x25;\n\tv46 = new DG.Tweening.Core.Easing.EaseCurve();\n\tDG.Tweening.Core.Easing.EaseCurve::.ctor(v46, animCurve);\n\tv53 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v53, v46, Il2CppMethodInfo);\n\tthis.customEase = v53;\n\treturn this;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetEase(AnimationCurve animCurve)
		{
			easeType = Ease.INTERNAL_Custom;
			EaseCurve easeCurve = new EaseCurve(animCurve);
			EaseFunction easeFunction = easeCurve.Evaluate;
			customEase = easeFunction;
			return this;
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x1605604", Offset = "0x1605604", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.easeType = 0x25;\n\tthis.customEase = customEase;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetEase(EaseFunction customEase)
		{
			easeType = Ease.INTERNAL_Custom;
			this.customEase = customEase;
			return this;
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x1605614", Offset = "0x1605614", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isRecyclable = recyclable;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetRecyclable(bool recyclable = true)
		{
			isRecyclable = recyclable;
			return this;
		}

		[Token(Token = "0x600010B")]
		[Address(RVA = "0x1605620", Offset = "0x1605620", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA6998]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, isIndependentUpdate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1D2]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v44, isIndependentUpdate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = DG.Tweening.DOTween;\nL_0026:\n\tthis.isIndependentUpdate = isIndependentUpdate;\n\tthis.updateType = v55.defaultUpdateType;\n\treturn this;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetUpdate(bool isIndependentUpdate)
		{
			this.isIndependentUpdate = isIndependentUpdate;
			updateType = DOTween.defaultUpdateType;
			return this;
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0x16056A8", Offset = "0x16056A8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateType = updateType;\n\tthis.isIndependentUpdate = isIndependentUpdate;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetUpdate(UpdateType updateType, bool isIndependentUpdate = false)
		{
			this.updateType = updateType;
			this.isIndependentUpdate = isIndependentUpdate;
			return this;
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0x16056B8", Offset = "0x16056B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onStart = action;\n\treturn this;\n")]
		public TweenParams OnStart(TweenCallback action)
		{
			onStart = action;
			return this;
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x16056C0", Offset = "0x16056C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onPlay = action;\n\treturn this;\n")]
		public TweenParams OnPlay(TweenCallback action)
		{
			onPlay = action;
			return this;
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x16056C8", Offset = "0x16056C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onRewind = action;\n\treturn this;\n")]
		public TweenParams OnRewind(TweenCallback action)
		{
			onRewind = action;
			return this;
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x16056D0", Offset = "0x16056D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onUpdate = action;\n\treturn this;\n")]
		public TweenParams OnUpdate(TweenCallback action)
		{
			onUpdate = action;
			return this;
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x16056D8", Offset = "0x16056D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onStepComplete = action;\n\treturn this;\n")]
		public TweenParams OnStepComplete(TweenCallback action)
		{
			onStepComplete = action;
			return this;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x16056E0", Offset = "0x16056E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onComplete = action;\n\treturn this;\n")]
		public TweenParams OnComplete(TweenCallback action)
		{
			onComplete = action;
			return this;
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x16056E8", Offset = "0x16056E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onKill = action;\n\treturn this;\n")]
		public TweenParams OnKill(TweenCallback action)
		{
			onKill = action;
			return this;
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x16056F0", Offset = "0x16056F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onWaypointChange = action;\n\treturn this;\n")]
		public TweenParams OnWaypointChange(TweenCallback<int> action)
		{
			onWaypointChange = action;
			return this;
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x16056F8", Offset = "0x16056F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.delay = delay;\n\treturn this;\n")]
		public TweenParams SetDelay(float delay)
		{
			this.delay = delay;
			return this;
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x1605700", Offset = "0x1605700", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isRelative = isRelative;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetRelative(bool isRelative = true)
		{
			this.isRelative = isRelative;
			return this;
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x160570C", Offset = "0x160570C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isSpeedBased = isSpeedBased;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetSpeedBased(bool isSpeedBased = true)
		{
			this.isSpeedBased = isSpeedBased;
			return this;
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x1605718", Offset = "0x1605718", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ECB330]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A1D3]) = v37;\nL_0015:\n\tv41 = new DG.Tweening.TweenParams();\n\tSystem.Object::.ctor(v41);\n\tv45 = DG.Tweening.TweenParams::Clear(v41);\n\tv47.Params = v41;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static TweenParams()
		{
			TweenParams tweenParams = new TweenParams();
			TweenParams tweenParams2 = tweenParams.Clear();
			Params = tweenParams;
		}
	}
}
