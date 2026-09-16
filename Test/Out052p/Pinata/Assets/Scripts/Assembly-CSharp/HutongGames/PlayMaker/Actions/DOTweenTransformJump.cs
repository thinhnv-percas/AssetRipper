using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750DFC", Offset = "0x750DFC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750DFC", Offset = "0x750DFC")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750DFC", Offset = "0x750DFC")]
	[Token(Token = "0x20000F3")]
	public class DOTweenTransformJump : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79355C", Offset = "0x79355C")]
		[Token(Token = "0x4000D07")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7935D0", Offset = "0x7935D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7935D0", Offset = "0x7935D0")]
		[Token(Token = "0x4000D08")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793630", Offset = "0x793630")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793630", Offset = "0x793630")]
		[Token(Token = "0x4000D09")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793680", Offset = "0x793680")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793680", Offset = "0x793680")]
		[Token(Token = "0x4000D0A")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7936D0", Offset = "0x7936D0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7936D0", Offset = "0x7936D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7936D0", Offset = "0x7936D0")]
		[Token(Token = "0x4000D0B")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793744", Offset = "0x793744")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793744", Offset = "0x793744")]
		[Token(Token = "0x4000D0C")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793794", Offset = "0x793794")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793794", Offset = "0x793794")]
		[Token(Token = "0x4000D0D")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat jumpPower;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7937F4", Offset = "0x7937F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7937F4", Offset = "0x7937F4")]
		[Token(Token = "0x4000D0E")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt numJumps;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793854", Offset = "0x793854")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793854", Offset = "0x793854")]
		[Token(Token = "0x4000D0F")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7938B4", Offset = "0x7938B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7938B4", Offset = "0x7938B4")]
		[Token(Token = "0x4000D10")]
		[FieldOffset(Offset = "0x98")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x793904", Offset = "0x793904")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793904", Offset = "0x793904")]
		[Token(Token = "0x4000D11")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793954", Offset = "0x793954")]
		[Token(Token = "0x4000D12")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793968", Offset = "0x793968")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793968", Offset = "0x793968")]
		[Token(Token = "0x4000D13")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7939B8", Offset = "0x7939B8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7939B8", Offset = "0x7939B8")]
		[Token(Token = "0x4000D14")]
		[FieldOffset(Offset = "0xB8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793A08", Offset = "0x793A08")]
		[Token(Token = "0x4000D15")]
		[FieldOffset(Offset = "0xC0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793A40", Offset = "0x793A40")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793A40", Offset = "0x793A40")]
		[Token(Token = "0x4000D16")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793A90", Offset = "0x793A90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793A90", Offset = "0x793A90")]
		[Token(Token = "0x4000D17")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x793AE0", Offset = "0x793AE0")]
		[Token(Token = "0x4000D18")]
		[FieldOffset(Offset = "0xD8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793B18", Offset = "0x793B18")]
		[Token(Token = "0x4000D19")]
		[FieldOffset(Offset = "0xDC")]
		public Ease easeType;

		[Token(Token = "0x4000D1A")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x793B50", Offset = "0x793B50")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793B50", Offset = "0x793B50")]
		[Token(Token = "0x4000D1B")]
		[FieldOffset(Offset = "0xE8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793BA0", Offset = "0x793BA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793BA0", Offset = "0x793BA0")]
		[Token(Token = "0x4000D1C")]
		[FieldOffset(Offset = "0xF0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793BF0", Offset = "0x793BF0")]
		[Token(Token = "0x4000D1D")]
		[FieldOffset(Offset = "0xF8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x793C28", Offset = "0x793C28")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793C28", Offset = "0x793C28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793C28", Offset = "0x793C28")]
		[Token(Token = "0x4000D1E")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793C9C", Offset = "0x793C9C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793C9C", Offset = "0x793C9C")]
		[Token(Token = "0x4000D1F")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793CEC", Offset = "0x793CEC")]
		[Token(Token = "0x4000D20")]
		[FieldOffset(Offset = "0x110")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793D24", Offset = "0x793D24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793D24", Offset = "0x793D24")]
		[Token(Token = "0x4000D21")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x793D74", Offset = "0x793D74")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793D74", Offset = "0x793D74")]
		[Token(Token = "0x4000D22")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool debugThis;

		[Token(Token = "0x4000D23")]
		[FieldOffset(Offset = "0x128")]
		private Sequence sequence;

		[Token(Token = "0x6000591")]
		[Address(RVA = "0xA781F0", Offset = "0xA781F0", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0D030]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022140]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.to = v52;\n\tv59 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v59);\n\tv59.useVariable = 0;\n\tthis.toGameObject = v59;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.setRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.snapping = v86;\n\tv87 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.jumpPower = v87;\n\tv88 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.numJumps = v88;\n\tv89 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.duration = v89;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.useVariable = 0;\n\tv90.value = 0;\n\tthis.finishImmediately = v90;\n\tv91 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v91);\n\tv91.useVariable = 0;\n\tthis.stringAsId = v91;\n\tv92 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v92);\n\tv92.useVariable = 0;\n\tthis.tagAsId = v92;\n\tv93 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v93);\n\tv93.value = 0f;\n\tthis.startDelay = v93;\n\tthis.selectedEase = 0x100000000;\n\tv94 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v94);\n\tv94.value = 0;\n\tthis.loops = v94;\n\tthis.loopType = 0;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 1;\n\tthis.autoKillOnCompletion = v95;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.recyclable = v96;\n\tthis.updateType = 0;\n\tv97 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v97);\n\tv97.value = 0;\n\tthis.isIndependentUpdate = v97;\n\tv98 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v98);\n\tv98.value = 0;\n\tthis.debugThis = v98;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01ea: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			to = fsmVector;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			toGameObject = fsmGameObject;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setRelative = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			snapping = fsmBool2;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			jumpPower = fsmFloat;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			numJumps = fsmInt;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
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

		[Token(Token = "0x6000592")]
		[Address(RVA = "0xA784AC", Offset = "0xA784AC", Length = "0x498")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1F09C40]);\n\tv35 = *([v34 @ X8_v58]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022141]) = v54;\nL_0021:\n\tgoto L_0028;\n\tv61 = *([v57 @ X0_v2+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0028;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0028:\n\tv69 = DG.Tweening.DOTween::Sequence();\n\tthis.sequence = v69;\n\tv72 = this.target == 0;\n\tif (v72) goto L_005A;\n\tv82 = this.target != 1;\n\tif (v82) goto L_00A8;\n\tv184 = this + 0x30;\n\tv222 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv325 = UnityEngine.GameObject::GetComponent(v222);\n\tv223 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv224 = UnityEngine.GameObject::get_transform(v223);\n\tv145 = UnityEngine.Transform::get_position(v224);\n\tv138 = v145.y;\n\tv135 = v145.z;\n\tgoto L_0077;\nL_005A:\n\tv184 = this + 0x30;\n\tv94 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv326 = UnityEngine.GameObject::GetComponent(v94);\n\tv145 = HutongGames.PlayMaker.FsmVector3::get_Value(this.to);\n\tv138 = v145.y;\n\tv135 = v145.z;\nL_0077:\n\tv141 = HutongGames.PlayMaker.FsmFloat::get_Value(this.jumpPower);\n\tv327 = HutongGames.PlayMaker.FsmInt::get_Value(this.numJumps);\n\tv142 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv441 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 148 MakeStruct v275 @ AGGA78658_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v145 @ V0_v3 (UnityEngine.Vector3), v138 @ V1_v2 (System.Single), v135 @ V2_v2 (System.Single)\n\tv328 = DG.Tweening.ShortcutExtensions::DOJump(v148, v275, v141, v327, v142, v441);\n\tv450 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv455 = DG.Tweening.TweenSettingsExtensions::SetRelative(v328, v450);\n\tv286 = DG.Tweening.TweenSettingsExtensions::Append(v69, v455);\n\tgoto L_00B2;\nL_00A8:\n\tv184 = this + 0x30;\nL_00B2:\n\tv341 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([v184 @ X23_v1]), this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.sequence, this.tweenIdType, this.stringAsId, this.tagAsId, v341);\n\tv144 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv421 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.sequence, v144);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.sequence, this.selectedEase, this.easeType, this.animationCurve);\n\tv430 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv433 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.sequence, v430, this.loopType);\n\tv436 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv439 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.sequence, v436);\n\tv444 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv447 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.sequence, v444);\n\tv459 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv467 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.sequence, this.updateType, v459);\n\tv469 = this.startEvent == 0;\n\tif (v469) goto L_0117;\n\tv474 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v474, this, Il2CppMethodInfo);\n\tv480 = DG.Tweening.TweenSettingsExtensions::OnStart(this.sequence, v474);\nL_0117:\n\tv487 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv491 = v487 == 0;\n\tv492 = ~v491;\n\tif (v492) goto L_0139;\n\tv498 = new DG.Tweening.TweenCallback();\n\tv507 = this.finishEvent == 0;\n\tif (v507) goto L_FFFFFFFF;\n\tgoto L_012E;\nL_012E:\n\tDG.Tweening.TweenCallback::.ctor(v498, this, *([v519 @ X8_v29 (Il2CppMethodInfo)]));\n\tv505 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.sequence, v498);\nL_0139:\n\tv512 = DG.Tweening.TweenExtensions::Play(this.sequence);\n\tv518 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv524 = v518 == 0;\n\tif (v524) goto L_014C;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Jump\");\nL_014C:\n\tv398 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv400 = v398 == 0;\n\tif (v400) goto L_016E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_016E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 285 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_00fc: Expected O, but got I
			//IL_0247: Expected O, but got I
			//IL_0065: Expected O, but got I
			Sequence s = (this.sequence = DOTween.Sequence());
			object obj;
			Vector3 vector;
			float y;
			float z;
			Transform transform2;
			if (target != Target.Value)
			{
				if (target != Target.GameObject)
				{
					obj = (long)(IntPtr)this + 48L;
					goto IL_024c;
				}
				obj = (long)(IntPtr)this + 48L;
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component = ownerDefaultTarget.GetComponent<Transform>();
				GameObject value = toGameObject.Value;
				Transform transform = value.transform;
				vector = transform.position;
				y = vector.y;
				z = vector.z;
				transform2 = component;
			}
			else
			{
				obj = (long)(IntPtr)this + 48L;
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component2 = ownerDefaultTarget2.GetComponent<Transform>();
				vector = to.Value;
				y = vector.y;
				z = vector.z;
				transform2 = component2;
			}
			float value2 = jumpPower.Value;
			int value3 = numJumps.Value;
			float value4 = duration.Value;
			bool value5 = snapping.Value;
			Vector3 endValue = default(Vector3);
			endValue.x = vector.x;
			endValue.y = y;
			endValue.z = z;
			Sequence t = transform2.DOJump(endValue, value2, value3, value4, value5);
			bool value6 = setRelative.Value;
			Sequence t2 = t.SetRelative(value6);
			Sequence sequence = s.Append(t2);
			goto IL_024c;
			IL_024c:
			GameObject ownerDefaultTarget3 = ((Fsm)obj).GetOwnerDefaultTarget(gameObject);
			this.sequence.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget3);
			float value7 = startDelay.Value;
			Sequence sequence2 = this.sequence.SetDelay(value7);
			this.sequence.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value8 = loops.Value;
			Sequence sequence3 = this.sequence.SetLoops(value8, loopType);
			bool value9 = autoKillOnCompletion.Value;
			Sequence sequence4 = this.sequence.SetAutoKill(value9);
			bool value10 = recyclable.Value;
			Sequence sequence5 = this.sequence.SetRecyclable(value10);
			bool value11 = isIndependentUpdate.Value;
			Sequence sequence6 = this.sequence.SetUpdate(updateType, value11);
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
				State.Debug("DOTween Transform Jump");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000593")]
		[Address(RVA = "0xA78944", Offset = "0xA78944", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB92C0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022142]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformJump()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
