using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752104", Offset = "0x752104")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752104", Offset = "0x752104")]
	[Token(Token = "0x2000121")]
	public class BlendAnimation : BaseAnimationAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A2554", Offset = "0x7A2554")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2554", Offset = "0x7A2554")]
		[Token(Token = "0x40010BD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A25EC", Offset = "0x7A25EC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A25EC", Offset = "0x7A25EC")]
		[Token(Token = "0x40010BE")]
		[FieldOffset(Offset = "0x68")]
		public FsmString animName;

		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A264C", Offset = "0x7A264C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A264C", Offset = "0x7A264C")]
		[Token(Token = "0x40010BF")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat targetWeight;

		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A26B0", Offset = "0x7A26B0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A26B0", Offset = "0x7A26B0")]
		[Token(Token = "0x40010C0")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat time;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2714", Offset = "0x7A2714")]
		[Token(Token = "0x40010C1")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent finishEvent;

		[Token(Token = "0x40010C2")]
		[FieldOffset(Offset = "0x88")]
		private DelayedEvent delayedFinishEvent;

		[Token(Token = "0x6000695")]
		[Address(RVA = "0xA8B9BC", Offset = "0xA8B9BC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.animName = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.targetWeight = v12;\n\tv16 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.3f);\n\tthis.time = v16;\n\tthis.finishEvent = 0;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			animName = null;
			FsmFloat fsmFloat = 1f;
			targetWeight = fsmFloat;
			FsmFloat fsmFloat2 = 0.3f;
			time = fsmFloat2;
			finishEvent = null;
		}

		[Token(Token = "0x6000696")]
		[Address(RVA = "0xA8BA00", Offset = "0xA8BA00", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0019;\nL_0013:\n\tv40 = *([this @ X0 (HutongGames.PlayMaker.Actions.BlendAnimation)+20]);\nL_0019:\n\tHutongGames.PlayMaker.Actions.BlendAnimation::DoBlendAnimation(this, v40);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0060: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.BlendAnimation)+20]");
				go = (GameObject)0;
			}
			DoBlendAnimation(go);
		}

		[Token(Token = "0x6000697")]
		[Address(RVA = "0xA8BC60", Offset = "0xA8BC60", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.DelayedEvent::WasSent(this.delayedFinishEvent);\n\tv14 = v12 == 0;\n\tif (v14) goto L_0018;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0018:\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (DelayedEvent.WasSent(delayedFinishEvent))
			{
				Finish();
			}
		}

		[Token(Token = "0x6000698")]
		[Address(RVA = "0xA8BA54", Offset = "0xA8BA54", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EE97D8]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, go, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20221CB]) = v45;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, go, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(go, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0039;\nL_0032:\n\treturn;\nL_0039:\n\tv143 = UnityEngine.GameObject::GetComponent(go);\n\tgoto L_0049;\n\tv191 = *([v172 @ X8_v9+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0049;\n\tv199 = v172;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v199, v142, v61, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0049:\n\tv198 = UnityEngine.Object::op_Equality(v143, 0);\n\tv201 = v198 == 0;\n\tif (v201) goto L_0057;\n\tv211 = UnityEngine.Object::get_name(go);\n\tgoto L_0070;\nL_0057:\n\tv162 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv227 = UnityEngine.Animation::get_Item(v143, v162);\n\tv235 = UnityEngine.TrackedReference::op_Equality(v227, 0);\n\tv237 = v235 == 0;\n\tif (v237) goto L_0085;\n\tv211 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\nL_0070:\n\tv221 = System.String::Concat(*([v215 @ X8_v10 (System.String)]), v211);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v221);\nL_007F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0085:\n\tv146 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv163 = HutongGames.PlayMaker.FsmString::get_Value(this.animName);\n\tv147 = HutongGames.PlayMaker.FsmFloat::get_Value(this.targetWeight);\n\tUnityEngine.Animation::Blend(v143, v163, v147, v146);\n\tv232 = this.finishEvent == 0;\n\tif (v232) goto L_007F;\n\tv68 = UnityEngine.AnimationState::get_length(v227);\n\tv81 = HutongGames.PlayMaker.Fsm::DelayedEvent(*([this @ X0 (HutongGames.PlayMaker.Actions.BlendAnimation)+30]), this.finishEvent, v68);\n\tthis.delayedFinishEvent = v81;\n\tgoto L_0032;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoBlendAnimation(GameObject go)
		{
			//IL_019f: Expected O, but got I
			if (go == null)
			{
				return;
			}
			Animation component = go.GetComponent<Animation>();
			string value;
			string text;
			if (component == null)
			{
				value = go.name;
				text = "Missing Animation component on GameObject: ";
			}
			else
			{
				string value2 = animName.Value;
				AnimationState animationState = component.get_Item(value2);
				if (!(animationState == null))
				{
					float value3 = time.Value;
					string value4 = animName.Value;
					float value5 = targetWeight.Value;
					component.Blend(value4, value5, value3);
					if (finishEvent != null)
					{
						float length = animationState.length;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.BlendAnimation)+30]");
						DelayedEvent delayedEvent = ((Fsm)0).DelayedEvent(finishEvent, length);
						delayedFinishEvent = delayedEvent;
						return;
					}
					goto IL_00fb;
				}
				value = animName.Value;
				text = "Missing animation: ";
			}
			string text2 = text + value;
			LogWarning(text2);
			goto IL_00fb;
			IL_00fb:
			Finish();
		}

		[Token(Token = "0x6000699")]
		[Address(RVA = "0xA8BCA0", Offset = "0xA8BCA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseAnimationAction::.ctor(this);\n\treturn;\n")]
		public BlendAnimation()
		{
		}
	}
}
