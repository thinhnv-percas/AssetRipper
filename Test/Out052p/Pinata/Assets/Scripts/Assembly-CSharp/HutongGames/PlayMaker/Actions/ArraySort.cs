using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753DC4", Offset = "0x753DC4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753DC4", Offset = "0x753DC4")]
	[Token(Token = "0x200017E")]
	public class ArraySort : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AA2D0", Offset = "0x7AA2D0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA2D0", Offset = "0x7AA2D0")]
		[Token(Token = "0x4001278")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Token(Token = "0x6000846")]
		[Address(RVA = "0xA8A168", Offset = "0xA8A168", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.array = 0;\n\treturn;\n")]
		public override void Reset()
		{
			array = null;
		}

		[Token(Token = "0x6000847")]
		[Address(RVA = "0xA8A170", Offset = "0xA8A170", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ECEDF0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221BA]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmArray::get_Values(this.array);\n\tv65 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v65, v44);\n\tSystem.Collections.Generic.List`1<System.Object>::Sort(v65);\n\tv97 = System.Collections.Generic.List`1<System.Object>::ToArray(v65);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.array, v97);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv52 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_001d: Expected I4, but got O
			object[] values = array.Values;
			object obj = new List<object>((int)values);
			((List<object>)obj).Sort();
			object[] values2 = ((List<object>)obj).ToArray();
			array.Values = values2;
			Finish();
		}

		[Token(Token = "0x6000848")]
		[Address(RVA = "0xA8A250", Offset = "0xA8A250", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArraySort()
		{
		}
	}
}
