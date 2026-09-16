using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753964", Offset = "0x753964")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753964", Offset = "0x753964")]
	[Token(Token = "0x2000170")]
	public class ArrayAddRange : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9160", Offset = "0x7A9160")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9160", Offset = "0x7A9160")]
		[Token(Token = "0x400123C")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[RequiredField]
		[AttributeAttribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A91C0", Offset = "0x7A91C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A91C0", Offset = "0x7A91C0")]
		[Token(Token = "0x400123D")]
		[FieldOffset(Offset = "0x58")]
		public FsmVar[] variables;

		[Token(Token = "0x6000808")]
		[Address(RVA = "0xA887DC", Offset = "0xA887DC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFC758]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221AE]) = v38;\nL_0013:\n\tthis.array = 0;\n\t// 24 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmVar[]), typeof(HutongGames.PlayMaker.FsmVar[]), 2\n\tthis.variables = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			this.array = null;
			FsmVar[] array = new FsmVar[2];
			variables = array;
		}

		[Token(Token = "0x6000809")]
		[Address(RVA = "0xA88838", Offset = "0xA88838", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayAddRange::DoAddRange(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddRange();
			Finish();
		}

		[Token(Token = "0x600080A")]
		[Address(RVA = "0xA88860", Offset = "0xA88860", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = this.variables;\n\tv35 = v22.Length < 1;\n\tif (v35) goto L_0072;\n\tv203 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv56 = v203 + v22.Length;\n\tHutongGames.PlayMaker.FsmArray::Resize(this.array, v56);\n\tv49 = this.variables;\n\tv199 = v49.Length;\n\tv135 = v49.Length < 1;\n\tif (v135) goto L_0072;\n\tv45 = 0 - v22.Length;\nL_0038:\n\tv243 = v47 < v199;\n\tv92 = ~v243;\n\tif (v92) goto L_0075;\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(v49[v47 @ X24_v6 (System.Int32)]);\n\tv246 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv249 = HutongGames.PlayMaker.FsmVar::GetValue(v49[v47 @ X24_v6 (System.Int32)]);\n\tv250 = v45 + v246;\n\tv129 = v250 + v47;\n\tHutongGames.PlayMaker.FsmArray::Set(this.array, v129, v249);\n\tv199 = v49.Length;\n\tv47 = v47 + 1;\n\tv134 = v47 < v49.Length;\n\tif (v134) goto L_0038;\nL_0072:\n\treturn;\n\tv104 = new System.NullReferenceException();\nL_0075:\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow v200;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddRange()
		{
			//IL_00a8: Expected O, but got I4
			//IL_0105: Expected O, but got I
			FsmVar[] array = variables;
			if (array.Length < 1)
			{
				return;
			}
			int length = this.array.Length;
			int newLength = length + array.Length;
			this.array.Resize(newLength);
			FsmVar[] array2 = variables;
			int num = array2.Length;
			if (array2.Length < 1)
			{
				return;
			}
			object obj = -array.Length;
			int num2 = 0;
			while (num2 < num)
			{
				array2[num2].UpdateValue();
				int length2 = this.array.Length;
				object value = array2[num2].GetValue();
				object obj2 = (long)(IntPtr)obj + (long)length2;
				int index = (int)((long)(IntPtr)obj2 + (long)num2);
				this.array.Set(index, value);
				num = array2.Length;
				num2++;
				if (num2 >= array2.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600080B")]
		[Address(RVA = "0xA8896C", Offset = "0xA8896C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayAddRange()
		{
		}
	}
}
