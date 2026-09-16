using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7509DC", Offset = "0x7509DC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7509DC", Offset = "0x7509DC")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7509DC", Offset = "0x7509DC")]
	[Token(Token = "0x20000EB")]
	public class DOTweenTextText : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x78F7FC", Offset = "0x78F7FC")]
		[Token(Token = "0x4000C2D")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78F870", Offset = "0x78F870")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78F870", Offset = "0x78F870")]
		[Token(Token = "0x4000C2E")]
		[FieldOffset(Offset = "0x58")]
		public FsmString to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78F8D0", Offset = "0x78F8D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78F8D0", Offset = "0x78F8D0")]
		[Token(Token = "0x4000C2F")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool richTextEnabled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78F920", Offset = "0x78F920")]
		[Token(Token = "0x4000C30")]
		[FieldOffset(Offset = "0x68")]
		public ScrambleMode scrambleMode;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78F958", Offset = "0x78F958")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78F958", Offset = "0x78F958")]
		[Token(Token = "0x4000C31")]
		[FieldOffset(Offset = "0x70")]
		public FsmString scrambleChars;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78F9A8", Offset = "0x78F9A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78F9A8", Offset = "0x78F9A8")]
		[Token(Token = "0x4000C32")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78F9F8", Offset = "0x78F9F8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78F9F8", Offset = "0x78F9F8")]
		[Token(Token = "0x4000C33")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FA58", Offset = "0x78FA58")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FA58", Offset = "0x78FA58")]
		[Token(Token = "0x4000C34")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FAA8", Offset = "0x78FAA8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FAA8", Offset = "0x78FAA8")]
		[Token(Token = "0x4000C35")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78FAF8", Offset = "0x78FAF8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FAF8", Offset = "0x78FAF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FAF8", Offset = "0x78FAF8")]
		[Token(Token = "0x4000C36")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FB6C", Offset = "0x78FB6C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FB6C", Offset = "0x78FB6C")]
		[Token(Token = "0x4000C37")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78FBBC", Offset = "0x78FBBC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FBBC", Offset = "0x78FBBC")]
		[Token(Token = "0x4000C38")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FC0C", Offset = "0x78FC0C")]
		[Token(Token = "0x4000C39")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FC20", Offset = "0x78FC20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FC20", Offset = "0x78FC20")]
		[Token(Token = "0x4000C3A")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78FC70", Offset = "0x78FC70")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FC70", Offset = "0x78FC70")]
		[Token(Token = "0x4000C3B")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FCC0", Offset = "0x78FCC0")]
		[Token(Token = "0x4000C3C")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FCF8", Offset = "0x78FCF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FCF8", Offset = "0x78FCF8")]
		[Token(Token = "0x4000C3D")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FD48", Offset = "0x78FD48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FD48", Offset = "0x78FD48")]
		[Token(Token = "0x4000C3E")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78FD98", Offset = "0x78FD98")]
		[Token(Token = "0x4000C3F")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FDD0", Offset = "0x78FDD0")]
		[Token(Token = "0x4000C40")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x4000C41")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78FE08", Offset = "0x78FE08")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FE08", Offset = "0x78FE08")]
		[Token(Token = "0x4000C42")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FE58", Offset = "0x78FE58")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FE58", Offset = "0x78FE58")]
		[Token(Token = "0x4000C43")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FEA8", Offset = "0x78FEA8")]
		[Token(Token = "0x4000C44")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78FEE0", Offset = "0x78FEE0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FEE0", Offset = "0x78FEE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FEE0", Offset = "0x78FEE0")]
		[Token(Token = "0x4000C45")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FF54", Offset = "0x78FF54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FF54", Offset = "0x78FF54")]
		[Token(Token = "0x4000C46")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FFA4", Offset = "0x78FFA4")]
		[Token(Token = "0x4000C47")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78FFDC", Offset = "0x78FFDC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78FFDC", Offset = "0x78FFDC")]
		[Token(Token = "0x4000C48")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79002C", Offset = "0x79002C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79002C", Offset = "0x79002C")]
		[Token(Token = "0x4000C49")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x4000C4A")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x6000569")]
		[Address(RVA = "0xA748DC", Offset = "0xA748DC", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EC5CD8]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022128]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 1;\n\tthis.richTextEnabled = v80;\n\tthis.scrambleMode = 0;\n\tv81 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.scrambleChars = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0259: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			to = fsmString;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = true;
			richTextEnabled = fsmBool2;
			scrambleMode = default(ScrambleMode);
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			fsmString2.Value = null;
			scrambleChars = fsmString2;
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
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = false;
			stringAsId = fsmString3;
			FsmString fsmString4 = new FsmString();
			fsmString4.useVariable = false;
			tagAsId = fsmString4;
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

		[Token(Token = "0x600056A")]
		[Address(RVA = "0xA74BC0", Offset = "0xA74BC0", Length = "0x414")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EBEF50]);\n\tv27 = *([v26 @ X8_v54]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022129]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv180 = UnityEngine.GameObject::GetComponent(v51);\n\tv181 = HutongGames.PlayMaker.FsmString::get_Value(this.to);\n\tv77 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv182 = HutongGames.PlayMaker.FsmBool::get_Value(this.richTextEnabled);\n\tv240 = HutongGames.PlayMaker.FsmString::get_Value(this.scrambleChars);\n\tv183 = DG.Tweening.DOTweenModuleUI::DOText(v180, v181, v77, v182, this.scrambleMode, v240);\n\tthis.tween = v183;\n\tv244 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv246 = v244 == 0;\n\tif (v246) goto L_005B;\n\tv251 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_005B:\n\tv254 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv257 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v254);\n\tv260 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v260);\n\tv79 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv266 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v79);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv269 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v269, this.loopType);\n\tv274 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv277 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v274);\n\tv279 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv282 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v279);\n\tv284 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv287 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v284);\n\tv288 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv290 = v288 == 0;\n\tif (v290) goto L_00CC;\n\tv305 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv296 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v305);\nL_00CC:\n\tv303 = this.startEvent == 0;\n\tif (v303) goto L_00E4;\n\tv310 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v310, this, Il2CppMethodInfo);\n\tv316 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v310);\nL_00E4:\n\tv325 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv329 = v325 == 0;\n\tv330 = ~v329;\n\tif (v330) goto L_0106;\n\tv336 = new DG.Tweening.TweenCallback();\n\tv345 = this.finishEvent == 0;\n\tif (v345) goto L_FFFFFFFF;\n\tgoto L_00FB;\nL_00FB:\n\tDG.Tweening.TweenCallback::.ctor(v336, this, *([v357 @ X8_v35 (Il2CppMethodInfo)]));\n\tv343 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v336);\nL_0106:\n\tv350 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv356 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv362 = v356 == 0;\n\tif (v362) goto L_0119;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Text Text\");\nL_0119:\n\tv223 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv225 = v223 == 0;\n\tif (v225) goto L_0133;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0133:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 245 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Text component = ownerDefaultTarget.GetComponent<Text>();
			string value = to.Value;
			float value2 = duration.Value;
			bool value3 = richTextEnabled.Value;
			string value4 = scrambleChars.Value;
			TweenerCore<string, string, StringOptions> tweenerCore = component.DOText(value, value2, value3, scrambleMode, value4);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value5 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value5);
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
			if (playInReverse.Value)
			{
				bool value11 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value11);
			}
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener9 = tween.OnStart(action);
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
				Tweener tweener10 = tween.OnComplete(action2);
			}
			Tweener tweener11 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Text Text");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600056B")]
		[Address(RVA = "0xA74FD4", Offset = "0xA74FD4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED6020]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202212A]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTextText()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
