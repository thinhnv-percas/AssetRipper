using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x741934", Offset = "0x741934")]
	[Token(Token = "0x2000014")]
	public class TitleAttribute : Attribute
	{
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x10")]
		public string Title;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x18")]
		public string Subtitle;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x20")]
		public bool Bold;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x21")]
		public bool HorizontalLine;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x24")]
		public TitleAlignments TitleAlignment;

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x167F3EC", Offset = "0x167F3EC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv38 = *([1EC5788]);\n\tv39 = *([v38 @ X8_v11]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, title, subtitle, titleAlignment, horizontalLine, bold, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202B573]) = v53;\nL_001F:\n\tSystem.Attribute::.ctor(this);\n\tthis.Bold = bold;\n\tthis.TitleAlignment = titleAlignment;\n\tthis.HorizontalLine = horizontalLine;\n\tv71 = title != 0;\n\tif (v71) goto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\tthis.Title = v76;\n\tthis.Subtitle = subtitle;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TitleAttribute(string title, string subtitle = null, TitleAlignments titleAlignment = TitleAlignments.Left, bool horizontalLine = true, bool bold = true)
		{
			Bold = bold;
			TitleAlignment = titleAlignment;
			HorizontalLine = horizontalLine;
			Title = ((title != null) ? title : "null");
			Subtitle = subtitle;
		}
	}
}
