using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D2B0", Offset = "0x74D2B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74D2B0", Offset = "0x74D2B0")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D2B0", Offset = "0x74D2B0")]
	[Token(Token = "0x2000080")]
	public class DOTweenAnimateFloat : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40002EC")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765624", Offset = "0x765624")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765624", Offset = "0x765624")]
		[Token(Token = "0x40002ED")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat variable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765684", Offset = "0x765684")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765684", Offset = "0x765684")]
		[Token(Token = "0x40002EE")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7656E4", Offset = "0x7656E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7656E4", Offset = "0x7656E4")]
		[Token(Token = "0x40002EF")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765734", Offset = "0x765734")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765734", Offset = "0x765734")]
		[Token(Token = "0x40002F0")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765794", Offset = "0x765794")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765794", Offset = "0x765794")]
		[Token(Token = "0x40002F1")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7657E4", Offset = "0x7657E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7657E4", Offset = "0x7657E4")]
		[Token(Token = "0x40002F2")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765834", Offset = "0x765834")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765834", Offset = "0x765834")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765834", Offset = "0x765834")]
		[Token(Token = "0x40002F3")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7658A8", Offset = "0x7658A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7658A8", Offset = "0x7658A8")]
		[Token(Token = "0x40002F4")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7658F8", Offset = "0x7658F8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7658F8", Offset = "0x7658F8")]
		[Token(Token = "0x40002F5")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765948", Offset = "0x765948")]
		[Token(Token = "0x40002F6")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76595C", Offset = "0x76595C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76595C", Offset = "0x76595C")]
		[Token(Token = "0x40002F7")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7659AC", Offset = "0x7659AC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7659AC", Offset = "0x7659AC")]
		[Token(Token = "0x40002F8")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7659FC", Offset = "0x7659FC")]
		[Token(Token = "0x40002F9")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765A34", Offset = "0x765A34")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765A34", Offset = "0x765A34")]
		[Token(Token = "0x40002FA")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765A84", Offset = "0x765A84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765A84", Offset = "0x765A84")]
		[Token(Token = "0x40002FB")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765AD4", Offset = "0x765AD4")]
		[Token(Token = "0x40002FC")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765B0C", Offset = "0x765B0C")]
		[Token(Token = "0x40002FD")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x40002FE")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765B44", Offset = "0x765B44")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765B44", Offset = "0x765B44")]
		[Token(Token = "0x40002FF")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765B94", Offset = "0x765B94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765B94", Offset = "0x765B94")]
		[Token(Token = "0x4000300")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765BE4", Offset = "0x765BE4")]
		[Token(Token = "0x4000301")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765C1C", Offset = "0x765C1C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765C1C", Offset = "0x765C1C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765C1C", Offset = "0x765C1C")]
		[Token(Token = "0x4000302")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765C90", Offset = "0x765C90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765C90", Offset = "0x765C90")]
		[Token(Token = "0x4000303")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765CE0", Offset = "0x765CE0")]
		[Token(Token = "0x4000304")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765D18", Offset = "0x765D18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765D18", Offset = "0x765D18")]
		[Token(Token = "0x4000305")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765D68", Offset = "0x765D68")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765D68", Offset = "0x765D68")]
		[Token(Token = "0x4000306")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000307")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x6000378")]
		[Address(RVA = "0xA974E0", Offset = "0xA974E0", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EC2D08]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202221E]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 1;\n\tthis.variable = v50;\n\tv56 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v56);\n\tv56.useVariable = 0;\n\tthis.to = v56;\n\tv78 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v78);\n\tv78.useVariable = 0;\n\tthis.duration = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			variable = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			to = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = false;
			duration = fsmFloat3;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
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
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.Value = 0f;
			startDelay = fsmFloat4;
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

		[Token(Token = "0x6000379")]
		[Address(RVA = "0xA97798", Offset = "0xA97798", Length = "0x434")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EBB810]);\n\tv29 = *([v28 @ X8_v62]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202221F]) = v48;\nL_001B:\n\tv52 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v52, this, Il2CppMethodInfo);\n\tv64 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v64, this, Il2CppMethodInfo);\n\tv76 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv206 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tgoto L_004F;\n\tv255 = *([v209 @ X0_v13+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_004F;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v209, v205, v71, v72, v34, v35, v36, v37, v206, v39, v40, v41, v42, v43, v44, v45);\nL_004F:\n\tv197 = DG.Tweening.DOTween::To(v52, v64, v76, v206);\n\tthis.tween = v197;\n\tv265 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv267 = v265 == 0;\n\tif (v267) goto L_0064;\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0064:\n\tv275 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv278 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v275);\n\tv281 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v281);\n\tv95 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv287 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v95);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv290 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv293 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v290, this.loopType);\n\tv295 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv298 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v295);\n\tv300 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv303 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v300);\n\tv305 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv308 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v305);\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv311 = v309 == 0;\n\tif (v311) goto L_00D5;\n\tv326 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv317 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v326);\nL_00D5:\n\tv324 = this.startEvent == 0;\n\tif (v324) goto L_00ED;\n\tv331 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v331, this, Il2CppMethodInfo);\n\tv337 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v331);\nL_00ED:\n\tv346 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv350 = v346 == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_010F;\n\tv357 = new DG.Tweening.TweenCallback();\n\tv366 = this.finishEvent == 0;\n\tif (v366) goto L_FFFFFFFF;\n\tgoto L_0104;\nL_0104:\n\tDG.Tweening.TweenCallback::.ctor(v357, this, *([v378 @ X8_v42 (Il2CppMethodInfo)]));\n\tv364 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v357);\nL_010F:\n\tv371 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv377 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv383 = v377 == 0;\n\tif (v383) goto L_0122;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Animate Float\");\nL_0122:\n\tv242 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv244 = v242 == 0;\n\tif (v244) goto L_013E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_013E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 250 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DOGetter<float> getter = () => variable.Value;
			DOSetter<float> setter = delegate(float x)
			{
				FsmFloat fsmFloat = variable;
				fsmFloat.Value = x;
			};
			float value = to.Value;
			float value2 = duration.Value;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, value, value2);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value3 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value3);
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget);
			float value4 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value4);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value5 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value5, loopType);
			bool value6 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value6);
			bool value7 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value7);
			bool value8 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value8);
			if (playInReverse.Value)
			{
				bool value9 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value9);
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
				State.Debug("DOTween Animate Float");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600037A")]
		[Address(RVA = "0xA97BCC", Offset = "0xA97BCC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC1BD8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022220]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAnimateFloat()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
