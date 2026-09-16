using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754ADC", Offset = "0x754ADC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754ADC", Offset = "0x754ADC")]
	[Token(Token = "0x200019F")]
	public class GetControllerCollisionFlags : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AC838", Offset = "0x7AC838")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC838", Offset = "0x7AC838")]
		[Token(Token = "0x400130E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AC8D0", Offset = "0x7AC8D0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC8D0", Offset = "0x7AC8D0")]
		[Token(Token = "0x400130F")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool isGrounded;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AC920", Offset = "0x7AC920")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC920", Offset = "0x7AC920")]
		[Token(Token = "0x4001310")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool none;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AC970", Offset = "0x7AC970")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC970", Offset = "0x7AC970")]
		[Token(Token = "0x4001311")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool sides;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AC9C0", Offset = "0x7AC9C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC9C0", Offset = "0x7AC9C0")]
		[Token(Token = "0x4001312")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool above;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ACA10", Offset = "0x7ACA10")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ACA10", Offset = "0x7ACA10")]
		[Token(Token = "0x4001313")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool below;

		[Token(Token = "0x4001314")]
		[FieldOffset(Offset = "0x80")]
		private GameObject previousGo;

		[Token(Token = "0x4001315")]
		[FieldOffset(Offset = "0x88")]
		private CharacterController controller;

		[Token(Token = "0x60008D2")]
		[Address(RVA = "0xA2A3B8", Offset = "0xA2A3B8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.none = 0;\n\tthis.above = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			none = null;
			above = null;
			gameObject = null;
		}

		[Token(Token = "0x60008D3")]
		[Address(RVA = "0xA2A3C8", Offset = "0xA2A3C8", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EA8A60]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DAA]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv122 = *([v88 @ X8_v5+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_002C;\n\tv132 = v88;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v132, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv131 = UnityEngine.Object::op_Equality(v47, 0);\n\tv134 = v131 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_009A;\n\tgoto L_003F;\n\tv169 = *([v159 @ X0_v13+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_003F;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v159, v129, v130, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv102 = UnityEngine.Object::op_Inequality(v47, this.previousGo);\n\tv177 = v102 == 0;\n\tif (v177) goto L_004E;\n\tv183 = UnityEngine.GameObject::GetComponent(v47);\n\tthis.previousGo = v47;\n\tthis.controller = v183;\n\tgoto L_0053;\nL_004E:\n\tv49 = this.controller;\nL_0053:\n\tgoto L_005C;\n\tv193 = *([v189 @ X0_v18+E0]);\n\tv194 = v193 == 0;\n\tv195 = ~v194;\n\tgoto L_005C;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v189, v185, v97, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005C:\n\tv164 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv165 = v164 == 0;\n\tif (v165) goto L_009A;\n\tv82 = this.isGrounded;\n\tv103 = UnityEngine.CharacterController::get_isGrounded(this.controller);\n\tv82.value = v103;\n\tv83 = this.none;\n\tv104 = UnityEngine.CharacterController::get_collisionFlags(this.controller);\n\tv83.value = 0;\n\tv84 = this.sides;\n\tv105 = UnityEngine.CharacterController::get_collisionFlags(this.controller);\n\tv78 = v105 & 1;\n\tv84.value = v78;\n\tv85 = this.above;\n\tv106 = UnityEngine.CharacterController::get_collisionFlags(this.controller);\n\tv201 = v106 >> 1;\n\tv79 = v201 & 1;\n\tv85.value = v79;\n\tv116 = this.below;\n\tv107 = UnityEngine.CharacterController::get_collisionFlags(this.controller);\n\tv202 = v107 >> 2;\n\tv167 = v202 & 1;\n\tv116.value = v167;\nL_009A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				CharacterController characterController;
				if (ownerDefaultTarget != previousGo)
				{
					CharacterController component = ownerDefaultTarget.GetComponent<CharacterController>();
					previousGo = ownerDefaultTarget;
					controller = component;
					characterController = component;
				}
				else
				{
					characterController = controller;
				}
				if (characterController != null)
				{
					FsmBool fsmBool = isGrounded;
					bool value = controller.isGrounded;
					fsmBool.value = value;
					FsmBool fsmBool2 = none;
					CollisionFlags collisionFlags = controller.collisionFlags;
					fsmBool2.value = false;
					FsmBool fsmBool3 = sides;
					CollisionFlags collisionFlags2 = controller.collisionFlags;
					int value2 = (int)(collisionFlags2 & CollisionFlags.Sides);
					fsmBool3.value = (byte)value2 != 0;
					FsmBool fsmBool4 = above;
					CollisionFlags collisionFlags3 = controller.collisionFlags;
					int num = (int)collisionFlags3 >> 1;
					int value3 = num & 1;
					fsmBool4.value = (byte)value3 != 0;
					FsmBool fsmBool5 = below;
					CollisionFlags collisionFlags4 = controller.collisionFlags;
					int num2 = (int)collisionFlags4 >> 2;
					int value4 = num2 & 1;
					fsmBool5.value = (byte)value4 != 0;
				}
			}
		}

		[Token(Token = "0x60008D4")]
		[Address(RVA = "0xA2A58C", Offset = "0xA2A58C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetControllerCollisionFlags()
		{
		}
	}
}
