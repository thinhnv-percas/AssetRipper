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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F3B0", Offset = "0x74F3B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F3B0", Offset = "0x74F3B0")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F3B0", Offset = "0x74F3B0")]
	[Token(Token = "0x20000C0")]
	public class DOTweenMaterialOffset : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x779EF4", Offset = "0x779EF4")]
		[Token(Token = "0x4000775")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779F68", Offset = "0x779F68")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779F68", Offset = "0x779F68")]
		[Token(Token = "0x4000776")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x779FC8", Offset = "0x779FC8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x779FC8", Offset = "0x779FC8")]
		[Token(Token = "0x4000777")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A018", Offset = "0x77A018")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A018", Offset = "0x77A018")]
		[Token(Token = "0x4000778")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A078", Offset = "0x77A078")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A078", Offset = "0x77A078")]
		[Token(Token = "0x4000779")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A0C8", Offset = "0x77A0C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A0C8", Offset = "0x77A0C8")]
		[Token(Token = "0x400077A")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A118", Offset = "0x77A118")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A118", Offset = "0x77A118")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A118", Offset = "0x77A118")]
		[Token(Token = "0x400077B")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A18C", Offset = "0x77A18C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A18C", Offset = "0x77A18C")]
		[Token(Token = "0x400077C")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A1DC", Offset = "0x77A1DC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A1DC", Offset = "0x77A1DC")]
		[Token(Token = "0x400077D")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A22C", Offset = "0x77A22C")]
		[Token(Token = "0x400077E")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A240", Offset = "0x77A240")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A240", Offset = "0x77A240")]
		[Token(Token = "0x400077F")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A290", Offset = "0x77A290")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A290", Offset = "0x77A290")]
		[Token(Token = "0x4000780")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A2E0", Offset = "0x77A2E0")]
		[Token(Token = "0x4000781")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A318", Offset = "0x77A318")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A318", Offset = "0x77A318")]
		[Token(Token = "0x4000782")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A368", Offset = "0x77A368")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A368", Offset = "0x77A368")]
		[Token(Token = "0x4000783")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A3B8", Offset = "0x77A3B8")]
		[Token(Token = "0x4000784")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A3F0", Offset = "0x77A3F0")]
		[Token(Token = "0x4000785")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000786")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A428", Offset = "0x77A428")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A428", Offset = "0x77A428")]
		[Token(Token = "0x4000787")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A478", Offset = "0x77A478")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A478", Offset = "0x77A478")]
		[Token(Token = "0x4000788")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A4C8", Offset = "0x77A4C8")]
		[Token(Token = "0x4000789")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A500", Offset = "0x77A500")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A500", Offset = "0x77A500")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A500", Offset = "0x77A500")]
		[Token(Token = "0x400078A")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A574", Offset = "0x77A574")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A574", Offset = "0x77A574")]
		[Token(Token = "0x400078B")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A5C4", Offset = "0x77A5C4")]
		[Token(Token = "0x400078C")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A5FC", Offset = "0x77A5FC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A5FC", Offset = "0x77A5FC")]
		[Token(Token = "0x400078D")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A64C", Offset = "0x77A64C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A64C", Offset = "0x77A64C")]
		[Token(Token = "0x400078E")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x400078F")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x6000492")]
		[Address(RVA = "0xAFC700", Offset = "0xAFC700", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF35B0]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022498]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = false;
			to = fsmVector;
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

		[Token(Token = "0x6000493")]
		[Address(RVA = "0xAFC99C", Offset = "0xAFC99C", Length = "0x3D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EF7F48]);\n\tv29 = *([v28 @ X8_v52]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022499]) = v48;\nL_001D:\n\tv53 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv117 = UnityEngine.GameObject::GetComponent(v53);\n\tv188 = UnityEngine.Renderer::get_material(v117);\n\tv149 = this.to;\n\tv244 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 56 MakeStruct v78 @ AGGAFCA44_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v149.value (UnityEngine.Vector2), v149.value.y (System.Single)\n\tv189 = DG.Tweening.ShortcutExtensions::DOOffset(v188, v78, v244);\n\tthis.tween = v189;\n\tv248 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv250 = v248 == 0;\n\tif (v250) goto L_004E;\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_004E:\n\tv258 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv261 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v258);\n\tv264 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v264);\n\tv85 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv270 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v85);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv273 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv276 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v273, this.loopType);\n\tv278 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv281 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v278);\n\tv283 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv286 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v283);\n\tv288 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v288);\n\tv292 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv294 = v292 == 0;\n\tif (v294) goto L_00BF;\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv300 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v309);\nL_00BF:\n\tv307 = this.startEvent == 0;\n\tif (v307) goto L_00D7;\n\tv314 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v314, this, Il2CppMethodInfo);\n\tv320 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v314);\nL_00D7:\n\tv329 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv333 = v329 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_00F9;\n\tv340 = new DG.Tweening.TweenCallback();\n\tv349 = this.finishEvent == 0;\n\tif (v349) goto L_FFFFFFFF;\n\tgoto L_00EE;\nL_00EE:\n\tDG.Tweening.TweenCallback::.ctor(v340, this, *([v361 @ X8_v33 (Il2CppMethodInfo)]));\n\tv347 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v340);\nL_00F9:\n\tv354 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv360 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv366 = v360 == 0;\n\tif (v366) goto L_010C;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Offset\");\nL_010C:\n\tv230 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv232 = v230 == 0;\n\tif (v232) goto L_0128;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0128:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 234 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Renderer component = ownerDefaultTarget.GetComponent<Renderer>();
			Material material = component.material;
			FsmVector2 fsmVector = to;
			float value = duration.Value;
			Vector2 endValue = default(Vector2);
			endValue.x = fsmVector.value.x;
			endValue.y = fsmVector.value.y;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = material.DOOffset(endValue, value);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value2 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value2);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value3 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value3);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value4 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value4, loopType);
			bool value5 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value5);
			bool value6 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value6);
			bool value7 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value7);
			if (playInReverse.Value)
			{
				bool value8 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value8);
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
				State.Debug("DOTween Material Offset");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000494")]
		[Address(RVA = "0xAFCD74", Offset = "0xAFCD74", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF5620]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202249A]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialOffset()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
