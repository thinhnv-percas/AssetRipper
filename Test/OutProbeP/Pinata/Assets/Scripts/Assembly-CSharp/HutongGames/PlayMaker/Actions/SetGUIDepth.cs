using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756E00", Offset = "0x756E00")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x756E00", Offset = "0x756E00")]
	[Token(Token = "0x200020E")]
	public class SetGUIDepth : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40014D2")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt depth;

		[Token(Token = "0x6000A99")]
		[Address(RVA = "0x99438C", Offset = "0x99438C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.depth = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmInt fsmInt = 0;
			depth = fsmInt;
		}

		[Token(Token = "0x6000A9A")]
		[Address(RVA = "0x9943B8", Offset = "0x9943B8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleOnGUI(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleOnGUI = true;
		}

		[Token(Token = "0x6000A9B")]
		[Address(RVA = "0x9943D8", Offset = "0x9943D8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB00A0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021747]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmInt::get_Value(this.depth);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv74 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.GUI::set_depth(v42);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			int value = depth.Value;
			GUI.depth = value;
		}

		[Token(Token = "0x6000A9C")]
		[Address(RVA = "0x99445C", Offset = "0x99445C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUIDepth()
		{
		}
	}
}
