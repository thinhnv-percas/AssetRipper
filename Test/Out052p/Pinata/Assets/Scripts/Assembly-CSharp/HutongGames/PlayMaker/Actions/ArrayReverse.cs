using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753CD4", Offset = "0x753CD4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753CD4", Offset = "0x753CD4")]
	[Token(Token = "0x200017B")]
	public class ArrayReverse : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AA000", Offset = "0x7AA000")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA000", Offset = "0x7AA000")]
		[Token(Token = "0x400126F")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Token(Token = "0x600083B")]
		[Address(RVA = "0xA89C28", Offset = "0xA89C28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.array = 0;\n\treturn;\n")]
		public override void Reset()
		{
			array = null;
		}

		[Token(Token = "0x600083C")]
		[Address(RVA = "0xA89C30", Offset = "0xA89C30", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EA3A60]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221B7]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmArray::get_Values(this.array);\n\tv65 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v65, v44);\n\tSystem.Collections.Generic.List`1<System.Object>::Reverse(v65);\n\tv97 = System.Collections.Generic.List`1<System.Object>::ToArray(v65);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.array, v97);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv52 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_001d: Expected I4, but got O
			object[] values = array.Values;
			object obj = new List<object>((int)values);
			((List<object>)obj).Reverse();
			object[] values2 = ((List<object>)obj).ToArray();
			array.Values = values2;
			Finish();
		}

		[Token(Token = "0x600083D")]
		[Address(RVA = "0xA89D10", Offset = "0xA89D10", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayReverse()
		{
		}
	}
}
