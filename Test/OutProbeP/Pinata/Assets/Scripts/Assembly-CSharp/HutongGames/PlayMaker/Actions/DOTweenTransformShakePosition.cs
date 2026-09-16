using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7519D8", Offset = "0x7519D8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7519D8", Offset = "0x7519D8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7519D8", Offset = "0x7519D8")]
	[Token(Token = "0x200010A")]
	public class DOTweenTransformShakePosition : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79FBEC", Offset = "0x79FBEC")]
		[Token(Token = "0x4000FB7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FC60", Offset = "0x79FC60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FC60", Offset = "0x79FC60")]
		[Token(Token = "0x4000FB8")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 strength;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FCB0", Offset = "0x79FCB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FCB0", Offset = "0x79FCB0")]
		[Token(Token = "0x4000FB9")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FD00", Offset = "0x79FD00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FD00", Offset = "0x79FD00")]
		[Token(Token = "0x4000FBA")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat randomness;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FD50", Offset = "0x79FD50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FD50", Offset = "0x79FD50")]
		[Token(Token = "0x4000FBB")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FDA0", Offset = "0x79FDA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FDA0", Offset = "0x79FDA0")]
		[Token(Token = "0x4000FBC")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FE00", Offset = "0x79FE00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FE00", Offset = "0x79FE00")]
		[Token(Token = "0x4000FBD")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FE50", Offset = "0x79FE50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FE50", Offset = "0x79FE50")]
		[Token(Token = "0x4000FBE")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79FEA0", Offset = "0x79FEA0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FEA0", Offset = "0x79FEA0")]
		[Token(Token = "0x4000FBF")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FEF0", Offset = "0x79FEF0")]
		[Token(Token = "0x4000FC0")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FF04", Offset = "0x79FF04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FF04", Offset = "0x79FF04")]
		[Token(Token = "0x4000FC1")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79FF54", Offset = "0x79FF54")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FF54", Offset = "0x79FF54")]
		[Token(Token = "0x4000FC2")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FFA4", Offset = "0x79FFA4")]
		[Token(Token = "0x4000FC3")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79FFDC", Offset = "0x79FFDC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79FFDC", Offset = "0x79FFDC")]
		[Token(Token = "0x4000FC4")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A002C", Offset = "0x7A002C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A002C", Offset = "0x7A002C")]
		[Token(Token = "0x4000FC5")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A007C", Offset = "0x7A007C")]
		[Token(Token = "0x4000FC6")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A00B4", Offset = "0x7A00B4")]
		[Token(Token = "0x4000FC7")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000FC8")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A00EC", Offset = "0x7A00EC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A00EC", Offset = "0x7A00EC")]
		[Token(Token = "0x4000FC9")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A013C", Offset = "0x7A013C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A013C", Offset = "0x7A013C")]
		[Token(Token = "0x4000FCA")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A018C", Offset = "0x7A018C")]
		[Token(Token = "0x4000FCB")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A01C4", Offset = "0x7A01C4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A01C4", Offset = "0x7A01C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A01C4", Offset = "0x7A01C4")]
		[Token(Token = "0x4000FCC")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0238", Offset = "0x7A0238")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0238", Offset = "0x7A0238")]
		[Token(Token = "0x4000FCD")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0288", Offset = "0x7A0288")]
		[Token(Token = "0x4000FCE")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A02C0", Offset = "0x7A02C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A02C0", Offset = "0x7A02C0")]
		[Token(Token = "0x4000FCF")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A0310", Offset = "0x7A0310")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0310", Offset = "0x7A0310")]
		[Token(Token = "0x4000FD0")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000FD1")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x6000605")]
		[Address(RVA = "0xA84074", Offset = "0xA84074", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF3008]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022185]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tgoto L_0031;\n\tv141 = *([v56 @ X0_v8+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0031;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v56, v51, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0031:\n\tv72 = UnityEngine.Vector3::get_one();\n\tv50.value = v72;\n\tv50.value.y = v72.y;\n\tv50.value.z = v72.z;\n\tthis.strength = v50;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.useVariable = 0;\n\tv89.value = 0xA;\n\tthis.vibrato = v89;\n\tv90 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v90);\n\tv90.useVariable = 0;\n\tv90.value = 90f;\n\tthis.randomness = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.useVariable = 0;\n\tv91.value = 0;\n\tthis.snapping = v91;\n\tv92 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v92);\n\tv92.useVariable = 0;\n\tthis.duration = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.useVariable = 0;\n\tv93.value = 0;\n\tthis.setSpeedBased = v93;\n\tv94 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v94);\n\tv94.value = 0f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.startDelay = v94;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.useVariable = 0;\n\tv95.value = 0;\n\tthis.finishImmediately = v95;\n\tv96 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v96);\n\tv96.useVariable = 0;\n\tthis.stringAsId = v96;\n\tv97 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v97);\n\tv97.useVariable = 0;\n\tthis.tagAsId = v97;\n\tthis.selectedEase = 0x100000000;\n\tv98 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v98);\n\tv98.value = 0;\n\tthis.loops = v98;\n\tthis.loopType = 0;\n\tv99 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v99);\n\tv99.value = 1;\n\tthis.autoKillOnCompletion = v99;\n\tv100 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v100);\n\tv100.value = 0;\n\tthis.recyclable = v100;\n\tthis.updateType = 0;\n\tv101 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v101);\n\tv101.value = 0;\n\tthis.isIndependentUpdate = v101;\n\tv102 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v102);\n\tv102.value = 0;\n\tthis.debugThis = v102;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_022d: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			Vector3 vector = (fsmVector.value = Vector3.one);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			strength = fsmVector;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 10;
			vibrato = fsmInt;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			fsmFloat.Value = 90f;
			randomness = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			snapping = fsmBool;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			setSpeedBased = fsmBool2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startEvent = null;
			finishEvent = null;
			startDelay = fsmFloat3;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			finishImmediately = fsmBool3;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			stringAsId = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			tagAsId = fsmString2;
			selectedEase = SelectedEase.EaseType;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.Value = 0;
			loops = fsmInt2;
			loopType = default(LoopType);
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.value = true;
			autoKillOnCompletion = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.value = false;
			recyclable = fsmBool5;
			updateType = default(UpdateType);
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = false;
			isIndependentUpdate = fsmBool6;
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = false;
			debugThis = fsmBool7;
		}

		[Token(Token = "0x6000606")]
		[Address(RVA = "0xA84344", Offset = "0xA84344", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1ECB318]);\n\tv35 = *([v34 @ X8_v48]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022186]) = v54;\nL_0020:\n\tv59 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv206 = UnityEngine.GameObject::GetComponent(v59);\n\tv107 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv108 = HutongGames.PlayMaker.FsmVector3::get_Value(this.strength);\n\tv207 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv109 = HutongGames.PlayMaker.FsmFloat::get_Value(this.randomness);\n\tv278 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tv208 = DG.Tweening.ShortcutExtensions::DOShakePosition(v206, v107, v108, v207, v109, v278, 1);\n\tthis.tween = v208;\n\tv282 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv284 = v282 == 0;\n\tif (v284) goto L_006F;\n\tv289 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_006F:\n\tv293 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v293);\n\tv111 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv299 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v111);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv302 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv305 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v302, this.loopType);\n\tv307 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v307);\n\tv312 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv315 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v312);\n\tv319 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv326 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v319);\n\tv328 = this.startEvent == 0;\n\tif (v328) goto L_00D4;\n\tv333 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v333, this, Il2CppMethodInfo);\n\tv339 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v333);\nL_00D4:\n\tv346 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv350 = v346 == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_00F6;\n\tv357 = new DG.Tweening.TweenCallback();\n\tv366 = this.finishEvent == 0;\n\tif (v366) goto L_FFFFFFFF;\n\tgoto L_00EB;\nL_00EB:\n\tDG.Tweening.TweenCallback::.ctor(v357, this, *([v378 @ X8_v31 (Il2CppMethodInfo)]));\n\tv364 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v357);\nL_00F6:\n\tv371 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv377 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv383 = v377 == 0;\n\tif (v383) goto L_0109;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Shake Position\");\nL_0109:\n\tv262 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv264 = v262 == 0;\n\tif (v264) goto L_012B;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 243 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			float value = duration.Value;
			Vector3 value2 = strength.Value;
			int value3 = vibrato.Value;
			float value4 = randomness.Value;
			bool value5 = snapping.Value;
			Tweener tweener = component.DOShakePosition(value, value2, value3, value4, value5);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value6 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value6);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value7 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value7, loopType);
			bool value8 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value8);
			bool value9 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value9);
			bool value10 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value10);
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener8 = tween.OnStart(action);
			}
			if (!finishImmediately.Value)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: TweenCallback");
				TweenCallback action2 = null;
				if (finishEvent != null)
				{
					IntPtr intPtr = (IntPtr)0;
				}
				else
				{
					IntPtr intPtr = (IntPtr)0;
				}
				Tweener tweener9 = tween.OnComplete(action2);
			}
			Tweener tweener10 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Transform Shake Position");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000607")]
		[Address(RVA = "0xA84724", Offset = "0xA84724", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF7528]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022187]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformShakePosition()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
