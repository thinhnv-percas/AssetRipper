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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FAE8", Offset = "0x74FAE8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FAE8", Offset = "0x74FAE8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FAE8", Offset = "0x74FAE8")]
	[Token(Token = "0x20000CE")]
	public class DOTweenRectTransformPivot : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x780D20", Offset = "0x780D20")]
		[Token(Token = "0x40008F8")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780D94", Offset = "0x780D94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780D94", Offset = "0x780D94")]
		[Token(Token = "0x40008F9")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780DF4", Offset = "0x780DF4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780DF4", Offset = "0x780DF4")]
		[Token(Token = "0x40008FA")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780E44", Offset = "0x780E44")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780E44", Offset = "0x780E44")]
		[Token(Token = "0x40008FB")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780EA4", Offset = "0x780EA4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780EA4", Offset = "0x780EA4")]
		[Token(Token = "0x40008FC")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780EF4", Offset = "0x780EF4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780EF4", Offset = "0x780EF4")]
		[Token(Token = "0x40008FD")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x780F44", Offset = "0x780F44")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780F44", Offset = "0x780F44")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780F44", Offset = "0x780F44")]
		[Token(Token = "0x40008FE")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780FB8", Offset = "0x780FB8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780FB8", Offset = "0x780FB8")]
		[Token(Token = "0x40008FF")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x781008", Offset = "0x781008")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781008", Offset = "0x781008")]
		[Token(Token = "0x4000900")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781058", Offset = "0x781058")]
		[Token(Token = "0x4000901")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78106C", Offset = "0x78106C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78106C", Offset = "0x78106C")]
		[Token(Token = "0x4000902")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7810BC", Offset = "0x7810BC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7810BC", Offset = "0x7810BC")]
		[Token(Token = "0x4000903")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78110C", Offset = "0x78110C")]
		[Token(Token = "0x4000904")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781144", Offset = "0x781144")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781144", Offset = "0x781144")]
		[Token(Token = "0x4000905")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781194", Offset = "0x781194")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781194", Offset = "0x781194")]
		[Token(Token = "0x4000906")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7811E4", Offset = "0x7811E4")]
		[Token(Token = "0x4000907")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78121C", Offset = "0x78121C")]
		[Token(Token = "0x4000908")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000909")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x781254", Offset = "0x781254")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781254", Offset = "0x781254")]
		[Token(Token = "0x400090A")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7812A4", Offset = "0x7812A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7812A4", Offset = "0x7812A4")]
		[Token(Token = "0x400090B")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7812F4", Offset = "0x7812F4")]
		[Token(Token = "0x400090C")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78132C", Offset = "0x78132C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78132C", Offset = "0x78132C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78132C", Offset = "0x78132C")]
		[Token(Token = "0x400090D")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7813A0", Offset = "0x7813A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7813A0", Offset = "0x7813A0")]
		[Token(Token = "0x400090E")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7813F0", Offset = "0x7813F0")]
		[Token(Token = "0x400090F")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781428", Offset = "0x781428")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781428", Offset = "0x781428")]
		[Token(Token = "0x4000910")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x781478", Offset = "0x781478")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781478", Offset = "0x781478")]
		[Token(Token = "0x4000911")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000912")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60004D8")]
		[Address(RVA = "0xA1BFB0", Offset = "0xA1BFB0", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv23 = *([1EC83A0]);\n\tv24 = *([v23 @ X8_v6]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021D55]) = v43;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv48 = 0xA2928C(this, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmVector2::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X19+58]) = X20;\n\tX22 = *([1ED98E0]);\n\tX0 = *([X22]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmFloat::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X19+68]) = X20;\n\tX21 = *([1F0E6C0]);\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X20+38]) = 0;\n\t*([X19+70]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X20+38]) = 0;\n\t*([X19+60]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X20+38]) = 0;\n\t*([X19+80]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X20+38]) = 0;\n\t*([X19+90]) = 0;\n\t*([X19+98]) = 0;\n\t*([X19+88]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X20+38]) = 0;\n\t*([X19+A0]) = X20;\n\tX23 = *([1ED01C0]);\n\tX0 = *([X23]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X19+B8]) = X20;\n\tX0 = *([X23]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+10]) = 0;\n\t*([X19+C0]) = X20;\n\tX0 = *([X22]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmFloat::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\tX8 = 0 | 0x100000000;\n\t*([X20+38]) = 0;\n\t*([X19+78]) = X20;\n\t*([X19+C8]) = X8;\n\tX8 = *([1ECE5A0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmInt::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+38]) = 0;\n\t*([X19+E0]) = X20;\n\t*([X19+E8]) = 0;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\tX8 = 0 | 1;\n\t*([X20+38]) = X8;\n\t*([X19+F0]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+38]) = 0;\n\t*([X19+F8]) = X20;\n\t*([X19+100]) = 0;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+38]) = 0;\n\t*([X19+108]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_00C1;\n\t*([X20+38]) = 0;\n\t*([X19+110]) = X20;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX23 = stack[0];\n\t// 191 ShiftStack 64\n\treturn;\nL_00C1:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @A2928C (inside HutongGames.PlayMaker.Actions.DOTweenTextColor::<OnEnter>b__28_1 +0x38)");
		}

		[Token(Token = "0x60004D9")]
		[Address(RVA = "0xA1C24C", Offset = "0xA1C24C", Length = "0x3CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EDAB58]);\n\tv29 = *([v28 @ X8_v52]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021D56]) = v48;\nL_001D:\n\tv53 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv184 = UnityEngine.GameObject::GetComponent(v53);\n\tv145 = this.to;\n\tv241 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 52 MakeStruct v78 @ AGGA1C2E8_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v145.value (UnityEngine.Vector2), v145.value.y (System.Single)\n\tv185 = DG.Tweening.DOTweenModuleUI::DOPivot(v184, v78, v241);\n\tthis.tween = v185;\n\tv245 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv247 = v245 == 0;\n\tif (v247) goto L_004A;\n\tv252 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_004A:\n\tv255 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv258 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v255);\n\tv261 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v261);\n\tv85 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv267 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v85);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv270 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv273 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v270, this.loopType);\n\tv275 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv278 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v275);\n\tv280 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv283 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v280);\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv288 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v285);\n\tv289 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv291 = v289 == 0;\n\tif (v291) goto L_00BB;\n\tv306 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv297 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v306);\nL_00BB:\n\tv304 = this.startEvent == 0;\n\tif (v304) goto L_00D3;\n\tv311 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v311, this, Il2CppMethodInfo);\n\tv317 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v311);\nL_00D3:\n\tv326 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv330 = v326 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_00F5;\n\tv337 = new DG.Tweening.TweenCallback();\n\tv346 = this.finishEvent == 0;\n\tif (v346) goto L_FFFFFFFF;\n\tgoto L_00EA;\nL_00EA:\n\tDG.Tweening.TweenCallback::.ctor(v337, this, *([v358 @ X8_v33 (Il2CppMethodInfo)]));\n\tv344 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v337);\nL_00F5:\n\tv351 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv357 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv363 = v357 == 0;\n\tif (v363) goto L_0108;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RectTransform Pivot\");\nL_0108:\n\tv227 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv229 = v227 == 0;\n\tif (v229) goto L_0124;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0124:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 231 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			FsmVector2 fsmVector = to;
			float value = duration.Value;
			Vector2 endValue = default(Vector2);
			endValue.x = fsmVector.value.x;
			endValue.y = fsmVector.value.y;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = component.DOPivot(endValue, value);
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
				State.Debug("DOTween RectTransform Pivot");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004DA")]
		[Address(RVA = "0xA1C618", Offset = "0xA1C618", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA4828]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D57]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRectTransformPivot()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
