using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75636C", Offset = "0x75636C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75636C", Offset = "0x75636C")]
	[Token(Token = "0x20001EC")]
	public class GetParent : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x400145F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1300", Offset = "0x7B1300")]
		[Token(Token = "0x4001460")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject storeResult;

		[Token(Token = "0x6000A21")]
		[Address(RVA = "0xA32594", Offset = "0xA32594", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			storeResult = null;
		}

		[Token(Token = "0x6000A22")]
		[Address(RVA = "0xA3259C", Offset = "0xA3259C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB5E50]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DFA]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv100 = *([v73 @ X8_v5+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_002C;\n\tv107 = v73;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v107, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv90 = UnityEngine.Object::op_Inequality(v47, 0);\n\tv109 = v90 == 0;\n\tif (v109) goto L_FFFFFFFF;\n\tv65 = UnityEngine.GameObject::get_transform(v47);\n\tv143 = UnityEngine.Transform::get_parent(v65);\n\tgoto L_0049;\n\tv147 = *([v74 @ X8_v7+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0049;\n\tv156 = v74;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v156, v142, v58, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv155 = UnityEngine.Object::op_Equality(v143, 0);\n\tv159 = v155 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_FFFFFFFF;\n\tv66 = UnityEngine.GameObject::get_transform(v47);\n\tv67 = UnityEngine.Transform::get_parent(v66);\n\tv163 = UnityEngine.Component::get_gameObject(v67);\n\tgoto L_0064;\nL_0064:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v140, v139);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(this.gameObject);
			GameObject value;
			FsmGameObject fsmGameObject;
			if (ownerDefaultTarget != null)
			{
				Transform transform = ownerDefaultTarget.transform;
				Transform parent = transform.parent;
				bool flag = parent == null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				value = null;
				if (!flag3)
				{
					Transform transform2 = ownerDefaultTarget.transform;
					Transform parent2 = transform2.parent;
					GameObject gameObject = parent2.gameObject;
					value = gameObject;
				}
				fsmGameObject = storeResult;
			}
			else
			{
				value = null;
				fsmGameObject = storeResult;
			}
			fsmGameObject.Value = value;
			Finish();
		}

		[Token(Token = "0x6000A23")]
		[Address(RVA = "0xA326E8", Offset = "0xA326E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetParent()
		{
		}
	}
}
