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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F224", Offset = "0x74F224")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F224", Offset = "0x74F224")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F224", Offset = "0x74F224")]
	[Token(Token = "0x20000BD")]
	public class DOTweenMaterialFade : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x77873C", Offset = "0x77873C")]
		[Token(Token = "0x4000722")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7787B0", Offset = "0x7787B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7787B0", Offset = "0x7787B0")]
		[Token(Token = "0x4000723")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778810", Offset = "0x778810")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778810", Offset = "0x778810")]
		[Token(Token = "0x4000724")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778860", Offset = "0x778860")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778860", Offset = "0x778860")]
		[Token(Token = "0x4000725")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7788C0", Offset = "0x7788C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7788C0", Offset = "0x7788C0")]
		[Token(Token = "0x4000726")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778910", Offset = "0x778910")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778910", Offset = "0x778910")]
		[Token(Token = "0x4000727")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778960", Offset = "0x778960")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778960", Offset = "0x778960")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778960", Offset = "0x778960")]
		[Token(Token = "0x4000728")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7789D4", Offset = "0x7789D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7789D4", Offset = "0x7789D4")]
		[Token(Token = "0x4000729")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778A24", Offset = "0x778A24")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778A24", Offset = "0x778A24")]
		[Token(Token = "0x400072A")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778A74", Offset = "0x778A74")]
		[Token(Token = "0x400072B")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778A88", Offset = "0x778A88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778A88", Offset = "0x778A88")]
		[Token(Token = "0x400072C")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778AD8", Offset = "0x778AD8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778AD8", Offset = "0x778AD8")]
		[Token(Token = "0x400072D")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778B28", Offset = "0x778B28")]
		[Token(Token = "0x400072E")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778B60", Offset = "0x778B60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778B60", Offset = "0x778B60")]
		[Token(Token = "0x400072F")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778BB0", Offset = "0x778BB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778BB0", Offset = "0x778BB0")]
		[Token(Token = "0x4000730")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778C00", Offset = "0x778C00")]
		[Token(Token = "0x4000731")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778C38", Offset = "0x778C38")]
		[Token(Token = "0x4000732")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000733")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778C70", Offset = "0x778C70")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778C70", Offset = "0x778C70")]
		[Token(Token = "0x4000734")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778CC0", Offset = "0x778CC0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778CC0", Offset = "0x778CC0")]
		[Token(Token = "0x4000735")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778D10", Offset = "0x778D10")]
		[Token(Token = "0x4000736")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778D48", Offset = "0x778D48")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778D48", Offset = "0x778D48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778D48", Offset = "0x778D48")]
		[Token(Token = "0x4000737")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778DBC", Offset = "0x778DBC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778DBC", Offset = "0x778DBC")]
		[Token(Token = "0x4000738")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778E0C", Offset = "0x778E0C")]
		[Token(Token = "0x4000739")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778E44", Offset = "0x778E44")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778E44", Offset = "0x778E44")]
		[Token(Token = "0x400073A")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778E94", Offset = "0x778E94")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778E94", Offset = "0x778E94")]
		[Token(Token = "0x400073B")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x400073C")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x6000483")]
		[Address(RVA = "0xAFB11C", Offset = "0xAFB11C", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF4670]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202248F]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.duration = v55;\n\tv76 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v76);\n\tv76.useVariable = 0;\n\tv76.value = 0;\n\tthis.setSpeedBased = v76;\n\tv77 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v77);\n\tv77.useVariable = 0;\n\tv77.value = 0;\n\tthis.setRelative = v77;\n\tv78 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v78);\n\tv78.useVariable = 0;\n\tv78.value = 0;\n\tthis.playInReverse = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.finishImmediately = v80;\n\tv81 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.stringAsId = v81;\n\tv82 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.tagAsId = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.value = 0f;\n\tthis.startDelay = v83;\n\tthis.selectedEase = 0x100000000;\n\tv84 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v84);\n\tv84.value = 0;\n\tthis.loops = v84;\n\tthis.loopType = 0;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.value = 1;\n\tthis.autoKillOnCompletion = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.value = 0;\n\tthis.recyclable = v86;\n\tthis.updateType = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.value = 0;\n\tthis.isIndependentUpdate = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 0;\n\tthis.debugThis = v88;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
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

		[Token(Token = "0x6000484")]
		[Address(RVA = "0xAFB3B0", Offset = "0xAFB3B0", Length = "0x3E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ED5480]);\n\tv27 = *([v26 @ X8_v52]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022490]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv109 = UnityEngine.GameObject::GetComponent(v51);\n\tv178 = UnityEngine.Renderer::get_material(v109);\n\tv79 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv230 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv179 = DG.Tweening.ShortcutExtensions::DOFade(v178, v79, v230);\n\tthis.tween = v179;\n\tv234 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv236 = v234 == 0;\n\tif (v236) goto L_004D;\n\tv241 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_004D:\n\tv244 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv247 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v244);\n\tv250 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v250);\n\tv81 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv256 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v81);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv259 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv262 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v259, this.loopType);\n\tv264 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv267 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v264);\n\tv269 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v269);\n\tv274 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv277 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v274);\n\tv278 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv280 = v278 == 0;\n\tif (v280) goto L_00BE;\n\tv295 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv286 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v295);\nL_00BE:\n\tv293 = this.startEvent == 0;\n\tif (v293) goto L_00D6;\n\tv300 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v300, this, Il2CppMethodInfo);\n\tv306 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v300);\nL_00D6:\n\tv315 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv319 = v315 == 0;\n\tv320 = ~v319;\n\tif (v320) goto L_00F8;\n\tv326 = new DG.Tweening.TweenCallback();\n\tv335 = this.finishEvent == 0;\n\tif (v335) goto L_FFFFFFFF;\n\tgoto L_00ED;\nL_00ED:\n\tDG.Tweening.TweenCallback::.ctor(v326, this, *([v347 @ X8_v33 (Il2CppMethodInfo)]));\n\tv333 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v326);\nL_00F8:\n\tv340 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv346 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv352 = v346 == 0;\n\tif (v352) goto L_010B;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Fade\");\nL_010B:\n\tv215 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv217 = v215 == 0;\n\tif (v217) goto L_0125;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0125:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 232 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Renderer component = ownerDefaultTarget.GetComponent<Renderer>();
			Material material = component.material;
			float value = to.Value;
			float value2 = duration.Value;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = material.DOFade(value, value2);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value3 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value3);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
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
				State.Debug("DOTween Material Fade");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000485")]
		[Address(RVA = "0xAFB790", Offset = "0xAFB790", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECFC90]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022491]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialFade()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
