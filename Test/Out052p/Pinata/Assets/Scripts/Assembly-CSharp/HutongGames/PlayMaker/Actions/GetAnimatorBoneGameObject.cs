using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752794", Offset = "0x752794")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x752794", Offset = "0x752794")]
	[Token(Token = "0x2000137")]
	public class GetAnimatorBoneGameObject : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A4110", Offset = "0x7A4110")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4110", Offset = "0x7A4110")]
		[Token(Token = "0x4001123")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A41A8", Offset = "0x7A41A8")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7A41A8", Offset = "0x7A41A8")]
		[Token(Token = "0x4001124")]
		[FieldOffset(Offset = "0x58")]
		public FsmEnum bone;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A4230", Offset = "0x7A4230")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A4230", Offset = "0x7A4230")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4230", Offset = "0x7A4230")]
		[Token(Token = "0x4001125")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject boneGameObject;

		[Token(Token = "0x4001126")]
		[FieldOffset(Offset = "0x68")]
		private Animator _animator;

		[Token(Token = "0x60006FF")]
		[Address(RVA = "0xB7E0B0", Offset = "0xB7E0B0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB3670]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202298A]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv42 = 0;\n\t// 25 Box v44 @ X0_v3 (System.Enum), typeof(UnityEngine.HumanBodyBones), &v42 @ stack_-24_v1\n\tv46 = HutongGames.PlayMaker.FsmEnum::op_Implicit(v44);\n\tthis.bone = v46;\n\tthis.boneGameObject = 0;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0015: Expected O, but got I4
			//IL_001e: Expected I4, but got O
			gameObject = null;
			object obj = 0;
			Enum obj2 = (HumanBodyBones)obj;
			FsmEnum fsmEnum = obj2;
			bone = fsmEnum;
			boneGameObject = null;
		}

		[Token(Token = "0x6000700")]
		[Address(RVA = "0xB7E120", Offset = "0xB7E120", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F043F0]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202298B]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.GetAnimatorBoneGameObject::GetBoneTransform(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				GetBoneTransform();
			}
			Finish();
		}

		[Token(Token = "0x6000701")]
		[Address(RVA = "0xB7E21C", Offset = "0xB7E21C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFD460]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202298C]) = v38;\nL_0019:\n\tv44 = HutongGames.PlayMaker.FsmEnum::get_Value(this.bone);\n\tv49 = v49_asT == 0;\n\tif (v49) goto L_0047;\n\tv135 = \"il2cpp_vm_object_unbox\"(v44, UnityEngine.HumanBodyBones, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv80 = UnityEngine.Animator::GetBoneTransform(this._animator, *([v135 @ X0_v11]));\n\tv104 = UnityEngine.Component::get_gameObject(v80);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.boneGameObject, v104);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv111 = new System.NullReferenceException();\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetBoneTransform()
		{
			//IL_0026: Expected I4, but got O
			//IL_005c: Expected I4, but got O
			Enum value = bone.Value;
			if ((int)((value is HumanBodyBones) ? value : null) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				Transform boneTransform = _animator.GetBoneTransform((HumanBodyBones)obj);
				GameObject value2 = boneTransform.gameObject;
				boneGameObject.Value = value2;
				return;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x6000702")]
		[Address(RVA = "0xB7E2D8", Offset = "0xB7E2D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorBoneGameObject()
		{
		}
	}
}
