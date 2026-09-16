using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750C70", Offset = "0x750C70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750C70", Offset = "0x750C70")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750C70", Offset = "0x750C70")]
	[Token(Token = "0x20000F0")]
	public class DOTweenTransformBlendableMoveBy : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x791DDC", Offset = "0x791DDC")]
		[Token(Token = "0x4000CB4")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x791E50", Offset = "0x791E50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x791E50", Offset = "0x791E50")]
		[Token(Token = "0x4000CB5")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 by;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x791EB0", Offset = "0x791EB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x791EB0", Offset = "0x791EB0")]
		[Token(Token = "0x4000CB6")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x791F00", Offset = "0x791F00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x791F00", Offset = "0x791F00")]
		[Token(Token = "0x4000CB7")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x791F50", Offset = "0x791F50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x791F50", Offset = "0x791F50")]
		[Token(Token = "0x4000CB8")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x791FB0", Offset = "0x791FB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x791FB0", Offset = "0x791FB0")]
		[Token(Token = "0x4000CB9")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792000", Offset = "0x792000")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792000", Offset = "0x792000")]
		[Token(Token = "0x4000CBA")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792050", Offset = "0x792050")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792050", Offset = "0x792050")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792050", Offset = "0x792050")]
		[Token(Token = "0x4000CBB")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7920C4", Offset = "0x7920C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7920C4", Offset = "0x7920C4")]
		[Token(Token = "0x4000CBC")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792114", Offset = "0x792114")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792114", Offset = "0x792114")]
		[Token(Token = "0x4000CBD")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792164", Offset = "0x792164")]
		[Token(Token = "0x4000CBE")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792178", Offset = "0x792178")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792178", Offset = "0x792178")]
		[Token(Token = "0x4000CBF")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7921C8", Offset = "0x7921C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7921C8", Offset = "0x7921C8")]
		[Token(Token = "0x4000CC0")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792218", Offset = "0x792218")]
		[Token(Token = "0x4000CC1")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792250", Offset = "0x792250")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792250", Offset = "0x792250")]
		[Token(Token = "0x4000CC2")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7922A0", Offset = "0x7922A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7922A0", Offset = "0x7922A0")]
		[Token(Token = "0x4000CC3")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7922F0", Offset = "0x7922F0")]
		[Token(Token = "0x4000CC4")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792328", Offset = "0x792328")]
		[Token(Token = "0x4000CC5")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x4000CC6")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792360", Offset = "0x792360")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792360", Offset = "0x792360")]
		[Token(Token = "0x4000CC7")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7923B0", Offset = "0x7923B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7923B0", Offset = "0x7923B0")]
		[Token(Token = "0x4000CC8")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792400", Offset = "0x792400")]
		[Token(Token = "0x4000CC9")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792438", Offset = "0x792438")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792438", Offset = "0x792438")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792438", Offset = "0x792438")]
		[Token(Token = "0x4000CCA")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7924AC", Offset = "0x7924AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7924AC", Offset = "0x7924AC")]
		[Token(Token = "0x4000CCB")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7924FC", Offset = "0x7924FC")]
		[Token(Token = "0x4000CCC")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792534", Offset = "0x792534")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792534", Offset = "0x792534")]
		[Token(Token = "0x4000CCD")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792584", Offset = "0x792584")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792584", Offset = "0x792584")]
		[Token(Token = "0x4000CCE")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000CCF")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x6000582")]
		[Address(RVA = "0xA76BF8", Offset = "0xA76BF8", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F0B228]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022137]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.by = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setSpeedBased = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.snapping = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0214: Expected I4, but got I8
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
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			snapping = fsmBool2;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			setRelative = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.useVariable = false;
			fsmBool4.value = false;
			playInReverse = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.useVariable = false;
			fsmBool5.value = false;
			startEvent = null;
			finishEvent = null;
			setReverseRelative = fsmBool5;
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.useVariable = false;
			fsmBool6.value = false;
			finishImmediately = fsmBool6;
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
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = true;
			autoKillOnCompletion = fsmBool7;
			FsmBool fsmBool8 = new FsmBool();
			fsmBool8.value = false;
			recyclable = fsmBool8;
			updateType = default(UpdateType);
			FsmBool fsmBool9 = new FsmBool();
			fsmBool9.value = false;
			isIndependentUpdate = fsmBool9;
			FsmBool fsmBool10 = new FsmBool();
			fsmBool10.value = false;
			debugThis = fsmBool10;
		}

		[Token(Token = "0x6000583")]
		[Address(RVA = "0xA76EB8", Offset = "0xA76EB8", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1ECF5B8]);\n\tv33 = *([v32 @ X8_v52]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022138]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv206 = UnityEngine.GameObject::GetComponent(v57);\n\tv100 = HutongGames.PlayMaker.FsmVector3::get_Value(this.by);\n\tv101 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv271 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tv207 = DG.Tweening.ShortcutExtensions::DOBlendableMoveBy(v206, v100, v101, v271);\n\tthis.tween = v207;\n\tv275 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv277 = v275 == 0;\n\tif (v277) goto L_005A;\n\tv282 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_005A:\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv288 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v285);\n\tv291 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v291);\n\tv103 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv297 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v103);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv300 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv303 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v300, this.loopType);\n\tv305 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv308 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v305);\n\tv310 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv313 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v310);\n\tv315 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv318 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v315);\n\tv319 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv321 = v319 == 0;\n\tif (v321) goto L_00CB;\n\tv336 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv327 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v336);\nL_00CB:\n\tv334 = this.startEvent == 0;\n\tif (v334) goto L_00E3;\n\tv341 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v341, this, Il2CppMethodInfo);\n\tv347 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v341);\nL_00E3:\n\tv356 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv360 = v356 == 0;\n\tv361 = ~v360;\n\tif (v361) goto L_0105;\n\tv367 = new DG.Tweening.TweenCallback();\n\tv376 = this.finishEvent == 0;\n\tif (v376) goto L_FFFFFFFF;\n\tgoto L_00FA;\nL_00FA:\n\tDG.Tweening.TweenCallback::.ctor(v367, this, *([v388 @ X8_v33 (Il2CppMethodInfo)]));\n\tv374 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v367);\nL_0105:\n\tv381 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv387 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv393 = v387 == 0;\n\tif (v393) goto L_0118;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Blendable Move By\");\nL_0118:\n\tv256 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv258 = v256 == 0;\n\tif (v258) goto L_0138;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0138:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 251 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			Vector3 value = by.Value;
			float value2 = duration.Value;
			bool value3 = snapping.Value;
			Tweener tweener = component.DOBlendableMoveBy(value, value2, value3);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			bool value4 = setRelative.Value;
			Tweener tweener3 = tween.SetRelative(value4);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value5 = startDelay.Value;
			Tweener tweener4 = tween.SetDelay(value5);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value6 = loops.Value;
			Tweener tweener5 = tween.SetLoops(value6, loopType);
			bool value7 = autoKillOnCompletion.Value;
			Tweener tweener6 = tween.SetAutoKill(value7);
			bool value8 = recyclable.Value;
			Tweener tweener7 = tween.SetRecyclable(value8);
			bool value9 = isIndependentUpdate.Value;
			Tweener tweener8 = tween.SetUpdate(updateType, value9);
			if (playInReverse.Value)
			{
				bool value10 = setReverseRelative.Value;
				Tweener tweener9 = tween.From(value10);
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
				State.Debug("DOTween Transform Blendable Move By");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000584")]
		[Address(RVA = "0xA772C0", Offset = "0xA772C0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EEEC38]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022139]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformBlendableMoveBy()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
