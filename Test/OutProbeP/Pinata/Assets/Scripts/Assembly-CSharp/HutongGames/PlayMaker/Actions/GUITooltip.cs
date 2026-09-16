using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756B30", Offset = "0x756B30")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x756B30", Offset = "0x756B30")]
	[Token(Token = "0x2000205")]
	public class GUITooltip : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1F10", Offset = "0x7B1F10")]
		[Token(Token = "0x40014B7")]
		[FieldOffset(Offset = "0x50")]
		public FsmString storeTooltip;

		[Token(Token = "0x6000A7D")]
		[Address(RVA = "0xB7C5CC", Offset = "0xB7C5CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeTooltip = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeTooltip = null;
		}

		[Token(Token = "0x6000A7E")]
		[Address(RVA = "0xB7C5D4", Offset = "0xB7C5D4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC0548]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022973]) = v38;\nL_0015:\n\tv41 = this.storeTooltip;\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = UnityEngine.GUI::get_tooltip();\n\tv41.value = v54;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			FsmString fsmString = storeTooltip;
			string tooltip = GUI.tooltip;
			fsmString.Value = tooltip;
		}

		[Token(Token = "0x6000A7F")]
		[Address(RVA = "0xB7C650", Offset = "0xB7C650", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUITooltip()
		{
		}
	}
}
