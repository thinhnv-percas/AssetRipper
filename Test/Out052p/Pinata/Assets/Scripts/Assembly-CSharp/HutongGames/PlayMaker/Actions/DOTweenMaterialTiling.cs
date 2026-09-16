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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F4B8", Offset = "0x74F4B8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F4B8", Offset = "0x74F4B8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F4B8", Offset = "0x74F4B8")]
	[Token(Token = "0x20000C2")]
	public class DOTweenMaterialTiling : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x77AEA4", Offset = "0x77AEA4")]
		[Token(Token = "0x40007AC")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AF18", Offset = "0x77AF18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AF18", Offset = "0x77AF18")]
		[Token(Token = "0x40007AD")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AF78", Offset = "0x77AF78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AF78", Offset = "0x77AF78")]
		[Token(Token = "0x40007AE")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AFC8", Offset = "0x77AFC8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AFC8", Offset = "0x77AFC8")]
		[Token(Token = "0x40007AF")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B028", Offset = "0x77B028")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B028", Offset = "0x77B028")]
		[Token(Token = "0x40007B0")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B078", Offset = "0x77B078")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B078", Offset = "0x77B078")]
		[Token(Token = "0x40007B1")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77B0C8", Offset = "0x77B0C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B0C8", Offset = "0x77B0C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B0C8", Offset = "0x77B0C8")]
		[Token(Token = "0x40007B2")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B13C", Offset = "0x77B13C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B13C", Offset = "0x77B13C")]
		[Token(Token = "0x40007B3")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77B18C", Offset = "0x77B18C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B18C", Offset = "0x77B18C")]
		[Token(Token = "0x40007B4")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B1DC", Offset = "0x77B1DC")]
		[Token(Token = "0x40007B5")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B1F0", Offset = "0x77B1F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B1F0", Offset = "0x77B1F0")]
		[Token(Token = "0x40007B6")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77B240", Offset = "0x77B240")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B240", Offset = "0x77B240")]
		[Token(Token = "0x40007B7")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B290", Offset = "0x77B290")]
		[Token(Token = "0x40007B8")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B2C8", Offset = "0x77B2C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B2C8", Offset = "0x77B2C8")]
		[Token(Token = "0x40007B9")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B318", Offset = "0x77B318")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B318", Offset = "0x77B318")]
		[Token(Token = "0x40007BA")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77B368", Offset = "0x77B368")]
		[Token(Token = "0x40007BB")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B3A0", Offset = "0x77B3A0")]
		[Token(Token = "0x40007BC")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x40007BD")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77B3D8", Offset = "0x77B3D8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B3D8", Offset = "0x77B3D8")]
		[Token(Token = "0x40007BE")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B428", Offset = "0x77B428")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B428", Offset = "0x77B428")]
		[Token(Token = "0x40007BF")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B478", Offset = "0x77B478")]
		[Token(Token = "0x40007C0")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77B4B0", Offset = "0x77B4B0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B4B0", Offset = "0x77B4B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B4B0", Offset = "0x77B4B0")]
		[Token(Token = "0x40007C1")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B524", Offset = "0x77B524")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B524", Offset = "0x77B524")]
		[Token(Token = "0x40007C2")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B574", Offset = "0x77B574")]
		[Token(Token = "0x40007C3")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B5AC", Offset = "0x77B5AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77B5AC", Offset = "0x77B5AC")]
		[Token(Token = "0x40007C4")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77B5FC", Offset = "0x77B5FC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77B5FC", Offset = "0x77B5FC")]
		[Token(Token = "0x40007C5")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x40007C6")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x600049C")]
		[Address(RVA = "0xAFD584", Offset = "0xAFD584", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EFFCC0]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202249E]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600049D")]
		[Address(RVA = "0xAFD820", Offset = "0xAFD820", Length = "0x3D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EC2F88]);\n\tv29 = *([v28 @ X8_v52]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202249F]) = v48;\nL_001D:\n\tv53 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv117 = UnityEngine.GameObject::GetComponent(v53);\n\tv188 = UnityEngine.Renderer::get_material(v117);\n\tv149 = this.to;\n\tv244 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 56 MakeStruct v78 @ AGGAFD8C8_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v149.value (UnityEngine.Vector2), v149.value.y (System.Single)\n\tv189 = DG.Tweening.ShortcutExtensions::DOTiling(v188, v78, v244);\n\tthis.tween = v189;\n\tv248 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv250 = v248 == 0;\n\tif (v250) goto L_004E;\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_004E:\n\tv258 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv261 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v258);\n\tv264 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v264);\n\tv85 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv270 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v85);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv273 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv276 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v273, this.loopType);\n\tv278 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv281 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v278);\n\tv283 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv286 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v283);\n\tv288 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v288);\n\tv292 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv294 = v292 == 0;\n\tif (v294) goto L_00BF;\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv300 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v309);\nL_00BF:\n\tv307 = this.startEvent == 0;\n\tif (v307) goto L_00D7;\n\tv314 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v314, this, Il2CppMethodInfo);\n\tv320 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v314);\nL_00D7:\n\tv329 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv333 = v329 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_00F9;\n\tv340 = new DG.Tweening.TweenCallback();\n\tv349 = this.finishEvent == 0;\n\tif (v349) goto L_FFFFFFFF;\n\tgoto L_00EE;\nL_00EE:\n\tDG.Tweening.TweenCallback::.ctor(v340, this, *([v361 @ X8_v33 (Il2CppMethodInfo)]));\n\tv347 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v340);\nL_00F9:\n\tv354 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv360 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv366 = v360 == 0;\n\tif (v366) goto L_010C;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Tiling\");\nL_010C:\n\tv230 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv232 = v230 == 0;\n\tif (v232) goto L_0128;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0128:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 234 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = material.DOTiling(endValue, value);
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
				State.Debug("DOTween Material Tiling");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600049E")]
		[Address(RVA = "0xAFDBF8", Offset = "0xAFDBF8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED4B90]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224A0]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialTiling()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
