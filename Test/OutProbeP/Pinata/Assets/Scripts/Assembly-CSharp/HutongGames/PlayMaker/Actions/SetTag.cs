using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75677C", Offset = "0x75677C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75677C", Offset = "0x75677C")]
	[Token(Token = "0x20001F9")]
	public class SetTag : FsmStateAction
	{
		[Token(Token = "0x4001486")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B17F8", Offset = "0x7B17F8")]
		[Token(Token = "0x4001487")]
		[FieldOffset(Offset = "0x58")]
		public FsmString tag;

		[Token(Token = "0x6000A57")]
		[Address(RVA = "0x999C04", Offset = "0x999C04", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC8248]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021795]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Untagged\");\n\tthis.tag = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "Untagged";
			tag = fsmString;
		}

		[Token(Token = "0x6000A58")]
		[Address(RVA = "0x999C60", Offset = "0x999C60", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF7930]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021796]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv77 = *([v56 @ X8_v7+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002A;\n\tv85 = v56;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v85, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv84 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv87 = v84 == 0;\n\tif (v87) goto L_0040;\n\tv70 = HutongGames.PlayMaker.FsmString::get_Value(this.tag);\n\tUnityEngine.GameObject::set_tag(v43, v70);\nL_0040:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				string value = tag.Value;
				ownerDefaultTarget.tag = value;
			}
			Finish();
		}

		[Token(Token = "0x6000A59")]
		[Address(RVA = "0x999D28", Offset = "0x999D28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetTag()
		{
		}
	}
}
