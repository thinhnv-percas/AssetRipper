using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A20C", Offset = "0x75A20C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A20C", Offset = "0x75A20C")]
	[Token(Token = "0x20002AD")]
	public class SetJointConnectedBody : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB164", Offset = "0x7BB164")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB164", Offset = "0x7BB164")]
		[Token(Token = "0x4001782")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault joint;

		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB1FC", Offset = "0x7BB1FC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB1FC", Offset = "0x7BB1FC")]
		[Token(Token = "0x4001783")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject rigidBody;

		[Token(Token = "0x6000D52")]
		[Address(RVA = "0x995DF0", Offset = "0x995DF0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.joint = 0;\n\tthis.rigidBody = 0;\n\treturn;\n")]
		public override void Reset()
		{
			joint = null;
			rigidBody = null;
		}

		[Token(Token = "0x6000D53")]
		[Address(RVA = "0x995DF8", Offset = "0x995DF8", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED7840]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021760]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.joint);\n\tgoto L_002B;\n\tv99 = *([v76 @ X8_v5+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_002B;\n\tv106 = v76;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v106, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv89 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv108 = v89 == 0;\n\tif (v108) goto L_007C;\n\tv143 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0045;\n\tv147 = *([v69 @ X8_v9+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0045;\n\tv154 = v69;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v154, v142, v84, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv136 = UnityEngine.Object::op_Inequality(v143, 0);\n\tv137 = v136 == 0;\n\tif (v137) goto L_007C;\n\tv157 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.rigidBody);\n\tgoto L_005D;\n\tv161 = *([v70 @ X8_v10+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_005D;\n\tv170 = v70;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v170, v156, v54, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005D:\n\tv169 = UnityEngine.Object::op_Equality(v157, 0);\n\tv172 = v169 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0073;\n\tv63 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.rigidBody);\n\tv175 = UnityEngine.GameObject::GetComponent(v63);\nL_0073:\n\tUnityEngine.Joint::set_connectedBody(v143, v87);\nL_007C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(joint);
			if (ownerDefaultTarget != null)
			{
				Joint component = ownerDefaultTarget.GetComponent<Joint>();
				if (component != null)
				{
					GameObject value = rigidBody.Value;
					bool flag = value == null;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					Rigidbody connectedBody = null;
					if (!flag3)
					{
						GameObject value2 = rigidBody.Value;
						Rigidbody component2 = value2.GetComponent<Rigidbody>();
						connectedBody = component2;
					}
					component.connectedBody = connectedBody;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000D54")]
		[Address(RVA = "0x995F70", Offset = "0x995F70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetJointConnectedBody()
		{
		}
	}
}
