using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75499C", Offset = "0x75499C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75499C", Offset = "0x75499C")]
	[Token(Token = "0x200019B")]
	public class ControllerIsGrounded : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AC1E0", Offset = "0x7AC1E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC1E0", Offset = "0x7AC1E0")]
		[Token(Token = "0x40012F1")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC278", Offset = "0x7AC278")]
		[Token(Token = "0x40012F2")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC2B0", Offset = "0x7AC2B0")]
		[Token(Token = "0x40012F3")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC2E8", Offset = "0x7AC2E8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AC2E8", Offset = "0x7AC2E8")]
		[Token(Token = "0x40012F4")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC338", Offset = "0x7AC338")]
		[Token(Token = "0x40012F5")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x40012F6")]
		[FieldOffset(Offset = "0x78")]
		private GameObject previousGo;

		[Token(Token = "0x40012F7")]
		[FieldOffset(Offset = "0x80")]
		private CharacterController controller;

		[Token(Token = "0x60008C2")]
		[Address(RVA = "0xA9146C", Offset = "0xA9146C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.falseEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			falseEvent = null;
		}

		[Token(Token = "0x60008C3")]
		[Address(RVA = "0xA9147C", Offset = "0xA9147C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ControllerIsGrounded::DoControllerIsGrounded(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoControllerIsGrounded();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008C4")]
		[Address(RVA = "0xA9164C", Offset = "0xA9164C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ControllerIsGrounded::DoControllerIsGrounded(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoControllerIsGrounded();
		}

		[Token(Token = "0x60008C5")]
		[Address(RVA = "0xA914B8", Offset = "0xA914B8", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EE8F50]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221F9]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002D;\n\tv102 = *([v73 @ X8_v5+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_002D;\n\tv112 = v73;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v112, v47, v48, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv111 = UnityEngine.Object::op_Equality(v49, 0);\n\tv114 = v111 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_006D;\n\tgoto L_0040;\n\tv182 = *([v174 @ X0_v13+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0040;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v174, v109, v110, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0040:\n\tv89 = UnityEngine.Object::op_Inequality(v49, this.previousGo);\n\tv190 = v89 == 0;\n\tif (v190) goto L_0052;\n\tv198 = UnityEngine.GameObject::GetComponent(v49);\n\tv51 = this + 0x80;\n\tthis.controller = v198;\n\tthis.previousGo = v49;\n\tgoto L_0058;\nL_0052:\n\tv51 = this + 0x80;\n\tv53 = this.controller;\nL_0058:\n\tgoto L_0061;\n\tv210 = *([v205 @ X0_v18+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tgoto L_0061;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v205, v201, v84, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0061:\n\tv180 = UnityEngine.Object::op_Equality(v53, 0);\n\tv181 = v180 == 0;\n\tif (v181) goto L_0072;\nL_006D:\n\treturn;\nL_0072:\n\tv90 = UnityEngine.CharacterController::get_isGrounded(*([v51 @ X23_v5]));\n\tv97 = this.storeResult;\n\tv97.value = v90;\n\tv147 = this + 0x58;\n\tv136 = this + 0x60;\n\tv130 = v90 == 0;\n\tv121 = ~v130;\n\tv118 = ~v121;\n\tif (v118) goto L_FFFFFFFF;\n\tgoto L_0094;\nL_0094:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v147 @ X9_v7]));\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoControllerIsGrounded()
		{
			//IL_00d0: Expected O, but got I
			//IL_00a3: Expected O, but got I
			//IL_0145: Expected O, but got I
			//IL_0151: Expected O, but got I
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			CharacterController characterController;
			if (ownerDefaultTarget != previousGo)
			{
				CharacterController component = ownerDefaultTarget.GetComponent<CharacterController>();
				obj = (long)(IntPtr)this + 128L;
				controller = component;
				previousGo = ownerDefaultTarget;
				characterController = component;
			}
			else
			{
				obj = (long)(IntPtr)this + 128L;
				characterController = controller;
			}
			if (!(characterController == null))
			{
				bool isGrounded = ((CharacterController)obj).isGrounded;
				FsmBool fsmBool = storeResult;
				fsmBool.value = isGrounded;
				object fsmEvent = (long)(IntPtr)this + 88L;
				object obj2 = (long)(IntPtr)this + 96L;
				if (!isGrounded)
				{
					fsmEvent = obj2;
				}
				Fsm.Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x60008C6")]
		[Address(RVA = "0xA91650", Offset = "0xA91650", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ControllerIsGrounded()
		{
		}
	}
}
