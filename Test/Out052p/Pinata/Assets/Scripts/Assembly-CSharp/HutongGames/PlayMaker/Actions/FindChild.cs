using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755FFC", Offset = "0x755FFC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755FFC", Offset = "0x755FFC")]
	[Token(Token = "0x20001E1")]
	public class FindChild : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B08D4", Offset = "0x7B08D4")]
		[Token(Token = "0x4001437")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0920", Offset = "0x7B0920")]
		[Token(Token = "0x4001438")]
		[FieldOffset(Offset = "0x58")]
		public FsmString childName;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B096C", Offset = "0x7B096C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B096C", Offset = "0x7B096C")]
		[Token(Token = "0x4001439")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject storeResult;

		[Token(Token = "0x60009F0")]
		[Address(RVA = "0xB75040", Offset = "0xB75040", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F03428]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022921]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.childName = v43;\n\tthis.storeResult = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			childName = fsmString;
			storeResult = null;
		}

		[Token(Token = "0x60009F1")]
		[Address(RVA = "0xB7509C", Offset = "0xB7509C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FindChild::DoFindChild(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFindChild();
			Finish();
		}

		[Token(Token = "0x60009F2")]
		[Address(RVA = "0xB750C4", Offset = "0xB750C4", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EED000]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022922]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv72 = *([v68 @ X8_v4+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_002B;\n\tv111 = v68;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v111, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv82 = UnityEngine.Object::op_Equality(v45, 0);\n\tv98 = v82 == 0;\n\tif (v98) goto L_003A;\n\treturn;\nL_003A:\n\tv116 = UnityEngine.GameObject::get_transform(v45);\n\tv121 = HutongGames.PlayMaker.FsmString::get_Value(this.childName);\n\tv136 = UnityEngine.Transform::Find(v116, v121);\n\tgoto L_0058;\n\tv140 = *([v104 @ X8_v7+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0058;\n\tv148 = v104;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v148, v118, v135, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0058:\n\tv122 = UnityEngine.Object::op_Inequality(v136, 0);\n\tv150 = v122 == 0;\n\tif (v150) goto L_006D;\n\tv152 = UnityEngine.Component::get_gameObject(v136);\nL_006D:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeResult, v94);\n\treturn;\n\tv56 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFindChild()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(this.gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Transform transform = ownerDefaultTarget.transform;
				string value = childName.Value;
				Transform transform2 = transform.Find(value);
				bool flag = transform2 != null;
				bool flag2 = !flag;
				GameObject value2 = null;
				if (!flag2)
				{
					GameObject gameObject = transform2.gameObject;
					value2 = gameObject;
				}
				storeResult.Value = value2;
			}
		}

		[Token(Token = "0x60009F3")]
		[Address(RVA = "0xB75210", Offset = "0xB75210", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FindChild()
		{
		}
	}
}
