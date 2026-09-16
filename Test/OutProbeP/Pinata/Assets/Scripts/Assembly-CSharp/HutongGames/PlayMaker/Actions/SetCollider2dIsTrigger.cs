using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75ACAC", Offset = "0x75ACAC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75ACAC", Offset = "0x75ACAC")]
	[Token(Token = "0x20002CF")]
	public class SetCollider2dIsTrigger : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BF4E0", Offset = "0x7BF4E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF4E0", Offset = "0x7BF4E0")]
		[Token(Token = "0x4001885")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF578", Offset = "0x7BF578")]
		[Token(Token = "0x4001886")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool isTrigger;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF5C4", Offset = "0x7BF5C4")]
		[Token(Token = "0x4001887")]
		[FieldOffset(Offset = "0x60")]
		public bool setAllColliders;

		[Token(Token = "0x6000E11")]
		[Address(RVA = "0xB2C918", Offset = "0xB2C918", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.isTrigger = v12;\n\tthis.setAllColliders = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			isTrigger = fsmBool;
			setAllColliders = false;
		}

		[Token(Token = "0x6000E12")]
		[Address(RVA = "0xB2C94C", Offset = "0xB2C94C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetCollider2dIsTrigger::DoSetIsTrigger(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetIsTrigger();
			Finish();
		}

		[Token(Token = "0x6000E13")]
		[Address(RVA = "0xB2C974", Offset = "0xB2C974", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EC4CC0]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022629]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv132 = *([v106 @ X8_v6+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_002C;\n\tv144 = v106;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v144, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv140 = UnityEngine.Object::op_Equality(v47, 0);\n\tv146 = v140 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_00AA;\n\tv243 = ~this.setAllColliders;\n\tif (v243) goto L_0077;\n\tv93 = UnityEngine.GameObject::GetComponents(v47);\n\tv100 = v93.Length;\n\tv193 = v93.Length < 1;\n\tif (v193) goto L_00AA;\nL_004C:\n\tv304 = v52 < v100;\n\tv79 = ~v304;\n\tif (v79) goto L_00AC;\n\tv173 = HutongGames.PlayMaker.FsmBool::get_Value(this.isTrigger);\n\tUnityEngine.Collider2D::set_isTrigger(v93[v52 @ X22_v10 (System.Int32)], v173);\n\tv100 = v93.Length;\n\tv52 = v52 + 1;\n\tv194 = v52 < v93.Length;\n\tif (v194) goto L_004C;\n\tgoto L_00AA;\nL_0077:\n\tv280 = UnityEngine.GameObject::GetComponent(v47);\n\tgoto L_0087;\n\tv286 = *([v234 @ X8_v9+E0]);\n\tv287 = v286 == 0;\n\tv288 = ~v287;\n\tif (v288) goto L_0087;\n\tv294 = v234;\n\tv290 = \"il2cpp_codegen_runtime_class_init\"(v294, v279, v87, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0087:\n\tv228 = UnityEngine.Object::op_Inequality(v280, 0);\n\tv230 = v228 == 0;\n\tif (v230) goto L_00AA;\n\tv174 = UnityEngine.GameObject::GetComponent(v47);\n\tv175 = HutongGames.PlayMaker.FsmBool::get_Value(this.isTrigger);\n\tUnityEngine.Collider2D::set_isTrigger(v174, v175);\n\treturn;\nL_00AA:\n\treturn;\n\tv103 = new System.NullReferenceException();\nL_00AC:\n\tv131 = new System.IndexOutOfRangeException();\n\tthrow v131;\n\tthrow System.NullReferenceException;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetIsTrigger()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			if (setAllColliders)
			{
				Collider2D[] components = ownerDefaultTarget.GetComponents<Collider2D>();
				int num = components.Length;
				if (components.Length < 1)
				{
					return;
				}
				int num2 = 0;
				while (num2 < num)
				{
					bool value = isTrigger.Value;
					components[num2].isTrigger = value;
					num = components.Length;
					num2++;
					if (num2 >= components.Length)
					{
						return;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			Collider2D component = ownerDefaultTarget.GetComponent<Collider2D>();
			if (component != null)
			{
				Collider2D component2 = ownerDefaultTarget.GetComponent<Collider2D>();
				bool value2 = isTrigger.Value;
				component2.isTrigger = value2;
			}
		}

		[Token(Token = "0x6000E14")]
		[Address(RVA = "0xB2CB34", Offset = "0xB2CB34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetCollider2dIsTrigger()
		{
		}
	}
}
