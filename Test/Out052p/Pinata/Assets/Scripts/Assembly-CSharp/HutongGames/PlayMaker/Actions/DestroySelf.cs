using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755F5C", Offset = "0x755F5C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755F5C", Offset = "0x755F5C")]
	[Token(Token = "0x20001DF")]
	public class DestroySelf : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0850", Offset = "0x7B0850")]
		[Token(Token = "0x4001435")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool detachChildren;

		[Token(Token = "0x60009E9")]
		[Address(RVA = "0xA86704", Offset = "0xA86704", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.detachChildren = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = false;
			detachChildren = fsmBool;
		}

		[Token(Token = "0x60009EA")]
		[Address(RVA = "0xA86730", Offset = "0xA86730", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EA5868]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202219B]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(this.owner, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_004F;\n\tv81 = HutongGames.PlayMaker.FsmBool::get_Value(this.detachChildren);\n\tv92 = v81 == 0;\n\tif (v92) goto L_003E;\n\tv86 = UnityEngine.GameObject::get_transform(this.owner);\n\tUnityEngine.Transform::DetachChildren(v86);\nL_003E:\n\tgoto L_0046;\n\tv110 = *([v106 @ X0_v13+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0046;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v106, v102, v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tUnityEngine.Object::Destroy(this.owner);\nL_004F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (Owner != null)
			{
				if (detachChildren.Value)
				{
					Transform transform = Owner.transform;
					transform.DetachChildren();
				}
				Object.Destroy(Owner);
			}
			Finish();
		}

		[Token(Token = "0x60009EB")]
		[Address(RVA = "0xA86814", Offset = "0xA86814", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DestroySelf()
		{
		}
	}
}
