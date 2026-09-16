using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D544", Offset = "0x74D544")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74D544", Offset = "0x74D544")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D544", Offset = "0x74D544")]
	[Token(Token = "0x2000085")]
	public class DOTweenAnimateVector3 : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4000378")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767C58", Offset = "0x767C58")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767C58", Offset = "0x767C58")]
		[Token(Token = "0x4000379")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 variable;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767CB8", Offset = "0x767CB8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767CB8", Offset = "0x767CB8")]
		[Token(Token = "0x400037A")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 to;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767D18", Offset = "0x767D18")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767D18", Offset = "0x767D18")]
		[Token(Token = "0x400037B")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setRelative;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767D68", Offset = "0x767D68")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767D68", Offset = "0x767D68")]
		[Token(Token = "0x400037C")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767DC8", Offset = "0x767DC8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767DC8", Offset = "0x767DC8")]
		[Token(Token = "0x400037D")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767E18", Offset = "0x767E18")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767E18", Offset = "0x767E18")]
		[Token(Token = "0x400037E")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[Attribute(Type = typeof(ActionSection), RVA = "0x767E68", Offset = "0x767E68")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767E68", Offset = "0x767E68")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767E68", Offset = "0x767E68")]
		[Token(Token = "0x400037F")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767EDC", Offset = "0x767EDC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767EDC", Offset = "0x767EDC")]
		[Token(Token = "0x4000380")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[Attribute(Type = typeof(ActionSection), RVA = "0x767F2C", Offset = "0x767F2C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767F2C", Offset = "0x767F2C")]
		[Token(Token = "0x4000381")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767F7C", Offset = "0x767F7C")]
		[Token(Token = "0x4000382")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767F90", Offset = "0x767F90")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x767F90", Offset = "0x767F90")]
		[Token(Token = "0x4000383")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[Attribute(Type = typeof(ActionSection), RVA = "0x767FE0", Offset = "0x767FE0")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x767FE0", Offset = "0x767FE0")]
		[Token(Token = "0x4000384")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x768030", Offset = "0x768030")]
		[Token(Token = "0x4000385")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x768068", Offset = "0x768068")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x768068", Offset = "0x768068")]
		[Token(Token = "0x4000386")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7680B8", Offset = "0x7680B8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7680B8", Offset = "0x7680B8")]
		[Token(Token = "0x4000387")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[Attribute(Type = typeof(ActionSection), RVA = "0x768108", Offset = "0x768108")]
		[Token(Token = "0x4000388")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x768140", Offset = "0x768140")]
		[Token(Token = "0x4000389")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x400038A")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[Attribute(Type = typeof(ActionSection), RVA = "0x768178", Offset = "0x768178")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x768178", Offset = "0x768178")]
		[Token(Token = "0x400038B")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7681C8", Offset = "0x7681C8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7681C8", Offset = "0x7681C8")]
		[Token(Token = "0x400038C")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x768218", Offset = "0x768218")]
		[Token(Token = "0x400038D")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[Attribute(Type = typeof(ActionSection), RVA = "0x768250", Offset = "0x768250")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x768250", Offset = "0x768250")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x768250", Offset = "0x768250")]
		[Token(Token = "0x400038E")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7682C4", Offset = "0x7682C4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7682C4", Offset = "0x7682C4")]
		[Token(Token = "0x400038F")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x768314", Offset = "0x768314")]
		[Token(Token = "0x4000390")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76834C", Offset = "0x76834C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76834C", Offset = "0x76834C")]
		[Token(Token = "0x4000391")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76839C", Offset = "0x76839C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76839C", Offset = "0x76839C")]
		[Token(Token = "0x4000392")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000393")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x600039B")]
		[Address(RVA = "0xA99C60", Offset = "0xA99C60", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EAE5D8]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202222D]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 1;\n\tthis.variable = v50;\n\tv56 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v56);\n\tv56.useVariable = 0;\n\tthis.to = v56;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			variable = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = false;
			to = fsmVector2;
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

		[Token(Token = "0x600039C")]
		[Address(RVA = "0xA99F20", Offset = "0xA99F20", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv31 = *([1F03780]);\n\tv32 = *([v31 @ X8_v15]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202222E]) = v51;\nL_001D:\n\tv55 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v55, this, Il2CppMethodInfo);\n\tv67 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v67, this, Il2CppMethodInfo);\n\tv79 = HutongGames.PlayMaker.FsmVector3::get_Value(this.to);\n\tv100 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv104 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(this.duration, 0, Il2CppMethodInfo);\n\treturn;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0051;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0051:\n\tX0 = X20;\n\tX1 = X21;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tV3 = V11;\n\tX2 = 0;\n\t// 88 MakeStruct AGGA9A038_2, typeof(UnityEngine.Vector3), V0, V1, V2\n\tX0 = DG.Tweening.DOTween::To(X0, X1, AGGA9A038_2, V3, X2);\n\tX8 = *([X19+78]);\n\t*([X19+120]) = X0;\n\tif (TEMP) goto L_014E;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0069;\n\tX0 = *([X19+120]);\n\tX8 = *([1EEDB38]);\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased /* +4 sharing this address */(X0, X1);\nL_0069:\n\tX0 = *([X19+68]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1EEA7C8]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetRelative /* +4 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+50]);\n\tX20 = *([X19+C0]);\n\tX21 = *([X19+C8]);\n\tX22 = *([X19+B8]);\n\tX23 = *([X19+120]);\n\tX2 = 0;\n\tX0 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(X0, X1, X2);\n\tX4 = X0;\n\tX0 = X23;\n\tX1 = X22;\n\tX2 = X20;\n\tX3 = X21;\n\tX5 = 0;\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(X0, X1, X2, X3, X4, X5);\n\tX0 = *([X19+80]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX8 = *([1ED8EC8]);\n\tX0 = X20;\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetDelay /* +5 sharing this address */(X0, V0, X1);\n\tX0 = *([X19+120]);\n\tX1 = *([X19+D0]);\n\tX2 = *([X19+D4]);\n\tX3 = *([X19+D8]);\n\tX4 = 0;\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(X0, X1, X2, X3, X4);\n\tX0 = *([X19+E8]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX2 = *([X19+F0]);\n\tX8 = *([1EE6E00]);\n\tX1 = X0;\n\tX0 = X20;\n\tX3 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetLoops /* +5 sharing this address */(X0, X1, X2, X3);\n\tX0 = *([X19+F8]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1EA6E00]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetAutoKill /* +5 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+100]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1ED17F8]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetRecyclable /* +3 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+108]);\n\tX21 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1ED5DF8]);\n\tX2 = X0 & 1;\n\tX0 = X21;\n\tX1 = X20;\n\tX3 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetUpdate /* +3 sharing this address */(X0, X1, X2, X3);\n\tX0 = *([X19+88]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00DE;\n\tX0 = *([X19+90]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1EEA250]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::From /* +2 sharing this address */(X0, X1, X2);\nL_00DE:\n\tX8 = *([X19+98]);\n\tif (TEMP) goto L_00F3;\n\tX20 = *([X19+120]);\n\tX8 = *([1EF3F98]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE8658]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tDG.Tweening.TweenCallback::.ctor(X0, X1, X2, X3);\n\tX8 = *([1F01228]);\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::OnStart /* +5 sharing this address */(X0, X1, X2);\nL_00F3:\n\tX0 = *([X19+A8]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0115;\n\tX22 = *([X19+A0]);\n\tX20 = *([X19+120]);\n\tX8 = *([1EF3F98]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0108;\n\tX8 = *([1ED6B40]);\n\tgoto L_010A;\nL_0108:\n\tX8 = 0x1EA5000;\n\tX8 = *([1EA5AA8]);\nL_010A:\n\tX2 = *([X8]);\n\tX0 = X21;\n\tX1 = X19;\n\tX3 = 0;\n\tDG.Tweening.TweenCallback::.ctor(X0, X1, X2, X3);\n\tX8 = *([1EE6378]);\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::OnComplete /* +5 sharing this address */(X0, X1, X2);\nL_0115:\n\tX8 = 0x1F01000;\n\tX0 = *([X19+120]);\n\tX8 = *([1F01CE0]);\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.TweenExtensions::Play /* +5 sharing this address */(X0, X1);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0128;\n\tX0 = *([X19+28]);\n\tX8 = *([1F08E40]);\n\tX2 = 0;\n\tX1 = *([X8]);\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(X0, X1, X2);\nL_0128:\n\tX0 = *([X19+A8]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0140;\n\tX0 = X19;\n\tX29 = stack[50];\n\tX30 = stack[58];\n\tX20 = stack[40];\n\tX19 = stack[48];\n\tX22 = stack[30];\n\tX21 = stack[38];\n\tX23 = stack[20];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tX1 = 0;\n\tV11 = stack[0];\n\tV10 = stack[8];\n\t// 317 ShiftStack 96\n\tHutongGames.PlayMaker.FsmStateAction::Finish(X0, X1);\n\treturn;\nL_0140:\n\tX29 = stack[50];\n\tX30 = stack[58];\n\tX20 = stack[40];\n\tX19 = stack[48];\n\tX22 = stack[30];\n\tX21 = stack[38];\n\tX23 = stack[20];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV11 = stack[0];\n\tV10 = stack[8];\n\t// 331 ShiftStack 96\n\treturn;\n\tthrow System.NullReferenceException;\nL_014E:\n\t;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DOGetter<Vector3> dOGetter = () => variable.Value;
			DOSetter<Vector3> dOSetter = delegate(Vector3 x)
			{
				FsmVector3 fsmVector = variable;
				fsmVector.value = x;
				fsmVector.value.y = x.y;
				fsmVector.value.z = x.z;
			};
			Vector3 value = to.Value;
			float value2 = duration.Value;
		}

		[Token(Token = "0x600039D")]
		[Address(RVA = "0xA9A370", Offset = "0xA9A370", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F033A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202222F]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAnimateVector3()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
