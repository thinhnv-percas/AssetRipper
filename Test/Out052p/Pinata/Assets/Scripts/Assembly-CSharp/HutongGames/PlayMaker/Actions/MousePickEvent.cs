using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758008", Offset = "0x758008")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x758008", Offset = "0x758008")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758008", Offset = "0x758008")]
	[Token(Token = "0x2000246")]
	public class MousePickEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B42C4", Offset = "0x7B42C4")]
		[Token(Token = "0x400159E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault GameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4328", Offset = "0x7B4328")]
		[Token(Token = "0x400159F")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat rayDistance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4360", Offset = "0x7B4360")]
		[Token(Token = "0x40015A0")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent mouseOver;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4398", Offset = "0x7B4398")]
		[Token(Token = "0x40015A1")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent mouseDown;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B43D0", Offset = "0x7B43D0")]
		[Token(Token = "0x40015A2")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent mouseUp;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4408", Offset = "0x7B4408")]
		[Token(Token = "0x40015A3")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent mouseOff;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4440", Offset = "0x7B4440")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4440", Offset = "0x7B4440")]
		[Token(Token = "0x40015A4")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4490", Offset = "0x7B4490")]
		[Token(Token = "0x40015A5")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B44C8", Offset = "0x7B44C8")]
		[Token(Token = "0x40015A6")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x6000B67")]
		[Address(RVA = "0xA3D4F0", Offset = "0xA3D4F0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0C4A0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E61]) = v38;\nL_0016:\n\tthis.GameObject = 0;\n\tv42 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.rayDistance = v42;\n\tthis.mouseOver = 0;\n\tthis.mouseUp = 0;\n\t// 32 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v48;\n\tv51 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v51;\n\tthis.everyFrame = 1;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			GameObject = null;
			FsmFloat fsmFloat = 100f;
			rayDistance = fsmFloat;
			mouseOver = null;
			mouseUp = null;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			everyFrame = true;
		}

		[Token(Token = "0x6000B68")]
		[Address(RVA = "0xA3D580", Offset = "0xA3D580", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePickEvent::DoMousePickEvent(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoMousePickEvent();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B69")]
		[Address(RVA = "0xA3D6FC", Offset = "0xA3D6FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePickEvent::DoMousePickEvent(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMousePickEvent();
		}

		[Token(Token = "0x6000B6A")]
		[Address(RVA = "0xA3D5BC", Offset = "0xA3D5BC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC6510]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E62]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.Actions.MousePickEvent::DoRaycast(this);\n\tv43 = HutongGames.PlayMaker.ActionHelpers;\n\tv44 = *([v43 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.ActionHelpers>)+B8]);\n\tv45 = this.fsm;\n\tv45.<RaycastHitInfo>k__BackingField.m_Distance = *([v44 @ X9_v1 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+1C]);\n\tv45.<RaycastHitInfo>k__BackingField.m_Normal.y = *([v44 @ X9_v1 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+10]);\n\tv45.<RaycastHitInfo>k__BackingField = v44.mousePickInfo;\n\tv60 = v40 == 0;\n\tif (v60) goto L_0053;\n\tv63 = this.mouseDown == 0;\n\tif (v63) goto L_003E;\n\tv89 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv95 = v89 == 0;\n\tif (v95) goto L_003E;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.mouseDown);\nL_003E:\n\tv96 = this.mouseOver == 0;\n\tif (v96) goto L_0046;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.mouseOver);\nL_0046:\n\tv103 = this.mouseUp == 0;\n\tif (v103) goto L_0066;\n\tv101 = UnityEngine.Input::GetMouseButtonUp(0);\n\tv104 = v101 == 0;\n\tif (v104) goto L_0066;\n\tv116 = this.fsm;\n\tv114 = this.mouseUp;\n\tgoto L_005F;\nL_0053:\n\tv114 = this.mouseOff;\n\tv65 = this.mouseOff == 0;\n\tif (v65) goto L_0066;\n\tv116 = this.fsm;\nL_005F:\n\tHutongGames.PlayMaker.Fsm::Event(v116, v114);\n\treturn;\nL_0066:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMousePickEvent()
		{
			//IL_01c5: Expected I, but got O
			//IL_01ce: Expected I, but got O
			//IL_001f: Expected F4, but got I
			//IL_003e: Expected F4, but got I
			bool flag = DoRaycast();
			IntPtr intPtr = (IntPtr)typeof(ActionHelpers);
			IntPtr intPtr2 = (IntPtr)ActionHelpers.mousePickInfo;
			Fsm fsm = Fsm;
			ref RaycastHit reference = ref fsm.RaycastHitInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X9_v1 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+1C]");
			reference.m_Distance = 0f;
			ref Vector3 normal = ref fsm.RaycastHitInfo.m_Normal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X9_v1 (Il2CppStaticFields<HutongGames.PlayMaker.ActionHelpers>)+10]");
			normal.y = 0f;
			fsm.RaycastHitInfo = ActionHelpers.mousePickInfo;
			Fsm fsm2;
			FsmEvent fsmEvent;
			if (flag)
			{
				if (mouseDown != null && Input.GetMouseButtonDown(0))
				{
					Fsm.Event(mouseDown);
				}
				if (mouseOver != null)
				{
					Fsm.Event(mouseOver);
				}
				if (mouseUp == null || !Input.GetMouseButtonUp(0))
				{
					return;
				}
				fsm2 = Fsm;
				fsmEvent = mouseUp;
			}
			else
			{
				fsmEvent = mouseOff;
				if (mouseOff == null)
				{
					return;
				}
				fsm2 = Fsm;
			}
			fsm2.Event(fsmEvent);
		}

		[Token(Token = "0x6000B6B")]
		[Address(RVA = "0xA3D700", Offset = "0xA3D700", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.GameObject;\n\tv17 = v14.ownerOption == 0;\n\tif (v17) goto L_0015;\n\tv56 = HutongGames.PlayMaker.FsmGameObject::get_Value(v14.gameObject);\n\tgoto L_001A;\nL_0015:\n\tv28 = this.owner;\nL_001A:\n\tv26 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rayDistance);\n\tv82 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv86 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v82);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::IsMouseOver(v28, v26, v86);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoRaycast()
		{
			FsmOwnerDefault gameObject = GameObject;
			GameObject gameObject2;
			if (gameObject.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = gameObject.GameObject.Value;
				gameObject2 = value;
			}
			else
			{
				gameObject2 = Owner;
			}
			float value2 = rayDistance.Value;
			bool value3 = invertMask.Value;
			int num = ActionHelpers.LayerArrayToLayerMask(layerMask, value3);
			return ActionHelpers.IsMouseOver(gameObject2, value2, num);
		}

		[Token(Token = "0x6000B6C")]
		[Address(RVA = "0xA3D7A0", Offset = "0xA3D7A0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED28E0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E63]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rayDistance);\n\tv45 = HutongGames.PlayMaker.ActionHelpers::CheckRayDistance(v42);\n\tv52 = System.String::Concat(\"\", v45);\n\tv85 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.GameObject);\n\tv87 = HutongGames.PlayMaker.ActionHelpers::CheckPhysicsSetup(v85);\n\treturnVal2 = System.String::Concat(v52, v87);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			float value = rayDistance.Value;
			string text = ActionHelpers.CheckRayDistance(value);
			string text2 = "" + text;
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(GameObject);
			string text3 = ActionHelpers.CheckPhysicsSetup(ownerDefaultTarget);
			return text2 + text3;
		}

		[Token(Token = "0x6000B6D")]
		[Address(RVA = "0xA3D850", Offset = "0xA3D850", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.rayDistance = v13;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MousePickEvent()
		{
			FsmFloat fsmFloat = 100f;
			rayDistance = fsmFloat;
		}
	}
}
