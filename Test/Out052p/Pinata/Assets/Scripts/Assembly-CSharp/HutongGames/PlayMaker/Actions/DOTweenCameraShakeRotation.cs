using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74DBF8", Offset = "0x74DBF8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74DBF8", Offset = "0x74DBF8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74DBF8", Offset = "0x74DBF8")]
	[Token(Token = "0x2000092")]
	public class DOTweenCameraShakeRotation : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x76DFBC", Offset = "0x76DFBC")]
		[Token(Token = "0x40004DA")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E030", Offset = "0x76E030")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E030", Offset = "0x76E030")]
		[Token(Token = "0x40004DB")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E090", Offset = "0x76E090")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E090", Offset = "0x76E090")]
		[Token(Token = "0x40004DC")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E0E0", Offset = "0x76E0E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E0E0", Offset = "0x76E0E0")]
		[Token(Token = "0x40004DD")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E130", Offset = "0x76E130")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E130", Offset = "0x76E130")]
		[Token(Token = "0x40004DE")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 strength;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E180", Offset = "0x76E180")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E180", Offset = "0x76E180")]
		[Token(Token = "0x40004DF")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E1D0", Offset = "0x76E1D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E1D0", Offset = "0x76E1D0")]
		[Token(Token = "0x40004E0")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat randomness;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E220", Offset = "0x76E220")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E220", Offset = "0x76E220")]
		[Token(Token = "0x40004E1")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E270", Offset = "0x76E270")]
		[Token(Token = "0x40004E2")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E284", Offset = "0x76E284")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E284", Offset = "0x76E284")]
		[Token(Token = "0x40004E3")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E2D4", Offset = "0x76E2D4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E2D4", Offset = "0x76E2D4")]
		[Token(Token = "0x40004E4")]
		[FieldOffset(Offset = "0xA0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E324", Offset = "0x76E324")]
		[Token(Token = "0x40004E5")]
		[FieldOffset(Offset = "0xA8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E35C", Offset = "0x76E35C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E35C", Offset = "0x76E35C")]
		[Token(Token = "0x40004E6")]
		[FieldOffset(Offset = "0xB0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E3AC", Offset = "0x76E3AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E3AC", Offset = "0x76E3AC")]
		[Token(Token = "0x40004E7")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E3FC", Offset = "0x76E3FC")]
		[Token(Token = "0x40004E8")]
		[FieldOffset(Offset = "0xC0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E434", Offset = "0x76E434")]
		[Token(Token = "0x40004E9")]
		[FieldOffset(Offset = "0xC4")]
		public Ease easeType;

		[Token(Token = "0x40004EA")]
		[FieldOffset(Offset = "0xC8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E46C", Offset = "0x76E46C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E46C", Offset = "0x76E46C")]
		[Token(Token = "0x40004EB")]
		[FieldOffset(Offset = "0xD0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E4BC", Offset = "0x76E4BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E4BC", Offset = "0x76E4BC")]
		[Token(Token = "0x40004EC")]
		[FieldOffset(Offset = "0xD8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E50C", Offset = "0x76E50C")]
		[Token(Token = "0x40004ED")]
		[FieldOffset(Offset = "0xE0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E544", Offset = "0x76E544")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E544", Offset = "0x76E544")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E544", Offset = "0x76E544")]
		[Token(Token = "0x40004EE")]
		[FieldOffset(Offset = "0xE8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E5B8", Offset = "0x76E5B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E5B8", Offset = "0x76E5B8")]
		[Token(Token = "0x40004EF")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E608", Offset = "0x76E608")]
		[Token(Token = "0x40004F0")]
		[FieldOffset(Offset = "0xF8")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E640", Offset = "0x76E640")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E640", Offset = "0x76E640")]
		[Token(Token = "0x40004F1")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E690", Offset = "0x76E690")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E690", Offset = "0x76E690")]
		[Token(Token = "0x40004F2")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool debugThis;

		[Token(Token = "0x40004F3")]
		[FieldOffset(Offset = "0x110")]
		private Tweener tween;

		[Token(Token = "0x60003DE")]
		[Address(RVA = "0xAEF2B4", Offset = "0xAEF2B4", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EC2A68]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022427]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.duration = v52;\n\tv59 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v59);\n\tv59.useVariable = 0;\n\tv59.value = 0;\n\tthis.setSpeedBased = v59;\n\tv86 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v86);\n\tv86.useVariable = 0;\n\tgoto L_0049;\n\tv166 = *([v162 @ X0_v12+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0049;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v162, v73, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0049:\n\tv69 = UnityEngine.Vector3::get_zero();\n\tv86.value = v69;\n\tv86.value.y = v69.y;\n\tv86.value.z = v69.z;\n\tthis.strength = v86;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0xA;\n\tthis.vibrato = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 90f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.randomness = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.useVariable = 0;\n\tv89.value = 0;\n\tthis.finishImmediately = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.stringAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v91);\n\tv91.useVariable = 0;\n\tthis.tagAsId = v91;\n\tv92 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v92);\n\tv92.value = 0f;\n\tthis.startDelay = v92;\n\tthis.selectedEase = 0x100000000;\n\tv93 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v93);\n\tv93.value = 0;\n\tthis.loops = v93;\n\tthis.loopType = 0;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 1;\n\tthis.autoKillOnCompletion = v94;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.recyclable = v95;\n\tthis.updateType = 0;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.isIndependentUpdate = v96;\n\tv97 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v97);\n\tv97.value = 0;\n\tthis.debugThis = v97;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01f8: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			Vector3 vector = (fsmVector.value = Vector3.zero);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			strength = fsmVector;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 10;
			vibrato = fsmInt;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			fsmFloat2.Value = 90f;
			startEvent = null;
			finishEvent = null;
			randomness = fsmFloat2;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			finishImmediately = fsmBool2;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			stringAsId = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			tagAsId = fsmString2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
			selectedEase = SelectedEase.EaseType;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.Value = 0;
			loops = fsmInt2;
			loopType = default(LoopType);
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.value = true;
			autoKillOnCompletion = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.value = false;
			recyclable = fsmBool4;
			updateType = default(UpdateType);
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.value = false;
			isIndependentUpdate = fsmBool5;
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = false;
			debugThis = fsmBool6;
		}

		[Token(Token = "0x60003DF")]
		[Address(RVA = "0xAEF564", Offset = "0xAEF564", Length = "0x3BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EA57B8]);\n\tv33 = *([v32 @ X8_v48]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022428]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv195 = UnityEngine.GameObject::GetComponent(v57);\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv103 = HutongGames.PlayMaker.FsmVector3::get_Value(this.strength);\n\tv196 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv265 = HutongGames.PlayMaker.FsmFloat::get_Value(this.randomness);\n\tv197 = DG.Tweening.ShortcutExtensions::DOShakeRotation(v195, v102, v103, v196, v265, 1);\n\tthis.tween = v197;\n\tv269 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv271 = v269 == 0;\n\tif (v271) goto L_0067;\n\tv276 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0067:\n\tv280 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v280);\n\tv105 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv286 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v105);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv289 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv292 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v289, this.loopType);\n\tv294 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv297 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v294);\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv302 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v299);\n\tv306 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv313 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v306);\n\tv315 = this.startEvent == 0;\n\tif (v315) goto L_00CC;\n\tv320 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v320, this, Il2CppMethodInfo);\n\tv326 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v320);\nL_00CC:\n\tv333 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv337 = v333 == 0;\n\tv338 = ~v337;\n\tif (v338) goto L_00EE;\n\tv344 = new DG.Tweening.TweenCallback();\n\tv353 = this.finishEvent == 0;\n\tif (v353) goto L_FFFFFFFF;\n\tgoto L_00E3;\nL_00E3:\n\tDG.Tweening.TweenCallback::.ctor(v344, this, *([v365 @ X8_v31 (Il2CppMethodInfo)]));\n\tv351 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v344);\nL_00EE:\n\tv358 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv364 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv370 = v364 == 0;\n\tif (v370) goto L_0101;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Camera Shake Rotation\");\nL_0101:\n\tv249 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv251 = v249 == 0;\n\tif (v251) goto L_0121;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0121:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 234 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Camera component = ownerDefaultTarget.GetComponent<Camera>();
			float value = duration.Value;
			Vector3 value2 = strength.Value;
			int value3 = vibrato.Value;
			float value4 = randomness.Value;
			Tweener tweener = component.DOShakeRotation(value, value2, value3, value4);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value5 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value5);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value6 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value6, loopType);
			bool value7 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value7);
			bool value8 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value8);
			bool value9 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value9);
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
				State.Debug("DOTween Camera Shake Rotation");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60003E0")]
		[Address(RVA = "0xAEF920", Offset = "0xAEF920", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE2548]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022429]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenCameraShakeRotation()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
