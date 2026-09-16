using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751A5C", Offset = "0x751A5C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751A5C", Offset = "0x751A5C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x751A5C", Offset = "0x751A5C")]
	[Token(Token = "0x200010B")]
	public class DOTweenTransformShakeRotation : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A0360", Offset = "0x7A0360")]
		[Token(Token = "0x4000FD2")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A03D4", Offset = "0x7A03D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A03D4", Offset = "0x7A03D4")]
		[Token(Token = "0x4000FD3")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 strength;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0424", Offset = "0x7A0424")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0424", Offset = "0x7A0424")]
		[Token(Token = "0x4000FD4")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0474", Offset = "0x7A0474")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0474", Offset = "0x7A0474")]
		[Token(Token = "0x4000FD5")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat randomness;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A04C4", Offset = "0x7A04C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A04C4", Offset = "0x7A04C4")]
		[Token(Token = "0x4000FD6")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0524", Offset = "0x7A0524")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0524", Offset = "0x7A0524")]
		[Token(Token = "0x4000FD7")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0574", Offset = "0x7A0574")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0574", Offset = "0x7A0574")]
		[Token(Token = "0x4000FD8")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A05C4", Offset = "0x7A05C4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A05C4", Offset = "0x7A05C4")]
		[Token(Token = "0x4000FD9")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0614", Offset = "0x7A0614")]
		[Token(Token = "0x4000FDA")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0628", Offset = "0x7A0628")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0628", Offset = "0x7A0628")]
		[Token(Token = "0x4000FDB")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A0678", Offset = "0x7A0678")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0678", Offset = "0x7A0678")]
		[Token(Token = "0x4000FDC")]
		[FieldOffset(Offset = "0xA0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A06C8", Offset = "0x7A06C8")]
		[Token(Token = "0x4000FDD")]
		[FieldOffset(Offset = "0xA8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0700", Offset = "0x7A0700")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0700", Offset = "0x7A0700")]
		[Token(Token = "0x4000FDE")]
		[FieldOffset(Offset = "0xB0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0750", Offset = "0x7A0750")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0750", Offset = "0x7A0750")]
		[Token(Token = "0x4000FDF")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A07A0", Offset = "0x7A07A0")]
		[Token(Token = "0x4000FE0")]
		[FieldOffset(Offset = "0xC0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A07D8", Offset = "0x7A07D8")]
		[Token(Token = "0x4000FE1")]
		[FieldOffset(Offset = "0xC4")]
		public Ease easeType;

		[Token(Token = "0x4000FE2")]
		[FieldOffset(Offset = "0xC8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A0810", Offset = "0x7A0810")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0810", Offset = "0x7A0810")]
		[Token(Token = "0x4000FE3")]
		[FieldOffset(Offset = "0xD0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0860", Offset = "0x7A0860")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A0860", Offset = "0x7A0860")]
		[Token(Token = "0x4000FE4")]
		[FieldOffset(Offset = "0xD8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A08B0", Offset = "0x7A08B0")]
		[Token(Token = "0x4000FE5")]
		[FieldOffset(Offset = "0xE0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A08E8", Offset = "0x7A08E8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A08E8", Offset = "0x7A08E8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A08E8", Offset = "0x7A08E8")]
		[Token(Token = "0x4000FE6")]
		[FieldOffset(Offset = "0xE8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A095C", Offset = "0x7A095C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A095C", Offset = "0x7A095C")]
		[Token(Token = "0x4000FE7")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A09AC", Offset = "0x7A09AC")]
		[Token(Token = "0x4000FE8")]
		[FieldOffset(Offset = "0xF8")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A09E4", Offset = "0x7A09E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A09E4", Offset = "0x7A09E4")]
		[Token(Token = "0x4000FE9")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A0A34", Offset = "0x7A0A34")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A0A34", Offset = "0x7A0A34")]
		[Token(Token = "0x4000FEA")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool debugThis;

		[Token(Token = "0x4000FEB")]
		[FieldOffset(Offset = "0x110")]
		private Tweener tween;

		[Token(Token = "0x600060A")]
		[Address(RVA = "0xA847D4", Offset = "0xA847D4", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ECD7B8]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022188]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tv57 = 0;\n\tv62 = 0x1586898(&v57 @ stack_-50_v2 (UnityEngine.Vector3), 0, v28, v29, v30, v31, v32, v33, 90f, 90f, 90f, v37, v38, v39, v40, v41);\n\tv50.value = 0;\n\tv50.value.y = v147;\n\tv50.value.z = 0f;\n\tthis.strength = v50;\n\tv98 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v98);\n\tv98.useVariable = 0;\n\tv98.value = 0xA;\n\tthis.vibrato = v98;\n\tv99 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v99);\n\tv99.useVariable = 0;\n\tv99.value = 90f;\n\tthis.randomness = v99;\n\tv100 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v100);\n\tv100.useVariable = 0;\n\tthis.duration = v100;\n\tv101 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v101);\n\tv101.useVariable = 0;\n\tv101.value = 0;\n\tthis.setSpeedBased = v101;\n\tv102 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v102);\n\tv102.value = 0f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.startDelay = v102;\n\tv103 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v103);\n\tv103.useVariable = 0;\n\tv103.value = 0;\n\tthis.finishImmediately = v103;\n\tv104 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v104);\n\tv104.useVariable = 0;\n\tthis.stringAsId = v104;\n\tv105 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v105);\n\tv105.useVariable = 0;\n\tthis.tagAsId = v105;\n\tthis.selectedEase = 0x100000000;\n\tv106 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v106);\n\tv106.value = 0;\n\tthis.loops = v106;\n\tthis.loopType = 0;\n\tv107 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v107);\n\tv107.value = 1;\n\tthis.autoKillOnCompletion = v107;\n\tv108 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v108);\n\tv108.value = 0;\n\tthis.recyclable = v108;\n\tthis.updateType = 0;\n\tv109 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v109);\n\tv109.value = 0;\n\tthis.isIndependentUpdate = v109;\n\tv110 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v110);\n\tv110.value = 0;\n\tthis.debugThis = v110;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01ff: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			Vector3 vector = default(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			fsmVector.value = default(Vector3);
			float y = default(float);
			fsmVector.value.y = y;
			fsmVector.value.z = 0f;
			strength = fsmVector;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 10;
			vibrato = fsmInt;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			fsmFloat.Value = 90f;
			randomness = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startEvent = null;
			finishEvent = null;
			startDelay = fsmFloat3;
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

		[Token(Token = "0x600060B")]
		[Address(RVA = "0xA84A8C", Offset = "0xA84A8C", Length = "0x3BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1F02230]);\n\tv33 = *([v32 @ X8_v48]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022189]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv195 = UnityEngine.GameObject::GetComponent(v57);\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv103 = HutongGames.PlayMaker.FsmVector3::get_Value(this.strength);\n\tv196 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv265 = HutongGames.PlayMaker.FsmFloat::get_Value(this.randomness);\n\tv197 = DG.Tweening.ShortcutExtensions::DOShakeRotation(v195, v102, v103, v196, v265, 1);\n\tthis.tween = v197;\n\tv269 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv271 = v269 == 0;\n\tif (v271) goto L_0067;\n\tv276 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0067:\n\tv280 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v280);\n\tv105 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv286 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v105);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv289 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv292 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v289, this.loopType);\n\tv294 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv297 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v294);\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv302 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v299);\n\tv306 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv313 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v306);\n\tv315 = this.startEvent == 0;\n\tif (v315) goto L_00CC;\n\tv320 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v320, this, Il2CppMethodInfo);\n\tv326 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v320);\nL_00CC:\n\tv333 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv337 = v333 == 0;\n\tv338 = ~v337;\n\tif (v338) goto L_00EE;\n\tv344 = new DG.Tweening.TweenCallback();\n\tv353 = this.finishEvent == 0;\n\tif (v353) goto L_FFFFFFFF;\n\tgoto L_00E3;\nL_00E3:\n\tDG.Tweening.TweenCallback::.ctor(v344, this, *([v365 @ X8_v31 (Il2CppMethodInfo)]));\n\tv351 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v344);\nL_00EE:\n\tv358 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv364 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv370 = v364 == 0;\n\tif (v370) goto L_0101;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Shake Rotation\");\nL_0101:\n\tv249 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv251 = v249 == 0;\n\tif (v251) goto L_0121;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0121:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 234 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
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
				State.Debug("DOTween Transform Shake Rotation");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600060C")]
		[Address(RVA = "0xA84E48", Offset = "0xA84E48", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F092D0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202218A]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformShakeRotation()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
