using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7539B4", Offset = "0x7539B4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7539B4", Offset = "0x7539B4")]
	[Token(Token = "0x2000171")]
	public class ArrayClear : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9230", Offset = "0x7A9230")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9230", Offset = "0x7A9230")]
		[Token(Token = "0x400123E")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Attribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A9280", Offset = "0x7A9280")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9280", Offset = "0x7A9280")]
		[Token(Token = "0x400123F")]
		[FieldOffset(Offset = "0x58")]
		public FsmVar resetValue;

		[Token(Token = "0x600080C")]
		[Address(RVA = "0xA88974", Offset = "0xA88974", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDB778]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221AF]) = v38;\nL_0013:\n\tthis.array = 0;\n\tv42 = new HutongGames.PlayMaker.FsmVar();\n\tHutongGames.PlayMaker.FsmVar::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.resetValue = v42;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			array = null;
			FsmVar fsmVar = new FsmVar();
			fsmVar.useVariable = true;
			resetValue = fsmVar;
		}

		[Token(Token = "0x600080D")]
		[Address(RVA = "0xA889EC", Offset = "0xA889EC", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tHutongGames.PlayMaker.FsmArray::Reset(this.array);\n\tHutongGames.PlayMaker.FsmArray::Resize(this.array, v19);\n\tv158 = HutongGames.PlayMaker.FsmVar::get_IsNone(this.resetValue);\n\tv160 = v158 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0059;\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(this.resetValue);\n\tv189 = HutongGames.PlayMaker.FsmVar::GetValue(this.resetValue);\n\tv166 = v19 < 1;\n\tif (v166) goto L_0059;\nL_0042:\n\tHutongGames.PlayMaker.FsmArray::Set(this.array, v24, v189);\n\tv24 = v24 + 1;\n\tv165 = v24 < v19;\n\tif (v165) goto L_0042;\nL_0059:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			int length = array.Length;
			array.Reset();
			array.Resize(length);
			if (!resetValue.IsNone)
			{
				resetValue.UpdateValue();
				object value = resetValue.GetValue();
				if (length >= 1)
				{
					int num = 0;
					do
					{
						array.Set(num, value);
						num++;
					}
					while (num < length);
				}
			}
			Finish();
		}

		[Token(Token = "0x600080E")]
		[Address(RVA = "0xA88AC8", Offset = "0xA88AC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayClear()
		{
		}
	}
}
