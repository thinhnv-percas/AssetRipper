using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EA8C", Offset = "0x73EA8C")]
	[Token(Token = "0x2000031")]
	public sealed class ActionCategoryAttribute : Attribute
	{
		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x10")]
		private readonly string category;

		[Token(Token = "0x17000036")]
		public string Category
		{
			[Token(Token = "0x6000105")]
			[Address(RVA = "0x9C7E04", Offset = "0x9C7E04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.category;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Category;
			}
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x9C7E0C", Offset = "0x9C7E0C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.category = category;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionCategoryAttribute(string category)
		{
			this.category = category;
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x9C7E38", Offset = "0x9C7E38", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F037A0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, category, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20219C0]) = v41;\nL_0017:\n\tSystem.Attribute::.ctor(this);\n\t// 28 Box v48 @ X0_v4, typeof(HutongGames.PlayMaker.ActionCategory), &category @ X1 (HutongGames.PlayMaker.ActionCategory)\n\tv51 = *([v48 @ X0_v4]);\n\t*([v51 @ X8_v5+160])(v55, v48, *([v51 @ X8_v5+168]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = \"il2cpp_vm_object_unbox\"(v48, *([v51 @ X8_v5+168]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.category = v55;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionCategoryAttribute(ActionCategory category)
		{
			object obj = category;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v51 @ X8_v5+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string text = default(string);
			this.category = text;
		}
	}
}
