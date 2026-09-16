using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755FAC", Offset = "0x755FAC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755FAC", Offset = "0x755FAC")]
	[Token(Token = "0x20001E0")]
	public class DetachChildren : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0888", Offset = "0x7B0888")]
		[Token(Token = "0x4001436")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x60009EC")]
		[Address(RVA = "0xB70328", Offset = "0xB70328", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x60009ED")]
		[Address(RVA = "0xB70330", Offset = "0xB70330", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tHutongGames.PlayMaker.Actions.DetachChildren::DoDetachChildren(v14);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			DoDetachChildren(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x60009EE")]
		[Address(RVA = "0xB70370", Offset = "0xB70370", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEE008]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20228F5]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Inequality(go, 0);\n\tv57 = v55 == 0;\n\tif (v57) goto L_003A;\n\tv65 = UnityEngine.GameObject::get_transform(go);\n\tUnityEngine.Transform::DetachChildren(v65);\n\treturn;\nL_003A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DoDetachChildren(GameObject go)
		{
			if (go != null)
			{
				Transform transform = go.transform;
				transform.DetachChildren();
			}
		}

		[Token(Token = "0x60009EF")]
		[Address(RVA = "0xB70410", Offset = "0xB70410", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DetachChildren()
		{
		}
	}
}
