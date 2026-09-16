using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74DB74", Offset = "0x74DB74")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74DB74", Offset = "0x74DB74")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74DB74", Offset = "0x74DB74")]
	[Token(Token = "0x2000091")]
	public class DOTweenCameraShakePosition : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x76D898", Offset = "0x76D898")]
		[Token(Token = "0x40004C0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76D90C", Offset = "0x76D90C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76D90C", Offset = "0x76D90C")]
		[Token(Token = "0x40004C1")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat duration;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76D96C", Offset = "0x76D96C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76D96C", Offset = "0x76D96C")]
		[Token(Token = "0x40004C2")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setSpeedBased;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76D9BC", Offset = "0x76D9BC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76D9BC", Offset = "0x76D9BC")]
		[Token(Token = "0x40004C3")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat startDelay;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DA0C", Offset = "0x76DA0C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DA0C", Offset = "0x76DA0C")]
		[Token(Token = "0x40004C4")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 strength;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DA5C", Offset = "0x76DA5C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DA5C", Offset = "0x76DA5C")]
		[Token(Token = "0x40004C5")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt vibrato;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DAAC", Offset = "0x76DAAC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DAAC", Offset = "0x76DAAC")]
		[Token(Token = "0x40004C6")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat randomness;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76DAFC", Offset = "0x76DAFC")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DAFC", Offset = "0x76DAFC")]
		[Token(Token = "0x40004C7")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent startEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DB4C", Offset = "0x76DB4C")]
		[Token(Token = "0x40004C8")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DB60", Offset = "0x76DB60")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DB60", Offset = "0x76DB60")]
		[Token(Token = "0x40004C9")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool finishImmediately;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76DBB0", Offset = "0x76DBB0")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DBB0", Offset = "0x76DBB0")]
		[Token(Token = "0x40004CA")]
		[FieldOffset(Offset = "0xA0")]
		public string tweenIdDescription;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DC00", Offset = "0x76DC00")]
		[Token(Token = "0x40004CB")]
		[FieldOffset(Offset = "0xA8")]
		public TweenId tweenIdType;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DC38", Offset = "0x76DC38")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DC38", Offset = "0x76DC38")]
		[Token(Token = "0x40004CC")]
		[FieldOffset(Offset = "0xB0")]
		public FsmString stringAsId;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DC88", Offset = "0x76DC88")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DC88", Offset = "0x76DC88")]
		[Token(Token = "0x40004CD")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString tagAsId;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76DCD8", Offset = "0x76DCD8")]
		[Token(Token = "0x40004CE")]
		[FieldOffset(Offset = "0xC0")]
		public SelectedEase selectedEase;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DD10", Offset = "0x76DD10")]
		[Token(Token = "0x40004CF")]
		[FieldOffset(Offset = "0xC4")]
		public Ease easeType;

		[Token(Token = "0x40004D0")]
		[FieldOffset(Offset = "0xC8")]
		public FsmAnimationCurve animationCurve;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76DD48", Offset = "0x76DD48")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DD48", Offset = "0x76DD48")]
		[Token(Token = "0x40004D1")]
		[FieldOffset(Offset = "0xD0")]
		public string loopsDescriptionArea;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DD98", Offset = "0x76DD98")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DD98", Offset = "0x76DD98")]
		[Token(Token = "0x40004D2")]
		[FieldOffset(Offset = "0xD8")]
		public FsmInt loops;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DDE8", Offset = "0x76DDE8")]
		[Token(Token = "0x40004D3")]
		[FieldOffset(Offset = "0xE0")]
		public LoopType loopType;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76DE20", Offset = "0x76DE20")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DE20", Offset = "0x76DE20")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DE20", Offset = "0x76DE20")]
		[Token(Token = "0x40004D4")]
		[FieldOffset(Offset = "0xE8")]
		public FsmBool autoKillOnCompletion;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DE94", Offset = "0x76DE94")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DE94", Offset = "0x76DE94")]
		[Token(Token = "0x40004D5")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool recyclable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DEE4", Offset = "0x76DEE4")]
		[Token(Token = "0x40004D6")]
		[FieldOffset(Offset = "0xF8")]
		public UpdateType updateType;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DF1C", Offset = "0x76DF1C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76DF1C", Offset = "0x76DF1C")]
		[Token(Token = "0x40004D7")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool isIndependentUpdate;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76DF6C", Offset = "0x76DF6C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76DF6C", Offset = "0x76DF6C")]
		[Token(Token = "0x40004D8")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool debugThis;

		[Token(Token = "0x40004D9")]
		[FieldOffset(Offset = "0x110")]
		private Tweener tween;

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0xAEEB98", Offset = "0xAEEB98", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EAEF60]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022424]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.duration = v52;\n\tv59 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v59);\n\tv59.useVariable = 0;\n\tv59.value = 0;\n\tthis.setSpeedBased = v59;\n\tv86 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v86);\n\tv86.useVariable = 0;\n\tgoto L_0049;\n\tv166 = *([v162 @ X0_v12+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0049;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v162, v73, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0049:\n\tv69 = UnityEngine.Vector3::get_zero();\n\tv86.value = v69;\n\tv86.value.y = v69.y;\n\tv86.value.z = v69.z;\n\tthis.strength = v86;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0xA;\n\tthis.vibrato = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 90f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.randomness = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.useVariable = 0;\n\tv89.value = 0;\n\tthis.finishImmediately = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.stringAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v91);\n\tv91.useVariable = 0;\n\tthis.tagAsId = v91;\n\tv92 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v92);\n\tv92.value = 0f;\n\tthis.startDelay = v92;\n\tthis.selectedEase = 0x100000000;\n\tv93 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v93);\n\tv93.value = 0;\n\tthis.loops = v93;\n\tthis.loopType = 0;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 1;\n\tthis.autoKillOnCompletion = v94;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.recyclable = v95;\n\tthis.updateType = 0;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.isIndependentUpdate = v96;\n\tv97 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v97);\n\tv97.value = 0;\n\tthis.debugThis = v97;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60003DA")]
		[Address(RVA = "0xAEEE48", Offset = "0xAEEE48", Length = "0x3BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv31 = *([1EEF980]);\n\tv32 = *([v31 @ X8_v18]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2022425]) = v51;\nL_001F:\n\tv56 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv153 = UnityEngine.GameObject::GetComponent(v56);\n\tv95 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv96 = HutongGames.PlayMaker.FsmVector3::get_Value(this.strength);\n\tv154 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv198 = HutongGames.PlayMaker.FsmFloat::get_Value(this.randomness);\n\tv155 = DG.Tweening.ShortcutExtensions::DOShakePosition(v153, v95, v96, v154, v198, 1);\n\tthis.tween = v155;\n\tv202 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv204 = v202 == 0;\n\tif (v204) goto L_0067;\n\tv209 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0067:\n\tv213 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v213);\n\tv98 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv219 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v98);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv221 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv189 = 0xAFDCB4(v221, 0, this.loopType, this.animationCurve, 0, 0, v39, v40, v98, v96, v96.y, v96.z, v198, v46, v47, v48);\n\treturn;\n\tX1 = X0;\n\tX0 = X20;\n\tX3 = *([1EE6000]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetLoops /* +5 sharing this address */(X0, X1, X2, X3);\n\tX0 = *([X19+E8]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+110]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1EA6E00]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetAutoKill /* +5 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+F0]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+110]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1ED17F8]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetRecyclable /* +3 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+100]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+F8]);\n\tX21 = *([X19+110]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1ED5DF8]);\n\tX2 = X0 & 1;\n\tX0 = X21;\n\tX1 = X20;\n\tX3 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetUpdate /* +3 sharing this address */(X0, X1, X2, X3);\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_00C9;\n\tX20 = *([X19+110]);\n\tX8 = *([1EF3F98]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFEC90]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tDG.Tweening.TweenCallback::.ctor(X0, X1, X2, X3);\n\tX8 = *([1F01228]);\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::OnStart /* +5 sharing this address */(X0, X1, X2);\nL_00C9:\n\tX0 = *([X19+98]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00EB;\n\tX22 = *([X19+90]);\n\tX20 = *([X19+110]);\n\tX8 = *([1EF3F98]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_00DE;\n\tX8 = *([1EDC3E8]);\n\tgoto L_00E0;\nL_00DE:\n\tX8 = 0x1EA5000;\n\tX8 = *([1EA5AA8]);\nL_00E0:\n\tX2 = *([X8]);\n\tX0 = X21;\n\tX1 = X19;\n\tX3 = 0;\n\tDG.Tweening.TweenCallback::.ctor(X0, X1, X2, X3);\n\tX8 = *([1EE6378]);\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::OnComplete /* +5 sharing this address */(X0, X1, X2);\nL_00EB:\n\tX8 = 0x1F01000;\n\tX0 = *([X19+110]);\n\tX8 = *([1F01CE0]);\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.TweenExtensions::Play /* +5 sharing this address */(X0, X1);\n\tX0 = *([X19+108]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00FE;\n\tX0 = *([X19+28]);\n\tX8 = *([1EBD130]);\n\tX2 = 0;\n\tX1 = *([X8]);\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(X0, X1, X2);\nL_00FE:\n\tX0 = *([X19+98]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0116;\n\tX0 = X19;\n\tX29 = stack[50];\n\tX30 = stack[58];\n\tX20 = stack[40];\n\tX19 = stack[48];\n\tX22 = stack[30];\n\tX21 = stack[38];\n\tX23 = stack[20];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tX1 = 0;\n\tV11 = stack[0];\n\tV10 = stack[8];\n\t// 275 ShiftStack 96\n\tHutongGames.PlayMaker.FsmStateAction::Finish(X0, X1);\n\treturn;\nL_0116:\n\tX29 = stack[50];\n\tX30 = stack[58];\n\tX20 = stack[40];\n\tX19 = stack[48];\n\tX22 = stack[30];\n\tX21 = stack[38];\n\tX23 = stack[20];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV11 = stack[0];\n\tV10 = stack[8];\n\t// 289 ShiftStack 96\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Camera component = ownerDefaultTarget.GetComponent<Camera>();
			float value = duration.Value;
			Vector3 value2 = strength.Value;
			int value3 = vibrato.Value;
			float value4 = randomness.Value;
			Tweener tweener = component.DOShakePosition(value, value2, value3, value4);
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
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AFDCB4 (inside HutongGames.PlayMaker.Actions.DOTweenMaterialTiling::<OnEnter>b__28_1 +0x30)");
		}

		[Token(Token = "0x60003DB")]
		[Address(RVA = "0xAEF204", Offset = "0xAEF204", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED1CF0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022426]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenCameraShakePosition()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
