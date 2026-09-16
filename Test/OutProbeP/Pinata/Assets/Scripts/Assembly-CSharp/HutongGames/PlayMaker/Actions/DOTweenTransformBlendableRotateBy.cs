using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750CF4", Offset = "0x750CF4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750CF4", Offset = "0x750CF4")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750CF4", Offset = "0x750CF4")]
	[Token(Token = "0x20000F1")]
	public class DOTweenTransformBlendableRotateBy : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7925D4", Offset = "0x7925D4")]
		[Token(Token = "0x4000CD0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792648", Offset = "0x792648")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792648", Offset = "0x792648")]
		[Token(Token = "0x4000CD1")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 by;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7926A8", Offset = "0x7926A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7926A8", Offset = "0x7926A8")]
		[Token(Token = "0x4000CD2")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7926F8", Offset = "0x7926F8")]
		[Token(Token = "0x4000CD3")]
		[FieldOffset(Offset = "0x68")]
		public RotateMode rotateMode;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792730", Offset = "0x792730")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792730", Offset = "0x792730")]
		[Token(Token = "0x4000CD4")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792790", Offset = "0x792790")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792790", Offset = "0x792790")]
		[Token(Token = "0x4000CD5")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7927E0", Offset = "0x7927E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7927E0", Offset = "0x7927E0")]
		[Token(Token = "0x4000CD6")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792830", Offset = "0x792830")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792830", Offset = "0x792830")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792830", Offset = "0x792830")]
		[Token(Token = "0x4000CD7")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7928A4", Offset = "0x7928A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7928A4", Offset = "0x7928A4")]
		[Token(Token = "0x4000CD8")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7928F4", Offset = "0x7928F4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7928F4", Offset = "0x7928F4")]
		[Token(Token = "0x4000CD9")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792944", Offset = "0x792944")]
		[Token(Token = "0x4000CDA")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792958", Offset = "0x792958")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792958", Offset = "0x792958")]
		[Token(Token = "0x4000CDB")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7929A8", Offset = "0x7929A8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7929A8", Offset = "0x7929A8")]
		[Token(Token = "0x4000CDC")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7929F8", Offset = "0x7929F8")]
		[Token(Token = "0x4000CDD")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792A30", Offset = "0x792A30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792A30", Offset = "0x792A30")]
		[Token(Token = "0x4000CDE")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792A80", Offset = "0x792A80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792A80", Offset = "0x792A80")]
		[Token(Token = "0x4000CDF")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792AD0", Offset = "0x792AD0")]
		[Token(Token = "0x4000CE0")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792B08", Offset = "0x792B08")]
		[Token(Token = "0x4000CE1")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x4000CE2")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792B40", Offset = "0x792B40")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792B40", Offset = "0x792B40")]
		[Token(Token = "0x4000CE3")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792B90", Offset = "0x792B90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792B90", Offset = "0x792B90")]
		[Token(Token = "0x4000CE4")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792BE0", Offset = "0x792BE0")]
		[Token(Token = "0x4000CE5")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792C18", Offset = "0x792C18")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792C18", Offset = "0x792C18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792C18", Offset = "0x792C18")]
		[Token(Token = "0x4000CE6")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792C8C", Offset = "0x792C8C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792C8C", Offset = "0x792C8C")]
		[Token(Token = "0x4000CE7")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792CDC", Offset = "0x792CDC")]
		[Token(Token = "0x4000CE8")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792D14", Offset = "0x792D14")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792D14", Offset = "0x792D14")]
		[Token(Token = "0x4000CE9")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792D64", Offset = "0x792D64")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792D64", Offset = "0x792D64")]
		[Token(Token = "0x4000CEA")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000CEB")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x6000587")]
		[Address(RVA = "0xA77370", Offset = "0xA77370", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EC4790]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202213A]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.by = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tthis.rotateMode = 0;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01f3: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			by = fsmVector;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			rotateMode = default(RotateMode);
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			setRelative = fsmBool2;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			playInReverse = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.useVariable = false;
			fsmBool4.value = false;
			startEvent = null;
			finishEvent = null;
			setReverseRelative = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.useVariable = false;
			fsmBool5.value = false;
			finishImmediately = fsmBool5;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			stringAsId = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			tagAsId = fsmString2;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.Value = 0f;
			startDelay = fsmFloat2;
			selectedEase = SelectedEase.EaseType;
			FsmInt fsmInt = new FsmInt();
			fsmInt.Value = 0;
			loops = fsmInt;
			loopType = default(LoopType);
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = true;
			autoKillOnCompletion = fsmBool6;
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = false;
			recyclable = fsmBool7;
			updateType = default(UpdateType);
			FsmBool fsmBool8 = new FsmBool();
			fsmBool8.value = false;
			isIndependentUpdate = fsmBool8;
			FsmBool fsmBool9 = new FsmBool();
			fsmBool9.value = false;
			debugThis = fsmBool9;
		}

		[Token(Token = "0x6000588")]
		[Address(RVA = "0xA77610", Offset = "0xA77610", Length = "0x3F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1F000F0]);\n\tv31 = *([v30 @ X8_v52]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202213B]) = v50;\nL_001E:\n\tv55 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv197 = UnityEngine.GameObject::GetComponent(v55);\n\tv96 = HutongGames.PlayMaker.FsmVector3::get_Value(this.by);\n\tv259 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv198 = DG.Tweening.ShortcutExtensions::DOBlendableRotateBy(v197, v96, v259, this.rotateMode);\n\tthis.tween = v198;\n\tv263 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv265 = v263 == 0;\n\tif (v265) goto L_0053;\n\tv270 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0053:\n\tv273 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv276 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v273);\n\tv279 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v279);\n\tv98 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv285 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v98);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv288 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v288, this.loopType);\n\tv293 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv296 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v293);\n\tv298 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv301 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v298);\n\tv303 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv306 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v303);\n\tv307 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv309 = v307 == 0;\n\tif (v309) goto L_00C4;\n\tv324 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv315 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v324);\nL_00C4:\n\tv322 = this.startEvent == 0;\n\tif (v322) goto L_00DC;\n\tv329 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v329, this, Il2CppMethodInfo);\n\tv335 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v329);\nL_00DC:\n\tv344 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv348 = v344 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_00FE;\n\tv355 = new DG.Tweening.TweenCallback();\n\tv364 = this.finishEvent == 0;\n\tif (v364) goto L_FFFFFFFF;\n\tgoto L_00F3;\nL_00F3:\n\tDG.Tweening.TweenCallback::.ctor(v355, this, *([v376 @ X8_v33 (Il2CppMethodInfo)]));\n\tv362 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v355);\nL_00FE:\n\tv369 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv375 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv381 = v375 == 0;\n\tif (v381) goto L_0111;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Blendable Rotate By\");\nL_0111:\n\tv244 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv246 = v244 == 0;\n\tif (v246) goto L_012F;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 243 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			Vector3 value = by.Value;
			float value2 = duration.Value;
			Tweener tweener = component.DOBlendableRotateBy(value, value2, rotateMode);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			bool value3 = setRelative.Value;
			Tweener tweener3 = tween.SetRelative(value3);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value4 = startDelay.Value;
			Tweener tweener4 = tween.SetDelay(value4);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value5 = loops.Value;
			Tweener tweener5 = tween.SetLoops(value5, loopType);
			bool value6 = autoKillOnCompletion.Value;
			Tweener tweener6 = tween.SetAutoKill(value6);
			bool value7 = recyclable.Value;
			Tweener tweener7 = tween.SetRecyclable(value7);
			bool value8 = isIndependentUpdate.Value;
			Tweener tweener8 = tween.SetUpdate(updateType, value8);
			if (playInReverse.Value)
			{
				bool value9 = setReverseRelative.Value;
				Tweener tweener9 = tween.From(value9);
			}
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener10 = tween.OnStart(action);
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
				Tweener tweener11 = tween.OnComplete(action2);
			}
			Tweener tweener12 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Transform Blendable Rotate By");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000589")]
		[Address(RVA = "0xA77A04", Offset = "0xA77A04", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC5708]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202213C]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformBlendableRotateBy()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
