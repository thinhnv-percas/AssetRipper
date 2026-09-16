using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755190", Offset = "0x755190")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755190", Offset = "0x755190")]
	[Token(Token = "0x20001B6")]
	public class Comment : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE118", Offset = "0x7AE118")]
		[Token(Token = "0x4001372")]
		[FieldOffset(Offset = "0x50")]
		public string comment;

		[Token(Token = "0x600094A")]
		[Address(RVA = "0xA9140C", Offset = "0xA9140C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA7A48]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221F8]) = v38;\nL_0016:\n\tthis.comment = \"\";\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			comment = "";
		}

		[Token(Token = "0x600094B")]
		[Address(RVA = "0xA9145C", Offset = "0xA9145C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Finish();
		}

		[Token(Token = "0x600094C")]
		[Address(RVA = "0xA91464", Offset = "0xA91464", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Comment()
		{
		}
	}
}
