using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754244", Offset = "0x754244")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754244", Offset = "0x754244")]
	[Token(Token = "0x2000186")]
	public class AudioPause : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AAE84", Offset = "0x7AAE84")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAE84", Offset = "0x7AAE84")]
		[Token(Token = "0x400129E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x6000867")]
		[Address(RVA = "0xA8AA70", Offset = "0xA8AA70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x6000868")]
		[Address(RVA = "0xA8AA78", Offset = "0xA8AA78", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB9C80]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221BF]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv77 = *([v50 @ X8_v4+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002B;\n\tv84 = v50;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v84, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv66 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv86 = v66 == 0;\n\tif (v86) goto L_0056;\n\tv119 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0045;\n\tv123 = *([v72 @ X8_v8+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0045;\n\tv130 = v72;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v130, v118, v60, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv67 = UnityEngine.Object::op_Inequality(v119, 0);\n\tv113 = v67 == 0;\n\tif (v113) goto L_0056;\n\tUnityEngine.AudioSource::Pause(v119);\nL_0056:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				AudioSource component = ownerDefaultTarget.GetComponent<AudioSource>();
				if (component != null)
				{
					component.Pause();
				}
			}
			Finish();
		}

		[Token(Token = "0x6000869")]
		[Address(RVA = "0xA8AB80", Offset = "0xA8AB80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AudioPause()
		{
		}
	}
}
