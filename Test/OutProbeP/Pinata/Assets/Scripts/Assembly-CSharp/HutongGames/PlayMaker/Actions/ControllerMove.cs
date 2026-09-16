using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7549EC", Offset = "0x7549EC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7549EC", Offset = "0x7549EC")]
	[Token(Token = "0x200019C")]
	public class ControllerMove : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AC370", Offset = "0x7AC370")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC370", Offset = "0x7AC370")]
		[Token(Token = "0x40012F8")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC408", Offset = "0x7AC408")]
		[Token(Token = "0x40012F9")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 moveVector;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC454", Offset = "0x7AC454")]
		[Token(Token = "0x40012FA")]
		[FieldOffset(Offset = "0x60")]
		public Space space;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AC48C", Offset = "0x7AC48C")]
		[Token(Token = "0x40012FB")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool perSecond;

		[Token(Token = "0x40012FC")]
		[FieldOffset(Offset = "0x70")]
		private GameObject previousGo;

		[Token(Token = "0x40012FD")]
		[FieldOffset(Offset = "0x78")]
		private CharacterController controller;

		[Token(Token = "0x60008C7")]
		[Address(RVA = "0xA91658", Offset = "0xA91658", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFB100]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221FA]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv42 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.moveVector = v42;\n\tthis.space = 0;\n\tv49 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.perSecond = v49;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			moveVector = fsmVector;
			space = default(Space);
			FsmBool fsmBool = true;
			perSecond = fsmBool;
		}

		[Token(Token = "0x60008C8")]
		[Address(RVA = "0xA916E4", Offset = "0xA916E4", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1F040A8]);\n\tv33 = *([v32 @ X8_v27]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20221FB]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0031;\n\tv161 = *([v101 @ X8_v5+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0031;\n\tv171 = v101;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v171, v55, v56, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0031:\n\tv170 = UnityEngine.Object::op_Equality(v57, 0);\n\tv173 = v170 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_008F;\n\tgoto L_0044;\n\tv245 = *([v237 @ X0_v13+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_0044;\n\tv249 = \"il2cpp_codegen_runtime_class_init\"(v237, v168, v169, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0044:\n\tv138 = UnityEngine.Object::op_Inequality(v57, this.previousGo);\n\tv253 = v138 == 0;\n\tif (v253) goto L_0056;\n\tv261 = UnityEngine.GameObject::GetComponent(v57);\n\tv74 = this + 0x78;\n\tthis.controller = v261;\n\tthis.previousGo = v57;\n\tgoto L_005C;\nL_0056:\n\tv74 = this + 0x78;\n\tv76 = this.controller;\nL_005C:\n\tgoto L_0065;\n\tv273 = *([v268 @ X0_v18+E0]);\n\tv274 = v273 == 0;\n\tv275 = ~v274;\n\tgoto L_0065;\n\tv277 = \"il2cpp_codegen_runtime_class_init\"(v268, v264, v131, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0065:\n\tv139 = UnityEngine.Object::op_Inequality(v76, 0);\n\tv243 = v139 == 0;\n\tif (v243) goto L_008F;\n\tv281 = this.space == 0;\n\tif (v281) goto L_0094;\n\tv140 = UnityEngine.GameObject::get_transform(v57);\n\tv123 = HutongGames.PlayMaker.FsmVector3::get_Value(this.moveVector);\n\tv203 = UnityEngine.Transform::TransformDirection(v140, v123);\n\tv201 = v203.y;\n\tv199 = v203.z;\n\tgoto L_009E;\nL_008F:\n\treturn;\nL_0094:\n\tv203 = HutongGames.PlayMaker.FsmVector3::get_Value(this.moveVector);\n\tv201 = v203.y;\n\tv199 = v203.z;\nL_009E:\n\tv143 = HutongGames.PlayMaker.FsmBool::get_Value(this.perSecond);\n\tv296 = v143 == 0;\n\tif (v296) goto L_FFFFFFFF;\n\tv298 = UnityEngine.Time::get_deltaTime();\n\tgoto L_00B7;\n\tv309 = *([v301 @ X0_v29+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_00B7;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v301, v136, v83, v37, v38, v39, v40, v41, v298, v70, v68, v45, v46, v47, v48, v49);\nL_00B7:\n\t// 183 MakeStruct v107 @ AGGA918DC_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v203 @ V0_v4 (UnityEngine.Vector3), v201 @ V1_v4 (System.Single), v199 @ V2_v4 (System.Single)\n\tv203 = UnityEngine.Vector3::op_Multiply(v107, v298);\n\tv201 = v203.y;\n\tv199 = v203.z;\n\tgoto L_00D2;\nL_00D2:\n\t// 210 MakeStruct v177 @ AGGA9191C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v203 @ V0_v4 (UnityEngine.Vector3), v201 @ V1_v4 (System.Single), v199 @ V2_v4 (System.Single)\n\tv221 = UnityEngine.CharacterController::Move(v319, v177);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_00d0: Expected O, but got I
			//IL_00a3: Expected O, but got I
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
				obj = (long)(IntPtr)this + 120L;
				controller = component;
				previousGo = ownerDefaultTarget;
				characterController = component;
			}
			else
			{
				obj = (long)(IntPtr)this + 120L;
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
				CharacterController characterController2;
				if (perSecond.Value)
				{
					float deltaTime = Time.deltaTime;
					Vector3 vector2 = default(Vector3);
					vector2.x = vector.x;
					vector2.y = y;
					vector2.z = z;
					vector = vector2 * deltaTime;
					y = vector.y;
					z = vector.z;
					characterController2 = (CharacterController)obj;
				}
				else
				{
					characterController2 = (CharacterController)obj;
				}
				Vector3 motion = default(Vector3);
				motion.x = vector.x;
				motion.y = y;
				motion.z = z;
				CollisionFlags collisionFlags = characterController2.Move(motion);
			}
		}

		[Token(Token = "0x60008C9")]
		[Address(RVA = "0xA9192C", Offset = "0xA9192C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ControllerMove()
		{
		}
	}
}
