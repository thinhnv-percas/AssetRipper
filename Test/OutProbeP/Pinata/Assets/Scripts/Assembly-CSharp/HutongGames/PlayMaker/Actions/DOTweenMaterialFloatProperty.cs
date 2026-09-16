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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F32C", Offset = "0x74F32C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F32C", Offset = "0x74F32C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F32C", Offset = "0x74F32C")]
	[Token(Token = "0x20000BF")]
	public class DOTweenMaterialFloatProperty : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7796EC", Offset = "0x7796EC")]
		[Token(Token = "0x4000759")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779760", Offset = "0x779760")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779760", Offset = "0x779760")]
		[Token(Token = "0x400075A")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7797C0", Offset = "0x7797C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7797C0", Offset = "0x7797C0")]
		[Token(Token = "0x400075B")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779810", Offset = "0x779810")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779810", Offset = "0x779810")]
		[Token(Token = "0x400075C")]
		[FieldOffset(Offset = "0x68")]
		public FsmString property;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779870", Offset = "0x779870")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779870", Offset = "0x779870")]
		[Token(Token = "0x400075D")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7798D0", Offset = "0x7798D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7798D0", Offset = "0x7798D0")]
		[Token(Token = "0x400075E")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779920", Offset = "0x779920")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779920", Offset = "0x779920")]
		[Token(Token = "0x400075F")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x779970", Offset = "0x779970")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779970", Offset = "0x779970")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779970", Offset = "0x779970")]
		[Token(Token = "0x4000760")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7799E4", Offset = "0x7799E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7799E4", Offset = "0x7799E4")]
		[Token(Token = "0x4000761")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x779A34", Offset = "0x779A34")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779A34", Offset = "0x779A34")]
		[Token(Token = "0x4000762")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779A84", Offset = "0x779A84")]
		[Token(Token = "0x4000763")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779A98", Offset = "0x779A98")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779A98", Offset = "0x779A98")]
		[Token(Token = "0x4000764")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x779AE8", Offset = "0x779AE8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779AE8", Offset = "0x779AE8")]
		[Token(Token = "0x4000765")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779B38", Offset = "0x779B38")]
		[Token(Token = "0x4000766")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779B70", Offset = "0x779B70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779B70", Offset = "0x779B70")]
		[Token(Token = "0x4000767")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779BC0", Offset = "0x779BC0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779BC0", Offset = "0x779BC0")]
		[Token(Token = "0x4000768")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x779C10", Offset = "0x779C10")]
		[Token(Token = "0x4000769")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779C48", Offset = "0x779C48")]
		[Token(Token = "0x400076A")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x400076B")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x779C80", Offset = "0x779C80")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779C80", Offset = "0x779C80")]
		[Token(Token = "0x400076C")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779CD0", Offset = "0x779CD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779CD0", Offset = "0x779CD0")]
		[Token(Token = "0x400076D")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779D20", Offset = "0x779D20")]
		[Token(Token = "0x400076E")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x779D58", Offset = "0x779D58")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779D58", Offset = "0x779D58")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779D58", Offset = "0x779D58")]
		[Token(Token = "0x400076F")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779DCC", Offset = "0x779DCC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779DCC", Offset = "0x779DCC")]
		[Token(Token = "0x4000770")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779E1C", Offset = "0x779E1C")]
		[Token(Token = "0x4000771")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779E54", Offset = "0x779E54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779E54", Offset = "0x779E54")]
		[Token(Token = "0x4000772")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x779EA4", Offset = "0x779EA4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779EA4", Offset = "0x779EA4")]
		[Token(Token = "0x4000773")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000774")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x600048D")]
		[Address(RVA = "0xAFBFA0", Offset = "0xAFBFA0", Length = "0x2B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EBC0B0]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022495]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.property = v57;\n\tv78 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v78);\n\tv78.useVariable = 0;\n\tthis.duration = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			property = fsmString;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
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
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			stringAsId = fsmString2;
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = false;
			tagAsId = fsmString3;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
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

		[Token(Token = "0x600048E")]
		[Address(RVA = "0xAFC254", Offset = "0xAFC254", Length = "0x3FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EF3FF0]);\n\tv27 = *([v26 @ X8_v53]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022496]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv111 = UnityEngine.GameObject::GetComponent(v51);\n\tv181 = UnityEngine.Renderer::get_material(v111);\n\tv80 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv182 = HutongGames.PlayMaker.FsmString::get_Value(this.property);\n\tv237 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv183 = DG.Tweening.ShortcutExtensions::DOFloat(v181, v80, v182, v237);\n\tthis.tween = v183;\n\tv241 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv243 = v241 == 0;\n\tif (v243) goto L_0055;\n\tv248 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0055:\n\tv251 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv254 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v251);\n\tv257 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v257);\n\tv82 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv263 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v82);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv266 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv269 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v266, this.loopType);\n\tv271 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv274 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v271);\n\tv276 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv279 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v276);\n\tv281 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv284 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v281);\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv287 = v285 == 0;\n\tif (v287) goto L_00C6;\n\tv302 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv293 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v302);\nL_00C6:\n\tv300 = this.startEvent == 0;\n\tif (v300) goto L_00DE;\n\tv307 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v307, this, Il2CppMethodInfo);\n\tv313 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v307);\nL_00DE:\n\tv322 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv326 = v322 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_0100;\n\tv333 = new DG.Tweening.TweenCallback();\n\tv342 = this.finishEvent == 0;\n\tif (v342) goto L_FFFFFFFF;\n\tgoto L_00F5;\nL_00F5:\n\tDG.Tweening.TweenCallback::.ctor(v333, this, *([v354 @ X8_v34 (Il2CppMethodInfo)]));\n\tv340 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v333);\nL_0100:\n\tv347 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv353 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv359 = v353 == 0;\n\tif (v359) goto L_0113;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Float Property\");\nL_0113:\n\tv221 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv223 = v221 == 0;\n\tif (v223) goto L_012D;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 239 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Renderer component = ownerDefaultTarget.GetComponent<Renderer>();
			Material material = component.material;
			float value = to.Value;
			string value2 = property.Value;
			float value3 = duration.Value;
			TweenerCore<float, float, FloatOptions> tweenerCore = material.DOFloat(value, value2, value3);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value4 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value4);
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
			if (playInReverse.Value)
			{
				bool value10 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value10);
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
				State.Debug("DOTween Material Float Property");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600048F")]
		[Address(RVA = "0xAFC650", Offset = "0xAFC650", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF2D78]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022497]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialFloatProperty()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
