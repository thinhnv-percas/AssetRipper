using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7581C4", Offset = "0x7581C4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7581C4", Offset = "0x7581C4")]
	[Token(Token = "0x200024A")]
	public class DontDestroyOnLoad : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B48E8", Offset = "0x7B48E8")]
		[Token(Token = "0x40015BB")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x6000B79")]
		[Address(RVA = "0xB7068C", Offset = "0xB7068C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x6000B7A")]
		[Address(RVA = "0xB70694", Offset = "0xB70694", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EE36B0]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20228F7]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv84 = *([v63 @ X8_v5+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_002B;\n\tv91 = v63;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v91, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv77 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv93 = v77 == 0;\n\tif (v93) goto L_0053;\n\tv57 = UnityEngine.GameObject::get_transform(v45);\n\tv58 = UnityEngine.Transform::get_root(v57);\n\tv126 = UnityEngine.Component::get_gameObject(v58);\n\tgoto L_004A;\n\tv130 = *([v121 @ X8_v7+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_004A;\n\tv135 = v121;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v135, v125, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004A:\n\tUnityEngine.Object::DontDestroyOnLoad(v126);\nL_0053:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				Transform transform = ownerDefaultTarget.transform;
				Transform root = transform.root;
				GameObject target = root.gameObject;
				Object.DontDestroyOnLoad(target);
			}
			Finish();
		}

		[Token(Token = "0x6000B7B")]
		[Address(RVA = "0xB70794", Offset = "0xB70794", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DontDestroyOnLoad()
		{
		}
	}
}
