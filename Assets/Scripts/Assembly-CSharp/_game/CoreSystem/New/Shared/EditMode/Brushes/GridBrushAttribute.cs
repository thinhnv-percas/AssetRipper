using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	[Token(Token = "0x200028D")]
	public sealed class GridBrushAttribute : Attribute
	{
		[Token(Token = "0x170000D8")]
		[field: Token(Token = "0x4000805")]
		[field: FieldOffset(Offset = "0x10")]
		public int Order
		{
			[Token(Token = "0x6000B5F")]
			[Address(RVA = "0x3EC687C", Offset = "0x3EC687C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Order;\n")]
			get;
		}

		[Token(Token = "0x170000D9")]
		[field: Token(Token = "0x4000806")]
		[field: FieldOffset(Offset = "0x18")]
		public string GridId
		{
			[Token(Token = "0x6000B60")]
			[Address(RVA = "0x3EC6884", Offset = "0x3EC6884", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.GridId;\n")]
			get;
		}

		[Token(Token = "0x6000B61")]
		[Address(RVA = "0x3EC688C", Offset = "0x3EC688C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tv21 = gridId == 0;\n\tv22 = ~v21;\n\tv30 = gridId;\n\tif (v22) goto L_0018;\n\tv24 = 0xB7D5000 + 0x538;\n\tv25 = *([v24 @ X8_v3 (System.Int32)+90]);\n\tv26 = *([v25 @ X8_v4+B8]);\n\tv30 = *([v26 @ X8_v5]);\nL_0018:\n\tthis.GridId = v30;\n\tthis.Order = order;\n\treturn;\n")]
		public GridBrushAttribute(string gridId, int order = 0)
		{
			bool flag = gridId == null;
			bool flag2 = !flag;
			string text = gridId;
			if (!flag2)
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X8_v3 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X8_v4+B8]");
				object obj2 = 0;
				text = (string)obj2;
			}
			GridId = text;
			Order = order;
		}
	}
}
