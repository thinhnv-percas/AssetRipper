using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754A8C", Offset = "0x754A8C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754A8C", Offset = "0x754A8C")]
	[Token(Token = "0x200019E")]
	public class ControllerSimpleMove : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AC6E4", Offset = "0x7AC6E4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC6E4", Offset = "0x7AC6E4")]
		[Token(Token = "0x4001308")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC77C", Offset = "0x7AC77C")]
		[Token(Token = "0x4001309")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 moveVector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC7C8", Offset = "0x7AC7C8")]
		[Token(Token = "0x400130A")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat speed;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AC800", Offset = "0x7AC800")]
		[Token(Token = "0x400130B")]
		[FieldOffset(Offset = "0x68")]
		public Space space;

		[Token(Token = "0x400130C")]
		[FieldOffset(Offset = "0x70")]
		private GameObject previousGo;

		[Token(Token = "0x400130D")]
		[FieldOffset(Offset = "0x78")]
		private CharacterController controller;

		[Token(Token = "0x60008CF")]
		[Address(RVA = "0xA91D40", Offset = "0xA91D40", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0EF30]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221FE]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv42 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.moveVector = v42;\n\tv49 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.speed = v49;\n\tthis.space = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			moveVector = fsmVector;
			FsmFloat fsmFloat = 1f;
			speed = fsmFloat;
			space = default(Space);
		}

		[Token(Token = "0x60008D0")]
		[Address(RVA = "0xA91DCC", Offset = "0xA91DCC", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EEEB38]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20221FF]) = v50;\nL_001E:\n\tv55 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0030;\n\tv154 = *([v97 @ X8_v5+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0030;\n\tv164 = v97;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v164, v53, v54, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0030:\n\tv163 = UnityEngine.Object::op_Equality(v55, 0);\n\tv166 = v163 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0089;\n\tgoto L_0043;\n\tv227 = *([v220 @ X0_v13+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0043;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v220, v161, v162, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0043:\n\tv133 = UnityEngine.Object::op_Inequality(v55, this.previousGo);\n\tv235 = v133 == 0;\n\tif (v235) goto L_0052;\n\tv241 = UnityEngine.GameObject::GetComponent(v55);\n\tthis.previousGo = v55;\n\tthis.controller = v241;\n\tgoto L_0057;\nL_0052:\n\tv72 = this.controller;\nL_0057:\n\tgoto L_0060;\n\tv251 = *([v247 @ X0_v18+E0]);\n\tv252 = v251 == 0;\n\tv253 = ~v252;\n\tgoto L_0060;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v247, v243, v126, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0060:\n\tv134 = UnityEngine.Object::op_Inequality(v72, 0);\n\tv225 = v134 == 0;\n\tif (v225) goto L_0089;\n\tv259 = this.space == 0;\n\tif (v259) goto L_008E;\n\tv135 = UnityEngine.GameObject::get_transform(v55);\n\tv119 = HutongGames.PlayMaker.FsmVector3::get_Value(this.moveVector);\n\tv70 = UnityEngine.Transform::TransformDirection(v135, v119);\n\tv68 = v70.y;\n\tv66 = v70.z;\n\tgoto L_0099;\nL_0089:\n\treturn;\nL_008E:\n\tv70 = HutongGames.PlayMaker.FsmVector3::get_Value(this.moveVector);\n\tv68 = v70.y;\n\tv66 = v70.z;\nL_0099:\n\tv273 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tgoto L_00AC;\n\tv280 = *([v276 @ X0_v24+E0]);\n\tv281 = v280 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_00AC;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v276, v131, v79, v35, v36, v37, v38, v39, v273, v68, v66, v43, v44, v45, v46, v47);\nL_00AC:\n\t// 172 MakeStruct v103 @ AGGA91FA4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v70 @ V0_v3 (UnityEngine.Vector3), v68 @ V1_v3 (System.Single), v66 @ V2_v3 (System.Single)\n\tv120 = UnityEngine.Vector3::op_Multiply(v103, v273);\n\tv206 = UnityEngine.CharacterController::SimpleMove(this.controller, v120);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
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
				Vector3 vector;
				float y;
				float z;
				if (space != Space.World)
				{
					Transform transform = ownerDefaultTarget.transform;
					Vector3 value = moveVector.Value;
					vector = transform.TransformDirection(value);
					y = vector.y;
					z = vector.z;
				}
				else
				{
					vector = moveVector.Value;
					y = vector.y;
					z = vector.z;
				}
				float value2 = speed.Value;
				Vector3 vector2 = default(Vector3);
				vector2.x = vector.x;
				vector2.y = y;
				vector2.z = z;
				Vector3 vector3 = vector2 * value2;
				bool flag = controller.SimpleMove(vector3);
			}
		}

		[Token(Token = "0x60008D1")]
		[Address(RVA = "0xA91FD8", Offset = "0xA91FD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ControllerSimpleMove()
		{
		}
	}
}
