using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7548FC", Offset = "0x7548FC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7548FC", Offset = "0x7548FC")]
	[Token(Token = "0x2000199")]
	public class SetMainCamera : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7ABEF0", Offset = "0x7ABEF0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABEF0", Offset = "0x7ABEF0")]
		[Token(Token = "0x40012E7")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[Token(Token = "0x60008BA")]
		[Address(RVA = "0x996AB4", Offset = "0x996AB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x60008BB")]
		[Address(RVA = "0x996ABC", Offset = "0x996ABC", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EFB3F8]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021771]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_002A;\n\tv80 = *([v76 @ X8_v4+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002A;\n\tv113 = v76;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v113, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv90 = UnityEngine.Object::op_Inequality(v44, 0);\n\tv115 = v90 == 0;\n\tif (v115) goto L_0064;\n\tv117 = UnityEngine.Camera::get_main();\n\tgoto L_003F;\n\tv127 = *([v69 @ X8_v6+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_003F;\n\tv135 = v69;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v135, v88, v89, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003F:\n\tv134 = UnityEngine.Object::op_Inequality(v117, 0);\n\tv137 = v134 == 0;\n\tif (v137) goto L_0054;\n\tv59 = UnityEngine.Camera::get_main();\n\tv60 = UnityEngine.Component::get_gameObject(v59);\n\tUnityEngine.GameObject::set_tag(v60, \"Untagged\");\nL_0054:\n\tv62 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tUnityEngine.GameObject::set_tag(v62, \"MainCamera\");\nL_0064:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject value = this.gameObject.Value;
			if (value != null)
			{
				Camera main = Camera.main;
				if (main != null)
				{
					Camera main2 = Camera.main;
					GameObject gameObject = main2.gameObject;
					gameObject.tag = "Untagged";
				}
				GameObject value2 = this.gameObject.Value;
				value2.tag = "MainCamera";
			}
			Finish();
		}

		[Token(Token = "0x60008BC")]
		[Address(RVA = "0x996BEC", Offset = "0x996BEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetMainCamera()
		{
		}
	}
}
