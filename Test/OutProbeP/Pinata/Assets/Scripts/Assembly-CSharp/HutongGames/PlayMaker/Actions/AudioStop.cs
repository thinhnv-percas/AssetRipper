using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754390", Offset = "0x754390")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754390", Offset = "0x754390")]
	[Token(Token = "0x2000188")]
	public class AudioStop : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AB100", Offset = "0x7AB100")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB100", Offset = "0x7AB100")]
		[Token(Token = "0x40012A5")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x600086E")]
		[Address(RVA = "0xA8AF48", Offset = "0xA8AF48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x600086F")]
		[Address(RVA = "0xA8AF50", Offset = "0xA8AF50", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0BC50]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221C2]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv77 = *([v50 @ X8_v4+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002B;\n\tv84 = v50;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v84, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv66 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv86 = v66 == 0;\n\tif (v86) goto L_0056;\n\tv119 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0045;\n\tv123 = *([v72 @ X8_v8+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0045;\n\tv130 = v72;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v130, v118, v60, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv67 = UnityEngine.Object::op_Inequality(v119, 0);\n\tv113 = v67 == 0;\n\tif (v113) goto L_0056;\n\tUnityEngine.AudioSource::Stop(v119);\nL_0056:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				AudioSource component = ownerDefaultTarget.GetComponent<AudioSource>();
				if (component != null)
				{
					component.Stop();
				}
			}
			Finish();
		}

		[Token(Token = "0x6000870")]
		[Address(RVA = "0xA8B058", Offset = "0xA8B058", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AudioStop()
		{
		}
	}
}
