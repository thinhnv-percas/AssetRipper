using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FA64", Offset = "0x74FA64")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FA64", Offset = "0x74FA64")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FA64", Offset = "0x74FA64")]
	[Token(Token = "0x20000CD")]
	public class DOTweenRectTransformJumpAnchorPos : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x78057C", Offset = "0x78057C")]
		[Token(Token = "0x40008DD")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7805F0", Offset = "0x7805F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7805F0", Offset = "0x7805F0")]
		[Token(Token = "0x40008DE")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780650", Offset = "0x780650")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780650", Offset = "0x780650")]
		[Token(Token = "0x40008DF")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7806A0", Offset = "0x7806A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7806A0", Offset = "0x7806A0")]
		[Token(Token = "0x40008E0")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat jumpPower;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780700", Offset = "0x780700")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780700", Offset = "0x780700")]
		[Token(Token = "0x40008E1")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt numJumps;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780760", Offset = "0x780760")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780760", Offset = "0x780760")]
		[Token(Token = "0x40008E2")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7807B0", Offset = "0x7807B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7807B0", Offset = "0x7807B0")]
		[Token(Token = "0x40008E3")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780810", Offset = "0x780810")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780810", Offset = "0x780810")]
		[Token(Token = "0x40008E4")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x780860", Offset = "0x780860")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780860", Offset = "0x780860")]
		[Token(Token = "0x40008E5")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7808B0", Offset = "0x7808B0")]
		[Token(Token = "0x40008E6")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7808C4", Offset = "0x7808C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7808C4", Offset = "0x7808C4")]
		[Token(Token = "0x40008E7")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x780914", Offset = "0x780914")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780914", Offset = "0x780914")]
		[Token(Token = "0x40008E8")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780964", Offset = "0x780964")]
		[Token(Token = "0x40008E9")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78099C", Offset = "0x78099C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78099C", Offset = "0x78099C")]
		[Token(Token = "0x40008EA")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7809EC", Offset = "0x7809EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7809EC", Offset = "0x7809EC")]
		[Token(Token = "0x40008EB")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x780A3C", Offset = "0x780A3C")]
		[Token(Token = "0x40008EC")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780A74", Offset = "0x780A74")]
		[Token(Token = "0x40008ED")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x40008EE")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x780AAC", Offset = "0x780AAC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780AAC", Offset = "0x780AAC")]
		[Token(Token = "0x40008EF")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780AFC", Offset = "0x780AFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780AFC", Offset = "0x780AFC")]
		[Token(Token = "0x40008F0")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780B4C", Offset = "0x780B4C")]
		[Token(Token = "0x40008F1")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x780B84", Offset = "0x780B84")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780B84", Offset = "0x780B84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780B84", Offset = "0x780B84")]
		[Token(Token = "0x40008F2")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780BF8", Offset = "0x780BF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780BF8", Offset = "0x780BF8")]
		[Token(Token = "0x40008F3")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780C48", Offset = "0x780C48")]
		[Token(Token = "0x40008F4")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780C80", Offset = "0x780C80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x780C80", Offset = "0x780C80")]
		[Token(Token = "0x40008F5")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x780CD0", Offset = "0x780CD0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x780CD0", Offset = "0x780CD0")]
		[Token(Token = "0x40008F6")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x40008F7")]
		[FieldOffset(Offset = "0x118")]
		private Sequence sequence;

		[Token(Token = "0x60004D3")]
		[Address(RVA = "0xA1B874", Offset = "0xA1B874", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EF4328]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D52]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.to = v52;\n\tv59 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v59);\n\tv59.useVariable = 0;\n\tv59.value = 0;\n\tthis.setRelative = v59;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.useVariable = 0;\n\tthis.jumpPower = v83;\n\tv84 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.numJumps = v84;\n\tv85 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.duration = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.snapping = v86;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.finishImmediately = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.stringAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.tagAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v90);\n\tv90.value = 0f;\n\tthis.startDelay = v90;\n\tthis.selectedEase = 0x100000000;\n\tv91 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v91);\n\tv91.value = 0;\n\tthis.loops = v91;\n\tthis.loopType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 1;\n\tthis.autoKillOnCompletion = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.recyclable = v93;\n\tthis.updateType = 0;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.isIndependentUpdate = v94;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.debugThis = v95;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01c3: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = false;
			to = fsmVector;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setRelative = fsmBool;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			jumpPower = fsmFloat;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			numJumps = fsmInt;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			snapping = fsmBool2;
			startEvent = null;
			finishEvent = null;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			finishImmediately = fsmBool3;
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
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.value = true;
			autoKillOnCompletion = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.value = false;
			recyclable = fsmBool5;
			updateType = default(UpdateType);
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = false;
			isIndependentUpdate = fsmBool6;
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = false;
			debugThis = fsmBool7;
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0xA1BB08", Offset = "0xA1BB08", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EAD580]);\n\tv33 = *([v32 @ X8_v53]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D53]) = v52;\nL_0020:\n\tgoto L_0027;\n\tv59 = *([v55 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0027;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0027:\n\tv67 = DG.Tweening.DOTween::Sequence();\n\tthis.sequence = v67;\n\tv74 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv109 = UnityEngine.GameObject::GetComponent(v74);\n\tv117 = this.to;\n\tv93 = HutongGames.PlayMaker.FsmFloat::get_Value(this.jumpPower);\n\tv110 = HutongGames.PlayMaker.FsmInt::get_Value(this.numJumps);\n\tv145 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv274 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 93 MakeStruct v77 @ AGGA1BC28_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v117.value (UnityEngine.Vector2), v117.value.y (System.Single)\n\tv111 = DG.Tweening.DOTweenModuleUI::DOJumpAnchorPos(v109, v77, v93, v110, v145, v274);\n\tv278 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv283 = DG.Tweening.TweenSettingsExtensions::SetRelative(v111, v278);\n\tv285 = DG.Tweening.TweenSettingsExtensions::Append(v67, v283);\n\tv288 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.sequence, this.tweenIdType, this.stringAsId, this.tagAsId, v288);\n\tv146 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv294 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.sequence, v146);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.sequence, this.selectedEase, this.easeType, this.animationCurve);\n\tv297 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv300 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.sequence, v297, this.loopType);\n\tv302 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv305 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.sequence, v302);\n\tv307 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.sequence, v307);\n\tv314 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv321 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.sequence, this.updateType, v314);\n\tv323 = this.startEvent == 0;\n\tif (v323) goto L_00DE;\n\tv328 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v328, this, Il2CppMethodInfo);\n\tv334 = DG.Tweening.TweenSettingsExtensions::OnStart(this.sequence, v328);\nL_00DE:\n\tv341 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv345 = v341 == 0;\n\tv346 = ~v345;\n\tif (v346) goto L_0100;\n\tv352 = new DG.Tweening.TweenCallback();\n\tv361 = this.finishEvent == 0;\n\tif (v361) goto L_FFFFFFFF;\n\tgoto L_00F5;\nL_00F5:\n\tDG.Tweening.TweenCallback::.ctor(v352, this, *([v373 @ X8_v37 (Il2CppMethodInfo)]));\n\tv359 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.sequence, v352);\nL_0100:\n\tv366 = DG.Tweening.TweenExtensions::Play(this.sequence);\n\tv372 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv378 = v372 == 0;\n\tif (v378) goto L_0113;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RectTransform Jump Anchor Pos\");\nL_0113:\n\tv259 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv261 = v259 == 0;\n\tif (v261) goto L_0133;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0133:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 244 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Sequence s = (this.sequence = DOTween.Sequence());
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			FsmVector2 fsmVector = to;
			float value = jumpPower.Value;
			int value2 = numJumps.Value;
			float value3 = duration.Value;
			bool value4 = snapping.Value;
			Vector2 endValue = default(Vector2);
			endValue.x = fsmVector.value.x;
			endValue.y = fsmVector.value.y;
			Sequence t = component.DOJumpAnchorPos(endValue, value, value2, value3, value4);
			bool value5 = setRelative.Value;
			Sequence t2 = t.SetRelative(value5);
			Sequence sequence = s.Append(t2);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			this.sequence.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value6 = startDelay.Value;
			Sequence sequence2 = this.sequence.SetDelay(value6);
			this.sequence.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value7 = loops.Value;
			Sequence sequence3 = this.sequence.SetLoops(value7, loopType);
			bool value8 = autoKillOnCompletion.Value;
			Sequence sequence4 = this.sequence.SetAutoKill(value8);
			bool value9 = recyclable.Value;
			Sequence sequence5 = this.sequence.SetRecyclable(value9);
			bool value10 = isIndependentUpdate.Value;
			Sequence sequence6 = this.sequence.SetUpdate(updateType, value10);
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Sequence sequence7 = this.sequence.OnStart(action);
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
				Sequence sequence8 = this.sequence.OnComplete(action2);
			}
			Sequence sequence9 = this.sequence.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween RectTransform Jump Anchor Pos");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004D5")]
		[Address(RVA = "0xA1BF00", Offset = "0xA1BF00", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF6B18]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D54]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRectTransformJumpAnchorPos()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
