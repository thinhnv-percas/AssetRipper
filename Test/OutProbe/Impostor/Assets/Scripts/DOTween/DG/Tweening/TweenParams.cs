using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Easing;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x200006C")]
	public class TweenParams
	{
		[Token(Token = "0x40000FD")]
		public static readonly TweenParams Params;

		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x10")]
		internal object id;

		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x18")]
		internal string stringId;

		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x20")]
		internal int intId;

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x28")]
		internal object target;

		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x30")]
		internal UpdateType updateType;

		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x34")]
		internal bool isIndependentUpdate;

		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x38")]
		internal TweenCallback onStart;

		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x40")]
		internal TweenCallback onPlay;

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x48")]
		internal TweenCallback onRewind;

		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x50")]
		internal TweenCallback onUpdate;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x58")]
		internal TweenCallback onStepComplete;

		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x60")]
		internal TweenCallback onComplete;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x68")]
		internal TweenCallback onKill;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x70")]
		internal TweenCallback<int> onWaypointChange;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x78")]
		internal bool isRecyclable;

		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x79")]
		internal bool isSpeedBased;

		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x7A")]
		internal bool autoKill;

		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x7C")]
		internal int loops;

		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x80")]
		internal LoopType loopType;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x84")]
		internal float delay;

		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x88")]
		internal bool isRelative;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x8C")]
		internal Ease easeType;

		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x90")]
		internal EaseFunction customEase;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x98")]
		internal float easeOvershootOrAmplitude;

		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x9C")]
		internal float easePeriod;

		[Token(Token = "0x600022A")]
		[Address(RVA = "0xC1B694", Offset = "0xC1B694", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.intId = 0xFFFFFC19;\n\tSystem.Object::.ctor(this);\n\tv11 = DG.Tweening.TweenParams::Clear(this);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams()
		{
			intId = -999;
			TweenParams tweenParams = Clear();
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0xC1B6B8", Offset = "0xC1B6B8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35747]) = v37;\nL_0014:\n\tthis.target = 0;\n\tthis.id = 0;\n\tthis.stringId = 0;\n\tthis.intId = 0xFFFFFC19;\n\tgoto L_0024;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = DG.Tweening.DOTween;\nL_0024:\n\tthis.updateType = v46.defaultUpdateType;\n\tthis.onStart = 0;\n\tthis.onRewind = 0;\n\tthis.onStepComplete = 0;\n\tthis.onKill = 0;\n\tthis.isIndependentUpdate = v46.defaultTimeScaleIndependent;\n\tthis.isSpeedBased = 0;\n\tthis.isRecyclable = v46.defaultRecyclable;\n\tthis.loops = 1;\n\tthis.autoKill = v46.defaultAutoKill;\n\tthis.isRelative = 0;\n\tthis.easeType = 0;\n\tthis.customEase = 0;\n\tthis.loopType = v46.defaultLoopType;\n\tthis.delay = 0f;\n\tthis.easeOvershootOrAmplitude = v46.defaultEaseOvershootOrAmplitude;\n\treturn this;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams Clear()
		{
			target = null;
			id = null;
			stringId = null;
			intId = -999;
			updateType = DOTween.defaultUpdateType;
			onStart = null;
			onRewind = null;
			onStepComplete = null;
			onKill = null;
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
			return this;
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0xC1B780", Offset = "0xC1B780", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.autoKill = autoKillOnCompletion;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetAutoKill(bool autoKillOnCompletion = true)
		{
			autoKill = autoKillOnCompletion;
			return this;
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0xC1B78C", Offset = "0xC1B78C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = objectId;\n\treturn this;\n")]
		public TweenParams SetId(object objectId)
		{
			id = objectId;
			return this;
		}

		[Token(Token = "0x600022E")]
		[Address(RVA = "0xC1B794", Offset = "0xC1B794", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stringId = stringId;\n\treturn this;\n")]
		public TweenParams SetId(string stringId)
		{
			this.stringId = stringId;
			return this;
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0xC1B79C", Offset = "0xC1B79C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.intId = intId;\n\treturn this;\n")]
		public TweenParams SetId(int intId)
		{
			this.intId = intId;
			return this;
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0xC1B7A4", Offset = "0xC1B7A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = target;\n\treturn this;\n")]
		public TweenParams SetTarget(object target)
		{
			this.target = target;
			return this;
		}

		[Token(Token = "0x6000231")]
		[Address(RVA = "0xC1B7AC", Offset = "0xC1B7AC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv23 = Il2CppMethodInfo;\n\tv24 = \"il2cpp_codegen_initialize_runtime_metadata\"(v23, loops, loopType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv54 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, loops, loopType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35748]) = v41;\nL_001C:\n\tv46 = loops == 0;\n\tv51 = ~v46;\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\n\tgoto L_0028;\nL_0028:\n\tv58 = loops + 1;\n\tv59 = v58 < 0;\n\tv63 = v59 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv68 = loopType & 0xFF;\n\tv70 = v68 == 0;\n\tthis.loops = v67;\n\tif (v70) goto L_0048;\n\tv77 = System.Nullable`1<System.Int32Enum>::get_Value(&loopType @ X2 (System.Nullable`1<DG.Tweening.LoopType>));\n\tthis.loopType = v77;\nL_0048:\n\treturn this;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe TweenParams SetLoops(int loops, LoopType? loopType = null)
		{
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected I4, but got Unknown
			int num = ((loops == 0) ? 1 : loops);
			int num2 = loops + 1;
			if (num2 < 0)
			{
				num = -1;
			}
			int num3 = (_003F?)loopType & 0xFF;
			bool flag = num3 == 0;
			this.loops = num;
			if (!flag)
			{
				LoopType? loopType2 = default(LoopType?);
				LoopType value = (LoopType)((System.Int32Enum?*)(&loopType2))->Value;
				this.loopType = value;
			}
			return this;
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0xC1B83C", Offset = "0xC1B83C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv25 = DG.Tweening.DOTween;\n\tv26 = \"il2cpp_codegen_initialize_runtime_metadata\"(v25, ease, overshootOrAmplitude, period, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, ease, overshootOrAmplitude, period, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv63 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, ease, overshootOrAmplitude, period, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35749]) = v42;\nL_001E:\n\tv45 = overshootOrAmplitude & 0xFF;\n\tv47 = v45 == 0;\n\tthis.easeType = ease;\n\tif (v47) goto L_002F;\n\tv69 = System.Nullable`1<System.Single>::get_Value(&overshootOrAmplitude @ X2 (System.Nullable`1<System.Single>));\n\tgoto L_0034;\nL_002F:\n\tgoto L_0033;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v58, ease, overshootOrAmplitude, period, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv66 = DG.Tweening.DOTween;\nL_0033:\n\tv69 = v67.defaultEaseOvershootOrAmplitude;\nL_0034:\n\tthis.easeOvershootOrAmplitude = v69;\n\tv76 = period == 0;\n\tif (v76) goto L_0042;\n\tv91 = System.Nullable`1<System.Single>::get_Value(&period @ X3 (System.Nullable`1<System.Single>));\n\tgoto L_0047;\nL_0042:\n\tgoto L_0046;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v82, v70, overshootOrAmplitude, period, methodInfo, v28, v29, v30, v69, v32, v33, v34, v35, v36, v37, v38);\n\tv88 = DG.Tweening.DOTween;\nL_0046:\n\tv91 = v89.defaultEasePeriod;\nL_0047:\n\tthis.easePeriod = v91;\n\tthis.customEase = 0;\n\treturn this;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetEase(Ease ease, float? overshootOrAmplitude = null, float? period = null)
		{
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected I4, but got Unknown
			int num = (_003F?)overshootOrAmplitude & 0xFF;
			bool flag = num == 0;
			easeType = ease;
			float? num3 = default(float?);
			float num2 = (flag ? DOTween.defaultEaseOvershootOrAmplitude : num3.Value);
			easeOvershootOrAmplitude = num2;
			float? num5 = default(float?);
			float num4 = (((object)period == null) ? DOTween.defaultEasePeriod : num5.Value);
			easePeriod = num4;
			customEase = null;
			return this;
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0xC1B93C", Offset = "0xC1B93C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, animCurve, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv54 = DG.Tweening.Core.Easing.EaseCurve;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, animCurve, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv60 = DG.Tweening.EaseFunction;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, animCurve, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A3574A]) = v49;\nL_0022:\n\tthis.easeType = 0x25;\n\tv52 = new DG.Tweening.Core.Easing.EaseCurve();\n\tDG.Tweening.Core.Easing.EaseCurve::.ctor(v52, animCurve);\n\tv62 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v62, v52, Il2CppMethodInfo);\n\tthis.customEase = v62;\n\treturn this;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetEase(AnimationCurve animCurve)
		{
			easeType = Ease.INTERNAL_Custom;
			EaseCurve easeCurve = new EaseCurve(animCurve);
			EaseFunction easeFunction = easeCurve.Evaluate;
			customEase = easeFunction;
			return this;
		}

		[Token(Token = "0x6000234")]
		[Address(RVA = "0xC1B9F8", Offset = "0xC1B9F8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.easeType = 0x25;\n\tthis.customEase = customEase;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetEase(EaseFunction customEase)
		{
			easeType = Ease.INTERNAL_Custom;
			this.customEase = customEase;
			return this;
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0xC1BA08", Offset = "0xC1BA08", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isRecyclable = recyclable;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetRecyclable(bool recyclable = true)
		{
			isRecyclable = recyclable;
			return this;
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0xC1BA14", Offset = "0xC1BA14", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3574B]) = v40;\nL_0019:\n\tgoto L_0022;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = DG.Tweening.DOTween;\nL_0022:\n\tthis.isIndependentUpdate = isIndependentUpdate;\n\tthis.updateType = v48.defaultUpdateType;\n\treturn this;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetUpdate(bool isIndependentUpdate)
		{
			this.isIndependentUpdate = isIndependentUpdate;
			updateType = DOTween.defaultUpdateType;
			return this;
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xC1BA8C", Offset = "0xC1BA8C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateType = updateType;\n\tthis.isIndependentUpdate = isIndependentUpdate;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetUpdate(UpdateType updateType, bool isIndependentUpdate = false)
		{
			this.updateType = updateType;
			this.isIndependentUpdate = isIndependentUpdate;
			return this;
		}

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xC1BA9C", Offset = "0xC1BA9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onStart = action;\n\treturn this;\n")]
		public TweenParams OnStart(TweenCallback action)
		{
			onStart = action;
			return this;
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0xC1BAA4", Offset = "0xC1BAA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onPlay = action;\n\treturn this;\n")]
		public TweenParams OnPlay(TweenCallback action)
		{
			onPlay = action;
			return this;
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0xC1BAAC", Offset = "0xC1BAAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onRewind = action;\n\treturn this;\n")]
		public TweenParams OnRewind(TweenCallback action)
		{
			onRewind = action;
			return this;
		}

		[Token(Token = "0x600023B")]
		[Address(RVA = "0xC1BAB4", Offset = "0xC1BAB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onUpdate = action;\n\treturn this;\n")]
		public TweenParams OnUpdate(TweenCallback action)
		{
			onUpdate = action;
			return this;
		}

		[Token(Token = "0x600023C")]
		[Address(RVA = "0xC1BABC", Offset = "0xC1BABC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onStepComplete = action;\n\treturn this;\n")]
		public TweenParams OnStepComplete(TweenCallback action)
		{
			onStepComplete = action;
			return this;
		}

		[Token(Token = "0x600023D")]
		[Address(RVA = "0xC1BAC4", Offset = "0xC1BAC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onComplete = action;\n\treturn this;\n")]
		public TweenParams OnComplete(TweenCallback action)
		{
			onComplete = action;
			return this;
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0xC1BACC", Offset = "0xC1BACC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onKill = action;\n\treturn this;\n")]
		public TweenParams OnKill(TweenCallback action)
		{
			onKill = action;
			return this;
		}

		[Token(Token = "0x600023F")]
		[Address(RVA = "0xC1BAD4", Offset = "0xC1BAD4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onWaypointChange = action;\n\treturn this;\n")]
		public TweenParams OnWaypointChange(TweenCallback<int> action)
		{
			onWaypointChange = action;
			return this;
		}

		[Token(Token = "0x6000240")]
		[Address(RVA = "0xC1BADC", Offset = "0xC1BADC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.delay = delay;\n\treturn this;\n")]
		public TweenParams SetDelay(float delay)
		{
			this.delay = delay;
			return this;
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0xC1BAE4", Offset = "0xC1BAE4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isRelative = isRelative;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetRelative(bool isRelative = true)
		{
			this.isRelative = isRelative;
			return this;
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0xC1BAF0", Offset = "0xC1BAF0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isSpeedBased = isSpeedBased;\n\treturn this;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenParams SetSpeedBased(bool isSpeedBased = true)
		{
			this.isSpeedBased = isSpeedBased;
			return this;
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0xC1BAFC", Offset = "0xC1BAFC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = DG.Tweening.TweenParams;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3574C]) = v34;\nL_0012:\n\tv36 = new DG.Tweening.TweenParams();\n\tv36.intId = 0xFFFFFC19;\n\tSystem.Object::.ctor(v36);\n\tv41 = DG.Tweening.TweenParams::Clear(v36);\n\tv43.Params = v36;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static TweenParams()
		{
			TweenParams tweenParams = new TweenParams
			{
				intId = -999
			};
			TweenParams tweenParams2 = tweenParams.Clear();
			Params = tweenParams;
		}
	}
}
